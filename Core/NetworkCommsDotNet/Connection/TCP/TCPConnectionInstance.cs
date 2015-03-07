﻿//  Copyright 2011-2013 Marc Fletcher, Matthew Dean
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
//  A commercial license of this software can also be purchased. 
//  Please see <http://www.networkcomms.net/licensing/> for details.

using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;
using DPSBase;

#if WINDOWS_PHONE
using Windows.Networking.Sockets;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage.Streams;
#endif

namespace NetworkCommsDotNet
{
    public sealed partial class TCPConnection : Connection
    {
        /// <summary>
        /// Asynchronous incoming connection data delegate
        /// </summary>
        /// <param name="ar">The call back state object</param>
        void IncomingTCPPacketHandler(IAsyncResult ar)
        {
            //Initialised with true so that logic still works in WP8
            bool dataAvailable = true;

#if !WINDOWS_PHONE
            //Incoming data always gets handled in a timeCritical fashion at this point
            Thread.CurrentThread.Priority = NetworkComms.timeCriticalThreadPriority;
            //int bytesRead;
#endif

            try
            {
#if WINDOWS_PHONE
                var stream = ar.AsyncState as Stream;
                var count = stream.EndRead(ar);
                totalBytesRead = count + totalBytesRead;
#else
                NetworkStream netStream = (NetworkStream)ar.AsyncState;
                if (!netStream.CanRead)
                    throw new ObjectDisposedException("Unable to read from stream.");

                totalBytesRead = netStream.EndRead(ar) + totalBytesRead;
                dataAvailable = netStream.DataAvailable;
#endif
                if (totalBytesRead > 0)
                {
                    ConnectionInfo.UpdateLastTrafficTime();

                    //If we have read a single byte which is 0 and we are not expecting other data
                    if (totalBytesRead == 1 && dataBuffer[0] == 0 && packetBuilder.TotalBytesExpected - packetBuilder.TotalBytesCached == 0)
                    {
                        if (NetworkComms.LoggingEnabled) NetworkComms.Logger.Trace(" ... null packet removed in IncomingPacketHandler() from " + ConnectionInfo + ". 1");
                    }
                    else
                    {
                        //if (NetworkComms.LoggingEnabled) NetworkComms.Logger.Trace(" ... " + totalBytesRead.ToString() + " bytes added to packetBuilder.");

                        //If there is more data to get then add it to the packets lists;
                        packetBuilder.AddPartialPacket(totalBytesRead, dataBuffer);

#if !WINDOWS_PHONE
                        //If we have more data we might as well continue reading syncronously
                        //In order to deal with data as soon as we think we have sufficient we will leave this loop
                        while (dataAvailable && packetBuilder.TotalBytesCached < packetBuilder.TotalBytesExpected)
                        {
                            int bufferOffset = 0;

                            //We need a buffer for our incoming data
                            //First we try to reuse a previous buffer
                            if (packetBuilder.TotalPartialPacketCount > 0 && packetBuilder.NumUnusedBytesMostRecentPartialPacket() > 0)
                                dataBuffer = packetBuilder.RemoveMostRecentPartialPacket(ref bufferOffset);
                            else
                                //If we have nothing to reuse we allocate a new buffer
                                dataBuffer = new byte[NetworkComms.ReceiveBufferSizeBytes];

                            totalBytesRead = netStream.Read(dataBuffer, bufferOffset, dataBuffer.Length - bufferOffset) + bufferOffset;

                            if (totalBytesRead > 0)
                            {
                                ConnectionInfo.UpdateLastTrafficTime();

                                //If we have read a single byte which is 0 and we are not expecting other data
                                if (totalBytesRead == 1 && dataBuffer[0] == 0 && packetBuilder.TotalBytesExpected - packetBuilder.TotalBytesCached == 0)
                                {
                                    if (NetworkComms.LoggingEnabled) NetworkComms.Logger.Trace(" ... null packet removed in IncomingPacketHandler() from " + ConnectionInfo + ". 2");
                                    //LastTrafficTime = DateTime.Now;
                                }
                                else
                                {
                                    //if (NetworkComms.LoggingEnabled) NetworkComms.Logger.Trace(" ... " + totalBytesRead.ToString() + " bytes added to packetBuilder for connection with " + ConnectionInfo + ". Cached " + packetBuilder.TotalBytesCached.ToString() + "B, expecting " + packetBuilder.TotalBytesExpected.ToString() + "B.");
                                    packetBuilder.AddPartialPacket(totalBytesRead, dataBuffer);
                                    dataAvailable = netStream.DataAvailable;
                                }
                            }
                            else
                                break;
                        }
#endif
                    }
                }

                if (packetBuilder.TotalBytesCached > 0 && packetBuilder.TotalBytesCached >= packetBuilder.TotalBytesExpected)
                {
                    //Once we think we might have enough data we call the incoming packet handle handoff
                    //Should we have a complete packet this method will start the appriate task
                    //This method will now clear byes from the incoming packets if we have received something complete.
                    IncomingPacketHandleHandOff(packetBuilder);
                }

                if (totalBytesRead == 0 && (!dataAvailable || ConnectionInfo.ConnectionState == ConnectionState.Shutdown))
                    CloseConnection(false, -2);
                else
                {
                    //We need a buffer for our incoming data
                    //First we try to reuse a previous buffer
                    if (packetBuilder.TotalPartialPacketCount > 0 && packetBuilder.NumUnusedBytesMostRecentPartialPacket() > 0)
                        dataBuffer = packetBuilder.RemoveMostRecentPartialPacket(ref totalBytesRead);
                    else
                    {
                        //If we have nothing to reuse we allocate a new buffer
                        dataBuffer = new byte[NetworkComms.ReceiveBufferSizeBytes];
                        totalBytesRead = 0;
                    }

#if WINDOWS_PHONE
                    stream.BeginRead(dataBuffer, totalBytesRead, dataBuffer.Length - totalBytesRead, IncomingTCPPacketHandler, stream);
#else
                    netStream.BeginRead(dataBuffer, totalBytesRead, dataBuffer.Length - totalBytesRead, IncomingTCPPacketHandler, netStream);
#endif
                }

            }
            catch (IOException)
            {
                CloseConnection(true, 12);
            }
            catch (ObjectDisposedException)
            {
                CloseConnection(true, 13);
            }
            catch (SocketException)
            {
                CloseConnection(true, 14);
            }
            catch (InvalidOperationException)
            {
                CloseConnection(true, 15);
            }
            catch (Exception ex)
            {
                NetworkComms.LogError(ex, "Error_TCPConnectionIncomingPacketHandler");
                CloseConnection(true, 31);
            }

#if !WINDOWS_PHONE
            Thread.CurrentThread.Priority = ThreadPriority.Normal;
#endif
        }

#if !WINDOWS_PHONE
        /// <summary>
        /// Synchronous incoming connection data worker
        /// </summary>
        void IncomingTCPDataSyncWorker()
        {
            bool dataAvailable = false;

            try
            {
                while (true)
                {
                    if (ConnectionInfo.ConnectionState == ConnectionState.Shutdown)
                        break;

                    int bufferOffset = 0;

                    //We need a buffer for our incoming data
                    //First we try to reuse a previous buffer
                    if (packetBuilder.TotalPartialPacketCount > 0 && packetBuilder.NumUnusedBytesMostRecentPartialPacket() > 0)
                        dataBuffer = packetBuilder.RemoveMostRecentPartialPacket(ref bufferOffset);
                    else
                        //If we have nothing to reuse we allocate a new buffer
                        dataBuffer = new byte[NetworkComms.ReceiveBufferSizeBytes];

                    //We block here until there is data to read
                    //When we read data we read until method returns or we fill the buffer length
                    totalBytesRead = tcpClientNetworkStream.Read(dataBuffer, bufferOffset, dataBuffer.Length - bufferOffset) + bufferOffset;

                    //Check to see if there is more data ready to be read
                    dataAvailable = tcpClientNetworkStream.DataAvailable;

                    //If we read any data it gets handed off to the packetBuilder
                    if (totalBytesRead > 0)
                    {
                        ConnectionInfo.UpdateLastTrafficTime();

                        //If we have read a single byte which is 0 and we are not expecting other data
                        if (totalBytesRead == 1 && dataBuffer[0] == 0 && packetBuilder.TotalBytesExpected - packetBuilder.TotalBytesCached == 0)
                        {
                            if (NetworkComms.LoggingEnabled) NetworkComms.Logger.Trace(" ... null packet removed in IncomingDataSyncWorker() from "+ConnectionInfo+".");
                        }
                        else
                        {
                            if (NetworkComms.LoggingEnabled) NetworkComms.Logger.Trace(" ... " + totalBytesRead.ToString() + " bytes added to packetBuilder for connection with " + ConnectionInfo + ". Cached " + packetBuilder.TotalBytesCached.ToString() + "B, expecting " + packetBuilder.TotalBytesExpected.ToString() + "B.");

                            packetBuilder.AddPartialPacket(totalBytesRead, dataBuffer);
                        }
                    }
                    else if (totalBytesRead == 0 && (!dataAvailable || ConnectionInfo.ConnectionState == ConnectionState.Shutdown))
                    {
                        //If we read 0 bytes and there is no data available we should be shutting down
                        CloseConnection(false, -10);
                        break;
                    }

                    //If we have read some data and we have more or equal what was expected we attempt a data handoff
                    if (packetBuilder.TotalBytesCached > 0 && packetBuilder.TotalBytesCached >= packetBuilder.TotalBytesExpected)
                        IncomingPacketHandleHandOff(packetBuilder);
                }
            }
            //On any error here we close the connection
            catch (NullReferenceException)
            {
                CloseConnection(true, 7);
            }
            catch (IOException)
            {
                CloseConnection(true, 8);
            }
            catch (ObjectDisposedException)
            {
                CloseConnection(true, 9);
            }
            catch (SocketException)
            {
                CloseConnection(true, 10);
            }
            catch (InvalidOperationException)
            {
                CloseConnection(true, 11);
            }
            catch (Exception ex)
            {
                NetworkComms.LogError(ex, "Error_TCPConnectionIncomingPacketHandler");
                CloseConnection(true, 39);
            }

            //Clear the listen thread object because the thread is about to end
            incomingDataListenThread = null;

            if (NetworkComms.LoggingEnabled) NetworkComms.Logger.Trace("Incoming data listen thread ending for " + ConnectionInfo);
        }
#endif

        /// <summary>
        /// Closes the <see cref="TCPConnection"/>
        /// </summary>
        /// <param name="closeDueToError">Closing a connection due an error possibly requires a few extra steps.</param>
        /// <param name="logLocation">Optional debug parameter.</param>
        protected override void CloseConnectionSpecific(bool closeDueToError, int logLocation = 0)
        {
#if WINDOWS_PHONE
            //Try to close the socket
            try
            {
                socket.Dispose();
            }
            catch (Exception)
            {
            }
#else
            //The following attempts to correctly close the connection
            //Try to close the networkStream first
            try
            {
                if (tcpClientNetworkStream != null) tcpClientNetworkStream.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                tcpClientNetworkStream = null;
            }

            //Try to close the tcpClient
            try
            {
                tcpClient.Client.Disconnect(false);
                tcpClient.Client.Close();
            }
            catch (Exception)
            {
            }

            //Try to close the tcpClient
            try
            {
                tcpClient.Close();
            }
            catch (Exception)
            {
            }
#endif
        }

        /// <summary>
        /// Sends the provided packet to the remote end point
        /// </summary>
        /// <param name="packet">Packet to send</param>
        protected override void SendPacketSpecific(Packet packet)
        {
            //To keep memory copies to a minimum we send the header and payload in two calls to networkStream.Write
            byte[] headerBytes = packet.SerialiseHeader(NetworkComms.InternalFixedSendReceiveOptions);

            double maxSendTimePerKB = double.MaxValue;
            if (!NetworkComms.DisableConnectionSendTimeouts)
            {
                if (SendTimesMSPerKBCache.Count > MinNumSendsBeforeConnectionSpecificSendTimeout)
                    maxSendTimePerKB = Math.Max(MinimumMSPerKBSendTimeout, SendTimesMSPerKBCache.CalculateMean() + NumberOfStDeviationsForWriteTimeout * SendTimesMSPerKBCache.CalculateStdDeviation());
                else
                    maxSendTimePerKB = DefaultMSPerKBSendTimeout;
            }

            if (NetworkComms.LoggingEnabled) NetworkComms.Logger.Debug("Sending a packet of type '" + packet.PacketHeader.PacketType + "' to " +
                ConnectionInfo + " containing " + headerBytes.Length.ToString() + " header bytes and " + packet.PacketData.Length.ToString() + " payload bytes. Allowing " +
                maxSendTimePerKB.ToString("0.0##") + " ms/KB for send.");
            
            DateTime startTime = DateTime.Now;

            Stream sendingStream;
#if WINDOWS_PHONE
            sendingStream = socket.OutputStream.AsStreamForWrite();
#else
            sendingStream = tcpClientNetworkStream;
#endif

            double headerWriteTime = StreamWriteWithTimeout.Write(headerBytes, headerBytes.Length, sendingStream, NetworkComms.SendBufferSizeBytes, maxSendTimePerKB, MinSendTimeoutMS);
            double dataWriteTime = 0;
            if (packet.PacketData.Length > 0)
                dataWriteTime = packet.PacketData.ThreadSafeStream.CopyTo(sendingStream, packet.PacketData.Start, packet.PacketData.Length, NetworkComms.SendBufferSizeBytes, maxSendTimePerKB, MinSendTimeoutMS);

#if WINDOWS_PHONE
            sendingStream.Flush();
#endif
            //We record each send independantly as if one is considerably larger than 
            //the other it will provide a much more reliable rate
            SendTimesMSPerKBCache.AddValue(headerWriteTime, headerBytes.Length);
            SendTimesMSPerKBCache.AddValue(dataWriteTime, packet.PacketData.Length);
            SendTimesMSPerKBCache.TrimList(MaxNumSendTimes);

            //Correctly dispose the stream if we are finished with it
            if (packet.PacketData.ThreadSafeStream.CloseStreamAfterSend)
                packet.PacketData.ThreadSafeStream.Close();

            if (NetworkComms.LoggingEnabled) NetworkComms.Logger.Trace(" ... " + ((headerBytes.Length + packet.PacketData.Length)/1024.0).ToString("0.000") + "KB written to TCP netstream at average of " + (((headerBytes.Length + packet.PacketData.Length) / 1024.0) / (DateTime.Now - startTime).TotalSeconds).ToString("0.000") + "KB/s. Current:" + ((headerWriteTime + dataWriteTime)/2).ToString("0.00") + " ms/KB, AVG:" + SendTimesMSPerKBCache.CalculateMean().ToString("0.00")+ " ms/KB.");

#if !WINDOWS_PHONE
            if (!tcpClient.Connected)
            {
                if (NetworkComms.LoggingEnabled) NetworkComms.Logger.Error("TCPClient is not marked as connected after write to networkStream. Possibly indicates a dropped connection.");
                throw new CommunicationException("TCPClient is not marked as connected after write to networkStream. Possibly indicates a dropped connection.");
            }
#endif
        }

        /// <summary>
        /// Send a null packet (1 byte) to the remotEndPoint. Helps keep the TCP connection alive while ensuring the bandwidth usage is an absolute minimum. If an exception is thrown the connection will be closed.
        /// </summary>
        protected override void SendNullPacket()
        {
            try
            {
                //Only once the connection has been established do we send null packets
                if (ConnectionInfo.ConnectionState == ConnectionState.Established)
                {
                    //Multiple threads may try to send packets at the same time so we need this lock to prevent a thread cross talk
                    lock (sendLocker)
                    {
                        if (NetworkComms.LoggingEnabled) NetworkComms.Logger.Trace("Sending null packet to " + ConnectionInfo);

                        //Send a single 0 byte
                        double maxSendTimePerKB = double.MaxValue;
                        if (!NetworkComms.DisableConnectionSendTimeouts)
                        {
                            if (SendTimesMSPerKBCache.Count > MinNumSendsBeforeConnectionSpecificSendTimeout)
                                maxSendTimePerKB = Math.Max(MinimumMSPerKBSendTimeout, SendTimesMSPerKBCache.CalculateMean() + NumberOfStDeviationsForWriteTimeout * SendTimesMSPerKBCache.CalculateStdDeviation());
                            else
                                maxSendTimePerKB = DefaultMSPerKBSendTimeout;
                        }

#if WINDOWS_PHONE
                        var stream = socket.OutputStream.AsStreamForWrite();
                        StreamWriteWithTimeout.Write(new byte[] { 0 }, 1, stream, 1, maxSendTimePerKB, MinSendTimeoutMS);
                        stream.Flush();
#else
                        StreamWriteWithTimeout.Write(new byte[] { 0 }, 1, tcpClientNetworkStream, 1, maxSendTimePerKB, MinSendTimeoutMS);
#endif

                        //Update the traffic time after we have written to netStream
                        ConnectionInfo.UpdateLastTrafficTime();
                    }
                }

                //If the connection is shutdown we should call close
                if (ConnectionInfo.ConnectionState == ConnectionState.Shutdown) CloseConnection(false, -8);
            }
            catch (Exception)
            {
                CloseConnection(true, 19);
            }
        }
    }
}

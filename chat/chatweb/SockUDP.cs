using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace chatweb
{
    public static class SockUDP
    {
        private static int UDP_Server_Port;
        private static System.Threading.Thread thdUdp;
        private static IPEndPoint _Server = new IPEndPoint(IPAddress.Any, 0);
        public  delegate void DataArrivalEventHandler(byte[] Data, IPAddress Ip, int Port);
        public static event DataArrivalEventHandler DataArrival;
        private static UdpClient UDP_Server = new UdpClient();
        //Socket UDP_Server; 
        public  delegate void Sock_ErrorEventHandler(string ErrString);
        public static event Sock_ErrorEventHandler Sock_Error;
        public static IPEndPoint Server
        {
            get
            {
                return _Server;
            }
            set
            {
                _Server = value;
            }
        }


        public static void init()
        {
            
           
        }
        public static void Send(System.Net.IPAddress Host, int Port, byte[] Data)
        {
            try
            {
                IPEndPoint server = new IPEndPoint(Host, Port);
                UDP_Server.Send(Data, Data.Length, server);
                //UDP_Server.SendTo(Data,server);
            }
            catch (Exception e)
            {
                if (Sock_Error != null)
                    Sock_Error(e.ToString());
            }
        }

        public static void Listen(int Port)
        {
            try
            {
                UDP_Server_Port = Port;
                UDP_Server = new UdpClient(Port);
                // UDP_Server = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Udp) ; 

                thdUdp = new Thread(new ThreadStart(GetUDPData));
                thdUdp.Start();
            }
            catch (Exception e)
            {
                if (Sock_Error != null)
                    Sock_Error(e.ToString());
            }
        }

        private static void GetUDPData()
        {
            while (true)
            {
                try
                {
                    byte[] RData = UDP_Server.Receive(ref _Server);

                    //byte[] RData= null;
                    //					UDP_Server.Receive(RData);

                    if (DataArrival != null)
                    {
                        DataArrival(RData, _Server.Address, _Server.Port);
                    }
                    Thread.Sleep(0);
                }
                catch (Exception e)
                {
                    if (Sock_Error != null)
                        Sock_Error(e.ToString());
                }
            }
        }

        public static void CloseSock()
        {
            Thread.Sleep(30);
            try
            {
                UDP_Server.Close();
                thdUdp.Abort();
            }
            catch (Exception e)
            {
                if (Sock_Error != null)
                    Sock_Error(e.ToString());
            }
        } 
    }
}
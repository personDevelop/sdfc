using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace chat
{
    public class SockUDP
    {
        private int UDP_Server_Port;
        private System.Threading.Thread thdUdp;
        private IPEndPoint _Server = new IPEndPoint(IPAddress.Any, 0);
        public delegate void DataArrivalEventHandler(byte[] Data, IPAddress Ip, int Port);  //委托方法
        public event DataArrivalEventHandler DataArrival;
        private UdpClient UDP_Server = new UdpClient();
        //Socket UDP_Server; 
        public delegate void Sock_ErrorEventHandler(string ErrString);
        public event Sock_ErrorEventHandler Sock_Error;


        public SockUDP() 
        {
        }

        [Browsable(true), Category("TinyClient"), Description("获得对方IP地址与端口号等信息.")]
        public IPEndPoint Server
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


        public void Send(System.Net.IPAddress Host, int Port, byte[] Data)
        {
            try
            {
                //				System.IO.MemoryStream ms=new MemoryStream(Data);
                //				ZipOutputStream ZipStream = new ZipOutputStream(ms);
                //                //Data=ms.ToArray();
                //ZipStream.PutNextEntry(ZipEntry.);
                //				ZipStream.SetLevel(CompressionLevel.);

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

        /// <summary>
        /// 开始监听端口
        /// </summary>
        /// <param name="Port"></param>
        public void Listen(int Port)
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

        private void GetUDPData()
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

        public void CloseSock()
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

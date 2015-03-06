using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using System.Net;
using CCWin.Win32;
using CCWin.Win32.Const;
using CCWin.SkinControl;
using System.Threading;

namespace chat
{
    public partial class Form1 : CCSkinMain
    {
        private SockUDP sockUDP1;//socket进程
        public ClassUserInfo selfInfo = new ClassUserInfo();
        private IPAddress ServerIP = IPAddress.Parse("127.0.0.1");//服务器IP
        private int ServerPort = 3211;//服务器端口

        public bool getUserDept = false;//是否获取用户部门信息
        public bool getUserInfo = false;
        public Form1()
        {
            InitializeComponent();
            this.sockUDP1 = new SockUDP();//启动socket信息
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chat));//加载资源
            System.Random i = new Random();
            int j = i.Next(2000, 6000);
            this.sockUDP1.Listen(j);//UDP开始侦听来自外部的消息.
            this.sockUDP1.Server = ((System.Net.IPEndPoint)(resources.GetObject("sockUDP1.Server")));//启动服务器
            this.sockUDP1.DataArrival += new SockUDP.DataArrivalEventHandler(this.sockUDP1_DataArrival);//绑定socket数据到达的方法
        }

        private void sockUDP1_DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port)
        {
            DataArrivaldelegate outdelegate = new DataArrivaldelegate(DataArrival);
            this.BeginInvoke(outdelegate, new object[] { Data, Ip, Port });
        }
        private delegate void DataArrivaldelegate(byte[] Data, System.Net.IPAddress Ip, int Port);

        public void userLoginCallback(ClassMsg msg)
        {
            ClassResponse user = new ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(msg.MsgContent))) as ClassResponse;
            if (user.userstate == 1)
            {
                getUserInfo = true;
                if (depts!=null)//
                {
                    MessageBox.Show(user.reponse);
                    main f = new main();
                    f.setNickName(user.username);
                    f.setDeptCache(depts);
                    f.userid = user.userid;
                    f.Show();
                    this.sockUDP1.CloseSock();
                    this.Hide();
                }
            }
            else if (user.userstate == -1) {
                MessageBox.Show(user.reponse);
            }
        }
        public  List<ClassDept> depts = new List<ClassDept>();
        public void CacheUserDept(ClassMsg msg)
        {
            depts = new ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(msg.MsgContent))) as List<ClassDept>;
 
        }

        private void DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port)
        {
            ClassMsg msg = new ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(Data))) as ClassMsg;
            switch (msg.MsgInfoClass)
            {
                case 2://有用户离线
                    userLoginCallback(msg);
                    break;
                case 1://有用户离线
                    CacheUserDept(msg);
                    break;

                default:
                    break;
            }
        }
        public void sendMsgToServer(ClassMsg msg)//发送消息到服务器
        {
            this.sockUDP1.Send(this.ServerIP, this.ServerPort, new ClassSerializers().SerializeBinary(msg).ToArray());
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxId_SkinTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            imgLoadding.Visible = true;
            string id = this.textBoxId.SkinTxt.Text;
            if (id == "")
            {
                MessageBox.Show("请输入用户");
            }
            string pwd = this.textBoxPwd.SkinTxt.Text;
            if (pwd == "")
            {
                MessageBox.Show("请输入密码");
            }
            ClassResponse user = new ClassResponse();
            user.userpwd = pwd;
            user.username = id;
            ClassMsg msg = new ClassMsg(0, "", new ClassSerializers().SerializeBinary(user).ToArray());
            sendMsgToServer(msg);
            //main f = new main();
            //f.setNickName(id);
            //f.Show();
            //this.Hide();

        }

        //保存用户的基本信息
        private const string _configFileName = "Config";
        private void Form1_SysBottomClick(object sender)
        {


        }
    }
}

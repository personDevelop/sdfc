using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace chat
{
    /// <summary>
    /// Form1 ��ժҪ˵����
    /// </summary>
    public class FormMain : System.Windows.Forms.Form
    {
        private SockUDP sockUDP1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.MenuItem menuItemControl;
        private System.Windows.Forms.MenuItem menuItemControlServer;
        private System.Windows.Forms.MenuItem menuItemControlExit;
        private System.Windows.Forms.StatusBar statusBar1;
        internal System.Windows.Forms.TreeView TreeView1;
        internal System.Windows.Forms.Splitter Splitter1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        internal System.Windows.Forms.Timer TimerCheckOnlineSta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        internal System.Windows.Forms.ListView LV_OnlineUser;
        internal System.Windows.Forms.ColumnHeader ID;
        internal System.Windows.Forms.ColumnHeader IP��ַ;
        internal System.Windows.Forms.ColumnHeader �˿�;
        internal System.Windows.Forms.ColumnHeader ״̬;
        internal System.Windows.Forms.ColumnHeader ����;
        internal System.Windows.Forms.ColumnHeader ����;
        private System.Windows.Forms.ColumnHeader Version;
        internal System.Windows.Forms.ListView LV_SysUser;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        internal System.Windows.Forms.ColumnHeader ColumnHeader4;
        internal System.Windows.Forms.ColumnHeader ColumnHeader5;
        internal System.Windows.Forms.ColumnHeader ColumnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.ComponentModel.IContainer components;

        public FormMain()
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();
            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
        }

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���
        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemControl = new System.Windows.Forms.MenuItem();
            this.menuItemControlServer = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItemControlExit = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.TreeView1 = new System.Windows.Forms.TreeView();
            this.Splitter1 = new System.Windows.Forms.Splitter();
            this.TimerCheckOnlineSta = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LV_SysUser = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LV_OnlineUser = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP��ַ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.�˿� = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.״̬ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.���� = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.���� = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.sockUDP1 = new chat.SockUDP(this.components);
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemControl,
            this.menuItem1});
            // 
            // menuItemControl
            // 
            this.menuItemControl.Index = 0;
            this.menuItemControl.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemControlServer,
            this.menuItem3,
            this.menuItemControlExit});
            this.menuItemControl.Text = "�ؼ�̨(&C)";
            this.menuItemControl.Click += new System.EventHandler(this.menuItemControl_Click);
            // 
            // menuItemControlServer
            // 
            this.menuItemControlServer.Index = 0;
            this.menuItemControlServer.Text = "��ʼ����(&B)";
            this.menuItemControlServer.Click += new System.EventHandler(this.menuItemControlServer_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            // 
            // menuItemControlExit
            // 
            this.menuItemControlExit.Index = 2;
            this.menuItemControlExit.Text = "�˳�(&E)";
            this.menuItemControlExit.Click += new System.EventHandler(this.menuItemControlExit_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2});
            this.menuItem1.Text = "����(&H)";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "����(&C)";
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButton1});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(632, 28);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.Visible = false;
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 0;
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 204);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(632, 22);
            this.statusBar1.TabIndex = 1;
            // 
            // TreeView1
            // 
            this.TreeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.TreeView1.ItemHeight = 14;
            this.TreeView1.Location = new System.Drawing.Point(0, 28);
            this.TreeView1.Name = "TreeView1";
            this.TreeView1.Size = new System.Drawing.Size(121, 176);
            this.TreeView1.TabIndex = 6;
            this.TreeView1.Visible = false;
            // 
            // Splitter1
            // 
            this.Splitter1.Location = new System.Drawing.Point(121, 28);
            this.Splitter1.Name = "Splitter1";
            this.Splitter1.Size = new System.Drawing.Size(4, 176);
            this.Splitter1.TabIndex = 7;
            this.Splitter1.TabStop = false;
            this.Splitter1.Visible = false;
            // 
            // TimerCheckOnlineSta
            // 
            this.TimerCheckOnlineSta.Enabled = true;
            this.TimerCheckOnlineSta.Interval = 10000;
            this.TimerCheckOnlineSta.Tick += new System.EventHandler(this.TimerCheckOnlineSta_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(125, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 176);
            this.panel1.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(503, 172);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LV_SysUser);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(495, 146);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ϵͳ�û�";
            // 
            // LV_SysUser
            // 
            this.LV_SysUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.ColumnHeader5,
            this.ColumnHeader6,
            this.columnHeader7});
            this.LV_SysUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_SysUser.FullRowSelect = true;
            this.LV_SysUser.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LV_SysUser.Location = new System.Drawing.Point(0, 0);
            this.LV_SysUser.Name = "LV_SysUser";
            this.LV_SysUser.Size = new System.Drawing.Size(495, 146);
            this.LV_SysUser.TabIndex = 14;
            this.LV_SysUser.UseCompatibleStateImageBehavior = false;
            this.LV_SysUser.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "ID";
            this.ColumnHeader1.Width = 72;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "IP��ַ";
            this.ColumnHeader2.Width = 122;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "�˿�";
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "״̬";
            this.ColumnHeader4.Width = 44;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "����";
            this.ColumnHeader5.Width = 40;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "����";
            this.ColumnHeader6.Width = 90;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Version";
            this.columnHeader7.Width = 120;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LV_OnlineUser);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(495, 167);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "�����û�";
            // 
            // LV_OnlineUser
            // 
            this.LV_OnlineUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.IP��ַ,
            this.�˿�,
            this.״̬,
            this.����,
            this.����,
            this.Version});
            this.LV_OnlineUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_OnlineUser.FullRowSelect = true;
            this.LV_OnlineUser.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LV_OnlineUser.Location = new System.Drawing.Point(0, 0);
            this.LV_OnlineUser.Name = "LV_OnlineUser";
            this.LV_OnlineUser.Size = new System.Drawing.Size(495, 167);
            this.LV_OnlineUser.TabIndex = 13;
            this.LV_OnlineUser.UseCompatibleStateImageBehavior = false;
            this.LV_OnlineUser.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 72;
            // 
            // IP��ַ
            // 
            this.IP��ַ.Text = "IP��ַ";
            this.IP��ַ.Width = 122;
            // 
            // �˿�
            // 
            this.�˿�.Text = "�˿�";
            // 
            // ״̬
            // 
            this.״̬.Text = "״̬";
            this.״̬.Width = 44;
            // 
            // ����
            // 
            this.����.Text = "����";
            this.����.Width = 40;
            // 
            // ����
            // 
            this.����.Text = "����";
            this.����.Width = 90;
            // 
            // Version
            // 
            this.Version.Text = "Version";
            this.Version.Width = 120;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "LanMsg����";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDown);
            // 
            // sockUDP1
            // 
            this.sockUDP1.Server = ((System.Net.IPEndPoint)(resources.GetObject("sockUDP1.Server")));
            this.sockUDP1.DataArrival += new chat.SockUDP.DataArrivalEventHandler(this.sockUDP1_DataArrival);
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(632, 226);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Splitter1);
            this.Controls.Add(this.TreeView1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.toolBar1);
            this.Menu = this.mainMenu1;
            this.Name = "FormMain";
            this.Text = "LanMsg����";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormMain_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// Ӧ�ó��������ڵ㡣
        /// </summary>
        [STAThread]
        static void Main()
        {
            Sharp.Common.CacheContainer.AddCache("IsLocation", true);
            Application.Run(new FormMain());
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            // 	          GetAllUserInfo();
        }

        private void Server(bool IsServer)//��ʼ��ֹͣ����
        {
            if (IsServer)
                this.sockUDP1.Listen(3211);
            else
                this.sockUDP1.CloseSock();
        }

        private void sockUDP1_DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port)//�������ݵ��������µĴ������
        {
            DataArrivaldelegate outdelegate = new DataArrivaldelegate(DataArrival);
            this.BeginInvoke(outdelegate, new object[] { Data, Ip, Port });
        }

        private delegate void DataArrivaldelegate(byte[] Data, System.Net.IPAddress Ip, int Port);

        private void verifyUser(ClassMsg msg, System.Net.IPAddress Ip, int Port)
        {
            ClassResponse user = new ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(msg.MsgContent))) as ClassResponse;
            user = UserVerify.verifyUser(user.username, user.userpwd, Ip.ToString(), Port);
            List<ClassDept> depts = new List<ClassDept>();
            depts = UserVerify.getUserDept();
            if (user.userstate == 1)
            {
                this.SendMsgToOne(Ip, Port, new ClassMsg(1, "", new ClassSerializers().SerializeBinary(depts).ToArray()));//�����û�����
            }
            this.SendMsgToOne(Ip, Port, new ClassMsg(2, "", new ClassSerializers().SerializeBinary(user).ToArray()));//�����û�����




        }

        private void DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port) //�������ݵ����Ĵ������
        {
            try
            {
                // MessageBox.Show("1");

                chat.ClassMsg msg = new ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(Data))) as chat.ClassMsg;
                switch (msg.MsgInfoClass)
                {

                    case 0://�����֤
                        verifyUser(msg, Ip, Port);
                        break;
                    case 1://�����û���¼����
                        NewUserLogin(msg, Ip, Port);
                        break;
                    case 2://�û�ѯ���Լ��Ƿ�����,������������״̬
                        updateUserState(msg, Ip, Port);//�����û�״̬��Ϣ
                        break;
                }
            }
            catch (Exception e)
            { }

        }

        private void updateUserState(chat.ClassMsg msg, System.Net.IPAddress Ip, int Port)//�����û�״̬��Ϣ
        {
            try
            {
                //this.textBox1.AppendText ("�û�"+ msg.ID +"״̬����\n");

                string state = System.Text.Encoding.Unicode.GetString((msg.MsgContent));

                System.Windows.Forms.ListViewItem item = FindUser(msg.ID, this.LV_OnlineUser);
                if (item != null)
                {
                    item.SubItems[3].Text = state;
                    if (state == "0")
                    {
                        //item
                    }
                    //this.LV_OnlineUser.Items.Remove(item);
                }

                item = FindUser(msg.ID, this.LV_SysUser);
                if (item != null)
                {
                    item.SubItems[3].Text = state;
                    if (state == "0" && item.SubItems[4].Text == "10")
                        this.LV_SysUser.Items.Remove(item);
                }

                this.SendMsgToOne(Ip, Port, new chat.ClassMsg(2, "", null));//�����û�����
            }
            catch (Exception e) { }
        }

        private void NewUserLogin(chat.ClassMsg msg, System.Net.IPAddress Ip, int Port)//�����û���¼����
        {
            try
            {
                //			this.textBox1.AppendText ("�û�"+ msg.ID +"��¼\n");

                ClassUserInfo selfInfo = new ClassUserInfo();//׼��������û�������
                selfInfo.ID = msg.ID;
                selfInfo.UserName = msg.ID;
                selfInfo.IP = Ip;
                selfInfo.Port = Port;
                selfInfo.State = 1;
                selfInfo.Dep = 10;
                selfInfo.AssemblyVersion = System.Text.Encoding.Unicode.GetString(msg.MsgContent);

                System.Windows.Forms.ListViewItem item = FindUser(msg.ID, this.LV_SysUser);
                if (item != null)//������û���sysuser����ô������������Ϣ����������������ϵ�˵���Ϣ���͸���
                {
                    item.SubItems[1].Text = Ip.ToString();
                    item.SubItems[2].Text = Port.ToString();
                    item.SubItems[3].Text = "1";//1��ʾ�û�����״̬Ϊ����
                    item.SubItems[6].Text = selfInfo.AssemblyVersion;//������汾��
                    selfInfo.UserName = item.SubItems[5].Text;
                    selfInfo.Dep = Convert.ToInt32(item.SubItems[4].Text);
                    //�������û����в��Ҵ��û��Ƿ���ڣ��������������ӣ�������ھͲ����κβ���
                    System.Windows.Forms.ListViewItem items = FindUser(msg.ID, this.LV_OnlineUser);
                    if (items != null)//����û����������û��б����棬�����
                    {
                        items.SubItems[1].Text = Ip.ToString();
                        items.SubItems[2].Text = Port.ToString();
                        items.SubItems[3].Text = "1";//1��ʾ�û�����״̬Ϊ����
                        items.SubItems[6].Text = selfInfo.AssemblyVersion;//������汾��
                    }
                    else//������û����������б��У������
                    {
                        System.Windows.Forms.ListViewItem NewItem = new ListViewItem();
                        NewItem = item.Clone() as ListViewItem;
                        this.LV_OnlineUser.Items.Add(NewItem);
                    }

                }
                else//������û�����sysuser����ô���������ϵͳ�û��б��������û��б�������������Ϣ����������������ϵ�˵���Ϣ���͸���
                {
                    System.Windows.Forms.ListViewItem NewItem = new ListViewItem();
                    NewItem.Text = msg.ID;
                    NewItem.SubItems.Add(Ip.ToString());
                    NewItem.SubItems.Add(Port.ToString());
                    NewItem.SubItems.Add("1");//1��ʾ�û�����״̬Ϊ����
                    NewItem.SubItems.Add("10");//10��ʾ�û�Ϊδ֪���û�
                    NewItem.SubItems.Add(msg.ID);// δ֪���û���������ΪID
                    NewItem.SubItems.Add(selfInfo.AssemblyVersion);//��ʾ�û�����汾��
                    this.LV_SysUser.Items.Add(NewItem);
                    this.LV_OnlineUser.Items.Add(NewItem.Clone() as ListViewItem);
                }

                //������Ϣ�����û��Ѿ���¼��������,������������ϵĸ������Ϸ���
                chat.ClassMsg ToOneMsg = new chat.ClassMsg(1, "", new ClassSerializers().SerializeBinary(selfInfo).ToArray());
                this.SendMsgToOne(Ip, Port, ToOneMsg);
                //			this.textBox1.AppendText ("����������ϵĸ������Ϸ���"+ Ip.ToString() + Port.ToString() +msg.ID +"\n");

                System.Threading.Thread.Sleep(100);

                //���ش��û�������ϵ�˵�����
                ClassUsers allUsers = Users();//���������û���ϵ�˵�����
                System.Threading.Thread.Sleep(100);
                ToOneMsg = new chat.ClassMsg(4, "", new ClassSerializers().SerializeBinary(allUsers).ToArray());
                this.SendMsgToOne(Ip, Port, ToOneMsg);
                //			this.textBox1.AppendText ("���������û���ϵ�˵�����"+ msg.ID +"\n");

                //����¼�û����Ϸ��͸���ȫ����ϵ�ˣ���֮�û���¼
                System.Threading.Thread.Sleep(100);
                ToOneMsg = new chat.ClassMsg(3, "", new ClassSerializers().SerializeBinary(selfInfo).ToArray());
                this.SendMsgToAll(ToOneMsg);
                //			this.textBox1.AppendText ("��֮�û���¼"+ msg.ID +"\n");
            }
            catch (Exception e) { }

        }

        private ClassUsers Users()//���������û���ϵ�˵�����
        {
            try
            {
                ClassUsers allUsers = new ClassUsers();
                foreach (System.Windows.Forms.ListViewItem item in this.LV_SysUser.Items)
                {
                    ClassUserInfo userInfo = new ClassUserInfo();
                    userInfo.ID = item.SubItems[0].Text;
                    userInfo.IP = System.Net.IPAddress.Parse(item.SubItems[1].Text);
                    userInfo.Port = Convert.ToInt32(item.SubItems[2].Text);
                    userInfo.State = Convert.ToInt32(item.SubItems[3].Text);
                    userInfo.Dep = Convert.ToInt32(item.SubItems[4].Text);
                    userInfo.UserName = item.SubItems[5].Text;
                    userInfo.AssemblyVersion = item.SubItems[6].Text;
                    allUsers.add(userInfo);
                }
                return allUsers;
            }
            catch (Exception e) { return null; }
        }

        private System.Windows.Forms.ListViewItem FindUser(string UserID, System.Windows.Forms.ListView LV)//����Ӧ��ListView������û�
        {
            try
            {
                foreach (System.Windows.Forms.ListViewItem item in LV.Items)
                    if (item.Text.ToLower() == UserID.ToLower())//�ҵ��û���˵����ϵͳ�û�,��������ֵ
                        return item;
                return null;
            }
            catch (Exception e) { return null; }
        }

        private void menuItemControlExit_Click(object sender, System.EventArgs e)
        {
            FormMain_Closing(sender, null);
        }

        private void FormMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (menuItemControlServer.Text == "ֹͣ����(&S)")
                if (MessageBox.Show("ȷ��Ҫ�رշ����˳�������", "��ʾ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.sockUDP1.CloseSock();
                    Application.Exit();
                }
        }

        private void menuItemControlServer_Click(object sender, System.EventArgs e)
        {
            if (menuItemControlServer.Text == "��ʼ����(&B)")
            {
                menuItemControlServer.Text = "ֹͣ����(&S)";
                Server(true);//��ʼ����
                this.statusBar1.Text = "�����Ѿ�����";
            }
            else
            {
                menuItemControlServer.Text = "��ʼ����(&B)";
                Server(false);//ֹͣ����
                this.statusBar1.Text = "�����Ѿ��ر�";
            }

        }

        private void TimerCheckOnlineSta_Tick(object sender, System.EventArgs e)
        {
            CheckOnlineSta();//ϵͳÿ��һ���Ӽ��һ���û�����״̬�������ߵ���ɾ����֪ͨ����ϵ��
        }

        private void CheckOnlineSta()//ϵͳÿ��һ���Ӽ��һ���û�����״̬�������ߵ���ɾ����֪ͨ����ϵ��
        {
            try
            {
                foreach (System.Windows.Forms.ListViewItem item in this.LV_OnlineUser.Items)
                {
                    if (item.SubItems[3].Text == "0")//����û��Ѿ��ѻ�����ɾ����֪ͨ��ȫ����ϵ��
                    {
                        System.Windows.Forms.ListViewItem TempItem = FindUser(item.Text, this.LV_SysUser);//��ϵͳ�û����в��Ҵ��û�����Ϣ
                        if (TempItem != null)
                        {
                            if (item.SubItems[4].Text == "10")//�������Ϊδ֪������ϵͳ�û�����ɾ�����û�
                                this.LV_SysUser.Items.Remove(TempItem);
                            else//����Ǳ�ϵͳ�û������״̬
                                TempItem.SubItems[3].Text = "0";//����ϵͳ�û�������״̬
                        }
                        chat.ClassMsg msg = new chat.ClassMsg(0, item.Text, null);
                        // MessageBox.Show(item.Text);
                        SendMsgToAll(msg);//������Ϣ�����д��û�����ϵ��,��֮�û�����
                        this.LV_OnlineUser.Items.Remove(item);//�������û��б���ɾ�����û���Ϣ
                    }
                    else
                    {
                        //item.SubItems[3].Text ="0";//������û��Ѿ�����
                    }
                }
            }
            catch (Exception e) { }

        }

        private void SendMsgToOne(System.Net.IPAddress ip, int port, chat.ClassMsg msg)//������Ϣ��һ���û�
        {
            try
            {
                System.IO.MemoryStream stream = new ClassSerializers().SerializeBinary(msg);
                SockUDP udp = new SockUDP();
                udp.Send(ip, port, stream.ToArray());
            }
            catch (Exception e) { }

        }

        private void SendMsgToAll(chat.ClassMsg msg)//������Ϣ�������û�
        {
            try
            {
                foreach (System.Windows.Forms.ListViewItem item in this.LV_OnlineUser.Items)
                {
                    System.Net.IPAddress ip = System.Net.IPAddress.Parse(item.SubItems[1].Text);
                    int port = Convert.ToInt32(item.SubItems[2].Text);
                    System.IO.MemoryStream stream = new ClassSerializers().SerializeBinary(msg);
                    SockUDP udp = new SockUDP();
                    udp.Send(ip, port, stream.ToArray());
                }
            }
            catch (Exception e) { }

        }

        private void GetAllUserInfo() //��ȡ���ݿ��������û����ݵ��б���
        {
            try
            {
                System.Data.OleDb.OleDbDataReader dr;
                string SQLstr = "select Sys_Users.UserName as computer,Mp_EmpLoyee.DepID as Dept,Mp_EmpLoyee.EmpName as UserName from Sys_Users,Mp_EmpLoyee where Mp_EmpLoyee.EmpID=Sys_Users.EmpID and (Sys_Users.IsWork is null or Sys_Users.IsWork>0)";
                dr = new ClassOptionData().ExSQLReDr(SQLstr);
                while (dr.Read())
                {
                    AllOneUserInfoToLV(LV_SysUser, Convert.ToString(dr["computer"]), "127.0.0.1", "0", "0", Convert.ToString(dr["dept"]), Convert.ToString(dr["UserName"]));
                }
                dr.Close();

            }
            catch (Exception e) { }

        }

        private void AllOneUserInfoToLV(System.Windows.Forms.ListView LV, string Computer, string IpAddress, string port, string OnlineSta, string Dept, string UserName)//'�����µ�¼�û�����Ϣ����)
        {
            try
            {
                System.Windows.Forms.ListViewItem NewItem = new ListViewItem();
                NewItem.Text = Computer.Trim().ToLower(); //      '����û����������˿ں���Ϣ
                NewItem.SubItems.Add(IpAddress); //'����û�IP��ַ��Ϣ
                NewItem.SubItems.Add(port); //  '����û��˿���Ϣ
                NewItem.SubItems.Add(OnlineSta);// '����״̬
                NewItem.SubItems.Add(getDept(Dept));//'�����û�����Ϊδ֪
                NewItem.SubItems.Add(UserName.Trim());//'����û�������Ϣ
                NewItem.SubItems.Add("");//'����û�������Ϣ
                LV.Items.Add(NewItem);// '��Ӵ˵�¼�û���������Ϣ��ϵͳ�б��� 
            }
            catch (Exception e) { }

        }

        private string getDept(string Dept)
        {
            switch (Dept)
            {
                case "12":
                    return "0";//Ժ�쵼 
                    break;
                case "8":
                    return "1";//Ժ�쵼					   
                    break;
                case "13":
                    return "1";//Ժ�쵼 
                    break;
                case "14":
                    return "1";//Ժ�쵼 
                    break;
                case "15":
                    return "1";//�ۺϲ� 
                    break;
                case "3":
                    return "2";//���� 
                    break;
                case "5":
                    return "3";//�г��� 
                    break;
                case "2":
                    return "3";//�г��� 
                    break;
                case "11":
                    return "4";//�豸��
                    break;
                case "9":
                    return "5";//������
                    break;
                case "10":
                    return "6";//������� 
                    break;
                case "4":
                    return "7";//�滮��
                    break;
                case "16":
                    return "8";//������
                    break;
                case "6":
                    return "9";//������Ժ 
                    break;
            }
            return "10";
        }

        private void menuItemControl_Click(object sender, System.EventArgs e)
        {

        }

        private void notifyIcon1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        private void notifyIcon1_DoubleClick(object sender, System.EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Show();
            this.Activate();
        }

        private void FormMain_Resize(object sender, System.EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Minimized)
                this.Hide();
        }
    }
}

using SimpleIMClient.Skin;
namespace SimpleIMClient.Skin
{
    partial class QQForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QQForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.description = new System.Windows.Forms.Label();
            this.miniTimer = new System.Windows.Forms.Timer(this.components);
            this.skinPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menu_Btn = new System.Windows.Forms.PictureBox();
            this.find_Btn = new System.Windows.Forms.PictureBox();
            this.message_Btn = new System.Windows.Forms.PictureBox();
            this.tools_Btn = new System.Windows.Forms.PictureBox();
            this.mail_btn = new System.Windows.Forms.PictureBox();
            this.qzone16_btn = new System.Windows.Forms.PictureBox();
            this.color_Btn = new System.Windows.Forms.PictureBox();
            this.search_Btn = new System.Windows.Forms.PictureBox();
            this.ButtonClose = new System.Windows.Forms.PictureBox();
            this.ButtonMax = new System.Windows.Forms.PictureBox();
            this.ButtonMin = new System.Windows.Forms.PictureBox();
            this.groupListView = new System.Windows.Forms.Panel();
            this.lastListView = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.userImg = new System.Windows.Forms.PictureBox();
            this.friendListView = new SimpleIMClient.Skin.QQListView();
            this.lt_btn = new SimpleIMClient.Skin.QQPictureBox();
            this.nt_btn = new SimpleIMClient.Skin.QQPictureBox();
            this.gp_btn = new SimpleIMClient.Skin.QQPictureBox();
            this.fd_btn = new SimpleIMClient.Skin.QQPictureBox();
            this.skinPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menu_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.find_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.message_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tools_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mail_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qzone16_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.search_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lt_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nt_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gp_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fd_btn)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 4000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // description
            // 
            this.description.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.description.AutoEllipsis = true;
            this.description.BackColor = System.Drawing.Color.Transparent;
            this.description.Location = new System.Drawing.Point(60, 56);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(175, 18);
            this.description.TabIndex = 32;
            this.description.Text = "这家伙很懒，什么也没留下！";
            this.description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.description.MouseClick += new System.Windows.Forms.MouseEventHandler(this.description_MouseClick);
            this.description.MouseEnter += new System.EventHandler(this.con_MouseEnter);
            this.description.MouseLeave += new System.EventHandler(this.con_MouseLeave);
            // 
            // miniTimer
            // 
            this.miniTimer.Interval = 1;
            this.miniTimer.Tick += new System.EventHandler(this.miniTimer_Tick);
            // 
            // skinPanel
            // 
            this.skinPanel.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel.BackgroundImage = global::SimpleIMClient.Properties.Resources.MainBkg;
            this.skinPanel.Controls.Add(this.pictureBox2);
            this.skinPanel.Controls.Add(this.pictureBox1);
            this.skinPanel.Location = new System.Drawing.Point(2, 99);
            this.skinPanel.Name = "skinPanel";
            this.skinPanel.Size = new System.Drawing.Size(236, 0);
            this.skinPanel.TabIndex = 41;
            this.skinPanel.Visible = false;
            this.skinPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.skinPanel_Paint);
            this.skinPanel.Leave += new System.EventHandler(this.skinPanel_Leave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SimpleIMClient.Properties.Resources.TbShadingNormal;
            this.pictureBox2.Location = new System.Drawing.Point(40, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SimpleIMClient.Properties.Resources.TbAdjustColorNormal;
            this.pictureBox1.Location = new System.Drawing.Point(4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // menu_Btn
            // 
            this.menu_Btn.BackColor = System.Drawing.Color.Transparent;
            this.menu_Btn.Location = new System.Drawing.Point(4, 458);
            this.menu_Btn.Name = "menu_Btn";
            this.menu_Btn.Size = new System.Drawing.Size(40, 40);
            this.menu_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.menu_Btn.TabIndex = 40;
            this.menu_Btn.TabStop = false;
            this.menu_Btn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.menu_Btn_MouseClick);
            this.menu_Btn.MouseEnter += new System.EventHandler(this.menu_Btn_MouseEnter);
            this.menu_Btn.MouseLeave += new System.EventHandler(this.menu_Btn_MouseLeave);
            // 
            // find_Btn
            // 
            this.find_Btn.BackColor = System.Drawing.Color.Transparent;
            this.find_Btn.Location = new System.Drawing.Point(100, 472);
            this.find_Btn.Name = "find_Btn";
            this.find_Btn.Size = new System.Drawing.Size(22, 22);
            this.find_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.find_Btn.TabIndex = 39;
            this.find_Btn.TabStop = false;
            this.find_Btn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.find_Btn_MouseClick);
            this.find_Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.find_Btn.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.find_Btn.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.find_Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // message_Btn
            // 
            this.message_Btn.BackColor = System.Drawing.Color.Transparent;
            this.message_Btn.Location = new System.Drawing.Point(75, 472);
            this.message_Btn.Name = "message_Btn";
            this.message_Btn.Size = new System.Drawing.Size(22, 22);
            this.message_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.message_Btn.TabIndex = 38;
            this.message_Btn.TabStop = false;
            this.message_Btn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.message_Btn_MouseClick);
            this.message_Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.message_Btn.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.message_Btn.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.message_Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // tools_Btn
            // 
            this.tools_Btn.BackColor = System.Drawing.Color.Transparent;
            this.tools_Btn.Location = new System.Drawing.Point(50, 472);
            this.tools_Btn.Name = "tools_Btn";
            this.tools_Btn.Size = new System.Drawing.Size(22, 22);
            this.tools_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.tools_Btn.TabIndex = 37;
            this.tools_Btn.TabStop = false;
            this.tools_Btn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tools_Btn_MouseClick);
            this.tools_Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.tools_Btn.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.tools_Btn.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.tools_Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // mail_btn
            // 
            this.mail_btn.BackColor = System.Drawing.Color.Transparent;
            this.mail_btn.Location = new System.Drawing.Point(30, 77);
            this.mail_btn.Name = "mail_btn";
            this.mail_btn.Size = new System.Drawing.Size(22, 22);
            this.mail_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mail_btn.TabIndex = 36;
            this.mail_btn.TabStop = false;
            this.mail_btn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mail_btn_MouseClick);
            this.mail_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.mail_btn.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.mail_btn.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.mail_btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // qzone16_btn
            // 
            this.qzone16_btn.BackColor = System.Drawing.Color.Transparent;
            this.qzone16_btn.Location = new System.Drawing.Point(6, 77);
            this.qzone16_btn.Name = "qzone16_btn";
            this.qzone16_btn.Size = new System.Drawing.Size(22, 22);
            this.qzone16_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.qzone16_btn.TabIndex = 35;
            this.qzone16_btn.TabStop = false;
            this.qzone16_btn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.qzone16_btn_MouseClick);
            this.qzone16_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MouseDown);
            this.qzone16_btn.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.qzone16_btn.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.qzone16_btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // color_Btn
            // 
            this.color_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.color_Btn.BackColor = System.Drawing.Color.Transparent;
            this.color_Btn.Location = new System.Drawing.Point(213, 77);
            this.color_Btn.Name = "color_Btn";
            this.color_Btn.Size = new System.Drawing.Size(22, 22);
            this.color_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.color_Btn.TabIndex = 34;
            this.color_Btn.TabStop = false;
            this.color_Btn.Click += new System.EventHandler(this.color_Btn_Click);
            this.color_Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.color_Btn_MouseDown);
            this.color_Btn.MouseEnter += new System.EventHandler(this.color_Btn_MouseEnter);
            this.color_Btn.MouseLeave += new System.EventHandler(this.color_Btn_MouseLeave);
            this.color_Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.color_Btn_MouseUp);
            // 
            // search_Btn
            // 
            this.search_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_Btn.BackColor = System.Drawing.Color.Transparent;
            this.search_Btn.Image = global::SimpleIMClient.Properties.Resources.main_search_normal;
            this.search_Btn.Location = new System.Drawing.Point(206, 99);
            this.search_Btn.Name = "search_Btn";
            this.search_Btn.Size = new System.Drawing.Size(31, 24);
            this.search_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.search_Btn.TabIndex = 33;
            this.search_Btn.TabStop = false;
            this.search_Btn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.search_Btn_MouseClick);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonClose.BackColor = System.Drawing.Color.Transparent;
            this.ButtonClose.Location = new System.Drawing.Point(202, 0);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(38, 18);
            this.ButtonClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ButtonClose.TabIndex = 21;
            this.ButtonClose.TabStop = false;
            this.ButtonClose.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonClose_Paint);
            this.ButtonClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonClose_MouseClick);
            this.ButtonClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonClose_MouseDown);
            this.ButtonClose.MouseEnter += new System.EventHandler(this.ButtonClose_MouseEnter);
            this.ButtonClose.MouseLeave += new System.EventHandler(this.ButtonClose_MouseLeave);
            this.ButtonClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonClose_MouseUp);
            // 
            // ButtonMax
            // 
            this.ButtonMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMax.BackColor = System.Drawing.Color.Transparent;
            this.ButtonMax.Location = new System.Drawing.Point(177, 0);
            this.ButtonMax.Name = "ButtonMax";
            this.ButtonMax.Size = new System.Drawing.Size(25, 18);
            this.ButtonMax.TabIndex = 23;
            this.ButtonMax.TabStop = false;
            this.ButtonMax.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonMax_Paint);
            this.ButtonMax.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonMax_MouseClick);
            this.ButtonMax.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMax_MouseDown);
            this.ButtonMax.MouseEnter += new System.EventHandler(this.ButtonMax_MouseEnter);
            this.ButtonMax.MouseLeave += new System.EventHandler(this.ButtonMax_MouseLeave);
            this.ButtonMax.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMax_MouseUp);
            // 
            // ButtonMin
            // 
            this.ButtonMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMin.BackColor = System.Drawing.Color.Transparent;
            this.ButtonMin.Location = new System.Drawing.Point(152, 0);
            this.ButtonMin.Name = "ButtonMin";
            this.ButtonMin.Size = new System.Drawing.Size(25, 18);
            this.ButtonMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ButtonMin.TabIndex = 20;
            this.ButtonMin.TabStop = false;
            this.ButtonMin.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonMin_Paint);
            this.ButtonMin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonMin_MouseClick);
            this.ButtonMin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMin_MouseDown);
            this.ButtonMin.MouseEnter += new System.EventHandler(this.ButtonMin_MouseEnter);
            this.ButtonMin.MouseLeave += new System.EventHandler(this.ButtonMin_MouseLeave);
            this.ButtonMin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMin_MouseUp);
            // 
            // groupListView
            // 
            this.groupListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupListView.Location = new System.Drawing.Point(2, 149);
            this.groupListView.Name = "groupListView";
            this.groupListView.Size = new System.Drawing.Size(235, 273);
            this.groupListView.TabIndex = 47;
            this.groupListView.Visible = false;
            // 
            // lastListView
            // 
            this.lastListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lastListView.Location = new System.Drawing.Point(2, 149);
            this.lastListView.Name = "lastListView";
            this.lastListView.Size = new System.Drawing.Size(235, 273);
            this.lastListView.TabIndex = 48;
            this.lastListView.Visible = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(2, 149);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(235, 273);
            this.webBrowser1.TabIndex = 50;
            this.webBrowser1.Visible = false;
            // 
            // userImg
            // 
            this.userImg.BackColor = System.Drawing.Color.Transparent;
            this.userImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userImg.Location = new System.Drawing.Point(5, 30);
            this.userImg.Name = "userImg";
            this.userImg.Size = new System.Drawing.Size(48, 48);
            this.userImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.userImg.TabIndex = 51;
            this.userImg.TabStop = false;
            this.userImg.MouseEnter += new System.EventHandler(this.userImg_MouseEnter);
            this.userImg.MouseLeave += new System.EventHandler(this.userImg_MouseLeave);
            // 
            // friendListView
            // 
            this.friendListView.AutoScroll = true;
            this.friendListView.BackColor = System.Drawing.Color.White;
            this.friendListView.BgColorMode = true;
            this.friendListView.ForeColor = System.Drawing.Color.White;
            this.friendListView.Location = new System.Drawing.Point(2, 149);
            this.friendListView.Name = "friendListView";
            this.friendListView.OldSelectFriend = null;
            this.friendListView.SelectedFriend = null;
            this.friendListView.Size = new System.Drawing.Size(235, 273);
            this.friendListView.TabIndex = 42;
            // 
            // lt_btn
            // 
            this.lt_btn.BackColor = System.Drawing.Color.Transparent;
            this.lt_btn.Location = new System.Drawing.Point(179, 122);
            this.lt_btn.Name = "lt_btn";
            this.lt_btn.Size = new System.Drawing.Size(59, 27);
            this.lt_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.lt_btn.TabIndex = 46;
            this.lt_btn.TabStop = false;
            this.lt_btn.Texts = null;
            this.lt_btn.Click += new System.EventHandler(this.tab_Click);
            this.lt_btn.MouseEnter += new System.EventHandler(this.tab_MouseEnter);
            this.lt_btn.MouseLeave += new System.EventHandler(this.tab_MouseLeave);
            // 
            // nt_btn
            // 
            this.nt_btn.BackColor = System.Drawing.Color.Transparent;
            this.nt_btn.Location = new System.Drawing.Point(120, 122);
            this.nt_btn.Name = "nt_btn";
            this.nt_btn.Size = new System.Drawing.Size(59, 27);
            this.nt_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.nt_btn.TabIndex = 45;
            this.nt_btn.TabStop = false;
            this.nt_btn.Texts = null;
            this.nt_btn.Click += new System.EventHandler(this.tab_Click);
            this.nt_btn.MouseEnter += new System.EventHandler(this.tab_MouseEnter);
            this.nt_btn.MouseLeave += new System.EventHandler(this.tab_MouseLeave);
            // 
            // gp_btn
            // 
            this.gp_btn.BackColor = System.Drawing.Color.Transparent;
            this.gp_btn.Location = new System.Drawing.Point(61, 122);
            this.gp_btn.Name = "gp_btn";
            this.gp_btn.Size = new System.Drawing.Size(59, 27);
            this.gp_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.gp_btn.TabIndex = 44;
            this.gp_btn.TabStop = false;
            this.gp_btn.Texts = null;
            this.gp_btn.Click += new System.EventHandler(this.tab_Click);
            this.gp_btn.MouseEnter += new System.EventHandler(this.tab_MouseEnter);
            this.gp_btn.MouseLeave += new System.EventHandler(this.tab_MouseLeave);
            // 
            // fd_btn
            // 
            this.fd_btn.BackColor = System.Drawing.Color.Transparent;
            this.fd_btn.Location = new System.Drawing.Point(2, 122);
            this.fd_btn.Name = "fd_btn";
            this.fd_btn.Size = new System.Drawing.Size(59, 27);
            this.fd_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.fd_btn.TabIndex = 43;
            this.fd_btn.TabStop = false;
            this.fd_btn.Texts = null;
            this.fd_btn.Click += new System.EventHandler(this.tab_Click);
            this.fd_btn.MouseEnter += new System.EventHandler(this.tab_MouseEnter);
            this.fd_btn.MouseLeave += new System.EventHandler(this.tab_MouseLeave);
            // 
            // QQForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(187)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(240, 500);
            this.Controls.Add(this.mail_btn);
            this.Controls.Add(this.qzone16_btn);
            this.Controls.Add(this.userImg);
            this.Controls.Add(this.friendListView);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.lastListView);
            this.Controls.Add(this.groupListView);
            this.Controls.Add(this.lt_btn);
            this.Controls.Add(this.nt_btn);
            this.Controls.Add(this.gp_btn);
            this.Controls.Add(this.fd_btn);
            this.Controls.Add(this.skinPanel);
            this.Controls.Add(this.menu_Btn);
            this.Controls.Add(this.find_Btn);
            this.Controls.Add(this.message_Btn);
            this.Controls.Add(this.tools_Btn);
            this.Controls.Add(this.color_Btn);
            this.Controls.Add(this.search_Btn);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.description);
            this.Controls.Add(this.ButtonMax);
            this.Controls.Add(this.ButtonMin);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(240, 400);
            this.Name = "QQForm";
            this.Text = "QQ2010";
            this.skinPanel.ResumeLayout(false);
            this.skinPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menu_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.find_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.message_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tools_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mail_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qzone16_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.search_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lt_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nt_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gp_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fd_btn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer miniTimer;
        private System.Windows.Forms.PictureBox ButtonMin;
        private System.Windows.Forms.PictureBox ButtonMax;
        private System.Windows.Forms.PictureBox ButtonClose;
        private System.Windows.Forms.Panel skinPanel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private QQListView friendListView;
        private System.Windows.Forms.PictureBox search_Btn;
        private System.Windows.Forms.PictureBox qzone16_btn;
        private System.Windows.Forms.PictureBox mail_btn;
        private System.Windows.Forms.PictureBox message_Btn;
        private System.Windows.Forms.PictureBox tools_Btn;
        private System.Windows.Forms.PictureBox find_Btn;
        private System.Windows.Forms.PictureBox menu_Btn;
        private System.Windows.Forms.PictureBox color_Btn;
        private System.Windows.Forms.Label description;
        private QQPictureBox fd_btn;
        private QQPictureBox gp_btn;
        private QQPictureBox lt_btn;
        private QQPictureBox nt_btn;
        private System.Windows.Forms.Panel groupListView;
        private System.Windows.Forms.Panel lastListView;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.PictureBox userImg;

    }
}
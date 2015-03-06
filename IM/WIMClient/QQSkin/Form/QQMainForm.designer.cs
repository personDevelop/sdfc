using WIMClient.Skin;
namespace WIMClient.Skin
{
    partial class QQMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QQMainForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.description = new System.Windows.Forms.Label();
            this.miniTimer = new System.Windows.Forms.Timer(this.components);
            this.userPanel = new System.Windows.Forms.Panel();
            this.skinPanel = new System.Windows.Forms.Panel();
            this.shadPanel = new System.Windows.Forms.Panel();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.select_color = new System.Windows.Forms.PictureBox();
            this.select_shad = new System.Windows.Forms.PictureBox();
            this.mail_btn = new System.Windows.Forms.PictureBox();
            this.qzone16_btn = new System.Windows.Forms.PictureBox();
            this.userImg = new System.Windows.Forms.PictureBox();
            this.menu_Btn = new System.Windows.Forms.PictureBox();
            this.find_Btn = new System.Windows.Forms.PictureBox();
            this.message_Btn = new System.Windows.Forms.PictureBox();
            this.tools_Btn = new System.Windows.Forms.PictureBox();
            this.color_Btn = new System.Windows.Forms.PictureBox();
            this.search_Btn = new System.Windows.Forms.PictureBox();
            this.ButtonClose = new System.Windows.Forms.PictureBox();
            this.ButtonMax = new System.Windows.Forms.PictureBox();
            this.ButtonMin = new System.Windows.Forms.PictureBox();
            this.LinkP2P = new System.Windows.Forms.LinkLabel();
            this.LinkUser = new System.Windows.Forms.LinkLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timeMessage = new System.Windows.Forms.Timer(this.components);
            this.skinPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.select_color)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.select_shad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mail_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qzone16_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menu_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.find_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.message_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tools_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.search_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMin)).BeginInit();
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
            this.description.Size = new System.Drawing.Size(159, 18);
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
            // userPanel
            // 
            this.userPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userPanel.BackColor = System.Drawing.Color.White;
            this.userPanel.Location = new System.Drawing.Point(1, 129);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(222, 310);
            this.userPanel.TabIndex = 48;
            // 
            // skinPanel
            // 
            this.skinPanel.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel.Controls.Add(this.shadPanel);
            this.skinPanel.Controls.Add(this.colorPanel);
            this.skinPanel.Controls.Add(this.select_color);
            this.skinPanel.Controls.Add(this.select_shad);
            this.skinPanel.Location = new System.Drawing.Point(2, 99);
            this.skinPanel.Name = "skinPanel";
            this.skinPanel.Size = new System.Drawing.Size(0, 140);
            this.skinPanel.TabIndex = 41;
            this.skinPanel.Leave += new System.EventHandler(this.skinPanel_Leave);
            // 
            // shadPanel
            // 
            this.shadPanel.Location = new System.Drawing.Point(8, 38);
            this.shadPanel.Name = "shadPanel";
            this.shadPanel.Size = new System.Drawing.Size(218, 85);
            this.shadPanel.TabIndex = 4;
            // 
            // colorPanel
            // 
            this.colorPanel.Location = new System.Drawing.Point(7, 37);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(222, 98);
            this.colorPanel.TabIndex = 3;
            this.colorPanel.Visible = false;
            // 
            // select_color
            // 
            this.select_color.Location = new System.Drawing.Point(41, 5);
            this.select_color.Name = "select_color";
            this.select_color.Size = new System.Drawing.Size(30, 30);
            this.select_color.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.select_color.TabIndex = 2;
            this.select_color.TabStop = false;
            this.select_color.Click += new System.EventHandler(this.select_color_Click);
            // 
            // select_shad
            // 
            this.select_shad.Location = new System.Drawing.Point(5, 5);
            this.select_shad.Name = "select_shad";
            this.select_shad.Size = new System.Drawing.Size(30, 30);
            this.select_shad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.select_shad.TabIndex = 1;
            this.select_shad.TabStop = false;
            this.select_shad.Click += new System.EventHandler(this.select_shad_Click);
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
            // color_Btn
            // 
            this.color_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.color_Btn.BackColor = System.Drawing.Color.Transparent;
            this.color_Btn.Location = new System.Drawing.Point(197, 77);
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
            this.search_Btn.Location = new System.Drawing.Point(190, 99);
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
            this.ButtonClose.Location = new System.Drawing.Point(186, 0);
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
            this.ButtonMax.Location = new System.Drawing.Point(161, 0);
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
            this.ButtonMin.Location = new System.Drawing.Point(136, 0);
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
            // LinkP2P
            // 
            this.LinkP2P.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkP2P.AutoSize = true;
            this.LinkP2P.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LinkP2P.LinkColor = System.Drawing.Color.Black;
            this.LinkP2P.Location = new System.Drawing.Point(132, 481);
            this.LinkP2P.Name = "LinkP2P";
            this.LinkP2P.Size = new System.Drawing.Size(71, 12);
            this.LinkP2P.TabIndex = 0;
            this.LinkP2P.TabStop = true;
            this.LinkP2P.Text = "查看P2P通道";
            this.LinkP2P.Click += new System.EventHandler(this.LinkP2P_Click);
            // 
            // LinkUser
            // 
            this.LinkUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkUser.AutoSize = true;
            this.LinkUser.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LinkUser.LinkColor = System.Drawing.Color.Black;
            this.LinkUser.Location = new System.Drawing.Point(132, 463);
            this.LinkUser.Name = "LinkUser";
            this.LinkUser.Size = new System.Drawing.Size(53, 12);
            this.LinkUser.TabIndex = 52;
            this.LinkUser.TabStop = true;
            this.LinkUser.Text = "LinkUser";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "微风ＩＭ";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // timeMessage
            // 
            this.timeMessage.Interval = 300;
            this.timeMessage.Tick += new System.EventHandler(this.timeMessage_Tick);
            // 
            // QQMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(187)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(224, 500);
            this.Controls.Add(this.userPanel);
            this.Controls.Add(this.LinkUser);
            this.Controls.Add(this.LinkP2P);
            this.Controls.Add(this.skinPanel);
            this.Controls.Add(this.mail_btn);
            this.Controls.Add(this.qzone16_btn);
            this.Controls.Add(this.userImg);
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
            this.Name = "QQMainForm";
            this.Text = "QQ2010";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QQMainForm_FormClosing);
            this.Load += new System.EventHandler(this.QQMainForm_Load);
            this.skinPanel.ResumeLayout(false);
            this.skinPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.select_color)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.select_shad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mail_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qzone16_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menu_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.find_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.message_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tools_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.search_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMin)).EndInit();
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
        private System.Windows.Forms.PictureBox select_color;
        private System.Windows.Forms.PictureBox select_shad;
        private System.Windows.Forms.PictureBox search_Btn;
        private System.Windows.Forms.PictureBox qzone16_btn;
        private System.Windows.Forms.PictureBox mail_btn;
        private System.Windows.Forms.PictureBox message_Btn;
        private System.Windows.Forms.PictureBox tools_Btn;
        private System.Windows.Forms.PictureBox find_Btn;
        private System.Windows.Forms.PictureBox menu_Btn;
        private System.Windows.Forms.PictureBox color_Btn;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.PictureBox userImg;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Panel shadPanel;
        private System.Windows.Forms.LinkLabel LinkP2P;
        private System.Windows.Forms.LinkLabel LinkUser;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timeMessage;

    }
}
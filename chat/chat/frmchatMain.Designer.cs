namespace ChatClient
{
    partial class frmchatMain
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
            //FormMain.formMain.forms.Romove(this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmchatMain));
            this.panelFriendHeadImage = new CCWin.SkinControl.SkinPanel();
            this.labelFriendName = new CCWin.SkinControl.SkinLabel();
            this.labelFriendSignature = new CCWin.SkinControl.SkinLabel();
            this.imgyy2 = new System.Windows.Forms.PictureBox();
            this.skinPanel_right = new CCWin.SkinControl.SkinPanel();
            this.skinTabControl1 = new CCWin.SkinControl.SkinTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.imgMeShow = new System.Windows.Forms.PictureBox();
            this.imgChatShow = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.skinPanel_left = new CCWin.SkinControl.SkinPanel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.liklblgg = new System.Windows.Forms.LinkLabel();
            this.btnSend = new CCWin.SkinControl.SkinButton();
            this.skinButtom3 = new CCWin.SkinControl.SkinButton();
            this.btnClose = new CCWin.SkinControl.SkinButton();
            this.pnlTx = new CCWin.SkinControl.SkinPanel();
            this.miniToolStrip = new CCWin.SkinControl.SkinToolStrip();
            this.timerCheckSendIsSuccess = new System.Windows.Forms.Timer(this.components);
            this.chatControl1 = new ChatClient.ChatControl();
            ((System.ComponentModel.ISupportInitialize)(this.imgyy2)).BeginInit();
            this.skinPanel_right.SuspendLayout();
            this.skinTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgMeShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgChatShow)).BeginInit();
            this.skinPanel_left.SuspendLayout();
            this.skinPanel1.SuspendLayout();
            this.pnlTx.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFriendHeadImage
            // 
            this.panelFriendHeadImage.BackColor = System.Drawing.Color.Transparent;
            this.panelFriendHeadImage.BackgroundImage = global::ChatClient.Properties.Resources._1_100;
            this.panelFriendHeadImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelFriendHeadImage.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelFriendHeadImage.DownBack = null;
            this.panelFriendHeadImage.Location = new System.Drawing.Point(5, 5);
            this.panelFriendHeadImage.Margin = new System.Windows.Forms.Padding(0);
            this.panelFriendHeadImage.MouseBack = null;
            this.panelFriendHeadImage.Name = "panelFriendHeadImage";
            this.panelFriendHeadImage.NormlBack = null;
            this.panelFriendHeadImage.Radius = 5;
            this.panelFriendHeadImage.Size = new System.Drawing.Size(40, 40);
            this.panelFriendHeadImage.TabIndex = 104;
            // 
            // labelFriendName
            // 
            this.labelFriendName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFriendName.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.Anamorphosis;
            this.labelFriendName.AutoSize = true;
            this.labelFriendName.BackColor = System.Drawing.Color.Transparent;
            this.labelFriendName.BorderColor = System.Drawing.Color.White;
            this.labelFriendName.BorderSize = 4;
            this.labelFriendName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFriendName.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.labelFriendName.ForeColor = System.Drawing.Color.Black;
            this.labelFriendName.Location = new System.Drawing.Point(55, 7);
            this.labelFriendName.Name = "labelFriendName";
            this.labelFriendName.Size = new System.Drawing.Size(88, 25);
            this.labelFriendName.TabIndex = 105;
            this.labelFriendName.Text = "在线咨询";
            // 
            // labelFriendSignature
            // 
            this.labelFriendSignature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFriendSignature.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.Anamorphosis;
            this.labelFriendSignature.AutoSize = true;
            this.labelFriendSignature.BackColor = System.Drawing.Color.Transparent;
            this.labelFriendSignature.BorderColor = System.Drawing.Color.White;
            this.labelFriendSignature.BorderSize = 4;
            this.labelFriendSignature.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.labelFriendSignature.ForeColor = System.Drawing.Color.Black;
            this.labelFriendSignature.Location = new System.Drawing.Point(79, 32);
            this.labelFriendSignature.Name = "labelFriendSignature";
            this.labelFriendSignature.Size = new System.Drawing.Size(80, 17);
            this.labelFriendSignature.TabIndex = 106;
            this.labelFriendSignature.Text = "我的个性签名";
            // 
            // imgyy2
            // 
            this.imgyy2.BackColor = System.Drawing.Color.Transparent;
            this.imgyy2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgyy2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgyy2.Image = global::ChatClient.Properties.Resources.icon_weibo;
            this.imgyy2.Location = new System.Drawing.Point(60, 32);
            this.imgyy2.Margin = new System.Windows.Forms.Padding(0);
            this.imgyy2.Name = "imgyy2";
            this.imgyy2.Size = new System.Drawing.Size(16, 16);
            this.imgyy2.TabIndex = 124;
            this.imgyy2.TabStop = false;
            // 
            // skinPanel_right
            // 
            this.skinPanel_right.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel_right.Controls.Add(this.skinTabControl1);
            this.skinPanel_right.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.skinPanel_right.DownBack = null;
            this.skinPanel_right.Location = new System.Drawing.Point(451, 28);
            this.skinPanel_right.MouseBack = null;
            this.skinPanel_right.Name = "skinPanel_right";
            this.skinPanel_right.NormlBack = null;
            this.skinPanel_right.Size = new System.Drawing.Size(175, 458);
            this.skinPanel_right.TabIndex = 131;
            // 
            // skinTabControl1
            // 
            this.skinTabControl1.BaseColor = System.Drawing.Color.White;
            this.skinTabControl1.BorderColor = System.Drawing.Color.White;
            this.skinTabControl1.BtnArrowDown = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.BtnArrowDown")));
            this.skinTabControl1.BtnArrowHover = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.BtnArrowHover")));
            this.skinTabControl1.BtnArrowNorml = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.BtnArrowNorml")));
            this.skinTabControl1.Controls.Add(this.tabPage1);
            this.skinTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTabControl1.ItemSize = new System.Drawing.Size(70, 36);
            this.skinTabControl1.Location = new System.Drawing.Point(0, 0);
            this.skinTabControl1.Name = "skinTabControl1";
            this.skinTabControl1.PageColor = System.Drawing.Color.White;
            this.skinTabControl1.PageDown = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageDown")));
            this.skinTabControl1.PageHover = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageHover")));
            this.skinTabControl1.PageNorml = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageNorml")));
            this.skinTabControl1.SelectedIndex = 0;
            this.skinTabControl1.Size = new System.Drawing.Size(175, 458);
            this.skinTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.skinTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.imgMeShow);
            this.tabPage1.Controls.Add(this.imgChatShow);
            this.tabPage1.Location = new System.Drawing.Point(4, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(167, 414);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "对方名片";
            // 
            // imgMeShow
            // 
            this.imgMeShow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.imgMeShow.BackColor = System.Drawing.Color.Transparent;
            this.imgMeShow.Image = global::ChatClient.Properties.Resources.log1;
            this.imgMeShow.Location = new System.Drawing.Point(41, 282);
            this.imgMeShow.Name = "imgMeShow";
            this.imgMeShow.Size = new System.Drawing.Size(88, 78);
            this.imgMeShow.TabIndex = 126;
            this.imgMeShow.TabStop = false;
            // 
            // imgChatShow
            // 
            this.imgChatShow.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.imgChatShow.BackColor = System.Drawing.Color.Transparent;
            this.imgChatShow.Image = global::ChatClient.Properties.Resources.girl1;
            this.imgChatShow.Location = new System.Drawing.Point(14, 22);
            this.imgChatShow.Name = "imgChatShow";
            this.imgChatShow.Size = new System.Drawing.Size(140, 201);
            this.imgChatShow.TabIndex = 125;
            this.imgChatShow.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(448, 28);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 458);
            this.splitter1.TabIndex = 132;
            this.splitter1.TabStop = false;
            // 
            // skinPanel_left
            // 
            this.skinPanel_left.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel_left.Controls.Add(this.chatControl1);
            this.skinPanel_left.Controls.Add(this.splitter2);
            this.skinPanel_left.Controls.Add(this.skinPanel1);
            this.skinPanel_left.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel_left.DownBack = null;
            this.skinPanel_left.Location = new System.Drawing.Point(4, 52);
            this.skinPanel_left.MouseBack = null;
            this.skinPanel_left.Name = "skinPanel_left";
            this.skinPanel_left.NormlBack = null;
            this.skinPanel_left.Size = new System.Drawing.Size(444, 434);
            this.skinPanel_left.TabIndex = 133;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 431);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(444, 3);
            this.splitter2.TabIndex = 136;
            this.splitter2.TabStop = false;
            this.splitter2.Visible = false;
            // 
            // skinPanel1
            // 
            this.skinPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.liklblgg);
            this.skinPanel1.Controls.Add(this.btnSend);
            this.skinPanel1.Controls.Add(this.skinButtom3);
            this.skinPanel1.Controls.Add(this.btnClose);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(0, 399);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(444, 35);
            this.skinPanel1.TabIndex = 135;
            // 
            // liklblgg
            // 
            this.liklblgg.ActiveLinkColor = System.Drawing.Color.Black;
            this.liklblgg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.liklblgg.AutoSize = true;
            this.liklblgg.BackColor = System.Drawing.Color.Transparent;
            this.liklblgg.DisabledLinkColor = System.Drawing.Color.Black;
            this.liklblgg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.liklblgg.ForeColor = System.Drawing.Color.Black;
            this.liklblgg.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.liklblgg.LinkColor = System.Drawing.Color.Black;
            this.liklblgg.Location = new System.Drawing.Point(3, 10);
            this.liklblgg.Name = "liklblgg";
            this.liklblgg.Size = new System.Drawing.Size(56, 17);
            this.liklblgg.TabIndex = 130;
            this.liklblgg.TabStop = true;
            this.liklblgg.Text = "聊天程序";
            this.liklblgg.VisitedLinkColor = System.Drawing.SystemColors.HotTrack;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.BaseColor = System.Drawing.Color.SkyBlue;
            this.btnSend.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSend.DownBack = ((System.Drawing.Image)(resources.GetObject("btnSend.DownBack")));
            this.btnSend.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnSend.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSend.Location = new System.Drawing.Point(360, 6);
            this.btnSend.Margin = new System.Windows.Forms.Padding(0);
            this.btnSend.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnSend.MouseBack")));
            this.btnSend.Name = "btnSend";
            this.btnSend.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnSend.NormlBack")));
            this.btnSend.Size = new System.Drawing.Size(61, 24);
            this.btnSend.TabIndex = 128;
            this.btnSend.Text = "发送(&S)";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // skinButtom3
            // 
            this.skinButtom3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.skinButtom3.BackColor = System.Drawing.Color.Transparent;
            this.skinButtom3.BaseColor = System.Drawing.Color.SkyBlue;
            this.skinButtom3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButtom3.DownBack = ((System.Drawing.Image)(resources.GetObject("skinButtom3.DownBack")));
            this.skinButtom3.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButtom3.Location = new System.Drawing.Point(421, 6);
            this.skinButtom3.Margin = new System.Windows.Forms.Padding(0);
            this.skinButtom3.MouseBack = ((System.Drawing.Image)(resources.GetObject("skinButtom3.MouseBack")));
            this.skinButtom3.Name = "skinButtom3";
            this.skinButtom3.NormlBack = ((System.Drawing.Image)(resources.GetObject("skinButtom3.NormlBack")));
            this.skinButtom3.Size = new System.Drawing.Size(20, 24);
            this.skinButtom3.TabIndex = 129;
            this.skinButtom3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.skinButtom3.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.SkyBlue;
            this.btnClose.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.DownBack = ((System.Drawing.Image)(resources.GetObject("btnClose.DownBack")));
            this.btnClose.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(288, 6);
            this.btnClose.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnClose.MouseBack")));
            this.btnClose.Name = "btnClose";
            this.btnClose.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnClose.NormlBack")));
            this.btnClose.Size = new System.Drawing.Size(69, 24);
            this.btnClose.TabIndex = 127;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlTx
            // 
            this.pnlTx.BackColor = System.Drawing.Color.Transparent;
            this.pnlTx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTx.BackRectangle = new System.Drawing.Rectangle(5, 5, 5, 5);
            this.pnlTx.Controls.Add(this.panelFriendHeadImage);
            this.pnlTx.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.pnlTx.DownBack = global::ChatClient.Properties.Resources.aio_head_normal;
            this.pnlTx.Location = new System.Drawing.Point(6, 7);
            this.pnlTx.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTx.MouseBack = global::ChatClient.Properties.Resources.aio_head_normal;
            this.pnlTx.Name = "pnlTx";
            this.pnlTx.NormlBack = global::ChatClient.Properties.Resources.aio_head_normal;
            this.pnlTx.Palace = true;
            this.pnlTx.Size = new System.Drawing.Size(49, 49);
            this.pnlTx.TabIndex = 134;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.miniToolStrip.Arrow = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.Back = System.Drawing.Color.White;
            this.miniToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.miniToolStrip.BackRadius = 4;
            this.miniToolStrip.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.miniToolStrip.Base = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.miniToolStrip.BaseFore = System.Drawing.Color.Black;
            this.miniToolStrip.BaseForeAnamorphosis = false;
            this.miniToolStrip.BaseForeAnamorphosisBorder = 4;
            this.miniToolStrip.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.miniToolStrip.BaseHoverFore = System.Drawing.Color.Black;
            this.miniToolStrip.BaseItemAnamorphosis = true;
            this.miniToolStrip.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.miniToolStrip.BaseItemBorderShow = true;
            this.miniToolStrip.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("miniToolStrip.BaseItemDown")));
            this.miniToolStrip.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.miniToolStrip.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("miniToolStrip.BaseItemMouse")));
            this.miniToolStrip.BaseItemPressed = System.Drawing.Color.Transparent;
            this.miniToolStrip.BaseItemRadius = 2;
            this.miniToolStrip.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.miniToolStrip.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.miniToolStrip.Fore = System.Drawing.Color.Black;
            this.miniToolStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.HoverFore = System.Drawing.Color.White;
            this.miniToolStrip.ItemAnamorphosis = false;
            this.miniToolStrip.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.miniToolStrip.ItemBorderShow = false;
            this.miniToolStrip.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.miniToolStrip.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.miniToolStrip.ItemRadius = 3;
            this.miniToolStrip.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.miniToolStrip.Location = new System.Drawing.Point(1, 25);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.miniToolStrip.Size = new System.Drawing.Size(263, 27);
            this.miniToolStrip.TabIndex = 132;
            this.miniToolStrip.TitleAnamorphosis = false;
            this.miniToolStrip.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.miniToolStrip.TitleRadius = 4;
            this.miniToolStrip.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // timerCheckSendIsSuccess
            // 
            this.timerCheckSendIsSuccess.Tick += new System.EventHandler(this.timerCheckSendIsSuccess_Tick);
            // 
            // chatControl1
            // 
            this.chatControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatControl1.BackColor = System.Drawing.Color.SteelBlue;
            this.chatControl1.Location = new System.Drawing.Point(0, -1);
            this.chatControl1.Name = "chatControl1";
            this.chatControl1.Size = new System.Drawing.Size(444, 400);
            this.chatControl1.TabIndex = 137;
            // 
            // frmchatMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.BackLayout = false;
            this.BorderPalace = global::ChatClient.Properties.Resources.BackPalace;
            this.ClientSize = new System.Drawing.Size(630, 490);
            this.CloseBoxSize = new System.Drawing.Size(39, 20);
            this.CloseDownBack = global::ChatClient.Properties.Resources.btn_close_down;
            this.CloseMouseBack = global::ChatClient.Properties.Resources.btn_close_highlight;
            this.CloseNormlBack = global::ChatClient.Properties.Resources.btn_close_disable;
            this.ControlBoxOffset = new System.Drawing.Point(0, -1);
            this.Controls.Add(this.pnlTx);
            this.Controls.Add(this.skinPanel_left);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.skinPanel_right);
            this.Controls.Add(this.imgyy2);
            this.Controls.Add(this.labelFriendName);
            this.Controls.Add(this.labelFriendSignature);
            this.EffectCaption = false;
            this.EffectWidth = 4;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaxDownBack = global::ChatClient.Properties.Resources.btn_max_down;
            this.MaxMouseBack = global::ChatClient.Properties.Resources.btn_max_highlight;
            this.MaxNormlBack = global::ChatClient.Properties.Resources.btn_max_normal;
            this.MaxSize = new System.Drawing.Size(28, 20);
            this.MiniDownBack = global::ChatClient.Properties.Resources.btn_mini_down;
            this.MiniMouseBack = global::ChatClient.Properties.Resources.btn_mini_highlight;
            this.MiniNormlBack = global::ChatClient.Properties.Resources.btn_mini_normal;
            this.MiniSize = new System.Drawing.Size(28, 20);
            this.Name = "frmchatMain";
            this.RestoreDownBack = global::ChatClient.Properties.Resources.btn_restore_down;
            this.RestoreMouseBack = global::ChatClient.Properties.Resources.btn_restore_highlight;
            this.RestoreNormlBack = global::ChatClient.Properties.Resources.btn_restore_normal;
            this.Shadow = false;
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.Special = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.SysBottomDown = global::ChatClient.Properties.Resources.AIO_SetBtn_down;
            this.SysBottomMouse = global::ChatClient.Properties.Resources.AIO_SetBtn_highlight;
            this.SysBottomNorml = global::ChatClient.Properties.Resources.AIO_SetBtn_normal;
            this.SysBottomVisibale = true;
            this.Text = "chat";
            ((System.ComponentModel.ISupportInitialize)(this.imgyy2)).EndInit();
            this.skinPanel_right.ResumeLayout(false);
            this.skinTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgMeShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgChatShow)).EndInit();
            this.skinPanel_left.ResumeLayout(false);
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.pnlTx.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinPanel panelFriendHeadImage;
        private CCWin.SkinControl.SkinLabel labelFriendName;
        private CCWin.SkinControl.SkinLabel labelFriendSignature;
        private System.Windows.Forms.PictureBox imgyy2;
        private CCWin.SkinControl.SkinPanel skinPanel_right;
        private System.Windows.Forms.Splitter splitter1;
        private CCWin.SkinControl.SkinPanel skinPanel_left;
        private CCWin.SkinControl.SkinTabControl skinTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox imgMeShow;
        private System.Windows.Forms.PictureBox imgChatShow;
        private System.Windows.Forms.Splitter splitter2;
        private CCWin.SkinControl.SkinPanel skinPanel1;
        private System.Windows.Forms.LinkLabel liklblgg;
        private CCWin.SkinControl.SkinButton btnSend;
        private CCWin.SkinControl.SkinButton skinButtom3;
        private CCWin.SkinControl.SkinButton btnClose;
        private CCWin.SkinControl.SkinPanel pnlTx;
        private CCWin.SkinControl.SkinToolStrip miniToolStrip;
        private System.Windows.Forms.Timer timerCheckSendIsSuccess;
        private ChatControl chatControl1;


    }
}
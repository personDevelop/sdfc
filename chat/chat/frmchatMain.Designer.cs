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
            FormMain.formMain.forms.Romove(this);
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
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.rtfRichTextBox_history = new MyExtRichTextBox();
            this.RTBSend = new MyExtRichTextBox();
            this.skinToolStrip1 = new CCWin.SkinControl.SkinToolStrip();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton3 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton4 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton5 = new System.Windows.Forms.ToolStripSplitButton();
            this.skToolMenu = new CCWin.SkinControl.SkinToolStrip();
            this.toolFont = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEmotion = new System.Windows.Forms.ToolStripButton();
            this.toolVibration = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripSplitButton();
            this.显示消息记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示比例ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放大Ctrl滚轮ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.清屏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.消息管理器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.liklblgg = new System.Windows.Forms.LinkLabel();
            this.btnSend = new CCWin.SkinControl.SkinButton();
            this.skinButtom3 = new CCWin.SkinControl.SkinButton();
            this.btnClose = new CCWin.SkinControl.SkinButton();
            this.pnlTx = new CCWin.SkinControl.SkinPanel();
            this.miniToolStrip = new CCWin.SkinControl.SkinToolStrip();
            this.timerCheckSendIsSuccess = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imgyy2)).BeginInit();
            this.skinPanel_right.SuspendLayout();
            this.skinTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgMeShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgChatShow)).BeginInit();
            this.skinPanel_left.SuspendLayout();
            this.skinPanel2.SuspendLayout();
            this.skinToolStrip1.SuspendLayout();
            this.skToolMenu.SuspendLayout();
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
            this.labelFriendName.Font = new System.Drawing.Font("Microsoft YaHei", 14F);
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
            this.labelFriendSignature.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
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
            this.skinPanel_left.Controls.Add(this.skinPanel2);
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
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.rtfRichTextBox_history);
            this.skinPanel2.Controls.Add(this.RTBSend);
            this.skinPanel2.Controls.Add(this.skinToolStrip1);
            this.skinPanel2.Controls.Add(this.skToolMenu);
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(0, 0);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(444, 396);
            this.skinPanel2.TabIndex = 137;
            // 
            // rtfRichTextBox_history
            // 
            this.rtfRichTextBox_history.Dock = System.Windows.Forms.DockStyle.Top;
            //this.rtfRichTextBox_history.HiglightColor = chat.RtfColor.White;
            this.rtfRichTextBox_history.Location = new System.Drawing.Point(0, 0);
            this.rtfRichTextBox_history.Name = "rtfRichTextBox_history";
            this.rtfRichTextBox_history.Size = new System.Drawing.Size(444, 268);
            this.rtfRichTextBox_history.TabIndex = 138;
            this.rtfRichTextBox_history.Text = "";
           // this.rtfRichTextBox_history.TextColor = chat.RtfColor.Black;
            // 
            // RTBSend
            // 
            this.RTBSend.Dock = System.Windows.Forms.DockStyle.Bottom;
           // this.RTBSend.HiglightColor = chat.RtfColor.White;
            this.RTBSend.Location = new System.Drawing.Point(0, 298);
            this.RTBSend.Name = "RTBSend";
            this.RTBSend.Size = new System.Drawing.Size(444, 98);
            this.RTBSend.TabIndex = 137;
            this.RTBSend.Text = "";
           // this.RTBSend.TextColor = chat.RtfColor.Black;
            // 
            // skinToolStrip1
            // 
            this.skinToolStrip1.Arrow = System.Drawing.Color.White;
            this.skinToolStrip1.AutoSize = false;
            this.skinToolStrip1.Back = System.Drawing.Color.White;
            this.skinToolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.skinToolStrip1.BackRadius = 4;
            this.skinToolStrip1.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skinToolStrip1.Base = System.Drawing.Color.Transparent;
            this.skinToolStrip1.BaseFore = System.Drawing.Color.Black;
            this.skinToolStrip1.BaseForeAnamorphosis = false;
            this.skinToolStrip1.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip1.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinToolStrip1.BaseHoverFore = System.Drawing.Color.White;
            this.skinToolStrip1.BaseItemAnamorphosis = true;
            this.skinToolStrip1.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.skinToolStrip1.BaseItemBorderShow = true;
            this.skinToolStrip1.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinToolStrip1.BaseItemDown")));
            this.skinToolStrip1.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skinToolStrip1.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinToolStrip1.BaseItemMouse")));
            this.skinToolStrip1.BaseItemPressed = System.Drawing.Color.Transparent;
            this.skinToolStrip1.BaseItemRadius = 2;
            this.skinToolStrip1.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.skinToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.skinToolStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinToolStrip1.Fore = System.Drawing.Color.Black;
            this.skinToolStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skinToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip1.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip1.ItemAnamorphosis = false;
            this.skinToolStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.ItemBorderShow = false;
            this.skinToolStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.ItemRadius = 1;
            this.skinToolStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton6,
            this.toolStripSplitButton3,
            this.toolStripSplitButton4,
            this.toolStripSplitButton5});
            this.skinToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.skinToolStrip1.Name = "skinToolStrip1";
            this.skinToolStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.Size = new System.Drawing.Size(444, 33);
            this.skinToolStrip1.TabIndex = 136;
            this.skinToolStrip1.Text = "skinToolStrip2";
            this.skinToolStrip1.TitleAnamorphosis = false;
            this.skinToolStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinToolStrip1.TitleRadius = 4;
            this.skinToolStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(24, 30);
            this.toolStripButton6.Text = "toolStripButton5";
            this.toolStripButton6.ToolTipText = "视频会话";
            // 
            // toolStripSplitButton3
            // 
            this.toolStripSplitButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.toolStripSplitButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton3.Image")));
            this.toolStripSplitButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton3.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolStripSplitButton3.Name = "toolStripSplitButton3";
            this.toolStripSplitButton3.Size = new System.Drawing.Size(36, 30);
            this.toolStripSplitButton3.Text = "toolStripButton8";
            this.toolStripSplitButton3.ToolTipText = "发送文件";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "发送文件";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem2.Text = "发送文件夹";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem3.Text = "发送离线文件";
            // 
            // toolStripSplitButton4
            // 
            this.toolStripSplitButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem7});
            this.toolStripSplitButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton4.Image")));
            this.toolStripSplitButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSplitButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton4.Name = "toolStripSplitButton4";
            this.toolStripSplitButton4.Size = new System.Drawing.Size(36, 30);
            this.toolStripSplitButton4.Text = "远程协助、桌面共享";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem4.Text = "请求远程协助";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem7.Text = "桌面共享（指定区域）";
            // 
            // toolStripSplitButton5
            // 
            this.toolStripSplitButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton5.Image")));
            this.toolStripSplitButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton5.Name = "toolStripSplitButton5";
            this.toolStripSplitButton5.Size = new System.Drawing.Size(32, 30);
            this.toolStripSplitButton5.Text = "来自对方的语音消息";
            // 
            // skToolMenu
            // 
            this.skToolMenu.Arrow = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.skToolMenu.AutoSize = false;
            this.skToolMenu.Back = System.Drawing.Color.White;
            this.skToolMenu.BackColor = System.Drawing.Color.Transparent;
            this.skToolMenu.BackRadius = 4;
            this.skToolMenu.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skToolMenu.Base = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skToolMenu.BaseFore = System.Drawing.Color.Black;
            this.skToolMenu.BaseForeAnamorphosis = false;
            this.skToolMenu.BaseForeAnamorphosisBorder = 4;
            this.skToolMenu.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skToolMenu.BaseHoverFore = System.Drawing.Color.Black;
            this.skToolMenu.BaseItemAnamorphosis = true;
            this.skToolMenu.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.skToolMenu.BaseItemBorderShow = true;
            this.skToolMenu.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skToolMenu.BaseItemDown")));
            this.skToolMenu.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skToolMenu.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skToolMenu.BaseItemMouse")));
            this.skToolMenu.BaseItemPressed = System.Drawing.Color.Transparent;
            this.skToolMenu.BaseItemRadius = 2;
            this.skToolMenu.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skToolMenu.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.skToolMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.skToolMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skToolMenu.Fore = System.Drawing.Color.Black;
            this.skToolMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skToolMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skToolMenu.HoverFore = System.Drawing.Color.White;
            this.skToolMenu.ItemAnamorphosis = false;
            this.skToolMenu.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenu.ItemBorderShow = false;
            this.skToolMenu.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenu.ItemRadius = 3;
            this.skToolMenu.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skToolMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFont,
            this.toolStripButtonEmotion,
            this.toolVibration,
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripDropDownButton4,
            this.toolStripButton1});
            this.skToolMenu.Location = new System.Drawing.Point(0, 271);
            this.skToolMenu.Name = "skToolMenu";
            this.skToolMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skToolMenu.Size = new System.Drawing.Size(263, 27);
            this.skToolMenu.TabIndex = 132;
            this.skToolMenu.Text = "skinToolStrip1";
            this.skToolMenu.TitleAnamorphosis = false;
            this.skToolMenu.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skToolMenu.TitleRadius = 4;
            this.skToolMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolFont
            // 
            this.toolFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFont.Image = global::ChatClient.Properties.Resources.aio_quickbar_font;
            this.toolFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFont.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.toolFont.Name = "toolFont";
            this.toolFont.Size = new System.Drawing.Size(23, 24);
            this.toolFont.Text = "toolStripButton1";
            this.toolFont.ToolTipText = "字体选择工具栏";
            this.toolFont.Click += new System.EventHandler(this.toolFont_Click);
            // 
            // toolStripButtonEmotion
            // 
            this.toolStripButtonEmotion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEmotion.Image = global::ChatClient.Properties.Resources.aio_quickbar_face;
            this.toolStripButtonEmotion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonEmotion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEmotion.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.toolStripButtonEmotion.Name = "toolStripButtonEmotion";
            this.toolStripButtonEmotion.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonEmotion.Text = "toolStripButton2";
            this.toolStripButtonEmotion.ToolTipText = "选择表情";
            // 
            // toolVibration
            // 
            this.toolVibration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolVibration.Image = global::ChatClient.Properties.Resources.aio_quickbar_twitter;
            this.toolVibration.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolVibration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolVibration.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.toolVibration.Name = "toolVibration";
            this.toolVibration.Size = new System.Drawing.Size(24, 24);
            this.toolVibration.Text = "toolStripButton4";
            this.toolVibration.ToolTipText = "向好友发送窗口抖动";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::ChatClient.Properties.Resources.aio_quickbar_inputassist;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton3.Text = "手写板";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::ChatClient.Properties.Resources.aio_quickbar_cut;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton2.Text = "屏幕截图";
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton4.AutoSize = false;
            this.toolStripDropDownButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示消息记录ToolStripMenuItem,
            this.显示比例ToolStripMenuItem,
            this.toolStripMenuItem5,
            this.清屏ToolStripMenuItem,
            this.消息管理器ToolStripMenuItem});
            this.toolStripDropDownButton4.Image = global::ChatClient.Properties.Resources.aio_quickbar_register;
            this.toolStripDropDownButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripDropDownButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(90, 24);
            this.toolStripDropDownButton4.Text = "消息记录";
            this.toolStripDropDownButton4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripDropDownButton4.ToolTipText = "显示消息记录";
            // 
            // 显示消息记录ToolStripMenuItem
            // 
            this.显示消息记录ToolStripMenuItem.Name = "显示消息记录ToolStripMenuItem";
            this.显示消息记录ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.显示消息记录ToolStripMenuItem.Text = "显示消息记录";
            // 
            // 显示比例ToolStripMenuItem
            // 
            this.显示比例ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.放大Ctrl滚轮ToolStripMenuItem,
            this.缩小ToolStripMenuItem,
            this.toolStripMenuItem6,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12,
            this.toolStripMenuItem13,
            this.toolStripMenuItem14});
            this.显示比例ToolStripMenuItem.Name = "显示比例ToolStripMenuItem";
            this.显示比例ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.显示比例ToolStripMenuItem.Text = "显示比例";
            // 
            // 放大Ctrl滚轮ToolStripMenuItem
            // 
            this.放大Ctrl滚轮ToolStripMenuItem.Name = "放大Ctrl滚轮ToolStripMenuItem";
            this.放大Ctrl滚轮ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.放大Ctrl滚轮ToolStripMenuItem.Text = "放大 Ctrl+滚轮";
            // 
            // 缩小ToolStripMenuItem
            // 
            this.缩小ToolStripMenuItem.Name = "缩小ToolStripMenuItem";
            this.缩小ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.缩小ToolStripMenuItem.Text = "缩小";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(154, 6);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem8.Text = "400%";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem9.Text = "200%";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem10.Text = "150%";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem11.Text = "125%";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem12.Text = "100%";
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem13.Text = "75%";
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem14.Text = "50%";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(145, 6);
            // 
            // 清屏ToolStripMenuItem
            // 
            this.清屏ToolStripMenuItem.Name = "清屏ToolStripMenuItem";
            this.清屏ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.清屏ToolStripMenuItem.Text = "清屏";
            // 
            // 消息管理器ToolStripMenuItem
            // 
            this.消息管理器ToolStripMenuItem.Name = "消息管理器ToolStripMenuItem";
            this.消息管理器ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.消息管理器ToolStripMenuItem.Text = "消息管理器";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 24);
            this.toolStripButton1.Text = "语音消息";
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
            this.liklblgg.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.btnSend.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.btnClose.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            // chat
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
            this.Name = "chat";
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
            this.skinPanel2.ResumeLayout(false);
            this.skinToolStrip1.ResumeLayout(false);
            this.skinToolStrip1.PerformLayout();
            this.skToolMenu.ResumeLayout(false);
            this.skToolMenu.PerformLayout();
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
        private CCWin.SkinControl.SkinPanel skinPanel2;
        private CCWin.SkinControl.SkinToolStrip skToolMenu;
        private System.Windows.Forms.ToolStripButton toolFont;
        private System.Windows.Forms.ToolStripButton toolStripButtonEmotion;
        private System.Windows.Forms.ToolStripButton toolVibration;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSplitButton toolStripDropDownButton4;
        private System.Windows.Forms.ToolStripMenuItem 显示消息记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示比例ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 放大Ctrl滚轮ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩小ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem 清屏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 消息管理器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton5;
        private MyExtRichTextBox RTBSend;
        private MyExtRichTextBox rtfRichTextBox_history;
        private System.Windows.Forms.Timer timerCheckSendIsSuccess;


    }
}
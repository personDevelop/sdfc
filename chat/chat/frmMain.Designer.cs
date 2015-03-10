namespace ChatClient
{
    partial class frmMain
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
            CCWin.SkinControl.ChatListItem chatListItem1 = new CCWin.SkinControl.ChatListItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.chatListBox = new CCWin.SkinControl.ChatListBox();
            this.skinPanel_HeadImage = new CCWin.SkinControl.SkinPanel();
            this.labelSignature = new CCWin.SkinControl.SkinLabel();
            this.skinButton_State = new CCWin.SkinControl.SkinButton();
            this.labelName = new CCWin.SkinControl.SkinLabel();
            this.skinToolStrip3 = new CCWin.SkinControl.SkinToolStrip();
            this.toolStripSplitButton4 = new System.Windows.Forms.ToolStripSplitButton();
            this.添加好友ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton3 = new System.Windows.Forms.ToolStripSplitButton();
            this.加入群ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建群ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.清空会话列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinToolStrip1 = new CCWin.SkinControl.SkinToolStrip();
            this.toolstripButton_mainMenu = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton19 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.skinContextMenuStrip_State = new CCWin.SkinControl.SkinContextMenuStrip();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem30 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem31 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem32 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem33 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem39 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem40 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon1 = new ChatClient.TwinkleNotifyIcon(this.components);
            this.skinToolStrip3.SuspendLayout();
            this.skinToolStrip1.SuspendLayout();
            this.skinContextMenuStrip_State.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chatListBox
            // 
            this.chatListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.chatListBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chatListBox.ForeColor = System.Drawing.Color.Black;
            chatListItem1.Bounds = new System.Drawing.Rectangle(0, 1, 278, 25);
            chatListItem1.IsTwinkleHide = false;
            chatListItem1.OwnerChatListBox = this.chatListBox;
            chatListItem1.Text = "网服在线";
            chatListItem1.TwinkleSubItemNumber = 0;
            this.chatListBox.Items.AddRange(new CCWin.SkinControl.ChatListItem[] {
            chatListItem1});
            this.chatListBox.ListHadOpenGroup = null;
            this.chatListBox.ListSubItemMenu = null;
            this.chatListBox.Location = new System.Drawing.Point(1, 136);
            this.chatListBox.Margin = new System.Windows.Forms.Padding(0);
            this.chatListBox.Name = "chatListBox";
            this.chatListBox.SelectSubItem = null;
            this.chatListBox.Size = new System.Drawing.Size(278, 477);
            this.chatListBox.SubItemMenu = null;
            this.chatListBox.TabIndex = 135;
            this.chatListBox.DoubleClickSubItem += new CCWin.SkinControl.ChatListBox.ChatListEventHandler(this.chatListBox_DoubleClickSubItem);
            // 
            // skinPanel_HeadImage
            // 
            this.skinPanel_HeadImage.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel_HeadImage.BackgroundImage = global::ChatClient.Properties.Resources.compic1335794816668_1653769;
            this.skinPanel_HeadImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.skinPanel_HeadImage.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel_HeadImage.DownBack = null;
            this.skinPanel_HeadImage.Location = new System.Drawing.Point(21, 17);
            this.skinPanel_HeadImage.MouseBack = null;
            this.skinPanel_HeadImage.Name = "skinPanel_HeadImage";
            this.skinPanel_HeadImage.NormlBack = null;
            this.skinPanel_HeadImage.Radius = 4;
            this.skinPanel_HeadImage.Size = new System.Drawing.Size(69, 69);
            this.skinPanel_HeadImage.TabIndex = 130;
            // 
            // labelSignature
            // 
            this.labelSignature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSignature.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.Anamorphosis;
            this.labelSignature.BackColor = System.Drawing.Color.Transparent;
            this.labelSignature.BorderColor = System.Drawing.Color.White;
            this.labelSignature.BorderSize = 4;
            this.labelSignature.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.labelSignature.ForeColor = System.Drawing.Color.Black;
            this.labelSignature.Location = new System.Drawing.Point(96, 54);
            this.labelSignature.Name = "labelSignature";
            this.labelSignature.Size = new System.Drawing.Size(192, 20);
            this.labelSignature.TabIndex = 132;
            this.labelSignature.Text = "退一步海阔天空！";
            // 
            // skinButton_State
            // 
            this.skinButton_State.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_State.BackgroundImage = global::ChatClient.Properties.Resources.imonline__2_;
            this.skinButton_State.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.skinButton_State.BackRectangle = new System.Drawing.Rectangle(4, 4, 4, 4);
            this.skinButton_State.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(90)))), ((int)(((byte)(147)))));
            this.skinButton_State.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_State.DownBack = null;
            this.skinButton_State.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton_State.ImageWidth = 12;
            this.skinButton_State.Location = new System.Drawing.Point(93, 31);
            this.skinButton_State.Margin = new System.Windows.Forms.Padding(0);
            this.skinButton_State.MouseBack = null;
            this.skinButton_State.Name = "skinButton_State";
            this.skinButton_State.NormlBack = null;
            this.skinButton_State.Palace = true;
            this.skinButton_State.Size = new System.Drawing.Size(23, 23);
            this.skinButton_State.TabIndex = 133;
            this.skinButton_State.Tag = "1";
            this.skinButton_State.UseVisualStyleBackColor = false;
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.Anamorphosis;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.BorderColor = System.Drawing.Color.White;
            this.labelName.BorderSize = 4;
            this.labelName.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelName.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.labelName.ForeColor = System.Drawing.Color.Black;
            this.labelName.Location = new System.Drawing.Point(119, 31);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(130, 23);
            this.labelName.TabIndex = 131;
            this.labelName.Text = "David";
            // 
            // skinToolStrip3
            // 
            this.skinToolStrip3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinToolStrip3.Arrow = System.Drawing.Color.White;
            this.skinToolStrip3.AutoSize = false;
            this.skinToolStrip3.Back = System.Drawing.Color.White;
            this.skinToolStrip3.BackColor = System.Drawing.Color.Transparent;
            this.skinToolStrip3.BackRadius = 4;
            this.skinToolStrip3.BackRectangle = new System.Drawing.Rectangle(2, 2, 2, 2);
            this.skinToolStrip3.Base = System.Drawing.Color.Transparent;
            this.skinToolStrip3.BaseFore = System.Drawing.Color.Black;
            this.skinToolStrip3.BaseForeAnamorphosis = false;
            this.skinToolStrip3.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip3.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinToolStrip3.BaseHoverFore = System.Drawing.Color.Black;
            this.skinToolStrip3.BaseItemAnamorphosis = true;
            this.skinToolStrip3.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.skinToolStrip3.BaseItemBorderShow = false;
            this.skinToolStrip3.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinToolStrip3.BaseItemDown")));
            this.skinToolStrip3.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skinToolStrip3.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinToolStrip3.BaseItemMouse")));
            this.skinToolStrip3.BaseItemPressed = System.Drawing.Color.Transparent;
            this.skinToolStrip3.BaseItemRadius = 2;
            this.skinToolStrip3.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip3.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.skinToolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.skinToolStrip3.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinToolStrip3.Fore = System.Drawing.Color.Black;
            this.skinToolStrip3.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skinToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip3.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skinToolStrip3.ItemAnamorphosis = false;
            this.skinToolStrip3.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip3.ItemBorderShow = false;
            this.skinToolStrip3.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip3.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip3.ItemRadius = 3;
            this.skinToolStrip3.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton4,
            this.toolStripSplitButton3,
            this.toolStripSplitButton2});
            this.skinToolStrip3.Location = new System.Drawing.Point(4, 102);
            this.skinToolStrip3.Name = "skinToolStrip3";
            this.skinToolStrip3.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip3.Size = new System.Drawing.Size(275, 34);
            this.skinToolStrip3.TabIndex = 134;
            this.skinToolStrip3.Text = "skinToolStrip3";
            this.skinToolStrip3.TitleAnamorphosis = false;
            this.skinToolStrip3.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinToolStrip3.TitleRadius = 4;
            this.skinToolStrip3.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolStripSplitButton4
            // 
            this.toolStripSplitButton4.AutoSize = false;
            this.toolStripSplitButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton4.DropDownButtonWidth = 20;
            this.toolStripSplitButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加好友ToolStripMenuItem});
            this.toolStripSplitButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton4.Image")));
            this.toolStripSplitButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSplitButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton4.Name = "toolStripSplitButton4";
            this.toolStripSplitButton4.Size = new System.Drawing.Size(70, 35);
            this.toolStripSplitButton4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripSplitButton4.ToolTipText = "联系人";
            // 
            // 添加好友ToolStripMenuItem
            // 
            this.添加好友ToolStripMenuItem.Name = "添加好友ToolStripMenuItem";
            this.添加好友ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.添加好友ToolStripMenuItem.Text = "添加好友";
            // 
            // toolStripSplitButton3
            // 
            this.toolStripSplitButton3.AutoSize = false;
            this.toolStripSplitButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton3.DropDownButtonWidth = 20;
            this.toolStripSplitButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加入群ToolStripMenuItem,
            this.创建群ToolStripMenuItem});
            this.toolStripSplitButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton3.Image")));
            this.toolStripSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton3.Name = "toolStripSplitButton3";
            this.toolStripSplitButton3.Size = new System.Drawing.Size(70, 35);
            this.toolStripSplitButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripSplitButton3.ToolTipText = "GG群";
            // 
            // 加入群ToolStripMenuItem
            // 
            this.加入群ToolStripMenuItem.Name = "加入群ToolStripMenuItem";
            this.加入群ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.加入群ToolStripMenuItem.Text = "加入群";
            // 
            // 创建群ToolStripMenuItem
            // 
            this.创建群ToolStripMenuItem.Name = "创建群ToolStripMenuItem";
            this.创建群ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.创建群ToolStripMenuItem.Text = "创建群";
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.AutoSize = false;
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.DropDownButtonWidth = 20;
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空会话列表ToolStripMenuItem});
            this.toolStripSplitButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton2.Image")));
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(70, 35);
            this.toolStripSplitButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripSplitButton2.ToolTipText = "会话";
            // 
            // 清空会话列表ToolStripMenuItem
            // 
            this.清空会话列表ToolStripMenuItem.Name = "清空会话列表ToolStripMenuItem";
            this.清空会话列表ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.清空会话列表ToolStripMenuItem.Text = "清空会话列表";
            // 
            // skinToolStrip1
            // 
            this.skinToolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinToolStrip1.Arrow = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.skinToolStrip1.AutoSize = false;
            this.skinToolStrip1.Back = System.Drawing.Color.White;
            this.skinToolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.skinToolStrip1.BackRadius = 4;
            this.skinToolStrip1.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skinToolStrip1.Base = System.Drawing.Color.Transparent;
            this.skinToolStrip1.BaseFore = System.Drawing.Color.Black;
            this.skinToolStrip1.BaseForeAnamorphosis = true;
            this.skinToolStrip1.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip1.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinToolStrip1.BaseHoverFore = System.Drawing.Color.Black;
            this.skinToolStrip1.BaseItemAnamorphosis = true;
            this.skinToolStrip1.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
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
            this.skinToolStrip1.ItemRadius = 3;
            this.skinToolStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripButton_mainMenu,
            this.toolStripButton1,
            this.toolStripButton4,
            this.toolStripButton19,
            this.toolStripButton2});
            this.skinToolStrip1.Location = new System.Drawing.Point(1, 613);
            this.skinToolStrip1.Name = "skinToolStrip1";
            this.skinToolStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.Size = new System.Drawing.Size(330, 24);
            this.skinToolStrip1.TabIndex = 136;
            this.skinToolStrip1.Text = "skinToolStrip2";
            this.skinToolStrip1.TitleAnamorphosis = false;
            this.skinToolStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinToolStrip1.TitleRadius = 4;
            this.skinToolStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolstripButton_mainMenu
            // 
            this.toolstripButton_mainMenu.AutoSize = false;
            this.toolstripButton_mainMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstripButton_mainMenu.Image = global::ChatClient.Properties.Resources.menu_btn_normal;
            this.toolstripButton_mainMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstripButton_mainMenu.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.toolstripButton_mainMenu.Name = "toolstripButton_mainMenu";
            this.toolstripButton_mainMenu.Size = new System.Drawing.Size(24, 24);
            this.toolstripButton_mainMenu.Text = "toolStripButton4";
            this.toolstripButton_mainMenu.ToolTipText = "主菜单";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton2";
            this.toolStripButton1.ToolTipText = "打开系统设置";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 21);
            this.toolStripButton4.Text = "添加好友";
            // 
            // toolStripButton19
            // 
            this.toolStripButton19.AutoSize = false;
            this.toolStripButton19.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton19.Image")));
            this.toolStripButton19.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.toolStripButton19.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton19.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton19.Name = "toolStripButton19";
            this.toolStripButton19.Size = new System.Drawing.Size(54, 24);
            this.toolStripButton19.Text = "加群";
            this.toolStripButton19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButton19.ToolTipText = "加群";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton2.Text = "toolStripButton3";
            this.toolStripButton2.ToolTipText = "打开消息管理器";
            // 
            // skinContextMenuStrip_State
            // 
            this.skinContextMenuStrip_State.Arrow = System.Drawing.Color.Black;
            this.skinContextMenuStrip_State.Back = System.Drawing.Color.White;
            this.skinContextMenuStrip_State.BackRadius = 4;
            this.skinContextMenuStrip_State.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.skinContextMenuStrip_State.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinContextMenuStrip_State.Fore = System.Drawing.Color.Black;
            this.skinContextMenuStrip_State.HoverFore = System.Drawing.Color.White;
            this.skinContextMenuStrip_State.ItemAnamorphosis = false;
            this.skinContextMenuStrip_State.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_State.ItemBorderShow = false;
            this.skinContextMenuStrip_State.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_State.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_State.ItemRadius = 4;
            this.skinContextMenuStrip_State.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinContextMenuStrip_State.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem20,
            this.toolStripMenuItem30,
            this.toolStripMenuItem31,
            this.toolStripMenuItem32,
            this.toolStripMenuItem33,
            this.toolStripSeparator6,
            this.toolStripMenuItem39,
            this.toolStripMenuItem40});
            this.skinContextMenuStrip_State.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinContextMenuStrip_State.Name = "MenuState";
            this.skinContextMenuStrip_State.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip_State.Size = new System.Drawing.Size(134, 164);
            this.skinContextMenuStrip_State.TitleAnamorphosis = false;
            this.skinContextMenuStrip_State.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinContextMenuStrip_State.TitleRadius = 4;
            this.skinContextMenuStrip_State.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Image = global::ChatClient.Properties.Resources.imonline__2_;
            this.toolStripMenuItem20.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem20.Tag = "2";
            this.toolStripMenuItem20.Text = "我在线上";
            this.toolStripMenuItem20.ToolTipText = "表示希望好友看到您在线。\r\n声音：开启\r\n消息提醒框：开启\r\n会话消息：任务栏头像闪动\r\n";
            // 
            // toolStripMenuItem30
            // 
            this.toolStripMenuItem30.Image = global::ChatClient.Properties.Resources.away__2_;
            this.toolStripMenuItem30.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem30.Name = "toolStripMenuItem30";
            this.toolStripMenuItem30.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem30.Tag = "3";
            this.toolStripMenuItem30.Text = "离开";
            this.toolStripMenuItem30.ToolTipText = "表示离开，暂无法处理消息。\r\n声音：开启\r\n消息提醒框：开启\r\n会话消息：任务栏头像闪动\r\n";
            // 
            // toolStripMenuItem31
            // 
            this.toolStripMenuItem31.Image = global::ChatClient.Properties.Resources.busy__2_;
            this.toolStripMenuItem31.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem31.Name = "toolStripMenuItem31";
            this.toolStripMenuItem31.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem31.Tag = "4";
            this.toolStripMenuItem31.Text = "忙碌";
            this.toolStripMenuItem31.ToolTipText = "表示忙碌，不会及时处理消息。\r\n声音：开启\r\n消息提醒框：开启\r\n会话消息：任务栏显示气泡\r\n";
            // 
            // toolStripMenuItem32
            // 
            this.toolStripMenuItem32.Image = global::ChatClient.Properties.Resources.mute__2_;
            this.toolStripMenuItem32.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem32.Name = "toolStripMenuItem32";
            this.toolStripMenuItem32.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem32.Tag = "5";
            this.toolStripMenuItem32.Text = "请勿打扰";
            this.toolStripMenuItem32.ToolTipText = "表示不想被打扰。\r\n声音：关闭\r\n消息提醒框：关闭\r\n会话消息：任务栏显示气泡\r\n\r\n";
            // 
            // toolStripMenuItem33
            // 
            this.toolStripMenuItem33.Image = global::ChatClient.Properties.Resources.invisible__2_;
            this.toolStripMenuItem33.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem33.Name = "toolStripMenuItem33";
            this.toolStripMenuItem33.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem33.Tag = "6";
            this.toolStripMenuItem33.Text = "隐身";
            this.toolStripMenuItem33.ToolTipText = "表示好友看到您是离线的。\r\n声音：开启\r\n消息提醒框：开启\r\n会话消息：任务栏头像闪动\r\n";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(130, 6);
            // 
            // toolStripMenuItem39
            // 
            this.toolStripMenuItem39.Name = "toolStripMenuItem39";
            this.toolStripMenuItem39.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem39.Text = "系统设置...";
            // 
            // toolStripMenuItem40
            // 
            this.toolStripMenuItem40.Name = "toolStripMenuItem40";
            this.toolStripMenuItem40.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem40.Text = "我的资料...";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem,
            this.退出ToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 48);
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItem.Text = "显示主面板";
            this.ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem1
            // 
            this.退出ToolStripMenuItem1.Name = "退出ToolStripMenuItem1";
            this.退出ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.退出ToolStripMenuItem1.Text = "退出";
            this.退出ToolStripMenuItem1.Click += new System.EventHandler(this.退出ToolStripMenuItem1_Click);
            // 
            // notifyIcon2
            // 
            this.notifyIcon2.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon2.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon2.Icon")));
            this.notifyIcon2.Text = "即时通";
            this.notifyIcon2.Visible = true;
            this.notifyIcon2.DoubleClick += new System.EventHandler(this.notifyIcon2_DoubleClick);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Back = global::ChatClient.Properties.Resources.blue;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(90)))), ((int)(((byte)(147)))));
            this.BackLayout = false;
            this.BorderPalace = global::ChatClient.Properties.Resources.BackPalace;
            this.ClientSize = new System.Drawing.Size(281, 640);
            this.CloseBoxSize = new System.Drawing.Size(39, 20);
            this.CloseDownBack = global::ChatClient.Properties.Resources.btn_close_down;
            this.CloseMouseBack = global::ChatClient.Properties.Resources.btn_close_highlight;
            this.CloseNormlBack = global::ChatClient.Properties.Resources.btn_close_disable;
            this.ControlBoxOffset = new System.Drawing.Point(0, -1);
            this.Controls.Add(this.skinToolStrip1);
            this.Controls.Add(this.chatListBox);
            this.Controls.Add(this.skinToolStrip3);
            this.Controls.Add(this.labelSignature);
            this.Controls.Add(this.skinButton_State);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.skinPanel_HeadImage);
            this.EffectCaption = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaxDownBack = global::ChatClient.Properties.Resources.btn_max_down;
            this.MaximizeBox = false;
            this.MaxMouseBack = global::ChatClient.Properties.Resources.btn_max_highlight;
            this.MaxNormlBack = global::ChatClient.Properties.Resources.btn_max_normal;
            this.MaxSize = new System.Drawing.Size(28, 20);
            this.MiniDownBack = global::ChatClient.Properties.Resources.btn_mini_down;
            this.MiniMouseBack = global::ChatClient.Properties.Resources.btn_mini_highlight;
            this.MiniNormlBack = global::ChatClient.Properties.Resources.btn_mini_normal;
            this.MiniSize = new System.Drawing.Size(28, 20);
            this.Name = "frmMain";
            this.RestoreDownBack = global::ChatClient.Properties.Resources.btn_restore_down;
            this.RestoreMouseBack = global::ChatClient.Properties.Resources.btn_restore_highlight;
            this.RestoreNormlBack = global::ChatClient.Properties.Resources.btn_restore_normal;
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.ShowInTaskbar = false;
            this.SkinOpacity = 100D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.SysBottomDown = global::ChatClient.Properties.Resources.btn_Skin_down;
            this.SysBottomMouse = global::ChatClient.Properties.Resources.btn_Skin_highlight;
            this.SysBottomNorml = global::ChatClient.Properties.Resources.btn_Skin_normal;
            this.SysBottomToolTip = "更改外观";
            this.SysBottomVisibale = true;
            this.Text = "GG 2013";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.main_Load);
            this.skinToolStrip3.ResumeLayout(false);
            this.skinToolStrip3.PerformLayout();
            this.skinToolStrip1.ResumeLayout(false);
            this.skinToolStrip1.PerformLayout();
            this.skinContextMenuStrip_State.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel_HeadImage;
        private CCWin.SkinControl.SkinLabel labelSignature;
        private CCWin.SkinControl.SkinButton skinButton_State;
        private CCWin.SkinControl.SkinLabel labelName;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip3;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton4;
        private System.Windows.Forms.ToolStripMenuItem 添加好友ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton3;
        private System.Windows.Forms.ToolStripMenuItem 加入群ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建群ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem 清空会话列表ToolStripMenuItem;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip1;
        private System.Windows.Forms.ToolStripButton toolstripButton_mainMenu;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton19;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private CCWin.SkinControl.SkinContextMenuStrip skinContextMenuStrip_State;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem20;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem30;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem31;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem32;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem33;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem39;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem40;
        private CCWin.SkinControl.ChatListBox chatListBox;
        private TwinkleNotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon2;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem1;
    }
}
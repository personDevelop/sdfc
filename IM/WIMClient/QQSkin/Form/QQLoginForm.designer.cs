using WIMClient.Skin;
namespace WIMClient.Skin
{
    partial class QQLoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QQLoginForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.netsetting_link = new System.Windows.Forms.LinkLabel();
            this.pass_link = new System.Windows.Forms.LinkLabel();
            this.ButtonClose = new System.Windows.Forms.PictureBox();
            this.ButtonMax = new System.Windows.Forms.PictureBox();
            this.ButtonMin = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.autologin_CheckBox = new WIMClient.Skin.BasicCheckBox();
            this.savepass_CheckBox = new WIMClient.Skin.BasicCheckBox();
            this.btnLogin = new WIMClient.Skin.LoginButton();
            this.txtPassword = new WIMClient.Skin.BasicQQTextBox();
            this.txtUserID = new WIMClient.Skin.BasicQQTextBox();
            this.newid_link = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMin)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(18, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "密码:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "帐号:";
            // 
            // netsetting_link
            // 
            this.netsetting_link.ActiveLinkColor = System.Drawing.Color.Black;
            this.netsetting_link.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.netsetting_link.BackColor = System.Drawing.Color.Transparent;
            this.netsetting_link.DisabledLinkColor = System.Drawing.Color.Gray;
            this.netsetting_link.Image = ((System.Drawing.Image)(resources.GetObject("netsetting_link.Image")));
            this.netsetting_link.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.netsetting_link.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.netsetting_link.LinkColor = System.Drawing.Color.Black;
            this.netsetting_link.Location = new System.Drawing.Point(18, 501);
            this.netsetting_link.Name = "netsetting_link";
            this.netsetting_link.Size = new System.Drawing.Size(76, 22);
            this.netsetting_link.TabIndex = 38;
            this.netsetting_link.TabStop = true;
            this.netsetting_link.Text = "设置";
            this.netsetting_link.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.netsetting_link.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // pass_link
            // 
            this.pass_link.ActiveLinkColor = System.Drawing.Color.Black;
            this.pass_link.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pass_link.BackColor = System.Drawing.Color.Transparent;
            this.pass_link.DisabledLinkColor = System.Drawing.Color.Gray;
            this.pass_link.Image = ((System.Drawing.Image)(resources.GetObject("pass_link.Image")));
            this.pass_link.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pass_link.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.pass_link.LinkColor = System.Drawing.Color.Black;
            this.pass_link.Location = new System.Drawing.Point(18, 479);
            this.pass_link.Name = "pass_link";
            this.pass_link.Size = new System.Drawing.Size(100, 22);
            this.pass_link.TabIndex = 37;
            this.pass_link.TabStop = true;
            this.pass_link.Text = "找回密码";
            this.pass_link.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pass_link.VisitedLinkColor = System.Drawing.Color.Black;
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
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Image = global::WIMClient.Properties.Resources.sm70_16;
            this.linkLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(143, 479);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(78, 22);
            this.linkLabel1.TabIndex = 39;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "好友";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // autologin_CheckBox
            // 
            this.autologin_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.autologin_CheckBox.BackColor = System.Drawing.Color.Transparent;
            this.autologin_CheckBox.Checked = false;
            this.autologin_CheckBox.CheckState = WIMClient.Skin.BasicCheckBox.CheckStates.Unchecked;
            this.autologin_CheckBox.Location = new System.Drawing.Point(21, 329);
            this.autologin_CheckBox.MinimumSize = new System.Drawing.Size(15, 15);
            this.autologin_CheckBox.Name = "autologin_CheckBox";
            this.autologin_CheckBox.Size = new System.Drawing.Size(76, 15);
            this.autologin_CheckBox.TabIndex = 35;
            this.autologin_CheckBox.Texts = "自动登录";
            // 
            // savepass_CheckBox
            // 
            this.savepass_CheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.savepass_CheckBox.BackColor = System.Drawing.Color.Transparent;
            this.savepass_CheckBox.Checked = false;
            this.savepass_CheckBox.CheckState = WIMClient.Skin.BasicCheckBox.CheckStates.Unchecked;
            this.savepass_CheckBox.Location = new System.Drawing.Point(21, 308);
            this.savepass_CheckBox.MinimumSize = new System.Drawing.Size(15, 15);
            this.savepass_CheckBox.Name = "savepass_CheckBox";
            this.savepass_CheckBox.Size = new System.Drawing.Size(76, 15);
            this.savepass_CheckBox.TabIndex = 34;
            this.savepass_CheckBox.Texts = "记住密码";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.Location = new System.Drawing.Point(84, 374);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(76, 27);
            this.btnLogin.TabIndex = 33;
            this.btnLogin.Texts = "登录";
            this.btnLogin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.loginButton_MouseClick);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPassword.Icon = ((System.Drawing.Bitmap)(resources.GetObject("txtPassword.Icon")));
            this.txtPassword.IsPass = true;
            this.txtPassword.Location = new System.Drawing.Point(21, 252);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.ReadOn = false;
            this.txtPassword.Size = new System.Drawing.Size(200, 23);
            this.txtPassword.TabIndex = 30;
            this.txtPassword.Texts = "";
            // 
            // txtUserID
            // 
            this.txtUserID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtUserID.BackColor = System.Drawing.Color.White;
            this.txtUserID.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserID.Icon = null;
            this.txtUserID.IsPass = false;
            this.txtUserID.Location = new System.Drawing.Point(21, 196);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOn = false;
            this.txtUserID.Size = new System.Drawing.Size(200, 23);
            this.txtUserID.TabIndex = 29;
            this.txtUserID.Texts = "";
            // 
            // newid_link
            // 
            this.newid_link.ActiveLinkColor = System.Drawing.Color.Black;
            this.newid_link.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newid_link.BackColor = System.Drawing.Color.Transparent;
            this.newid_link.DisabledLinkColor = System.Drawing.Color.Gray;
            this.newid_link.Image = ((System.Drawing.Image)(resources.GetObject("newid_link.Image")));
            this.newid_link.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newid_link.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.newid_link.LinkColor = System.Drawing.Color.Black;
            this.newid_link.Location = new System.Drawing.Point(18, 457);
            this.newid_link.Name = "newid_link";
            this.newid_link.Size = new System.Drawing.Size(91, 22);
            this.newid_link.TabIndex = 36;
            this.newid_link.TabStop = true;
            this.newid_link.Text = "注册新帐号";
            this.newid_link.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.newid_link.VisitedLinkColor = System.Drawing.Color.Black;
            this.newid_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.newid_link_LinkClicked);
            // 
            // QQLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(180)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(240, 550);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.netsetting_link);
            this.Controls.Add(this.pass_link);
            this.Controls.Add(this.newid_link);
            this.Controls.Add(this.autologin_CheckBox);
            this.Controls.Add(this.savepass_CheckBox);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonMax);
            this.Controls.Add(this.ButtonMin);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(240, 319);
            this.Name = "QQLoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.ButtonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ButtonMin;
        private System.Windows.Forms.PictureBox ButtonMax;
        private System.Windows.Forms.PictureBox ButtonClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private BasicQQTextBox txtPassword;
        private BasicQQTextBox txtUserID;
        private LoginButton btnLogin;
        private BasicCheckBox savepass_CheckBox;
        private BasicCheckBox autologin_CheckBox;
        private System.Windows.Forms.LinkLabel pass_link;
        private System.Windows.Forms.LinkLabel netsetting_link;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel newid_link;

    }
}
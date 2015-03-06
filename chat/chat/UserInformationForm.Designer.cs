namespace chat
{
    partial class UserInformationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInformationForm));
            this.lblName = new CCWin.SkinControl.SkinLabel();
            this.lblQm = new CCWin.SkinControl.SkinLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timShow = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.Anamorphosis;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.BorderColor = System.Drawing.Color.Black;
            this.lblName.BorderSize = 4;
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.Font = new System.Drawing.Font("Microsoft YaHei", 16F);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(96, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(145, 30);
            this.lblName.TabIndex = 104;
            this.lblName.Text = "威廉乔克斯_汀";
            this.lblName.MouseEnter += new System.EventHandler(this.lblChatName_MouseEnter);
            this.lblName.MouseLeave += new System.EventHandler(this.lblChatName_MouseLeave);
            // 
            // lblQm
            // 
            this.lblQm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQm.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.Anamorphosis;
            this.lblQm.BackColor = System.Drawing.Color.Transparent;
            this.lblQm.BorderColor = System.Drawing.Color.Black;
            this.lblQm.BorderSize = 4;
            this.lblQm.Font = new System.Drawing.Font("Microsoft YaHei", 10F);
            this.lblQm.ForeColor = System.Drawing.Color.White;
            this.lblQm.Location = new System.Drawing.Point(97, 49);
            this.lblQm.Name = "lblQm";
            this.lblQm.Size = new System.Drawing.Size(176, 20);
            this.lblQm.TabIndex = 105;
            this.lblQm.Text = "退一步海阔天空！";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 103;
            this.pictureBox1.TabStop = false;
            // 
            // timShow
            // 
            this.timShow.Enabled = true;
            this.timShow.Interval = 500;
            this.timShow.Tick += new System.EventHandler(this.timShow_Tick_1);
            // 
            // UserInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.BackLayout = false;
            this.BorderPalace = global::chat.Properties.Resources.BackPalace;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(279, 181);
            this.CloseBoxSize = new System.Drawing.Size(39, 20);
            this.ControlBox = false;
            this.ControlBoxActive = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.ControlBoxDeactive = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(172)))), ((int)(((byte)(218)))));
            this.ControlBoxOffset = new System.Drawing.Point(0, -1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblQm);
            this.Controls.Add(this.pictureBox1);
            this.DropBack = false;
            this.Mobile = CCWin.MobileStyle.None;
            this.Name = "UserInformationForm";
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FrmInformation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinLabel lblName;
        private CCWin.SkinControl.SkinLabel lblQm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timShow;
    }
}
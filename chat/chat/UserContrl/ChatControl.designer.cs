namespace ChatClient
{
    partial class ChatControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolFont = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBQ = new System.Windows.Forms.ToolStripButton();
            this.toolZD = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolImage = new System.Windows.Forms.ToolStripButton();
            this.toolCapture = new System.Windows.Forms.ToolStripButton();
            this.toolHisMsg = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.txtSendMsg = new CCWin.SkinControl.RtfRichTextBox();
            this.txtAllMsg = new CCWin.SkinControl.RtfRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.SteelBlue;
            this.splitContainer1.Location = new System.Drawing.Point(1, 1);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.txtAllMsg);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.txtSendMsg);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(594, 512);
            this.splitContainer1.SplitterDistance = 317;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFont,
            this.toolStripSeparator1,
            this.toolBQ,
            this.toolZD,
            this.toolStripSeparator2,
            this.toolImage,
            this.toolCapture,
            this.toolHisMsg});
            this.toolStrip1.Location = new System.Drawing.Point(-6, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(603, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolFont
            // 
            this.toolFont.Image = ((System.Drawing.Image)(resources.GetObject("toolFont.Image")));
            this.toolFont.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolFont.Name = "toolFont";
            this.toolFont.Size = new System.Drawing.Size(28, 22);
            this.toolFont.Text = " ";
            this.toolFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolFont.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolFont.ToolTipText = "字体工具栏";
            this.toolFont.Click += new System.EventHandler(this.toolFont_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolBQ
            // 
            this.toolBQ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBQ.Image = ((System.Drawing.Image)(resources.GetObject("toolBQ.Image")));
            this.toolBQ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBQ.Name = "toolBQ";
            this.toolBQ.Size = new System.Drawing.Size(23, 22);
            this.toolBQ.ToolTipText = "选择表情";
            this.toolBQ.Click += new System.EventHandler(this.toolStripButton表情_Click);
            // 
            // toolZD
            // 
            this.toolZD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolZD.Image = ((System.Drawing.Image)(resources.GetObject("toolZD.Image")));
            this.toolZD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolZD.Name = "toolZD";
            this.toolZD.Size = new System.Drawing.Size(23, 22);
            this.toolZD.Text = "toolStripButton3";
            this.toolZD.ToolTipText = "向好友发送窗口抖动";
            this.toolZD.Click += new System.EventHandler(this.toolStripButton震动_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolImage
            // 
            this.toolImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolImage.Image = ((System.Drawing.Image)(resources.GetObject("toolImage.Image")));
            this.toolImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolImage.Name = "toolImage";
            this.toolImage.Size = new System.Drawing.Size(23, 22);
            this.toolImage.ToolTipText = "发送图片";
            this.toolImage.Click += new System.EventHandler(this.InsertImage_Click);
            // 
            // toolCapture
            // 
            this.toolCapture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCapture.Image = ((System.Drawing.Image)(resources.GetObject("toolCapture.Image")));
            this.toolCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCapture.Name = "toolCapture";
            this.toolCapture.Size = new System.Drawing.Size(23, 22);
            this.toolCapture.ToolTipText = "屏幕截图";
            this.toolCapture.Click += new System.EventHandler(this.capture_Click);
            // 
            // toolHisMsg
            // 
            this.toolHisMsg.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolHisMsg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolHisMsg.Image = global::ChatClient.Properties.Resources.invisible__2_;
            this.toolHisMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolHisMsg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolHisMsg.Name = "toolHisMsg";
            this.toolHisMsg.Size = new System.Drawing.Size(60, 22);
            this.toolHisMsg.Text = "聊天记录";
            this.toolHisMsg.ToolTipText = "显示消息记录";
            this.toolHisMsg.Click += new System.EventHandler(this.toolStripButton聊天记录_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1.gif");
            this.imageList1.Images.SetKeyName(1, "2.gif");
            this.imageList1.Images.SetKeyName(2, "3.gif");
            this.imageList1.Images.SetKeyName(3, "4.gif");
            this.imageList1.Images.SetKeyName(4, "5.gif");
            this.imageList1.Images.SetKeyName(5, "6.gif");
            this.imageList1.Images.SetKeyName(6, "7.gif");
            this.imageList1.Images.SetKeyName(7, "8.gif");
            this.imageList1.Images.SetKeyName(8, "9.gif");
            this.imageList1.Images.SetKeyName(9, "10.gif");
            this.imageList1.Images.SetKeyName(10, "11.gif");
            this.imageList1.Images.SetKeyName(11, "12.gif");
            this.imageList1.Images.SetKeyName(12, "13.gif");
            this.imageList1.Images.SetKeyName(13, "14.gif");
            this.imageList1.Images.SetKeyName(14, "15.gif");
            this.imageList1.Images.SetKeyName(15, "16.gif");
            this.imageList1.Images.SetKeyName(16, "17.gif");
            this.imageList1.Images.SetKeyName(17, "18.gif");
            this.imageList1.Images.SetKeyName(18, "19.gif");
            this.imageList1.Images.SetKeyName(19, "20.gif");
            this.imageList1.Images.SetKeyName(20, "21.gif");
            this.imageList1.Images.SetKeyName(21, "22.gif");
            this.imageList1.Images.SetKeyName(22, "23.gif");
            this.imageList1.Images.SetKeyName(23, "24.gif");
            this.imageList1.Images.SetKeyName(24, "25.gif");
            this.imageList1.Images.SetKeyName(25, "26.gif");
            this.imageList1.Images.SetKeyName(26, "27.gif");
            this.imageList1.Images.SetKeyName(27, "28.gif");
            this.imageList1.Images.SetKeyName(28, "29.gif");
            this.imageList1.Images.SetKeyName(29, "30.gif");
            this.imageList1.Images.SetKeyName(30, "31.gif");
            this.imageList1.Images.SetKeyName(31, "32.gif");
            this.imageList1.Images.SetKeyName(32, "33.gif");
            this.imageList1.Images.SetKeyName(33, "34.gif");
            this.imageList1.Images.SetKeyName(34, "35.gif");
            this.imageList1.Images.SetKeyName(35, "36.gif");
            this.imageList1.Images.SetKeyName(36, "37.gif");
            this.imageList1.Images.SetKeyName(37, "38.gif");
            this.imageList1.Images.SetKeyName(38, "39.gif");
            this.imageList1.Images.SetKeyName(39, "40.gif");
            this.imageList1.Images.SetKeyName(40, "41.gif");
            this.imageList1.Images.SetKeyName(41, "42.gif");
            this.imageList1.Images.SetKeyName(42, "43.gif");
            this.imageList1.Images.SetKeyName(43, "44.gif");
            this.imageList1.Images.SetKeyName(44, "45.gif");
            this.imageList1.Images.SetKeyName(45, "46.gif");
            this.imageList1.Images.SetKeyName(46, "47.gif");
            this.imageList1.Images.SetKeyName(47, "48.gif");
            this.imageList1.Images.SetKeyName(48, "49.gif");
            this.imageList1.Images.SetKeyName(49, "50.gif");
            this.imageList1.Images.SetKeyName(50, "51.gif");
            this.imageList1.Images.SetKeyName(51, "52.gif");
            this.imageList1.Images.SetKeyName(52, "53.gif");
            this.imageList1.Images.SetKeyName(53, "54.gif");
            this.imageList1.Images.SetKeyName(54, "55.gif");
            this.imageList1.Images.SetKeyName(55, "56.gif");
            this.imageList1.Images.SetKeyName(56, "57.gif");
            this.imageList1.Images.SetKeyName(57, "58.gif");
            this.imageList1.Images.SetKeyName(58, "59.gif");
            this.imageList1.Images.SetKeyName(59, "60.gif");
            this.imageList1.Images.SetKeyName(60, "61.gif");
            this.imageList1.Images.SetKeyName(61, "62.gif");
            this.imageList1.Images.SetKeyName(62, "63.gif");
            this.imageList1.Images.SetKeyName(63, "64.gif");
            this.imageList1.Images.SetKeyName(64, "65.gif");
            this.imageList1.Images.SetKeyName(65, "66.gif");
            this.imageList1.Images.SetKeyName(66, "67.gif");
            this.imageList1.Images.SetKeyName(67, "68.gif");
            this.imageList1.Images.SetKeyName(68, "69.gif");
            this.imageList1.Images.SetKeyName(69, "70.gif");
            this.imageList1.Images.SetKeyName(70, "71.gif");
            this.imageList1.Images.SetKeyName(71, "72.gif");
            this.imageList1.Images.SetKeyName(72, "73.gif");
            this.imageList1.Images.SetKeyName(73, "74.gif");
            this.imageList1.Images.SetKeyName(74, "75.gif");
            this.imageList1.Images.SetKeyName(75, "76.gif");
            this.imageList1.Images.SetKeyName(76, "77.gif");
            this.imageList1.Images.SetKeyName(77, "78.gif");
            this.imageList1.Images.SetKeyName(78, "79.gif");
            this.imageList1.Images.SetKeyName(79, "80.gif");
            this.imageList1.Images.SetKeyName(80, "81.gif");
            this.imageList1.Images.SetKeyName(81, "82.gif");
            this.imageList1.Images.SetKeyName(82, "83.gif");
            this.imageList1.Images.SetKeyName(83, "84.gif");
            this.imageList1.Images.SetKeyName(84, "85.gif");
            this.imageList1.Images.SetKeyName(85, "86.gif");
            this.imageList1.Images.SetKeyName(86, "87.gif");
            this.imageList1.Images.SetKeyName(87, "88.gif");
            this.imageList1.Images.SetKeyName(88, "89.gif");
            this.imageList1.Images.SetKeyName(89, "90.gif");
            this.imageList1.Images.SetKeyName(90, "91.gif");
            this.imageList1.Images.SetKeyName(91, "92.gif");
            this.imageList1.Images.SetKeyName(92, "93.gif");
            this.imageList1.Images.SetKeyName(93, "94.gif");
            this.imageList1.Images.SetKeyName(94, "95.gif");
            this.imageList1.Images.SetKeyName(95, "96.gif");
            this.imageList1.Images.SetKeyName(96, "97.gif");
            this.imageList1.Images.SetKeyName(97, "98.gif");
            this.imageList1.Images.SetKeyName(98, "99.gif");
            this.imageList1.Images.SetKeyName(99, "100.gif");
            this.imageList1.Images.SetKeyName(100, "101.gif");
            this.imageList1.Images.SetKeyName(101, "102.gif");
            this.imageList1.Images.SetKeyName(102, "103.gif");
            this.imageList1.Images.SetKeyName(103, "104.gif");
            this.imageList1.Images.SetKeyName(104, "105.gif");
            this.imageList1.Images.SetKeyName(105, "106.gif");
            this.imageList1.Images.SetKeyName(106, "107.gif");
            this.imageList1.Images.SetKeyName(107, "108.gif");
            this.imageList1.Images.SetKeyName(108, "109.gif");
            this.imageList1.Images.SetKeyName(109, "110.gif");
            this.imageList1.Images.SetKeyName(110, "111.gif");
            this.imageList1.Images.SetKeyName(111, "112.gif");
            this.imageList1.Images.SetKeyName(112, "113.gif");
            this.imageList1.Images.SetKeyName(113, "114.gif");
            this.imageList1.Images.SetKeyName(114, "115.gif");
            this.imageList1.Images.SetKeyName(115, "116.gif");
            this.imageList1.Images.SetKeyName(116, "117.gif");
            this.imageList1.Images.SetKeyName(117, "118.gif");
            this.imageList1.Images.SetKeyName(118, "119.gif");
            this.imageList1.Images.SetKeyName(119, "120.gif");
            this.imageList1.Images.SetKeyName(120, "121.gif");
            this.imageList1.Images.SetKeyName(121, "122.gif");
            this.imageList1.Images.SetKeyName(122, "123.gif");
            this.imageList1.Images.SetKeyName(123, "124.gif");
            this.imageList1.Images.SetKeyName(124, "125.gif");
            this.imageList1.Images.SetKeyName(125, "126.gif");
            this.imageList1.Images.SetKeyName(126, "127.gif");
            this.imageList1.Images.SetKeyName(127, "128.gif");
            this.imageList1.Images.SetKeyName(128, "129.gif");
            this.imageList1.Images.SetKeyName(129, "130.gif");
            this.imageList1.Images.SetKeyName(130, "131.gif");
            this.imageList1.Images.SetKeyName(131, "132.gif");
            this.imageList1.Images.SetKeyName(132, "133.gif");
            this.imageList1.Images.SetKeyName(133, "134.gif");
            this.imageList1.Images.SetKeyName(134, "135.gif");
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSendMsg.HiglightColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.White;
            this.txtSendMsg.Location = new System.Drawing.Point(2, 27);
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(589, 164);
            this.txtSendMsg.TabIndex = 1;
            this.txtSendMsg.Text = "";
            this.txtSendMsg.TextColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.Black;
            // 
            // txtAllMsg
            // 
            this.txtAllMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAllMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAllMsg.HiglightColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.White;
            this.txtAllMsg.Location = new System.Drawing.Point(0, 0);
            this.txtAllMsg.Name = "txtAllMsg";
            this.txtAllMsg.Size = new System.Drawing.Size(594, 317);
            this.txtAllMsg.TabIndex = 2;
            this.txtAllMsg.Text = "";
            this.txtAllMsg.TextColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.Black;
            // 
            // ChatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ChatControl";
            this.Size = new System.Drawing.Size(596, 514);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolFont;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolHisMsg;
        private System.Windows.Forms.ToolStripButton toolZD;
        private System.Windows.Forms.ToolStripButton toolBQ;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripButton toolCapture;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private CCWin.SkinControl.RtfRichTextBox txtAllMsg;
        private CCWin.SkinControl.RtfRichTextBox txtSendMsg;
    }
}

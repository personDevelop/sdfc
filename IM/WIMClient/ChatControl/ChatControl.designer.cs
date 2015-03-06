namespace WIMClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.richTextBoxEx_read = new WIMClient.RichTextBoxEx();
            this.richTextBoxEx_send = new WIMClient.RichTextBoxEx();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.font = new System.Windows.Forms.ToolStripComboBox();
            this.fontSize = new System.Windows.Forms.ToolStripComboBox();
            this.bold = new System.Windows.Forms.ToolStripButton();
            this.italic = new System.Windows.Forms.ToolStripButton();
            this.underline = new System.Windows.Forms.ToolStripButton();
            this.color = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton震动 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton聊天记录 = new System.Windows.Forms.ToolStripButton();
            this.capture = new System.Windows.Forms.ToolStripButton();
            this.InsertImage = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
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
            this.splitContainer1.Panel1.Controls.Add(this.richTextBoxEx_read);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxEx_send);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(594, 512);
            this.splitContainer1.SplitterDistance = 317;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // richTextBoxEx_read
            // 
            this.richTextBoxEx_read.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxEx_read.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxEx_read.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxEx_read.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBoxEx_read.MaxLength = 0;
            this.richTextBoxEx_read.Name = "richTextBoxEx_read";
            this.richTextBoxEx_read.ReadOnly = true;
            this.richTextBoxEx_read.Size = new System.Drawing.Size(594, 317);
            this.richTextBoxEx_read.TabIndex = 0;
            this.richTextBoxEx_read.Text = "";
            // 
            // richTextBoxEx_send
            // 
            this.richTextBoxEx_send.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxEx_send.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxEx_send.Location = new System.Drawing.Point(0, 25);
            this.richTextBoxEx_send.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBoxEx_send.MaxLength = 0;
            this.richTextBoxEx_send.Name = "richTextBoxEx_send";
            this.richTextBoxEx_send.Size = new System.Drawing.Size(594, 169);
            this.richTextBoxEx_send.TabIndex = 1;
            this.richTextBoxEx_send.Text = "";
            this.richTextBoxEx_send.TextChanged += new System.EventHandler(this.richTextBoxEx_send_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.font,
            this.fontSize,
            this.bold,
            this.italic,
            this.underline,
            this.color,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripButton震动,
            this.toolStripSeparator2,
            this.toolStripButton聊天记录,
            this.capture,
            this.InsertImage});
            this.toolStrip1.Location = new System.Drawing.Point(-6, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(603, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
            this.toolStripLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(28, 22);
            this.toolStripLabel1.Text = " ";
            this.toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // font
            // 
            this.font.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.font.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.font.MaxDropDownItems = 12;
            this.font.Name = "font";
            this.font.Size = new System.Drawing.Size(100, 25);
            this.font.ToolTipText = "字体";
            // 
            // fontSize
            // 
            this.fontSize.AutoSize = false;
            this.fontSize.AutoToolTip = true;
            this.fontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.fontSize.Items.AddRange(new object[] {
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.fontSize.Name = "fontSize";
            this.fontSize.Size = new System.Drawing.Size(55, 25);
            this.fontSize.ToolTipText = "字体大小";
            // 
            // bold
            // 
            this.bold.CheckOnClick = true;
            this.bold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bold.Image = ((System.Drawing.Image)(resources.GetObject("bold.Image")));
            this.bold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bold.Name = "bold";
            this.bold.Size = new System.Drawing.Size(23, 22);
            this.bold.ToolTipText = "加粗";
            // 
            // italic
            // 
            this.italic.CheckOnClick = true;
            this.italic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.italic.Image = ((System.Drawing.Image)(resources.GetObject("italic.Image")));
            this.italic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.italic.Name = "italic";
            this.italic.Size = new System.Drawing.Size(23, 22);
            this.italic.ToolTipText = "斜体";
            // 
            // underline
            // 
            this.underline.CheckOnClick = true;
            this.underline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.underline.Image = ((System.Drawing.Image)(resources.GetObject("underline.Image")));
            this.underline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.underline.Name = "underline";
            this.underline.Size = new System.Drawing.Size(23, 22);
            this.underline.ToolTipText = "下划线";
            // 
            // color
            // 
            this.color.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.color.Image = ((System.Drawing.Image)(resources.GetObject("color.Image")));
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(23, 22);
            this.color.ToolTipText = "颜色";
            this.color.Click += new System.EventHandler(this.color_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.ToolTipText = "表情";
            this.toolStripButton1.Visible = false;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton表情_Click);
            // 
            // toolStripButton震动
            // 
            this.toolStripButton震动.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton震动.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton震动.Image")));
            this.toolStripButton震动.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton震动.Name = "toolStripButton震动";
            this.toolStripButton震动.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton震动.Text = "toolStripButton3";
            this.toolStripButton震动.ToolTipText = "发送窗体抖动";
            this.toolStripButton震动.Visible = false;
            this.toolStripButton震动.Click += new System.EventHandler(this.toolStripButton震动_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton聊天记录
            // 
            this.toolStripButton聊天记录.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton聊天记录.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton聊天记录.Image")));
            this.toolStripButton聊天记录.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton聊天记录.Name = "toolStripButton聊天记录";
            this.toolStripButton聊天记录.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton聊天记录.Text = "聊天记录";
            this.toolStripButton聊天记录.Click += new System.EventHandler(this.toolStripButton聊天记录_Click);
            // 
            // capture
            // 
            this.capture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.capture.Image = ((System.Drawing.Image)(resources.GetObject("capture.Image")));
            this.capture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.capture.Name = "capture";
            this.capture.Size = new System.Drawing.Size(23, 22);
            this.capture.ToolTipText = "表情";
            this.capture.Click += new System.EventHandler(this.capture_Click);
            // 
            // InsertImage
            // 
            this.InsertImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.InsertImage.Image = ((System.Drawing.Image)(resources.GetObject("InsertImage.Image")));
            this.InsertImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InsertImage.Name = "InsertImage";
            this.InsertImage.Size = new System.Drawing.Size(23, 22);
            this.InsertImage.ToolTipText = "表情";
            this.InsertImage.Click += new System.EventHandler(this.InsertImage_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
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
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox font;
        private System.Windows.Forms.ToolStripButton color;
        private System.Windows.Forms.ToolStripButton bold;
        private System.Windows.Forms.ToolStripButton italic;
        private System.Windows.Forms.ToolStripButton underline;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton InsertImage;
        private System.Windows.Forms.ToolStripComboBox fontSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton聊天记录;
        private RichTextBoxEx richTextBoxEx_read;
        private RichTextBoxEx richTextBoxEx_send;
        private System.Windows.Forms.ToolStripButton toolStripButton震动;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripButton capture;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using System.Net;
using CCWin.Win32;
using CCWin.Win32.Const;

using NetworkCommsDotNet;
using AuthorityEntity.IM;
namespace ChatClient
{
    public partial class frmchatMain : CCSkinMain, IManagedForm
    {
        private ClassGifs SendGifs = new ClassGifs();
        private IMUserInfo friend;
        public frmchatMain()
        {
            InitializeComponent();
            //panelFriendHeadImage.BackgroundImage = Image.FromFile("head/image.jpg");

        }
        public frmchatMain(IMUserInfo friend)
            : this()
        {
            // TODO: Complete member initialization
            this.friend = friend;
            labelFriendName.Text = friend.DisplayName;
            labelFriendSignature.Text = friend.DisplaySignature;
            this.Text = "正在和" + labelFriendName.Text + "对话";
        }


        #region 关闭按钮
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 设置字体
        private void toolFont_Click(object sender, EventArgs e)
        {
            //System.Windows.Forms.FontDialog fd = new FontDialog();
            //if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    this.RTBSend.Font = fd.Font;
        }
        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            chatControl1.SendMessage();

        }
        private MyPicture findPic(string ID, ClassGifs gifs)
        {
            foreach (MyPicture pic in gifs)
                if (Convert.ToString(pic.Tag) == ID)
                    return pic;
            return null;
        }
        private class ClassGifs : System.Collections.CollectionBase
        {
            public ClassGifs()
            {
                //
                // TODO: 在此处添加构造函数逻辑
                //
            }
            public void add(MyPicture tempGif)
            {
                base.InnerList.Add(tempGif);
            }

            public void Romove(MyPicture tempGif)
            {
                base.InnerList.Remove(tempGif);
            }
        }

        //private byte[] GetSendString()//获得要发送的序列化字串
        //{

        //    this.SendTextMsg = GetSendTextMsg();
        //    return (new ClassSerializers().SerializeBinary(SendTextMsg).ToArray());
        //}
        //private ClassTextMsg GetSendTextMsg()//获得要发送的序列化字串
        //{
        //    ClassTextMsg textMsg = new ClassTextMsg();
        //    MyExtRichTextBox rich = new MyExtRichTextBox();
        //    rich.Rtf = this.RTBSend.Rtf;
        //    textMsg.MsgContent = rich.Rtf;//获得消息rtf内容
        //    textMsg.font = this.RTBSend.Font;//获得文本字体
        //    textMsg.color = this.RTBSend.ForeColor;//获得文本颜色
        //    REOBJECT reObject = new REOBJECT();
        //    MyPicture pic;
        //    for (int i = 0; i < RTBSend.TextLength; i++)
        //    {
        //        RTBSend.Select(i, 1);
        //        RichTextBoxSelectionTypes rt = RTBSend.SelectionType;
        //        if (rt == RichTextBoxSelectionTypes.Object)
        //        {
        //            RTBSend.Copy();
        //            Image img = Clipboard.GetImage();
        //            if (img != null)
        //            {
        //                MyPicture pic1 = new MyPicture();
        //                pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
        //                pic1.BackColor = this.RTBSend.BackColor;
        //                pic1.Image = img;
        //                pic1.Tag = i;
        //                //MyPicture pic1 = new MyPicture();
        //                this.SendGifs.add(pic1);
        //                textMsg.ImageInfo += i.ToString() + "," + i.ToString() + "|";
        //                //img.Dispose();
        //            }
        //        }
        //    }
        //    //for (int i = 0; i < this.RTBSend.GetRichEditOleInterface().GetObjectCount(); i++)
        //    //{
        //    //    this.RTBSend.GetRichEditOleInterface().GetObject(i, reObject, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES);
        //    //    RTBSend.Select(i, 1);
        //    //    RichTextBoxSelectionTypes rt = RTBSend.SelectionType;
        //    //    if (rt == RichTextBoxSelectionTypes.Object)
        //    //    {
        //    //        RTBSend.Copy();
        //    //        Image img = Clipboard.GetImage();
        //    //        if (img != null)
        //    //        {
        //    //            MyPicture pic1 = new MyPicture();
        //    //            pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
        //    //            pic1.BackColor = this.RTBSend.BackColor;
        //    //            pic1.Image = img;
        //    //            pic1.Tag = i;
        //    //            //MyPicture pic1 = new MyPicture();
        //    //            this.SendGifs.add(pic1);
        //    //            textMsg.ImageInfo += i.ToString() + "," + i.ToString() + "|";
        //    //            //img.Dispose();
        //    //        }
        //    //    }
        //    //    //pic = this.findPic(reObject.dwUser.ToString(), this.SendGifs);
        //    //    //if (pic != null)
        //    //    //{
        //    //    //    pic.IsSent = true;//发送此图片
        //    //    //    textMsg.ImageInfo += reObject.cp.ToString() + "," +i.ToString() + "|";
        //    //    //    //textMsg.ImageInfo += reObject.cp.ToString() + "," + reObject.dwUser.ToString() + "," + pic.Image.Size.Width.ToString() + "," + pic.Image.Size.Height.ToString() + "|";
        //    //    //}
        //    //    //else
        //    //    //{
        //    //    //    textMsg.ImageInfo += reObject.cp.ToString() + "," + reObject.dwUser.ToString() + "|";
        //    //    //}
        //    //}


        //    rich.Clear();
        //    rich.Dispose();
        //    return textMsg;
        //}

        private void getALLImage()
        {
            //for (int i = 0; i < RTBSend.TextLength; i++)
            //{
            //    RTBSend.Select(i, 1);
            //    RichTextBoxSelectionTypes rt = RTBSend.SelectionType;

            //    if (rt == RichTextBoxSelectionTypes.Object)
            //    {
            //        //当然也可能是其它的类型

            //        RTBSend.Copy();
            //        Image img = Clipboard.GetImage();
            //        if (img != null)
            //        {
            //            MessageBox.Show("这是一个图片");
            //            img.Save("e:\\" + i.ToString() + ".bmp");
            //            img.Dispose();
            //        }
            //    }
            //}
        }

        //public void newTextMsg(string title, Font titleFont, Color titleColor)//将发送的消息加入历史rich
        //{
        //    this.SendTextMsg = GetSendTextMsg();
        //    MyExtRichTextBox rich = new MyExtRichTextBox();
        //    rich.AppendText(title);
        //    rich.Font = titleFont;
        //    rich.ForeColor = titleColor;
        //    getALLImage();
        //    this.rtfRichTextBox_history.AppendRtf(rich.Rtf);
        //    this.rtfRichTextBox_history.AppendText("  ");
        //    ClassTextMsg textMsg = this.SendTextMsg;

        //    int iniPos = this.rtfRichTextBox_history.TextLength;//获得当前记录richBox中最后的位置
        //    //rtfRichTextBox_history.Rtf = RTBSend.Rtf;
        //    //rich.Clear();
        //    // rich.Dispose();
        //    // return;
        //    //if (textMsg.ImageInfo != "")//如果消息中有图片，则添加图片
        //    //{

        //    //        string[] imagePos = textMsg.ImageInfo.Split('|');
        //    //        int addPos = 0;//
        //    //        int currPos = 0;//当前正要添加的文本位置
        //    //        int textPos = 0;
        //    //        for (int i = 0; i < imagePos.Length - 1; i++)
        //    //        {
        //    //            string[] imageContent = imagePos[i].Split(',');//获得图片所在的位置、图片名称、图片宽、高

        //    //            currPos = Convert.ToInt32(imageContent[0]);

        //    //            this.rtfRichTextBox_history.AppendText(textMsg.MsgContent.Substring(textPos, currPos - addPos));
        //    //            this.rtfRichTextBox_history.SelectionStart = this.rtfRichTextBox_history.TextLength;

        //    //            textPos += currPos - addPos;
        //    //            addPos += currPos - addPos;

        //    //            MyPicture pic = new MyPicture();
        //    //            pic.BackColor = this.rtfRichTextBox_history.BackColor;
        //    //            pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
        //    //            if (Convert.ToUInt32(imageContent[1]) > 96)
        //    //                pic.Image = System.Drawing.Image.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LanMsg.Resources." + imageContent[1] + ".gif"));
        //    //            else
        //    //            {
        //    //                pic.Tag = imageContent[1];
        //    //                pic.Image = this.findPic(imageContent[1], this.SendGifs).Image;
        //    //            }

        //    //            System.Drawing.ImageAnimator.Animate(pic.Image, new System.EventHandler(this.RTBRecordOnFrameChanged));
        //    //            this.rtfRichTextBox_history.InsertMyControl(pic);
        //    //           // Graphics GraphicsMyg = rtfRichTextBox_history.CreateGraphics();

        //    //           // GraphicsMyg.DrawImage(pic.Image, 0, 0);
        //    //            //GraphicsMyg.ResetTransform();   
        //    //            addPos++;
        //    //        }
        //    //        this.rtfRichTextBox_history.AppendText(textMsg.MsgContent.Substring(textPos, textMsg.MsgContent.Length - textPos) + "\n");

        //    //}
        //    //else//如果消息中没有图片，则直接添加消息文本
        //    //{
        //    //    this.rtfRichTextBox_history.AppendText(textMsg.MsgContent + "\n");
        //    //}
        //    this.rtfRichTextBox_history.AppendRtf(textMsg.MsgContent + "\n");
        //    this.rtfRichTextBox_history.Focus();
        //    this.rtfRichTextBox_history.Select(iniPos, this.rtfRichTextBox_history.TextLength - iniPos);

        //    this.rtfRichTextBox_history.Select(iniPos, this.rtfRichTextBox_history.TextLength - iniPos);
        //    this.rtfRichTextBox_history.SelectionColor = textMsg.color;
        //    this.RTBSend.Focus();
        //}

        private void RTBRecordOnFrameChanged(object sender, EventArgs e)
        {
            //this.rtfRichTextBox_history.Invalidate();
        }

        //public void newTextMsg(byte[] content, string title, Font titleFont, Color titleColor)//收到对方发送过来文本消息
        //{
        //    MyExtRichTextBox rich = new MyExtRichTextBox();
        //    rich.AppendText(title);
        //    rich.Font = titleFont;
        //    rich.ForeColor = titleColor;
        //    this.rtfRichTextBox_history.AppendRtf(rich.Rtf);
        //    this.rtfRichTextBox_history.AppendText("  ");

        //    ClassTextMsg textMsg = (new ClassSerializers().DeSerializeBinary(new System.IO.MemoryStream(content)) as ClassTextMsg);

        //    int iniPos = this.rtfRichTextBox_history.TextLength;//获得当前记录richBox中最后的位置

        //    rich.Clear();
        //    rich.Dispose();

        //    if (textMsg.ImageInfo != "")//如果消息中有图片，则添加图片
        //    {

        //    }
        //    else//如果消息中没有图片，则直接添加消息文本
        //    {
        //        //this.rtfRichTextBox_history.AppendText(textMsg.MsgContent + "\n");

        //    }
        //    this.rtfRichTextBox_history.AppendRtf(textMsg.MsgContent + "\n");
        //    this.rtfRichTextBox_history.Focus();
        //    this.rtfRichTextBox_history.Select(iniPos, this.rtfRichTextBox_history.TextLength - iniPos);

        //    this.rtfRichTextBox_history.Select(iniPos, this.rtfRichTextBox_history.TextLength - iniPos);
        //    this.rtfRichTextBox_history.SelectionColor = textMsg.color;


        //    this.currUserInfo = this.FormMain.formMain.findUser(this.Tag.ToString());
        //    this.RTBSend.Focus();
        //    //if (this.currUserInfo != null)
        //    // this.FormMain.formMain.sendMsgToOneUser(new ClassMsg(6, this.FormMain.formMain.selfInfo.ID, null), currUserInfo.IP, currUserInfo.Port);//告诉发消息的联系人已经收到发送的消息

        //    //this.FormMain.formMain.MsgAddToDB(textMsg.MsgContent, this.Tag.ToString(), this.FormMain.formMain.selfInfo.ID, this.FormMain.formMain.selfInfo.AssemblyVersion, System.DateTime.Now.ToString(), textMsg.ImageInfo, true);//将消息添加进数据库
        //}
        private void EnBut(bool t)//启用或禁用发送功能
        {
            //this.btnSend.Enabled = t;
            //this.RTBSend.ReadOnly = !t;
            //OutTime = 0;
            //this.timerCheckSendIsSuccess.Enabled = !t;//开始检测消息是否发送成功
        }

        private int OutTime = 0;


        private void timerCheckSendIsSuccess_Tick(object sender, System.EventArgs e)
        {
            //if (currUserInfo != null)
            //{
            //    OutTime++;
            //    if (OutTime == 50 && !currUserInfo.SendIsSuccess)//如果消息没有发送成功
            //    {
            //        //在对话框里给提示
            //        //MessageBox.Show("消息发送不成功(原因可能是对方已经脱机或网络出现故障)。","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //        //EnBut(true);//启用发送功能
            //        this.RTBSend.Focus();
            //    }
            //    if (currUserInfo.SendIsSuccess)//如果消息发送成功 
            //    {
            //        if (this.RTBSend.Text != "")
            //        {
            //            //记录消息记录
            //            //this.FormMain.formMain.MsgAddToDB(this.SendTextMsg.MsgContent, this.FormMain.formMain.selfInfo.ID, currUserInfo.ID, this.FormMain.formMain.selfInfo.AssemblyVersion, System.DateTime.Now.ToString(), this.SendTextMsg.ImageInfo, true);
            //            //将消息添加进数据库
            //        }
            //    }
            //}
        }


        public string FormID
        {
            get { return friend.ID; }
        }


        public Form CurrentForm
        {
            get
            {
                return this;
            }
            set
            {

            }
        }

        public void ShowOtherTextChat(string userID, List<MsgEntity> msgList)
        {
            if (msgList.Count > 0)
            {

                foreach (MsgEntity msg in msgList)
                {
                    chatControl1.ReciveMessage(msg);


                    IList<ImageWrapper> theImageList = msg.ImageList;

                    foreach (ImageWrapper imageWrapper in theImageList)
                    {
                        //显示图片
                        //chatControl1.ShowImage(imageWrapper.ImageName, imageWrapper.Image);

                    }


                }

            }
        }

        //控件中的图片字典
        public Dictionary<string, Image> imageDict = null;
        //图片包装类的列表
        IList<ImageWrapper> imageWrapperList = new List<ImageWrapper>();

        private void chatControl1_BeginToSend(string content, MsgType msgType = MsgType.文字, MsgSendType sendType = MsgSendType.基本消息)
        {
            //imageDict = this.chatControl1.imageDict;

            ////把控件中的图片字典，添加到图片包装类列表中
            //foreach (KeyValuePair<string, Image> kv in imageDict)
            //{
            //    ImageWrapper newWrapper = new ImageWrapper(kv.Key, kv.Value);

            //    imageWrapperList.Add(newWrapper);

            //} 
            Common.SendMsg(content, msgType, sendType, friend.ID, friend.DisplayName);

            this.chatControl1.Focus();
            imageWrapperList.Clear();
        }

        private void frmchatMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

    }
}

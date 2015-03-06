//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;

namespace WIMClient
{
    [ToolboxItem(false)]
    public class User:Label
    {
        
        public User(string ID, string Name, string Underwrite, UserSex Sex, Bitmap Head, string Mobile, string Email)
        {
            //样式控制
            base.AutoSize = false;
            base.Text = string.Empty;
            base.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            base.BackColor = Color.White;

            //屏闭系统绘制
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.DoubleBuffered = true;

            //初始化
            this.userID = ID;
            this.userName = Name;
            this.Underwrite = "(" + Underwrite + ")";
            this.sex = Sex;
            this.head = Head;
            this.mobile = Mobile;
            this.email = Email;
            this.state = OnlineState.Offline;

            this.ForeColor = Color.FromArgb(40, 40, 40);

            //头像跳动
            this.headTimer = new System.Timers.Timer();
            this.headTimer.Interval = 300;
            this.headTimer.Elapsed += delegate
            {
                if (this.headToRight)
                {
                    this.headX += 2;
                    if (this.headX == 6)
                        this.headToRight = false;
                }
                else
                {
                    this.headX -= 2;
                    if (this.headX == 2)
                        this.headToRight = true;
                }
                this.headY = this.headX == 4 ? 3 : 5;
                this.Invalidate(new Rectangle(0, 0, 34, 34));
            };

            this.Messages = new UserMessage();

            this.Messages.CountChanged += delegate
            {
                if (this.Messages.Count == 0)
                {
                    this.headTimer.Enabled = false;
                    this.headX = this.headY = 4;
                    this.Invalidate(new Rectangle(0, 0, 34, 34));
                }
                else
                {
                    this.headTimer.Enabled = true;
                }
            };

            //提示
            this.toolTip = new ToolTip();
            this.toolTip.UseAnimation = true;
            this.toolTip.UseFading = true;
            this.toolTip.ShowAlways = true;

            //设置可用工具
            this.toolList = new List<ToolSwitch>();
            this.toolList.Add(ToolSwitch.IM_Chat);
            this.toolList.Add(ToolSwitch.IM_Speech);
            if (this.Mobile != null && this.Mobile.Trim().Length > 0) this.toolList.Add(ToolSwitch.IM_Message);
            if (this.Email != null && this.Email.Trim().Length > 0) this.toolList.Add(ToolSwitch.IM_Email);           
        }

        public User(string ID, string Name, string Underwrite, UserSex Sex, Bitmap Head, string Mobile, string Email,OnlineState  onlineState)
        {
            //样式控制
            base.AutoSize = false;
            base.Text = string.Empty;
            base.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            base.BackColor = Color.White;

            //屏闭系统绘制
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.DoubleBuffered = true;

            //初始化
            this.userID = ID;
            this.userName = Name;
            this.Underwrite = "(" + Underwrite + ")";
            this.sex = Sex;
            this.head = Head;
            this.mobile = Mobile;
            this.email = Email;
            this.state = onlineState;

            this.ForeColor = Color.FromArgb(40, 40, 40);

            //头像跳动
            this.headTimer = new System.Timers.Timer();
            this.headTimer.Interval = 300;
            this.headTimer.Elapsed += delegate
            {
                if (this.headToRight)
                {
                    this.headX += 2;
                    if (this.headX == 6)
                        this.headToRight = false;
                }
                else
                {
                    this.headX -= 2;
                    if (this.headX == 2)
                        this.headToRight = true;
                }
                this.headY = this.headX == 4 ? 3 : 5;
                this.Invalidate(new Rectangle(0, 0, 34, 34));
            };

            this.Messages = new UserMessage();

            this.Messages.CountChanged += delegate
            {
                if (this.Messages.Count == 0)
                {
                    this.headTimer.Enabled = false;
                    this.headX = this.headY = 4;
                    this.Invalidate(new Rectangle(0, 0, 34, 34));
                }
                else
                {
                    this.headTimer.Enabled = true;
                }
            };

            //提示
            this.toolTip = new ToolTip();
            this.toolTip.UseAnimation = true;
            this.toolTip.UseFading = true;
            this.toolTip.ShowAlways = true;

            //设置可用工具
            this.toolList = new List<ToolSwitch>();
            this.toolList.Add(ToolSwitch.IM_Chat);
            this.toolList.Add(ToolSwitch.IM_Speech);
            if (this.Mobile != null && this.Mobile.Trim().Length > 0) this.toolList.Add(ToolSwitch.IM_Message);
            if (this.Email != null && this.Email.Trim().Length > 0) this.toolList.Add(ToolSwitch.IM_Email);
        }
         
        //样式控制
        public new bool AutoSize { get { return false; } }
        public new string Text { get { return string.Empty; } }
        public new AnchorStyles Anchor { get { return AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right; } }

        System.Timers.Timer headTimer;
        int headX = 4, headY = 4;
        bool headToRight;
        ToolTip toolTip;

        private FormManager< ChatForm> FormManager = null;

        #region 属性
        string currentUserID;

        public string CurrentUserID { get { return this.currentUserID; } }

        string userID;
        public string UserID { get { return this.userID; } }
        string userName;
        public string UserName { get { return this.userName; } }
        public string Underwrite { get; set; }
        Bitmap grayHead;
        Bitmap head;
        public Bitmap Head
        {
            get
            {
                if (this.head == null)//如果没有设置头像，则使用默认头像
                    this.head = Properties.Resources.User_Default;

                if ((this.userID.Trim().ToLower() != Common.ClientUser.UserID.Trim().ToLower() && this.state == OnlineState.Hide)
                    ||
                    this.state == OnlineState.Offline)//如果不是本人的隐身或离线，显示灰度头像
                {
                    if (this.grayHead == null)//如果灰度头象未生成，进行灰度转阵
                    {
                        ImageAttributes imageAttributes = new ImageAttributes();
                        float[][] matrix = { new float[] {0.299f, 0.299f, 0.299f, 0, 0},
                                             new float[]   {0.587f,   0.587f,   0.587f,   0,   0}, 
                                             new float[]   {0.114f,   0.114f,   0.114f,   0,   0},
                                             new float[]   {0,   0,   0,   1,   0},                   
                                             new float[]   {0,   0,   0,   0,   1}
                                   };
                        ColorMatrix colorMatrix = new ColorMatrix(matrix);
                        imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                        this.grayHead = new Bitmap(this.head.Width, this.head.Height);
                        Graphics g = Graphics.FromImage(this.grayHead);
                        g.DrawImage(this.head, new Rectangle(0, 0, this.head.Width, this.head.Height), 0, 0, this.head.Width, this.head.Height, GraphicsUnit.Pixel, imageAttributes);
                        g.Dispose();
                    }

                    return this.grayHead;
                }
                else
                    return this.head;
            }
            set { this.head = value; }
        }
        
        UserSex sex;
        public UserSex Sex { get { return this.sex; } }
        string mobile;
        public string Mobile { get { return this.mobile; } }
        string email;
        public string Email { get { return this.email; } }
        OnlineState state;
        public OnlineState State 
        { 
            get { return this.state; }
            set
            {
                if (this.state != value)
                {                    
                    //上线闪烁
                    if ((this.state == OnlineState.Offline || this.state == OnlineState.Hide) && value == OnlineState.Online)
                    {
                        Random rand = new Random();

                        int times = 10;
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 400;
                        timer.Elapsed += delegate
                        {
                            this.ForeColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                            times--;

                            if (times <= 0)
                            {
                                timer.Enabled = false;
                                this.ForeColor = Color.FromArgb(40, 40, 40);
                            }
                            this.Invalidate(new Rectangle(36, 4, this.Width - 36, 16));
                        };
                        timer.Enabled = true;
                    }
                   
                    if (this.OnlineStateChanged != null)
                        this.OnlineStateChanged(this, this.state, value);

                    this.state = value;
                    this.Invalidate();
                }
            }
        }
        public UserMessage Messages { get; set; }
        public Group Group { get; set; }
        #endregion

        #region 状态改变事件
        public delegate void OnlineStateChangedHandler(User sender, OnlineState oldState, OnlineState newState);
        public event OnlineStateChangedHandler OnlineStateChanged;
        #endregion

        #region 绘制
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            this.drawBorder(e.Graphics);
            this.drawHead(e.Graphics);
            this.drawNameAndState(e.Graphics);
            this.drawTools(e.Graphics);
        }

        void drawBorder(Graphics g)
        {
            if (this.mouseOn || (this.ContextMenuStrip != null && this.ContextMenuStrip.Visible))
            {
                Rectangle rect = new Rectangle(0, 0, 33, 33);
                g.DrawRectangle(this.Sex == UserSex.Male ? new Pen(Color.FromArgb(197, 227, 249)) : new Pen(Color.FromArgb(248, 195, 248)), rect);
            }
        }

        void drawHead(Graphics g)
        {
            if (!this.Visible)
                return;

            Rectangle imgRect = new Rectangle(this.headX, this.headY, 17, 17);
            g.DrawImage(this.Head, imgRect);

            Rectangle rect = new Rectangle(18 + this.headX - 4, 18 + this.headY - 4, 16, 16);
            if (this.state == OnlineState.Away)
                g.DrawImage(Properties.Resources.State_Away, rect);
            else if (this.state == OnlineState.Busy)
                g.DrawImage(Properties.Resources.State_Busy, rect);
            else if (this.state == OnlineState.Quiet)
                g.DrawImage(Properties.Resources.State_Quiet, rect);
            else if (this.state == OnlineState.Hide && this.userID == Common.ClientUser.UserID)
                g.DrawImage(Properties.Resources.State_Hide, rect);
        }

        void drawNameAndState(Graphics g)
        {
            Pen pen = new Pen(Color.FromArgb(80, 80, 80));
            Brush brush = pen.Brush;
            g.DrawString(this.UserName + this.stateToText(), this.Font, brush, 36, 4);
            if (!this.mouseOn)
                g.DrawString(this.Underwrite, this.Font, brush, 36, 18);
            g.DrawString(this.UserName, this.Font, new Pen(this.ForeColor).Brush, 36, 4);

            brush.Dispose();
            pen.Dispose();
        }

        string stateToText()
        {
            switch (this.state)
            {
                case OnlineState.Online:
                    return "[在线]";
                case OnlineState.Busy:
                    return "[忙碌]";
                case OnlineState.Away:
                    return "[离开]";
                case OnlineState.Quiet:
                    return "[静音]";
                case OnlineState.Hide:
                    return "[离线]";
                case OnlineState.Offline:
                    return "[离线]";
                default:
                    return "[离线]";
            }
        }

        void drawTools(Graphics g)
        {
            if (!this.mouseOn)
                return;

            for (int i = 0, left = 38; i < this.toolList.Count; i++, left += 20)
            {
                Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(this.toolList[i].ToString());
                g.DrawImage(img, left, (this.toolSwitch == this.toolList[i] ? 17 : 19), 13, 13);

                img.Dispose();
            }
        }
        #endregion
        
        #region 指示当前鼠标指中的工具，并显示提示文字
        ToolSwitch toolswitch;
        ToolSwitch toolSwitch
        {
            get { return this.toolswitch; }
            set
            {
                if (this.toolswitch != value)
                {
                    this.toolswitch = value;

                    switch (this.toolswitch)
                    {
                        case ToolSwitch.Null:
                            this.toolTip.Hide(this);
                            break;
                        case ToolSwitch.IM_Chat:
                            this.toolTip.Show("发起会话", this, PointToClient(new Point(MousePosition.X, MousePosition.Y + 26)));
                            break;
                        case ToolSwitch.IM_Speech:
                            this.toolTip.Show("语言聊天", this, PointToClient(new Point(MousePosition.X, MousePosition.Y + 26)));
                            break;
                        case ToolSwitch.IM_Message:
                            this.toolTip.Show("发送短信", this, PointToClient(new Point(MousePosition.X, MousePosition.Y + 26)));
                            break;
                        case ToolSwitch.IM_Email:
                            this.toolTip.Show("发送邮件", this, PointToClient(new Point(MousePosition.X, MousePosition.Y + 26)));
                            break;                        
                        default:
                            break;
                    }
                }
            }
        }
        enum ToolSwitch
        {
            Null,
            IM_Chat,
            IM_Speech,            
            IM_Message,
            IM_Email            
        }
        #endregion

        #region 背景颜色控制
        bool mouseOn = false;
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            this.mouseOn = true;
            this.BackColor = this.Sex == UserSex.Male ? Color.FromArgb(230, 245, 255) : Color.FromArgb(249, 227, 227);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.ContextMenuStrip == null || !this.ContextMenuStrip.Visible)
            {
                this.mouseOn = false;
                this.BackColor = Color.White;
                this.toolSwitch = ToolSwitch.Null;
            }
        }
        #endregion

        #region 拖放
        int dropX = 0, dropY = 0;
        bool beginDrop = false;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                this.dropX = e.X;
                this.dropY = e.Y;
                this.beginDrop = true;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            this.beginDrop = false;
        }
        #endregion

        #region 工具栏
        List<ToolSwitch> toolList;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left && this.beginDrop)
            {
                if (Math.Abs(e.X - this.dropX) > 20 || Math.Abs(e.Y - this.dropY) > 20)
                    this.DoDragDrop(this, DragDropEffects.Move);
                return;
            }

            if (e.X < this.Height + 2 || e.Y < this.Height - 20 || this.toolList == null || e.X > this.Height + 2 + (20 * this.toolList.Count))//不在工具栏区域
            {
                if (this.toolSwitch != ToolSwitch.Null)
                {
                    this.toolSwitch = ToolSwitch.Null;
                    this.Invalidate();
                }
                return;
            }

            if (e.X >= this.Height + 2 && e.X <= this.Height + 2 + 13)
                this.toolSwitch = this.toolList[0];
            else if (e.X >= this.Height + 2 + 20 && e.X <= this.Height + 2 + 20 + 13)
                this.toolSwitch = this.toolList[1];
            else if (e.X >= this.Height + 2 + 40 && e.X <= this.Height + 2 + 40 + 13 && this.toolList.Count > 2)
                this.toolSwitch = this.toolList[2];
            else if (e.X > this.Height + 2 + 60 && e.X <= this.Height + 2 + 60 + 13 && this.toolList.Count > 3)
                this.toolSwitch = this.toolList[3];         
            else
                this.toolSwitch = ToolSwitch.Null;

            this.Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            this.Focus();

            switch (this.toolswitch)
            {
                case ToolSwitch.Null:
                    break;
                case ToolSwitch.IM_Chat:
                    this.OnDoubleClick(null);
                    break;
                case ToolSwitch.IM_Speech:
                    break;
                case ToolSwitch.IM_Message:
                    break;
                case ToolSwitch.IM_Email:
                    break;                
                default:
                    break;
            }
        }
        #endregion

        #region 菜单影响
        protected override void OnContextMenuStripChanged(EventArgs e)
        {
            base.OnContextMenuStripChanged(e);

            if (this.ContextMenuStrip != null)
                this.ContextMenuStrip.Closed += delegate
                {
                    this.mouseOn = false;
                    this.BackColor = Color.White;
                    this.toolSwitch = ToolSwitch.Null;
                };
        }
        #endregion

        protected override void OnDoubleClick(EventArgs e)
        {
            ShowChatForm();
        }

        public void ShowChatForm()
        {
           

            //ChatForm form = this.FormManager.GetForm(this.userID);
            //if (form == null)
            //{
            //    form = new ChatForm(currentUserID,userID);
            //    this.FormManager.Add(form);
            //    form.Show();
            //}
            //form.Focus();


            ChatForm form = Common.ChatFormManager.GetForm(this.userID);

            if (form == null)
            {
                form = new ChatForm(Common.UserID,userID);
                Common.ChatFormManager.Add(form);


                form.Show();

                //form.ShowOtherTextChat(this.userID, this.Messages);

                if (Common.ContainsUserID(userID))
                {
                    form.ShowOtherTextChat(this.userID, Common.MsgContractList(userID));
                    Common.RemoveID(userID);
                    Common.RemoveMsg(userID);
                    this.Messages.Clear();
                }
            }
            else
            {

                form.Focus();

                if (Common.ContainsUserID(userID))
                {
                    form.ShowOtherTextChat(this.userID, Common.MsgContractList(userID));
                    Common.RemoveID(userID);
                    Common.RemoveMsg(userID);
                    this.Messages.Clear();
                }

            }

        }

        public User Clone()
        {
            return new User(this.userID, this.userName, this.Underwrite, this.sex, this.head, this.mobile, this.email);
        }
    }
}

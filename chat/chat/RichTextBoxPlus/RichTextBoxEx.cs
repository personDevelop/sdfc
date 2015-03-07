using System;
using System.Collections.Generic;
 
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.ComponentModel; 

namespace ChatClient
{
    public class RichTextBoxEx : RichTextBox
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int message, IntPtr wParam, IntPtr lParam);
        [DllImport("User32.dll", CharSet = CharSet.Auto, PreserveSig = false)]
        internal static extern IRichEditOle SendMessage(IntPtr hWnd, int message, int wParam);

        [StructLayout(LayoutKind.Sequential)]
        private struct CHARFORMAT2_STRUCT
        {
            public UInt32 cbSize;
            public UInt32 dwMask;
            public UInt32 dwEffects;
            public Int32 yHeight;
            public Int32 yOffset;
            public Int32 crTextColor;
            public byte bCharSet;
            public byte bPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public char[] szFaceName;
            public UInt16 wWeight;
            public UInt16 sSpacing;
            public int crBackColor;
            public int lcid;
            public int dwReserved;
            public Int16 sStyle;
            public Int16 wKerning;
            public byte bUnderlineType;
            public byte bAnimation;
            public byte bRevAuthor;
            public byte bReserved1;
        }

        private const int WM_USER = 0x0400;
        private const int EM_GETCHARFORMAT = WM_USER + 58;
        private const int EM_SETCHARFORMAT = WM_USER + 68;
        private const int SCF_SELECTION = 0x0001;
        private const UInt32 CFE_LINK = 0x0020;
        private const UInt32 CFM_LINK = 0x00000020;


        IRichEditOle _richEditOle = null;
        IRichEditOle richEditOle
        {
            get
            {
                if (this._richEditOle == null)
                {
                    IntPtr ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(IntPtr)));
                    IntPtr richEditOleIntPtr = IntPtr.Zero;
                    Marshal.WriteIntPtr(ptr, IntPtr.Zero);
                    try
                    {
                        int msgResult = SendMessage(this.Handle, RichEditOle.EM_GETOLEINTERFACE, IntPtr.Zero, ptr);
                        if (msgResult != 0)
                        {
                            IntPtr intPtr = Marshal.ReadIntPtr(ptr);
                            try
                            {
                                if (intPtr != IntPtr.Zero)
                                {
                                    Guid guid = new Guid("00020D00-0000-0000-c000-000000000046");
                                    Marshal.QueryInterface(intPtr, ref guid, out richEditOleIntPtr);

                                    this._richEditOle = (IRichEditOle)Marshal.GetTypedObjectForIUnknown(richEditOleIntPtr, typeof(IRichEditOle));
                                }
                            }
                            finally
                            {
                                Marshal.Release(intPtr);
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        Trace.WriteLine(err.ToString());
                    }
                    finally
                    {
                        Marshal.FreeCoTaskMem(ptr);
                    }
                }
                return this._richEditOle;
            }
        }

        class RichEditOle
        {
            [DllImport("ole32.dll", PreserveSig = false)]
            static extern int CreateILockBytesOnHGlobal(IntPtr hGlobal, bool fDeleteOnRelease, [Out] out ILockBytes ppLkbyt);
            [DllImport("ole32.dll")]
            static extern int StgCreateDocfileOnILockBytes(ILockBytes plkbyt, uint grfMode, uint reserved, out IStorage ppstgOpen);

            public const int EM_GETOLEINTERFACE = 0x0400 + 60;

            private RichTextBoxEx richTextBox;
            private IRichEditOle ole;

            internal RichEditOle(RichTextBoxEx richEdit)
            {
                this.richTextBox = richEdit;
                this.ole = SendMessage(this.richTextBox.Handle, EM_GETOLEINTERFACE, 0);
            }

            internal void InsertControl(MyGIF gif)
            {
                if (gif == null)
                    return;

                Guid guid = Marshal.GenerateGuidForType(gif.Box.GetType());

                ILockBytes lockBytes;
                CreateILockBytesOnHGlobal(IntPtr.Zero, true, out lockBytes);

                IStorage storage;
                StgCreateDocfileOnILockBytes(lockBytes, (uint)(STGM.STGM_SHARE_EXCLUSIVE | STGM.STGM_CREATE | STGM.STGM_READWRITE), 0, out storage);

                IOleClientSite oleClientSite;
                this.ole.GetClientSite(out oleClientSite);

                REOBJECT reObject = new REOBJECT()
                {
                    cp = this.richTextBox.SelectionStart,
                    clsid = guid,
                    pstg = storage,
                    poleobj = Marshal.GetIUnknownForObject(gif.Box),
                    polesite = oleClientSite,
                    dvAspect = (uint)(DVASPECT.DVASPECT_CONTENT),
                    dwFlags = (uint)0x00000002,
                };

                try
                {
                    reObject.dwUser = gif.Index;
                }
                catch { }

                this.ole.InsertObject(reObject);

                Marshal.ReleaseComObject(lockBytes);
                Marshal.ReleaseComObject(oleClientSite);
                Marshal.ReleaseComObject(storage);
            }
        }


        public RichTextBoxEx()
            : base()
        {
            base.BorderStyle = BorderStyle.FixedSingle;
            this.DetectUrls = false;
        }

        public new bool ReadOnly { get; set; }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0100:
                    if (this.ReadOnly)
                        return;
                    break;
                case 0X0102:
                    if (this.ReadOnly)
                        return;
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }

        List<MyGIF> gifList = new List<MyGIF>();
        Panel gifPanel = new Panel();

        [DefaultValue(false)]
        public new bool DetectUrls
        {
            get { return base.DetectUrls; }
            set { base.DetectUrls = value; }
        }


        public void ClearGif()
        {
            this.gifPanel.Controls.Clear();
            this.gifList.Clear();
        }

        public void InsertGIF(string Name, Image Data)
        {
            
            MyGIF gif = new MyGIF(Name, Data);
            gif.Box.Invalidate();
            this.gifPanel.Controls.Add(gif.Box);
            this.gifList.Add(gif);

            RichEditOle ole = new RichEditOle(this);
            ole.InsertControl(gif);

           
            this.Invalidate();

          
        }

        public string GetGIFInfo()
        {
            string imageInfo = "";
            REOBJECT reObject = new REOBJECT();
            for (int i = 0; i < this.richEditOle.GetObjectCount(); i++)
            {
                this.richEditOle.GetObject(i, reObject, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES);
                MyGIF gif = this.gifList.Find(p => p != null && p.Index == reObject.dwUser);
                if (gif != null)
                {
                    imageInfo += reObject.cp.ToString() + ":" + gif.Name + "|";
                }
            }
            return imageInfo;
        }

        public void InsertLink(string text, string hyperlink)
        {
            int position = this.SelectionStart;

            this.SelectionStart = position;
            this.SelectedRtf = @"{\rtf1\ansi " + text + @"\v #" + hyperlink + @"\v0}";
            this.Select(position, text.Length + hyperlink.Length + 1);
            this.SetSelectionStyle();
            this.Select(position + text.Length + hyperlink.Length + 1, 0);
        }

        private void SetSelectionStyle()
        {
            CHARFORMAT2_STRUCT cf = new CHARFORMAT2_STRUCT();
            cf.cbSize = (UInt32)Marshal.SizeOf(cf);
            cf.dwMask = CFM_LINK;
            cf.dwEffects = CFE_LINK;

            IntPtr wpar = new IntPtr(SCF_SELECTION);
            IntPtr lpar = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
            Marshal.StructureToPtr(cf, lpar, false);

            IntPtr res = (IntPtr)SendMessage(Handle, EM_SETCHARFORMAT, wpar, lpar);

            Marshal.FreeCoTaskMem(lpar);
        }

        public void SetFont(string Name, bool Bold, bool Italic, bool Underline, Color Color, float Size)
        {
            FontStyle style = FontStyle.Regular;
            if (Bold) style |= FontStyle.Bold;
            if (Italic) style |= FontStyle.Italic;
            if (Underline) style |= FontStyle.Underline;

            this.Font = new Font(Name, Size, style);
            this.ForeColor = Color;
        }

        public string GetTextToSend()
        {
            string value = string.Empty;
            value += "\\n" + this.Font.Name;
            value += "\\b" + (this.Font.Bold ? "1" : "0");
            value += "\\i" + (this.Font.Italic ? "1" : "0");
            value += "\\u" + (this.Font.Underline ? "1" : "0");
            value += "\\s" + this.Font.Size.ToString();
            value += "\\c" + ColorTranslator.ToHtml(this.ForeColor);
            value += "\\t" + this.Text;
            value += "\\p" + this.GetGIFInfo();

            return value;
        }

        public void AppentMessage(string UserName, DateTime SendTime, bool Self, string Content)
        {
            int start = this.SelectionStart;

            string anthor = " " + UserName + " " + SendTime.Hour.ToString() + ":" + SendTime.Minute + ":" + SendTime.Second + "\r\n    ";
            this.AppendText(anthor);

            this.SelectionStart = start + 1;
            this.SelectionLength = anthor.Length - 5;
            this.SelectionColor = Self ? Color.FromArgb(0, 128, 64) : Color.Blue;
            this.SelectionFont = this.Font;
            this.SelectionStart = this.TextLength;
            start = this.SelectionStart;

            try
            {
                int index_b = Content.IndexOf("\\b");
                int index_i = Content.IndexOf("\\i");
                int index_u = Content.IndexOf("\\u");
                int index_s = Content.IndexOf("\\s");
                int index_c = Content.IndexOf("\\c");
                int index_t = Content.IndexOf("\\t");
                int index_p = Content.LastIndexOf("\\p");

                string name = Content.Substring(2, index_b - 2);
                bool bold = Content.Substring(index_b + 2, 1) == "1" ? true : false;
                bool italic = Content.Substring(index_i + 2, 1) == "1" ? true : false;
                bool underline = Content.Substring(index_u + 2, 1) == "1" ? true : false;
                float size = float.Parse(Content.Substring(index_s + 2, index_c - index_s - 2));
                Color color = ColorTranslator.FromHtml(Content.Substring(index_c + 2, index_t - index_c - 2));
                string text = Content.Substring(index_t + 2, index_p - index_t - 2);
                string gif = Content.Substring(index_p + 2, Content.Length - index_p - 2);

                FontStyle style = FontStyle.Regular;
                if (bold) style |= FontStyle.Bold;
                if (italic) style |= FontStyle.Italic;
                if (underline) style |= FontStyle.Underline;
                Font font = new Font(name, size, style);

                int oldPos = 0;
                if (gif.Trim().Length > 0)
                {
                    string[] gifPos = gif.Split('|');
                    for (int i = 0; i < gifPos.Length; i++)
                    {
                        if (gifPos[i].Trim().Length == 0)
                            break;

                        this.SelectionStart = this.TextLength - 1;
                        int index = gifPos[i].IndexOf(':');
                        int pos = int.Parse(gifPos[i].Substring(0, index));
                        string subString = text.Substring(oldPos, pos - oldPos);
                        oldPos = pos + 1;
                        this.AppendText(subString);

                        string gifName = gifPos[i].Substring(index + 1, gifPos[i].Length - index - 1);
                        this.InsertGIF(gifName, (Image)Properties.Resources.ResourceManager.GetObject(gifName));
                    }
                }

                string lastString = text.Substring(oldPos, text.Length - oldPos);
                this.AppendText(lastString);

                this.SelectionStart = start;
                this.SelectionLength = text.Length;
                this.SelectionFont = font;
                this.SelectionColor = color;

                this.AppendText("\r\n");
                this.SelectionStart = this.TextLength;
            }
            catch
            {
                this.AppendText(Content);
                this.AppendText("\r\n");
                this.SelectionStart = this.TextLength;
            }
        }
    }
}

//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text; 
using IMInterface;

namespace WIMClient
{
    public class UserMessage : List<MsgEntity>
    {
        public void Add(MsgEntity Content)
        {
            base.Add(Content);

            if (this.CountChanged != null)
                this.CountChanged();

            new System.Media.SoundPlayer(Properties.Resources.Sound_Msg).Play();
        }

        public new void Clear()
        {
            base.Clear();

            if (this.CountChanged != null)
                this.CountChanged();
        }

        public delegate void CountChangedHandler();
        public event CountChangedHandler CountChanged;

    }
}

//www.networkcomms.cn  www.networkcomms.net
using System;
using System.Collections.Generic;
using System.Text;

namespace WIMClient
{
     


    public class ExceptionEventArgs : EventArgs
    {

        public Exception TheException { get; set; }

        public ExceptionEventArgs(Exception theException)
        {
            this.TheException = theException;
        }
    }


    public class FormIDEventArgs : EventArgs
    {
        public FormIDEventArgs(string text)
        {
            Text = text;
        }
        public string Text { get; set; }

    }

}

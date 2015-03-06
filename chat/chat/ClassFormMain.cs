using System;

namespace chat
{
	/// <summary>
	/// ClassMain 的摘要说明。
	/// </summary>
	public class ClassFormMain 
	{
        private static main f = null;
        private static Form1 login = null;

		public  ClassFormMain()
		{
		}

		private static string conStr="";
		public string ConStr 
		{
			get{return conStr;}
			set{conStr=value;}
		}

        public main formMain
		{
			get{return f;}
			set{f=value;}
		}

		public Form1 formLogin
		{
			get{return login;}
			set{login=value;}
		}
	}
}

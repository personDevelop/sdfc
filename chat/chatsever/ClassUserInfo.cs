using System;
using System.ComponentModel;
using System.Net;

namespace chat
{
	/// <summary>
	/// ClassUserInfo ��ժҪ˵����
	/// </summary>
	[Serializable] 
	public class ClassUserInfo
	{

		public ClassUserInfo()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		[NonSerialized]
		public bool SendIsSuccess=false;//��ʶ���͸�����ϵ�˵������Ƿ�ɹ�

		[NonSerialized]
		private System.Windows.Forms.TreeNode node;
		public System.Windows.Forms.TreeNode Node
		{
			get{return node;}
			set{node=value;}
		}

        private string assemblyVersion="1.0.0.1";
		public string AssemblyVersion
		{
			get{return assemblyVersion;}
			set{assemblyVersion=value;}
		}

		private string userName="";
		public string UserName
		{
			get{return userName;}
			set{userName=value;}
		}

        private string userid = "";
        public string Userid
        {
            get { return userid; }
            set { userid = value; }
        }

		private IPAddress Ip=IPAddress.Parse("127.0.0.1");
		public IPAddress IP
		{
			get{return Ip;}
			set{Ip=value;}
		}

		private int port=0;
		public int Port
		{
			get{return port;}
			set{port=value;}
		}

		private string ComputerName="";
		public string ID
		{
			get{return ComputerName;}
			set{ComputerName=value;}
		}


		[NonSerialized]
		private string stateInfo ="(�ѻ�)";
		public string StateInfo
		{
			get{return stateInfo;}
		}

		private int state=0;
		public int State
		{
			get{return state;}
			set
			{
				state=value;
				switch(state)
				{
					case 0:
						stateInfo ="(�ѻ�)";
						break;
					case 1:
						stateInfo ="(����)";
						break;
					case 2:
						stateInfo ="(æµ)";
						break;
					case 3:
						stateInfo ="(�뿪)";
						break;
					case 4:
						stateInfo ="(�����绰)";
						break;
					case 5:
						stateInfo ="(����Ͳ�)";
						break;
				}
			}
		}

		private int dep=10;
		public int Dep  
		{
			get{return dep;}
			set
			{
				dep=value;
				switch(dep)
				{
					case 0:
						depInfo ="����";
						break;
					case 1:
						depInfo ="����";
						break;
					case 2:
						depInfo ="����";
						break;
					case 3:
						depInfo ="����";
						break;
					case 4:
						depInfo ="����";
						break;
					case 5:
						depInfo ="����";
						break;
					case 6:
						depInfo ="����";
						break;
					case 7:
						depInfo ="����";
						break;
					case 8:
						depInfo ="����";
						break;
					case 9:
						depInfo ="����";
						break;
					case 10:
						depInfo ="δ֪";
						break;
				}
			}
		}

		[NonSerialized]
		private string depInfo="";
		public string DepInfo  
		{
			get{return depInfo;}
		}
		

		//		[NonSerialized]
		//		private int old=0;
		//     	public int ����  
		//		{
		//			get{return old;}
		//			set{old=value;}
		//		}
		//
		//		[NonSerialized]
		//		private string business="";
		//		public string ְ��  
		//		{
		//			get{return business;}
		//			set{business=value;}
		//		}
		//
		//		[NonSerialized]
		//		private string sex="";
		//		public string �Ա�  
		//		{
		//			get{return sex;}
		//			set{sex=value;}
		//		}

	}
}

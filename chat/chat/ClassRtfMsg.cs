using System;

namespace chat
{
	/// <summary>
	/// ClassMsg ��ժҪ˵����
	/// </summary>
	/// []
	[Serializable]
	public class ClassMsg
	{
		public string ID="";//������Ϣ���û�ID
        public int MsgInfoClass=0;//���͵���Ϣ���(1Ϊ��¼;2Ϊ��������״̬;3.��11��ʾGIFͼƬ
        public byte[] MsgContent=null;//������Ϣ���������л������ɵ��ֽ���������
        public string AssemblyVersion= "1.0.0.1" ;


		public ClassMsg(int msgInfoClass,string id,byte[] msgContent)
		{
		   this.ID=id;
		   this.MsgInfoClass=msgInfoClass;
		   this.MsgContent=msgContent;
           
		}


 	}
}

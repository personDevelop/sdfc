using System;

namespace chat
{
	/// <summary>
	/// ClassUser ��ժҪ˵����
	/// </summary>
	[Serializable] 
	public class ClassUsers: System.Collections.CollectionBase 
	{
		public ClassUsers()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public void add(ClassUserInfo userInfo)
		{
			base.InnerList.Add(userInfo);	
		}

		public void Romove(ClassUserInfo userInfo)
		{
			base.InnerList.Remove (userInfo);
		}
	}
}

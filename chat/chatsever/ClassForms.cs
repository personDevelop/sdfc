using System;

namespace LanMsg.Controls
{
	/// <summary>
	/// ClassForms ��ժҪ˵����
	/// </summary>
	public class ClassForms : System.Collections.CollectionBase 
	{
		public ClassForms()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public void add(System.Windows.Forms.Form f)
		{
			base.InnerList.Add(f);	
		}

		public void Romove(System.Windows.Forms.Form f)
		{
			base.InnerList.Remove (f);
		}
	}


}

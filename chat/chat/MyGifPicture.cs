using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ChatClient 
{
	/// <summary> 
	/// MyPicture ��ժҪ˵����
	/// </summary>
	public class MyPicture : System.Windows.Forms.PictureBox
	{
		/// <summary> 
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MyPicture()
		{
			// �õ����� Windows.Forms ���������������ġ�
			InitializeComponent();
//            this.SizeMode=System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			// TODO: �� InitializeComponent ���ú�����κγ�ʼ��
            
		}

		/// <summary> 
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region �����������ɵĴ���
		/// <summary> 
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭�� 
		/// �޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		private string filename="";//GIFͼƬ�ļ��ľ���·��
		public string FileName
		{
			set{filename=value;}
			get{return filename;}
		}

		public bool IsSent=false;//��ʶ��ͼƬ�Ƿ���Ҫ���͵��Է�,Ĭ�ϲ�����

		public void playGif()
		{
			System.Drawing.ImageAnimator.Animate(this.Image,new System.EventHandler(this.OnFrameChanged));
		}
 
		private void OnFrameChanged(object sender, EventArgs e) 
		{

			//Force a call to the Paint event handler.
			 this.Invalidate();
			//this.Refresh();
		}

	}
}

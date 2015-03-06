using System;
using System.Data.OleDb ;
using System.Data;
using System.ComponentModel;

namespace chat
{
	/// <summary>
	/// ClassOptionData ��ժҪ˵����
	/// </summary>
	public class ClassOptionData  
	{
		private string ConStr= "Provider=SQLOLEDB;Data Source=;User id=;password=;Initial Catalog=;";

		public ClassOptionData()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public int ExSQL(string SQLStr)//ִ���κ�SQL��䣬������Ӱ�������
		{
			try
			{
				OleDbConnection cnn = new OleDbConnection(ConStr);
				OleDbCommand cmd =new OleDbCommand(SQLStr ,cnn);
				cnn.Open ();
				int i =0;
				i=cmd.ExecuteNonQuery();
				cmd.Dispose();
				cnn.Close();
				cnn.Dispose();   
				return i;
			}
			catch(Exception e){return 0;}

		}

		public int ExSQLLengData(object Data,string par,string SQLStr)//ִ���κ�SQL��䣬������Ӱ�������
		{
			try
			{
				OleDbConnection cnn = new OleDbConnection(ConStr);
				OleDbCommand cmd =new OleDbCommand(SQLStr ,cnn);
				cnn.Open ();
				int i =0;
				cmd.Parameters.Add(par, System.Data.OleDb.OleDbType.Binary);
				i=cmd.ExecuteNonQuery();
				cmd.Dispose();
				cnn.Close();
				cnn.Dispose();   
				return i;
			}
			catch(Exception e){return 0;}

		}

		public int ExSQLR(string SQLStr)//ִ���κ�SQL��ѯ��䣬������Ӱ�������
		{
			try
			{
				OleDbConnection cnn = new OleDbConnection(ConStr);
				OleDbCommand cmd =new OleDbCommand(SQLStr ,cnn);
				cnn.Open ();
				OleDbDataReader dr;
				int i =0;
				dr=cmd.ExecuteReader();
				while(dr.Read())
				{i++;}
				cmd.Dispose();
				cnn.Close();
				cnn.Dispose();
				return i;
			}
			catch(Exception e){return 0;}

		}

		public object ExSQLReField(string field ,string SQLStr)//ִ���κ�SQL��ѯ��䣬����һ���ֶ�ֵ
		{
			try
			{
				OleDbConnection cnn = new OleDbConnection(ConStr);
				OleDbCommand cmd =new OleDbCommand(SQLStr ,cnn);
				cnn.Open ();
				OleDbDataReader dr;
				object fieldValue=null;
				dr=cmd.ExecuteReader();
				if(dr.Read())
				{fieldValue=dr[field];}
				cmd.Dispose();
				cnn.Close();
				cnn.Dispose();   
				return fieldValue;
			}
			catch(Exception e){return null;}

		}

		public OleDbDataReader ExSQLReDr(string SQLStr)//ִ���κ�SQL��ѯ��䣬����һ��OleDbDataReader
		{
			try
			{
				OleDbConnection cnn = new OleDbConnection(ConStr);
				OleDbCommand cmd =new OleDbCommand(SQLStr ,cnn);
				cnn.Open ();
				OleDbDataReader dr;
				dr=cmd.ExecuteReader(CommandBehavior.CloseConnection);
				return dr;
			}
			catch(Exception e){return null;}
		}

	}
}

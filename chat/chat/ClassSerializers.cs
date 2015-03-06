using System;
using System.Xml;
using System.IO ;
using System.Xml.Xsl;
using System.Runtime.Serialization.Formatters.Binary;

namespace chat 
{
	/// <summary>
	/// ClassSerializers ��ժҪ˵����
	/// </summary>
	public class ClassSerializers
	{
		public ClassSerializers()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		#region Binary Serializers
		public   System.IO.MemoryStream SerializeBinary(object request) 
		{
			System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			System.IO.MemoryStream memStream = new System.IO.MemoryStream();
			serializer.Serialize(memStream, request);
			return memStream;
		}

		public   object DeSerializeBinary(System.IO.MemoryStream memStream) 
		{
��			memStream.Position=0;
��			System.Runtime.Serialization.Formatters.Binary.BinaryFormatter deserializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
��			object newobj = deserializer.Deserialize(memStream);
��			memStream.Close();
��			return newobj;
		}
		#endregion

		#region XML Serializers

		public   System.IO.MemoryStream SerializeSOAP(object request) 
		{

            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
��          System.IO.MemoryStream memStream = new System.IO.MemoryStream();
��          serializer.Serialize(memStream, request);
��          return memStream;
		}

		public   object DeSerializeSOAP(System.IO.MemoryStream memStream) 
		{
��			object sr;
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter deserializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
��			memStream.Position=0;
��			sr = deserializer.Deserialize(memStream);
��			memStream.Close();
��			return sr;
		}

		#endregion 


	}
}

using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;
using System.Drawing;
using System.IO;
using ProtoBuf;

namespace SimpleIM.Business
{
    [ProtoContract]
   public class ImageWrapper
  {
      /// <summary>
      /// 把Image对象存储为私有的字节数组
      /// </summary>
      [ProtoMember(1)]
      private byte[] _imageData;
   
      /// <summary>
      /// 图片名称
      /// </summary>
      [ProtoMember(2)]
      public string ImageName { get; set; }
   
      /// <summary>
       /// 图片对象
      /// </summary>
      public Image Image { get; set; }
   
      /// <summary>
      /// 私有的无参数构造函数 反序列化时需要使用
      /// </summary>
      private ImageWrapper() { }
   
      /// <summary>
      /// 创建一个新的 ImageWrapper类
      /// </summary>
      /// <param name="imageName"></param>
      /// <param name="image"></param>
      public ImageWrapper(string imageName, Image image)
      {
          this.ImageName = imageName;
          this.Image = image;
      }
   
      /// <summary>
      ///序列化之前，把图片转化为二进制数据
      /// </summary>
      [ProtoBeforeSerialization]
      private void Serialize()
      {
          if (Image != null)
          {
              //We need to decide how to convert our image to its raw binary form here
              using (MemoryStream inputStream = new MemoryStream())
              {
                  //For basic image types the features are part of the .net framework
                  Image.Save(inputStream, Image.RawFormat);
   
                  //If we wanted to include additional data processing here
                  //such as compression, encryption etc we can still use the features provided by NetworkComms.Net
                  //e.g. see DPSManager.GetDataProcessor<LZMACompressor>()
   
                  //Store the binary image data as bytes[]
                  _imageData = inputStream.ToArray();
              }
          }
      }
   
      /// <summary>
      /// 反序列化时，把二进制数据转化为图片对象
      /// </summary>
      [ProtoAfterDeserialization]
      private void Deserialize()
      {
          MemoryStream ms = new MemoryStream(_imageData);
   
          //If we added custom data processes we have the perform the reverse operations here before 
          //trying to recreate the image object
          //e.g. DPSManager.GetDataProcessor<LZMACompressor>()
   
          Image = Image.FromStream(ms);
          _imageData = null;
      }
  }
}

 
////www.networkcomms.cn  www.networkcomms.net

//using System;
//using System.Collections.Generic;
//using System.Text;
//using ProtoBuf;
//using System.ComponentModel;

//namespace SimpleIM.Business
//{
//    /// <summary>
//    /// 传递图片
//    /// </summary>
//    [ProtoContract]
//    public class ImageListContract
//    {
//        [ProtoMember(1)]
//        public IList<ImageWrapper> ImageList { get; set; }

//        //下面这段代码主要是为了防止列表为空，如果列表为空，不加入下面这段代码，序列化会有问题
//        [DefaultValue(false), ProtoMember(2)]
//        private bool IsEmptyList
//        {
//            get { return ImageList != null && ImageList.Count == 0; }
//            set { if (value) { ImageList = new List<ImageWrapper>(); } }
//        }

//        public ImageListContract() { }

//        public ImageListContract(IList<ImageWrapper> imageList)
//        {
//            this.ImageList = imageList;
//        }

  
//    }
//}


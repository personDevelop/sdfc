using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace WIMClient.Skin
{
    public class ResClass
    {
        private static string _SkinFileName = "";
        public static string SkinFilePath = "";
        public static string Pass = "1234";

        public static Bitmap GetImgRes(string name)
        {
            if (name == null || name == "")
                return null;
            //string s1 = Path.GetFileNameWithoutExtension(SkinFileName) + "\\" + name + ".png";
            //if (!File.Exists(SkinFilePath + s1))
            //{
            //    s1 = Path.GetFileNameWithoutExtension(SkinFileName) + "\\" + name + ".bmp";
            //    if (!File.Exists(SkinFilePath + s1))
            //    {
            //        s1 = Path.GetFileNameWithoutExtension(SkinFileName) + "\\" + name + ".jpg";
            //    }
            //}
            //Bitmap bmp = null;
            //try
            //{
            //    bmp = (Bitmap)Bitmap.FromFile(SkinFilePath + s1);
            //}
            //catch (Exception)
            //{
            //    bmp = null;
            //}
            //GC.Collect();
            return (Bitmap)Properties.Resources.ResourceManager.GetObject(name);
        }

        public static Bitmap GetHead(string name)
        {
            if (name == null || name == "")
                name = "big1";
            return (Bitmap)Properties.Resources.ResourceManager.GetObject(name);
        }

        public static string SkinFileName
        {
            get 
            { 
                return _SkinFileName; 
            }
            set 
            {
                if (value != _SkinFileName)
                {
                    ExtractSkin(SkinFilePath, value);
                    _SkinFileName = value;
                }
            }
        }

        private static void ExtractSkin(string saveto, string SkinFileName)
        {
            //if (!Directory.Exists(saveto))
            //{
            //    Directory.CreateDirectory(saveto);
            //}
            //string sfile = SkinFileName;
            //if (File.Exists(sfile))
            //{
            //    FastZip fz = new FastZip();
            //    fz.Password = Pass;
            //    fz.ExtractZip(sfile, saveto + "\\" + Path.GetFileNameWithoutExtension(SkinFileName), "");
            //    fz = null;
            //}
            //else
            //{
            //    SkinFileName = "qq2010.qsf";
            //}
            //GC.Collect();
        }
    }
}

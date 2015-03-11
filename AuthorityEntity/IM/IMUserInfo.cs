using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;
using AuthorityEntity;
using System.Data;

namespace AuthorityEntity.IM
{
    /// <summary>
    ///  即时通讯专用用户表
    /// </summary>  

    [ProtoContract]
    public partial class IMUserInfo
    {


        [ProtoMember(1)]
        public string ID { get; set; }
        [ProtoMember(2)]

        public string Code { get; set; }
        [ProtoMember(3)]
        public string Name { get; set; }
        [ProtoMember(4)]
        public string NickyName { get; set; }
        [ProtoMember(5)]
        public string Signature { get; set; }
        [ProtoMember(6)]
        public string Photo { get; set; }
        [ProtoMember(7)]
        public string Pwd { get; set; }
        [ProtoMember(8)]
        public string Sex { get; set; }
        [ProtoMember(9)]
        public string Birthday { get; set; }
        [ProtoMember(10)]
        public string ContactPhone { get; set; }
        [ProtoMember(11)]
        public string AgentID { get; set; }
        [ProtoMember(12)]
        public string AgentGroup { get; set; }
        [ProtoMember(13)]
        public string ICallPwd { get; set; }
        [ProtoMember(14)]
        public bool IsWebPerson { get; set; }
        [ProtoMember(15)]
        public bool BJDH { get; set; }
        [ProtoMember(16)]
        public string Note { get; set; }
        [ProtoMember(17)]
        public string Email { get; set; }
        [ProtoMember(18)]
        public string QQ { get; set; }
        [ProtoMember(19)]
        public string CompName { get; set; }
        [ProtoMember(20)]
        public string DepartName { get; set; }
        [ProtoMember(21)]
        public string IMGroupName { get; set; }
        [ProtoMember(22)]
        public string DepartID { get; set; }
        [ProtoMember(23)]
        public bool IsWebMsg { get; set; }
        /// <summary>
        /// 获取用户状态
        /// </summary>
        [ProtoMember(23)]
        public int UserState { get; set; }

        /// <summary>
        /// 登录结果
        /// </summary>
        [ProtoMember(24)]
        public string Response { get; set; }


        /// <summary>
        /// 是否在线
        /// </summary>
        [ProtoMember(25)]
        public bool IsOnline { get; set; }

        public string DisplayName
        {

            get
            {
                string name = string.IsNullOrWhiteSpace(NickyName) ? Name : NickyName;
                if (string.IsNullOrWhiteSpace(name))
                {
                    name = "陌生人";
                }
                return name;
            }

        }

        public string DisplaySignature
        {

            get
            {

                return string.IsNullOrWhiteSpace(Signature) ? "沟通从心开始" : Signature;
            }

        }

    }


    public static class ConvertToImUser
    {
        public static IMUserInfo Clone(this View_IMUser imuser)
        {

            IMUserInfo tem = new IMUserInfo();
            tem.ID = imuser.ID;

            tem.Code = imuser.Code;

            tem.Name = imuser.Name;

            tem.NickyName = imuser.NickyName;

            tem.Signature = imuser.Signature;

            tem.Photo = imuser.Photo;

            tem.Pwd = imuser.Pwd;

            tem.Sex = imuser.Sex;
            if (imuser.Birthday.HasValue)
            {
                tem.Birthday = imuser.Birthday.Value.ToString();
            }


            tem.ContactPhone = imuser.ContactPhone;

            tem.AgentID = imuser.AgentID;

            tem.AgentGroup = imuser.AgentGroup;

            tem.ICallPwd = imuser.ICallPwd;

            tem.IsWebPerson = imuser.IsWebPerson;

            tem.BJDH = imuser.BJDH;

            tem.Note = imuser.Note;

            tem.Email = imuser.Email;

            tem.QQ = imuser.QQ;

            tem.CompName = imuser.CompName;

            tem.DepartName = imuser.DepartName;

            tem.IMGroupName = imuser.IMGroupName;
            tem.DepartID = imuser.DepartID;
            /// <summary>
            /// 获取用户状态
            /// </summary>
            tem.UserState = imuser.UserState;
            /// <summary>
            /// 登录结果
            /// </summary>
            tem.Response = imuser.Response;
            /// <summary>
            /// 是否在线
            /// </summary>
            tem.IsOnline = imuser.IsOnline;
            return tem;

        }
        public static IMUserInfo Clone(this IMUserInfo imuser)
        {

            IMUserInfo tem = new IMUserInfo();
            tem.ID = imuser.ID;

            tem.Code = imuser.Code;

            tem.Name = imuser.Name;

            tem.NickyName = imuser.NickyName;

            tem.Signature = imuser.Signature;

            tem.Photo = imuser.Photo;

            tem.Pwd = imuser.Pwd;

            tem.Sex = imuser.Sex;

            tem.Birthday = imuser.Birthday;

            tem.ContactPhone = imuser.ContactPhone;

            tem.AgentID = imuser.AgentID;

            tem.AgentGroup = imuser.AgentGroup;

            tem.ICallPwd = imuser.ICallPwd;

            tem.IsWebPerson = imuser.IsWebPerson;

            tem.BJDH = imuser.BJDH;

            tem.Note = imuser.Note;

            tem.Email = imuser.Email;

            tem.QQ = imuser.QQ;

            tem.CompName = imuser.CompName;

            tem.DepartName = imuser.DepartName;

            tem.IMGroupName = imuser.IMGroupName;
            tem.DepartID = imuser.DepartID;
            /// <summary>
            /// 获取用户状态
            /// </summary>
            tem.UserState = imuser.UserState;
            /// <summary>
            /// 登录结果
            /// </summary>
            tem.Response = imuser.Response;
            /// <summary>
            /// 是否在线
            /// </summary>
            tem.IsOnline = imuser.IsOnline;
            return tem;

        }
        public static List<IMUserInfo> List(this DataTable dt)
        {
            List<IMUserInfo> list = new List<IMUserInfo>();
            foreach (DataRow item in dt.Rows)
            {
                IMUserInfo tem = new IMUserInfo();
                tem.ID = item["ID"] as string;

                tem.Code = item["Code"] as string;

                tem.Name = item["Name"] as string;

                tem.NickyName = item["NickyName"] as string;

                tem.Signature = item["Signature"] as string;

                tem.Photo = item["Photo"] as string;

                tem.Pwd = item["Pwd"] as string;

                tem.Sex = item["Sex"] as string;
                if (item["Birthday"] != DBNull.Value && item["Birthday"] != null)
                {
                    tem.Birthday = item["Birthday"].ToString();
                }

                tem.ContactPhone = item["ContactPhone"] as string;

                tem.AgentID = item["AgentID"] as string;

                tem.AgentGroup = item["AgentGroup"] as string;

                tem.ICallPwd = item["ICallPwd"] as string;


                tem.IsWebPerson = Convert.ToBoolean(item["IsWebPerson"]);

                tem.BJDH = Convert.ToBoolean(item["BJDH"]);

                tem.Note = item["Note"] as string;

                tem.Email = item["Email"] as string;

                tem.QQ = item["QQ"] as string;

                tem.CompName = item["CompName"] as string;

                tem.DepartName = item["DepartName"] as string;

                tem.IMGroupName = item["IMGroupName"] as string;
                tem.DepartID = item["DepartID"] as string;
                ///// <summary>
                ///// 获取用户状态
                ///// </summary>
                //if (item["UserState"]!=DBNull.Value&& item["UserState"]!=null)
                //{
                //    tem.UserState = Convert.ToInt32(item["UserState"]);
                //}

                ///// <summary>
                ///// 登录结果
                ///// </summary>
                //tem.Response = item["Response"] as string;
                ///// <summary>
                ///// 是否在线
                ///// </summary>
                //tem.IsOnline = Convert.ToBoolean(item["IsOnline"]);
                list.Add(tem);
            }

            return list;

        }
    }



}

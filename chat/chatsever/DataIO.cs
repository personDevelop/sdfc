using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;


namespace chat
{
    public class DataIO
    {

        private XmlDocument _userAccount;   //表示用户帐号表的XML文档
 
        private XmlDocument _userFriendList;//表示用户好友列表的XML文档
        private XmlElement _accoRoot;      //Acco的根元素，提升性能
 
        private XmlElement _listRoot;      //List的根元素，提升性能
        private const string _accoFile = "UserAccount";
 
        private const string _listFile = "UserFriendList";

        public DataIO()
        {
            this._userAccount=ReadForFile(_accoFile);
 
            this._userFriendList=ReadForFile(_listFile);
            this._accoRoot = _userAccount.DocumentElement;
          
            this._listRoot = _userFriendList.DocumentElement;
        }

        //读取并且返回xmldocument
        private XmlDocument ReadForFile(string fileName)
        {//从文件读取XML
            if (!File.Exists(fileName))
            {
                string content = "<?xml version='1.0'?>\r\n<" + fileName + " DateTime='" + DateTime.Now.ToString() + "'>\r\n</" + fileName + ">";
                File.AppendAllText(fileName, content);
            }
            XmlDocument xml = new XmlDocument();
            xml.Load(fileName);
            return xml;
        }


        public XmlElement SelectAccount(string account)
        {
            return _accoRoot[account];
        }

        public XmlElement getFriend()
        {
            return _accoRoot;
             
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WIMClient.Skin
{
    public class Friend
    {
        private int _Uin;
        private string _NikeName = null;
        private string _HeadImage = null;
        private bool _isOnline = false;
        private int _state = 0;
        private string _Description = null;
        private bool _isSysHead = false;
        private int _groupID = 0;

        public int Uin
        {
            get
            {
                return _Uin;
            }
            set
            {
                _Uin = value;
            }
        }
        public string NikeName
        {
            get
            {
                return _NikeName;
            }
            set
            {
                _NikeName = value;
            }
        }
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
        public string HeadIMG
        {
            get
            {
                return _HeadImage;
            }
            set
            {
                _HeadImage = value;
            }
        }
        public bool IsSysHead
        {
            get
            {
                return _isSysHead;
            }
            set
            {
                _isSysHead = value;
            }
        }
        public bool IsOnline
        {
            get
            {
                return _isOnline;
            }
            set
            {
                _isOnline = value;
            }
        }
        public int State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                if (_state == 0 || _state == 5)
                    IsOnline = false;
                else
                    IsOnline = true;
            }
        }
        public int GroupID
        {
            get
            {
                return _groupID;
            }
            set
            {
                _groupID = value;
            }
        }
    }
}

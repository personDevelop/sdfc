using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthorityEntity;
using FrameCommonDataAccess;
using FrameCommonEntity;
using System.Data;
using Sharp.Common;
using Sharp.Data;

namespace AuthorityDataAccess
{
    public class MenuInfoDataAccess : Sharp.Data.BaseManager
    {
        public bool Exit(string parentID, string id, string code)
        {
            bool exist = Dal.Exists<MenuInfo>(MenuInfo._.ParentID == parentID &&
                MenuInfo._.ID != id && MenuInfo._.Code == code);
            return exist;
        }

        public int Delete(string classcode)
        {
            ParameterInfoDataAccess paraClient = new ParameterInfoDataAccess();
            ParameterInfo version = paraClient.GetEntity("3eb2fb3d-061b-4c18-b37f-3f84360380f7");//菜单版本 
            version.Value = (int.Parse(version.Value) + 1).ToString();
            // 删菜单，删分配 
            string[] menuIDAry = Dal.From<MenuInfo>().Where(MenuInfo._.ClassCode.StartsWith(classcode)).Select(MenuInfo._.ID).ToSinglePropertyArray();

            SessionFactory dal;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            try
            {
                dal.BeginBatch(50, tr);
                dal.SubmitNew(tr, ref dal, version);
                dal.Delete<MenuInfo>(MenuInfo._.ClassCode.StartsWith(classcode), tr);
                dal.Delete<Permission>(Permission._.MenuID.In(menuIDAry), tr);
                dal.EndBatch(tr);
                dal.CommitTransaction(tr);
                return 1;
            }
            catch (Exception)
            {
                dal.RollbackTransaction(tr);
                throw;
            }


        }



        public System.Data.DataTable GetAllList(string funcid, string parentID)
        {
            return Dal.From<MenuInfo>().Where(MenuInfo._.FuntionID == funcid && MenuInfo._.ParentID == parentID).OrderBy(MenuInfo._.OrderNo).ToDataTable();

        }
        public DataTable GetMenuListByFuncID(string funcid)
        {
            return Dal.From<MenuInfo>().Where(MenuInfo._.FuntionID == funcid).OrderBy(MenuInfo._.OrderNo).ToDataTable();

        }

        public int Save(List<MenuInfo> list)
        {
            ParameterInfoDataAccess paraClient = new ParameterInfoDataAccess();
            ParameterInfo version = paraClient.GetEntity("3eb2fb3d-061b-4c18-b37f-3f84360380f7");//菜单版本 
            if (string.IsNullOrEmpty(version.Value))
            {
                version.Value = "0";
            }
            version.Value = (int.Parse(version.Value) + 1).ToString();
            List<FunctionInfo> fucList = new List<FunctionInfo>();
            List<MenuInfo> parentList = new List<MenuInfo>();
            foreach (var item in list)
            {
                if (item.Name != "菜单" && item.Name != "工具栏" && item.Name != "右键菜单" && item.Name != "控件")
                {

                    if (item.IsMust)
                    {
                        //必备功能，则将其父菜单不处理，
                        //其子菜单，如果有不是必备的，则改为在权限设置里显示
                        item.IsMustNot = true;

                        if (item.RecordStatus != StatusType.add)
                        {
                            if (Dal.Exists<MenuInfo>(MenuInfo._.ClassCode.StartsWith(item.ClassCode + ";") && MenuInfo._.IsMust == false))
                            {
                                item.IsMustNot = false;
                            }
                        }

                    }
                    else
                    {
                        //不是必备功能，则将其功能显示 
                        if (!item.IsMustNot)
                        {
                            FunctionInfo parent = new FunctionInfo();
                            parent.RecordStatus = StatusType.update;
                            parent.Where = FunctionInfo._.ID == item.FuntionID;
                            parent.IsMustNot = false;
                            fucList.Add(parent);

                            //不是必备功能，则将其父菜单都显示

                            string classcode = item.ClassCode;
                            while (classcode.Length > 37)
                            {
                                classcode = classcode.Substring(0, classcode.Length - 37);
                                MenuInfo parentmenu = new MenuInfo();
                                parentmenu.RecordStatus = StatusType.update;
                                parentmenu.Where = MenuInfo._.ClassCode == classcode && MenuInfo._.Name != "菜单" && MenuInfo._.Name != "工具栏" && MenuInfo._.Name != "右键菜单" && MenuInfo._.Name != "控件";
                                parentmenu.IsMustNot = false;
                                parentList.Add(parentmenu);
                            }
                        }

                    }
                }
            }
            Sharp.Data.SessionFactory dal;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            try
            {
                dal.BeginBatch(20, tr);
                dal.SubmitNew(tr, ref dal, version);
                dal.SubmitNew(tr, ref dal, list);
                dal.SubmitNew(tr, ref dal, fucList);
                dal.SubmitNew(tr, ref dal, parentList);
                dal.EndBatch(tr);
                dal.CommitTransaction(tr);
                return 0;
            }
            catch (Exception ex)
            {
                dal.RollbackTransaction(tr);
                //LogDataAccess.LogDal.Write(ex);
                return -1;
                throw;
            }

        }

        public DataTable GetMenuListByRole(string funcID, string[] roleids)
        {
            return Dal.From<Permission>().Where(Permission._.FunID == funcID && Permission._.RoleID.In(roleids) && Permission._.MenuID != null
                   &&
                   Permission._.IsVisble == true).Distinct()
                   .Select(Permission._.FunID, Permission._.MenuID, Permission._.IsEnable)
                   .ToDataTable();
        }

        public MenuInfo GetMenu(string menuID)
        {
            return Dal.Find<MenuInfo>(menuID);
        }

        public DataTable GetRootMenu(string fucnID)
        {
            return Dal.From<MenuInfo>().Where(MenuInfo._.FuntionID == fucnID && MenuInfo._.ParentID == null).ToDataTable();
        }
    }
}

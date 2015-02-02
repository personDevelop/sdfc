using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthorityEntity;
using FrameCommonEntity;
using FrameCommonDataAccess;
using Sharp.Common;
using System.Data;
using Sharp.Data;

namespace AuthorityDataAccess
{

    public class FunctionInfoDataAccess : Sharp.Data.BaseManager
    {
        public bool Exit(string id, string parentID, string code, string name, ref string errorMsg)
        {
            bool exist = Dal.Exists<FunctionInfo>(FunctionInfo._.ParentID == parentID &&
                FunctionInfo._.ID != id && FunctionInfo._.Code == code);
            if (exist)
            {
                errorMsg = "已存在相同编号";

            }
            else
            {
                exist = Dal.Exists<FunctionInfo>(FunctionInfo._.ParentID == parentID &&
                    FunctionInfo._.ID != id && FunctionInfo._.Name == name);
                if (exist)
                {
                    errorMsg = "已存在相同名称";
                }

            }
            return exist;
        }

        public int Delete(string classcode)
        {

            //删功能，删菜单，删分配
            //删除WFDistribution
            string[] funcIDAry = Dal.From<FunctionInfo>().Where(FunctionInfo._.ClassCode.StartsWith(classcode)).Select(FunctionInfo._.ID).ToSinglePropertyArray();

            ParameterInfoDataAccess paraClient = new ParameterInfoDataAccess();
            ParameterInfo version = paraClient.GetEntity("41585e05-7246-44d1-ada2-92112d0cda61");//功能版本 
            version.Value = (int.Parse(version.Value) + 1).ToString();

            SessionFactory dal;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            try
            {
                dal.BeginBatch(50, tr);
                dal.SubmitNew(tr, ref dal, version);
                dal.Delete<FunctionInfo>(FunctionInfo._.ClassCode.StartsWith(classcode), tr);
                dal.Delete<MenuInfo>(MenuInfo._.FuntionID.In(funcIDAry), tr);
                dal.Delete<Permission>(Permission._.FunID.In(funcIDAry), tr);
                dal.FromCustomSql("delete WFDistribution where EXISTS (select 1 from FunctionInfo where FunctionInfo.id=WFDistribution.FuncId and  ClassCode like @classCode+'%'   )", tr)
                    .AddInputParameter("classCode", classcode).ExecuteNonQuery();
                dal.EndBatch(tr);
                dal.CommitTransaction(tr);
                return 1;
            }
            catch (Exception)
            {
                dal.RollbackTransaction(tr);
               
                throw;
                return 0;
            }
            

        }

        public int Save(FunctionInfo item)
        {
            ParameterInfoDataAccess paraClient = new ParameterInfoDataAccess();
            ParameterInfo version = paraClient.GetEntity("41585e05-7246-44d1-ada2-92112d0cda61");//功能版本 
            if (string.IsNullOrEmpty(version.Value))
            {
                version.Value = "0";
            }
            version.Value = (int.Parse(version.Value) + 1).ToString();
            List<FunctionInfo> parentList = new List<FunctionInfo>();
            if (item.IsMust)
            {
                //必备功能，则将其父功能不处理，
                //其子功能及其菜单，如果有不是必备的，则改为在权限设置里显示
                item.IsMustNot = true;
                if (item.RecordStatus != StatusType.add)
                {


                    if (Dal.Exists<FunctionInfo>(FunctionInfo._.ClassCode.StartsWith(item.ClassCode + ";") && FunctionInfo._.IsMust == false))
                    {
                        item.IsMustNot = false;
                    }

                    if (item.IsMustNot)
                    {
                        if (Dal.Exists<MenuInfo>(MenuInfo._.FuntionID == item.ID && MenuInfo._.IsMust == false && MenuInfo._.Name != "菜单" && MenuInfo._.Name != "工具栏" && MenuInfo._.Name != "右键菜单" && MenuInfo._.Name != "控件"))
                        {
                            item.IsMustNot = false;
                        }
                    }
                }
            }
            else
            {
                if (!item.IsMustNot)
                {
                    //不是必备功能，则将其父功能都显示
                    string classcode = item.ClassCode;
                    while (classcode.Length > 37)
                    {
                        classcode = classcode.Substring(0, classcode.Length - 37);
                        FunctionInfo parent = new FunctionInfo();
                        parent.RecordStatus = StatusType.update;
                        parent.Where = FunctionInfo._.ClassCode == classcode;
                        parent.IsMustNot = false;
                        parentList.Add(parent);
                    }
                }

            }
            Sharp.Data.SessionFactory dal;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            try
            {
                dal.SubmitNew(ref dal, item, version);
                dal.SubmitNew(tr, ref dal, parentList);
                dal.CommitTransaction(tr);
                return 1;
            }
            catch (Exception)
            {
                dal.RollbackTransaction(tr);
                return -1;
            }

        }

        public System.Data.DataTable GetAllList()
        {
            return Dal.From<FunctionInfo>().OrderBy(FunctionInfo._.OrderNo).ToDataTable();

        }

        public string[] GetGroupClass()
        {
            return Dal.From<FunctionInfo>().OrderBy(FunctionInfo._.GroupType).Distinct().Select(FunctionInfo._.GroupType).ToSinglePropertyArray();

        }

        public int Save(List<FunctionInfo> list)
        {
            ParameterInfoDataAccess paraClient = new ParameterInfoDataAccess();
            ParameterInfo version = paraClient.GetEntity("41585e05-7246-44d1-ada2-92112d0cda61");//功能版本 

            version.Value = (int.Parse(version.Value) + 1).ToString();
            List<BaseEntity> listnew = new List<BaseEntity>();
            listnew.Add(version);
            listnew.AddRange(list);
            return Dal.Submit(listnew);
        }

        public System.Data.DataTable FindDefaultMenu()
        {
            return Dal.From<FunctionInfo>().Where(FunctionInfo._.Name == "默认菜单").ToDataTable();
        }

        public FunctionInfo GetEntityByName(string code, string name)
        {
            return Dal.Find<FunctionInfo>(FunctionInfo._.Code == code && FunctionInfo._.Name == name);
        }

        public DataTable GetCanSetPermissionFunc()
        {
            return Dal.From<FunctionInfo>().Where(FunctionInfo._.IsMustNot == false).OrderBy(FunctionInfo._.OrderNo).ToDataTable();

        }

        public DataTable GetCanSetPermissionMenu()
        {
            return Dal.From<MenuInfo>().Where(MenuInfo._.IsMustNot == false).OrderBy(MenuInfo._.OrderNo).ToDataTable();


        }

        public DataTable GetPermission()
        {
            return Dal.From<Permission>().ToDataTable();

        }

        public int SavePermission(List<Permission> AuthorityList, ref int version)
        {
            Sharp.Data.SessionFactory dal;
            int result = 0;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            try
            {
                result = dal.SubmitNew(tr, ref dal, AuthorityList);
                ParameterInfo p = new ParameterInfo();
                p.ID = "478d3892-df2d-4f2b-b1f7-43d4398fcafc";//权限版本ID
                p.RecordStatus = StatusType.update;
                int newversion = version + 1;
                p.Value = newversion.ToString();
                dal.SubmitNew(tr, ref dal, p);
                dal.CommitTransaction(tr);
                version = newversion;
            }
            catch (Exception)
            {
                dal.RollbackTransaction(tr);

                throw;
            }
            return result;
        }

        public DataTable GetAllFunctByRole(string[] roleids)
        {
            DataTable dt = Dal.From<FunctionInfo>().Join<Permission>(FunctionInfo._.ID == Permission._.FunID
            && Permission._.RoleID.In(roleids) && Permission._.MenuID == null && Permission._.IsVisble == true)
            .Select(FunctionInfo._.ID.All)
            .Distinct()
             .ToDataTable();
            dt.Merge(Dal.From<FunctionInfo>().Where(FunctionInfo._.IsMust == true).ToDataTable());
            DataView dv = dt.DefaultView;     //dt3默认的虚拟视图
            dv.Sort = "ID asc"; //排序
            dt = dv.ToTable(true);
            return dt;
            //var qry = from dr in dt.AsEnumerable()
            //          where !dr.Field<string>("ClassCode").Contains("34fedeb5-7cda-42b2-8377-be5c9b7602cb")//主程序
            //              && !dr.Field<string>("ClassCode").Contains("05fd2983-febe-4e4b-ba55-f67886196efe") //零散功能
            //          select dr;
            //return qry.CopyToDataTable(); ;
        }


        public FunctionInfo GetEntity(string id)
        {
            return Dal.Find<FunctionInfo>(id);
        }
    }
}

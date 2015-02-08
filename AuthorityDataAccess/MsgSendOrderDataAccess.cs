using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AuthorityEntity;
using Sharp.Common;
using Sharp.Data;

namespace AuthorityDataAccess
{
    public class MsgSendOrderDataAccess : Sharp.Data.BaseManager
    {
        public DataTable GetAllMsg()
        {
            return Dal.From<MsgSendOrder>()
                .OrderBy(MsgSendOrder._.CreateDate.Desc).ToDataTable();
        }

        public DataTable GetAllMsgByStatus(string status)
        {
            return Dal.From<MsgSendOrder>().Where(MsgSendOrder._.MsgStatus == status)
                .OrderBy(MsgSendOrder._.CreateDate.Desc).ToDataTable();
        }
        public DataTable GetMySenderMsg(string senderID)
        {
            return Dal.From<MsgSendOrder>().Where(MsgSendOrder._.SenderID == senderID)
                .OrderBy(MsgSendOrder._.CreateDate.Desc).ToDataTable();
        }
        public DataTable GetMyReciveMsg(string reciverID)
        {
            return Dal.From<MsgSendOrder>().Where(MsgSendOrder._.ReciverID == reciverID)
                .OrderBy(MsgSendOrder._.CreateDate.Desc).ToDataTable();
        }

        public int AddMsg(DataTable dt)
        {
            List<MsgSendOrder> list = dt.ToList<MsgSendOrder>();
            foreach (MsgSendOrder item in list)
            {
                item.RecordStatus = StatusType.add;
                item.MsgStatus = "待发送";
                item.CreateDate = DateTime.Now;
            }
            SessionFactory dal;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            int result = 0;
            try
            {
                result = dal.SubmitNew(list, ref dal);
                dal.CommitTransaction(tr);
            }
            catch (Exception)
            {
                dal.RollbackTransaction(tr);
                result = -1;
            }
            return result;
        }

        public int AddOneMsgToMutilsPerson(string msg, string senderID, string senderName, string senderTel,
            string[] reciverIDS, string[] reciverNames, string[] reciverTelPhone)
        {
            List<MsgSendOrder> list = new List<MsgSendOrder>();
            for (int i = 0; i < reciverTelPhone.Length; i++)
            {


                MsgSendOrder order = new MsgSendOrder();
                order.ID = Guid.NewGuid().ToString();
                order.SenderID = senderID;
                order.SenderName = senderName;
                order.SenderTel = senderTel;
                order.ReciverID = reciverIDS[i];
                order.ReciverName = reciverNames[i];
                order.ReciverTel = reciverTelPhone[i];

                order.MsgContent = msg;
                order.MsgStatus = "待发送";
                order.CreateDate = DateTime.Now;
                list.Add(order);
            }
            SessionFactory dal;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            int result = 0;
            try
            {
                result = dal.SubmitNew(list, ref dal);
                dal.CommitTransaction(tr);
            }
            catch (Exception)
            {
                dal.RollbackTransaction(tr);
                result = -1;
            }
            return result;
        }

        public int UpdateStatus(string[] msgID, string Status)
        {

            MsgSendOrder order = new MsgSendOrder();
            order.RecordStatus = StatusType.update;
            order.Where = MsgSendOrder._.ID.In(msgID);
            order.MsgStatus = Status;
            order.SendTime = DateTime.Now;
            return Dal.Submit(order);
        }
    }
}

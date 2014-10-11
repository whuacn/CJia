using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Presenters
{
    public class NewCancelApplyPresenter : Tools.Presenter<Models.NewCancelApplyModel, Views.INewCancelApplyView>
    {
        public NewCancelApplyPresenter(Views.INewCancelApplyView view)
            : base(view)
        {
            view.Load += view_Load;
            view.OnCancelPreview += view_OnCancelPreview;
            view.OnRefuseApply += view_OnRefuseApply;
            view.OnOkCancel += view_OnOkCancel;
            view.OnBtnSelect += view_OnBtnSelect;
            view.OnBtnDelete += view_OnBtnDelete;
        }

        void view_OnBtnDelete(object sender, Views.NewCancelApplyArgs e)
        {
            string barCode = e.BarCodeID;
            if (!e.barCodeList.Contains(barCode))
            {
                View.ExeDeleteReturn("不在查询的瓶贴中", false);
                return;
            }
            DataTable data = Model.GetLabelByBarCodeID(barCode);
            if (data != null)
            {
                if (data.Rows[0]["STATUS"].ToString() == "1000603")
                {
                    View.ExeDeleteReturn("该瓶贴之前已作废", false);
                    return;
                }
                using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
                {
                    string labelID = data.Rows[0]["LABEL_ID"].ToString();
                    string labelBarCodeStatus = data.Rows[0]["STATUS"].ToString();
                    string labelBarCode = data.Rows[0]["LABEL_BAR_ID"].ToString();
                    bool isFee = CJia.PIVAS.Models.PIVASModel.QueryCancelFeeTime(labelBarCode);
                    this.Model.DelectCancelApply(trans.ID, labelID);
                    bool bol4 = true;
                    bool bol = true;
                    bool bol2 = true;
                    //if(isFee)// 产生了费用
                    //{
                    long cancelRCPID = Model.GetNextCancelRCPId();
                    bol2 = Model.AddCancelApplyRCP(trans.ID, cancelRCPID, User.UserId.ToString(), User.UserName, User.DeptId, User.DeptName, User.HisUserId.ToString());
                    bol4 = Model.AddCancelApply(trans.ID, labelID, labelBarCode, User.UserId.ToString(), User.UserName, User.DeptId, User.DeptName, " ", User.UserId.ToString(), isFee ? "1" : "0");
                    string strFee = "";
                    if (isFee) strFee = "1";
                    else strFee = "0";
                    bol = Model.ModifyCancelRCPID(trans.ID, cancelRCPID, labelID, User.UserId.ToString(), strFee, "1000303");
                    //}
                    bool bol1 = Model.ModifyLabelStatusByID2(trans.ID, labelID, User.UserId.ToString());
                    bool bol3 = Model.ModifyBarCodeStatusByID(trans.ID, labelID, User.UserId.ToString());
                    if (!bol || !bol1 || !bol2 || !bol3 || !bol4)
                    {
                        View.ExeDeleteReturn("作废瓶贴失败！", false);
                        return;
                    }
                    if (isFee)
                    {
                        int feeCount = int.Parse(data.Rows[0]["FEE_COUNT"].ToString());
                        for (int j = 0; j < data.Rows.Count; j++)
                        {
                            if (feeCount != 0)
                            {
                                string str = CJia.PIVAS.Models.PIVASModel.ExecuteAdviceIdFee(trans.ID, data.Rows[j]["HIS_ADVICE_ID"].ToString(), User.HisUserId.ToString(), Model.Sysdate(), feeCount, 1);
                                if (str != "Successed")
                                {
                                    View.ExeDeleteReturn("作废瓶贴失败！" + str + "！", false);
                                    return;
                                }
                            }
                        }
                    }
                    trans.Complete();
                    View.ExeDeleteReturn("作废瓶贴成功！", true);
                }
            }
            else
            {
                View.ExeDeleteReturn("无此条形码对应的瓶贴信息！", false);
            }
        }

        void view_OnBtnSelect(object sender, Views.NewCancelApplyArgs e)
        {
            DataTable data = Model.GetLabelByBarCodeList(e.barCodeList);
            View.ExeBindBarCode(data);
        }

        //确认退药
        void view_OnOkCancel(object sender, Views.NewCancelApplyArgs e)
        {
            long cancelRCPID = Model.GetNextCancelRCPId();
            if (e.LabelID.Count > 0)
            {
                using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
                {
                    List<string> list = new List<string>();
                    list = GetLable(e.LabelID);
                    for (int i = 0; i < list.Count; i++)
                    {
                        bool bol = Model.ModifyCancelRCPID(trans.ID, cancelRCPID, list[i], User.UserId.ToString(), "1", "1000303");
                        bool bol1 = Model.ModifyLabelStatusByID2(trans.ID, list[i], User.UserId.ToString());
                        bool bol3 = Model.ModifyBarCodeStatusByID(trans.ID, list[i], User.UserId.ToString());
                        if (!bol || !bol1 || !bol3)
                        {
                            View.ShowMessage("确定退药失败！" + bol.ToString() + bol1.ToString() + bol3.ToString());
                            return;
                        }
                    }

                    for (int j = 0; j < e.AdviceID.Count; j++)
                    {
                        if (CJia.PIVAS.Models.PIVASModel.QueryCancelFeeTimeLabelId(e.LabelID[j]))
                        {
                            int feeCount = int.Parse(this.Model.QueryLabelTimes(e.LabelID[j]));
                            if (feeCount != 0)
                            {
                                string str = CJia.PIVAS.Models.PIVASModel.ExecuteAdviceIdFee(trans.ID, e.AdviceID[j], User.HisUserId.ToString(), Model.Sysdate().AddSeconds(j), feeCount, 1);
                                if (str != "Successed")
                                {
                                    View.ShowMessage("确定退药失败！" + str);
                                    return;
                                }
                            }
                        }
                    }
                    bool bol2 = Model.AddCancelApplyRCP(trans.ID, cancelRCPID, User.UserId.ToString(), User.UserName, User.DeptId, User.DeptName, User.UserId.ToString());
                    if (bol2)
                    {
                        View.ShowMessage("确定退药成功！");
                    }
                    trans.Complete();
                }
            }
        }

        //拒绝退药
        void view_OnRefuseApply(object sender, Views.NewCancelApplyArgs e)
        {
            long cancelRCPID = Model.GetNextCancelRCPId();
            if (e.LabelID.Count > 0)
            {
                using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
                {
                    List<string> list = new List<string>();
                    list = GetLable(e.LabelID);
                    for (int i = 0; i < list.Count; i++)
                    {
                        bool bol = Model.ModifyCancelRCPID(trans.ID, cancelRCPID, list[i], User.UserId.ToString(), "1", "1000305");
                        bool bol1 = Model.ModifyLabelStatusByID(trans.ID, list[i], User.UserId.ToString());
                        if (!bol || !bol1)
                        {
                            View.ShowMessage("拒绝退药申请失败！");
                            return;
                        }
                    }
                    bool bol2 = Model.AddCancelApplyRCP(trans.ID, cancelRCPID, User.UserId.ToString(), User.UserName, User.DeptId, User.DeptName, User.UserId.ToString());
                    if (bol2)
                    {
                        View.ShowMessage("拒绝退药申请成功！");
                    }
                    trans.Complete();
                }
            }
        }

        void view_OnCancelPreview(object sender, Views.NewCancelApplyArgs e)
        {
            DataTable data = Model.GetApplyLabelByIffieldAndDate(e.Date, e.IllFieldId);
            if (data != null)
            {
                DataColumn isChecked = new DataColumn("ISCHECK", typeof(System.Boolean));
                data.Columns.Add(isChecked);
            }
            View.ExeBindGridCancelApply(data);
        }

        void view_Load(object sender, EventArgs e)
        {
            DataTable data = Model.GetAllIffield();
            View.ExeBindOfficeName(data);
        }

        public List<string> GetLable(List<string> list)
        {
            List<string> newList = new List<string>();
            for (int j = 0; j < list.Count; j++)
            {
                if (newList.Count != 0)
                {
                    bool bol = false;
                    for (int k = 0; k < newList.Count; k++)
                    {
                        if (list[j] == newList[k])
                        {
                            bol = true;
                        }
                    }
                    if (!bol)
                    {
                        newList.Add(list[j]);
                    }
                }
                else
                {
                    newList.Add(list[j]);
                }
            }
            return newList;
        }
    }
}

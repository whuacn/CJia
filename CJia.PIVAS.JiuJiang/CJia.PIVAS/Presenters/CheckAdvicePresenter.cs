//***************************************************
// 文件名（File Name）:      CheckAdvicePresenter.cs（审方Presenter层）
//
// 数据表（Tables）:         nothing
// 视图(Views)               nothing
//
// 作者（Author）:           郭婷
//
// 日期（Create Date）:     2013.1.21
//***************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.PIVAS.Presenters
{
    /// <summary>
    /// 审方Presenter层
    /// </summary>
    public class CheckAdvicePresenter : Tools.Presenter<Models.CheckAdviceModel, Views.ICheckAdviceView>
    {
        /// <summary>
        /// 审方Presenter层
        /// </summary>
        /// <param name="view"></param>
        public CheckAdvicePresenter(Views.ICheckAdviceView view)
            : base(view)
        {
            view.OnInitLoad += view_OnInitLoad;
            view.OnRefresh += view_OnRefresh;
            view.OnInsertCheck += view_OnInsertCheck;
            view.OnCancelCheck += view_OnCancelCheck;
            view.OnRefuseCheck += view_OnRefuseCheck;
            view.OnPatient += view_OnPatient;
            view.OnPatientHistory += view_OnPatientHistory;
            view.OnComplete += view_OnComplete;
            view.OnPWJJ += view_OnPWJJ;
        }

        void view_OnPWJJ(object sender, Views.CheckAdviceArgs e)
        {
            string[] data = CJia.PIVAS.Models.PIVASModel.GetPWJJByGroupIndex(e.GroupIndex);
            View.ExeBindPWJJ(data);
        }

        /// <summary>
        /// 审方通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnComplete(object sender, Views.CheckAdviceArgs e)
        {
            DataTable batchData = Model.GetBatchData(e.BeginListDate, e.EndListDate, e.OfficeID, e.IsValidCheck, e.IsAllCheck, e.IsNoCheck, e.IsYesCheck, e.IsTypePTY, e.IsTypeJSY, e.IsTypeDMY, e.IsTypeGCY, e.IsTypeKSS, e.CheckPivasStatus, e.CheckLong, e.CheckTemporary);
            if(batchData == null)
            {
                CJia.Message.Show("没有待审医嘱！");
            }
            else
            {
                int checkSeq = Model.GetCheckSeq();
                using(CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
                {
                    //插入审核表
                    this.Model.AddCheck(trans.ID, checkSeq, User.UserId, User.UserNo, User.UserName, User.DeptId, User.DeptName, User.UserId);
                    //明细表中的未审医嘱
                    DataTable noData = Model.GetCheckDetail(e.BeginListDate, e.EndListDate, e.OfficeID, e.IsValidCheck, e.IsAllCheck, e.IsNoCheck, e.IsYesCheck, e.IsTypePTY, e.IsTypeJSY, e.IsTypeDMY, e.IsTypeGCY, e.IsTypeKSS, e.CheckPivasStatus, e.CheckLong, e.CheckTemporary);
                    //明细表中的已审医嘱
                    DataTable yesData = Model.GetYesCheckDetail(e.BeginListDate, e.EndListDate, e.OfficeID, e.IsValidCheck, e.IsAllCheck, e.IsNoCheck, e.IsYesCheck, e.IsTypePTY, e.IsTypeJSY, e.IsTypeDMY, e.IsTypeGCY, e.IsTypeKSS, e.CheckPivasStatus, e.CheckLong, e.CheckTemporary);
                    if(yesData == null && noData == null)//新医嘱，未审核过
                    {
                        //插入审核明细表
                        Models.CheckResult checkResult = Model.BatchAddCheckDetail(trans.ID, checkSeq, 1000102, User.UserId, e.BeginListDate, e.EndListDate, e.OfficeID, e.IsValidCheck, e.IsAllCheck, e.IsNoCheck, e.IsYesCheck, e.IsTypePTY, e.IsTypeJSY, e.IsTypeDMY, e.IsTypeGCY, e.IsTypeKSS, e.CheckPivasStatus, e.CheckLong, e.CheckTemporary);
                        //更新瓶贴基表
                        //List<string> groupIndex = new List<string>();
                        ////DataTable batchData = Model.GetBatchData(e.BeginListDate, e.EndListDate, e.OfficeID);
                        //for(int i = 0; i < batchData.Rows.Count; i++)
                        //{
                        //    groupIndex.Add(batchData.Rows[i]["GROUP_INDEX"].ToString());
                        //}
                        RefreshCommonLabel(trans.ID, checkResult.CheckGroup);
                        this.showMes(checkResult.NoCheckGroup);
                    }
                    else
                    {
                        //DataTable batchData = Model.GetBatchData(e.BeginListDate, e.EndListDate, e.OfficeID);
                        if(batchData != null)
                        {
                            Models.CheckResult checkResult = new Models.CheckResult();
                            for(int i = 0; i < batchData.Rows.Count; i++)
                            {
                                List<string> result = this.Model.QueryPharm(batchData.Rows[i]["GROUP_INDEX"].ToString());
                                if(result != null && result.Count > 0)
                                {
                                    checkResult.NoCheckGroup.Add(new Models.NoCheckGroupPharm()
                                    {
                                        GroupIndex = batchData.Rows[i]["GROUP_INDEX"].ToString(),
                                        pharmList = result
                                    });
                                }
                                else
                                {
                                    //将之前审核明细置为无效
                                    //int detailId = Model.GetDetailIdByGroupIndex(batchData.Rows[i]["GROUP_INDEX"].ToString());
                                    //Model.ModifyCheckDetailValid(trans.ID, User.UserId, detailId);
                                    this.Model.ModifyCheckDetailGroupIndex(trans.ID, batchData.Rows[i]["GROUP_INDEX"].ToString(), User.UserId);
                                    //插入新的审核明细
                                    Model.AddCheckDetail(trans.ID, checkSeq, batchData.Rows[i]["GROUP_INDEX"].ToString(), 1000101, 1000102, e.OriginalPivasBatchNo, batchData.Rows[i]["CHECK_PIVAS_BATCH_NO"].ToString(), User.UserId, e.CancelReason, e.LongTimeStatus);
                                    //更新瓶贴基表
                                    List<string> groupIndex = new List<string>();
                                    groupIndex.Add(batchData.Rows[i]["GROUP_INDEX"].ToString());
                                    RefreshCommonLabel(trans.ID, groupIndex);
                                    checkResult.CheckGroup.Add(batchData.Rows[i]["GROUP_INDEX"].ToString());
                                }
                            }
                            this.showMes(checkResult.NoCheckGroup);
                        }
                        ////将之前审核明细批量置为无效
                        //Model.ModifyCheckDetail(trans.ID, User.UserId, e.BeginListDate, e.EndListDate, e.OfficeID, groupIndex);
                        ////插入新的审核明细
                        //Model.BatchAddCheckDetail(trans.ID, checkSeq, e.CheckPivasStatus, User.UserId, e.BeginListDate, e.EndListDate, e.OfficeID, batchStr);
                        ////更新瓶贴基表
                        //RefreshCommonLabel(trans.ID, groupIndex);
                    }
                    trans.Complete();
                }
            }
        }

        /// <summary>
        /// 病史资料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnPatientHistory(object sender, Views.CheckAdviceArgs e)
        {
            DataTable data = Model.GetPatientHistoryDataByInhosId(e.InhosId);
            View.ExeBindPatientHistory(data);
        }

        /// <summary>
        /// 病人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnPatient(object sender, Views.CheckAdviceArgs e)
        {
            DataTable data = Model.GetPatientDataByInhosId(e.InhosId);
            View.ExeBindPatient(data);
        }

        /// <summary>
        /// 拒绝
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnRefuseCheck(object sender, Views.CheckAdviceArgs e)
        {
            int checkSeq = Model.GetCheckSeq();
            using(CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                //插入审核表
                this.Model.AddCheck(trans.ID, checkSeq, User.UserId, User.UserNo, User.UserName, User.DeptId, User.DeptName, User.UserId);
                //判断是否在明细表
                DataTable data = Model.GetCheckDetailDataByGroupIndex(e.GroupIndex);
                if(data == null)//新医嘱，未审核过
                {
                    //插入审核明细表
                    Model.AddCheckDetail(trans.ID, checkSeq, e.GroupIndex, e.OriginalPivasStatus, e.CheckPivasStatus, e.OriginalPivasBatchNo, e.CheckPivasBatchNo, User.UserId, e.CancelReason, e.LongTimeStatus);
                }
                else
                {
                    //将之前审核明细置为无效
                    //int detailId = Model.GetDetailIdByGroupIndex(e.GroupIndex);
                    //Model.ModifyCheckDetailValid(trans.ID, User.UserId, detailId);
                    this.Model.ModifyCheckDetailGroupIndex(trans.ID, e.GroupIndex, User.UserId);
                    //插入新的审核明细
                    Model.AddCheckDetail(trans.ID, checkSeq, e.GroupIndex, e.OriginalPivasStatus, e.CheckPivasStatus, e.OriginalPivasBatchNo, e.CheckPivasBatchNo, User.UserId, e.CancelReason, e.LongTimeStatus);
                    //更新瓶贴基表
                    List<string> groupIndex = new List<string>();
                    groupIndex.Add(e.GroupIndex);
                    RefreshCommonLabel(trans.ID, groupIndex);
                }
                trans.Complete();
            }
        }

        /// <summary>
        /// 撤销审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnCancelCheck(object sender, Views.CheckAdviceArgs e)
        {
            int checkSeq = Model.GetCheckSeq();
            using(CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                //插入审核表
                this.Model.AddCheck(trans.ID, checkSeq, User.UserId, User.UserNo, User.UserName, User.DeptId, User.DeptName, User.UserId);
                int detailId = Model.GetDetailIdByGroupIndex(e.GroupIndex);
                //修改审核明细
                Model.ModifyCheckDetail(trans.ID, checkSeq, e.OriginalPivasStatus, e.CheckPivasStatus, e.OriginalPivasBatchNo, e.CheckPivasBatchNo, User.UserId, e.CancelReason, detailId);
                if(e.OriginalPivasStatus == 1000102)    //撤销已审
                {
                    //更新瓶贴基表
                    List<string> groupIndex = new List<string>();
                    groupIndex.Add(e.GroupIndex);
                    RefreshCommonLabel(trans.ID, groupIndex);
                }
                trans.Complete();
            }
        }

        /// <summary>
        /// 单个审方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInsertCheck(object sender, Views.CheckAdviceArgs e)
        {
            int checkSeq = Model.GetCheckSeq();
            using(CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                Models.CheckResult checkResult = new Models.CheckResult();
                //插入审核表
                this.Model.AddCheck(trans.ID, checkSeq, User.UserId, User.UserNo, User.UserName, User.DeptId, User.DeptName, User.UserId);
                //判断是否在明细表
                DataTable data = Model.GetCheckDetailDataByGroupIndex(e.GroupIndex);
                if(data == null)//新医嘱，未审核过
                {
                    List<string> pharmList = this.Model.QueryPharm(e.GroupIndex);
                    if(pharmList != null && pharmList.Count > 0)
                    {
                        checkResult.NoCheckGroup.Add(new Models.NoCheckGroupPharm()
                        {
                            GroupIndex = e.GroupIndex,
                            pharmList = pharmList
                        });
                    }
                    else
                    {
                        //插入审核明细表
                        Model.AddCheckDetail(trans.ID, checkSeq, e.GroupIndex, e.OriginalPivasStatus, e.CheckPivasStatus, e.OriginalPivasBatchNo, e.CheckPivasBatchNo, User.UserId, e.CancelReason, e.LongTimeStatus);
                        //更新瓶贴基表
                        List<string> groupIndex = new List<string>();
                        groupIndex.Add(e.GroupIndex);
                        RefreshCommonLabel(trans.ID, groupIndex);
                        checkResult.CheckGroup.Add(e.GroupIndex);
                    }
                }
                else
                {
                    List<string> pharmList = this.Model.QueryPharm(e.GroupIndex);
                    if(pharmList != null && pharmList.Count > 0)
                    {
                        checkResult.NoCheckGroup.Add(new Models.NoCheckGroupPharm()
                        {
                            GroupIndex = e.GroupIndex,
                            pharmList = pharmList
                        });
                    }
                    else
                    {
                        //将之前审核明细置为无效
                        //int detailId = Model.GetDetailIdByGroupIndex(e.GroupIndex);
                        //Model.ModifyCheckDetailValid(trans.ID, User.UserId, detailId);
                        this.Model.ModifyCheckDetailGroupIndex(trans.ID, e.GroupIndex, User.UserId);
                        //插入新的审核明细
                        Model.AddCheckDetail(trans.ID, checkSeq, e.GroupIndex, e.OriginalPivasStatus, e.CheckPivasStatus, e.OriginalPivasBatchNo, e.CheckPivasBatchNo, User.UserId, e.CancelReason, e.LongTimeStatus);
                        //更新瓶贴基表
                        List<string> groupIndex = new List<string>();
                        groupIndex.Add(e.GroupIndex);
                        RefreshCommonLabel(trans.ID, groupIndex);
                        checkResult.CheckGroup.Add(e.GroupIndex);
                    }
                }
                this.showMes(checkResult.NoCheckGroup);
                trans.Complete();
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnRefresh(object sender, Views.CheckAdviceArgs e)
        {
            DataTable dtAdvice = Model.GetAdviceData(e.BeginListDate, e.EndListDate, e.OfficeID, e.IsValidCheck, e.IsAllCheck, e.IsNoCheck, e.IsYesCheck, e.IsTypePTY, e.IsTypeJSY, e.IsTypeDMY, e.IsTypeGCY, e.IsTypeKSS, e.CheckPivasStatus, e.CheckLong, e.CheckTemporary);


            //if(e.IsNoCheck)
            //{
            //    DataTable storeyPharm = this.Model.QueryStoreyPharm();
            //    if(dtAdvice != null && dtAdvice.Rows != null && dtAdvice.Rows.Count > 0)
            //    {
            //        foreach(DataRow row in dtAdvice.Rows)
            //        {
            //            storeyPharm.Select( " GM_ADVICE_ID = '" +  row["GM_ADVICE_ID"] + "'" )
            //        }
            //    }
            //}

            //DataTable dtBatchData = Model.GetBatchData(e.BeginListDate,e.EndListDate,e.OfficeID);
            View.ExeGetAdvice(dtAdvice);
            //View.ExeGetBatchData(dtBatchData);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInitLoad(object sender, EventArgs e)
        {
            DataTable data = Model.GetOffice();
            View.ExeBindOffice(data);
        }

        /// <summary>
        /// 更新组号对应的固定瓶贴
        /// </summary>
        /// <param name="tranId"></param>
        /// <param name="groupIndexs"></param>
        public void RefreshCommonLabel(string tranId, List<string> groupIndexs)
        {
            if(groupIndexs != null && groupIndexs.Count != 0)
            {
                this.Model.InsertLabelDetail(tranId, groupIndexs);
                this.Model.DeleteCommonLabel(tranId, groupIndexs);
                this.Model.InsertCommonLabel(tranId, groupIndexs, CJia.PIVAS.User.UserId);
            }
        }

        public void showMes(List<Models.NoCheckGroupPharm >noCheckGroupPharms)
        {
            string floag = "";
            if(noCheckGroupPharms != null && noCheckGroupPharms.Count > 0)
            {
                foreach(Models.NoCheckGroupPharm noCheckGroupPharm in noCheckGroupPharms)
                {
                    string phs = "";
                    foreach(string ph in noCheckGroupPharm.pharmList)
                    {
                        phs += ph + "  ";
                    }
                    floag += "医嘱  " + noCheckGroupPharm.GroupIndex + "  因为药品  " + phs + @"库存不足或无此药品不能审核
";
                }
                Message.Show(floag);
            }
            else
            {

            }
        }
    }
}

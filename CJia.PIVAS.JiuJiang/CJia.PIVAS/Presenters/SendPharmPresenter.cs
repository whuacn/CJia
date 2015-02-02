using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Presenters
{
    /// <summary>
    /// 冲药presenter层
    /// </summary>
    public class SendPharmPresenter : CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.SendPharmModel, CJia.PIVAS.Views.ISendPharmView>
    {

        /// <summary>
        /// 登录的构造方法
        /// </summary>
        /// <param name="view"></param>
        public SendPharmPresenter(Views.ISendPharmView view)
            : base(view)
        {
            this.View.OnInitIffield += View_OnInitIffield;
            this.View.OnInitBacth += View_OnInitBacth;
            this.View.OnSelectLabel += View_OnSelectLabel;
            this.View.OnSelectPharmColloet += View_OnSelectPharmColloet;
            this.View.OnSendPharm += View_OnSendPharm;
            this.View.OnPrintPharm += View_OnPrintPharm;
            this.View.OnFeeTIME += View_OnFeeTIME;
            this.View.OnPharmFee += View_OnPharmFee;
            this.View.OnUpdateLabelExeStatus += View_OnUpdateLabelExeStatus;
        }



        #region View事件绑定方法

        //修改瓶贴冲药状态
        void View_OnUpdateLabelExeStatus(object labelId)
        {
            CJia.PIVAS.Models.PIVASModel.ExecuteLabelFee(labelId.ToString());
        }

        //获取扣费时间
        object View_OnFeeTIME(object feeTime)
        {
            return CJia.PIVAS.Models.PIVASModel.QueryFeeTime(feeTime.ToString());
        }

        //扣费扣库存
        object View_OnPharmFee(object groupIndex, object openDate, object count)
        {
            return CJia.PIVAS.Models.PIVASModel.ExecuteGroupIndexFee(groupIndex.ToString(), CJia.PIVAS.User.hisUserId.ToString(), (DateTime)openDate, (int)count, 0);
        }

        //查询药品汇总
        void View_OnSelectPharmColloet(object sender, Views.SendPharmEventArgs e)
        {
            DataTable result = this.Model.QueryPharmColloct(e.date, e.IffieldID);
            this.View.ExeInitPharmColloet(result);
        }

        //查询瓶贴
        void View_OnSelectLabel(object sender, Views.SendPharmEventArgs e)
        {
            DataTable result = this.Model.QueryLabler(e.IffieldID,e.barchID);
            this.View.ExeInitLabel(result);
        }

        //初始化病区事件绑定方法
        void View_OnInitIffield(object sender, Views.SendPharmEventArgs e)
        {
            this.View.ExeInitIffield(Common.GetIllfield());
        }

        //初始化批次事件绑定方法
        void View_OnInitBacth(object sender, Views.SendPharmEventArgs e)
        {
            this.View.ExeInitBacth(Common.GetBatch());
        }

        void View_OnSendPharm(object sender, Views.SendPharmEventArgs e)
        {
            //判断冲药是否今天
            DateTime sysdate = Model.SystemDate;
            if (sysdate.ToShortDateString() != e.date.ToShortDateString())
            {
                View.ShowMessage("请选择当前时间进行冲药操作！");
                return;
            }
            //判断有无退药申请

            //判断库存
            DataTable data = Model.GetTodayNOPharmStore(e.IffieldID);
            if (data != null && data.Rows.Count > 0) { View.ExeBindTodayNoPharmStore(data, e.IffieldID); return; }
            //扣费用 扣库存 费用明细 
            DataTable adviceData = Model.QueryTodayPharmSend(e.IffieldID);
            if (adviceData != null && adviceData.Rows.Count > 0)
            {
                DataTable trueAdvice = adviceData.Clone();
                DataTable falseAdvice = adviceData.Clone();
                falseAdvice.Columns.Add("MESSAGE", typeof(string));
                using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
                {
                    for (int i = 0; i < adviceData.Rows.Count; i++)
                    {
                        int j = int.Parse(adviceData.Rows[i]["TIMES"].ToString());
                        string message = Models.PIVASModel.ExecuteAdviceIdFee(trans.ID, adviceData.Rows[i]["ADVICE_ID"].ToString(), User.HisUserId.ToString(), sysdate,j,1);
                        if (message != "Successed！")
                        {
                            DataRow dr = falseAdvice.NewRow();
                            object[] drItem = new object[adviceData.Rows[i].ItemArray.Length + 1];
                            for (int k = 0; k < drItem.Length - 1; k++)
                            {
                                drItem[k] = adviceData.Rows[i].ItemArray[k];
                            }
                            drItem[drItem.Length - 1] = message;
                            dr.ItemArray = drItem;
                            falseAdvice.Rows.Add(dr);
                        }
                        else
                        {
                            DataRow dr = trueAdvice.NewRow();
                            dr.ItemArray = adviceData.Rows[i].ItemArray;
                            trueAdvice.Rows.Add(dr);
                        }
                    }
                    trans.Complete();
                }
                View.ExeBindTodayPharmSend(trueAdvice, falseAdvice);
            }
        }

        void View_OnPrintPharm(object sender, Views.SendPharmEventArgs e)
        {
            DataTable result = this.Model.QueryPharmColloct(e.date, e.IffieldID);
            this.View.ExeBindTodayPharmSendReport(result);
        }
        #endregion

        /// <summary>
        /// 重写OnInitView 方法
        /// </summary>
        protected override void OnInitView()
        {

        }
    }
}

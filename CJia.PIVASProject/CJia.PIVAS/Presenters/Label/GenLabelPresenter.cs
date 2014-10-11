using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.Label
{
    /// <summary>
    /// 生成瓶贴Presenter层
    /// </summary>
    public class GenLabelPresenter : CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.Label.GenLabelModel, CJia.PIVAS.Views.Label.IGenLabelView>
    {

        /// <summary>
        /// 生成瓶贴构造函数
        /// </summary>
        /// <param name="view"></param>
        public GenLabelPresenter(CJia.PIVAS.Views.Label.IGenLabelView view)
            : base(view)
        {
            this.View.OnQueryListCountEven += View_QueryListCountEven;
            this.View.OnQueryIffield += View_QueryIffield;
            this.View.OnPreviewLabelEven += View_OnPreviewLabelEven;
            this.View.OnGenLabelEven += View_OnGenLabelEven;
        }

        /// <summary>
        /// 出事化View层
        /// </summary>
        protected override void OnInitView()
        {
            base.OnInitView();
        }

        #region View事件绑定方法

        // 查询病区
        void View_QueryIffield(object sender, CJia.PIVAS.Views.Label.GenLabelEventArgs e)
        {
            DataTable result = this.Model.QueryIffield();
            this.View.ExeBindingIffield(result);
        }

        // 生成瓶贴
        void View_OnGenLabelEven(object sender, CJia.PIVAS.Views.Label.GenLabelEventArgs e)
        {
            switch(this.IsCorrectTime(e))
            {
                case 0:
                    this.View.ShowMessage("时间配置信息有错误！");
                    break;
                case 1:
                    this.GenLabel(e);
                    break;
                case 2:
                    this.View.ShowMessage("不在操作时间内！");
                    break;
                case 3:
                    this.View.ShowMessage("您还没有选着病区！");
                    break;
                default:
                    break;
            }
        }

        // 预览瓶贴
        void View_OnPreviewLabelEven(object sender, CJia.PIVAS.Views.Label.GenLabelEventArgs e)
        {
            switch(this.IsCorrectTime(e))
            {
                case 0:
                    this.View.ShowMessage("时间配置信息有错误！");
                    break;
                case 1:
                    this.PreviewLabel(e);
                    break;
                case 2:
                    this.View.ShowMessage("不在操作时间内！");
                    break;
                case 3:
                    this.View.ShowMessage("您还没有选着病区！");
                    break;
                default:
                    break;
            }

        }

        //获取生成摆药单次数
        void View_QueryListCountEven(object sender, CJia.PIVAS.Views.Label.GenLabelEventArgs e)
        {
            DataTable result = this.Model.QueryListCount();
            this.View.ExeInitButton(result);
            this.View.ExeInitIffieldGrid(result);
        }

        #endregion

        #region 补助方法

        //执行生成操作
        private void GenLabel(CJia.PIVAS.Views.Label.GenLabelEventArgs e)
        {
            List<DataRow> iffieldnames = new List<DataRow>();
            List<long> arrangeid = new List<long>();
            this.View.ExeInitSchedule(e.Illfieldids.Count);
            using (CJia.Transaction tran = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                //此查询无实际意义 只是让事务不为空 因为事务为空  提交事务会抛未将对象引用设置到对象实例异常
                CJia.DefaultOleDb.QueryScalar(tran.ID, "select 1 from dual");
                foreach(DataRow row in e.Illfieldids)
                {
                    int arrangeId = this.Model.QueryArrangeSeq();
                    if(this.Model.QueryToDayIsGenLabel(e.TimeId, row["OFFICE_ID"].ToString()))
                    {
                        iffieldnames.Add(row);
                    }
                    else
                    {
                        this.Model.InsertArrange(tran.ID,(long)arrangeId, CJia.PIVAS.User.UserId, row["OFFICE_ID"].ToString(), row["OFFICE_NAME"].ToString(), e.TimeId);
                        this.Model.InsertLabel(tran.ID,(long)arrangeId, CJia.PIVAS.User.UserId, row["OFFICE_ID"].ToString());
                        arrangeid.Add(arrangeId);
                    }
                    this.View.ExeNextSchedule();
                }
                tran.Complete();
            }
            this.View.ExeGenLabel(this.Model.QueryGenLabel(arrangeid), iffieldnames);
        }

        //执行预览操作
        private void PreviewLabel(CJia.PIVAS.Views.Label.GenLabelEventArgs e)
        {
            this.Model.DeleteTempLabel(CJia.PIVAS.User.UserId);
            List<string> illfeldidList = new List<string>();
            foreach(DataRow row in e.Illfieldids)
            {
                string a = row["OFFICE_ID"].ToString();
                illfeldidList.Add(row["OFFICE_ID"].ToString());
            }
            this.Model.InsertTempLabel(illfeldidList, CJia.PIVAS.User.UserId);
            this.View.ExeBindingCollect(this.Model.QueryTempLabelCollect(CJia.PIVAS.User.UserId));
            this.View.ExeBindingInfo(this.Model.QueryTempLabelDetail(CJia.PIVAS.User.UserId));
        }

        // 判断该操作时否在正确时间内
        private int IsCorrectTime(CJia.PIVAS.Views.Label.GenLabelEventArgs e)
        {
            DataTable result = this.Model.QueryListTime(e.TimeId);
            if(result == null || result.Rows == null || result.Rows.Count == 0)
            {
                return 0;
            }
            DateTime sysDate = CJia.PIVAS.Models.PIVASModel.QuerySysdate();
            string startDateStr = sysDate.ToString("yyyy/MM/dd ") + result.Rows[0]["START_TIME"].ToString() + ":00";
            string overDateStr = sysDate.ToString("yyyy/MM/dd ") + (result.Rows[0]["OVER_TIME"].ToString() == "" ? "23:59" : result.Rows[0]["OVER_TIME"].ToString()) + ":00";
            DateTime startDate = DateTime.Parse(startDateStr);
            DateTime overDate = DateTime.Parse(overDateStr);
            if(sysDate < overDate && sysDate > startDate)
            {
                if(e.Illfieldids == null || e.Illfieldids.Count == 0)
                {
                    return 3;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 2;
            }
        }

        #endregion



    }
}
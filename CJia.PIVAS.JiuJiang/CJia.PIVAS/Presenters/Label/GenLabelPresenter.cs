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
            if(e.Illfieldids == null || e.Illfieldids.Count == 0)
            {
                this.View.ShowMessage("您还没有选着病区！");
            }
            else
            {
                this.GenLabel(e);
            }
        }

        // 预览瓶贴
        void View_OnPreviewLabelEven(object sender, CJia.PIVAS.Views.Label.GenLabelEventArgs e)
        {
            if(e.Illfieldids == null || e.Illfieldids.Count == 0)
            {
                this.View.ShowMessage("您还没有选着病区！");
            }
            else
            {
                this.PreviewLabel(e);
            }
        }


        #endregion

        #region 补助方法

        //执行生成操作
        private void GenLabel(CJia.PIVAS.Views.Label.GenLabelEventArgs e)
        {
            List<long> arrangeid = new List<long>();
            this.View.ExeInitSchedule(e.Illfieldids.Count);
            using(CJia.Transaction tran = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                //此查询无实际意义 只是让事务不为空 因为事务为空  提交事务会抛未将对象引用设置到对象实例异常
                CJia.DefaultOleDb.QueryScalar(tran.ID, "select 1 from dual");
                foreach(DataRow row in e.Illfieldids)
                {
                    int arrangeId = this.Model.QueryArrangeSeq();
                    this.Model.InsertArrange(tran.ID, (long)arrangeId, CJia.PIVAS.User.UserId, row["OFFICE_ID"].ToString(), row["OFFICE_NAME"].ToString());
                    this.Model.InsertLabel(tran.ID, (long)arrangeId, CJia.PIVAS.User.UserId, row["OFFICE_ID"].ToString());
                    arrangeid.Add(arrangeId);
                    this.View.ExeNextSchedule();
                }
                tran.Complete();
            }
            this.View.ExeGenLabel(this.Model.QueryGenLabel(arrangeid));
        }

        //执行预览操作
        private void PreviewLabel(CJia.PIVAS.Views.Label.GenLabelEventArgs e)
        {
            this.Model.DeleteTempLabel();
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


        #endregion



    }
}
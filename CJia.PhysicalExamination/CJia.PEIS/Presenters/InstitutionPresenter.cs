using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.PEIS.Presenters
{
    public class InstitutionPresenter:CJia.PEIS.Tools.Presenter<Models.InstitutionModel,Views.IInstitutionView>
    {
        public InstitutionPresenter(Views.IInstitutionView view)
            : base(view)
        {
            this.View.OnInit += View_OnInit;
            this.View.OnInsertIns += View_OnInsertIns;
            this.View.OnUpdateIns += View_OnUpdateIns;
        }

    
        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInit(object sender, Views.InstitutionEventArgs e)
        {
            BindHigherIns();
            BindInsType();
            BIndInsInfo();
        }
        
        /// <summary>
        /// 绑定上级单位
        /// </summary>
        void BindHigherIns()
        {
            this.View.ExeBindHigherIns(Model.QueryHigherIns());
        }

        /// <summary>
        /// 绑定单位性质
        /// </summary>
        void BindInsType()
        {
            this.View.ExeBindInsType(Model.QueryInsType());
        }

        /// <summary>
        /// 绑定单位信息
        /// </summary>
        void BIndInsInfo()
        {
            this.View.ExeBindGridIns(Model.QueryInsInfo());
        }
        /// <summary>
        /// 插入单位事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInsertIns(object sender, Views.InstitutionEventArgs e)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(e.InsName);
            sqlParams.Add(e.InsType);
            sqlParams.Add(e.HigherLevelId);
            sqlParams.Add(e.InsFirstPinyin);
            sqlParams.Add(e.InsAddr);
            sqlParams.Add(e.InsPhone);
            sqlParams.Add(e.InsFax);
            sqlParams.Add(e.InsPostCode);
            sqlParams.Add(e.InsNum);
            sqlParams.Add(e.ContactName);
            sqlParams.Add(e.ContactDept);
            sqlParams.Add(e.ContactPhone);
            sqlParams.Add(e.ContactMobilePhone);
            sqlParams.Add(e.ContactFax);
            sqlParams.Add(e.ContactEmail);
            sqlParams.Add(e.Remark);
            sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
            sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
            if (Model.InsertInstitution(sqlParams))
            {
                Message.Show("【"+e.InsName+"】保存成功");
            }
            BIndInsInfo();
        }

        /// <summary>
        /// 修改单位表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnUpdateIns(object sender, Views.InstitutionEventArgs e)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(e.InsName);
            sqlParams.Add(e.InsType);
            sqlParams.Add(e.HigherLevelId);
            sqlParams.Add(e.InsFirstPinyin);
            sqlParams.Add(e.InsAddr);
            sqlParams.Add(e.InsPhone);
            sqlParams.Add(e.InsFax);
            sqlParams.Add(e.InsPostCode);
            sqlParams.Add(e.InsNum);
            sqlParams.Add(e.ContactName);
            sqlParams.Add(e.ContactDept);
            sqlParams.Add(e.ContactPhone);
            sqlParams.Add(e.ContactMobilePhone);
            sqlParams.Add(e.ContactFax);
            sqlParams.Add(e.ContactEmail);
            sqlParams.Add(e.Remark);
            sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
            sqlParams.Add(e.InsId);
            if (Model.UpdateInstitutionById(sqlParams))
            {
                Message.Show("【" + e.InsName + "】修改成功");
            }
            BIndInsInfo();
        }

    }
}

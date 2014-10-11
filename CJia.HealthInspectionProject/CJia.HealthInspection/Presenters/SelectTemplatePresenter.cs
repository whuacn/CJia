using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class SelectTemplatePresenter : CJia.HealthInspection.Tools.PresenterPage<Models.SelectTemplateModel,Views.ISelectTemplate>
    {
        public SelectTemplatePresenter(Views.ISelectTemplate view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnDropBigSelectedChanged += view_OnDropBigSelectedChanged;
            view.OnDropMiddleSelectedChanged +=view_OnDropMiddleSelectedChanged;
            view.OnSelectTemp += view_OnSelectTemp;
            view.OnQueryTempNameByIdForAdd += view_OnQueryTempNameByIdForAdd;
            view.OnQueryTempNameByIDForEdit += view_OnQueryTempNameByIDForEdit;
            view.ONQueryTempNameByIdForExeCheck += view_ONQueryTempNameByIdForExeCheck;
        }

        void view_ONQueryTempNameByIdForExeCheck(object sender, Views.SelectTemplateArgs e)
        {
            if (e.TempIDExeTemp != 0)
            {
                string TempName = Model.QueryTemplateNameById(e.TempIDExeTemp);
                View.ExeGetTempNameForExeCheck(TempName);
            }
        }

        void view_OnQueryTempNameByIDForEdit(object sender, Views.SelectTemplateArgs e)
        {
            if (e.TempIDEdit != 0)
            {
                string TempName = Model.QueryTemplateNameById(e.TempIDEdit);
                View.ExeGetTempNameForEdit(TempName);
            }
        }

        void view_OnQueryTempNameByIdForAdd(object sender, Views.SelectTemplateArgs e)
        {
            if (e.TempIDAdd != 0)
            {
                string TempName = Model.QueryTemplateNameById(e.TempIDAdd);
                View.ExeGetTempNameForAdd(TempName);
            }
        }

       

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.SelectTemplateArgs e)
        {
            DataTable dtTemp = Model.QueryAllTemplate(e.OrganId);
            View.ExeGridTemp(dtTemp);
            BindDropBigTemp();
        }

        #region【自定义方法】

        /// <summary>
        /// 绑定大分类
        /// </summary>
        void BindDropBigTemp()
        {
            View.ExeDropBig(Model.QueryBigTemplate());
        }

        /// <summary>
        /// 根据大分类绑定中分类
        /// </summary>
        /// <param name="e"></param>
        void BindDropMiddleTemp(Views.SelectTemplateArgs e)
        {
            View.ExeDropMiddle(Model.QueryMidTemplateByBig(e.SelectedBigTempId));
        }

        /// <summary>
        /// 绑定根据中分类小分类
        /// </summary>
        /// <param name="e"></param>
        void BindDropSmallTemp(Views.SelectTemplateArgs e)
        {
            View.ExeDropSmall(Model.QuerySmallTemplateByMid(e.SelectedMiddleTempId));
        }
        #endregion

        /// <summary>
        /// 根据所选大分类重新绑定中分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDropBigSelectedChanged(object sender, Views.SelectTemplateArgs e)
        {
            BindDropMiddleTemp(e);
        }

        /// <summary>
        /// 根据所选中分类重新绑定小分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDropMiddleSelectedChanged(object sender, Views.SelectTemplateArgs e)
        {
            BindDropSmallTemp(e);
        }

        /// <summary>
        /// 根据分类查询模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSelectTemp(object sender, Views.SelectTemplateArgs e)
        {
            View.ExeGridTemp(Model.QueryTemplateByType(e.BigTypeID,e.MiddleTypeID,e.SmallTypeID, e.OrganId));
        }
    }
}

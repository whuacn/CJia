//***************************************************
// 文件名（File Name）:      AssTemManPresenter.cs（评估模板维护Presenters层）
//
// 数据表（Tables）:         nothing
// 视图(Views)               nothing
//
// 作者（Author）:           郭婷
//
// 日期（Create Date）:     2013.4.7
//***************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.PEIS.Presenters
{
    /// <summary>
    /// 评估模板维护Presenter层
    /// </summary>
    public class AssTemManPresenter : CJia.PEIS.Tools.Presenter<Models.AssTemManModel, Views.IAssTemManView>
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public AssTemManPresenter(Views.IAssTemManView view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnSearch += view_OnSearch;
            view.OnStart += view_OnStart;
            view.OnStop += view_OnStop;
            view.OnAdd += view_OnAdd;
            view.OnSave += view_OnSave;
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSave(object sender, Views.AssTemEventArgs e)
        {
            //判断是修改还是新增
            bool flag = Model.IsInAssTem(e.AssTemId);
            if (flag)//修改
            {
                Model.UpdateAssTem(e.AssTemContent, e.DeptId, e.Gender, e.ContentPY, e.Remark, e.UserId, e.AssTemId);
                Message.Show("模板【" + e.AssTemId + "】修改成功");
            }
            else//新增
            {
                if (e.AssTemContent == "")
                {
                    Message.Show("模板内容不能为空！");
                    return;
                }
                Model.AddAssTem(e.AssTemId, e.AssTemContent, e.DeptId, e.Gender, e.ContentPY, e.Remark, e.UserId);
                Message.Show("模板【" + e.AssTemId + "】新增成功");
            }
        }

        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnAdd(object sender, EventArgs e)
        {
            View.ExeBindAssTemSeq(Model.GetNextNextAssTemSeq());
        }

        /// <summary>
        /// 停用事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnStop(object sender, Views.AssTemEventArgs e)
        {
            Model.UpdateAssTemToInvalid(e.AssTemId);
        }

        /// <summary>
        /// 启用事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnStart(object sender, Views.AssTemEventArgs e)
        {
            Model.UpdateAssTemToValid(e.AssTemId);
        }

        /// <summary>
        /// 搜索事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSearch(object sender, Views.AssTemEventArgs e)
        {
            DataTable dtAssTem = Model.GetAssTem(e.ContentPY, e.DeptId, e.Gender, e.IsStopAss);
            View.ExeBindAssTem(dtAssTem);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, EventArgs e)
        {
            DataTable dtDept = Model.GetDept();
            View.ExeBindDept(dtDept);

            DataTable dtGender = Model.GetGender();
            View.ExeBindGender(dtGender);

            DataTable dtAssTem = Model.GetAssTem2();
            View.ExeBindAssTem(dtAssTem);
        }
    }
}

//***************************************************
// 文件名（File Name）:      InteAssManPresenter.cs（智能评估Presenters层）
//
// 数据表（Tables）:         nothing
// 视图(Views)               nothing
//
// 作者（Author）:           郭婷
//
// 日期（Create Date）:     2013.4.9
//***************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.PEIS.Presenters
{
    /// <summary>
    /// 智能评估Presenters层
    /// </summary>
    public class InteAssManPresenter: CJia.PEIS.Tools.Presenter<Models.InteAssManModel, Views.IInteAssManView>
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public InteAssManPresenter(Views.IInteAssManView view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnSearchDeptPro += view_OnSearchDeptPro;
            view.OnSearchInteAss += view_OnSearchInteAss;
            view.OnStartInteAss += view_OnStartInteAss;
            view.OnStopInteAss += view_OnStopInteAss;
            view.OnAddInteAss += view_OnAddInteAss;
            view.OnSaveInteAss += view_OnSaveInteAss;
        }

        /// <summary>
        /// 保存模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSaveInteAss(object sender, Views.InteAssEventArgs e)
        {
            //判断是修改还是新增
            bool flag = Model.GetInteAssId(e.InteAssId);
            if (flag)//修改
            {
                Model.UpdateInteAss(e.InteAssName, e.Gender, e.MinAge, e.MaxAge, e.AssTem, e.InteAssPY, e.Remark, e.UserId, e.InteAssId);
                Message.Show("评估【" + e.InteAssName + "】修改成功");
            }
            else//新增
            {
                if (e.InteAssName == "")
                {
                    Message.Show("评估名称不能为空！");
                    return;
                }
                Model.AddInteAss(e.InteAssId,e.InteAssName, e.Gender, e.MinAge, e.MaxAge, e.AssTem, e.InteAssPY, e.Remark, e.UserId);
                Message.Show("评估【" + e.InteAssName + "】新增成功");
            }
        }
        /// <summary>
        /// 添加模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnAddInteAss(object sender, EventArgs e)
        {
            View.ExeBindNextInteAssSeq(Model.GetNextInteAssSeq());
        }
        /// <summary>
        /// 停用模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnStopInteAss(object sender, Views.InteAssEventArgs e)
        {
            Model.UpdateInteAssToInvalid(e.InteAssId);
        }
        /// <summary>
        /// 启用模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnStartInteAss(object sender, Views.InteAssEventArgs e)
        {
            Model.UpdateInteAssToValid(e.InteAssId);
        }

        /// <summary>
        /// 根据评估首拼绑定评估列表
        /// </summary>
        void view_OnSearchInteAss(object sender, Views.InteAssEventArgs e)
        {
            DataTable dtInteAss = Model.GetInteAssByPY(e.InteAssPY);
            View.ExeBindInteAssByPY(dtInteAss);
        }

        /// <summary>
        /// 根据首拼绑定科室项目列表
        /// </summary>
        void view_OnSearchDeptPro(object sender, Views.InteAssEventArgs e)
        {
            DataTable dtDeptPro = Model.GetDeptProByPY(e.DeptProPY);
            View.ExeBindDeptProByPY(dtDeptPro);
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, EventArgs e)
        {
            //绑定性别
            DataTable dtGender = Model.GetGender();
            View.ExeBindGender(dtGender);
            //绑定科室/项目
            DataTable dtDeptPro = Model.GetDeptPro();
            View.ExeBindDeptPro(dtDeptPro);
            //绑定评估列表
            DataTable dtInteAss = Model.GetInteAss();
            View.ExeBindInteAss(dtInteAss);
        }
    }
}

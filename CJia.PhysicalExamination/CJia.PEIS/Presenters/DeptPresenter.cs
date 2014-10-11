//***************************************************
// 文件名（File Name）:      DeptMode.cs
//
// 表（Tables）:            
//                          
// 视图（Views）:           
//                          
// 作者（Author）:           曾翠玲
//
// 日期（Create Date）:     2013.4.3
// 
// 修改记录（Revision History）：
//               R1：
//                   修改作者：
//                   修改日期：
//                   修改理由：
//***************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PEIS.Presenters
{
    public class DeptPresenter:CJia.PEIS.Tools.Presenter<Models.DeptMode,Views.IDeptView>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public DeptPresenter(Views.IDeptView view)
            : base(view)
        {
            this.View.OnInit +=View_OnInit;
            this.View.OnAddDept += View_OnAddDept;
            this.View.OnInsertDept += View_OnInsertDept;
            this.View.OnUpdateDept += View_OnUpdateDept;
            this.View.OnStopDept += View_OnStopDept;
            this.View.OnSearch += View_OnSearch;
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInit(object sender, Views.DeptEventArgs e)
        {
            BindDeptType();
            BIndGridDept();
        }

        /// <summary>
        /// 绑定下拉科室
        /// </summary>
        void BindDeptType()
        {
            View.ExeBindDeptType(Model.SelectDeptType());
        }

        /// <summary>
        /// 绑定科室表数据
        /// </summary>
        void BIndGridDept()
        {
            View.ExeBindGridDept(Model.SelectGridDept());
        }

        /// <summary>
        /// 新增科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnAddDept(object sender, Views.DeptEventArgs e)
        {
            View.ExeBindSortNo(Model.GetNextSortNo());
        }

        /// <summary>
        /// 插入科室表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInsertDept(object sender, Views.DeptEventArgs e)
        {
            bool isSuccess = Model.InsertDept(e.DeptName, e.SortNo, e.DeptType, e.DeptEnglishName,e.DeptFirstPinyin, e.Remark);
            if (isSuccess)
            {
                Message.Show("科室【"+e.DeptName+"】保存成功");
                BIndGridDept();
            }
        }

        /// <summary>
        /// 修改科室表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnUpdateDept(object sender, Views.DeptEventArgs e)
        {
            bool isSuccess = Model.UpdateDept(e.DeptName, e.SortNo, e.DeptType, e.DeptEnglishName,e.DeptFirstPinyin, e.Remark, e.DeptId);
            if (isSuccess)
            {
                Message.Show("科室【"+e.DeptName+"】修改成功");
                BIndGridDept();
            }
        }

        /// <summary>
        /// 停用科室事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnStopDept(object sender, Views.DeptEventArgs e)
        {
            Model.UpdateDeptByStop(e.DeptId);
            BIndGridDept();
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnSearch(object sender, Views.DeptEventArgs e)
        {
            // 所查询数据状态
            string checkStatus = "";
            if (e.IsCheckedStopDept == "N")
            {
                checkStatus = "0','1";
            }
            if (e.IsCheckedStopDept == "Y")
            {
                checkStatus = "1";
            }
            View.ExeBindGridDept(Model.SelectDeptBySearch(e.StrSearchCondition, checkStatus));
        }
    }
}

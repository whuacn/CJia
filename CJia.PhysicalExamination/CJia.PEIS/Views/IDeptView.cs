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
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.PEIS.Views
{
    public interface IDeptView:CJia.PEIS.Tools.IView
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<DeptEventArgs> OnInit;
        /// <summary>
        /// 插入科室表事件
        /// </summary>
        event EventHandler<DeptEventArgs> OnInsertDept;

        /// <summary>
        /// 点击新增按钮事件
        /// </summary>
        event EventHandler<DeptEventArgs> OnAddDept;

        /// <summary>
        /// 修改科室事件
        /// </summary>
        event EventHandler<DeptEventArgs> OnUpdateDept;

        /// <summary>
        /// 停用科室事件
        /// </summary>
        event EventHandler<DeptEventArgs> OnStopDept;

        /// <summary>
        /// 查询事件
        /// </summary>
        event EventHandler<DeptEventArgs> OnSearch;

        /// <summary>
        /// 点击新增时把排序号绑定在界面对应输入框,所取得下一个序列号
        /// </summary>
        void ExeBindSortNo(long sortNo);

        /// <summary>
        /// 绑定参数表中科室类型
        /// </summary>
        /// <param name="deptTypeId"></param>
        void ExeBindDeptType(DataTable dtDeptType);

        /// <summary>
        /// 绑定科室表数据
        /// </summary>
        /// <param name="dtGridDept"></param>
        void ExeBindGridDept(DataTable dtGridDept);
        
    }

    public class DeptEventArgs : EventArgs
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        public long DeptId = 0;

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName = "";

        /// <summary>
        /// 排序号
        /// </summary>
        public long  SortNo = 0;

        /// <summary>
        /// 部门英文名
        /// </summary>
        public string DeptEnglishName = "";

        /// <summary>
        /// 部门首拼
        /// </summary>
        public string DeptFirstPinyin = "";

        /// <summary>
        /// 部门类别
        /// </summary>
        public long DeptType = 0;

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark = "";

        /// <summary>
        /// 搜索条件
        /// </summary>
        public string StrSearchCondition = "";

        /// <summary>
        /// 是否勾选停用科室，"Y"为勾选中，"N"为未勾选
        /// </summary>
        public string IsCheckedStopDept = "N";


    }
}

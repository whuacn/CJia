//***************************************************
// 文件名（File Name）:      IInteAssManView.cs（智能评估View层）
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

namespace CJia.PEIS.Views
{
    /// <summary>
    /// 智能评估View层
    /// </summary>
    public interface IInteAssManView: CJia.PEIS.Tools.IView
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler OnInit;
        /// <summary>
        /// 搜索事件
        /// </summary>
        event EventHandler<Views.InteAssEventArgs> OnSearchDeptPro;
        /// <summary>
        /// 搜索评估事件
        /// </summary>
        event EventHandler<Views.InteAssEventArgs> OnSearchInteAss;
        /// <summary>
        /// 启用评估事件
        /// </summary>
        event EventHandler<Views.InteAssEventArgs> OnStartInteAss;
        /// <summary>
        /// 停用评估事件
        /// </summary>
        event EventHandler<Views.InteAssEventArgs> OnStopInteAss;
        /// <summary>
        /// 添加评估事件
        /// </summary>
        event EventHandler OnAddInteAss;
        /// <summary>
        /// 保存评估
        /// </summary>
        event EventHandler<Views.InteAssEventArgs> OnSaveInteAss;
        /// <summary>
        /// 绑定性别
        /// </summary>
        void ExeBindGender(DataTable dtGender);
        /// <summary>
        /// 绑定科室项目列表
        /// </summary>
        /// <param name="data"></param>
        void ExeBindDeptPro(DataTable dtDeptPro);
        /// <summary>
        /// 根据首拼绑定科室项目列表
        /// </summary>
        /// <param name="data"></param>
        void ExeBindDeptProByPY(DataTable dtDeptPro);
        /// <summary>
        /// 绑定全部评估列表
        /// </summary>
        /// <param name="dtInteAss"></param>
        void ExeBindInteAss(DataTable dtInteAss);
        /// <summary>
        /// 根据评估首拼绑定评估列表
        /// </summary>
        /// <param name="dtInteAss"></param>
        void ExeBindInteAssByPY(DataTable dtInteAss);
        /// <summary>
        /// 绑定评估Seq值
        /// </summary>
        void ExeBindNextInteAssSeq(int inteAssSeq);
    }
    /// <summary>
    /// 智能评估参数类
    /// </summary>
    public class InteAssEventArgs : EventArgs
    {
        /// <summary>
        /// 科室/项目首拼
        /// </summary>
        public string DeptProPY;
        /// <summary>
        /// 评估首拼
        /// </summary>
        public string InteAssPY;
        /// <summary>
        /// 评估ID
        /// </summary>
        public int InteAssId;
        /// <summary>
        /// 评估名称
        /// </summary>
        public string InteAssName;
        /// <summary>
        /// 性别
        /// </summary>
        public int Gender;
        /// <summary>
        /// 适用年龄（小）
        /// </summary>
        public int MinAge;
        /// <summary>
        /// 适用年龄（大）
        /// </summary>
        public int MaxAge;
        /// <summary>
        /// 模板内容
        /// </summary>
        public string AssTem;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark;
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId;
    }
}

//***************************************************
// 文件名（File Name）:      IAssTemManView.cs（模板维护View层）
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

namespace CJia.PEIS.Views
{
    /// <summary>
    /// 评估模板维护View层
    /// </summary>
    public interface IAssTemManView : CJia.PEIS.Tools.IView
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler OnInit;
        /// <summary>
        /// 搜索事件
        /// </summary>
        event EventHandler<AssTemEventArgs> OnSearch;
        /// <summary>
        /// 启用事件
        /// </summary>
        event EventHandler<AssTemEventArgs> OnStart;
        /// <summary>
        /// 停用事件
        /// </summary>
        event EventHandler<AssTemEventArgs> OnStop;
        /// <summary>
        /// 添加事件
        /// </summary>
        event EventHandler OnAdd;
        /// <summary>
        /// 保存事件
        /// </summary>
        event EventHandler<Views.AssTemEventArgs> OnSave;
        /// <summary>
        /// 绑定科室
        /// </summary>
        /// <param name="data"></param>
        void ExeBindDept(DataTable dtDept);
        /// <summary>
        /// 绑定性别
        /// </summary>
        /// <param name="data"></param>
        void ExeBindGender(DataTable dtGender);
        /// <summary>
        /// 绑定评估模板
        /// </summary>
        /// <param name="dtAssTem"></param>
        void ExeBindAssTem(DataTable dtAssTem);
        /// <summary>
        /// 取得模板内容的下一个Seq值
        /// </summary>
        void ExeBindAssTemSeq(int assTemSeq);
    }
    /// <summary>
    /// 评估模板维护参数类
    /// </summary>
    public class AssTemEventArgs : EventArgs
    {
        /// <summary>
        /// 评估模板内容拼音
        /// </summary>
        public string ContentPY;
        /// <summary>
        /// 适用科室Id
        /// </summary>
        public int DeptId;
        /// <summary>
        /// 性别
        /// </summary>
        public int Gender;
        /// <summary>
        /// 停用单选框选择状态，true表示选中，false表示未选中
        /// </summary>
        public bool IsStopAss;
        /// <summary>
        /// 模板Id
        /// </summary>
        public int AssTemId;
        /// <summary>
        /// 模板内容
        /// </summary>
        public string AssTemContent;
        /// <summary>
        /// 模板备注
        /// </summary>
        public string Remark;
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId;
    }
}

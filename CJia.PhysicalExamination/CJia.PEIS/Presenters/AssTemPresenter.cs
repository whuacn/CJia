//***************************************************
// 文件名（File Name）:      AssTem.cs（添加评估模板Presenter层）
//
// 数据表（Tables）:         nothing
// 视图(Views)               nothing
//
// 作者（Author）:           郭婷
//
// 日期（Create Date）:     2013.4.12
//***************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.PEIS.Presenters
{
    /// <summary>
    /// 添加评估模板Presenter层
    /// </summary>
    public class AssTemPresenter : CJia.PEIS.Tools.Presenter<Models.AssTemModel, Views.IAssTemView>
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public AssTemPresenter(Views.IAssTemView view)
            : base(view)
        {
        }
    }
}

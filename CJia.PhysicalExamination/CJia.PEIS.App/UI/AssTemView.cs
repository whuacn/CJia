//***************************************************
// 文件名（File Name）:      AssTem.cs（添加评估模板UI层）
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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.PEIS.App.UI
{
    /// <summary>
    /// 添加评估模板UI层
    /// </summary>
    public partial class AssTemView : UserControl
    {
        public AssTemView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 带参数的构造函数
        /// </summary>
        public AssTemView(string assTem)
        {
            InitializeComponent();
            BindAssTem(assTem);
        }
        /// <summary>
        /// 绑定评估模板内容
        /// </summary>
        /// <param name="assTem"></param>
        public void BindAssTem(string assTem)
        {
            mlAssTem.Text = assTem;
        }
    }
}

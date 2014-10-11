using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.PIVAS.App.UI.Label
{
    /// <summary>
    /// 显示生成后的瓶贴用户控件
    /// </summary>
    public partial class GenLabelResultView : DevExpress.XtraEditors.XtraUserControl
    {
        public GenLabelResultView()
        {
            InitializeComponent();
        }

        #region 外部事件 方法

        /// <summary>
        /// 生成结果数据绑定
        /// </summary>
        /// <param name="result"></param>
        public void BindData(DataTable result)
        {
            this.grcLabelDetail.DataSource = result;
            this.grvLabelDetail.ExpandAllGroups();
        }

        #endregion

    }
}

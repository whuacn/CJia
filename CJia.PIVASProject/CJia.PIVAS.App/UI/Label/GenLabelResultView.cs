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
        /// <param name="illfields"></param>
        public void BindData(DataTable result, List<DataRow> illfields)
        {
            this.grcLabelDetail.DataSource = result;
            this.grvLabelDetail.ExpandAllGroups();
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("OFFICE_NAME");
            dt.Columns.Add(dc);
            foreach(DataRow row in illfields)
            {
                DataRow nr = dt.NewRow();
                nr["OFFICE_NAME"] = row["OFFICE_NAME"];
                dt.Rows.Add(nr);
            }
            this.grdIllfield.DataSource = dt;
        }

        #endregion

    }
}

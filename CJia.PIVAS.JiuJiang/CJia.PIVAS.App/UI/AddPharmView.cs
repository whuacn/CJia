using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.PIVAS.App.UI
{
    public partial class AddPharmView : UserControl
    {
        public AddPharmView()
        {
            InitializeComponent();
        }

        public DataTable PharmData = null;

        private DataTable PharmFilter = null;

        CJia.PIVAS.App.UI.Label.FilterPharmView filterPharmView = new Label.FilterPharmView();

        public event CJia.PIVAS.Tools.Delegate.ResNoPar AddPharm;

        public void BindPharmData(DataTable pharmData, DataTable pharmFilter)
        {
            this.PharmFilter = pharmFilter;
            this.PharmData = pharmData;
            this.FilterZero();
            this.FilterPharm();
        }

        /// <summary>
        /// 过滤0节约药物
        /// </summary>
        private void FilterZero()
        {
            if (this.PharmData != null && this.PharmData.Rows != null && this.PharmData.Rows.Count > 0)
            {
                if (this.cbFilterZero.Checked == true)
                {
                    DataTable result = CJia.PIVAS.Tools.Helper.GetDataSource(this.PharmData.Select(" ALL_ECONOMIZE_PHARM_AMOUNT <> 0 "));
                    this.gcPharm.DataSource = result;
                    this.PharmData = result;
                }
                else
                {
                    this.gcPharm.DataSource = this.PharmData;
                }
            }
            else
            {
                this.gcPharm.DataSource = this.PharmData;
            }
        }

        private void FilterPharm()
        {
            if (this.PharmFilter != null && this.PharmFilter.Rows != null && this.PharmFilter.Rows.Count > 0)
            {
                if (this.PharmFilter.Columns.IndexOf("ISCHECK") == -1)
                {
                    DataColumn select = new DataColumn("ISCHECK", typeof(System.Boolean));
                    this.PharmFilter.Columns.Add(select);
                    for (int i = 0; i < this.PharmFilter.Rows.Count; i++)
                    {
                        this.PharmFilter.Rows[i]["ISCHECK"] = true;
                    }
                }

                foreach (DataRow row in this.PharmFilter.Rows)
                {
                    row["ISCHECK"] = false;
                }

                if (this.PharmData != null && this.PharmData.Rows != null && this.PharmData.Rows.Count > 0)
                {
                    foreach (DataRow row in this.PharmData.Rows)
                    {
                        DataRow[] results = this.PharmFilter.Select(" PHARM_ID =  '" + row["PHARM_ID"] + "' and UNITS = '" + row["PHARM_UNIT"].ToString() + "'");
                        foreach (DataRow result in results)
                        {
                            result["ISCHECK"] = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 以窗口形式显示
        /// </summary>
        /// <param name="Caption"></param>
        /// <param name="UControl"></param>
        public void ShowAsWindow(string Caption, System.Windows.Forms.UserControl UControl)
        {
            System.Windows.Forms.Form frmBase = new System.Windows.Forms.Form();
            frmBase.Text = Caption;
            frmBase.FormBorderStyle = FormBorderStyle.FixedDialog;
            frmBase.MaximizeBox = false;
            frmBase.MinimizeBox = false;

            frmBase.Size = new System.Drawing.Size(UControl.Width + 15, UControl.Height + 30);
            frmBase.AutoSize = true;
            frmBase.StartPosition = FormStartPosition.CenterScreen;
            frmBase.KeyPreview = true;
            //UControl.Dock = DockStyle.Fill;
            frmBase.Controls.Add(UControl);
            //UControl.Parent = frmBase;
            UControl.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top);
            frmBase.ShowDialog();
        }

        private void btnAddPharm_Click(object sender, EventArgs e)
        {
            if (this.PharmData == null && this.PharmData.Rows == null && this.PharmData.Rows.Count == 0)
            {
                Message.Show("没有需要入库的药品！");
                return;
            }
            else
            {
                //DataRow[] rows = this.PharmData.Select(" ALL_ECONOMIZE_PHARM_AMOUNT <> 0 ");
                //if(rows == null || rows.Length == 0)
                //{
                //    MessageBox.Show("没有需要入库的药品！");
                //    return;
                //}
            }
            string result = this.AddPharm().ToString();
            if (result == "True")
            {
                Message.Show("药品入库成功！");
                this.FindForm().Close();
            }
            else
            {
                Message.Show("药品入库失败！");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable data = (DataTable)this.gcPharm.DataSource;
            if (data != null && data.Rows != null && data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    int start = data.Rows[i]["FLAG"].ToString().ToUpper().IndexOf(this.txtSearch.Text.Trim().ToUpper());
                    if (start != -1)
                    {
                        this.gridView1.MoveFirst();
                        this.gridView1.MoveBy(i);
                        return;
                    }
                }
            }
        }

        private void btnFilterPharm_Click(object sender, EventArgs e)
        {
            filterPharmView.BindData(this.PharmFilter);
            this.ShowAsWindow("增加药品", filterPharmView);
            DataTable result = new DataTable();

            if (this.PharmData == null)
            {
                result.Columns.Add("PHARM_ID");
                result.Columns.Add("PHARM_NAME");
                result.Columns.Add("PHARM_SPEC");
                result.Columns.Add("PHARM_FACTORY");
                result.Columns.Add("ALL_ECONOMIZE_PHARM_AMOUNT");
                result.Columns.Add("ADD_PHARM_COUNT");
                result.Columns.Add("PHARM_UNIT");
            }
            else
            {
                result = this.PharmData.Clone();
            }

            foreach (DataRow row in this.PharmFilter.Rows)
            {
                if (row["ISCHECK"].ToString() == "True")
                {
                    DataRow[] selectRows = null;
                    if (PharmData != null)
                    {
                        selectRows = this.PharmData.Select(" PHARM_ID = '" + row["PHARM_ID"] + "' and PHARM_UNIT = '" + row["UNITS"].ToString() + "'");
                    }
                    if (selectRows != null && selectRows.Length > 0)
                    {
                        CJia.PIVAS.Tools.Helper.DataAddRow(result, selectRows);
                    }
                    else
                    {
                        DataRow newRow = result.NewRow();
                        newRow["PHARM_ID"] = row["PHARM_ID"];
                        newRow["PHARM_NAME"] = row["PHARM_NAME"];
                        newRow["PHARM_SPEC"] = row["PHARM_SPEC"];
                        newRow["PHARM_FACTORY"] = row["PHARM_FACTION"];
                        newRow["ALL_ECONOMIZE_PHARM_AMOUNT"] = 0;
                        newRow["ADD_PHARM_COUNT"] = 0;
                        newRow["PHARM_UNIT"] = row["UNITS"];
                        result.Rows.Add(newRow);
                    }
                }
            }

            this.PharmData = result;
            this.gcPharm.DataSource = this.PharmData;
        }
    }
}

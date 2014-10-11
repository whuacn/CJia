using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

namespace CJia.PIVAS.App.UI.Label
{
    public partial class NewFilterPatientView : XtraUserControl
    {
        /// <summary>
        /// 赛选瓶贴用户控件
        /// </summary>
        public NewFilterPatientView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取选择的病人
        /// </summary>
        public DataTable selectPatient
        {
            get
            {
                DataTable patient = (DataTable)this.gcPatient.DataSource;
                if(patient != null && patient.Rows != null && patient.Rows.Count > 0)
                {
                    DataTable selectPatient = this.GetDataSource(patient.Select(" ISCHECK = true "));
                    return selectPatient;
                }
                else
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// 绑定所有病人
        /// </summary>
        /// <param name="patient"></param>
        public void BindData(DataTable Patient)
        {
            DataColumn select = new DataColumn("ISCHECK", typeof(System.Boolean));
            if(Patient != null && Patient.Rows != null && Patient.Rows.Count > 0)
            {
                Patient.Columns.Add(select);
                for(int i = 0; i < Patient.Rows.Count; i++)
                {
                    Patient.Rows[i]["ISCHECK"] = true;
                }
            }
            this.gcPatient.DataSource = Patient;
        }

        /// <summary>
        /// 获取选着的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnter_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void ckeBen_CheckedChanged(object sender, EventArgs e)
        {
            DataTable pharm = (DataTable)this.gcPatient.DataSource;
            if(pharm != null && pharm.Rows != null && pharm.Rows.Count > 0)
            {
                for(int i = 0; i < pharm.Rows.Count; i++)
                {
                    if(this.ckeBen.Checked)
                    {
                        pharm.Rows[i]["ISCHECK"] = true;
                    }
                    else
                    {
                        pharm.Rows[i]["ISCHECK"] = false;
                    }
                }
            }
        }

        /// <summary>
        //　将ROW数组转成datatable
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        private DataTable GetDataSource(DataRow[] rows)
        {
            if(rows != null && rows.Length != 0)
            {
                DataTable result = rows[0].Table.Clone();
                for(int i = 0; i < rows.Length; i++)
                {
                    DataRow row = result.NewRow();
                    row.ItemArray = rows[i].ItemArray;
                    result.Rows.Add(row);
                }
                return result;
            }
            return null;
        }
    }
}

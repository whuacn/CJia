using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Health.App.UI
{
    public partial class MyPatientInputView : CJia.Health.Tools.View, Views.IMyPatientInputView
    {
        public MyPatientInputView()
        {
            InitializeComponent();
            crbCheckState.SelectedIndex = 0;
            //Init();
            ckPatient.CheckedChanged += ckPatient_CheckedChanged;
        }

        void ckPatient_CheckedChanged(object sender, EventArgs e)
        {
            string value = this.patientView.GetFocusedDataRow()["ISCHECK"].ToString();
            if (value == "" || value == "False")
            {
                this.patientView.GetFocusedDataRow()["ISCHECK"] = true;
            }
            else
            {
                this.patientView.GetFocusedDataRow()["ISCHECK"] = false;
            }
            this.patientGrid.RefreshDataSource();
        }
        protected override object CreatePresenter()
        {
            return new Presenters.MyPatientInputPresenter(this);
        }
        /// <summary>
        /// 参数
        /// </summary>
        Views.MyPatientInputArgs myPatientInputArgs = new Views.MyPatientInputArgs();

        #region 内部调用方法
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            if (OnCheckSateChanged != null)
            {
                int index = crbCheckState.SelectedIndex;
                myPatientInputArgs.CheckSate = crbCheckState.Properties.Items[index].Value.ToString();
                OnCheckSateChanged(null, myPatientInputArgs);
            }
        }
        /// <summary>
        /// 获得选中的病人表id
        /// </summary>
        /// <returns></returns>
        public List<string> GetCheckPatient()
        {
            if (patientView.GetFocusedDataRow() != null)
            {
                List<string> list = new List<string>();
                DataTable data = patientGrid.DataSource as DataTable;
                foreach (DataRow dr in data.Rows)
                {
                    if (dr["ISCHECK"].ToString() == "True")
                    {
                        string ID = dr["ID"].ToString();
                        list.Add(ID);
                    }
                }
                return list;
            }
            return null;
        }
        #endregion

        #region IMyPatientInputView成员
        public event EventHandler<Views.MyPatientInputArgs> OnDelete;
        public event EventHandler<Views.MyPatientInputArgs> OnCommit;
        public event EventHandler<Views.MyPatientInputArgs> OnUndo;
        public event EventHandler<Views.MyPatientInputArgs> OnCheckSateChanged;
        public event EventHandler<Views.MyPatientInputArgs> OnPrint;
        public void ExeBindMyPatient(DataTable data)
        {
            patientGrid.DataSource = data;
        }
        #endregion

        private void crbCheckState_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index=crbCheckState.SelectedIndex;
            if (index == 1)
            {
                btnDelete.Enabled = true;
                btnUndo.Enabled = false;
                btnCommit.Enabled = true;
            }
            else if (index == 3)
            {
                btnDelete.Enabled = false;
                btnUndo.Enabled = true;
                btnCommit.Enabled = false;
            }
            else if (index == 0)
            {
                btnDelete.Enabled = true;
                btnUndo.Enabled = false;
                btnCommit.Enabled = false;
            }
            else if (index == 2)
            {
                btnDelete.Enabled = true;
                btnUndo.Enabled = false;
                btnCommit.Enabled = false;
            }
            else if (index == 4)
            {
                btnDelete.Enabled = true;
                btnUndo.Enabled = false;
                btnCommit.Enabled = false;
            }
            Init();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<string> list = GetCheckPatient();
            if (list != null && list.Count > 0)
            {
                if (Message.ShowQuery("确认删除吗？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    if (OnDelete != null)
                    {
                        myPatientInputArgs.HealthID = list;
                        OnDelete(sender, myPatientInputArgs);
                        Init();
                    }
                }
            }
        }

        private void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAll.Checked)
            {
                if (patientView.GetFocusedDataRow() != null)
                {
                    DataTable data = patientGrid.DataSource as DataTable;
                    foreach (DataRow dr in data.Rows)
                    {
                        dr["ISCHECK"] = true;
                    }
                }
            }
            else
            {
                if (patientView.GetFocusedDataRow() != null)
                {
                    DataTable data = patientGrid.DataSource as DataTable;
                    foreach (DataRow dr in data.Rows)
                    {
                        dr["ISCHECK"] = false;
                    }
                }
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            List<string> list = GetCheckPatient();
            if (list != null && list.Count > 0)
            {
                if (OnCommit != null)
                {
                    myPatientInputArgs.HealthID = list;
                    OnCommit(sender, myPatientInputArgs);
                    Init();
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            List<string> list = GetCheckPatient();
            if (list != null && list.Count > 0)
            {
                if (OnUndo != null)
                {
                    myPatientInputArgs.HealthID = list;
                    OnUndo(sender, myPatientInputArgs);
                    Init();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<string> list = GetCheckPatient();
            if (list != null && list.Count > 0)
            {
                myPatientInputArgs.HealthID = list;
                OnPrint(null, myPatientInputArgs);
            }
        }
    }
}

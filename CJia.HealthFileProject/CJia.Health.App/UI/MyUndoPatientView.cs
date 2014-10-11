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
    public partial class MyUndoPatientView : CJia.Health.Tools.View,Views.IMyUndoPatientView
    {
        public MyUndoPatientView()
        {
            InitializeComponent();
            Init();
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
            return new Presenters.MyUndoPatientPresenter(this);
        }
        /// <summary>
        /// 参数
        /// </summary>
        Views.MyUndoPatientArgs myUndoPatientArgs = new Views.MyUndoPatientArgs();

        #region IMyUndoPatientView成员
        public event EventHandler<Views.MyUndoPatientArgs> OnLoadUndoPatient;
        public event EventHandler<Views.MyUndoPatientArgs> OnCommit;
        public event EventHandler<Views.MyUndoPatientArgs> OnDelete;
        public void ExeBindPatient(DataTable data)
        {
            patientGrid.DataSource = data;
        }
        #endregion
        #region 内部调用方法
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            if (OnLoadUndoPatient != null)
            {
                OnLoadUndoPatient(null, null);
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<string> list = GetCheckPatient();
            if (list != null && list.Count > 0)
            {
                if (Message.ShowQuery("确认删除吗？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    if (OnDelete != null)
                    {
                        myUndoPatientArgs.HealthID = list;
                        OnDelete(sender, myUndoPatientArgs);
                        Init();
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
                    myUndoPatientArgs.HealthID = list;
                    OnCommit(sender, myUndoPatientArgs);
                    Init();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Init();
        }
    }
}

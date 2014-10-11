using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CJia.CheckRegOrder.App.UI
{
    public partial class RegNoCheckView : CJia.Editors.View, Views.IRegNoCheckView
    {
        public RegNoCheckView()
        {
            InitializeComponent();
            Load(null, null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.RegNoCheckPresenter(this);
        }
        /// <summary>
        /// 登记未排队检查病人参数设置
        /// </summary>
        Views.RegNoCheckArgs regNoCheckArgs = new Views.RegNoCheckArgs();
        #region IRegNoCheckView成员
        public int? PatientID
        {
            get
            {
                if (gvRegNoCheckPatient.GetFocusedDataRow() != null)
                    return int.Parse(gvRegNoCheckPatient.GetFocusedDataRow()["patient_id"].ToString());
                else return null;
            }
        }
        public string PatientName
        {
            get { return gvRegNoCheckPatient.GetFocusedDataRow()["patient_name"].ToString(); }
        }
        public event EventHandler Load;
        public event EventHandler<Views.RegNoCheckArgs> OnDelete;
        public void ExeBindRegNoCheckPatient(DataTable data)
        {
            gcRegNoCheckPatient.DataSource = data;
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(PatientID!=null)
            {
                if (Message.ShowQuery("确定删除病人【" + PatientName + "】吗？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    regNoCheckArgs.PatientID = PatientID;
                    OnDelete(sender, regNoCheckArgs);
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.HISOLAP.Views;

namespace CJia.HISOLAP.App.UI.HQMS
{
    public partial class CheckScript : CJia.HISOLAP.Tools.View, Views.ICheckScript
    {
        public CheckScript()
        {
            InitializeComponent();
            if (OnInitView != null)
                OnInitView(null, null);
        }
        protected override object CreatePresenter()
        {
            return new Presenters.CheckScriptPresenter(this);
        }
        CheckScriptArgs checkScriptArgs = new CheckScriptArgs();
        public event EventHandler OnInitView;
        public event EventHandler<CheckScriptArgs> OnDelete;
        public event EventHandler<CheckScriptArgs> OnSearch;
        public event EventHandler<CheckScriptArgs> OnAdd;
        public event EventHandler<CheckScriptArgs> OnModify;
        public event EventHandler OnQueryCheckType;
        public void ExeBindCheckTypeData(DataTable data) { }
        public void ExeIsSuccessAdd(bool bol) { }
        public void ExeIsSuccessModify(bool bol) { }
        public void ExeFocusNO() { }
        public void ExeBindData(DataTable data)
        {
            cgScript.DataSource = data;
        }
        public void ExeIsSuccessDelete(bool bol)
        {
            if (bol)
            {
                if (OnInitView != null)
                    OnInitView(null, null);
            }
            else
            {
                Message.Show("删除失败！");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvScript.GetFocusedDataRow() != null)
            {
                int i = gvScript.FocusedRowHandle;
                if (Message.ShowQuery("确定删除？", Message.Button.OkCancel) == Message.Result.Ok)
                {
                    checkScriptArgs.ID = gvScript.GetFocusedDataRow()["ID"].ToString();
                    OnDelete(null, checkScriptArgs);
                }
                gvScript.FocusedRowHandle = i;
            }
        }

        private void cJiaTextSearch1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (cJiaTextSearch1.Text.Trim().Length > 0)
            {
                checkScriptArgs.Key = cJiaTextSearch1.Text;
                OnSearch(null, checkScriptArgs);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (gvScript.GetFocusedDataRow() != null)
            {
                gvScript.MoveFirst();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (gvScript.GetFocusedDataRow() != null)
            {
                gvScript.MovePrev();
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (gvScript.GetFocusedDataRow() != null)
            {
                gvScript.MoveNext();
            }
        }

        private void btnLeast_Click(object sender, EventArgs e)
        {
            if (gvScript.GetFocusedDataRow() != null)
            {
                gvScript.MoveLast();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int i = gvScript.FocusedRowHandle;
            EditCheckScriptView uc = new EditCheckScriptView(EditCheckScriptView.Type.Add, null);
            CJia.HISOLAP.Tools.Help.NewRedBorderFrom(uc);
            if (OnInitView != null)
                OnInitView(null, null);
            gvScript.FocusedRowHandle = i;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (gvScript.GetFocusedDataRow() != null)
            {
                int i = gvScript.FocusedRowHandle;
                DataRow dr = gvScript.GetFocusedDataRow();
                EditCheckScriptView uc = new EditCheckScriptView(EditCheckScriptView.Type.Modify, dr);
                CJia.HISOLAP.Tools.Help.NewRedBorderFrom(uc);
                if (OnInitView != null)
                    OnInitView(null, null);
                gvScript.FocusedRowHandle = i;
            }
        }

        private void gvScript_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                string stutas = this.gvScript.GetDataRow(e.RowHandle)["STATUS"].ToString();
                if (stutas == "0")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }
        }

        private void btnRefresh1_Click(object sender, EventArgs e)
        {
            if (OnInitView != null)
                OnInitView(null, null);
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    btnRefresh1.Focus();
                    btnRefresh1_Click(null, null);
                    return true;
                case Keys.F1:
                    btnFirst.Focus();
                    btnFirst_Click(null, null);
                    return true;
                case Keys.F2:
                    btnUp.Focus();
                    btnUp_Click(null, null);
                    return true;
                case Keys.F3:
                    btnDown.Focus();
                    btnDown_Click(null, null);
                    return true;
                case Keys.F4:
                    btnLeast.Focus();
                    btnLeast_Click(null, null);
                    return true;
                case Keys.F6:
                    btnDelete.Focus();
                    btnDelete_Click(null, null);
                    return true;
                case Keys.F7:
                    btnAdd.Focus();
                    btnAdd_Click(null, null);
                    return true;
                case Keys.F8:
                    btnModify.Focus();
                    btnModify_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

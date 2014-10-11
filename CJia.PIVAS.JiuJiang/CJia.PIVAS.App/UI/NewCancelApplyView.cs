
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CJia.PIVAS.Views;
using SpeechLib;

namespace CJia.PIVAS.App.UI
{
    /// <summary>
    /// 退药处理表示层
    /// </summary>
    public partial class NewCancelApplyView : Tools.View, Views.INewCancelApplyView
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public NewCancelApplyView()
        {
            InitializeComponent();
            Load(null, null);
            dtpQueryTime.Value = Sysdate;
        }

        protected override object CreatePresenter()
        {
            return new Presenters.NewCancelApplyPresenter(this);
        }

        NewCancelApplyArgs newCancelApplyArgs = new NewCancelApplyArgs();

        #region INewCancelApplyView成员
        public event EventHandler Load;
        public event EventHandler<NewCancelApplyArgs> OnOkCancel;
        public event EventHandler<NewCancelApplyArgs> OnRefuseApply;
        public event EventHandler<NewCancelApplyArgs> OnCancelPreview;
        public event EventHandler<NewCancelApplyArgs> OnBtnSelect;
        public event EventHandler<NewCancelApplyArgs> OnBtnDelete;



        public void ExeDeleteReturn(string mes,bool isSucceess)
        {
            if(isSucceess)
            {
                this.lblMessage.BackColor = Color.Green;
                this.lblMessage.ForeColor = Color.White;
                this.lblMessage.Text = mes;
                this.SpeakMessage("成功");
            }
            else
            {
                this.lblMessage.BackColor = Color.LightGray;
                this.lblMessage.ForeColor = Color.Red;
                this.lblMessage.Text = mes;
                this.SpeakMessage(mes);
            }
        }

        public void ExeBindGridCancelApply(DataTable dtCancelApply)
        {
            gcCancel.MainView = gvCancel;
            gcCancel.DataSource = dtCancelApply;
            this.repositoryItemLookUpEdit2.DataSource = dtCancelApply;
            gvCancel.ExpandAllGroups();
            ckAll.Visible = ckNo.Visible = true;
        }

        public void ExeBindOfficeName(DataTable dtOfficeName)
        {
            //cbOfficeName.DataSource = dtOfficeName;
            //cbOfficeName.DisplayMember = "OFFICE_NAME";
            //cbOfficeName.ValueMember = "OFFICE_ID";
            AddOfficeNameItem(dtOfficeName);
        }

        public void ExeBindPrintApplyCancelPharm(DataTable dtCheckedPharm)
        {

        }
        public void ExeBindBarCode(DataTable data)
        {
            gcCancel.DataSource = data;
            this.repositoryItemLookUpEdit1.DataSource = data;
            gcCancel.MainView = gvBarCode;
            ckAll.Visible = ckNo.Visible = false;
        }
        #endregion

        #region 界面事件

        private void gvBarCode_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if(e.RowHandle >= 0)
            {
                string stutas = this.gvBarCode.GetDataRow(e.RowHandle)["STATUS"].ToString();
                if(stutas == "1000603")
                {
                    e.Appearance.BackColor = Color.Green;
                }
                else
                {
                    e.Appearance.BackColor = Color.LightGray;
                }

            }
        }


        bool oldIsEnter = false;
        private void txtZFPT_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                oldIsEnter = true;
                this.btnDelect_Click(null, null);
            }
            else
            {
                if(oldIsEnter)
                {
                    this.txtZFPT.Text = "";
                }
                oldIsEnter = false;
            }
        }


        List<string> labelBarIdList
        {
            get
            {
                List<string> list = new List<string>();
                string[] barIds = this.txtBarCode.Text.Trim().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if(barIds != null)
                {
                    for(int i = 0; i < barIds.Length; i++)
                    {
                        list.Add(barIds[i]);
                    }
                }
                return list;
            }
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                this.txtBarCode.Text = this.txtBarCode.Text.Trim() + ";";
            }
            this.txtBarCode.Select(this.txtBarCode.Text.Length + 1, 0);
        }

        //全选病区
        private void cbAllOffice_CheckedChanged(object sender, EventArgs e)
        {
            if(cbAllOffice.Checked)
            {
                cbOfficeName.CheckAll();
            }
            else
            {
                cbOfficeName.UnCheckAll();
            }
        }
        //预览申请
        private void btnCancelPreview_Click(object sender, EventArgs e)
        {
            if(OnCancelPreview != null)
            {
                newCancelApplyArgs.IllFieldId = GetSelectIllfield();
                newCancelApplyArgs.Date = dtpQueryTime.Value;
                OnCancelPreview(sender, newCancelApplyArgs);
            }
        }
        //拒绝申退
        private void btnRefuseApply_Click(object sender, EventArgs e)
        {
            if(gvCancel.GetFocusedDataRow() != null && OnRefuseApply != null)
            {
                if(GetLabelInfo().Count > 0)
                {
                    if(Message.ShowQuery("是否确定拒绝退药？", Message.Button.YesNo) == Message.Result.Yes)
                    {
                        newCancelApplyArgs.LabelID = GetLabelInfo();
                        OnRefuseApply(sender, newCancelApplyArgs);
                        btnCancelPreview_Click(null, null);
                    }
                }
                else
                {
                    Message.Show("请勾选你要拒绝申请退药的医嘱！");
                }
            }
        }
        //确定退药
        private void btnOkCancel_Click(object sender, EventArgs e)
        {
            if(gvCancel.GetFocusedDataRow() != null && OnRefuseApply != null)
            {
                if(GetLabelInfo().Count > 0)
                {
                    if(Message.ShowQuery("是否确定退药？", Message.Button.YesNo) == Message.Result.Yes)
                    {
                        newCancelApplyArgs.LabelID = GetLabelInfo();
                        newCancelApplyArgs.AdviceID = GetAdviceID();
                        OnOkCancel(sender, newCancelApplyArgs);
                        btnCancelPreview_Click(null, null);
                    }
                }
                else
                {
                    Message.Show("请勾选你要确定退药的医嘱！");
                }
            }
        }
        private void cbOfficeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbOfficeName.CheckedItemsCount == cbOfficeName.ItemCount)
            {
                cbAllOffice.Checked = true;
            }
            else
            {
                cbAllOffice.Checked = false;
            }
        }
        /// <summary>
        /// 退药申请列表选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            string value = "";
            string Index = this.gvCancel.GetFocusedDataRow()["LABEL_NO"].ToString();
            value = this.gvCancel.GetFocusedDataRow()["ISCHECK"].ToString();
            DataTable dt = gcCancel.DataSource as DataTable;
            foreach(DataRow dr in dt.Rows)
            {
                if(dr["LABEL_NO"].ToString() == Index)
                {
                    if(value == "" || value == "False")
                    {
                        dr["ISCHECK"] = true;
                    }
                    else
                    {
                        dr["ISCHECK"] = false;
                    }
                }
            }
            this.gcCancel.RefreshDataSource();
        }
        private void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            if(ckAll.Checked)
            {
                ckNo.Checked = false;
                DataTable dt = gcCancel.DataSource as DataTable;
                if(dt != null && dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        dr["ISCHECK"] = true;
                    }
                }
            }
        }
        private void ckNo_CheckedChanged(object sender, EventArgs e)
        {
            if(ckNo.Checked)
            {
                ckAll.Checked = false;
                DataTable dt = gcCancel.DataSource as DataTable;
                if(dt != null && dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        dr["ISCHECK"] = false;
                    }
                }
            }
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            HelperTools.GridViewLocationcs gridViewLocationcs = new HelperTools.GridViewLocationcs(this.gvBarCode);
            gridViewLocationcs.GetLocation();
            if(labelBarIdList != null && labelBarIdList.Count > 0 && OnBtnSelect != null)
            {
                newCancelApplyArgs.barCodeList = labelBarIdList;
                OnBtnSelect(sender, newCancelApplyArgs);
            }
            else
            {
                txtBarCode.Focus();
            }
            gridViewLocationcs.SetLocation();

        }

        private void btnDelect_Click(object sender, EventArgs e)
        {
            if(txtBarCode.Text.Trim().Length > 0 && OnBtnDelete != null)
            {
                newCancelApplyArgs.BarCodeID = this.txtZFPT.Text.Trim();
                newCancelApplyArgs.barCodeList = labelBarIdList;
                OnBtnDelete(sender, newCancelApplyArgs);
                btnSelect_Click(null, null);
            }
            else
            {
                txtBarCode.Focus();
            }
        }

        private void btnDeleteF_Click(object sender, EventArgs e)
        {
            if(txtBarCode.Text.Trim().Length > 0 && OnBtnDelete != null)
            {
                newCancelApplyArgs.BarCodeID = txtBarCode.Text.Trim();
                newCancelApplyArgs.btnStyle = "DeleteF";
                OnBtnDelete(sender, newCancelApplyArgs);
                btnSelect_Click(null, null);
            }
            else
            {
                txtBarCode.Focus();
            }
        }

        #endregion

        #region 内部调用方法
        /// <summary>
        /// 获得选择的病区
        /// </summary>
        /// <returns></returns>
        public List<string> GetSelectIllfield()
        {
            List<string> illfield = new List<string>();
            for(int j = 0; j < cbOfficeName.ItemCount; j++)
            {
                if(this.cbOfficeName.Items[j].CheckState == CheckState.Checked)
                {
                    illfield.Add("'" + cbOfficeName.Items[j].Value.ToString() + "'");
                }
            }
            return illfield;
        }
        /// <summary>
        /// 绑定病区item
        /// </summary>
        /// <param name="dtOfficeName"></param>
        public void AddOfficeNameItem(DataTable dtOfficeName)
        {
            for(int i = 0; i < dtOfficeName.Rows.Count; i++)
            {
                this.cbOfficeName.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
                new DevExpress.XtraEditors.Controls.CheckedListBoxItem(dtOfficeName.Rows[i]["office_id"], dtOfficeName.Rows[i]["office_name"].ToString(), CheckState.Checked)});
            }
        }
        /// <summary>
        /// 获得选择的瓶贴id信息
        /// </summary>
        public List<string> GetLabelInfo()
        {
            List<string> list = new List<string>();
            int count = ((DataTable)gcCancel.DataSource).Rows.Count;
            for(int i = 0; i < count; i++)
            {
                if(gvCancel.GetDataRow(i)["ISCHECK"].ToString() == "True")
                {
                    string labelID = gvCancel.GetDataRow(i)["LABEL_ID"].ToString();
                    list.Add(labelID);
                }
            }
            return list;
            //List<string> newList = new List<string>();
            //for(int j = 0; j < list.Count; j++)
            //{
            //    if(newList.Count != 0)
            //    {
            //        bool bol = false;
            //        for(int k = 0; k < newList.Count; k++)
            //        {
            //            if(list[j] == newList[k])
            //            {
            //                bol = true;
            //            }
            //        }
            //        if(!bol)
            //        {
            //            newList.Add(list[j]);
            //        }
            //    }
            //    else
            //    {
            //        newList.Add(list[j]);
            //    }
            //}
            //return newList;
        }
        /// <summary>
        /// 获得选择的医嘱id
        /// </summary>
        /// <returns></returns>
        public List<string> GetAdviceID()
        {
            List<string> list = new List<string>();
            int count = ((DataTable)gcCancel.DataSource).Rows.Count;
            for(int i = 0; i < count; i++)
            {
                if(gvCancel.GetDataRow(i)["ISCHECK"].ToString() == "True")
                {
                    string adviceID = gvCancel.GetDataRow(i)["HIS_ADVICE_ID"].ToString();
                    list.Add(adviceID);
                }
            }
            return list;
        }
        /// <summary>
        /// 朗读语音提示信息
        /// </summary>
        /// <param name="text"></param>
        private void SpeakMessage(string text)
        {
            try
            {
                SpeechVoiceSpeakFlags SpFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
                SpVoice Voice = new SpVoice();
                Voice.Rate = 2;
                Voice.Speak(text, SpFlags);
            }
            catch
            {

            }
        }
        #endregion



    }
}

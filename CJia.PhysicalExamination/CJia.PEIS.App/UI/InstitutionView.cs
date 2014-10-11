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
    public partial class InstitutionView : CJia.PEIS.Tools.View, CJia.PEIS.Views.IInstitutionView
    {
        public InstitutionView()
        {
            InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.InstitutionPresenter(this);
        }

        private void InstitutionView_Load(object sender, EventArgs e)
        {
            OnInit(null,null);
            this.cbUpIns.Visible = false;
            this.btnCancel.Visible = false;
            gridInstitution_Click(null,null);
        }

        Views.InstitutionEventArgs insEventArgs = new Views.InstitutionEventArgs();

        /// <summary>
        /// 判断按钮状态，1代表按钮为取消，2代表新增
        /// </summary>
        int btnStatus = 1;

        #region 绑定界面控件数据

        /// <summary>
        /// 当查询下拉相应表数据为空时，添加一空行值
        /// </summary>
        /// <param name="dtData"></param>
        private void AddNewRowWhenNull(DataTable dtData)
        {
            DataRow dr = dtData.NewRow();
            object[] newRowContent = { 0, "" };
            dr.ItemArray = newRowContent;
            dtData.Rows.Add(dr);
        }

        /// <summary>
        /// 绑定上级单位
        /// </summary>
        /// <param name="dtUpIns"></param>
        public void ExeBindHigherIns(DataTable dtUpIns)
        {
            this.cbUpIns.Properties.DataSource = dtUpIns;
            this.cbUpIns.Properties.ValueMember = "ins_id";
            this.cbUpIns.Properties.DisplayMember = "ins_name";
            if (dtUpIns.Rows.Count == 0)
            {
                AddNewRowWhenNull(dtUpIns);
            }
            this.cbUpIns.EditValue = dtUpIns.Rows[0]["ins_id"];  // 默认值
        }

        /// <summary>
        /// 绑定单位性质
        /// </summary>
        /// <param name="dtInsType"></param>
        public void ExeBindInsType(DataTable dtInsType)
        {
            this.cbInsType.Properties.DataSource = dtInsType;
            this.cbInsType.Properties.ValueMember = "ins_type_id";
            this.cbInsType.Properties.DisplayMember = "ins_type_name";
            if (dtInsType.Rows.Count == 0)
            {
                AddNewRowWhenNull(dtInsType);
            }
            this.cbInsType.EditValue = dtInsType.Rows[0]["ins_type_id"];  // 默认值
        }

        /// <summary>
        /// 绑定Grid单位信息
        /// </summary>
        /// <param name="dtGridIns"></param>
        public void ExeBindGridIns(DataTable dtGridIns)
        {
            this.gridInstitution.DataSource = dtGridIns;
        }
        #endregion

        // 添加项目
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnStatus == 1)
            {
                btnStatus = 2;
                this.btnAdd.Visible = false;
                this.btnCancel.Visible = true;
                this.gridInstitution.Enabled = false;
            }
        }


        // 取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnStatus == 2)
            {
                btnStatus = 1;
                this.btnAdd.Visible = true;
                this.btnCancel.Visible = false;
                this.gridInstitution.Enabled = true;
            }
        }

        /// <summary>
        /// 控件置空
        /// </summary>
        private void SetNull()
        {
            this.txtInsName.Text = "";
            this.txtInsPhone.Text = "";
            this.txtInsPostcode.Text = "";
            this.txtInsFax.Text = "";
            this.txtInsNum.Text = "";
            this.txtInsAddr.Text = "";
            this.txtContactName.Text = "";
            this.txtContactDept.Text = "";
            this.txtContactMobilePhone.Text = "";
            this.txtContactPhone.Text = "";
            this.txtContactFax.Text = "";
            this.txtContactEmail.Text = "";
            this.txtRemark.Text = "";
        }

        // 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtInsName.Text == "")
            {
                MessageBox.Show("单位名称不能为空");
            }
            
            if (long.Parse(this.cbInsType.EditValue.ToString()) == 0)
            {
                MessageBox.Show("请先维护单位性质");
                return;
            }
            if (long.Parse(this.cbUpIns.EditValue.ToString()) == 0 && this.chkHigherIns.CheckState == CheckState.Checked)
            {
                MessageBox.Show("请先维护上级单位");
                return;
            }
            insEventArgs.InsName = this.txtInsName.Text;
            insEventArgs.InsType = long.Parse(this.cbInsType.EditValue.ToString());
            if (this.chkHigherIns.CheckState == CheckState.Checked)
            {
                insEventArgs.HigherLevelId = long.Parse(this.cbUpIns.EditValue.ToString());
            }
            insEventArgs.InsFirstPinyin = CJia.Controls.CJiaSpellEditor.ToChString(this.txtInsName.Text);
            insEventArgs.InsAddr = this.txtInsAddr.Text;
            insEventArgs.InsPhone = this.txtInsPhone.Text;
            insEventArgs.InsFax = this.txtInsFax.Text;
            insEventArgs.InsPostCode = this.txtInsPostcode.Text;
            if (this.txtInsNum.Text != "")
            {
                insEventArgs.InsNum = int.Parse(this.txtInsNum.Text);
            }
            insEventArgs.ContactName = this.txtContactName.Text;
            insEventArgs.ContactDept = this.txtContactDept.Text;
            insEventArgs.ContactPhone = this.txtContactPhone.Text;
            insEventArgs.ContactMobilePhone = this.txtContactMobilePhone.Text;
            insEventArgs.ContactFax = this.txtContactFax.Text;
            insEventArgs.ContactEmail = this.txtContactEmail.Text;
            insEventArgs.Remark = this.txtRemark.Text;
            if (btnStatus == 1)
            {
                OnUpdateIns(sender,insEventArgs);
            }
            if (btnStatus == 2)
            {
                OnInsertIns(sender, insEventArgs);
                SetNull();
            }
        }

        // 人数只能输入数字
        private void txtInsNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
        }

        // 界面Grid单击事件
        private void gridInstitution_Click(object sender, EventArgs e)
        {
            if (this.gridViewIns.FocusedRowHandle < 0)
            {
                return;
            }
            DataRow dr = this.gridViewIns.GetFocusedDataRow();
            insEventArgs.InsId = long.Parse(dr["ins_id"].ToString());
            this.txtInsName.Text = dr["ins_name"].ToString();
            this.cbInsType.EditValue = dr["ins_type"];
            if (dr["higher_level_id"].ToString() == "")
            {
                this.cbUpIns.EditValue = 0;
            }
            else
            {
                this.cbUpIns.EditValue = dr["higher_level_id"];
            }
            this.txtInsPhone.Text = dr["ins_phone"].ToString();
            this.txtInsPostcode.Text = dr["ins_postcode"].ToString();
            this.txtInsFax.Text = dr["ins_fax"].ToString();
            this.txtInsNum.Text = dr["ins_num"].ToString();
            this.txtInsAddr.Text = dr["ins_addr"].ToString();
            this.txtContactName.Text = dr["contact_name"].ToString();
            this.txtContactDept.Text = dr["contact_dept"].ToString();
            this.txtContactPhone.Text = dr["contact_phone"].ToString();
            this.txtContactMobilePhone.Text = dr["contact_mobile_phone"].ToString();
            this.txtContactFax.Text = dr["contact_fax"].ToString();
            this.txtContactEmail.Text = dr["contact_email"].ToString();
            this.txtRemark.Text = dr["remark"].ToString();
        }

        // 是否显示上级
        private void chkHigherIns_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.chkHigherIns.Checked)
            {
                this.cbUpIns.Visible = true;
            }
            else
            {
                this.cbUpIns.Visible = false;
            }
        }

        #region 事件
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.InstitutionEventArgs> OnInit;

        /// <summary>
        /// 插入单位事件
        /// </summary>
        public event EventHandler<Views.InstitutionEventArgs> OnInsertIns; 

        /// <summary>
        /// 更新单位事件
        /// </summary>
        public event EventHandler<Views.InstitutionEventArgs> OnUpdateIns;
        #endregion

       
    }
}

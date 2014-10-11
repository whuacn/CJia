using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace CJia.Health.App.UI
{
    public partial class UserManageView : CJia.Health.Tools.View, CJia.Health.Views.IUserManageView
    {
        public UserManageView()
        {
            InitializeComponent();
            OnInit(null, null);
            this.rtlkDept.GetData += rtlkDept_GetData;
        }

        protected override object CreatePresenter()
        {
            return new Presenters.UserManagePresenter(this);
        }

        Views.UserArgs userArgs = new Views.UserArgs();

        #region【界面事件】
        
        private void UserManageView_SizeChanged(object sender, EventArgs e)
        {
            int formHeight = this.Height;
            int formWidth = this.Width;
            int pnlHeight;
            pnlHeight = formHeight; 
            int location = (formWidth - pnlUser.Width) / 2;
            pnlUser.Location = new Point(location, 9);
            this.VerticalScroll.Value = VerticalScroll.Minimum;
        }

        /// <summary>
        /// 焦点行变化时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr != null)
            {
                txtUserNo.Text = dr["USER_NO"].ToString();
                txtUserName.Text = dr["USER_NAME"].ToString();
                rtlkDept.DisplayValue = dr["DEPT_ID"].ToString();
                rtlkDept.DisplayText = dr["DEPT_NAME"].ToString();
                rtlkDept.Text = dr["DEPT_NAME"].ToString();
                cboDoctorDescript.Text = dr["DOCTOR_DESCRIPT_NAME"].ToString();
                cboDoctorDescript.EditValue = dr["DOC_DESCRIPT"].ToString();

                userArgs.UserId = long.Parse(dr["USER_ID"].ToString());
                userArgs.ExistName = dr["USER_NAME"].ToString();
                OnFocusedRowChanged(sender, userArgs);
            }
        }

        /// <summary>
        /// 添加一条医生信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Common.CheckIsNotNull(this, "txtUserName", "用户名称") && Common.CheckIsNotNull(this, "txtUserNo", "医生编号"))
            {
                if (this.rtlkDept.Text == "")
                {
                    MessageBox.Show("部门不能为空！");
                    return;
                }
                SetValue();
                OnInsertUser(sender, userArgs);
                if (userArgs.IsInsertSuccess)
                {
                    SetNull();
                    userArgs.IsInsertSuccess = true;
                }
            }
            else
            {
                return;
            }
        }

        // 更新
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Common.CheckIsNotNull(this, "txtUserName", "用户名称") && Common.CheckIsNotNull(this, "txtUserNo", "医生编号"))
            {
                if (this.rtlkDept.Text == "")
                {
                    MessageBox.Show("部门不能为空！");
                    return;
                }

                if (gridView1.FocusedRowHandle < 0)
                {
                    return;
                }
                SetValue();
                userArgs.ExistName = gridView1.GetFocusedDataRow()["USER_NAME"].ToString();
                userArgs.UserId = long.Parse(gridView1.GetFocusedDataRow()["user_id"].ToString());
                OnUpdateUser(sender, userArgs);
                if (userArgs.IsInsertSuccess)
                {
                    SetNull();
                    userArgs.IsInsertSuccess = true;
                }
            }
            else
            {
                return;
            }
            gridView1_FocusedRowChanged(null, null);
        }

        // 删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                return;
            }
            SetValue();
            userArgs.ExistName = gridView1.GetFocusedDataRow()["USER_NAME"].ToString();
            OnDeleteUser(sender, userArgs);
        }

        // 查询
        private void btnSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            userArgs.KeyWord = btnSearch.Text;
            OnSearch(sender, userArgs);
        }
        #endregion
        

        /// <summary>
        /// 模糊查询医生职称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkDoctorDescript_GetData(object sender, Controls.CJiaRTLookUpArgs e)
        {
            throw new NotImplementedException();
        }

        #region【实现接口】

        public void ExeBindDept(DataTable dtDept)
        {
            rtlkDept.DataSource = dtDept;
            rtlkDept.Caption = "科室";
            rtlkDept.DisplayField = "DEPT_NAME";
            rtlkDept.ValueField = "DEPT_ID";
        }

        /// <summary>
        /// 绑定Grid
        /// </summary>
        /// <param name="dtUser"></param>
        public void ExeBindGridUser(DataTable dtUser)
        {
            gridUser.DataSource = dtUser;
        }

         //<summary>
         //绑定界面角色选择框
         //</summary>
         //<param name="dtUserRole"></param>
        public void ExeBindRole(DataTable dtUserRole)
        {
            cklstUserRole.DisplayMember = "role_name";
            cklstUserRole.ValueMember = "role_id";
            foreach (DataRow dr in dtUserRole.Rows)//dt为数据源：DataTable类型  
            {
                this.cklstUserRole.Items.Add(new InnerUser(dr, "role_id", "role_name"));
            }
        }

        /// <summary>
        /// 绑定医生职称
        /// </summary>
        /// <param name="dtDoctorDescript"></param>
        public void ExeBindDoctorDescript(DataTable dtDoctorDescript)
        {
            cboDoctorDescript.Properties.DataSource = dtDoctorDescript;
            cboDoctorDescript.Properties.DisplayMember = "NAME";
            cboDoctorDescript.Properties.ValueMember = "CODE";
        }

        /// <summary>
        /// 设定用户权限选择状态
        /// </summary>
        /// <param name="dtRole"></param>
        public void ExeSetRoleChecked(DataTable dtRole)
        {
            // 全部置为不选状态
            for (int j = 0; j < dtRole.Rows.Count; j++)
            {
                cklstUserRole.Items[j].CheckState = CheckState.Unchecked;
            }

            DataTable dt = userArgs.TableUserRole;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dtRole.Rows.Count; j++)
                {
                    if (dtRole.Rows[j]["role_id"].ToString() == dt.Rows[i]["role_id"].ToString())
                    {
                        cklstUserRole.Items[j].CheckState = CheckState.Checked;
                    }
                }
            }
        }
        #endregion

        #region【自定义方法】
        /// <summary>
        /// 模糊查询部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkDept_GetData(object sender, Controls.CJiaRTLookUpArgs e)
        {
            if (OnQueryDept != null)
            {
                userArgs.KeyWord = e.SearchValue.ToUpper().ToString();
                OnQueryDept(sender, userArgs);
            }
        }

        /// <summary>
        /// 为View层参数赋值
        /// </summary>
        private void SetValue()
        {
            userArgs.ListRoleId.Clear();
            userArgs.ListRoleName.Clear();
            userArgs.UserNo = txtUserNo.Text;
            userArgs.UserName = txtUserName.Text;
            userArgs.DeptId = rtlkDept.DisplayValue;
            userArgs.DoctorDescript = cboDoctorDescript.EditValue.ToString();

            for (int i = 0; i < cklstUserRole.Items.Count; i++)
            {
                if (cklstUserRole.Items[i].CheckState == CheckState.Checked)
                {
                    InnerUser uChecked = (InnerUser)(this.cklstUserRole.Items[i].Value);
                    userArgs.ListRoleId.Add(uChecked.GetFieldID());
                    userArgs.ListRoleName.Add(uChecked.GetFieldName());
                }
            }
        }

        

        /// <summary>
        /// 置空控件
        /// </summary>
        private void SetNull()
        {
            this.txtUserNo.Text = "";
            this.txtUserName.Text = "";
            this.rtlkDept.Text = "";
            this.rtlkDept.DisplayValue = "";
        }
        #endregion

        #region 【接口事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.UserArgs> OnInit;

        /// <summary>
        /// 新增用户事件
        /// </summary>
        public event EventHandler<Views.UserArgs> OnInsertUser;

        /// <summary>
        /// 模糊查询部门
        /// </summary>
        public event EventHandler<Views.UserArgs> OnQueryDept;

        /// <summary>
        /// 更新用户
        /// </summary>
        public event EventHandler<Views.UserArgs> OnUpdateUser;

        /// <summary>
        /// 删除用户
        /// </summary>
        public event EventHandler<Views.UserArgs> OnDeleteUser;

        /// <summary>
        /// 点击Grid行事件
        /// </summary>
        public event EventHandler<Views.UserArgs> OnFocusedRowChanged;

        /// <summary>
        /// 查询
        /// </summary>
        public event EventHandler<Views.UserArgs> OnSearch;
        #endregion

        #region【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    btnAdd.Focus();
                    this.btnAdd_Click(null, null);
                    return true;
                case Keys.F2:
                    btnUpdate.Focus();
                    btnUpdate_Click(null, null);
                    return true;
                case Keys.F3:
                    btnDelete.Focus();
                    btnDelete_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

    }


    #region 【内部用户类，用于加载checkedListBox控件，以及返回对象】
    class InnerUser  
    {  
        private DataRow dr;
        string FieldId;
        string FieldName;
        public InnerUser(DataRow dr, string fieldId,string fieldName )  
        {  
            this.dr = dr;
            this.FieldId = fieldId;
            this.FieldName = fieldName;
        }  
        public override string ToString()//一定要注意重载  
        {  
            return dr[FieldName].ToString();  
        }
        public string GetFieldName()  
        {  
            return this.ToString();  
        }
        public long GetFieldID()  
        {
            return long.Parse(dr[FieldId].ToString());  
        }
    }
   #endregion



}

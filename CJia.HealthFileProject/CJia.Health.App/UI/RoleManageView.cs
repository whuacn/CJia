using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace CJia.Health.App.UI
{
    public partial class RoleManageView : CJia.Health.Tools.View,CJia.Health.Views.IRoleManageView
    {
        public RoleManageView()
        {
            InitializeComponent();
            OnInit(null,null);
        }
        
        protected override object CreatePresenter()
        {
            return new Presenters.RoleManagePresenter(this);
        }

        Views.RoleManageArgs roleArgs = new Views.RoleManageArgs();

        #region【初始绑定事件】
        /// <summary>
        /// 绑定界面Grid
        /// </summary>
        /// <param name="dtGridRole"></param>
        public void ExeBindGridRole(DataTable dtGridRole)
        {
            gridRole.DataSource = dtGridRole;
        }

        /// <summary>
        /// 绑定界面功能角色选择框
        /// </summary>
        /// <param name="dtUserRole"></param>
        public void ExeBindRoleFunc(DataTable dtUserRole)
        {
            cklstRoleFunction.DisplayMember = "role_func";
            cklstRoleFunction.ValueMember = "function_id";
            foreach (DataRow dr in dtUserRole.Rows)
            {
                this.cklstRoleFunction.Items.Add(new InnerUser(dr, "function_id", "role_func"));
            }
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
                cklstRoleFunction.Items[j].CheckState = CheckState.Unchecked;
            }

            // 比较所选择用户拥有功能角色和全部功能角色
            DataTable dt = roleArgs.TableFunction;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dtRole.Rows.Count; j++)
                {
                    if (dtRole.Rows[j]["function_id"].ToString() == dt.Rows[i]["function_id"].ToString())
                    {
                        cklstRoleFunction.Items[j].CheckState = CheckState.Checked;
                    }
                }
            }
        }
        #endregion

        #region 【控件生成事件】
        private void RoleManageView_SizeChanged(object sender, EventArgs e)
        {
            int formHeight = this.Height;
            int formWidth = this.Width;
            int pnlHeight;
            pnlHeight = formHeight;
            int location = (formWidth - pnlRole.Width) / 2;
            pnlRole.Location = new Point(location, 9);
            this.VerticalScroll.Value = VerticalScroll.Minimum;
        }

        // 网格单击事件
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr != null)
            {
                roleArgs.RoleName = dr["ROLE_NAME"].ToString();
                txtRoleName.Text = dr["ROLE_NAME"].ToString();
                roleArgs.RoleId = long.Parse(dr["ROLE_ID"].ToString());
                OnFocusedRowChanged(sender, roleArgs);
            }
            else
            {
                return;
            }
        }

        // 分组时改变选中行颜色
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle == gridView1.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.FromArgb(99, 184, 255);
            }
        }

        // 新增
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Message.ShowQuery("确定要保存【" + txtRoleName.Text + "】?") == Message.Result.Ok)
            {
                SetValue();
                OnAdd(sender, roleArgs);
                roleArgs.ListFunctionId.Clear();
            }
        }

        // 更新
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Message.ShowQuery("确定要修改【" + txtRoleName.Text + "】?") == Message.Result.Ok)
            {
                DataRow dr = gridView1.GetFocusedDataRow();
                SetValue();
                if (dr != null)
                {
                    roleArgs.RoleId = long.Parse(dr["ROLE_ID"].ToString());
                    roleArgs.ExistNameWhenUpdate = dr["ROLE_NAME"].ToString();
                    OnUpdate(sender, roleArgs);
                    roleArgs.ListFunctionId.Clear();
                }
                
            }
        }

        // 删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Message.ShowQuery("确定要删除【" + txtRoleName.Text + "】?") == Message.Result.Ok)
            {
                DataRow dr = gridView1.GetFocusedDataRow();
                if (dr != null)
                {
                    // 用户没有权限，只存在名称
                    if (dr["ROLE_FUNCTION_ID"].ToString() != "")
                    {
                        roleArgs.RoleFunctionId = long.Parse(dr["ROLE_FUNCTION_ID"].ToString());
                    }
                    roleArgs.RoleId = long.Parse(dr["ROLE_ID"].ToString());
                    OnDelete(sender, roleArgs);
                }
            }
        }

        private void btnSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            roleArgs.KeyWord = btnSearch.Text;
            OnSearch(sender,roleArgs);
        }

        /// <summary>
        /// 取界面控件所编辑值
        /// </summary>
        void SetValue()
        {
            roleArgs.ListFunctionId.Clear();
            roleArgs.RoleName = txtRoleName.Text;
            for (int i = 0; i < cklstRoleFunction.CheckedIndices.Count; i++)
            {
                InnerUser uChecked = (InnerUser)(this.cklstRoleFunction.CheckedItems[i]);
                roleArgs.ListFunctionId.Add(uChecked.GetFieldID());
            }
            
        }

        // 刷新
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cklstRoleFunction.Items.Clear();
            OnInit(null,null);
        }
        #endregion

        #region 【事件】

        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.RoleManageArgs> OnInit;

        /// <summary>
        /// 添加事件
        /// </summary>
        public event EventHandler<Views.RoleManageArgs> OnAdd;

        /// <summary>
        /// 更新事件
        /// </summary>
        public event EventHandler<Views.RoleManageArgs> OnUpdate;

        /// <summary>
        /// 删除事件
        /// </summary>
        public event EventHandler<Views.RoleManageArgs> OnDelete;

        /// <summary>
        /// 点击Grid行事件
        /// </summary>
        public event EventHandler<Views.RoleManageArgs> OnFocusedRowChanged;

        /// <summary>
        /// 查询
        /// </summary>
        public event EventHandler<Views.RoleManageArgs> OnSearch;
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
                    btnUpdate_Click(null,null);
                    return true;
                case Keys.F3:
                    btnDelete.Focus();
                    btnDelete_Click(null,null);
                    return true;
                case Keys.F5:
                    btnRefresh.Focus();
                    btnRefresh_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

    }
}

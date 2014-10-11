//***************************************************
// 文件名（File Name）:      DeptMode.cs
//
// 表（Tables）:            
//                          
//
// 视图（Views）:           
//                          
// 作者（Author）:           曾翠玲
//
// 日期（Create Date）:     2013.4.3
// 
// 修改记录（Revision History）：
//               R1：
//                   修改作者：
//                   修改日期：
//                   修改理由：
//***************************************************

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
    public partial class DeptView : CJia.PEIS.Tools.View, CJia.PEIS.Views.IDeptView
    {
        public DeptView()
        {
            InitializeComponent();
            OnInit(null,null);
            this.btnCancel.Visible = false;
            gridDept_Click(null,null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.DeptPresenter(this);
        }

        /// <summary>
        /// 判断按钮状态，1代表按钮为取消，2代表新增
        /// </summary>
        public int btnStatus = 1;
        Views.DeptEventArgs deptEventArgs = new Views.DeptEventArgs();

        /// <summary>
        /// 下一个排序号
        /// </summary>
        /// <param name="sortNo"></param>
        public void ExeBindSortNo(long sortNo)
        {
            this.txtSortNo.Text = sortNo.ToString();
        }

        /// <summary>
        /// 绑定下拉科室类别
        /// </summary>
        /// <param name="dtDeptType"></param>
        public void ExeBindDeptType(DataTable dtDeptType)
        {
            this.cbDeptType.Properties.DataSource = dtDeptType;
            this.cbDeptType.Properties.ValueMember = "dept_type_id";
            this.cbDeptType.Properties.DisplayMember = "dept_type_name";
            this.cbDeptType.EditValue = dtDeptType.Rows[0]["dept_type_id"];  // 默认值
        }

        /// <summary>
        /// 绑定科室表数据
        /// </summary>
        /// <param name="dtDept"></param>
        public void ExeBindGridDept(DataTable dtDept)
        {
            gridDept.DataSource = dtDept;
        }

        private void gridDept_Click(object sender, EventArgs e)
        {
            if (gridViewDept.FocusedRowHandle < 0)
            {
                return;
            }
            this.txtSortNo.Text = gridViewDept.GetFocusedDataRow()["sort_no"].ToString();
            this.txtDeptName.Text = gridViewDept.GetFocusedDataRow()["dept_name"].ToString();
            this.cbDeptType.EditValue = gridViewDept.GetFocusedDataRow()["dept_type"];
            this.txtEnglishName.Text = gridViewDept.GetFocusedDataRow()["dept_english_name"].ToString();
            this.txtRemark.Text = gridViewDept.GetFocusedDataRow()["remark"].ToString();
        }

        // 点击保存按钮
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtDeptName.Text == "")
            {
                MessageBox.Show("科室名称不能为空！");
                this.Focus();
                return;
            }
            if (this.txtSortNo.Text == "")
            {
                MessageBox.Show("排序号不能为空！");
                this.Focus();
                return;
            }
            if (this.cbDeptType.EditValue.ToString() == "")
            {
                MessageBox.Show("科室类型不能为空");
                this.Focus();
                return;
            }
            deptEventArgs.DeptName = this.txtDeptName.Text;
            deptEventArgs.SortNo = long.Parse(this.txtSortNo.Text);
            deptEventArgs.DeptType = long.Parse(cbDeptType.EditValue.ToString());
            deptEventArgs.DeptEnglishName = this.txtEnglishName.Text;
            deptEventArgs.DeptFirstPinyin = CJia.Controls.CJiaSpellEditor.ToChString(this.txtDeptName.Text);
            deptEventArgs.Remark = this.txtRemark.Text;
            if (btnStatus == 1)
            {
                deptEventArgs.DeptId = long.Parse(gridViewDept.GetFocusedDataRow()["dept_id"].ToString());
                OnUpdateDept(sender, deptEventArgs);
            }
            if (btnStatus == 2)
            {
                OnInsertDept(sender, deptEventArgs);
                btnStatus = 1;
                this.btnAdd.Visible = true;
                this.btnCancel.Visible = false;
                this.txtDeptName.Text = "";
                this.txtEnglishName.Text = "";
                this.txtRemark.Text = "";
                gridDept.Enabled = true;
            }
        }

        // 点击新增按钮
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ( btnStatus == 1)
            {
                btnStatus = 2;
                this.btnAdd.Visible = false;
                this.btnCancel.Visible = true;
                this.txtDeptName.Text = "";
                this.txtEnglishName.Text = "";
                this.txtRemark.Text = "";
                gridDept.Enabled = false;
                OnAddDept(sender, deptEventArgs);
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
                gridDept.Enabled = true;
            }
        }
        // 点击停用按钮
        private void btnStop_Click(object sender, EventArgs e)
        {
            deptEventArgs.DeptId = long.Parse(gridViewDept.GetFocusedDataRow()["dept_id"].ToString());
            OnStopDept(sender,deptEventArgs);
        }

        // 点击搜索按钮
        private void txtSeach_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            deptEventArgs.StrSearchCondition = this.txtSeach.Text;
            if (chkStopDept.Checked)
            {
                deptEventArgs.IsCheckedStopDept = "Y";
            }
            else
            {
                deptEventArgs.IsCheckedStopDept = "N";
            }
            OnSearch(sender, deptEventArgs);
        }


        #region  事件
        public event EventHandler<Views.DeptEventArgs> OnInit;

        /// <summary>
        /// 插入科室表事件
        /// </summary>
        public event EventHandler<Views.DeptEventArgs> OnInsertDept;

        /// <summary>
        /// 点击新增按钮事件
        /// </summary>
        public event EventHandler<Views.DeptEventArgs> OnAddDept;

        /// <summary>
        /// 修改科室事件
        /// </summary>
        public event EventHandler<Views.DeptEventArgs> OnUpdateDept;

        /// <summary>
        /// 停用科室事件
        /// </summary>
        public event EventHandler<Views.DeptEventArgs> OnStopDept;

        /// <summary>
        /// 查询事件
        /// </summary>
        public event EventHandler<Views.DeptEventArgs> OnSearch;

        #endregion
    }
}

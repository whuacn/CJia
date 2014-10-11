using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CJia.PIVAS.App.UI.DataManage
{
    /// <summary>
    /// 病区对应用法的UI层
    /// </summary>
    public partial class DeptUsageView : CJia.PIVAS.Tools.View, CJia.PIVAS.Views.DataManage.IDeptUsageView
    {
        /// <summary>
        /// 病区用法维护构造方法
        /// </summary>
        public DeptUsageView()
        {
            InitializeComponent();
        }

        //重写创建P层方法
        protected override object CreatePresenter()
        {
            return new Presenters.DataManage.DeptUsagePresenter(this);
        }

        //初始化载入数据
        private void GcDeptUsage_Load(object sender, EventArgs e)
        {
            this.OnInitLoadData(null, null);
        }

        //点击添加执行的事件
        private void BtnAddDeptUsage_Click(object sender, EventArgs e)
        {
            AddDeptUsageView addDeptUsage = new AddDeptUsageView();
            ShowAsWindow("用法给药途径", addDeptUsage);
            this.OnInitLoadData(null, null);
        }

        //点击删除执行的事件
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (GridViewDeptUsage.FocusedRowHandle >= 0)
            {
                if (CJia.PIVAS.Tools.Message.ShowQuery("确认是否删除", CJia.PIVAS.Tools.Message.Button.YesNo) == CJia.PIVAS.Tools.Message.Result.Yes)
                {
                    CJia.PIVAS.Views.DataManage.DeptUsageEventArgs deptUsageAreas = new Views.DataManage.DeptUsageEventArgs();
                    deptUsageAreas.UserId = User.UserId;
                    deptUsageAreas.PivasSetId = long.Parse(GridViewDeptUsage.GetFocusedDataRow()["PIVAS_SET_ID"].ToString());
                    this.OnDeleteDeptUsage(null, deptUsageAreas);
                }
                else
                {
                    return;
                }
            }
            else
            {
                CJia.PIVAS.Tools.Message.ShowWarning("请选择数据");
            }
        }

        //F5刷新
        private void GcDeptUsage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                this.OnInitLoadData(null, null);
            }
        }

        #region【实现接口】

        //初始化数据
        public event EventHandler<Views.DataManage.DeptUsageEventArgs> OnInitLoadData;

        //删除所选数据
        public event EventHandler<Views.DataManage.DeptUsageEventArgs> OnDeleteDeptUsage;

       //未gridcontrol绑定数据源
        public void ExeDataBinds(DataTable dt)
        {
            GcDeptUsage.DataSource = dt;
        }

        #endregion

        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    BtnRefresh.Focus();
                    this.OnInitLoadData(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}

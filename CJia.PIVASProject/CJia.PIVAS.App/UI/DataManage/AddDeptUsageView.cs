using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.PIVAS.App.UI.DataManage
{
    /// <summary>
    /// 添加病区对应用法UI层
    /// </summary>
    public partial class AddDeptUsageView : CJia.PIVAS.Tools.View, CJia.PIVAS.Views.DataManage.IAddDeptUsageView
    {
        
        public AddDeptUsageView()
        {
            InitializeComponent();
            
        }

        protected override object CreatePresenter()
        {
            return new Presenters.DataManage.AddDeptUsagePresenter(this);
        }

        private void AddDeptUsageView_Load(object sender, EventArgs e)
        {
            //CJia.PIVAS.Views.DataManage.AddDeptUsageEventArgs addDeptUsage = new Views.DataManage.AddDeptUsageEventArgs();
            //addDeptUsage.officeId=
            this.OnInitLoadDept(null, null);
        }

        /// <summary>
        /// 选中了病区触发加载未配置当前病区的用法 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlueDept_EditValueChanged(object sender, EventArgs e)
        {
            if (GlueDept.EditValue != null)
            {
                DataRow drDept = GlueViewDept.GetFocusedDataRow();
                CJia.PIVAS.Views.DataManage.AddDeptUsageEventArgs addDeptUsage = new Views.DataManage.AddDeptUsageEventArgs();
                addDeptUsage.OfficeId = drDept["DEPT_ID"].ToString();
                this.OnRowClick(null, addDeptUsage);
            }
            else
            {
                return;
            }
        }

        //点击确定执行的事件
        private void BtnSure_Click(object sender, EventArgs e)
        {
            AddDeptUsage();
        }

        //点击取消执行的事件
        private void BtnCancle_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        //添加病区对应用法
        private void AddDeptUsage()
        {
            //判断是否选择了病区和用法
            if (GlueDept.EditValue != null && GlueUsage.EditValue != null)
            {
                if (CJia.PIVAS.Tools.Message.ShowQuery("确认是否添加", CJia.PIVAS.Tools.Message.Button.YesNo) == CJia.PIVAS.Tools.Message.Result.Yes)
                {
                    CJia.PIVAS.Views.DataManage.AddDeptUsageEventArgs addDeptUsage = new Views.DataManage.AddDeptUsageEventArgs();
                    DataRow drDept = GlueViewDept.GetFocusedDataRow();
                    DataRow drUsage = GlueViewUsage.GetFocusedDataRow();
                    addDeptUsage.OfficeId = drDept["DEPT_ID"].ToString();
                    addDeptUsage.OfficeName = drDept["DEPT_NAME"].ToString();
                    addDeptUsage.UsageId = long.Parse(drUsage["USAGE_ID"].ToString());
                    addDeptUsage.UsageName = drUsage["USAGE_NAME"].ToString();
                    addDeptUsage.UserId = User.UserId;
                    this.OnInsertData(null, addDeptUsage);
                }
                else
                {
                    return;
                }
            }
            else
            {
                CJia.PIVAS.Tools.Message.Show("病区或用法未选择");
                return;
            }
        }

        #region【实现接口】

        //初始化载入数据(病区和用法)
        public event EventHandler<Views.DataManage.AddDeptUsageEventArgs> OnInitLoadDept;

        //添加数据 
        public event EventHandler<Views.DataManage.AddDeptUsageEventArgs> OnInsertData;

        //点击选择的病区行
        public event EventHandler<Views.DataManage.AddDeptUsageEventArgs> OnRowClick;

        //初始化病区数据
        public void ExeInitLoadDept(DataTable dtDept)
        {
            GlueDept.Properties.DataSource = dtDept;
            GlueDept.Properties.DisplayMember = "DEPT_NAME"; //绑定Text显示的字段源名称
            GlueDept.Properties.ValueMember = "DEPT_ID"; //绑定Value字段源名称
            GlueDept.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            GlueDept.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            GlueDept.Properties.View.BestFitColumns();
            GlueDept.Properties.ShowFooter = false;
            //GlueFrequency.Properties.View.OptionsView.ShowAutoFilterRow = true; //显示不显示grid上第一个空行,也是用于检索的应用
            GlueDept.Properties.ImmediatePopup = true;
            GlueDept.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            GlueDept.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard; //配置,用于像文本框那样呀,可自己录入,选择,些处是枚举,可自行设置.
        }

        //根据所选病区初始化病区
        public void ExtLoadUsage(DataTable dtUsage)
        {
            GlueUsage.Properties.DataSource = dtUsage;
            GlueUsage.Properties.DisplayMember = "USAGE_NAME"; //绑定Text显示的字段源名称
            GlueUsage.Properties.ValueMember = "USAGE_ID"; //绑定Value字段源名称
            GlueUsage.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            GlueUsage.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            GlueUsage.Properties.View.BestFitColumns();
            GlueUsage.Properties.ShowFooter = false;
            //GlueFrequency.Properties.View.OptionsView.ShowAutoFilterRow = true; //显示不显示grid上第一个空行,也是用于检索的应用
            GlueUsage.Properties.ImmediatePopup = true;
            GlueUsage.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            GlueUsage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard; //配置,用于像文本框那样呀,可自己录入,选择,些处是枚举,可自行设置.
        }

        #endregion

        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    BtnSure.Focus();
                    this.AddDeptUsage();
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

    }
}

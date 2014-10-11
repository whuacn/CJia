using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace CJia.PIVAS.App.UI.DataManage
{
    /// <summary>
    /// 添加频率对应批次的UI层
    /// </summary>
    public partial class AddFrequenceToBeachView : CJia.PIVAS.Tools.View, CJia.PIVAS.Views.DataManage.IAddFrequencyToBatchView
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public AddFrequenceToBeachView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选中的批次对应的数字
        /// </summary>
        private List<string> BatchsInt = new List<string>();

        protected override object CreatePresenter()
        {
            return new Presenters.DataManage.AddFrequencyToBatchPresenter(this);
        }

        /// <summary>
        /// Load事件对下拉框的赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFrequenceToBeachView_Load(object sender, EventArgs e)
        {
            this.OnInitLoadData(null, null);
        }

        /// <summary>
        /// 点击添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSure_Click(object sender, EventArgs e)
        {
            AddFrequencyToBatch();
        }

        /// <summary>
        /// 添加频率对应批次
        /// </summary>
        private void AddFrequencyToBatch()
        {
            if (GlueFrequency.EditValue != null && IsSeclect())
            {

                if (CJia.PIVAS.Tools.Message.ShowQuery("确认是否添加", CJia.PIVAS.Tools.Message.Button.YesNo) == CJia.PIVAS.Tools.Message.Result.Yes)
                {
                    CJia.PIVAS.Views.DataManage.AddFrequencyToBatchEventArgs addFrequency = new Views.DataManage.AddFrequencyToBatchEventArgs();
                    DataRow dr = gridLookUpEdit1View.GetFocusedDataRow();
                    addFrequency.FrequencyId = long.Parse(dr["FREQUENCY_ID"].ToString());
                    addFrequency.FrequencyName = dr["FREQUENCY_NAME"].ToString();
                    addFrequency.FrequencyFilter = dr["FILTER"].ToString();
                    addFrequency.BatchsName = CJia.PIVAS.Common.GetBatchsName(this.BatchsInt);
                    addFrequency.UserId = User.UserId;
                    if(User.Role == "0")
                    {
                        addFrequency.Illfield = User.DeptId;
                        addFrequency.IllfieldName = User.DeptName;
                    }
                    else
                    {
                        addFrequency.Illfield = gridView1.GetFocusedDataRow()["OFFICE_ID"].ToString();
                        addFrequency.IllfieldName = gridView1.GetFocusedDataRow()["OFFICE_NAME"].ToString();
                    }
                    this.OnAddFrequencyBatch(null, addFrequency);
                }
                else
                {
                    return;
                }
            }
            else
            {
                Message.Show("您未选择频率或批次，请选择");
            }
        }
        /// <summary>
        /// 点击取消关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancle_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        //以选排序双击事件
        private void lbcUseOrderBy_DoubleClick(object sender, EventArgs e)
        {
            this.ToRitht();
        }

        //未选排序双击事件
        private void lbcNoUseOrderBy_DoubleClick(object sender, EventArgs e)
        {
            this.Tolift();
        }

        //排序向左按钮单机事件
        private void btnToLift_Click(object sender, EventArgs e)
        {
            this.Tolift();
        }

        //排序向右按钮单击事件
        private void butToRigth_Click(object sender, EventArgs e)
        {
            this.ToRitht();
        }


        #region【实现接口】

        //public event EventHandler<Views.DataManage.AddFrequencyToBatchEventArgs> OnInitLoadData;
        //初始化页面时的加载频率和批次信息
        public event EventHandler<Views.DataManage.AddFrequencyToBatchEventArgs> OnInitLoadData;

        //添加频率对应批次
        public event EventHandler<Views.DataManage.AddFrequencyToBatchEventArgs> OnAddFrequencyBatch;

        //把或得到得频率和病区数据源绑定到控件上
        public void ExeGridLookUpDataBind(DataTable dtFrequency,DataTable dtBatch,DataTable dtIllfield)
        {
            GlueFrequency.Properties.DataSource = dtFrequency;
            GlueFrequency.Properties.DisplayMember = "FREQUENCY_NAME"; //绑定Text显示的字段源名称
            GlueFrequency.Properties.ValueMember = "FREQUENCY_ID"; //绑定Value字段源名称
            GlueFrequency.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            GlueFrequency.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            GlueFrequency.Properties.View.BestFitColumns();
            GlueFrequency.Properties.ShowFooter = false;
            //GlueFrequency.Properties.View.OptionsView.ShowAutoFilterRow = true; //显示不显示grid上第一个空行,也是用于检索的应用
            GlueFrequency.Properties.ImmediatePopup = true;
            GlueFrequency.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            GlueFrequency.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard; //配置,用于像文本框那样呀,可自己录入,选择,些处是枚举,可自行设置.


            cbIllfield.Properties.DataSource = dtIllfield;
            cbIllfield.Properties.DisplayMember = "OFFICE_NAME"; //绑定Text显示的字段源名称
            cbIllfield.Properties.ValueMember = "OFFICE_ID"; //绑定Value字段源名称
            cbIllfield.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            cbIllfield.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            cbIllfield.Properties.View.BestFitColumns();
            cbIllfield.Properties.ShowFooter = false;
            //GlueFrequency.Properties.View.OptionsView.ShowAutoFilterRow = true; //显示不显示grid上第一个空行,也是用于检索的应用
            cbIllfield.Properties.ImmediatePopup = true;
            cbIllfield.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            cbIllfield.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard; //配置,用于像文本框那样呀,可自己录入,选择,些处是枚举,可自行设置.

            if(User.Role == "0")
            {
                this.txtIllfield.Text = User.DeptName;
                this.txtIllfield.Visible = true;
                this.txtIllfield.Enabled = false;
                cbIllfield.Enabled = false;
            }
            else
            {
                this.txtIllfield.Visible = false;
                cbIllfield.Enabled = true;
            }

            //for (int i = 0; i < dtBatch.Rows.Count; i++)
            //{
            //    CheckedListBoxItem item = new CheckedListBoxItem(dtBatch.Rows[i]["BATCH_NO"], dtBatch.Rows[i]["BATCH_NAME"].ToString());
            //    ClbcBatch.Items.Add(item);
            //}

            for(int i = 0; i < dtBatch.Rows.Count; i++)
            {
                if(dtBatch.Rows[i]["BATCH_ID"].ToString() != "1000000005"
                   && dtBatch.Rows[i]["BATCH_ID"].ToString() != "2000000020"
                   && dtBatch.Rows[i]["BATCH_ID"].ToString() != "2000000021") 
                {
                    lbcNoUseBatch.Items.Add(dtBatch.Rows[i]["BATCH_NAME"].ToString() + " " + dtBatch.Rows[i]["BATCH_NO"].ToString());
                }
            }
        }

        #endregion

        #region【自定义方法】

        /// <summary>
        /// 判断多选框checklistboxcontrol是否有选中  true为已选中
        /// </summary>
        /// <param name="clbc"></param>
        /// <returns></returns>
        private bool IsSeclect()
        {
            if(this.lbcUseBatch.Items == null || this.lbcUseBatch.Items.Count == 0)
            {
                return false;
            }
            return true;
        }


        //将未选着的排序方式list中选着的一行转移到已选择的排序方式list中
        private void Tolift()
        {
            if(this.lbcNoUseBatch.SelectedItem != null)
            {
                string selectItem = this.lbcNoUseBatch.SelectedItem.ToString();
                this.lbcUseBatch.Items.Add(selectItem);
                this.BatchsInt.Add(selectItem.Split(' ')[1]);
            }
        }

        //将已选择的排序方式list中选着的一行转移到未选择的排序方式list中
        private void ToRitht()
        {
            if(this.lbcUseBatch.SelectedItem != null)
            {
                string selectItem = this.lbcUseBatch.SelectedItem.ToString();
                this.BatchsInt.Remove(selectItem.Split(' ')[1]);
                this.lbcUseBatch.Items.Remove(selectItem);
            }
            //将未选着的排序方式list中选着的一行转移到已选择的排序方式list中
        }

        #endregion

        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    BtnSure.Focus();
                    this.AddFrequencyToBatch();
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}

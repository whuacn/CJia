//***************************************************
// 文件名（File Name）:      ProjectView.cs
//
// 表（Tables）:          
//                          
// 视图（Views）:           
// 
// 作者（Author）:           曾翠玲
//
// 日期（Create Date）:     2013.4.8
// 
// 修改记录（Revision History）：
//               R1：
//                   修改作者：
//                   修改日期：
//                   修改理由：
//
//***************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;

namespace CJia.PEIS.App.UI
{
    public partial class ProjectView : CJia.PEIS.Tools.View,CJia.PEIS.Views.IProjectView
    {
        public ProjectView()
        {
            InitializeComponent();

        }

        protected override object CreatePresenter()
        {
            return new Presenters.ProjectPresenter(this);
        }

        private void ProjectView_Load(object sender, EventArgs e)
        {
            OnInit(null, null);
            this.btnCancel.Visible = false;
            this.btnStop.Visible = true;
            this.btnReStart.Visible = false;
            this.chklstctlControlValue.Visible = false;
            gridProject_Click(null,null);
        }

        /// <summary>
        /// 判断按钮状态，1代表按钮为取消，2代表新增
        /// </summary>
        int btnStatus = 1;

        /// <summary>
        /// 控件预设值按钮状态，1代表“<<”， 0代表“>>”
        /// </summary>
        int btnLoadControlValueStatus = 1;
        Views.ProjectEventArgs proEventArgs = new Views.ProjectEventArgs();
        

        /// <summary>
        /// 绑定科室项目
        /// </summary>
        /// <param name="dtDeptProInfo">科室及所属项目信息</param>
        public void ExeDeptProBindTree(DataTable dtDeptProInfo)
        {
            this.trstDeptPro.DataSource = dtDeptProInfo;
            this.trstDeptPro.KeyFieldName = "key_id";
            this.trstDeptPro.ParentFieldName = "parent_id";
        }

        /// <summary>
        /// 绑定排序号
        /// </summary>
        /// <param name="proSortNo"></param>
        public void ExeBindProSortNo(long proSortNo)
        {
            this.txtSortNo.Text = proSortNo.ToString();
        }

        /// <summary>
        /// 绑定网格项目数据
        /// </summary>
        /// <param name="dtGridPro"></param>
        public void ExeBindGridPro(DataTable dtGridPro)
        {
            this.gridProject.DataSource = dtGridPro;
        }

        /// <summary>
        /// 绑定Grid网格项目数据
        /// </summary>
        /// <param name="dtGridPro"></param>
        public void ExeBindGridProject(DataTable dtGridPro)
        {
            this.gridProject.DataSource = dtGridPro;
        }

        #region 绑定下拉列表

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
        /// 绑定项目类型下拉框
        /// </summary>
        /// <param name="dtProType"></param>
        public void ExeBindProType(DataTable dtProType)
        {
            this.cbProType.Properties.DataSource = dtProType;
            this.cbProType.Properties.ValueMember = "pro_type_id";
            this.cbProType.Properties.DisplayMember = "pro_type_name";
            if (dtProType.Rows.Count == 0)
            {
                AddNewRowWhenNull(dtProType);
            }
            this.cbProType.EditValue = dtProType.Rows[0]["pro_type_id"];  // 默认值
        }

        /// <summary>
        /// 绑定下拉短信设置
        /// </summary>
        /// <param name="dtSmsSet"></param>
        public void ExeBindSmsSet(DataTable dtSmsSet)
        {
            this.cbSmsSet.Properties.DataSource = dtSmsSet;
            this.cbSmsSet.Properties.ValueMember = "sms_set_id";
            this.cbSmsSet.Properties.DisplayMember = "sms_set_name";
            if (dtSmsSet.Rows.Count == 0)
            {
                AddNewRowWhenNull(dtSmsSet);
            }
            this.cbSmsSet.EditValue = dtSmsSet.Rows[0]["sms_set_id"];  // 默认值
        }

       
        /// <summary>
        /// 绑定是否为餐前项目
        /// </summary>
        /// <param name="dtBeforeMeal"></param>
        public void ExeBindBeforeMeal(DataTable dtBeforeMeal)
        {
            this.cbBeforeMeal.Properties.DataSource = dtBeforeMeal;
            this.cbBeforeMeal.Properties.ValueMember = "is_before_meal_id";
            this.cbBeforeMeal.Properties.DisplayMember = "is_before_meal_name";
            if (dtBeforeMeal.Rows.Count == 0)
            {
                AddNewRowWhenNull(dtBeforeMeal);
            }
            this.cbBeforeMeal.EditValue = dtBeforeMeal.Rows[0]["is_before_meal_id"];  // 默认值
        }

        /// <summary>
        /// 绑定适用类别
        /// </summary>
        /// <param name="dtApplyGender"></param>
        public void ExeBindApplyGender(DataTable dtApplyGender)
        {
            this.cbApplyGender.Properties.DataSource = dtApplyGender;
            this.cbApplyGender.Properties.ValueMember = "code_id";
            this.cbApplyGender.Properties.DisplayMember = "code_name";
            if (dtApplyGender.Rows.Count == 0)
            {
                AddNewRowWhenNull(dtApplyGender);
            }
            this.cbApplyGender.EditValue = dtApplyGender.Rows[0]["code_id"];  // 默认值
        }

        /// <summary>
        /// 绑定费用类别
        /// </summary>
        /// <param name="dtCostType"></param>
        public void ExeBindCostType(DataTable dtCostType)
        {
            this.cbCostType.Properties.DataSource = dtCostType;
            this.cbCostType.Properties.ValueMember = "cost_type_id";
            this.cbCostType.Properties.DisplayMember = "cost_type_name";
            if (dtCostType.Rows.Count == 0)
            {
                AddNewRowWhenNull(dtCostType);
            }
            this.cbCostType.EditValue = dtCostType.Rows[0]["cost_type_id"];  // 默认值
        }

        /// <summary>
        /// 绑定标本种类
        /// </summary>
        /// <param name="dtSpeciesType"></param>
        public void ExeBindSpeciesType(DataTable dtSpeciesType)
        {
            this.cbSpeciesType.Properties.DataSource = dtSpeciesType;
            this.cbSpeciesType.Properties.ValueMember = "species_type_id";
            this.cbSpeciesType.Properties.DisplayMember = "species_type_name";
            if (dtSpeciesType.Rows.Count == 0)
            {
                AddNewRowWhenNull(dtSpeciesType);
            }
            this.cbSpeciesType.EditValue = dtSpeciesType.Rows[0]["species_type_id"];  // 默认值
        }

        /// <summary>
        /// 绑定下拉计量单位
        /// </summary>
        /// <param name="dtUnitMeasurement"></param>
        public void ExeBindUnitMeasurement(DataTable dtUnitMeasurement)
        {
            this.cbUnitMeasurement.Properties.DataSource = dtUnitMeasurement;
            this.cbUnitMeasurement.Properties.ValueMember = "unit_id";
            this.cbUnitMeasurement.Properties.DisplayMember = "unit_name";
            if (dtUnitMeasurement.Rows.Count == 0)
            {
                AddNewRowWhenNull(dtUnitMeasurement);
            }
            this.cbUnitMeasurement.EditValue = dtUnitMeasurement.Rows[0]["unit_id"];  // 默认值
        }

        /// <summary>
        /// 绑定下拉常用项目类别
        /// </summary>
        /// <param name="dtCommonProType"></param>
        public void ExeBindCommonProType(DataTable dtCommonProType)
        {
            this.cbCommonProType.Properties.DataSource = dtCommonProType;
            this.cbCommonProType.Properties.ValueMember = "common_pro_type_id";
            this.cbCommonProType.Properties.DisplayMember = "common_pro_type_name";
            if (dtCommonProType.Rows.Count == 0)
            {
                AddNewRowWhenNull(dtCommonProType);
            }
            this.cbCommonProType.EditValue = dtCommonProType.Rows[0]["common_pro_type_id"];  // 默认值
        }

        /// <summary>
        /// 绑定空间类型
        /// </summary>
        /// <param name="dtControlType"></param>
        public void ExeBindControlType(DataTable dtControlType)
        {
            this.cbControlType.Properties.DataSource = dtControlType;
            this.cbControlType.Properties.ValueMember = "control_id";
            this.cbControlType.Properties.DisplayMember = "control_name";
            if (dtControlType.Rows.Count == 0)
            {
                AddNewRowWhenNull(dtControlType);
            }
            this.cbControlType.EditValue = dtControlType.Rows[0]["control_id"];
        }
        #endregion



        // 获取treelist焦点ID
        private void trstDeptPro_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            DataRowView dr = trstDeptPro.GetDataRecordByNode(e.Node) as DataRowView;
            proEventArgs.DeptId = long.Parse(dr["dept_id"].ToString());
            proEventArgs.ParentId = long.Parse(dr["key_id"].ToString());

            OnAfterFocusNodeDeptPro(sender,proEventArgs);
        }

        /// <summary>
        /// 控件置空
        /// </summary>
        private void SetNull()
        {
            this.txtProName.Text = "";
            this.txtEnglishName.Text = "";
            this.txtDefaultValue.Text = "";
            this.txtReferencePrice.Text = "";
            this.txtExePrice.Text = "";
            this.txtControlDefaultValue.Text = "";
            this.txtControlWidth.Text = "";
            this.txtRefUpMail.Text = "";
            this.txtRefUpFemail.Text = "";
            this.txtRefUpPrompt.Text = "";
            this.txtRefLowerMail.Text = "";
            this.txtRefLowerFemail.Text = "";
            this.txtRefLowerPrompt.Text = "";
            this.txtAlarmUpMail.Text = "";
            this.txtAlarmUpFemail.Text = "";
            this.txtAlarmUpPrompt.Text = "";
            this.txtAlarmLowerMail.Text = "";
            this.txtAlarmLowerFemail.Text = "";
            this.txtAlarmLowerPrompt.Text = "";
            chkIsReadDataDirect.Checked = false;
            chkIsFeePro.Checked = false;
            chkIsInputPro.Checked = false; ;
            chkIsNumericPro.Checked = false;
            chkIsSumMust.Checked = false;

            this.btnAdd.Visible = false;
            this.btnCancel.Visible = true;
            gridProject.Enabled = false;
        }

        // 添加项目
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnStatus == 1)
            {
                btnStatus = 2;
                SetNull();
                OnAddPro(sender, proEventArgs);
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
                this.gridProject.Enabled = true;
            }
        }


        // 保存项目
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtProName.Text == "")
            {
                MessageBox.Show("项目名称不能为空");
                this.txtProName.Focus();
                return;
            }
            if (this.txtSortNo.Text == "")
            {
                MessageBox.Show("排序号不能为空");
                this.txtSortNo.Focus();
                return;
            }
           
            proEventArgs.ProName = this.txtProName.Text;
            proEventArgs.SortNo = long.Parse(this.txtSortNo.Text);
            proEventArgs.ProFirstPinyin = CJia.Controls.CJiaSpellEditor.ToChString(this.txtProName.Text);
            proEventArgs.ProEnglishName = this.txtEnglishName.Text;
            proEventArgs.ProType = int.Parse(this.cbProType.EditValue.ToString());
            proEventArgs.CommonProType = int.Parse(this.cbCommonProType.EditValue.ToString());
            proEventArgs.DefaultValue = this.txtDefaultValue.Text;
            proEventArgs.UnitMeasurement = int.Parse(this.cbUnitMeasurement.EditValue.ToString());
            proEventArgs.ApplyGender = int.Parse(this.cbApplyGender.EditValue.ToString());
            proEventArgs.CostType = int.Parse(this.cbCostType.EditValue.ToString());
            proEventArgs.ControlType = int.Parse(this.cbControlType.EditValue.ToString());
            proEventArgs.ControlDefaultName = this.txtControlDefaultValue.Text;
            if (this.txtControlWidth.Text != "")
            {
                proEventArgs.ControlTypeWidth = double.Parse(this.txtControlWidth.Text);
            }
            if(chkIsInputPro.Checked)
            {
                proEventArgs.IsInputPro = "1";
            }
            if (chkIsFeePro.Checked)
            {
                proEventArgs.IsFeePro = "1";
            }
            proEventArgs.BeroreMeal = int.Parse(this.cbBeforeMeal.EditValue.ToString());
            proEventArgs.SmsSet = int.Parse(this.cbSmsSet.EditValue.ToString());
            if(chkIsReadDataDirect.Checked)
            {
                proEventArgs.IsReadDataDirect = "1";
            }
            if (this.txtReferencePrice.Text != "")
            {
                proEventArgs.ReferencePrice = double.Parse(this.txtReferencePrice.Text);
            }
            if (this.txtExePrice.Text != "")
            {
                proEventArgs.ExecutePrice = double.Parse(this.txtExePrice.Text);
            }
            if (chkIsNumericPro.Checked)
            {
                proEventArgs.IsNumericalPro = "1";
            }
            proEventArgs.SpeciesType = int.Parse(this.cbSpeciesType.EditValue.ToString());
            if (chkIsSumMust.Checked)
            {
                proEventArgs.IsNumericalPro = "1";
            }
            if (this.txtRefUpMail.Text != "")
            {
                proEventArgs.RefUpMail = double.Parse(this.txtRefUpMail.Text);
            }
            if (this.txtRefUpFemail.Text != "")
            {
                proEventArgs.RefUpFemail = double.Parse(this.txtRefUpFemail.Text);
            }
            if (this.txtRefLowerMail.Text != "")
            {
                proEventArgs.RefUpPrompt = this.txtRefUpPrompt.Text;
            }
            if (this.txtRefLowerMail.Text != "")
            {
                proEventArgs.RefLowerMail = double.Parse(this.txtRefLowerMail.Text);
            }
            if (this.txtRefLowerFemail.Text != "")
            {
                proEventArgs.RefLowerFemail = double.Parse(this.txtRefLowerFemail.Text);
            }
            if (this.txtRefLowerPrompt.Text != "")
            {
                proEventArgs.RefLowerPrompt = this.txtRefLowerPrompt.Text;
            }
            if (this.txtAlarmUpMail.Text != "")
            {
                proEventArgs.AlarmUpMail = double.Parse(this.txtAlarmUpMail.Text);
            }
            if (this.txtAlarmUpFemail.Text != "")
            {
                proEventArgs.AlarmUpFemail = double.Parse(this.txtAlarmUpFemail.Text);
            }
                                              
            proEventArgs.AlarmUpPrompt = this.txtAlarmUpPrompt.Text;
            if (this.txtAlarmLowerMail.Text != "")
            {
                proEventArgs.AlarmLowerMail = double.Parse(this.txtAlarmLowerMail.Text);
            }
            if (this.txtAlarmLowerFemail.Text != "")
            {
                proEventArgs.AlarmLowerFemail = double.Parse(this.txtAlarmLowerFemail.Text);
            }
            proEventArgs.AlarmLowerPrompt = this.txtAlarmLowerPrompt.Text;

            if (proEventArgs.ProType == 0)
            {
                MessageBox.Show("请先添加项目类别");
                this.cbProType.Focus();
                return;
            }
            if (proEventArgs.SmsSet == 0)
            {
                MessageBox.Show("请先添加短信设置选项");
                this.cbSmsSet.Focus();
                return;
            }
            if (proEventArgs.BeroreMeal == 0)
            {
                MessageBox.Show("请先添加是否餐前选项");
                this.cbBeforeMeal.Focus();
                return;
            }
            if (proEventArgs.ApplyGender == 0)
            {
                MessageBox.Show("请先添加性别");
                this.cbApplyGender.Focus();
                return;
            }
            if (proEventArgs.CostType == 0)
            {
                MessageBox.Show("请先添加费用类别");
                this.cbCostType.Focus();
                return;
            }
            if (proEventArgs.SpeciesType == 0)
            {
                MessageBox.Show("请先添加标本种类");
                this.cbSpeciesType.Focus();
                return;
            }
            if (proEventArgs.UnitMeasurement == 0)
            {
                MessageBox.Show("请先添加计量单位");
                this.cbUnitMeasurement.Focus();
                return;
            }
            if (proEventArgs.CommonProType == 0)
            {
                MessageBox.Show("请先添加常用项目类别");
                this.cbCommonProType.Focus();
                return;
            }
            if (proEventArgs.ControlType == 0)
            {
                MessageBox.Show("请先添加控件类别");
                this.cbControlType.Focus();
                return;
            }
            proEventArgs.AddControlValue = this.chklstctlControlValue.DataSource as DataTable;

            if (btnStatus == 1)
            {
                ControlValueCheckedStatus();
                proEventArgs.ProId = long.Parse(gridViewProject.GetFocusedDataRow()["pro_id"].ToString());
                OnUpdatePro(sender,proEventArgs);
            }
            if (btnStatus == 2)
            {
                OnInsertPro(sender, proEventArgs);
            }
            SetNull();
        }

        
        // 停用项目
        private void btnStop_Click(object sender, EventArgs e)
        {
            proEventArgs.ProId = long.Parse(gridViewProject.GetFocusedDataRow()["pro_id"].ToString());
            OnStopPro(sender,proEventArgs);
            this.btnStop.Visible = false;
            this.btnReStart.Visible = true;
        }

        /// <summary>
        /// 启用项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReStart_Click(object sender, EventArgs e)
        {
            proEventArgs.ProId = long.Parse(gridViewProject.GetFocusedDataRow()["pro_id"].ToString());
            OnReStartPro(sender,proEventArgs);
            this.btnStop.Visible = true;
            this.btnReStart.Visible = false;
        }

        // 添加控件默认值
        private void btnAddControlDefault_Click(object sender, EventArgs e)
        {
            proEventArgs.ControlDefaultName = this.txtControlDefaultValue.Text;
            proEventArgs.ProId = long.Parse(gridViewProject.GetFocusedDataRow()["pro_id"].ToString());
            proEventArgs.AddControlValue = this.chklstctlControlValue.DataSource as DataTable;
            OnAddControlDefault(sender,proEventArgs);
        }

        // 显示控件预设值
        private void btnLoadControlValue_Click(object sender, EventArgs e)
        {
            if (btnLoadControlValueStatus == 1)
            {
                this.btnLoadControlValue.CustomText = "<<";
                this.chklstctlControlValue.Visible = true;
                btnLoadControlValueStatus = 0;

            }
            else
            {
                this.btnLoadControlValue.CustomText = ">>";
                this.chklstctlControlValue.Visible = false;
                btnLoadControlValueStatus =1;
            }

        }

        /// <summary>
        /// 绑定控件预设值
        /// </summary>
        /// <param name="dtControlValue"></param>
        public void ExeShowControlValue(DataTable dtControlValue)
        {
            chklstctlControlValue.DataSource = dtControlValue;
            chklstctlControlValue.DisplayMember = "control_default_name";
            chklstctlControlValue.ValueMember = "control_default_id";
            int idx = 0;
            while (this.chklstctlControlValue.GetItemValue(idx) != null)
            {
                if (dtControlValue.Rows[idx]["is_checked"].ToString() == "0")
                {
                    this.chklstctlControlValue.SetItemChecked(idx,false);
                }
                else
                {
                    this.chklstctlControlValue.SetItemChecked(idx,true);
                }
                idx++;
            }
        }

        /// <summary>
        /// 修改控件预设值勾选状态
        /// </summary>
        public void ControlValueCheckedStatus()
        {
            proEventArgs.UpdateControlValue = this.chklstctlControlValue.DataSource as DataTable;
            int idx = 0;
            while (this.chklstctlControlValue.GetItemValue(idx) != null)
            {
                long controlId = long.Parse(this.chklstctlControlValue.GetItemValue(idx).ToString());
                if (this.chklstctlControlValue.GetItemCheckState(idx) == CheckState.Checked)
                {
                    proEventArgs.UpdateControlValue.Rows[idx]["is_checked"] = "1";
                }
                else
                    proEventArgs.UpdateControlValue.Rows[idx]["is_checked"] = "0";
                idx++;
            }
        }

        /// <summary>
        /// 项目状态（启用或者停用）
        /// </summary>
        public void ExeSelectProStatus(string proStatus)
        {
            if (proStatus == "0")
            {
                this.btnStop.Visible = false;
                this.btnReStart.Visible = true;
            }
            else
            {
                this.btnStop.Visible = true;
                this.btnReStart.Visible = false;
            }

        }

        // Grid网格单击事件
        private void gridProject_Click(object sender, EventArgs e)
        {
            if (gridViewProject.FocusedRowHandle < 0)
            {
                return;
            }
            DataRow drPro = gridViewProject.GetFocusedDataRow();
            proEventArgs.ProId = long.Parse(drPro["pro_id"].ToString());
            this.txtProName.Text = drPro["pro_name"].ToString();
            this.txtSortNo.Text = drPro["sort_no"].ToString();
            this.cbProType.EditValue = drPro["pro_type"];
            this.txtEnglishName.Text = drPro["pro_english_name"].ToString();
            this.txtDefaultValue.Text = drPro["default_value"].ToString();
            this.cbUnitMeasurement.EditValue = drPro["unit_measurement"];
            this.cbCostType.EditValue = drPro["cost_type"];
            this.cbBeforeMeal.EditValue = drPro["is_before_meal"];
            this.cbSpeciesType.EditValue = drPro["species_type"];
            this.cbSmsSet.EditValue = drPro["sms_set"];
            this.txtReferencePrice.Text = drPro["reference_price"].ToString();
            this.txtExePrice.Text = drPro["execute_price"].ToString();
            this.cbApplyGender.EditValue = drPro["apply_gender"];
            if (drPro["is_read_data_direct"].ToString() == "0")
            {
                chkIsReadDataDirect.Checked = false;
            }
            else
            {
                chkIsReadDataDirect.Checked = true;
            }
            if (drPro["is_numerical_pro"].ToString() == "0")
            {
                chkIsNumericPro.Checked = false;
            }
            else
            {
                chkIsNumericPro.Checked = true;
            }
            if (drPro["is_input_pro"].ToString() == "0")
            {
                chkIsInputPro.Checked = false;
            }
            else
            {
                chkIsInputPro.Checked = true;
            }
            if (drPro["is_fee_pro"].ToString() == "0")
            {
                chkIsFeePro.Checked = false;
            }
            else
            {
                chkIsFeePro.Checked = true;
            }
            if (drPro["is_sum_must"].ToString() == "0")
            {
                chkIsSumMust.Checked = false;
            }
            else
            {
                chkIsSumMust.Checked = true;
            }
            this.cbControlType.EditValue = drPro["control_type"];
            this.txtControlDefaultValue.Text = drPro["control_value"].ToString();
            this.txtControlWidth.Text = drPro["control_type_width"].ToString();
            this.txtRefUpMail.Text = drPro["reference_ceiling_mail"].ToString();
            this.txtRefUpFemail.Text = drPro["reference_ceiling_femail"].ToString();
            this.txtRefUpPrompt.Text = drPro["reference_ceiling_prompt"].ToString();
            this.txtRefLowerMail.Text = drPro["reference_lower_mail"].ToString();
            this.txtRefLowerFemail.Text = drPro["reference_lower_femail"].ToString();
            this.txtRefLowerPrompt.Text = drPro["reference_lower_prompt"].ToString();
            this.txtAlarmUpMail.Text = drPro["alarm_ceiling_mail"].ToString();
            this.txtAlarmUpFemail.Text = drPro["alarm_ceiling_femail"].ToString();
            this.txtAlarmUpPrompt.Text = drPro["alarm_ceiling_prompt"].ToString();
            this.txtAlarmLowerMail.Text = drPro["alarm_lower_mail"].ToString();
            this.txtAlarmLowerFemail.Text = drPro["alarm_lower_femail"].ToString();
            this.txtAlarmLowerPrompt.Text = drPro["alarm_lower_prompt"].ToString();

            OnGridProjectClick(sender,proEventArgs);
        }

        // 删除所选控件预设值
        private void tlmnusDelete_Click(object sender, EventArgs e)
        {
            DataTable dtControlValue = this.chklstctlControlValue.DataSource as DataTable;
            int idx = 0;
            if (proEventArgs.DeleteControlValue == null)
            {
                proEventArgs.DeleteControlValue = new DataTable();
            }
            //string selectedValue = this.chklstctlControlValue.SelectedValue.ToString();
            while (chklstctlControlValue.GetItemValue(idx) != null)
            {
                //if (chklstctlControlValue.GetItemCheckState(idx) == CheckState.Checked)
                //{
                //    dtControlValue.Rows[idx]["is_checked"] = "1";
                //}
                //else
                //{
                //    dtControlValue.Rows[idx]["is_checked"] = "0";
                //}
                //CheckState ck = this.chklstctlControlValue.GetItemCheckState(idx);
                if (dtControlValue.Rows[idx]["control_default_id"].ToString() == this.chklstctlControlValue.SelectedValue.ToString())
                {
                    if (!proEventArgs.DeleteControlValue.Columns.Contains("control_default_id"))
                    {
                        proEventArgs.DeleteControlValue.Columns.Add("control_default_id", typeof(long));
                    }
                    if (!proEventArgs.DeleteControlValue.Columns.Contains("is_new_col"))
                    {
                        proEventArgs.DeleteControlValue.Columns.Add("is_new_col", typeof(string));
                    }
                    proEventArgs.DeleteControlValue.Rows.Add(long.Parse(dtControlValue.Rows[idx]["control_default_id"].ToString()), "delete");
                    dtControlValue.Rows.Remove(dtControlValue.Rows[idx]);
                    //idx = idx - 1;
                    ExeShowControlValue(dtControlValue);
                    return;
                }
                idx ++;
            }
        }

        #region 事件
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.ProjectEventArgs> OnInit;

        /// <summary>
        /// 添加项目事件
        /// </summary>
        public event EventHandler<Views.ProjectEventArgs> OnAddPro;

        /// <summary>
        /// 插入项目事件
        /// </summary>
        public event EventHandler<Views.ProjectEventArgs> OnInsertPro;

        /// <summary>
        /// 修改项目事件
        /// </summary>
        public event EventHandler<Views.ProjectEventArgs> OnUpdatePro;

        /// <summary>
        /// 添加控件预设值
        /// </summary>
        public event EventHandler<Views.ProjectEventArgs> OnAddControlDefault;

        /// <summary>
        /// 停用项目
        /// </summary>
        public event EventHandler<Views.ProjectEventArgs> OnStopPro;

        /// <summary>
        /// 启用项目
        /// </summary>
        public event EventHandler<Views.ProjectEventArgs> OnReStartPro;
        
        /// <summary>
        /// 单击网格事件
        /// </summary>
        public event EventHandler<Views.ProjectEventArgs> OnGridProjectClick;

        /// <summary>
        /// 删除控件预设值
        /// </summary>
        public event EventHandler<Views.ProjectEventArgs> OnDeleteControlValue;

        /// <summary>
        /// 点击树状结构查询所选中科室下属项目
        /// </summary>
        public event EventHandler<Views.ProjectEventArgs> OnAfterFocusNodeDeptPro;
        #endregion

    }
}

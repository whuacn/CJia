//***************************************************
// 文件名（File Name）:      CheckAdviceView.cs（审方UI层）
//
// 数据表（Tables）:         nothing
// 视图(Views)               nothing           
//
// 作者（Author）:           郭婷
//
// 日期（Create Date）:     2013.1.21
//***************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using CJia.PIVAS.Views;
using CJia;

namespace CJia.PIVAS.App.UI
{
    /// <summary>
    /// 医嘱状态枚举类
    /// </summary>
    public enum AdviceStatus
    {
        待审 = 1000101,
        已审 = 1000102,
        不予配药 = 1000103,
        拒绝 = 1000104
    }
    /// <summary>
    /// 审方
    /// </summary>
    public partial class CheckAdviceView : Tools.View, Views.ICheckAdviceView
    {
        /// <summary>
        /// 审方构造函数
        /// </summary>
        public CheckAdviceView()
        {
            InitializeComponent();
            Init();
            //btnRefresh_Click(null, null);
            this.IimitsManagement();
        }

        /// <summary>
        /// 权限控制
        /// </summary>
        public void IimitsManagement()
        {
            if (User.role == "0")
            {
                this.rgAdviceState.Enabled = true;
                this.panelControl3.Enabled = false;
                this.btnSingleOk.Visible = false;
                this.btnCancelCheck.Visible = false;
                this.btnRefuseAdvice.Visible = false;
                this.btnRefuseDosage.Visible = false;
                this.btnComplete.Visible = false;
                this.gcAdvice.ContextMenuStrip = null;
                //this.cbOffice.Enabled = false;
                //this.cbOffice.SelectedValue = User.DeptId;
                this.ckceIllfield.Enabled = false;
                DateTime now = CJia.PIVAS.Tools.Helper.Sysdate;
                this.deBeginDate.DateTime = new DateTime(now.Year - 1, now.Month, now.Day, 0, 0, 0);
                this.rgAdviceState.EditValue = "所有";
                this.deBeginDate.Enabled = false;
                this.deEndDate.Enabled = false;
                this.ceInvalidAdvice.Enabled = false;
                this.labelControl4.Visible = false;
                //this.cbLong.Enabled = false;
                //this.cbTemporary.Enabled = false;
            }
            if (User.role == "2")
            {
                DateTime now = CJia.PIVAS.Tools.Helper.Sysdate;
                this.deBeginDate.DateTime = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                this.deEndDate.DateTime = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
                this.deBeginDate.Enabled = false;
                this.deEndDate.Enabled = false;
                //this.cbOffice.Enabled = false;
                this.ckceIllfield.Enabled = false;
                this.ceInvalidAdvice.Enabled = false;
                this.rgAdviceState.Enabled = false;
                this.rgAdviceState.EditValue = "未审";
                this.btnUpdateBatch.Visible = false;
                this.btnPatientHistory.Visible = false;
                this.btnPatient.Visible = false;

                //this.panelControl5.Enabled = false;


                this.panelControl3.Enabled = false;
                this.btnSingleOk.Visible = false;
                this.btnCancelCheck.Visible = false;
                this.btnRefuseAdvice.Visible = false;
                this.btnRefuseDosage.Visible = false;
                this.btnComplete.Visible = true;
                this.gcAdvice.ContextMenuStrip = null;
                this.deBeginDate.Enabled = false;
                this.deEndDate.Enabled = false;
                this.labelControl4.Visible = false;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            OnInitLoad(null, null);
            CheckOffice();
            DateTime now = CJia.PIVAS.Tools.Helper.Sysdate;
            DateTime old = CJia.PIVAS.Tools.Helper.Sysdate.AddMonths(-1);
            this.deBeginDate.DateTime = new DateTime(old.Year, old.Month, old.Day, 0, 0, 0);
            this.deEndDate.EditValue = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
            //rgAdviceState.EditValue = "未审";
        }

        //重载CreatePresenter函数
        protected override object CreatePresenter()
        {
            return new Presenters.CheckAdvicePresenter(this);
        }

        // 定义审方参数
        Views.CheckAdviceArgs checkAdviceArgs = new Views.CheckAdviceArgs();

        #region ICheckAdviceView成员
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler OnInitLoad;

        /// <summary>
        /// 刷新医嘱事件
        /// </summary>
        public event EventHandler<Views.CheckAdviceArgs> OnRefresh;

        /// <summary>
        /// 单个通过事件
        /// </summary>
        public event EventHandler<Views.CheckAdviceArgs> OnInsertCheck;

        /// <summary>
        /// 取消审核事件
        /// </summary>
        public event EventHandler<Views.CheckAdviceArgs> OnCancelCheck;

        /// <summary>
        /// 拒绝医嘱事件
        /// </summary>
        public event EventHandler<Views.CheckAdviceArgs> OnRefuseCheck;

        /// <summary>
        /// 查询病人信息事件
        /// </summary>
        public event EventHandler<Views.CheckAdviceArgs> OnPatient;

        /// <summary>
        /// 查询病史资料事件
        /// </summary>
        public event EventHandler<Views.CheckAdviceArgs> OnPatientHistory;

        /// <summary>
        /// 审方完成事件
        /// </summary>
        public event EventHandler<Views.CheckAdviceArgs> OnComplete;

        //配伍禁忌事件
        public event EventHandler<CheckAdviceArgs> OnPWJJ;
        //配伍禁忌
        public void ExeBindPWJJ(string[] data)
        {
            string PWJJInfo = data[1].ToString();
            PWJJInfoView pwjj = new PWJJInfoView(PWJJInfo);
            this.ShowAsWindow("配伍禁忌", pwjj);
        }
        /// <summary>
        /// 绑定可进配置中心的所有病区
        /// </summary>
        /// <param name="data"></param>
        public void ExeBindOffice(DataTable data)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                ckceIllfield.Properties.Items.Add(data.Rows[i]["office_id"].ToString(), data.Rows[i]["office_name"].ToString(),CheckState.Checked,true);

            }

            //cbOffice.DataSource = data;
            //if (data == null)
            //    return;
            //DataRow dr = data.NewRow();
            //dr["office_id"] = "0";
            //dr["office_name"] = "<--全部-->";
            //data.Rows.InsertAt(dr, 0);
            //cbOffice.DisplayMember = "office_name";
            //cbOffice.ValueMember = "office_id";
        }

        /// <summary>
        /// 绑定所有未审医嘱
        /// </summary>
        /// <param name="data"></param>
        public void ExeGetAllNoCheckAdvice(DataTable data)
        {
            gcAdvice.DataSource = data;
            gvAdvice.ExpandAllGroups();
        }

        /// <summary>
        /// 绑定医嘱
        /// </summary>
        /// <param name="data"></param>
        public void ExeGetAdvice(DataTable dtAdvice)
        {
            gcAdvice.DataSource = dtAdvice;
            if (dtAdvice == null)
            {
                btnSingleOk.Enabled = btnCancelCheck.Enabled = btnRefuseAdvice.Enabled = btnUpdateBatch.Enabled = btnRefuseDosage.Enabled = btnPatient.Enabled = btnPatientHistory.Enabled = btnComplete.Enabled = false;
                mbtnSingleOk.Enabled = mbtnCancelCheck.Enabled = mbtnRefuseAdvice.Enabled = mbtnUpdateBatch.Enabled = mbtnRefuseDosage.Enabled = mbtnPatient.Enabled = mbtnPatientHistory.Enabled = mbtnComplete.Enabled = false;
                mbtnUpdateBatch.Enabled = true;
            }
            else
            {
                btnPatient.Enabled = btnPatientHistory.Enabled = true;
                mbtnPatient.Enabled = mbtnPatientHistory.Enabled = true;
            }
            this.repositoryItemLookUpEdit2.DataSource = dtAdvice;
            gvAdvice.ExpandAllGroups();
        }

        ///// <summary>
        ///// 绑定需要插入的待审医嘱
        ///// </summary>
        ///// <param name="dtBatchData"></param>
        //public void ExeGetBatchData(DataTable dtBatchData)
        //{
        //    gcAdvice.DataSource = dtBatchData;
        //    if (dtBatchData == null)
        //    {
        //        btnComplete.Enabled = false;
        //        mbtnComplete.Enabled = false;
        //    }
        //    else
        //    {
        //        btnComplete.Enabled = true;
        //        mbtnComplete.Enabled = true;
        //    }
        //    gvAdvice.ExpandAllGroups();
        //}

        /// <summary>
        /// 绑定病人信息
        /// </summary>
        /// <param name="data"></param>
        public void ExeBindPatient(DataTable data)
        {
            PatientView patientView = new PatientView(data);
            this.ShowAsWindow("病人信息", patientView);
        }

        /// <summary>
        /// 绑定病史资料
        /// </summary>
        /// <param name="data"></param>
        public void ExeBindPatientHistory(DataTable data)
        {
            //重复利用，可用临时变量代替
            DataRow drFocus = gvAdvice.GetFocusedDataRow();
            string patientName = drFocus["PATIENT_NAME"].ToString();
            string inhosId = drFocus["PATIENT_ID"].ToString();
            string illfieldName = drFocus["PATIENT_ILLFILED_NAME"].ToString();
            string officeName = drFocus["PATIENT_OFFICE_NAME"].ToString();
            string bedName = drFocus["BED_NAME"].ToString();
            PatientHistoryView patientHistory = new PatientHistoryView(patientName, inhosId, illfieldName, officeName, bedName, data);
            this.ShowAsWindow("病史资料", patientHistory);
        }

        #endregion

        #region 自定义函数
        /// <summary>
        /// 判断病区是否有数据
        /// </summary>
        private void CheckOffice()
        {
            //if (cbOffice.SelectedIndex < 0)
            //    return;
            //else
            //{
            //    cbOffice.SelectedIndex = 0;
            //}
            string strIllfield = "";
            foreach (string illList in ckceIllfield.Properties.Items.GetCheckedValues())
            {
                strIllfield += "'" + illList + "',";
            }
            if (strIllfield == "")
            {
                return;
            }
        }

        /// <summary>
        /// 固定参数赋值
        /// </summary>
        private void AssignFixParam()
        {
            DateTime beginDate = DateTime.Parse(deBeginDate.EditValue.ToString());
            checkAdviceArgs.BeginListDate = beginDate;  //开始时间
            DateTime endDate = DateTime.Parse(deEndDate.EditValue.ToString());
            checkAdviceArgs.EndListDate = endDate;  //结束时间
            //if (cbOffice.SelectedValue == null)
            //{
            //    return;
            //}
            //checkAdviceArgs.OfficeID = cbOffice.SelectedValue.ToString();    //病区ID
            string strIllfield = "";
            //for (int i = 0; i < ckceIllfield.Properties.Items.Count; i++)
            //{
            //    if (ckceIllfield.Properties.Items[i].CheckState == CheckState.Checked)
            //    {
            //        strIllfield += "'" + ckceIllfield.Properties.Items[i].Value.ToString() + "',";
            //    }
            //}
            foreach (string illList in ckceIllfield.Properties.Items.GetCheckedValues())
            {
                strIllfield += "'" + illList + "',";
            }
            //string strIllfield = ckceIllfield.Properties.GetCheckedItems().ToString();
            if (strIllfield == "")
            {
                checkAdviceArgs.OfficeID = "''";
            }
            else
            {
                checkAdviceArgs.OfficeID = strIllfield.Substring(0, strIllfield.Length - 1);
                //checkAdviceArgs.OfficeID ="'"+ string.Join("','", strIllfield.Split(','))+"'";
            }
            
        }

        /// <summary>
        /// 变化参数赋值
        /// </summary>
        private void AssignChangeParam()
        {
            //成组药品类别按钮是否选中 false标识未选，true标识选中
            if (cePTY.Checked)
            {
                checkAdviceArgs.IsTypePTY = true;
            }
            else
            {
                checkAdviceArgs.IsTypePTY = false;
            }
            if (ceJSY.Checked)
            {
                checkAdviceArgs.IsTypeJSY = true;
            }
            else
            {
                checkAdviceArgs.IsTypeJSY = false;
            }
            if (ceDMY.Checked)
            {
                checkAdviceArgs.IsTypeDMY = true;
            }
            else
            {
                checkAdviceArgs.IsTypeDMY = false;
            }
            if (ceGCY.Checked)
            {
                checkAdviceArgs.IsTypeGCY = true;
            }
            else
            {
                checkAdviceArgs.IsTypeGCY = false;
            }
            if (ceKSS.Checked)
            {
                checkAdviceArgs.IsTypeKSS = true;
            }
            else
            {
                checkAdviceArgs.IsTypeKSS = false;
            }
            checkAdviceArgs.CheckLong = this.cbLong.Checked;
            checkAdviceArgs.CheckTemporary = this.cbTemporary.Checked;
        }

        /// <summary>
        /// 鼠标停留参数赋值
        /// </summary>
        private void MouseFocusParam()
        {
            DataRow drFocus = gvAdvice.GetFocusedDataRow();
            if (drFocus != null)
            {
                checkAdviceArgs.GroupIndex = drFocus["GROUP_INDEX"].ToString();
                checkAdviceArgs.OriginalPivasBatchNo = drFocus["ORIGINAL_PIVAS_BATCH_NO"].ToString();
                checkAdviceArgs.CheckPivasBatchNo = drFocus["CHECK_PIVAS_BATCH_NO"].ToString();
                checkAdviceArgs.CancelReason = drFocus["CANCEL_REASON"].ToString();
                checkAdviceArgs.LongTimeStatus = drFocus["STANDING_FLAG"].ToString();
            }
        }

        /// <summary>
        /// 获得原始医嘱状态
        /// </summary>
        /// <returns>返回原始医嘱状态</returns>
        private int GetOriginalCheckStatus()
        {
            DataRow drFocus = gvAdvice.GetFocusedDataRow();
            int originalCheckPivasStatus = 0;   //原始审核状态
            if (drFocus != null)
            {
                originalCheckPivasStatus = int.Parse(drFocus["CHECK_PIVAS_STATUS"].ToString());
            }
            return originalCheckPivasStatus;
        }

        /// <summary>
        /// 判断审核状态
        /// </summary>
        private bool CheckAdviceStatus()
        {
            bool flag = true;
            int originalCheckPivasStatus = GetOriginalCheckStatus();
            if (originalCheckPivasStatus == 0)
            {
                Message.Show("请先选择一行数据");
                flag = false;
            }
            if (originalCheckPivasStatus == (int)(AdviceStatus)Enum.Parse(typeof(AdviceStatus), "已审", true))
            {
                Message.Show("已审核");
                flag = false;
            }
            if (originalCheckPivasStatus == (int)(AdviceStatus)Enum.Parse(typeof(AdviceStatus), "不予配药", true))
            {
                Message.Show("已拒绝配药");
                flag = false;
            }
            if (originalCheckPivasStatus == (int)(AdviceStatus)Enum.Parse(typeof(AdviceStatus), "拒绝", true))
            {
                Message.Show("已拒绝医嘱");
                flag = false;
            }
            return flag;
        }
        /// <summary>
        /// 判断是否可以撤销审核
        /// </summary>
        private bool IsCanCancelCheck()
        {
            bool flag = true;
            int originalCheckPivasStatus = GetOriginalCheckStatus();
            if (originalCheckPivasStatus == 0)
            {
                Message.Show("请先选择一行数据！");
                flag = false;
            }
            if (originalCheckPivasStatus == (int)(AdviceStatus)Enum.Parse(typeof(AdviceStatus), "待审", true))
            {
                Message.Show("未审核，请先审核");
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// 根据选择所有、未审、已审按钮控制按钮是否可以点击
        /// </summary>
        private void CheckrgAdviceState()
        {
            if (rgAdviceState.EditValue.ToString() == "所有")
            {
                checkAdviceArgs.IsValidCheck = checkAdviceArgs.IsNoCheck = checkAdviceArgs.IsYesCheck = false;
                checkAdviceArgs.IsAllCheck = btnSingleOk.Enabled = btnCancelCheck.Enabled = btnRefuseAdvice.Enabled = btnRefuseDosage.Enabled = btnUpdateBatch.Enabled = btnComplete.Enabled = true;
                mbtnSingleOk.Enabled = mbtnRefuseAdvice.Enabled = mbtnRefuseDosage.Enabled = mbtnUpdateBatch.Enabled = mbtnComplete.Enabled = mbtnCancelCheck.Enabled = true;
            }
            else if (rgAdviceState.EditValue.ToString() == "未审")
            {
                //checkAdviceArgs.IsValidCheck = checkAdviceArgs.IsAllCheck = checkAdviceArgs.IsYesCheck = btnCancelCheck.Enabled = btnUpdateBatch.Enabled = false;
                checkAdviceArgs.IsValidCheck = checkAdviceArgs.IsAllCheck = checkAdviceArgs.IsYesCheck = btnCancelCheck.Enabled = false;
                btnUpdateBatch.Enabled = true;
                mbtnCancelCheck.Enabled = mbtnUpdateBatch.Enabled = false;
                mbtnUpdateBatch.Enabled = true;
                checkAdviceArgs.CheckPivasStatus = (int)(AdviceStatus)Enum.Parse(typeof(AdviceStatus), "待审", true);
                checkAdviceArgs.IsNoCheck = btnSingleOk.Enabled = btnRefuseAdvice.Enabled = btnRefuseDosage.Enabled = btnComplete.Enabled = true;
                mbtnSingleOk.Enabled = mbtnRefuseAdvice.Enabled = mbtnRefuseDosage.Enabled = mbtnComplete.Enabled = true;
            }
            else if (rgAdviceState.EditValue.ToString() == "已审")
            {
                checkAdviceArgs.IsValidCheck = checkAdviceArgs.IsAllCheck = checkAdviceArgs.IsNoCheck = btnSingleOk.Enabled = btnRefuseAdvice.Enabled = btnRefuseDosage.Enabled = btnComplete.Enabled = false;
                mbtnSingleOk.Enabled = mbtnRefuseAdvice.Enabled = mbtnRefuseDosage.Enabled = mbtnComplete.Enabled = false;
                checkAdviceArgs.CheckPivasStatus = (int)(AdviceStatus)Enum.Parse(typeof(AdviceStatus), "已审", true);
                checkAdviceArgs.IsYesCheck = btnCancelCheck.Enabled = btnUpdateBatch.Enabled = true;
                mbtnCancelCheck.Enabled = mbtnUpdateBatch.Enabled = true;
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        public void NewRefresh()
        {
            HelperTools.GridViewLocationcs gridViewLocationcs = new HelperTools.GridViewLocationcs(this.gvAdvice);
            gridViewLocationcs.GetLocation();
            if (ceInvalidAdvice.Checked)//无效
            {
                //参数
                checkAdviceArgs.IsValidCheck = true;
                checkAdviceArgs.IsAllCheck = checkAdviceArgs.IsYesCheck = checkAdviceArgs.IsNoCheck = false;
                //控制按钮显示隐藏
                rgAdviceState.Enabled = cePTY.Enabled = ceJSY.Enabled = ceDMY.Enabled = ceGCY.Enabled = btnSingleOk.Enabled = btnRefuseAdvice.Enabled = btnRefuseDosage.Enabled = btnUpdateBatch.Enabled = btnComplete.Enabled = false;
                mbtnSingleOk.Enabled = mbtnRefuseAdvice.Enabled = mbtnRefuseDosage.Enabled = mbtnUpdateBatch.Enabled = mbtnComplete.Enabled = false;
                btnCancelCheck.Enabled = true;
                mbtnCancelCheck.Enabled = true;
                //执行方法
                AssignFixParam();
                AssignChangeParam();
                if (OnRefresh != null)
                {
                    OnRefresh(null, checkAdviceArgs);
                }
            }
            else
            {
                rgAdviceState.Enabled = cePTY.Enabled = ceJSY.Enabled = ceDMY.Enabled = ceGCY.Enabled = true;
                RGAdviceStateChange();
            }
            if (User.role == "2")
            {
                this.rgAdviceState.Enabled = false;
            }
            gridViewLocationcs.SetLocation();
        }

        /// <summary>
        /// //所有、已审、未审按钮改变事件
        /// </summary>
        public void RGAdviceStateChange()
        {
            CheckrgAdviceState();
            AssignFixParam();
            AssignChangeParam();
            if (OnRefresh != null)
            {
                OnRefresh(null, checkAdviceArgs);
            }
        }

        /// <summary>
        /// 长期临时按钮改变事件
        /// </summary>
        private void cbLongTemporaryCheckedChanged()
        {
            CheckrgAdviceState();
            AssignFixParam();
            AssignChangeParam();
            if (OnRefresh != null)
            {
                OnRefresh(null, checkAdviceArgs);
            }
        }

        /// <summary>
        /// 单个通过
        /// </summary>
        public void SingleOk()
        {
            if (CheckAdviceStatus())
            {
                DataRow drFocus = gvAdvice.GetFocusedDataRow();
                string isPwjj = drFocus["IS_PWJJ"].ToString();
                string pharmStatus = drFocus["PHARM_STATUS"].ToString();
                if (isPwjj == "0")
                {
                    Message.Show("该医嘱违反配伍禁忌！无法进行审核！");
                    return;
                }
                if (pharmStatus == "0")
                {
                    Message.Show("该医嘱对应药品无效！无法进行审核！");
                    return;
                }
                MouseFocusParam();
                checkAdviceArgs.OriginalPivasStatus = GetOriginalCheckStatus();
                checkAdviceArgs.CheckPivasStatus = (int)(AdviceStatus)Enum.Parse(typeof(AdviceStatus), "已审", true);
                if (OnInsertCheck != null)
                {
                    OnInsertCheck(null, checkAdviceArgs);
                }
                NewRefresh();
            }
        }

        /// <summary>
        /// 撤销审核
        /// </summary>
        public void CancelCheck()
        {
            if (IsCanCancelCheck())
            {
                MouseFocusParam();
                if (CJia.PIVAS.Tools.Message.ShowQuery("是否确认撤销审核", CJia.PIVAS.Tools.Message.Button.YesNo) == CJia.PIVAS.Tools.Message.Result.Yes)
                {
                    checkAdviceArgs.OriginalPivasStatus = GetOriginalCheckStatus();
                    checkAdviceArgs.CheckPivasStatus = (int)(AdviceStatus)Enum.Parse(typeof(AdviceStatus), "待审", true);
                    if (OnCancelCheck != null)
                    {
                        OnCancelCheck(null, checkAdviceArgs);
                    }
                    NewRefresh();
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 拒绝医嘱
        /// </summary>
        public void RefuseAdvice()
        {
            if (CheckAdviceStatus())
            {
                if (CJia.PIVAS.Tools.Message.ShowQuery("是否确认拒绝医嘱", CJia.PIVAS.Tools.Message.Button.YesNo) == CJia.PIVAS.Tools.Message.Result.Yes)
                {
                    MouseFocusParam();
                    checkAdviceArgs.OriginalPivasStatus = GetOriginalCheckStatus();
                    checkAdviceArgs.CheckPivasStatus = (int)(AdviceStatus)Enum.Parse(typeof(AdviceStatus), "拒绝", true);
                    if (OnRefuseCheck != null)
                    {
                        OnRefuseCheck(null, checkAdviceArgs);
                    }
                    NewRefresh();
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 拒绝配药
        /// </summary>
        public void RefuseDosage()
        {
            if (CheckAdviceStatus())
            {
                if (CJia.PIVAS.Tools.Message.ShowQuery("是否确认拒绝配药", CJia.PIVAS.Tools.Message.Button.YesNo) == CJia.PIVAS.Tools.Message.Result.Yes)
                {
                    MouseFocusParam();
                    checkAdviceArgs.OriginalPivasStatus = GetOriginalCheckStatus();
                    checkAdviceArgs.CheckPivasStatus = (int)(AdviceStatus)Enum.Parse(typeof(AdviceStatus), "不予配药", true);
                    if (OnRefuseCheck != null)
                    {
                        OnRefuseCheck(null, checkAdviceArgs);
                    }
                    NewRefresh();
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 修改批次
        /// </summary>
        public void UpdateBatch()
        {
            DataRow drFocus = gvAdvice.GetFocusedDataRow();
            if (drFocus["STANDING_FLAG"].ToString() == "0")
            {
                Message.Show("临时医嘱不能修改批次!");
                return;
            }
            MouseFocusParam();
            checkAdviceArgs.OriginalPivasStatus = GetOriginalCheckStatus();
            if (checkAdviceArgs.OriginalPivasStatus == 1000101)
            {
                checkAdviceArgs.CheckPivasStatus = (int)(AdviceStatus)Enum.Parse(typeof(AdviceStatus), "已审", true);
                if (OnInsertCheck != null)
                {
                    OnInsertCheck(null, checkAdviceArgs);
                }
                checkAdviceArgs.CheckPivasStatus = (int)(AdviceStatus)Enum.Parse(typeof(AdviceStatus), "待审", true);
                if (OnCancelCheck != null)
                {
                    OnCancelCheck(null, checkAdviceArgs);
                }
            }
            bool flag = true;
            //if (int.Parse(drFocus["CHECK_PIVAS_STATUS"].ToString()) != (int)(AdviceStatus)Enum.Parse(typeof(AdviceStatus), "已审", true))
            //{
            //    Message.Show("审核状态不符合要求！");
            //    flag = false;
            //}
            string groupIndex = "0";
            string frequencyName = "";
            string illfieldId = "";
            List<string> batchs = null;
            if (drFocus["GROUP_INDEX"].ToString() != null)
            {
                groupIndex = drFocus["GROUP_INDEX"].ToString();
            }
            else
            {
                Message.Show("请先选择一行数据！");
                flag = false;
            }
            if (drFocus["FREQUENCY_NAME"].ToString() != null)
            {
                frequencyName = drFocus["FREQUENCY_NAME"].ToString();
            }
            else
            {
                Message.Show("频率为空！");
                flag = false;
            }
            illfieldId = drFocus["PATIENT_ILLFILED_CODE"].ToString();
            if (drFocus["CHECK_PIVAS_BATCH_NO"].ToString() != null)
            {
                batchs = CJia.PIVAS.Common.BatchHandle(drFocus["CHECK_PIVAS_BATCH_NO"].ToString());
            }
            else
            {
                Message.Show("批次号为空！");
                flag = false;
            }
            if (flag)
            {
                CJia.PIVAS.App.UI.DataManage.EditFrequencyToBatchView editFrequencyBatch = new DataManage.EditFrequencyToBatchView(2, groupIndex, frequencyName, illfieldId, batchs);
                this.ShowAsWindow("修改批次", editFrequencyBatch);
                NewRefresh();
            }
        }

        /// <summary>
        /// 查询病史资料
        /// </summary>
        public void SelectPatientHistory()
        {
            DataRow drFocus = gvAdvice.GetFocusedDataRow();
            if (drFocus == null)
            {
                Message.Show("请先选择一行数据！");
                return;
            }
            checkAdviceArgs.InhosId = drFocus["INHOS_ID"].ToString();
            if (OnPatientHistory != null)
            {
                OnPatientHistory(null, checkAdviceArgs);
            }
        }

        /// <summary>
        /// 查询病人信息
        /// </summary>
        public void SelectPatientInfo()
        {
            DataRow drFocus = gvAdvice.GetFocusedDataRow();
            if (drFocus == null)
            {
                Message.Show("请先选择一行数据！");
                return;
            }
            checkAdviceArgs.InhosId = drFocus["INHOS_ID"].ToString();
            if (OnPatient != null)
            {
                OnPatient(null, checkAdviceArgs);
            }
        }

        /// <summary>
        /// 全部通过
        /// </summary>
        public void CompleteCheck()
        {
            CheckrgAdviceState();
            //add 0118
            btnComplete.Enabled = false;
            //end
            AssignFixParam();
            AssignChangeParam();
            MouseFocusParam();
            //checkAdviceArgs.CheckPivasStatus = (int)(AdviceStatus)Enum.Parse(typeof(AdviceStatus), "已审", true);
            if (OnComplete != null)
            {
                OnComplete(null, checkAdviceArgs);
            }
            NewRefresh();
        }

        ///// <summary>
        ///// 判断是否可以修改批次
        ///// </summary>
        //private bool IsCanUpdateBatch()
        //{
        //    bool flag = true;
        //    DataRow drFocus = gvAdvice.GetFocusedDataRow();
        //    if (int.Parse(drFocus["CHECK_PIVAS_STATUS"].ToString()) != int.Parse(AdviceStatus.已审.ToString()))
        //    {
        //        Message.Show("审核状态不符合要求！");
        //        flag = false;
        //    }
        //    int groupIndex = 0;
        //    string frequencyName = "";
        //    List<int> batchs = null;
        //    if (drFocus["GROUP_INDEX"].ToString() != null)
        //    {
        //        groupIndex = int.Parse(drFocus["GROUP_INDEX"].ToString());
        //    }
        //    else
        //    {
        //        Message.Show("请先选择一行数据！");
        //        flag = false;
        //    }
        //    if (drFocus["FREQUENCY_NAME"].ToString() != null)
        //    {
        //        frequencyName = drFocus["FREQUENCY_NAME"].ToString();
        //    }
        //    else
        //    {
        //        Message.Show("频率为空！");
        //        flag = false;
        //    }
        //    if (drFocus["CHECK_PIVAS_BATCH_NO"].ToString() != null)
        //    {
        //        batchs = CJia.PIVAS.Common.BatchHandle(drFocus["CHECK_PIVAS_BATCH_NO"].ToString());
        //    }
        //    else
        //    {
        //        Message.Show("批次号为空！");
        //        flag = false;
        //    }
        //    return flag;
        //}
        #endregion

        #region 按钮事件
        //刷新按钮
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            NewRefresh();
        }

        //所有、已审、未审按钮
        private void rgAdviceState_EditValueChanged(object sender, EventArgs e)
        {
            RGAdviceStateChange();
        }

        private void cbLongTemporary_CheckedChanged(object sender, EventArgs e)
        {
            cbLongTemporaryCheckedChanged();
        }

        //单个通过按钮
        private void btnSingleOk_Click(object sender, EventArgs e)
        {
            SingleOk();
        }

        //撤销审核按钮
        private void btnCancelCheck_Click(object sender, EventArgs e)
        {
            CancelCheck();
        }

        //拒绝医嘱按钮
        private void btnRefuseAdvice_Click(object sender, EventArgs e)
        {
            RefuseAdvice();
        }

        //拒绝配药按钮
        private void btnRefuseDosage_Click(object sender, EventArgs e)
        {
            RefuseDosage();
        }

        //修改批次按钮
        private void btnUpdateBatch_Click(object sender, EventArgs e)
        {
            UpdateBatch();
        }

        //病史资料按钮
        private void btnPatientHistory_Click(object sender, EventArgs e)
        {
            SelectPatientHistory();
        }

        //病人信息按钮
        private void btnPatient_Click(object sender, EventArgs e)
        {
            SelectPatientInfo();
        }

        //审方完成按钮
        private void btnComplete_Click(object sender, EventArgs e)
        {

            CompleteCheck();
            btnComplete.Enabled = true;
        }
        #endregion

        #region 快捷键
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
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

        #region 显示有异常的医嘱
        private void gvAdvice_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (gvAdvice.RowCount > 0)
            {
                for (int i = 0; i < gvAdvice.RowCount; i++)
                {
                    string isInPivas = "1";
                    isInPivas = this.gvAdvice.GetRowCellDisplayText(e.RowHandle, this.colIsInPivas);
                    if (isInPivas == "0")
                    {
                        e.Appearance.BackColor = System.Drawing.Color.White;
                        e.Appearance.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            //如果医嘱为配伍禁忌  则背景色变红
            if (e.RowHandle >= 0)
            {
                string isPWJJ = this.gvAdvice.GetDataRow(e.RowHandle)["IS_PWJJ"].ToString();
                if (isPWJJ == "0")
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
            // 药品状态
            if (e.RowHandle >= 0)
            {
                string phamrStatus = this.gvAdvice.GetDataRow(e.RowHandle)["PHARM_STATUS"].ToString();
                if (phamrStatus == "0")
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }
        #endregion
        //配伍禁忌
        private void mbtnPWJJ_Click(object sender, EventArgs e)
        {
            if (gvAdvice.GetFocusedDataRow() != null)
            {
                checkAdviceArgs.GroupIndex = gvAdvice.GetFocusedDataRow()["GROUP_INDEX"].ToString();
                OnPWJJ(sender, checkAdviceArgs);
            }
        }



    }
}

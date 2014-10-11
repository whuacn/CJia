using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Health.App.UI
{
    public partial class DoctorManageView : CJia.Health.Tools.View, CJia.Health.Views.IDoctorManageView
    {
        public DoctorManageView()
        {
            InitializeComponent();
            LoadData();
            LpDes.GetData += LpDes_GetData;
            LpDept.GetData += LpDept_GetData;
            GetFocusData();
        }

        bool isDocNoHave = false;

        void LpDept_GetData(object sender, Controls.CJiaRTLookUpArgs e)
        {
            if (OnQueryDept != null)
            {
                doctorArgs.KeyWord = e.SearchValue.Trim().ToUpper();
                OnQueryDept(sender, doctorArgs);
            }
        }

        void LpDes_GetData(object sender, Controls.CJiaRTLookUpArgs e)
        {
            if (OnQueryDocDescript != null)
            {
                doctorArgs.KeyWord = e.SearchValue.Trim().ToUpper();
                OnQueryDocDescript(sender, doctorArgs);
            }
        }
        protected override object CreatePresenter()
        {
            return new Presenters.DoctorManagePresenter(this);
        }

        Views.DoctorArgs doctorArgs = new Views.DoctorArgs();

        private void DoctorManageView_SizeChanged(object sender, EventArgs e)
        {
            int formHeight = this.Height;
            int formWidth = this.Width;
            int pnlHeight;
            pnlHeight = formHeight;
            int location = (formWidth - pnlDoctor.Width) / 2;
            pnlDoctor.Location = new Point(location, 5);
            this.VerticalScroll.Value = VerticalScroll.Minimum;
        }

        /// <summary>
        /// 根据关键字查询医生信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DocSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            doctorArgs.KeyWord = DocSearch.Text;
            OnQueryDoctor(null, doctorArgs);
        }

        /// <summary>
        /// 焦点行变化时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetFocusData();
        }

        /// <summary>
        /// 获得网格焦点行的数据并绑定
        /// </summary>
        private void GetFocusData()
        {
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr != null)
            {
                TxtDocNo.Text = dr["DOCTOR_NO"].ToString();
                TxtDocName.Text = dr["DOCTOR_NAME"].ToString();
                TxtDocPinYin.Text = dr["FIRST_PINYIN"].ToString();
                LpDes.DisplayValue = dr["DOCTOR_DESCRIPT"].ToString();
                LpDes.DisplayText = dr["NAME"].ToString();
                LpDes.Text = dr["NAME"].ToString();
                LpDept.DisplayValue = dr["DEPT_ID"].ToString();
                LpDept.DisplayText = dr["DEPT_NAME"].ToString();
                LpDept.Text = dr["DEPT_NAME"].ToString();
                doctorArgs.DoctorId = dr["DOCTOR_ID"].ToString();
            }
        }
        /// <summary>
        /// 添加一条医生信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddProject_Click(object sender, EventArgs e)
        {
            if (Common.CheckIsNotNull(this, "TxtDocName", "医生名称") && Common.CheckIsNotNull(this, "TxtDocNo", "医生编号") && Common.CheckIsNotNull(this, "TxtDocPinYin", "医生拼音查询码"))
            {
                SetDoctorArgs();
                Models.DoctorManageModel model = new Models.DoctorManageModel();
                doctorArgs.DoctorId = " ";
                int i = model.CheckDocIsRepeat(doctorArgs.DoctorNo, doctorArgs.DoctorId);
                if (i == 0)
                {
                    if (CJia.Health.Tools.Message.ShowQuery("是否添加此医生信息", CJia.Health.Tools.Message.Button.YesNo) == CJia.Health.Tools.Message.Result.Yes)
                    {
                        if (checkBox.Checked)
                        {
                            OnCheckDoctorNo(null, doctorArgs);
                            if (isDocNoHave)
                            {
                                MessageBox.Show("此工号已有用户使用，请更改！");
                                TxtDocNo.Focus();
                                TxtDocNo.SelectAll();
                                return;
                            }
                            else
                            {
                                OnInsertUserDoc(null, doctorArgs);
                            }
                        }
                        else
                        {
                            OnInsertDoctor(null, doctorArgs);
                        }
                        LoadData();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("此医生编号已存在");
                    TxtDocNo.Focus();
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 修改医生信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdateProject_Click(object sender, EventArgs e)
        {
            if (Common.CheckIsNotNull(this, "TxtDocName", "医生名称") && Common.CheckIsNotNull(this, "TxtDocNo", "医生编号") && Common.CheckIsNotNull(this, "TxtDocPinYin", "医生拼音查询码")&& Common.CheckLpIsNotNull(this,"LpDes","医生职称")&&Common.CheckLpIsNotNull(this,"LpDept","科室"))
            {
                SetDoctorArgs();
                Models.DoctorManageModel model = new Models.DoctorManageModel();
                int i = model.CheckDocIsRepeat(doctorArgs.DoctorNo, doctorArgs.DoctorId);
                if (i == 0)
                {
                    if (CJia.Health.Tools.Message.ShowQuery("是否修改此医生信息", CJia.Health.Tools.Message.Button.YesNo) == CJia.Health.Tools.Message.Result.Yes)
                    {
                        OnUpdateDoctor(null, doctorArgs);
                        LoadData();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("此医生编号已存在");
                    TxtDocNo.Focus();
                }
            }
            else
            {
                return;
            }
            
        }

        /// <summary>
        /// 删除医生信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnProjectDelect_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr != null)
            {
                doctorArgs.DoctorId = dr["DOCTOR_ID"].ToString();
                doctorArgs.DoctorNo = dr["DOCTOR_NO"].ToString();
                doctorArgs.UserId = User.UserData.Rows[0]["USER_ID"].ToString();
                if (CJia.Health.Tools.Message.ShowQuery("是否删除此医生", CJia.Health.Tools.Message.Button.YesNo) == CJia.Health.Tools.Message.Result.Yes)
                {
                    OnDeleteDoctor(null, doctorArgs);
                    LoadData();
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 为参数类赋值
        /// </summary>
        private void SetDoctorArgs()
        {
            doctorArgs.DoctorName = TxtDocName.Text;
            doctorArgs.DoctorNo = TxtDocNo.Text;
            doctorArgs.DoctorPinyin = CJia.Controls.CJiaSpellEditor.ToChString(TxtDocName.Text).ToUpper();
            TxtDocPinYin.Text = doctorArgs.DoctorPinyin;
            doctorArgs.DescriptId = LpDes.DisplayValue;
            doctorArgs.DeptId = LpDept.DisplayValue;
            doctorArgs.UserId = User.UserData.Rows[0]["USER_ID"].ToString();
        }

        /// <summary>
        /// 初始化载入数据
        /// </summary>
        private void LoadData()
        {
            doctorArgs.KeyWord = "";
            OnQueryDoctor(null, doctorArgs);
        }

        #region【实现接口】
        public event EventHandler<Views.DoctorArgs> OnQueryDoctor;

        public event EventHandler<Views.DoctorArgs> OnInsertDoctor;

        public event EventHandler<Views.DoctorArgs> OnUpdateDoctor;

        public event EventHandler<Views.DoctorArgs> OnDeleteDoctor;

        public event EventHandler<Views.DoctorArgs> OnQueryDocDescript;

        public event EventHandler<Views.DoctorArgs> OnQueryDept;

        public event EventHandler<Views.DoctorArgs> OnCheckDoctorNo;

        public event EventHandler<Views.DoctorArgs> OnInsertUserDoc;

        public void ExeBindDoctor(DataTable dtDoctor)
        {
            DoctorGrid.DataSource = dtDoctor;
        }

        public void ExeBindDocDescript(DataTable dtDocDescript)
        {
            LpDes.DataSource = dtDocDescript;
            LpDes.Caption = "职称";
            LpDes.DisplayField = "NAME";
            LpDes.ValueField = "CODE";
        }

        public void ExeBindDocDept(DataTable dtDocDept)
        {
            LpDept.DataSource = dtDocDept;
            LpDept.Caption = "科室";
            LpDept.DisplayField = "DEPT_NAME";
            LpDept.ValueField = "DEPT_ID";
        }
        public void exeBindIsDocNoHave(bool IsDocNoHave)
        {
            isDocNoHave = IsDocNoHave;
        }

        #endregion


        #region【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    BtnAddDocject.Focus();
                    this.BtnAddProject_Click(null, null);
                    return true;
                case Keys.F2:
                    BtnUpdateDocject.Focus();
                    this.BtnUpdateProject_Click(null, null);
                    return true;
                case Keys.F3:
                    BtnDocDelect.Focus();
                    BtnProjectDelect_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}

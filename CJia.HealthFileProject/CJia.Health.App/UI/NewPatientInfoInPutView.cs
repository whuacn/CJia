using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Castle.DynamicProxy;

namespace CJia.Health.App.UI
{
    public partial class NewPatientInfoInPutView : CJia.Health.Tools.View, CJia.Health.Views.INewPatientInfoInputView
    {
        public NewPatientInfoInPutView()
        {
            InitializeComponent();
            ltxtRecordNo.Controls[0].ForeColor = Color.Red;
            ltxtPatientName.Controls[0].ForeColor = Color.Red;
            //System.Net.ServicePointManager.DefaultConnectionLimit = 3000000;//后加

        }

        protected override object CreatePresenter()
        {
            //return new Presenters.NewPatientInfoInputPresenter(this);
            ProxyGenerator generator = new ProxyGenerator();//实例化【代理类生成器】
            SimpleInterceptor interceptor = new SimpleInterceptor();//实例化【拦截器】  
            return (Presenters.NewPatientInfoInputPresenter)generator.CreateClassProxy(typeof(Presenters.NewPatientInfoInputPresenter), new object[] { this }, interceptor);
        }


        Views.NewPatientInfoInputEventArgs patientInfoEventArgs = new Views.NewPatientInfoInputEventArgs();

        #region 【绑定界面下拉列表】

        /// <summary>
        /// 当查询下拉相应表数据为空时，添加一空行值
        /// </summary>
        /// <param name="dtData"></param>
        private void AddRowWhenNull(DataTable dtData)
        {
            DataRow dr = dtData.NewRow();
            object[] newRowContent = { 0, "" };
            dr.ItemArray = newRowContent;
            dtData.Rows.Add(dr);
        }

        /// <summary>
        /// 绑定CJiaRTLookUp控件
        /// </summary>
        /// <param name="rtlLookUp">控件名</param>
        /// <param name="dtData">所传DataTable</param>
        /// <param name="displayField">所要显示字段</param>
        /// <param name="valueField">值字段</param>
        /// <param name="inCode">输入码</param>
        void BindRTLookUp(Controls.CJiaRTLookUpMoreCol rtlLookUp, DataTable dtData, string displayField, string valueField, string inCode)
        {
            //DataRow dr = dtData.NewRow();
            rtlLookUp.DataSource = dtData;
            rtlLookUp.DisplayField = displayField;
            rtlLookUp.ValueField = valueField;
            rtlLookUp.Fields = new string[,] { { displayField, "名称" }, { inCode, "输入码" } };

        }

        /// <summary>
        /// 绑定CJiaComboBox2控件
        /// </summary>
        /// <param name="combox2">控件名</param>
        /// <param name="dtData">所传DataTable</param>
        /// <param name="displayMember">所要显示字段</param>
        /// <param name="valueMember">值字段</param>
        void BindComboBox2(Controls.CJiaComboBox2 combox2, DataTable dtData, string displayMember, string valueMember)
        {
            combox2.Properties.DataSource = dtData;
            combox2.Properties.DisplayMember = displayMember;
            combox2.Properties.ValueMember = valueMember;
            combox2.Text = "";
        }

        /// <summary>
        /// 绑定性别
        /// </summary>
        /// <param name="dtGender"></param>
        public void ExeBindGender(DataTable dtGender)
        {
            BindComboBox2(this.cboGender, dtGender, "NAME", "CODE");
        }

        /// <summary>
        /// 绑定所在省(直辖市)
        /// </summary>
        /// <param name="dtProvince"></param>
        public void ExeBindProvince(DataTable dtProvince)
        {
            BindRTLookUp(this.rtlkProvince, dtProvince, "AREA_NAME", "AREA_ID", "PINYIN");
        }

        /// <summary>
        /// 绑定市
        /// </summary>
        /// <param name="dtCity"></param>
        public void ExeBindCity(DataTable dtCity)
        {
            BindRTLookUp(this.rtlkCity, dtCity, "AREA_NAME", "AREA_ID", "PINYIN");
        }

        /// <summary>
        /// 绑定科室
        /// </summary>
        /// <param name="dtDept"></param>
        public void ExeBindDept(DataTable dtDept)
        {
            // 入院科室
            BindRTLookUp(this.rtlkInHospitalDept, dtDept, "DEPT_NAME", "DEPT_ID", "DEPT_NO");

            // 出院科室
            BindRTLookUp(this.rtlkOutHospitalDept, dtDept, "DEPT_NAME", "DEPT_ID", "DEPT_NO");
        }

        /// <summary>
        /// 入院部门
        /// </summary>
        /// <param name="dtIndeptSearch"></param>
        public void ExeInDept(DataTable dtIndeptSearch)
        {
            BindRTLookUp(rtlkInHospitalDept, dtIndeptSearch, "DEPT_NAME", "DEPT_ID", "DEPT_NO");
        }

        /// <summary>
        /// 出院部门
        /// </summary>
        /// <param name="dtOutDeptSearch"></param>
        public void ExeOutDept(DataTable dtOutDeptSearch)
        {
            BindRTLookUp(rtlkOutHospitalDept, dtOutDeptSearch, "DEPT_NAME", "DEPT_ID", "DEPT_NO");
        }

        /// <summary>
        /// ICD编码（出院诊断1）
        /// </summary>
        /// <param name="dtICDOutDia1"></param>
        public void ExeICDOutDia1(DataTable dtICDOutDia1)
        {
            BindRTLookUp(rtlkICDOutDia1, dtICDOutDia1, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
        }

        /// <summary>
        /// ICD编码（出院诊断2）
        /// </summary>
        /// <param name="dtICDOutDia2"></param>
        public void ExeICDOutDia2(DataTable dtICDOutDia2)
        {
            BindRTLookUp(rtlkICDOutDia2, dtICDOutDia2, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
        }

        /// <summary>
        /// ICD编码（出院诊断3）
        /// </summary>
        /// <param name="dtICDOutDia3"></param>
        public void ExeICDOutDia3(DataTable dtICDOutDia3)
        {
            BindRTLookUp(rtlkICDOutDia3, dtICDOutDia3, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
        }

        /// <summary>
        /// ICD编码（出院诊断4）
        /// </summary>
        /// <param name="dtICDOutDia4"></param>
        public void ExeICDOutDia4(DataTable dtICDOutDia4)
        {
            BindRTLookUp(rtlkICDOutDia4, dtICDOutDia4, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
        }

        /// <summary>
        /// ICD编码（手术名称1）
        /// </summary>
        /// <param name="dtICDSurgery1"></param>
        public void ExeICDSurgery1(DataTable dtICDSurgery1)
        {
            BindRTLookUp(rtlkICDSurgery1, dtICDSurgery1, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
        }

        /// <summary>
        /// ICD编码（手术名称2）
        /// </summary>
        /// <param name="dtICDSurgery2"></param>
        public void ExeICDSurgery2(DataTable dtICDSurgery2)
        {
            BindRTLookUp(rtlkICDSurgery2, dtICDSurgery2, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
        }

        /// <summary>
        /// ICD编码（手术名称3）
        /// </summary>
        /// <param name="dtICDSurgery3"></param>
        public void ExeICDSurgery3(DataTable dtICDSurgery3)
        {
            BindRTLookUp(rtlkICDSurgery3, dtICDSurgery3, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
        }

        /// <summary>
        /// ICD编码（手术名称4）
        /// </summary>
        /// <param name="dtICDSurgery4"></param>
        public void ExeICDSurgery4(DataTable dtICDSurgery4)
        {
            BindRTLookUp(rtlkICDSurgery4, dtICDSurgery4, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
        }

        /// <summary>
        /// 初始化绑定ICD编码
        /// </summary>
        /// <param name="dtICDCode"></param>
        public void ExeBindICDCode(DataTable dtICDCode)
        {
            // 出院诊断ICD编码1
            BindRTLookUp(this.rtlkICDOutDia1, dtICDCode, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
            // 出院诊断ICD编码2
            BindRTLookUp(this.rtlkICDOutDia2, dtICDCode, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
            // 出院诊断ICD编码3
            BindRTLookUp(this.rtlkICDOutDia3, dtICDCode, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
            // 出院诊断ICD编码4
            BindRTLookUp(this.rtlkICDOutDia4, dtICDCode, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");

            // 手术名称ICD编码1
            BindRTLookUp(this.rtlkICDSurgery1, dtICDCode, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
            // 手术名称ICD编码2
            BindRTLookUp(this.rtlkICDSurgery2, dtICDCode, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
            // 手术名称ICD编码3
            BindRTLookUp(this.rtlkICDSurgery3, dtICDCode, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
            // 手术名称ICD编码4
            BindRTLookUp(this.rtlkICDSurgery4, dtICDCode, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
        }

        /// <summary>
        /// 绑定治疗结果
        /// </summary>
        /// <param name="dtTreatResult"></param>
        public void ExeBindTreatResult(DataTable dtTreatResult)
        {
            BindComboBox2(this.cboTreatResult1, dtTreatResult, "NAME", "CODE");
            BindComboBox2(this.cboTreatResult2, dtTreatResult, "NAME", "CODE");
            BindComboBox2(this.cboTreatResult3, dtTreatResult, "NAME", "CODE");
            BindComboBox2(this.cboTreatResult4, dtTreatResult, "NAME", "CODE");
        }
        #endregion

        #region 【界面事件】
        private void NewPatientInfoInPutView_SizeChanged(object sender, EventArgs e)
        {
            int formHeight = this.Height;
            int formWidth = this.Width;
            int pnlHeight;
            pnlHeight = formHeight;
            int location = (formWidth - pnlPatient.Width) / 2;
            pnlPatient.Location = new Point(location, 5);
            this.VerticalScroll.Value = VerticalScroll.Minimum;
        }

        private void NewPatientInfoInPutView_Load(object sender, EventArgs e)
        {
            OnInit(null, null);
            ltxtRecordNo.Controls[0].Leave += ltxtRecordNo_Leave;
            ltxtRecordNo.Controls[0].KeyDown += ltxtRecordNo_KeyDown;
            ltxtIdCard.Controls[0].Leave += ltxtIdCard_Leave;
            ltxtIdCard.Controls[0].KeyDown += ltxtIdCard_KeyDown;
            ltxtPatientName.Controls[0].KeyDown += ltxtPatientName_KeyDown;
            ltxtPatientAge.Controls[0].KeyDown += ltxtPatientAge_KeyDown;
            ltxtPatientAddress.Controls[0].KeyDown += ltxtPatientAddress_KeyDown;
            ltxtInHospitalTime.Leave += ltxtInHospitalTime_Leave;
            FuzzySearch();
            this.ltxtRecordNo.Focus();
        }

        private void ltxtPatientAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboInHospitalDate.Focus();
            }
        }

        private void ltxtPatientAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ltxtIdCard.Focus();
            }
        }

        private void ltxtPatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboGender.Focus();
            }
        }

        private void ltxtRecordNo_Leave(object sender, EventArgs e)
        {
            //if (CheckExistSameRecordNoAndInHospitalTime())
            //{
            //    ltxtRecordNo.Focus();
            //}
            //else
            //{
            //    ltxtPatientName.Focus();
            //}
            //if (ltxtInHospitalTime.Text == "")
            //{
            //    ltxtInHospitalTime.Focus();
            //}
            //CheckExistSameRecordNoAndInHospitalTime();
            ltxtInHospitalTime.Focus();
        }

        private void ltxtRecordNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //{
                //    ltxtRecordNo.Controls[0].Leave -= ltxtRecordNo_Leave;
                //    if (CheckExistSameRecordNoAndInHospitalTime())
                //    {
                //        ltxtRecordNo.Focus();
                //    }
                //    else
                //    {
                //        ltxtPatientName.Focus();
                //    }
                //    ltxtRecordNo.Controls[0].Leave += ltxtRecordNo_Leave;
                //}
                //CheckExistSameRecordNoAndInHospitalTime();
                ltxtInHospitalTime.Focus();
            }
        }

        // 离开住院次数
        private void ltxtInHospitalTime_Leave(object sender, EventArgs e)
        {
            //if (CheckExistSameRecordNoAndInHospitalTime())
            //{
            //    ltxtInHospitalTime.Focus();
            //}
            //else
            //{
            //    ltxtPatientName.Focus();
            //}
            //CheckExistSameRecordNoAndInHospitalTime();
        }

        /// <summary>
        /// 按下住院次数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ltxtInHospitalTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ltxtRecordNo.MyText != "" && ltxtInHospitalTime.Text != "")
                {
                    patientInfoEventArgs.RecordNo = ltxtRecordNo.MyText;
                    patientInfoEventArgs.InHospitalTime = int.Parse(ltxtInHospitalTime.Text);
                    OnCheckIsExistSameRecordNoAndInHospitalTime(null, patientInfoEventArgs);
                    if (patientInfoEventArgs.TablePatientInfoByRecordNo != null)
                    {
                        if (patientInfoEventArgs.TablePatientInfoByRecordNo.Rows.Count > 0)
                        {
                            ltxtInHospitalTime.Leave -= ltxtInHospitalTime_Leave;
                            MessageBox.Show("【" + patientInfoEventArgs.TablePatientInfoByRecordNo.Rows[0]["PATIENT_NAME"].ToString() + "】存在相同【病案号+入院次数】！");
                            ltxtRecordNo.MyText = "";
                            ltxtInHospitalTime.Text = "";
                            patientInfoEventArgs.TablePatientInfoByRecordNo = null;
                            ltxtRecordNo.Focus();
                            ltxtInHospitalTime.Leave += ltxtInHospitalTime_Leave;
                            return;
                        }
                    }
                    IsSameRecordNoAndTime(ltxtRecordNo.MyText.ToUpper(), ltxtInHospitalTime.Text);
                }
                ltxtPatientName.Focus();
            }
        }

        /// <summary>
        /// 焦点离开时校验在数据库中是否存在此病案号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //void CheckExistSameRecordNoAndInHospitalTime()
        //{
        //    if (ltxtRecordNo.MyText != "" && ltxtInHospitalTime.Text != "")
        //    {
        //        patientInfoEventArgs.RecordNo = ltxtRecordNo.MyText;
        //        patientInfoEventArgs.InHospitalTime = int.Parse(ltxtInHospitalTime.Text);
        //        OnCheckIsExistSameRecordNoAndInHospitalTime(null, patientInfoEventArgs);

        //        // 查询在库中是否存在相同病案号和入院次数
        //        if (patientInfoEventArgs.TablePatientInfoByRecordNo != null)
        //        {
        //            if (patientInfoEventArgs.TablePatientInfoByRecordNo.Rows.Count > 0)
        //            {
        //                MessageBox.Show("【" + patientInfoEventArgs.TablePatientInfoByRecordNo.Rows[0]["PATIENT_NAME"].ToString() + "】存在相同【病案号+入院次数】！");
        //                ltxtRecordNo.MyText = "";
        //                ltxtInHospitalTime.Text = "";
        //                patientInfoEventArgs.TablePatientInfoByRecordNo = null;
        //                ltxtRecordNo.Focus();
        //                return;
        //            }
        //        }
        //        IsSameRecordNoAndTime(ltxtRecordNo.MyText.ToUpper(), ltxtInHospitalTime.Text);
        //    }
        //    patientInfoEventArgs.TablePatientInfoByRecordNo = null;
        //    patientInfoEventArgs.TablePatientFromInterface = null;
        //}

        /// <summary>
        /// 把控件置为不可编辑
        /// </summary>
        void SetReadValue(bool value)
        {
            this.ltxtRecordNo.ReadOnly = value;
            this.ltxtInHospitalTime.Properties.ReadOnly = value;

            this.ltxtPatientName.ReadOnly = value;
            this.cboGender.Properties.ReadOnly = value;
            this.cboBirthday.Properties.ReadOnly = value;

            this.rtlkProvince.Properties.ReadOnly = value;
            this.rtlkCity.Properties.ReadOnly = value;

            this.ltxtIdCard.ReadOnly = value;
            ltxtPatientAge.ReadOnly = value;
            ltxtPatientAddress.ReadOnly = value;

            this.cboInHospitalDate.Properties.ReadOnly = value;
            this.cboOutHospitalDate.Properties.ReadOnly = value;

            this.rtlkInHospitalDept.Properties.ReadOnly = value;

            this.rtlkOutHospitalDept.Properties.ReadOnly = value;

            this.rtlkICDOutDia1.Properties.ReadOnly = value;
            this.ltxtOutDiaName1.ReadOnly = value;

            this.rtlkICDOutDia2.Properties.ReadOnly = value;
            this.ltxtOutDiaName2.ReadOnly = value;

            this.rtlkICDOutDia3.Properties.ReadOnly = value;
            this.ltxtOutDiaName3.ReadOnly = value;

            this.rtlkICDOutDia4.Properties.ReadOnly = value;
            this.ltxtOutDiaName4.ReadOnly = value;

            this.rtlkICDSurgery1.Properties.ReadOnly = value;
            this.ltxtSurgeryName1.ReadOnly = value;

            this.rtlkICDSurgery2.Properties.ReadOnly = value;
            this.ltxtSurgeryName2.ReadOnly = value;

            this.rtlkICDSurgery3.Properties.ReadOnly = value;
            this.ltxtSurgeryName3.ReadOnly = value;

            this.rtlkICDSurgery4.Properties.ReadOnly = value;
            this.ltxtSurgeryName4.ReadOnly = value;

            this.cboTreatResult1.Properties.ReadOnly = value;
            this.cboTreatResult2.Properties.ReadOnly = value;
            this.cboTreatResult3.Properties.ReadOnly = value;
            this.cboTreatResult4.Properties.ReadOnly = value;

            //cboSurgeryDate1.Properties.ReadOnly = value;
            //cboSurgeryDate2.Properties.ReadOnly = value;
            //cboSurgeryDate3.Properties.ReadOnly = value;
            //cboSurgeryDate4.Properties.ReadOnly = value;
        }
        //CJ.HealthServiceSoapClient ws = new CJ.HealthServiceSoapClient();
        JJCJ.HealthServiceSoapClient jjcj = new JJCJ.HealthServiceSoapClient();
        //CJ.HealthServiceSoapClient web = new CJ.HealthServiceSoapClient();
        /// <summary>
        /// 接口中查询是否有相同病案号和入院次数
        /// </summary>
        void IsSameRecordNoAndTime(string recordno, string inhosTimes)
        {
            //CjiaWebServer.HealthServiceSoapClient web = new CjiaWebServer.HealthServiceSoapClient();
            //DataTable data = web.QueryPatientBy(recordno, inhosTimes).Tables[0];
            //JJBJYWebServer.HealthServiceSoapClient web = new JJBJYWebServer.HealthServiceSoapClient();
            //DataTable data = web.QueryPatientBy(recordno, inhosTimes).Tables[0];
            DataTable data = null;
            try
            {
                //web1.Open();
                //string str = ws.HelloWorld();
                data = jjcj.QueryPatientBy(recordno, inhosTimes);
                //web1.Close();
            }
            catch
            {
                MessageBox.Show("链接超时或者服务器已关闭,请您多尝试几遍！");
            }
            // 查询接口中是否存在相同病案号和入院次数信息
            //DataTable data = null;
            if (data != null)
            {
                if (data.Rows.Count > 0)
                {
                    DataRow dr = data.Rows[0];
                    this.ltxtRecordNo.MyText = dr["RECORD_NO"].ToString();
                    this.ltxtInHospitalTime.Text = dr["IN_HOSPITAL_TIME"].ToString();

                    this.ltxtPatientName.MyText = dr["PATIENT_NAME"].ToString();
                    this.cboGender.Text = dr["GENDER_NAME"].ToString();
                    this.cboGender.EditValue = dr["GENDER"].ToString();
                    this.cboBirthday.Text = DateTime.Parse(dr["BIRTHDAY"].ToString()).ToString("yyyy-MM-dd");

                    this.ltxtBirthPlace.MyText = dr["PROVINCE"].ToString();
                    //this.rtlkProvince.Text = dr["PROVINCE_NAME"].ToString();
                    //this.rtlkProvince.DisplayText = dr["PROVINCE_NAME"].ToString();
                    //this.rtlkProvince.DisplayValue = dr["PROVINCE"].ToString();

                    //this.rtlkCity.Text = dr["CITY_NAME"].ToString();
                    //this.rtlkCity.DisplayText = dr["CITY_NAME"].ToString();
                    //this.rtlkCity.DisplayValue = dr["CITY"].ToString();

                    this.ltxtIdCard.MyText = dr["ID_CARD"].ToString();
                    ltxtPatientAge.MyText = dr["PATIENT_AGE"].ToString();
                    ltxtPatientAddress.MyText = dr["PATIENT_ADDRESS"].ToString();

                    this.cboInHospitalDate.Text = DateTime.Parse(dr["IN_HOSPITAL_DATE"].ToString()).ToString("yyyy-MM-dd");
                    this.cboOutHospitalDate.Text = DateTime.Parse(dr["OUT_HOSPITAL_DATE"].ToString()).ToString("yyyy-MM-dd");

                    this.rtlkInHospitalDept.Text = dr["IN_HOSPITAL_DEPT_NAME"].ToString();
                    this.rtlkInHospitalDept.DisplayText = dr["IN_HOSPITAL_DEPT_NAME"].ToString();
                    this.rtlkInHospitalDept.DisplayValue = dr["IN_HOSPITAL_DEPT"].ToString();

                    this.rtlkOutHospitalDept.Text = dr["OUT_HOSPITAL_DEPT_NAME"].ToString();
                    this.rtlkOutHospitalDept.DisplayText = dr["OUT_HOSPITAL_DEPT_NAME"].ToString();
                    this.rtlkOutHospitalDept.DisplayValue = dr["OUT_HOSPITAL_DEPT"].ToString();

                    this.rtlkICDOutDia1.Text = dr["ICD_OUTDIA1"].ToString();
                    this.rtlkICDOutDia1.DisplayText = dr["ICD_OUTDIA1"].ToString();
                    this.rtlkICDOutDia1.DisplayValue = dr["ICD_OUTDIA1"].ToString();
                    this.ltxtOutDiaName1.MyText = dr["OUTDIA_NAME1"].ToString();

                    this.rtlkICDOutDia2.Text = dr["ICD_OUTDIA2"].ToString();
                    this.rtlkICDOutDia2.DisplayText = dr["ICD_OUTDIA2"].ToString();
                    this.rtlkICDOutDia2.DisplayValue = dr["ICD_OUTDIA2"].ToString();
                    this.ltxtOutDiaName2.MyText = dr["OUTDIA_NAME2"].ToString();

                    this.rtlkICDOutDia3.Text = dr["ICD_OUTDIA3"].ToString();
                    this.rtlkICDOutDia3.DisplayText = dr["ICD_OUTDIA3"].ToString();
                    this.rtlkICDOutDia3.DisplayValue = dr["ICD_OUTDIA3"].ToString();
                    this.ltxtOutDiaName3.MyText = dr["OUTDIA_NAME3"].ToString();

                    this.rtlkICDOutDia4.Text = dr["ICD_OUTDIA4"].ToString();
                    this.rtlkICDOutDia4.DisplayText = dr["ICD_OUTDIA4"].ToString();
                    this.rtlkICDOutDia4.DisplayValue = dr["ICD_OUTDIA4"].ToString();
                    this.ltxtOutDiaName4.MyText = dr["OUTDIA_NAME4"].ToString();

                    this.rtlkICDSurgery1.Text = dr["ICD_SURGERY1"].ToString();
                    this.rtlkICDSurgery1.DisplayText = dr["ICD_SURGERY1"].ToString();
                    this.rtlkICDSurgery1.DisplayValue = dr["ICD_SURGERY1"].ToString();
                    this.ltxtSurgeryName1.MyText = dr["SURGERY_NAME1"].ToString();

                    this.rtlkICDSurgery2.Text = dr["ICD_SURGERY2"].ToString();
                    this.rtlkICDSurgery2.DisplayText = dr["ICD_SURGERY2"].ToString();
                    this.rtlkICDSurgery2.DisplayValue = dr["ICD_SURGERY2"].ToString();
                    this.ltxtSurgeryName2.MyText = dr["SURGERY_NAME2"].ToString();

                    this.rtlkICDSurgery3.Text = dr["ICD_SURGERY3"].ToString();
                    this.rtlkICDSurgery3.DisplayText = dr["ICD_SURGERY3"].ToString();
                    this.rtlkICDSurgery3.DisplayValue = dr["ICD_SURGERY3"].ToString();
                    this.ltxtSurgeryName3.MyText = dr["SURGERY_NAME3"].ToString();

                    this.rtlkICDSurgery4.Text = dr["ICD_SURGERY4"].ToString();
                    this.rtlkICDSurgery4.DisplayText = dr["ICD_SURGERY4"].ToString();
                    this.rtlkICDSurgery4.DisplayValue = dr["ICD_SURGERY4"].ToString();
                    this.ltxtSurgeryName4.MyText = dr["SURGERY_NAME4"].ToString();

                    this.cboTreatResult1.Text = dr["TREAT_RESULT1_NAME"].ToString();
                    this.cboTreatResult1.EditValue = dr["TREAT_RESULT1"].ToString();
                    this.cboTreatResult2.Text = dr["TREAT_RESULT2_NAME"].ToString();
                    this.cboTreatResult2.EditValue = dr["TREAT_RESULT2"].ToString();
                    this.cboTreatResult3.Text = dr["TREAT_RESULT3_NAME"].ToString();
                    this.cboTreatResult3.EditValue = dr["TREAT_RESULT3"].ToString();
                    this.cboTreatResult4.Text = dr["TREAT_RESULT4_NAME"].ToString();
                    this.cboTreatResult4.EditValue = dr["TREAT_RESULT4"].ToString();

                    cboSurgeryDate1.EditValue = dr["SURGERY_DATE1"];
                    cboSurgeryDate2.EditValue = dr["SURGERY_DATE2"];
                    cboSurgeryDate3.EditValue = dr["SURGERY_DATE3"];
                    cboSurgeryDate4.EditValue = dr["SURGERY_DATE4"];
                    SetReadValue(true);
                }
            }
        }


        /// <summary>
        /// 身份证位数校验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ltxtIdCard_Leave(object sender, EventArgs e)
        {
            if (!CheckCidInfo(ltxtIdCard.MyText))
            {
                if (Message.ShowQuery("身份证号有误,确定要继续输入?") == Message.Result.Ok)
                {
                    rtlkProvince.Focus();
                }
                else
                {
                    ltxtIdCard.Focus();
                }
            }
        }

        /// <summary>
        /// 按下Enter校验身份证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ltxtIdCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!CheckCidInfo(ltxtIdCard.MyText))
                {
                    ltxtIdCard.Controls[0].Leave -= ltxtIdCard_Leave;
                    if (Message.ShowQuery("身份证号有误,确定要继续输入?") == Message.Result.Ok)
                    {
                        rtlkProvince.Focus();
                    }
                    else
                    {
                        ltxtIdCard.Focus();
                    }
                }
                ltxtIdCard.Controls[0].Leave += ltxtIdCard_Leave;
            }
        }

        // 改变省输入框值时触发
        private void rtlkProvince_TextChanged(object sender, EventArgs e)
        {
            if (this.rtlkProvince.Text == "")
            {
                // 让搜索条件为空字符，置空市数据源数据源
                this.rtlkProvince.DisplayValue = "";
                this.rtlkProvince.DisplayText = "";
            }
            patientInfoEventArgs.SelectedProvinceId = this.rtlkProvince.DisplayValue;
            OnProvinceTextChanged(sender, patientInfoEventArgs);
            this.rtlkCity.Text = "";
            this.rtlkCity.DisplayValue = "";

            // 出生地=所选省+市
            if (rtlkProvince.Text != rtlkCity.Text)
            {
                this.ltxtBirthPlace.MyText = rtlkProvince.DisplayText + rtlkCity.DisplayText;
            }
            else
            {
                this.ltxtBirthPlace.MyText = rtlkProvince.Text;
            }
        }

        // 改变市输入框值时触发
        private void rtlkCity_TextChanged(object sender, EventArgs e)
        {
            // 如查询值为空值 则市绑定值为全部
            if (this.rtlkCity.Text == "")
            {
                OnProvinceTextChanged(sender, patientInfoEventArgs);
                this.rtlkCity.DisplayText = "";
            }
            // 出生地=所选省+市
            if (rtlkProvince.Text != rtlkCity.Text)
            {
                this.ltxtBirthPlace.MyText = rtlkProvince.DisplayText + rtlkCity.DisplayText;
            }
            else
            {
                this.ltxtBirthPlace.MyText = rtlkProvince.Text;
            }
        }

        // 选择ICD编码带出院诊断1
        private void rtlkICDOutDia1_TextChanged(object sender, EventArgs e)
        {
            this.ltxtOutDiaName1.MyText = this.rtlkICDOutDia1.DisplayValue;
            if (rtlkICDOutDia1.Text == "")
            {
                rtlkICDOutDia1.DisplayValue = "";
                rtlkICDOutDia1.DisplayText = "";
                this.ltxtOutDiaName1.MyText = "";
            }
        }

        // 选择ICD编码带出院诊断2
        private void rtlkICDOutDia2_TextChanged(object sender, EventArgs e)
        {
            this.ltxtOutDiaName2.MyText = this.rtlkICDOutDia2.DisplayValue;
            if (rtlkICDOutDia2.Text == "")
            {
                rtlkICDOutDia2.DisplayValue = "";
                rtlkICDOutDia2.DisplayText = "";
                this.ltxtOutDiaName2.MyText = "";
            }
        }

        // 选择ICD编码带出院诊断3
        private void rtlkICDOutDia3_TextChanged(object sender, EventArgs e)
        {
            this.ltxtOutDiaName3.MyText = this.rtlkICDOutDia3.DisplayValue;
            if (rtlkICDOutDia3.Text == "")
            {
                rtlkICDOutDia3.DisplayValue = "";
                rtlkICDOutDia3.DisplayText = "";
                this.ltxtOutDiaName3.MyText = "";
            }
        }

        // 选择ICD编码带出院诊断4
        private void rtlkICDOutDia4_TextChanged(object sender, EventArgs e)
        {
            this.ltxtOutDiaName4.MyText = this.rtlkICDOutDia4.DisplayValue;
            if (rtlkICDOutDia4.Text == "")
            {
                rtlkICDOutDia4.DisplayValue = "";
                rtlkICDOutDia4.DisplayText = "";
                this.ltxtOutDiaName4.MyText = "";
            }
        }

        // 选择ICD编码带出手术名称1
        private void rtlkICDSurgery1_TextChanged(object sender, EventArgs e)
        {
            this.ltxtSurgeryName1.MyText = this.rtlkICDSurgery1.DisplayValue;
            if (rtlkICDSurgery1.Text == "")
            {
                rtlkICDSurgery1.DisplayValue = "";
                rtlkICDSurgery1.DisplayText = "";
                this.ltxtSurgeryName1.MyText = "";
                cboSurgeryDate1.EditValue = null;
                cboSurgeryDate1.Properties.ReadOnly = true;
            }
            if (rtlkICDSurgery1.DisplayText != "")
            {
                cboSurgeryDate1.Properties.ReadOnly = false;
            }
        }

        // 选择ICD编码带出手术名称2
        private void rtlkICDSurgery2_TextChanged(object sender, EventArgs e)
        {
            this.ltxtSurgeryName2.MyText = this.rtlkICDSurgery2.DisplayValue;
            if (rtlkICDSurgery2.Text == "")
            {
                rtlkICDSurgery2.DisplayValue = "";
                rtlkICDSurgery2.DisplayText = "";
                this.ltxtSurgeryName2.MyText = "";
                cboSurgeryDate2.EditValue = null;
                cboSurgeryDate2.Properties.ReadOnly = true;
            }
            if (rtlkICDSurgery2.DisplayText != "")
            {
                cboSurgeryDate2.Properties.ReadOnly = false;
            }
        }

        // 选择ICD编码带出手术名称3
        private void rtlkICDSurgery3_TextChanged(object sender, EventArgs e)
        {
            this.ltxtSurgeryName3.MyText = this.rtlkICDSurgery3.DisplayValue;
            if (rtlkICDSurgery3.Text == "")
            {
                rtlkICDSurgery3.DisplayValue = "";
                rtlkICDSurgery3.DisplayText = "";
                this.ltxtSurgeryName3.MyText = "";
                cboSurgeryDate3.EditValue = null;
                cboSurgeryDate3.Properties.ReadOnly = true;
            }
            if (rtlkICDSurgery3.DisplayText != "")
            {
                cboSurgeryDate3.Properties.ReadOnly = false;
            }
        }

        // 选择ICD编码带出手术名称4
        private void rtlkICDSurgery4_TextChanged(object sender, EventArgs e)
        {
            this.ltxtSurgeryName4.MyText = this.rtlkICDSurgery4.DisplayValue;
            if (rtlkICDSurgery4.Text == "")
            {
                rtlkICDSurgery4.DisplayValue = "";
                rtlkICDSurgery4.DisplayText = "";
                this.ltxtSurgeryName4.MyText = "";
                cboSurgeryDate4.EditValue = null;
                cboSurgeryDate4.Properties.ReadOnly = true;
            }
            if (rtlkICDSurgery4.DisplayText != "")
            {
                cboSurgeryDate4.Properties.ReadOnly = false;
            }
        }

        // 保存事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (NullReturn())
            {
                return;
            }
            patientInfoEventArgs.RecordNo = this.ltxtRecordNo.MyText.ToUpper();
            patientInfoEventArgs.PatientName = this.ltxtPatientName.MyText;
            patientInfoEventArgs.Gender = this.cboGender.EditValue.ToString();
            patientInfoEventArgs.BirthDate = this.cboBirthday.DateTime;
            patientInfoEventArgs.Province = this.rtlkProvince.DisplayValue;
            patientInfoEventArgs.City = this.rtlkCity.DisplayValue;
            patientInfoEventArgs.IDCard = this.ltxtIdCard.MyText;
            patientInfoEventArgs.InHospitalTime = int.Parse(this.ltxtInHospitalTime.Text);
            patientInfoEventArgs.InHospitalDate = this.cboInHospitalDate.DateTime;
            patientInfoEventArgs.OutHospitalDate = this.cboOutHospitalDate.DateTime;
            patientInfoEventArgs.InHospitalDept = this.rtlkInHospitalDept.DisplayValue;
            patientInfoEventArgs.OutHospitalDept = this.rtlkOutHospitalDept.DisplayValue;
            patientInfoEventArgs.ICDOutDia1 = this.rtlkICDOutDia1.DisplayText;
            patientInfoEventArgs.OutDiaName1 = this.ltxtOutDiaName1.MyText;
            patientInfoEventArgs.ICDOutDia2 = this.rtlkICDOutDia2.DisplayText;
            patientInfoEventArgs.OutDiaName2 = this.ltxtOutDiaName2.MyText;
            patientInfoEventArgs.ICDOutDia3 = this.rtlkICDOutDia3.DisplayText;
            patientInfoEventArgs.OutDiaName3 = this.ltxtOutDiaName3.MyText;
            patientInfoEventArgs.ICDOutDia4 = this.rtlkICDOutDia4.DisplayText;
            patientInfoEventArgs.OutDiaName4 = this.ltxtOutDiaName4.MyText;
            patientInfoEventArgs.ICDSurgery1 = this.rtlkICDSurgery1.DisplayText;
            patientInfoEventArgs.SurgeryName1 = this.ltxtSurgeryName1.MyText;
            patientInfoEventArgs.ICDSurgery2 = this.rtlkICDSurgery2.DisplayText;
            patientInfoEventArgs.SurgeryName2 = this.ltxtSurgeryName2.MyText;
            patientInfoEventArgs.ICDSurgery3 = this.rtlkICDSurgery3.DisplayText;
            patientInfoEventArgs.SurgeryName3 = this.ltxtSurgeryName3.MyText;
            patientInfoEventArgs.ICDSurgery4 = this.rtlkICDSurgery4.DisplayText;
            patientInfoEventArgs.SurgeryName4 = this.ltxtSurgeryName4.MyText;
            patientInfoEventArgs.TreatResult1 = this.cboTreatResult1.EditValue.ToString();
            patientInfoEventArgs.TreatResult2 = this.cboTreatResult2.EditValue.ToString();
            patientInfoEventArgs.TreatResult3 = this.cboTreatResult3.EditValue.ToString();
            patientInfoEventArgs.TreatResult4 = this.cboTreatResult4.EditValue.ToString();
            patientInfoEventArgs.PatientAge = ltxtPatientAge.MyText;
            patientInfoEventArgs.PatientAddress = ltxtPatientAddress.MyText;
            if (cboSurgeryDate1.EditValue != null && cboSurgeryDate1.DateTime != DateTime.MinValue)
            {
                patientInfoEventArgs.SurgeryDate1 = cboSurgeryDate1.DateTime;
            }
            if (cboSurgeryDate2.EditValue != null && cboSurgeryDate2.DateTime != DateTime.MinValue)
            {
                patientInfoEventArgs.SurgeryDate2 = cboSurgeryDate2.DateTime;
            }
            if (cboSurgeryDate3.EditValue != null && cboSurgeryDate3.DateTime != DateTime.MinValue)
            {
                patientInfoEventArgs.SurgeryDate3 = cboSurgeryDate3.DateTime;
            }
            if (cboSurgeryDate4.EditValue != null && cboSurgeryDate4.DateTime != DateTime.MinValue)
            {
                patientInfoEventArgs.SurgeryDate4 = cboSurgeryDate4.DateTime;
            }

            OnSavePatientInfo(sender, patientInfoEventArgs);
            if (!patientInfoEventArgs.IsReturn)
            {
                SetNull();
                patientInfoEventArgs.IsReturn = false;
                ltxtRecordNo.Focus();
            }

        }

        // 重置
        private void btnReset_Click(object sender, EventArgs e)
        {
            SetNull();
        }
        #endregion

        #region【自定义方法】
        /// <summary>
        /// 身份证校验方法
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        private bool CheckCidInfo(string cid)
        {
            string[] aCity = new string[] { null, null, null, null, null, null, null, null, null, null, null, "北京", "天津", "河北", "山西", "内蒙古", null, null, null, null, null, "辽宁", "吉林", "黑龙江", null, null, null, null, null, null, null, "上海", "江苏", "浙江", "安微", "福建", "江西", "山东", null, null, null, "河南", "湖北", "湖南", "广东", "广西", "海南", null, null, null, "重庆", "四川", "贵州", "云南", "西藏", null, null, null, null, null, null, "陕西", "甘肃", "青海", "宁夏", "新疆", null, null, null, null, null, "台湾", null, null, null, null, null, null, null, null, null, "香港", "澳门", null, null, null, null, null, null, null, null, "国外" };
            double iSum = 0;
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$");
            System.Text.RegularExpressions.Match mc = rg.Match(cid);
            if (!mc.Success)
            {
                // "位数错啦"
                return false;
            }
            cid = cid.ToLower();
            cid = cid.Replace("x", "a");
            if (aCity[int.Parse(cid.Substring(0, 2))] == null)
            {
                // "非法地区"
                return false;
            }
            try
            {
                DateTime.Parse(cid.Substring(6, 4) + "-" + cid.Substring(10, 2) + "-" + cid.Substring(12, 2));
            }
            catch
            {
                // "非法生日"
                return false;
            }
            for (int i = 17; i >= 0; i--)
            {
                iSum += (System.Math.Pow(2, i) % 11) * int.Parse(cid[17 - i].ToString(), System.Globalization.NumberStyles.HexNumber);

            }
            if (iSum % 11 != 1)
                // "非法证号"
                return (false);
            return true;

        }

        /// <summary>
        /// 置空
        /// </summary>
        private void SetNull()
        {
            SetReadValue(false);
            this.ltxtRecordNo.MyText = "";
            this.ltxtPatientName.MyText = "";
            this.cboGender.Text = "";
            cboGender.EditValue = "";
            this.cboBirthday.Text = "";

            this.ltxtBirthPlace.MyText = "";
            this.rtlkProvince.Text = "";
            this.rtlkProvince.DisplayText = "";
            rtlkProvince.DisplayValue = "";

            this.rtlkCity.Text = "";
            rtlkCity.DisplayText = "";
            rtlkCity.DisplayValue = "";

            this.ltxtIdCard.MyText = "";
            this.ltxtInHospitalTime.Text = "";

            this.rtlkInHospitalDept.Text = "";
            rtlkInHospitalDept.DisplayText = "";
            rtlkInHospitalDept.DisplayValue = "";

            this.rtlkOutHospitalDept.Text = "";
            rtlkOutHospitalDept.DisplayText = "";
            rtlkOutHospitalDept.DisplayValue = "";

            this.cboInHospitalDate.Text = "";
            this.cboOutHospitalDate.Text = "";
            this.rtlkICDOutDia1.Text = "";
            rtlkICDOutDia1.DisplayText = "";
            rtlkICDOutDia1.DisplayValue = "";
            this.ltxtOutDiaName1.MyText = "";

            this.rtlkICDOutDia2.Text = "";
            rtlkICDOutDia2.DisplayText = "";
            rtlkICDOutDia2.DisplayValue = "";
            this.ltxtOutDiaName2.MyText = "";

            this.rtlkICDOutDia3.Text = "";
            rtlkICDOutDia3.DisplayText = "";
            rtlkICDOutDia3.DisplayValue = "";
            this.ltxtOutDiaName3.MyText = "";

            this.rtlkICDOutDia4.Text = "";
            rtlkICDOutDia4.DisplayText = "";
            rtlkICDOutDia4.DisplayValue = "";
            this.ltxtOutDiaName4.MyText = "";

            this.rtlkICDSurgery1.Text = "";
            rtlkICDSurgery1.DisplayText = "";
            rtlkICDSurgery1.DisplayValue = "";
            this.ltxtSurgeryName1.MyText = "";

            this.rtlkICDSurgery2.Text = "";
            rtlkICDSurgery2.DisplayText = "";
            rtlkICDSurgery2.DisplayValue = "";
            this.ltxtSurgeryName2.MyText = "";

            this.rtlkICDSurgery3.Text = "";
            rtlkICDSurgery3.DisplayText = "";
            rtlkICDSurgery3.DisplayValue = "";
            this.ltxtSurgeryName3.MyText = "";

            this.rtlkICDSurgery4.Text = "";
            rtlkICDSurgery4.DisplayText = "";
            rtlkICDSurgery4.DisplayValue = "";
            this.ltxtSurgeryName4.MyText = "";

            this.cboTreatResult1.Text = "";
            cboTreatResult1.EditValue = "";
            this.cboTreatResult2.Text = "";
            cboTreatResult2.EditValue = "";
            this.cboTreatResult3.Text = "";
            cboTreatResult3.EditValue = "";
            this.cboTreatResult4.Text = "";
            cboTreatResult4.EditValue = "";
            ltxtPatientAge.MyText = "";
            ltxtPatientAddress.MyText = "";

            cboSurgeryDate1.EditValue = null;
            cboSurgeryDate2.EditValue = null;
            cboSurgeryDate3.EditValue = null;
            cboSurgeryDate4.EditValue = null;

            ltxtRecordNo.Focus();
        }

        /// <summary>
        /// 数据为空返回
        /// </summary>
        private bool NullReturn()
        {
            if (this.ltxtRecordNo.MyText == "")
            {
                MessageBox.Show("病案号不能为空！");
                ltxtRecordNo.Focus();
                return true;
            }
            if (this.ltxtInHospitalTime.Text == "")
            {
                MessageBox.Show("入院次数不能为空！");
                ltxtInHospitalTime.Focus();
                return true;
            }
            if (this.ltxtPatientName.MyText == "")
            {
                MessageBox.Show("病人姓名不能为空！");
                ltxtPatientName.Focus();
                return true;
            }
            if (this.cboGender.Text == "")
            {
                MessageBox.Show("性别不能为空！");
                cboGender.Focus();
                return true;
            }
            if (this.cboBirthday.Text == "")
            {
                MessageBox.Show("出生日期不能为空！");
                cboBirthday.Focus();
                return true;
            }
            if (ltxtPatientAge.MyText == "")
            {
                MessageBox.Show("年龄不能为空！");
                ltxtPatientAge.Focus();
                return true;
            }
            //if (rtlkProvince.Text == "" || rtlkCity.Text == "")
            //{
            //    MessageBox.Show("出生地不能为空！");
            //    rtlkProvince.Focus();
            //    return true;
            //}
            //if (ltxtPatientAddress.MyText == "")
            //{
            //    MessageBox.Show("户口地址不能为空！");
            //    ltxtPatientAddress.Focus();
            //    return true;
            //}

            if (cboInHospitalDate.Text == "")
            {
                MessageBox.Show("入院时间不能为空！");
                cboInHospitalDate.Focus();
                return true;
            }
            if (cboOutHospitalDate.Text == "")
            {
                MessageBox.Show("入院时间不能为空！");
                cboOutHospitalDate.Focus();
                return true;
            }
            if (cboInHospitalDate.DateTime > cboOutHospitalDate.DateTime)
            {
                MessageBox.Show("入院时间不能早于出院时间！");
                cboInHospitalDate.Focus();
                return true;
            }
            if (rtlkInHospitalDept.Text == "")
            {
                MessageBox.Show("入院科别不能为空！");
                rtlkInHospitalDept.Focus();
                return true;
            }
            if (rtlkOutHospitalDept.Text == "")
            {
                MessageBox.Show("出院科别不能为空！");
                rtlkOutHospitalDept.Focus();
                return true;
            }
            return false;
        }
        #endregion

        #region 【模糊查询】
        /// <summary>
        /// 模糊查询
        /// </summary>
        private void FuzzySearch()
        {
            this.rtlkProvince.GetData += rtlkProvince_GetData;
            this.rtlkICDOutDia1.GetData += rtlkICDOutDia1_GetData;
            this.rtlkICDOutDia2.GetData += rtlkICDOutDia2_GetData;
            this.rtlkICDOutDia3.GetData += rtlkICDOutDia3_GetData;
            this.rtlkICDOutDia4.GetData += rtlkICDOutDia4_GetData;
            this.rtlkICDSurgery1.GetData += rtlkICDSurgery1_GetData;
            this.rtlkICDSurgery2.GetData += rtlkICDSurgery2_GetData;
            this.rtlkICDSurgery3.GetData += rtlkICDSurgery3_GetData;
            this.rtlkICDSurgery4.GetData += rtlkICDSurgery4_GetData;
            this.rtlkCity.GetData += rtlkCity_GetData;
            this.rtlkInHospitalDept.GetData += rtlkInHospitalDept_GetData;
            this.rtlkOutHospitalDept.GetData += rtlkOutHospitalDept_GetData;
        }

        /// <summary>
        /// 判断RTLookUp控件是否按下Enter键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtlkControls_KeyDown(object sender, KeyEventArgs e)
        {
            Controls.CJiaRTLookUpMoreColArgs a = new Controls.CJiaRTLookUpMoreColArgs();
            Controls.CJiaRTLookUpMoreCol rtlk = (Controls.CJiaRTLookUpMoreCol)sender;
            if (e.KeyCode == Keys.Enter)
            {
                switch (rtlk.Name)
                {
                    case "rtlkProvince":
                        a.SearchValue = rtlkProvince.Text;
                        rtlkProvince_GetData(sender, a);
                        break;
                    case "rtlkInHospitalDept":
                        a.SearchValue = rtlkInHospitalDept.Text;
                        rtlkInHospitalDept_GetData(sender, a);
                        break;
                    case "rtlkOutHospitalDept":
                        a.SearchValue = rtlkOutHospitalDept.Text;
                        rtlkOutHospitalDept_GetData(sender, a);
                        break;
                    case "rtlkICDOutDia1":
                        a.SearchValue = rtlkICDOutDia1.Text;
                        rtlkICDOutDia1_GetData(sender, a);
                        this.ltxtOutDiaName1.MyText = this.rtlkICDOutDia1.DisplayValue;
                        break;
                    case "rtlkICDOutDia2":
                        a.SearchValue = rtlkICDOutDia2.Text;
                        rtlkICDOutDia2_GetData(sender, a);
                        this.ltxtOutDiaName2.MyText = this.rtlkICDOutDia2.DisplayValue;
                        break;
                    case "rtlkICDOutDia3":
                        a.SearchValue = rtlkICDOutDia3.Text;
                        rtlkICDOutDia3_GetData(sender, a);
                        this.ltxtOutDiaName3.MyText = this.rtlkICDOutDia3.DisplayValue;
                        break;
                    case "rtlkICDOutDia4":
                        a.SearchValue = rtlkICDOutDia4.Text;
                        rtlkICDOutDia4_GetData(sender, a);
                        this.ltxtOutDiaName4.MyText = this.rtlkICDOutDia4.DisplayValue;
                        break;
                    case "rtlkICDSurgery1":
                        a.SearchValue = rtlkICDSurgery1.Text;
                        rtlkICDSurgery1_GetData(sender, a);
                        this.ltxtSurgeryName1.MyText = this.rtlkICDSurgery1.DisplayValue;
                        break;
                    case "rtlkICDSurgery2":
                        a.SearchValue = rtlkICDSurgery2.Text;
                        rtlkICDSurgery2_GetData(sender, a);
                        this.ltxtSurgeryName2.MyText = this.rtlkICDSurgery2.DisplayValue;
                        break;
                    case "rtlkICDSurgery3":
                        a.SearchValue = rtlkICDSurgery3.Text;
                        rtlkICDSurgery3_GetData(sender, a);
                        this.ltxtSurgeryName3.MyText = this.rtlkICDSurgery3.DisplayValue;
                        break;
                    case "rtlkICDSurgery4":
                        a.SearchValue = rtlkICDSurgery4.Text;
                        rtlkICDSurgery4_GetData(sender, a);
                        this.ltxtSurgeryName4.MyText = this.rtlkICDSurgery4.DisplayValue;
                        break;
                }
            }

            // 选择ICD编码带出院诊断1
            if (rtlkICDOutDia1.Text == "")
            {
                rtlkICDOutDia1.DisplayValue = "";
                this.ltxtOutDiaName1.MyText = "";
            }

            // 选择ICD编码带出院诊断2
            if (rtlkICDOutDia2.Text == "")
            {
                rtlkICDOutDia2.DisplayValue = "";
                this.ltxtOutDiaName2.MyText = "";
            }


            // 选择ICD编码带出院诊断3
            if (rtlkICDOutDia3.Text == "")
            {
                rtlkICDOutDia3.DisplayValue = "";
                this.ltxtOutDiaName3.MyText = "";
            }


            // 选择ICD编码带出院诊断4
            if (rtlkICDOutDia4.Text == "")
            {
                rtlkICDOutDia4.DisplayValue = "";
                this.ltxtOutDiaName4.MyText = "";
            }


            // 选择ICD编码带出手术名称1
            if (rtlkICDSurgery1.Text == "")
            {
                rtlkICDSurgery1.DisplayValue = "";
                this.ltxtSurgeryName1.MyText = "";
            }


            // 选择ICD编码带出手术名称2
            if (rtlkICDSurgery2.Text == "")
            {
                rtlkICDSurgery2.DisplayValue = "";
                this.ltxtSurgeryName2.MyText = "";
            }


            // 选择ICD编码带出手术名称3
            if (rtlkICDSurgery3.Text == "")
            {
                rtlkICDSurgery3.DisplayValue = "";
                this.ltxtSurgeryName3.MyText = "";
            }


            // 选择ICD编码带出手术名称4
            if (rtlkICDSurgery4.Text == "")
            {
                rtlkICDSurgery4.DisplayValue = "";
                this.ltxtSurgeryName4.MyText = "";
            }
        }

        /// <summary>
        /// 省模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkProvince_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnProviceSearch != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnProviceSearch(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// 市模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkCity_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnCitySearch != null)
            {
                DataTable dtCity = patientInfoEventArgs.TableCity;
                if (dtCity == null)
                {
                    return;
                }
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                patientInfoEventArgs.TableFuzzySearch = dtCity;
                OnCitySearch(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// 入院部门模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkInHospitalDept_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnInHospitalDeptSearch != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnInHospitalDeptSearch(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// 出院部门模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkOutHospitalDept_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnOutHospitalDeptSearch != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnOutHospitalDeptSearch(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// ICD编码（出院诊断1）模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkICDOutDia1_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnICDOutDia1Search != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnICDOutDia1Search(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// ICD编码（出院诊断2）模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkICDOutDia2_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnICDOutDia2Search != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnICDOutDia2Search(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// ICD编码（出院诊断3）模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkICDOutDia3_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnICDOutDia3Search != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnICDOutDia3Search(sender, patientInfoEventArgs);
            }
        }

        ///// <summary>
        ///// ICD编码（出院诊断4）模糊查询
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        void rtlkICDOutDia4_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnICDOutDia4Search != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnICDOutDia4Search(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// ICD编码（手术名称1）模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkICDSurgery1_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnICDSurgery1Search != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnICDSurgery1Search(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// ICD编码（手术名称2）模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkICDSurgery2_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnICDSurgery2Search != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnICDSurgery2Search(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// ICD编码（手术名称3）模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkICDSurgery3_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnICDSurgery3Search != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnICDSurgery3Search(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// ICD编码（手术名称4）模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkICDSurgery4_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnICDSurgery4Search != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnICDSurgery4Search(sender, patientInfoEventArgs);
            }
        }
        #endregion

        #region 【事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.NewPatientInfoInputEventArgs> OnInit;

        /// <summary>
        /// 保存病人信息
        /// </summary>
        public event EventHandler<Views.NewPatientInfoInputEventArgs> OnSavePatientInfo;

        /// <summary>
        /// 根据市筛选省
        /// </summary>
        public event EventHandler<Views.NewPatientInfoInputEventArgs> OnProvinceTextChanged;

        /// <summary>
        /// 查询库中是否存在相同病案号和入院次数
        /// </summary>
        public event EventHandler<Views.NewPatientInfoInputEventArgs> OnCheckIsExistSameRecordNoAndInHospitalTime;

        /// <summary>
        /// 焦点聚焦ComBox2后按下数字快捷选择键
        /// </summary>
        public event EventHandler<Views.NewPatientInfoInputEventArgs> OnKeyPressComBox2;

        #region 模糊查询事件
        /// <summary>
        /// 省模糊查询事件
        /// </summary>
        public event EventHandler<Views.NewPatientInfoInputEventArgs> OnProviceSearch;

        /// <summary>
        /// 市模糊查询
        /// </summary>
        public event EventHandler<Views.NewPatientInfoInputEventArgs> OnCitySearch;

        /// <summary>
        /// 入院科室模糊查询
        /// </summary>
        public event EventHandler<Views.NewPatientInfoInputEventArgs> OnInHospitalDeptSearch;

        /// <summary>
        /// 出院科室模糊查询
        /// </summary>
        public event EventHandler<Views.NewPatientInfoInputEventArgs> OnOutHospitalDeptSearch;

        /// <summary>
        /// ICD编码（出院诊断1）事件
        /// </summary>
        public event EventHandler<Views.NewPatientInfoInputEventArgs> OnICDOutDia1Search;

        /// <summary>
        /// ICD编码（出院诊断2）事件
        /// </summary>
        public event EventHandler<Views.NewPatientInfoInputEventArgs> OnICDOutDia2Search;

        /// <summary>
        /// ICD编码（出院诊断3）事件
        /// </summary>
        public event EventHandler<Views.NewPatientInfoInputEventArgs> OnICDOutDia3Search;

        /// <summary>
        /// ICD编码（出院诊断4）事件
        /// </summary>
        public event EventHandler<Views.NewPatientInfoInputEventArgs> OnICDOutDia4Search;

        /// <summary>
        /// ICD编码（手术名称1）事件
        /// </summary>
        public event EventHandler<Views.NewPatientInfoInputEventArgs> OnICDSurgery1Search;

        /// <summary>
        /// ICD编码（手术名称2）事件
        /// </summary>
        public event EventHandler<Views.NewPatientInfoInputEventArgs> OnICDSurgery2Search;

        /// <summary>
        /// ICD编码（手术名称3）事件
        /// </summary>
        public event EventHandler<Views.NewPatientInfoInputEventArgs> OnICDSurgery3Search;

        /// <summary>
        /// ICD编码（手术名称4）事件
        /// </summary>
        public event EventHandler<Views.NewPatientInfoInputEventArgs> OnICDSurgery4Search;
        #endregion
        #endregion

        #region 快捷键
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F8:
                    btnSave_Click(null, null);
                    return true;
                case Keys.F9:
                    btnReset_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// 下拉快捷键选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > '0' && e.KeyChar < '9' || e.KeyChar == 8)
            {
                CJia.Controls.CJiaComboBox2 cboControl = (CJia.Controls.CJiaComboBox2)sender;
                switch (cboControl.Name)
                {
                    case "cboGender":
                        patientInfoEventArgs.ComBox2Type = "GENDER";
                        break;
                    case "cboTreatResult1":
                        patientInfoEventArgs.ComBox2Type = "TREAT_RESULT";
                        break;
                    case "cboTreatResult2":
                        patientInfoEventArgs.ComBox2Type = "TREAT_RESULT";
                        break;
                    case "cboTreatResult3":
                        patientInfoEventArgs.ComBox2Type = "TREAT_RESULT";
                        break;
                    case "cboTreatResult4":
                        patientInfoEventArgs.ComBox2Type = "TREAT_RESULT";
                        break;
                }
                OnKeyPressComBox2(sender, patientInfoEventArgs);
                DataTable dt = patientInfoEventArgs.TableCombox2;
                if (int.Parse(e.KeyChar.ToString()) > dt.Rows.Count)
                {
                    return;
                }
                switch (e.KeyChar)
                {
                    case '1':
                        cboControl.Text = dt.Rows[0]["NAME"].ToString();
                        cboControl.EditValue = dt.Rows[0]["CODE"].ToString();
                        cboControl.ClosePopup();
                        break;
                    case '2':
                        cboControl.Text = dt.Rows[1]["NAME"].ToString();
                        cboControl.EditValue = dt.Rows[1]["CODE"].ToString();
                        cboControl.ClosePopup();
                        break;
                    case '3':
                        cboControl.Text = dt.Rows[2]["NAME"].ToString();
                        cboControl.EditValue = dt.Rows[2]["CODE"].ToString();
                        break;
                    case '4':
                        cboControl.Text = dt.Rows[3]["NAME"].ToString();
                        cboControl.EditValue = dt.Rows[3]["CODE"].ToString();
                        break;
                    case '5':
                        cboControl.Text = dt.Rows[4]["NAME"].ToString();
                        cboControl.EditValue = dt.Rows[4]["CODE"].ToString();
                        break;
                    case '6':
                        cboControl.Text = dt.Rows[5]["NAME"].ToString();
                        cboControl.EditValue = dt.Rows[5]["CODE"].ToString();
                        break;
                    case '7':
                        cboControl.Text = dt.Rows[6]["NAME"].ToString();
                        cboControl.EditValue = dt.Rows[6]["CODE"].ToString();
                        break;
                    case '8':
                        cboControl.Text = dt.Rows[7]["NAME"].ToString();
                        cboControl.EditValue = dt.Rows[7]["CODE"].ToString();
                        break;
                    case '9':
                        cboControl.Text = dt.Rows[8]["NAME"].ToString();
                        cboControl.EditValue = dt.Rows[8]["CODE"].ToString();
                        break;
                }
            }
        }
        #endregion

        private void cboSurgeryDate4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(null, null);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CJia.Health.App.UI
{
    public partial class PatientInfoInputView : CJia.Health.Tools.View, CJia.Health.Views.IPatientInfoInputView
    {
        public PatientInfoInputView()
        {
            InitializeComponent();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.PatientInfoInputPresenter(this);
        }


        Views.PatientInfoInputEventArgs patientInfoEventArgs = new Views.PatientInfoInputEventArgs();

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PatientInfoInputView_Load(object sender, EventArgs e)
        {
            OnInit(null, null);
            ltxtRecordNo.Controls[0].Leave += CheckExistSameRecordNoAndInHospitalTime;
            ltxtRecordNo.Controls[0].KeyDown += RecordNoAndInHospitalTimeKeyDown;
            ltxtIdCard.Controls[0].Leave += ltxtIdCard_Leave;
            ltxtIdCard.Controls[0].KeyDown += ltxtIdCard_KeyDown;
            FuzzySearch();
            this.rtlkNation.DisplayText = "汉族";
            this.rtlkNation.DisplayValue = "75";
            this.rtlkCountry.DisplayText = "中国";
            this.rtlkCountry.DisplayValue = "36";
        }

      

        #region 模糊查询
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
            this.rtlkICDBLZD1.GetData += rtlkICDBLZD1_GetData;
            this.rtlkICDBLZD2.GetData += rtlkICDBLZD2_GetData;
            this.rtlkICDYNGR1.GetData += rtlkICDYNGR1_GetData;
            this.rtlkICDYNGR2.GetData += rtlkICDYNGR2_GetData;
            this.rtlkNation.GetData += rtlkNation_GetData;
            this.rtlkCity.GetData += rtlkCity_GetData;
            this.rtlkCountry.GetData += rtlkCountry_GetData;
            this.rtlkInHospitalDept.GetData += rtlkInHospitalDept_GetData;
            this.rtlkOutHospitalDept.GetData += rtlkOutHospitalDept_GetData;

            rtlkDeptDirector.GetData += rtlkDeptDirector_GetData;
            rtlkDeptDoctor.GetData += rtlkDeptDoctor_GetData;
            rtlkMainDoctor.GetData += rtlkMainDoctor_GetData;
            this.rtlkInHospitalDoctor.GetData += rtlkInHospitalDoctor_GetData;
            //this.rtlkOutHospitalDoctor.GetData += rtlkOutHospitalDoctor_GetData;

            rtlkAdvanceStudyDoctor.GetData += rtlkAdvanceStudyDoctor_GetData;
            rtlkGraduatePracticeDoctor.GetData += rtlkGraduatePracticeDoctor_GetData;
            rtlkPracticeDoctor.GetData += rtlkPracticeDoctor_GetData;
            rtlkQCDoctor.GetData += rtlkQCDoctor_GetData;
            rtlkQCNurse.GetData += rtlkQCNurse_GetData;
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
                        rtlkProvince_GetData(sender,a);
                        break;
                    case "rtlkNation":
                        a.SearchValue = rtlkNation.Text;
                        rtlkNation_GetData(sender,a);
                        break;
                    case "rtlkCountry":
                        a.SearchValue = rtlkCountry.Text;
                        rtlkCountry_GetData(sender,a);
                        break;
                    case "rtlkInHospitalDept":
                        a.SearchValue = rtlkInHospitalDept.Text;
                        rtlkInHospitalDept_GetData(sender, a);
                        break;
                    case "rtlkOutHospitalDept":
                        a.SearchValue = rtlkOutHospitalDept.Text;
                        rtlkOutHospitalDept_GetData(sender, a);
                        break;
                    //case "rtlkOutHospitalDoctor":
                    //    a.SearchValue = rtlkOutHospitalDoctor.Text;
                    //    rtlkOutHospitalDoctor_GetData(sender, a);
                    //    break;
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
                    case "rtlkICDBLZD1":
                        a.SearchValue = rtlkICDBLZD1.Text;
                        rtlkICDBLZD1_GetData(sender, a);
                        this.ltxtBLZDName1.MyText = this.rtlkICDBLZD1.DisplayValue;
                        break;
                    case "rtlkICDBLZD2":
                        a.SearchValue = rtlkICDBLZD2.Text;
                        rtlkICDBLZD2_GetData(sender, a);
                        this.ltxtBLZDName2.MyText = this.rtlkICDBLZD2.DisplayValue;
                        break;
                    case "rtlkICDYNGR1":
                        a.SearchValue = rtlkICDYNGR1.Text;
                        rtlkICDYNGR1_GetData(sender, a);
                        this.ltxtYNGRName1.MyText = this.rtlkICDYNGR1.DisplayValue;
                        break;
                    case "rtlkICDYNGR2":
                        a.SearchValue = rtlkICDYNGR2.Text;
                        rtlkICDYNGR2_GetData(sender, a);
                        this.ltxtYNGRName2.MyText = this.rtlkICDYNGR2.DisplayValue;
                        break;
                    case "rtlkDeptDirector":
                        a.SearchValue = rtlkDeptDirector.Text;
                        rtlkDeptDirector_GetData(sender, a);
                        break;
                    case "rtlkDeptDoctor":
                        a.SearchValue = rtlkDeptDoctor.Text;
                        rtlkDeptDoctor_GetData(sender, a);
                        break;
                    case "rtlkMainDoctor":
                        a.SearchValue = rtlkMainDoctor.Text;
                        rtlkMainDoctor_GetData(sender, a);
                        break;
                    case "rtlkInHospitalDoctor":
                        a.SearchValue = rtlkInHospitalDoctor.Text;
                        rtlkInHospitalDoctor_GetData(sender, a);
                        break;
                    case "rtlkAdvanceStudyDoctor":
                        a.SearchValue = rtlkAdvanceStudyDoctor.Text;
                        rtlkAdvanceStudyDoctor_GetData(sender, a);
                        break;
                    case "rtlkGraduatePracticeDoctor":
                        a.SearchValue = rtlkGraduatePracticeDoctor.Text;
                        rtlkGraduatePracticeDoctor_GetData(sender, a);
                        break;
                    case "rtlkPracticeDoctor":
                        a.SearchValue = rtlkPracticeDoctor.Text;
                        rtlkPracticeDoctor_GetData(sender, a);
                        break;
                    case "rtlkQCDoctor":
                        a.SearchValue = rtlkQCDoctor.Text;
                        rtlkQCDoctor_GetData(sender, a);
                        break;
                    case "rtlkQCNurse":
                        a.SearchValue = rtlkQCNurse.Text;
                        rtlkQCNurse_GetData(sender, a);
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
        

        // 选择ICD编码带出病理诊断1
            if (rtlkICDBLZD1.Text == "")
            {
                rtlkICDBLZD1.DisplayValue = "";
                this.ltxtBLZDName1.MyText = "";
            }
        

        // 选择ICD编码带出病理诊断2
            if (rtlkICDBLZD2.Text == "")
            {
                rtlkICDBLZD2.DisplayValue = "";
                this.ltxtBLZDName2.MyText = "";
            }
        

        // 选择ICD编码带出院内感染1
       
            if (rtlkICDYNGR1.Text == "")
            {
                rtlkICDYNGR1.DisplayValue = "";
                this.ltxtYNGRName1.MyText = "";
            }
        

        // 选择ICD编码带出院内感染2
       
            if (rtlkICDYNGR2.Text == "")
            {
                rtlkICDYNGR2.DisplayValue = "";
                this.ltxtYNGRName2.MyText = "";
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
                //// 如查询值为空值 则市绑定值为全部
                //if (e.SearchValue.ToString() == "")
                //{
                //    OnProvinceTextChanged(sender, patientInfoEventArgs);
                //}
                //else
                //{
                    DataTable dtCity = patientInfoEventArgs.TableCity;
                    if (dtCity == null)
                    {
                        return;
                    }
                    patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                    patientInfoEventArgs.TableFuzzySearch = dtCity;
                    OnCitySearch(sender, patientInfoEventArgs);
                //}
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
        /// 入院医生模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkInHospitalDoctor_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnInHospitalDoctorSearch != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnInHospitalDoctorSearch(sender, patientInfoEventArgs);
            }
        }

        ///// <summary>
        ///// 入院医生模糊查询
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void rtlkInHospitalDoctor_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        //{
        //    if (OnOutHospitalDocSearch != null)
        //    {
        //        DataTable dtDoctor = (DataTable)this.rtlkInHospitalDoctor.DataGrid.DataSource;
        //        if (dtDoctor == null)
        //        {
        //            return;
        //        }
        //        patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
        //        patientInfoEventArgs.TableFuzzySearch = dtDoctor;
        //        OnInHospitalDocSearch(sender, patientInfoEventArgs);
        //    }
        //}

        ///// <summary>
        ///// 出院医生模糊查询
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void rtlkOutHospitalDoctor_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        //{
        //    if (OnOutHospitalDocSearch != null)
        //    {
        //        // 从所绑DataTable数据源筛选数据
        //        DataTable dtDoctor = (DataTable)this.rtlkOutHospitalDoctor.DataGrid.DataSource;
        //        if (dtDoctor == null)
        //        {
        //            return;
        //        }
        //        patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
        //        patientInfoEventArgs.TableFuzzySearch = dtDoctor;
        //        OnOutHospitalDocSearch(sender, patientInfoEventArgs);
        //    }
        //}

        /// <summary>
        /// 民族模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkNation_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnNationSearch != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnNationSearch(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// 国家模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkCountry_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnCountrySearch != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnCountrySearch(sender, patientInfoEventArgs);
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

        /// <summary>
        /// ICD编码（病理诊断1）模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkICDBLZD1_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnICDBLZD1Search != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnICDBLZD1Search(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// ICD编码（病理诊断2）模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkICDBLZD2_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnICDBLZD2Search != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnICDBLZD2Search(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// ICD编码（院内感染1）模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkICDYNGR1_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnICDYNGR1Search != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnICDYNGR1Search(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// ICD编码（院内感染2）模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkICDYNGR2_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnICDYNGR2Search != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnICDYNGR2Search(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// 科主任模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkDeptDirector_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnDeptDirectorBySearch != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnDeptDirectorBySearch(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// 主（副）任医师模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkDeptDoctor_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnDeptDoctorBySearch != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnDeptDoctorBySearch(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// 主治医生模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkMainDoctor_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnMainDoctorBySearch != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnMainDoctorBySearch(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// 进修医师模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkAdvanceStudyDoctor_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnAdvanceStudyDoctorBySearch != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnAdvanceStudyDoctorBySearch(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// 研究生实习医生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkGraduatePracticeDoctor_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnGraduatePracticeDoctor != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnGraduatePracticeDoctor(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// 实习医生模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkPracticeDoctor_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnPracticeDoctorBySearch != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnPracticeDoctorBySearch(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// 质检医生模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkQCDoctor_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnQCDoctorBySearch != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnQCDoctorBySearch(sender, patientInfoEventArgs);
            }
        }

        /// <summary>
        /// 质检护士模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rtlkQCNurse_GetData(object sender, Controls.CJiaRTLookUpMoreColArgs e)
        {
            if (OnQCNurseBySearch != null)
            {
                patientInfoEventArgs.StrFuzzySearch = e.SearchValue.ToUpper().ToString();
                OnQCNurseBySearch(sender, patientInfoEventArgs);
            }
        }
        #endregion

        #region 绑定界面下拉列表

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
        void BindRTLookUp(Controls.CJiaRTLookUpMoreCol rtlLookUp, DataTable dtData, string displayField, string valueField,string inCode)
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
            //AddRowWhenNull(dtData);
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
        /// 绑定婚姻状况
        /// </summary>
        /// <param name="dtIsMarry"></param>
        public void ExeBindIsMarry(DataTable dtIsMarry)
        {
            BindComboBox2(this.cboIsMarry, dtIsMarry, "NAME", "CODE");
        }

        /// <summary>
        /// 绑定职业
        /// </summary>
        /// <param name="dtJob"></param>
        public void ExeBindJob(DataTable dtJob)
        {
            BindComboBox2(this.cboJob, dtJob, "NAME", "CODE");
        }

        /// <summary>
        /// 绑定所在省(直辖市)
        /// </summary>
        /// <param name="dtProvince"></param>
        public void ExeBindProvince(DataTable dtProvince)
        {
            BindRTLookUp(this.rtlkProvince, dtProvince, "AREA_NAME", "AREA_ID","PINYIN");
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
        /// 绑定民族
        /// </summary>
        /// <param name="dtNation"></param>
        public void ExeBindNation(DataTable dtNation)
        {
            BindRTLookUp(this.rtlkNation, dtNation, "NAME", "CODE", "PINYIN");
        }

        /// <summary>
        /// 绑定国籍
        /// </summary>
        /// <param name="dtCountry"></param>
        public void ExeBindCountry(DataTable dtCountry)
        {
            BindRTLookUp(this.rtlkCountry, dtCountry, "COUNTRY_NAME", "COUNTRY_ID", "PINYIN");
        }


        /// <summary>
        /// 绑定入院方式
        /// </summary>
        /// <param name="dtInHospitalType"></param>
        public void ExeBindInHospitalType(DataTable dtInHospitalType)
        {
            BindComboBox2(this.cboInHospitalType, dtInHospitalType, "NAME", "CODE");
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
        /// 绑定医师
        /// </summary>
        /// <param name="dtDoctor"></param>
        public void ExeBindDoctor(DataTable dtDoctor)
        {
            // 绑定科主任
            BindRTLookUp(this.rtlkDeptDirector, dtDoctor, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");

            // 绑定主（副）任医师
            BindRTLookUp(this.rtlkDeptDoctor, dtDoctor, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");

            // 主治医师
            BindRTLookUp(this.rtlkMainDoctor, dtDoctor, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");

            // 绑定住院医师名称
            BindRTLookUp(this.rtlkInHospitalDoctor, dtDoctor, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");

            // 进修医师
            BindRTLookUp(this.rtlkAdvanceStudyDoctor, dtDoctor, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");

            // 研究生实习医生
            BindRTLookUp(this.rtlkGraduatePracticeDoctor, dtDoctor, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");

            // 实习医师
            BindRTLookUp(this.rtlkPracticeDoctor, dtDoctor, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");

            // 质控医师
            BindRTLookUp(this.rtlkQCDoctor, dtDoctor, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");

            // 质控护士
            BindRTLookUp(this.rtlkQCNurse, dtDoctor, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");
            //// 绑定出院医师名称
            //BindRTLookUp(this.rtlkOutHospitalDoctor, dtDoctorName, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");
        }

        /// <summary>
        /// 绑定科主任
        /// </summary>
        /// <param name="dtDeptDirector"></param>
        public void ExeBindDeptDirector(DataTable dtDeptDirector)
        {
            BindRTLookUp(this.rtlkDeptDirector, dtDeptDirector, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");
        }

        /// <summary>
        /// 绑定主（副）任医师
        /// </summary>
        /// <param name="dtDeptDoctor"></param>
        public void ExeBindDeptDoctor(DataTable dtDeptDoctor)
        {
            BindRTLookUp(this.rtlkDeptDoctor, dtDeptDoctor, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");
        }

        /// <summary>
        /// 绑定主治医生
        /// </summary>
        /// <param name="dtMainDoctor"></param>
        public void ExeBindMainDoctor(DataTable dtMainDoctor)
        {
            BindRTLookUp(this.rtlkMainDoctor, dtMainDoctor, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");
        }

        /// <summary>
        /// 绑定住院医师名称
        /// </summary>
        /// <param name="dtInHospitalDoctor"></param>
        public void ExeBindInHospitalDoctor(DataTable dtInHospitalDoctor)
        {
            BindRTLookUp(this.rtlkInHospitalDoctor, dtInHospitalDoctor, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");
        }

        /// <summary>
        /// 进修医师
        /// </summary>
        /// <param name="dtAdvanceStudyDoctor"></param>
        public void ExeBindAdvanceStudyDoctor(DataTable dtAdvanceStudyDoctor)
        {
            BindRTLookUp(this.rtlkAdvanceStudyDoctor, dtAdvanceStudyDoctor, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");
        }

        /// <summary>
        /// 研究生实习医生
        /// </summary>
        /// <param name="dtGraduatePracticeDoctor"></param>
        public void ExeBindGraduatePracticeDoctor(DataTable dtGraduatePracticeDoctor)
        {
            BindRTLookUp(this.rtlkGraduatePracticeDoctor, dtGraduatePracticeDoctor, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");
        }

        /// <summary>
        /// 实习医生
        /// </summary>
        /// <param name="dtPracticeDoctor"></param>
        public void ExeBindPracticeDoctor(DataTable dtPracticeDoctor)
        {
            BindRTLookUp(this.rtlkPracticeDoctor, dtPracticeDoctor, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");
        }

        /// <summary>
        /// 质控医生
        /// </summary>
        /// <param name="dtQCDoctor"></param>
        public void ExeBindQCDoctor(DataTable dtQCDoctor)
        {
            BindRTLookUp(this.rtlkQCDoctor, dtQCDoctor, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");
        }

        /// <summary>
        /// 质控护士
        /// </summary>
        /// <param name="dtQCNurse"></param>
        public void ExeBindQCNurse(DataTable dtQCNurse)
        {
            BindRTLookUp(this.rtlkQCNurse, dtQCNurse, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");
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

        ///// <summary>
        ///// 入院医生名称
        ///// </summary>
        ///// <param name="dtInDoctorSearch"></param>
        //public void ExeInDoctor(DataTable dtInDoctorSearch)
        //{
        //    BindRTLookUp(rtlkInHospitalDoctor, dtInDoctorSearch, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");
        //}

        ///// <summary>
        ///// 出院医生名称
        ///// </summary>
        ///// <param name="dtOutDoctorSearch"></param>
        //public void ExeOutDoctor(DataTable dtOutDoctorSearch)
        //{
        //    BindRTLookUp(rtlkOutHospitalDoctor, dtOutDoctorSearch, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");
        //}

        ///// <summary>
        ///// 根据入院部门查询医生
        ///// </summary>
        ///// <param name="dtSearchInDoctorByDept"></param>
        //public void ExeSearchInDoctorByDept(DataTable dtSearchInDoctorByDept)
        //{
        //    BindRTLookUp(rtlkInHospitalDoctor, dtSearchInDoctorByDept, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");
        //}

        ///// <summary>
        ///// 根据出院部门查询医生
        ///// </summary>
        ///// <param name="dtSearchOutDoctorByDept"></param>
        //public void ExeSearchOutDoctorByDept(DataTable dtSearchOutDoctorByDept)
        //{
        //    BindRTLookUp(rtlkOutHospitalDoctor, dtSearchOutDoctorByDept, "DOCTOR_NAME", "DOCTOR_ID", "DOCTOR_NO");
        //}

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
        /// ICD编码（病理诊断1）
        /// </summary>
        /// <param name="dtICDBLZD1"></param>
        public void ExeICDBLZD1(DataTable dtICDBLZD1)
        {
            BindRTLookUp(rtlkICDBLZD1, dtICDBLZD1, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
        }

        /// <summary>
        /// ICD编码（病理诊断2）
        /// </summary>
        /// <param name="dtICDBLZD1"></param>
        public void ExeICDBLZD2(DataTable dtICDBLZD2)
        {
            BindRTLookUp(rtlkICDBLZD2, dtICDBLZD2, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
        }

        /// <summary>
        /// ICD编码（院内感染1）
        /// </summary>
        /// <param name="dtICDYNGR1"></param>
        public void ExeICDYNGR1(DataTable dtICDYNGR1)
        {
            BindRTLookUp(rtlkICDYNGR1, dtICDYNGR1, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
        }

        /// <summary>
        /// ICD编码（院内感染2）
        /// </summary>
        /// <param name="dtICDYNGR2"></param>
        public void ExeICDYNGR2(DataTable dtICDYNGR2)
        {
            BindRTLookUp(rtlkICDYNGR2, dtICDYNGR2, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
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

            // 病理诊断1
            BindRTLookUp(this.rtlkICDBLZD1, dtICDCode, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
            // 病理诊断2
            BindRTLookUp(this.rtlkICDBLZD2, dtICDCode, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");

            // 院内感染1
            BindRTLookUp(this.rtlkICDYNGR1, dtICDCode, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");
            // 院内感染2
            BindRTLookUp(this.rtlkICDYNGR2, dtICDCode, "ICD10_CODE", "ICD10_NAME", "ICD10_NAME");

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

        /// <summary>
        /// 绑定血型
        /// </summary>
        /// <param name="dtBloodType"></param>
        public void ExeBindBloodType(DataTable dtBloodType)
        {
            BindComboBox2(this.cboBloodType, dtBloodType, "NAME", "CODE");
        }

        /// <summary>
        ///各种下拉诊断绑定
        /// </summary>
        /// <param name="dtData"></param>
        public void ExeBindDiagnosisResult(DataTable dtData)
        {
            // 门诊诊断与出院诊断
            BindComboBox2(this.cboOutPatientOutHospitalDia, dtData, "NAME", "CODE");
            // 入院诊断与出院诊断
            BindComboBox2(this.cboInOutHospitalDia, dtData, "NAME", "CODE");
            // 术前诊断与术后诊断
            BindComboBox2(this.cboBeforeAfterSurDia, dtData, "NAME", "CODE");
            // 放射诊断与术后诊断
            BindComboBox2(this.cboRadAfterDia, dtData, "NAME", "CODE");
            // 临床诊断与病理诊断
            BindComboBox2(this.cboClinicalPathDia, dtData, "NAME", "CODE");
        }

        /// <summary>
        /// 绑定病案质量
        /// </summary>
        /// <param name="dtRecordQuality"></param>
        public void ExeBindRecordQuality(DataTable dtRecordQuality)
        {
            BindComboBox2(cboRecodeQuality,dtRecordQuality,"NAME","CODE");
        }
        #endregion

        #region 触发控件事件
        /// <summary>
        /// 按下Enter校验身份证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ltxtIdCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ltxtIdCard_Leave(null, null);
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
                if (Message.ShowQuery("身份证号有误,确定要继续输入?") == Message.Result.Cancel)
                {
                    ltxtIdCard.Focus();
                }
            }
        }

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
        /// 按下Enter键校验是否存在此病案号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RecordNoAndInHospitalTimeKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckExistSameRecordNoAndInHospitalTime(null, null);
            }
        }

        /// <summary>
        /// 焦点离开时校验是否存在此病案号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CheckExistSameRecordNoAndInHospitalTime(object sender, EventArgs e)
        {
            if (ltxtRecordNo.MyText != "" && ltxtInHospitalTime.Text != "")
            {
                patientInfoEventArgs.RecordNo = ltxtRecordNo.MyText;
                patientInfoEventArgs.InHospitalTime = int.Parse(ltxtInHospitalTime.Text);
                OnCheckIsExistSameRecordNoAndInHospitalTime(sender, patientInfoEventArgs);
                if (patientInfoEventArgs.TablePatientInfoByRecordNo != null)
                {
                    if (patientInfoEventArgs.TablePatientInfoByRecordNo.Rows.Count > 0)
                    {
                        MessageBox.Show("【"+this.ltxtPatientName.MyText+"】存在相同【病案号+入院次数】！");
                        return;
                        //            DataRow dr = patientInfoEventArgs.TablePatientInfoByRecordNo.Rows[0];
                        //            this.ltxtRecordNo.MyText = dr["RECORDNO"].ToString();
                        //            this.ltxtPatientId.MyText = dr["PATIENT_ID"].ToString();
                        //            this.ltxtShelfNo.MyText = dr["SHELFNO"].ToString();
                        //            this.chkIsSpecial.CheckState = dr["IS_SPECIAL"].ToString() == "0" ? CheckState.Unchecked : CheckState.Checked;
                        //            this.ltxtPatientName.MyText = dr["PATIENT_NAME"].ToString();
                        //            this.cboGender.Text = dr["GENDER_NAME"].ToString();
                        //            this.cboGender.EditValue = dr["GENDER"].ToString();
                        //            this.cboBirthday.Text = DateTime.Parse(dr["BIRTHDAY"].ToString()).ToString("yyyy-MM-dd");
                        //            this.cboIsMarry.Text = dr["IS_MARRY_NAME"].ToString();
                        //            this.cboIsMarry.EditValue = dr["IS_MARRY"].ToString();
                        //            this.cboJob.Text = dr["JOB_NAME"].ToString();
                        //            this.cboJob.EditValue = dr["JOB"].ToString();
                        //            this.rtlkProvince.Text = dr["PROVINCE_NAME"].ToString();
                        //            this.rtlkProvince.DisplayValue = dr["PROVINCE"].ToString();
                        //            this.rtlkCity.Text = dr["CITY_NAME"].ToString();
                        //            this.rtlkCity.DisplayValue = dr["CITY"].ToString();
                        //            this.ltxtIdCard.MyText = dr["ID_CARD"].ToString();
                        //            this.ltxtInHospitalTime.Text = dr["IN_HOSPITAL_TIME"].ToString();

                        //            this.rtlkCountry.DisplayText = dr["COUNTRY_NAME"].ToString();
                        //            this.rtlkCountry.DisplayValue = dr["COUNTRY"].ToString();
                        //            this.rtlkNation.DisplayText = dr["NATION_NAME"].ToString();
                        //            this.rtlkNation.DisplayValue = dr["NATION"].ToString();
                        //            this.cboInHospitalType.Text = dr["IN_HOSPITAL_TYPE_NAME"].ToString();
                        //            this.cboInHospitalType.EditValue = dr["IN_HOSPITAL_TYPE"].ToString();
                        //            this.ltxtInHospitalTime.Text = dr["IN_HOSPITAL_TIME"].ToString();

                        //            this.cboInHospitalDate.Text = DateTime.Parse(dr["IN_HOSPITAL_DATE"].ToString()).ToString("yyyy-MM-dd");
                        //            this.cboOutHospitalDate.Text = DateTime.Parse(dr["OUT_HOSPITAL_DATE"].ToString()).ToString("yyyy-MM-dd");

                        //            this.rtlkInHospitalDept.Text = dr["IN_HOSPITAL_DEPT_NAME"].ToString();
                        //            this.rtlkInHospitalDept.DisplayValue = dr["IN_HOSPITAL_DEPT"].ToString();
                        //            this.rtlkOutHospitalDept.Text = dr["OUT_HOSPITAL_DEPT_NAME"].ToString();
                        //            this.rtlkOutHospitalDept.DisplayValue = dr["OUT_HOSPITAL_DEPT"].ToString();
                        //            //this.rtlkInHospitalDoctor.Text = dr["IN_HOSPITAL_DOCTOR_NAME"].ToString();
                        //            //this.rtlkInHospitalDoctor.DisplayValue = dr["IN_HOSPITAL_DOCTOR"].ToString();
                        //            //this.ltxtInHospitalDocId.MyText = dr["IN_HOSPITAL_DOCTOR_NO"].ToString();
                        //            //this.rtlkOutHospitalDoctor.Text = dr["OUT_HOSPITAL_DOCTOR_NAME"].ToString();
                        //            //this.rtlkOutHospitalDoctor.DisplayValue = dr["OUT_HOSPITAL_DOCTOR"].ToString();
                        //            //this.ltxtOutHospitalDocId.MyText = dr["OUT_HOSPITAL_DOCTOR_NO"].ToString();
                        //            ltxtInHospitalRoom.MyText = dr["IN_HOSPITAL_ROOM"].ToString();
                        //            ltxtOutHospitalRoom.MyText = dr["OUT_HOSPITAL_ROOM"].ToString();
                        //            this.ltxtDrugAllergy.MyText = dr["DRUG_ALLERGY"].ToString();
                        //            this.cboBloodType.Text = dr["BLOOD_TYPE_NAME"].ToString();
                        //            this.cboBloodType.EditValue = dr["BLOOD_TYPE"].ToString();
                        //            this.rtlkICDOutDia1.Text = dr["ICD_OUTDIA1"].ToString();
                        //            this.rtlkICDOutDia1.DisplayValue = dr["ICD_OUTDIA1"].ToString();
                        //            this.ltxtOutDiaName1.MyText = dr["OUTDIA_NAME1"].ToString();
                        //            this.rtlkICDOutDia2.Text = dr["ICD_OUTDIA2"].ToString();
                        //            this.rtlkICDOutDia2.DisplayValue = dr["ICD_OUTDIA2"].ToString();
                        //            this.ltxtOutDiaName2.MyText = dr["OUTDIA_NAME2"].ToString();
                        //            this.rtlkICDOutDia3.Text = dr["ICD_OUTDIA3"].ToString();
                        //            this.rtlkICDOutDia3.DisplayValue = dr["ICD_OUTDIA3"].ToString();
                        //            this.ltxtOutDiaName3.MyText = dr["OUTDIA_NAME3"].ToString();
                        //            this.rtlkICDOutDia4.Text = dr["ICD_OUTDIA4"].ToString();
                        //            this.rtlkICDOutDia4.DisplayValue = dr["ICD_OUTDIA4"].ToString();
                        //            this.ltxtOutDiaName4.MyText = dr["OUTDIA_NAME4"].ToString();
                        //            this.rtlkICDSurgery1.Text = dr["ICD_SURGERY1"].ToString();
                        //            this.rtlkICDSurgery1.DisplayValue = dr["ICD_SURGERY1"].ToString();
                        //            this.ltxtSurgeryName1.MyText = dr["SURGERY_NAME1"].ToString();
                        //            this.rtlkICDSurgery2.Text = dr["ICD_SURGERY2"].ToString();
                        //            this.rtlkICDSurgery2.DisplayValue = dr["ICD_SURGERY2"].ToString();
                        //            this.ltxtSurgeryName2.MyText = dr["SURGERY_NAME2"].ToString();
                        //            this.rtlkICDSurgery3.Text = dr["ICD_SURGERY3"].ToString();
                        //            this.rtlkICDSurgery3.DisplayValue = dr["ICD_SURGERY3"].ToString();
                        //            this.ltxtSurgeryName3.MyText = dr["SURGERY_NAME3"].ToString();
                        //            this.rtlkICDSurgery4.Text = dr["ICD_SURGERY4"].ToString();
                        //            this.rtlkICDSurgery4.DisplayValue = dr["ICD_SURGERY4"].ToString();
                        //            this.ltxtSurgeryName4.MyText = dr["SURGERY_NAME4"].ToString();

                        //            this.cboTreatResult1.Text = dr["TREAT_RESULT1_NAME"].ToString();
                        //            this.cboTreatResult1.EditValue = dr["TREAT_RESULT1"].ToString();
                        //            this.cboTreatResult2.Text = dr["TREAT_RESULT2_NAME"].ToString();
                        //            this.cboTreatResult2.EditValue = dr["TREAT_RESULT2"].ToString();
                        //            this.cboTreatResult3.Text = dr["TREAT_RESULT3_NAME"].ToString();
                        //            this.cboTreatResult3.EditValue = dr["TREAT_RESULT3"].ToString();
                        //            this.cboTreatResult4.Text = dr["TREAT_RESULT4_NAME"].ToString();
                        //            this.cboTreatResult4.EditValue = dr["TREAT_RESULT4"].ToString();

                        //            this.rtlkICDBLZD1.DisplayValue = dr["ICD_BLZD1"].ToString();
                        //            this.rtlkICDBLZD1.Text = dr["ICD_BLZD1"].ToString();
                        //            this.ltxtBLZDName1.MyText = dr["BLZD_NAME1"].ToString();
                        //            this.rtlkICDBLZD2.DisplayValue = dr["ICD_BLZD2"].ToString();
                        //            this.rtlkICDBLZD2.Text = dr["ICD_BLZD2"].ToString();
                        //            this.ltxtBLZDName2.MyText = dr["BLZD_NAME2"].ToString();
                        //            this.rtlkICDYNGR1.Text = dr["ICD_YNGR1"].ToString();
                        //            this.rtlkICDYNGR1.DisplayValue = dr["ICD_YNGR1"].ToString();
                        //            this.ltxtYNGRName1.MyText = dr["YNGR_NAME1"].ToString();
                        //            this.rtlkICDYNGR2.Text = dr["ICD_YNGR2"].ToString();
                        //            this.rtlkICDYNGR2.DisplayValue = dr["ICD_YNGR2"].ToString();
                        //            this.ltxtYNGRName2.MyText = dr["YNGR_NAME2"].ToString();
                        //            this.cboOutPatientOutHospitalDia.Text = dr["OUTPATIENT_OUT_DIA_NAME"].ToString();
                        //            this.cboOutPatientOutHospitalDia.EditValue = dr["OUTPATIENT_OUT_DIA"].ToString();
                        //            this.cboInOutHospitalDia.Text = dr["IN_OUT_HOSPITAL_DIA_NAME"].ToString();
                        //            this.cboInOutHospitalDia.EditValue = dr["IN_OUT_HOSPITAL_DIA"].ToString();
                        //            this.cboBeforeAfterSurDia.Text = dr["BEGORE_AFTER_SURGERY_DIA_NAME"].ToString();
                        //            this.cboBeforeAfterSurDia.EditValue = dr["BEGORE_AFTER_SURGERY_DIA"].ToString();
                        //            this.cboRadAfterDia.Text = dr["RADIATION_AFTER_DIA_NAME"].ToString();
                        //            this.cboRadAfterDia.EditValue = dr["RADIATION_AFTER_DIA"].ToString();
                        //            this.cboClinicalPathDia.Text = dr["CLINICAL_PATHOLOGY_DIA_NAME"].ToString();
                        //            this.cboClinicalPathDia.EditValue = dr["CLINICAL_PATHOLOGY_DIA"].ToString();
                        //            ltxtPatientAge.MyText = dr["PATIENT_AGE"].ToString();
                        //            ltxtPatientAddress.MyText = dr["PATIENT_ADDRESS"].ToString();

                        //            rtlkDeptDirector.Text = dr["DEPT_DIRECTOR_NAME"].ToString();
                        //            rtlkDeptDirector.DisplayValue = dr["DEPT_DIRECTOR"].ToString();
                        //            rtlkDeptDoctor.Text = dr["DEPT_DOCTOR_NAME"].ToString();
                        //            rtlkDeptDoctor.DisplayValue = dr["DEPT_DOCTOR"].ToString();
                        //            rtlkMainDoctor.Text = dr["MAIN_DOCTOR_NAME"].ToString();
                        //            rtlkMainDoctor.DisplayValue = dr["MAIN_DOCTOR"].ToString();
                        //            rtlkInHospitalDoctor.Text = dr["IN_HOSPITAL_DOCTOR_NAME"].ToString();
                        //            rtlkInHospitalDoctor.DisplayValue = dr["IN_HOSPITAL_DOCTOR"].ToString();
                        //            rtlkAdvanceStudyDoctor.Text = dr["ADVANCE_STUDY_DOCTOR_NAME"].ToString();
                        //            rtlkAdvanceStudyDoctor.DisplayValue = dr["ADVANCE_STUDY_DOCTOR"].ToString();
                        //            rtlkGraduatePracticeDoctor.Text = dr["GRADUATE_PRACTICE_DOCTOR_NAME"].ToString();
                        //            rtlkGraduatePracticeDoctor.DisplayValue = dr["GRADUATE_PRACTICE_DOCTOR"].ToString();
                        //            rtlkPracticeDoctor.Text = dr["PRACTICE_DOCTOR_NAME"].ToString();
                        //            rtlkPracticeDoctor.DisplayValue = dr["PRACTICE_DOCTOR"].ToString();
                        //            cboRecodeQuality.Text = dr["RECORD_QUALITY_NAME"].ToString();
                        //            cboRecodeQuality.EditValue = dr["RECORD_QUALITY"].ToString();
                        //            rtlkQCDoctor.Text = dr["QC_DOCTOR_NAME"].ToString();
                        //            rtlkQCDoctor.DisplayValue = dr["QC_DOCTOR"].ToString();
                        //            rtlkQCNurse.Text = dr["QC_NURSE_NAME"].ToString();
                        //            rtlkQCNurse.DisplayValue = dr["QC_NURSE"].ToString();
                    }
                }
            }
            patientInfoEventArgs.TablePatientInfoByRecordNo = null;
        }

        // 改变省输入框值时触发
        private void rtlkProvince_TextChanged(object sender, EventArgs e)
        {
            if (this.rtlkProvince.Text == "")
            {
                // 让搜索条件为空字符，置空市数据源数据源
                this.rtlkProvince.DisplayValue = "";
            }
            patientInfoEventArgs.SelectedProvinceId = this.rtlkProvince.DisplayValue;
            OnProvinceTextChanged(sender, patientInfoEventArgs);
            this.rtlkCity.Text = "";
            this.rtlkCity.DisplayValue = "";
        }

        // 改变市输入框值时触发
        private void rtlkCity_TextChanged(object sender, EventArgs e)
        {
            // 如查询值为空值 则市绑定值为全部
            if (this.rtlkCity.Text.ToString() == "")
            {
                OnProvinceTextChanged(sender, patientInfoEventArgs);
            }
        }
        //// 选择入院部门带出部门医生
        //private void rtlkInHospitalDept_TextChanged(object sender, EventArgs e)
        //{
        //    if (this.rtlkInHospitalDept.Text == "")
        //    {
        //        // 让搜索条件为空字符，置空入院部门数据源
        //        this.rtlkInHospitalDept.DisplayValue = "";
        //    }
        //    patientInfoEventArgs.StrFuzzySearch = this.rtlkInHospitalDept.DisplayValue;
        //    OnSearchInDoctorByDept(sender, patientInfoEventArgs);
        //    this.rtlkInHospitalDoctor.Text = "";
        //    this.rtlkInHospitalDoctor.DisplayValue = "";
        //    this.ltxtInHospitalDocId.MyText = "";
        //}

        //// 选择出院部门带出部门医生
        //private void rtlkOutHospitalDept_TextChanged(object sender, EventArgs e)
        //{
        //    if (this.rtlkOutHospitalDept.Text == "")
        //    {
        //        // 让搜索条件为空字符，置空出院部门数据源
        //        this.rtlkOutHospitalDept.DisplayValue = "";
        //    }
        //    patientInfoEventArgs.StrFuzzySearch = this.rtlkOutHospitalDept.DisplayValue;
        //    OnSearchOutDoctorByDept(sender, patientInfoEventArgs);
        //    this.rtlkOutHospitalDoctor.Text = "";
        //    this.rtlkOutHospitalDoctor.DisplayValue = "";
        //    this.ltxtOutHospitalDocId.MyText = "";
        //}
        //// 选择入院医生名称时带出医生ID
        //private void rtlkInHospitalDoctor_TextChanged(object sender, EventArgs e)
        //{
        //    if (rtlkInHospitalDept.Text == "")
        //    {
        //        this.rtlkInHospitalDoctor.DataSource = null;
        //    }
        //    DataTable dtInDoctor = this.rtlkInHospitalDoctor.DataSource;
        //    if (dtInDoctor != null)
        //    {
        //        if (dtInDoctor.Rows.Count > 0 && this.rtlkInHospitalDoctor.DisplayValue != "")
        //        {
        //            this.ltxtInHospitalDocId.MyText = dtInDoctor.Select(" DOCTOR_ID ='" + this.rtlkInHospitalDoctor.DisplayValue + "' ")[0]["DOCTOR_NO"].ToString();
        //        }
        //    }

        //}

        //// 选择出院医生名称时带出医生ID
        //private void rtlkOutHospitalDoctor_TextChanged(object sender, EventArgs e)
        //{
        //    DataTable dtOutDoctor = this.rtlkOutHospitalDoctor.DataSource;
        //   if (dtOutDoctor != null)
        //    {
        //        if (dtOutDoctor.Rows.Count > 0 && this.rtlkOutHospitalDoctor.DisplayValue != "")
        //        {
        //            this.ltxtOutHospitalDocId.MyText = dtOutDoctor.Select(" DOCTOR_ID ='" + this.rtlkOutHospitalDoctor.DisplayValue + "' ")[0]["DOCTOR_NO"].ToString();
        //        }
        //    }
        //}
       

        // 选择ICD编码带出院诊断1
        private void rtlkICDOutDia1_TextChanged(object sender, EventArgs e)
        {
            this.ltxtOutDiaName1.MyText = this.rtlkICDOutDia1.DisplayValue;
            if (rtlkICDOutDia1.Text == "")
            {
                rtlkICDOutDia1.DisplayValue = "";
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
                this.ltxtSurgeryName1.MyText = "";
            }
        }

        // 选择ICD编码带出手术名称2
        private void rtlkICDSurgery2_TextChanged(object sender, EventArgs e)
        {
            this.ltxtSurgeryName2.MyText = this.rtlkICDSurgery2.DisplayValue;
            if (rtlkICDSurgery2.Text == "")
            {
                rtlkICDSurgery2.DisplayValue = "";
                this.ltxtSurgeryName2.MyText = "";
            }
        }

        // 选择ICD编码带出手术名称3
        private void rtlkICDSurgery3_TextChanged(object sender, EventArgs e)
        {
            this.ltxtSurgeryName3.MyText = this.rtlkICDSurgery3.DisplayValue;
            if (rtlkICDSurgery3.Text == "")
            {
                rtlkICDSurgery3.DisplayValue = "";
                this.ltxtSurgeryName3.MyText = "";
            }
        }

        // 选择ICD编码带出手术名称4
        private void rtlkICDSurgery4_TextChanged(object sender, EventArgs e)
        {
            this.ltxtSurgeryName4.MyText = this.rtlkICDSurgery4.DisplayValue;
            if (rtlkICDSurgery4.Text == "")
            {
                rtlkICDSurgery4.DisplayValue = "";
                this.ltxtSurgeryName4.MyText = "";
            }
        }

        // 选择ICD编码带出病理诊断1
        private void rtlkICDBLZD1_TextChanged(object sender, EventArgs e)
        {
            this.ltxtBLZDName1.MyText = this.rtlkICDBLZD1.DisplayValue;
            if (rtlkICDBLZD1.Text == "")
            {
                rtlkICDBLZD1.DisplayValue = "";
                this.ltxtBLZDName1.MyText = "";
            }
        }

        // 选择ICD编码带出病理诊断2
        private void rtlkICDBLZD2_TextChanged(object sender, EventArgs e)
        {
            this.ltxtBLZDName2.MyText = this.rtlkICDBLZD2.DisplayValue;
            if (rtlkICDBLZD2.Text == "")
            {
                rtlkICDBLZD2.DisplayValue = "";
                this.ltxtBLZDName2.MyText = "";
            }
        }

        // 选择ICD编码带出院内感染1
        private void rtlkICDYNGR1_TextChanged(object sender, EventArgs e)
        {
            this.ltxtYNGRName1.MyText = this.rtlkICDYNGR1.DisplayValue;
            if (rtlkICDYNGR1.Text == "")
            {
                rtlkICDYNGR1.DisplayValue = "";
                this.ltxtYNGRName1.MyText = "";
            }
        }

        // 选择ICD编码带出院内感染2
        private void rtlkICDYNGR2_TextChanged(object sender, EventArgs e)
        {
            this.ltxtYNGRName2.MyText = this.rtlkICDYNGR2.DisplayValue;
            if (rtlkICDYNGR2.Text == "")
            {
                rtlkICDYNGR2.DisplayValue = "";
                this.ltxtYNGRName2.MyText = "";
            }
        }

        // 保存事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (NullReturn())
            {
                return;
            }
            patientInfoEventArgs.RecordNo = this.ltxtRecordNo.MyText;
            patientInfoEventArgs.PatientId = this.ltxtPatientId.MyText;
            patientInfoEventArgs.ShelfNo = this.ltxtShelfNo.MyText;
            patientInfoEventArgs.IsSpecial = this.chkIsSpecial.CheckState == CheckState.Checked ? "1" : "0";
            patientInfoEventArgs.PatientName = this.ltxtPatientName.MyText;
            patientInfoEventArgs.Gender = this.cboGender.EditValue.ToString();
            patientInfoEventArgs.BirthDate = this.cboBirthday.DateTime;
            patientInfoEventArgs.IsMarry = this.cboIsMarry.EditValue.ToString();
            patientInfoEventArgs.Job = this.cboJob.EditValue.ToString();
            patientInfoEventArgs.Province = this.rtlkProvince.DisplayValue;
            patientInfoEventArgs.City = this.rtlkCity.DisplayValue;
            patientInfoEventArgs.Nation = this.rtlkNation.DisplayValue;
            patientInfoEventArgs.Country = this.rtlkCountry.DisplayValue;
            patientInfoEventArgs.IDCard = this.ltxtIdCard.MyText;
            patientInfoEventArgs.InHospitalType = this.cboInHospitalType.EditValue.ToString();
            patientInfoEventArgs.InHospitalTime = int.Parse(this.ltxtInHospitalTime.Text);
            patientInfoEventArgs.InHospitalDate = this.cboInHospitalDate.DateTime;
            patientInfoEventArgs.OutHospitalDate = this.cboOutHospitalDate.DateTime;
            patientInfoEventArgs.InHospitalDept = this.rtlkInHospitalDept.DisplayValue;
            patientInfoEventArgs.OutHospitalDept = this.rtlkOutHospitalDept.DisplayValue;
            patientInfoEventArgs.InHospitalRoom = ltxtInHospitalRoom.MyText;
            patientInfoEventArgs.OutHospitalRoom = ltxtOutHospitalRoom.MyText;
            //patientInfoEventArgs.InHospitalDoctor = this.rtlkInHospitalDoctor.DisplayValue;
            //patientInfoEventArgs.OutHospitalDoctor = this.rtlkOutHospitalDoctor.DisplayValue;
            patientInfoEventArgs.DrugAllergy = this.ltxtDrugAllergy.MyText;
            patientInfoEventArgs.BloodType = this.cboBloodType.EditValue.ToString();
            patientInfoEventArgs.ICDOutDia1 = this.rtlkICDOutDia1.Text;
            patientInfoEventArgs.OutDiaName1 = this.ltxtOutDiaName1.MyText;
            patientInfoEventArgs.ICDOutDia2 = this.rtlkICDOutDia2.Text;
            patientInfoEventArgs.OutDiaName2 = this.ltxtOutDiaName2.MyText;
            patientInfoEventArgs.ICDOutDia3 = this.rtlkICDOutDia3.Text;
            patientInfoEventArgs.OutDiaName3 = this.ltxtOutDiaName3.MyText;
            patientInfoEventArgs.ICDOutDia4 = this.rtlkICDOutDia4.Text;
            patientInfoEventArgs.OutDiaName4 = this.ltxtOutDiaName4.MyText;
            patientInfoEventArgs.ICDSurgery1 = this.rtlkICDSurgery1.Text;
            patientInfoEventArgs.SurgeryName1 = this.ltxtSurgeryName1.MyText;
            patientInfoEventArgs.ICDSurgery2 = this.rtlkICDSurgery2.Text;
            patientInfoEventArgs.SurgeryName2 = this.ltxtSurgeryName2.MyText;
            patientInfoEventArgs.ICDSurgery3 = this.rtlkICDSurgery3.Text;
            patientInfoEventArgs.SurgeryName3 = this.ltxtSurgeryName3.MyText;
            patientInfoEventArgs.ICDSurgery4 = this.rtlkICDSurgery4.Text;
            patientInfoEventArgs.SurgeryName4 = this.ltxtSurgeryName4.MyText;
            patientInfoEventArgs.TreatResult1 = this.cboTreatResult1.EditValue.ToString();
            patientInfoEventArgs.TreatResult2 = this.cboTreatResult2.EditValue.ToString();
            patientInfoEventArgs.TreatResult3 = this.cboTreatResult3.EditValue.ToString();
            patientInfoEventArgs.TreatResult4 = this.cboTreatResult4.EditValue.ToString();
            patientInfoEventArgs.ICDBLZD1 = this.rtlkICDBLZD1.Text;
            patientInfoEventArgs.BLZDName1 = this.ltxtBLZDName1.MyText;
            patientInfoEventArgs.ICDBLZD2 = this.rtlkICDBLZD2.Text;
            patientInfoEventArgs.BLZDName2 = this.ltxtBLZDName2.MyText;
            patientInfoEventArgs.ICDYNGR1 = this.rtlkICDYNGR1.Text;
            patientInfoEventArgs.YNGRName1 = this.ltxtYNGRName1.MyText;
            patientInfoEventArgs.ICDYNGR2 = this.rtlkICDYNGR2.Text;
            patientInfoEventArgs.YNGRName2 = this.ltxtYNGRName2.MyText;
            patientInfoEventArgs.OutPatientOutDia = this.cboOutPatientOutHospitalDia.EditValue.ToString();
            patientInfoEventArgs.InOutHospitalDia = this.cboInOutHospitalDia.EditValue.ToString();
            patientInfoEventArgs.BeforeAfterSurgeryDia = this.cboBeforeAfterSurDia.EditValue.ToString();
            patientInfoEventArgs.RadiationAfterDia = this.cboRadAfterDia.EditValue.ToString();
            patientInfoEventArgs.ClinicalPathologyDia = this.cboClinicalPathDia.EditValue.ToString();
            patientInfoEventArgs.PatientAge = ltxtPatientAge.MyText;
            patientInfoEventArgs.PatientAddress = ltxtPatientAddress.MyText;
            patientInfoEventArgs.DeptDirector = rtlkDeptDirector.DisplayValue;
            patientInfoEventArgs.DeptDoctor = rtlkDeptDoctor.DisplayValue;
            patientInfoEventArgs.MainDoctor = rtlkMainDoctor.DisplayValue;
            patientInfoEventArgs.InHospitalDoctor = rtlkInHospitalDoctor.DisplayValue;
            patientInfoEventArgs.AdvanceStudyDoctor = rtlkAdvanceStudyDoctor.DisplayValue;
            patientInfoEventArgs.GraduatePracticeDoctor = rtlkGraduatePracticeDoctor.DisplayValue;
            patientInfoEventArgs.PracticeDoctor = rtlkPracticeDoctor.DisplayValue;
            patientInfoEventArgs.RecordQuality = cboRecodeQuality.EditValue.ToString();
            patientInfoEventArgs.QCDoctor = rtlkQCDoctor.DisplayValue;
            patientInfoEventArgs.QCNurse = rtlkQCNurse.DisplayValue;
            OnSavePatientInfo(sender, patientInfoEventArgs);
            if (!patientInfoEventArgs.IsReturn)
            {
                SetNull();
                patientInfoEventArgs.IsReturn = false;
            }
            
        }

        // 重置
        private void btnReset_Click(object sender, EventArgs e)
        {
            SetNull();
        }

        /// <summary>
        /// 置空
        /// </summary>
        private void SetNull()
        {
            this.ltxtRecordNo.MyText = "";
            this.ltxtPatientId.MyText = "";
            this.ltxtShelfNo.MyText = "";
            this.chkIsSpecial.CheckState = CheckState.Unchecked;
            this.ltxtPatientName.MyText = "";
            this.cboGender.Text = "";
            cboGender.EditValue = "";
            this.cboBirthday.Text = "";
            this.cboIsMarry.Text = "";
            cboIsMarry.EditValue = "";
            this.cboJob.Text = "";
            this.rtlkProvince.Text = "";
            this.rtlkProvince.DisplayText = "";
            rtlkProvince.DisplayValue = "";

            this.rtlkCity.Text = "";
            rtlkCity.DisplayText = "";
            rtlkCity.DisplayValue = "";

            this.ltxtIdCard.MyText = "";
            this.cboInHospitalType.Text = "";
            cboInHospitalType.EditValue = "";
            this.ltxtInHospitalTime.Text = "";

            this.rtlkInHospitalDept.Text = "";
            rtlkInHospitalDept.DisplayText = "";
            rtlkInHospitalDept.DisplayValue = "";

            this.rtlkOutHospitalDept.Text = "";
            rtlkOutHospitalDept.DisplayText = "";
            rtlkOutHospitalDept.DisplayValue = "";

            this.cboInHospitalDate.Text = "";
            this.cboOutHospitalDate.Text = "";
            //this.rtlkInHospitalDoctor.Text = "";
            //this.rtlkOutHospitalDoctor.Text = "";
            ltxtInHospitalRoom.MyText = "";
            ltxtOutHospitalRoom.MyText = "";
            this.ltxtDrugAllergy.MyText = "";
            this.cboBloodType.Text = "";
            cboBloodType.EditValue = "";
            //this.ltxtInHospitalDocId.MyText = "";
            //this.ltxtOutHospitalDocId.MyText = "";
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

            this.rtlkICDBLZD1.Text = "";
            rtlkICDBLZD1.DisplayText = "";
            rtlkICDBLZD1.DisplayValue = "";
            this.ltxtBLZDName1.MyText = "";

            this.rtlkICDBLZD2.Text = "";
            rtlkICDBLZD2.DisplayText = "";
            rtlkICDBLZD2.DisplayValue = "";
            this.ltxtBLZDName2.MyText = "";

            this.rtlkICDYNGR1.Text = "";
            rtlkICDYNGR1.DisplayText = "";
            rtlkICDYNGR1.DisplayValue = "";
            this.ltxtYNGRName1.MyText = "";

            this.rtlkICDYNGR2.Text = "";
            rtlkICDYNGR2.DisplayText = "";
            rtlkICDYNGR2.DisplayValue = "";
            this.ltxtYNGRName2.MyText = "";

            this.cboOutPatientOutHospitalDia.Text = "";
            cboOutPatientOutHospitalDia.EditValue = "";
            this.cboInOutHospitalDia.Text = "";
            cboInOutHospitalDia.EditValue = "";
            this.cboBeforeAfterSurDia.Text = "";
            cboBeforeAfterSurDia.EditValue = "";
            this.cboRadAfterDia.Text = "";
            cboRadAfterDia.EditValue = "";
            this.cboClinicalPathDia.Text = "";
            cboClinicalPathDia.EditValue = "";
            this.rtlkCountry.DisplayText = "中国";
            this.rtlkCountry.DisplayValue = "36";
            this.rtlkNation.DisplayText = "汉族";
            this.rtlkNation.DisplayValue = "75";
            ltxtPatientAge.MyText = "";
            ltxtPatientAddress.MyText = "";

            rtlkDeptDirector.Text = "";
            rtlkDeptDirector.DisplayText = "";
            rtlkDeptDirector.DisplayValue = "";
            rtlkDeptDoctor.Text = "";
            rtlkDeptDoctor.DisplayText = "";
            rtlkDeptDoctor.DisplayValue = "";
            rtlkMainDoctor.Text = "";
            rtlkMainDoctor.DisplayText = "";
            rtlkMainDoctor.DisplayValue = "";
            rtlkMainDoctor.DisplayValue = "";

            rtlkInHospitalDoctor.Text = "";
            rtlkInHospitalDoctor.DisplayText = "";
            rtlkInHospitalDoctor.DisplayValue = "";

            rtlkAdvanceStudyDoctor.Text = "";
            rtlkAdvanceStudyDoctor.DisplayText = "";
            rtlkAdvanceStudyDoctor.DisplayValue = "";

            rtlkGraduatePracticeDoctor.Text = "";
            rtlkGraduatePracticeDoctor.DisplayText = "";
            rtlkGraduatePracticeDoctor.DisplayValue = "";

            rtlkPracticeDoctor.Text = "";
            rtlkPracticeDoctor.DisplayText = "";
            rtlkPracticeDoctor.DisplayValue = "";

            cboRecodeQuality.Text = "";
            cboRecodeQuality.EditValue = "";

            rtlkQCDoctor.Text = "";
            rtlkQCDoctor.DisplayText = "";
            rtlkQCDoctor.DisplayValue = "";

            rtlkQCNurse.Text = "";
            rtlkQCNurse.DisplayText = "";
            rtlkQCNurse.DisplayValue = "";
        }

        /// <summary>
        /// 数据为空返回
        /// </summary>
        private bool NullReturn()
        {
            if (this.ltxtRecordNo.MyText == "")
            {
                MessageBox.Show("病案号不能为空！");
                return true;
            }
            if (this.ltxtPatientId.MyText == "")
            {
                MessageBox.Show("ID号不能为空！");
                return true;
            }
            if (this.ltxtShelfNo.MyText == "")
            {
                MessageBox.Show("货架号不能为空！");
                return true;
            }
            if (this.ltxtPatientName.MyText == "")
            {
                MessageBox.Show("病人姓名不能为空！");
                return true;
            }
            if (this.cboGender.Text == "")
            {
                MessageBox.Show("性别不能为空！");
                return true;
            }
            if (this.cboBirthday.Text == "")
            {
                MessageBox.Show("出生日期不能为空！");
                return true;
            }
            if (ltxtPatientAge.MyText == "")
            {
                MessageBox.Show("年龄不能为空！");
                return true;
            }
            if (rtlkProvince.Text == "" || rtlkCity.Text == "")
            {
                MessageBox.Show("出生地不能为空！");
                return true;
            }
            if (ltxtPatientAddress.MyText == "")
            {
                MessageBox.Show("户口地址不能为空！");
                return true;
            }
            //if (cboInHospitalType.Text == "")
            //{
            //    MessageBox.Show("入院方式不能为空！");
            //    return true;
            //}
            //if (ltxtInHospitalTime.MyText == "")
            //{
            //    MessageBox.Show("入院次数不能为空！");
            //    return true;
            //}
            if (cboInHospitalDate.Text == "")
            {
                MessageBox.Show("入院时间不能为空！");
                return true;
            }
            if (cboOutHospitalDate.Text == "")
            {
                MessageBox.Show("入院时间不能为空！");
                return true;
            }
            if (cboInHospitalDate.DateTime > cboOutHospitalDate.DateTime)
            {
                MessageBox.Show("入院时间不能早于出院时间！");
                return true;
            }
            if (rtlkInHospitalDept.Text == "")
            {
                MessageBox.Show("入院科别不能为空！");
                return true;
            }
            if (rtlkOutHospitalDept.Text == "")
            {
                MessageBox.Show("出院科别不能为空！");
                return true;
            }
            return false;
        }
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
                    case "cboIsMarry":
                        patientInfoEventArgs.ComBox2Type = "IS_MARRY";
                        break;
                    case "cboJob":
                        patientInfoEventArgs.ComBox2Type = "JOB";
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
                    case "cboBloodType":
                        patientInfoEventArgs.ComBox2Type = "BLOOD_TYPE";
                        break;
                    case "cboOutPatientOutHospitalDia":
                        patientInfoEventArgs.ComBox2Type = "DIAGNOSIS_RESULT";
                        break;
                    case "cboInOutHospitalDia":
                        patientInfoEventArgs.ComBox2Type = "DIAGNOSIS_RESULT";
                        break;
                    case "cboBeforeAfterSurDia":
                        patientInfoEventArgs.ComBox2Type = "DIAGNOSIS_RESULT";
                        break;
                    case "cboClinicalPathDia":
                        patientInfoEventArgs.ComBox2Type = "DIAGNOSIS_RESULT";
                        break;
                    case "cboRadAfterDia":
                        patientInfoEventArgs.ComBox2Type = "DIAGNOSIS_RESULT";
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

        #region 事件
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnInit;

        /// <summary>
        /// 保存病人信息
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnSavePatientInfo;

        /// <summary>
        /// 根据市筛选省
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnProvinceTextChanged;

        ///// <summary>
        ///// 根据入院部门查找医生
        ///// </summary>
        //public event EventHandler<Views.PatientInfoInputEventArgs> OnSearchInDoctorByDept;

        ///// <summary>
        ///// 根据出院部门查找医生
        ///// </summary>
        //public event EventHandler<Views.PatientInfoInputEventArgs> OnSearchOutDoctorByDept;

        /// <summary>
        /// 查询库中是否存在相同病案号和入院次数
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnCheckIsExistSameRecordNoAndInHospitalTime;

        /// <summary>
        /// 焦点聚焦ComBox2后按下数字快捷选择键
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnKeyPressComBox2;

        #region 模糊查询事件
        /// <summary>
        /// 省模糊查询事件
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnProviceSearch;

        /// <summary>
        /// 市模糊查询
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnCitySearch;

        /// <summary>
        /// 民族模糊查询
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnNationSearch;

        /// <summary>
        /// 国家模糊查询
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnCountrySearch;

        /// <summary>
        /// 入院科室模糊查询
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnInHospitalDeptSearch;

        /// <summary>
        /// 出院科室模糊查询
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnOutHospitalDeptSearch;

       

        ///// <summary>
        ///// 出院医生模糊查询
        ///// </summary>
        //public event EventHandler<Views.PatientInfoInputEventArgs> OnOutHospitalDocSearch;

        /// <summary>
        /// ICD编码（出院诊断1）事件
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnICDOutDia1Search;

        /// <summary>
        /// ICD编码（出院诊断2）事件
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnICDOutDia2Search;

        /// <summary>
        /// ICD编码（出院诊断3）事件
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnICDOutDia3Search;

        /// <summary>
        /// ICD编码（出院诊断4）事件
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnICDOutDia4Search;

        /// <summary>
        /// ICD编码（手术名称1）事件
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnICDSurgery1Search;

        /// <summary>
        /// ICD编码（手术名称2）事件
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnICDSurgery2Search;

        /// <summary>
        /// ICD编码（手术名称3）事件
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnICDSurgery3Search;

        /// <summary>
        /// ICD编码（手术名称4）事件
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnICDSurgery4Search;

        /// <summary>
        /// ICD编码（病理诊断1）事件
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnICDBLZD1Search;

        /// <summary>
        /// ICD编码（病理诊断2）事件
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnICDBLZD2Search;

        /// <summary>
        /// ICD编码（院内感染1）事件
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnICDYNGR1Search;

        /// <summary>
        /// ICD编码（院内感染2）事件
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnICDYNGR2Search;

        /// <summary>
        /// 科主任模糊查询
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnDeptDirectorBySearch;

        /// <summary>
        /// 主（副）任医师模糊查询
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnDeptDoctorBySearch;

        /// <summary>
        ///主治医生医师模糊查询
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnMainDoctorBySearch;


        /// <summary>
        /// 入院医生模糊查询
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnInHospitalDoctorSearch;

        /// <summary>
        /// 进修医生模糊查询
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnAdvanceStudyDoctorBySearch;

        /// <summary>
        /// 研究生医生模糊查询
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnGraduatePracticeDoctor;

        /// <summary>
        /// 实习医生模糊查询
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnPracticeDoctorBySearch;

        /// <summary>
        /// 质控医师模糊查询
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnQCDoctorBySearch;

        /// <summary>
        /// 质控护士模糊查询
        /// </summary>
        public event EventHandler<Views.PatientInfoInputEventArgs> OnQCNurseBySearch;
        #endregion

        #endregion


        private void cboInHospitalDate_KeyDown(object sender, KeyEventArgs e)
        {
          
                SendKeys.Send("{right}");
                return;
        }

     
        
    }
}

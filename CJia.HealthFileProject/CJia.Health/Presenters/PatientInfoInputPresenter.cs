using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Presenters
{
    public class PatientInfoInputPresenter : CJia.Health.Tools.Presenter<Models.PatientInfoInputModel, Views.IPatientInfoInputView>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public PatientInfoInputPresenter(Views.IPatientInfoInputView view)
            : base(view)
        {
            this.View.OnInit += View_OnInit;
            this.View.OnSavePatientInfo += View_OnSavePatientInfo;
            this.View.OnProvinceTextChanged += View_OnProvinceTextChanged;
            this.View.OnProviceSearch += View_OnProviceSearch;
            this.View.OnICDOutDia1Search += View_OnICDOutDia1Search;
            this.View.OnICDOutDia2Search += View_OnICDOutDia2Search;
            this.View.OnICDOutDia3Search += View_OnICDOutDia3Search;
            this.View.OnICDOutDia4Search += View_OnICDOutDia4Search;
            this.View.OnICDSurgery1Search += View_OnICDSurgery1Search;
            this.View.OnICDSurgery2Search += View_OnICDSurgery2Search;
            this.View.OnICDSurgery3Search += View_OnICDSurgery3Search;
            this.View.OnICDSurgery4Search += View_OnICDSurgery4Search;
            this.View.OnICDBLZD1Search += View_OnICDBLZD1Search;
            this.View.OnICDBLZD2Search += View_OnICDBLZD2Search;
            this.View.OnICDYNGR1Search += View_OnICDYNGR1Search;
            this.View.OnICDYNGR2Search += View_OnICDYNGR2Search;
            this.View.OnNationSearch += View_OnNationSearch;
            this.View.OnCountrySearch += View_OnCountrySearch;
            //this.View.OnSearchInDoctorByDept += View_OnSearchInDoctorByDept;
            //this.View.OnSearchOutDoctorByDept += View_OnSearchOutDoctorByDept;
            this.View.OnInHospitalDeptSearch += View_OnInHospitalDeptSearch;
            this.View.OnOutHospitalDeptSearch += View_OnOutHospitalDeptSearch;
            //this.View.OnInHospitalDoctorSearch += View_OnInHospitalDocSearch;
            //this.View.OnOutHospitalDocSearch += View_OnOutHospitalDocSearch;
            this.View.OnCitySearch += View_OnCitySearch;
            this.View.OnCheckIsExistSameRecordNoAndInHospitalTime += View_OnCheckIsExistSameRecordNoAndInHospitalTime;

            View.OnDeptDirectorBySearch += View_OnDeptDirectorBySearch;
            View.OnDeptDoctorBySearch += View_OnDeptDoctorBySearch;
            View.OnMainDoctorBySearch += View_OnMainDoctorBySearch;
            View.OnInHospitalDoctorSearch += View_OnInHospitalDoctorSearch;
            View.OnAdvanceStudyDoctorBySearch += View_OnAdvanceStudyDoctorBySearch;
            View.OnGraduatePracticeDoctor += View_OnGraduatePracticeDoctor;
            View.OnPracticeDoctorBySearch += View_OnPracticeDoctorBySearch;
            View.OnQCDoctorBySearch += View_OnQCDoctorBySearch;
            View.OnQCNurseBySearch += View_OnQCNurseBySearch;
            View.OnKeyPressComBox2 += View_OnKeyPressComBox2;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInit(object sender, Views.PatientInfoInputEventArgs e)
        {
            BindGender();
            BindIsMarry();
            BindJob();
            BindProvince();
            //BindCity();
            BindNation();
            BindCountry();
            BindInHospitalType();
            BindDept();
            BindDoctor();
            BindICDCode();
            BindTreatResult();
            BindBloodType();
            BindDiagnosisResult();
            BindRecordQuality();
        }

        #region 绑定下拉选择框
        /// <summary>
        /// 绑定性别
        /// </summary>
        void BindGender()
        {
            this.View.ExeBindGender(this.Model.QueryGender());
        }

        /// <summary>
        /// 绑定婚姻状况
        /// </summary>
        void BindIsMarry()
        {
            this.View.ExeBindIsMarry(this.Model.QueryIsMarry());
        }

        /// <summary>
        /// 绑定职业
        /// </summary>
        void BindJob()
        {
            this.View.ExeBindJob(this.Model.QueryJob());
        }

        /// <summary>
        /// 绑定省
        /// </summary>
        void BindProvince()
        {
            this.View.ExeBindProvince(this.Model.QueryProvince());
        }

        /// <summary>
        /// 绑定民族
        /// </summary>
        void BindNation()
        {
            this.View.ExeBindNation(this.Model.QueryNation());
        }

        /// <summary>
        /// 绑定国籍
        /// </summary>
        void BindCountry()
        {
            this.View.ExeBindCountry(this.Model.QueryCountry());
        }

        /// <summary>
        /// 绑定入院方式
        /// </summary>
        void BindInHospitalType()
        {
            this.View.ExeBindInHospitalType(this.Model.QueryInHospitalType());
        }

        /// <summary>
        /// 绑定入院科室
        /// </summary>
        void BindDept()
        {
            this.View.ExeBindDept(this.Model.QueryDept());
        }

        /// <summary>
        /// 绑定ICD编码
        /// </summary>
        void BindICDCode()
        {
            this.View.ExeBindICDCode(this.Model.QueryICDCode());
        }

        /// <summary>
        /// 绑定治疗结果
        /// </summary>
        void BindTreatResult()
        {
            this.View.ExeBindTreatResult(this.Model.QueryTreatResult());
        }

        /// <summary>
        /// 绑定血型
        /// </summary>
        void BindBloodType()
        {
            this.View.ExeBindBloodType(this.Model.QueryBloodType());
        }

        /// <summary>
        /// 诊断结果
        /// </summary>
        void BindDiagnosisResult()
        {
            this.View.ExeBindDiagnosisResult(this.Model.QueryDiagnosisResult());
        }

        /// <summary>
        /// 绑定医生
        /// </summary>
        void BindDoctor()
        {
            this.View.ExeBindDoctor(Model.QueryDoctor());
        }

        void BindRecordQuality()
        {
            this.View.ExeBindRecordQuality(Model.QueryRecordQuality());
        }
        #endregion

        /// <summary>
        /// 插入病人表基本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnSavePatientInfo(object sender, Views.PatientInfoInputEventArgs e)
        {
            List<object> sqlParams= new List<object>();

            DataTable dtRecord = Model.QueryIsExistRecordNo(e.RecordNo, e.InHospitalTime);
            // 存在相同病案号，则为修改状态
            if (dtRecord.Rows.Count > 0)
            {
                Message.Show("库中已存在相同【病案号】+【住院次数】！");
            //    if (dtRecord.Rows[0]["RECORDNO"].ToString() == e.RecordNo)
                //{
                //    Message.Show("库中存在相同病案号，请修改！");
                    e.IsReturn = true;
                    return;
                //}
                //if (Message.ShowQuery("确定要修改【" + e.PatientName + "】信息？") == Message.Result.Ok)
                //{
                //    #region 【修改参数】
                //    sqlParams.Add(e.PatientId);
                //    sqlParams.Add(e.PatientName);
                //    sqlParams.Add(e.ShelfNo);
                //    sqlParams.Add(e.IsSpecial);
                //    sqlParams.Add(e.Gender);
                //    sqlParams.Add(e.BirthDate);
                //    sqlParams.Add(e.IsMarry);
                //    sqlParams.Add(e.Job);
                //    sqlParams.Add(e.Province);
                //    sqlParams.Add(e.City);
                //    sqlParams.Add(e.Nation);
                //    sqlParams.Add(e.Country);
                //    sqlParams.Add(e.IDCard);
                //    sqlParams.Add(e.InHospitalType);
                //    sqlParams.Add(e.InHospitalTime);
                //    sqlParams.Add(e.InHospitalDate);
                //    sqlParams.Add(e.OutHospitalDate);
                //    sqlParams.Add(e.InHospitalDept);
                //    sqlParams.Add(e.OutHospitalDept);
                //    //sqlParams.Add(e.InHospitalDoctor);
                //    //sqlParams.Add(e.OutHospitalDoctor);
                //    sqlParams.Add(e.InHospitalRoom);
                //    sqlParams.Add(e.OutHospitalRoom);
                //    sqlParams.Add(e.DrugAllergy);
                //    sqlParams.Add(e.BloodType);
                //    sqlParams.Add(e.ICDOutDia1);
                //    sqlParams.Add(e.OutDiaName1);
                //    sqlParams.Add(e.ICDOutDia2);
                //    sqlParams.Add(e.OutDiaName2);
                //    sqlParams.Add(e.ICDOutDia3);
                //    sqlParams.Add(e.OutDiaName3);
                //    sqlParams.Add(e.ICDOutDia4);
                //    sqlParams.Add(e.OutDiaName4);
                //    sqlParams.Add(e.ICDSurgery1);
                //    sqlParams.Add(e.SurgeryName1);
                //    sqlParams.Add(e.ICDSurgery2);
                //    sqlParams.Add(e.SurgeryName2);
                //    sqlParams.Add(e.ICDSurgery3);
                //    sqlParams.Add(e.SurgeryName3);
                //    sqlParams.Add(e.ICDSurgery4);
                //    sqlParams.Add(e.SurgeryName4);
                //    sqlParams.Add(e.TreatResult1);
                //    sqlParams.Add(e.TreatResult2);
                //    sqlParams.Add(e.TreatResult3);
                //    sqlParams.Add(e.TreatResult4);
                //    sqlParams.Add(e.ICDBLZD1);
                //    sqlParams.Add(e.BLZDName1);
                //    sqlParams.Add(e.ICDBLZD2);
                //    sqlParams.Add(e.BLZDName2);
                //    sqlParams.Add(e.ICDYNGR1);
                //    sqlParams.Add(e.YNGRName1);
                //    sqlParams.Add(e.ICDYNGR2);
                //    sqlParams.Add(e.YNGRName2);
                //    sqlParams.Add(e.OutPatientOutDia);
                //    sqlParams.Add(e.InOutHospitalDia);
                //    sqlParams.Add(e.BeforeAfterSurgeryDia);
                //    sqlParams.Add(e.RadiationAfterDia);
                //    sqlParams.Add(e.ClinicalPathologyDia);
                //    sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));

                //    sqlParams.Add(e.DeptDirector);
                //    sqlParams.Add(e.DeptDoctor);
                //    sqlParams.Add(e.MainDoctor);
                //    sqlParams.Add(e.InHospitalDoctor);
                //    sqlParams.Add(e.AdvanceStudyDoctor);
                //    sqlParams.Add(e.GraduatePracticeDoctor);
                //    sqlParams.Add(e.PracticeDoctor);
                //    sqlParams.Add(e.RecordQuality);
                //    sqlParams.Add(e.QCDoctor);
                //    sqlParams.Add(e.QCNurse);
                //    sqlParams.Add(e.RecordNo);
                //    #endregion
                //    Model.UpdatePatientInfo(sqlParams);
                //}
            }
            //// 否则不存在所输病案号为插入
            //else
            //{
                if (Message.ShowQuery("确定要保存【" + e.PatientName + "】信息？") == Message.Result.Ok)
                {
                    #region 【插入参数】
                    sqlParams.Add(e.PatientId);
                    sqlParams.Add(e.PatientName);
                    sqlParams.Add(e.RecordNo);
                    sqlParams.Add(e.ShelfNo);
                    sqlParams.Add(e.IsSpecial);
                    sqlParams.Add(e.Gender);
                    sqlParams.Add(e.BirthDate);
                    sqlParams.Add(e.IsMarry);
                    sqlParams.Add(e.Job);
                    sqlParams.Add(e.Province);
                    sqlParams.Add(e.City);
                    sqlParams.Add(e.Nation);
                    sqlParams.Add(e.Country);
                    sqlParams.Add(e.IDCard);
                    sqlParams.Add(e.InHospitalType);
                    sqlParams.Add(e.InHospitalTime);
                    sqlParams.Add(e.InHospitalDate);
                    sqlParams.Add(e.OutHospitalDate);
                    sqlParams.Add(e.InHospitalDept);
                    sqlParams.Add(e.OutHospitalDept);
                    //sqlParams.Add(e.InHospitalDoctor);
                    //sqlParams.Add(e.OutHospitalDoctor);
                    sqlParams.Add(e.InHospitalRoom);
                    sqlParams.Add(e.OutHospitalRoom);
                    sqlParams.Add(e.DrugAllergy);
                    sqlParams.Add(e.BloodType);
                    sqlParams.Add(e.ICDOutDia1);
                    sqlParams.Add(e.OutDiaName1);
                    sqlParams.Add(e.ICDOutDia2);
                    sqlParams.Add(e.OutDiaName2);
                    sqlParams.Add(e.ICDOutDia3);
                    sqlParams.Add(e.OutDiaName3);
                    sqlParams.Add(e.ICDOutDia4);
                    sqlParams.Add(e.OutDiaName4);
                    sqlParams.Add(e.ICDSurgery1);
                    sqlParams.Add(e.SurgeryName1);
                    sqlParams.Add(e.ICDSurgery2);
                    sqlParams.Add(e.SurgeryName2);
                    sqlParams.Add(e.ICDSurgery3);
                    sqlParams.Add(e.SurgeryName3);
                    sqlParams.Add(e.ICDSurgery4);
                    sqlParams.Add(e.SurgeryName4);
                    sqlParams.Add(e.TreatResult1);
                    sqlParams.Add(e.TreatResult2);
                    sqlParams.Add(e.TreatResult3);
                    sqlParams.Add(e.TreatResult4);
                    sqlParams.Add(e.ICDBLZD1);
                    sqlParams.Add(e.BLZDName1);
                    sqlParams.Add(e.ICDBLZD2);
                    sqlParams.Add(e.BLZDName2);
                    sqlParams.Add(e.ICDYNGR1);
                    sqlParams.Add(e.YNGRName1);
                    sqlParams.Add(e.ICDYNGR2);
                    sqlParams.Add(e.YNGRName2);
                    sqlParams.Add(e.OutPatientOutDia);
                    sqlParams.Add(e.InOutHospitalDia);
                    sqlParams.Add(e.BeforeAfterSurgeryDia);
                    sqlParams.Add(e.RadiationAfterDia);
                    sqlParams.Add(e.ClinicalPathologyDia);
                    sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
                    sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
                    sqlParams.Add(User.UserData.Rows[0]["user_name"].ToString());
                    sqlParams.Add(e.PatientAge);
                    sqlParams.Add(e.PatientAddress);
                    sqlParams.Add(e.DeptDirector);
                    sqlParams.Add(e.DeptDoctor);
                    sqlParams.Add(e.MainDoctor);
                    sqlParams.Add(e.InHospitalDoctor);
                    sqlParams.Add(e.AdvanceStudyDoctor);
                    sqlParams.Add(e.GraduatePracticeDoctor);
                    sqlParams.Add(e.PracticeDoctor);
                    sqlParams.Add(e.RecordQuality);
                    sqlParams.Add(e.QCDoctor);
                    sqlParams.Add(e.QCNurse);
                    #endregion
                    Model.InsertPatientInfo(sqlParams);
                //}
                }
        }

        /// <summary>
        /// 根据省筛选绑定市
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnProvinceTextChanged(object sender, Views.PatientInfoInputEventArgs e)
        {
            DataTable dtCity = Model.QueryCityByProvince(e.SelectedProvinceId);
            this.View.ExeBindCity(dtCity);
            e.TableCity = dtCity;
        }

        #region 模糊查询
        /// <summary>
        /// 根据省模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnProviceSearch(object sender, Views.PatientInfoInputEventArgs e)
        {
            View.ExeBindProvince(Model.QueryProvinceBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 市模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnCitySearch(object sender, Views.PatientInfoInputEventArgs e)
        {
            DataView dataView = e.TableFuzzySearch.DefaultView;
            if (e.StrFuzzySearch != "")
            {
                dataView.RowFilter = ("  PINYIN LIKE '%" + e.StrFuzzySearch + "%' OR AREA_NAME LIKE '%" + e.StrFuzzySearch + "%' ");
            }
            DataTable dt = dataView.ToTable();
            View.ExeBindCity(dt);
        }

        /// <summary>
        /// 民族模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnNationSearch(object sender, Views.PatientInfoInputEventArgs e)
        {
            this.View.ExeBindNation(Model.QueryNationSearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 国家模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnCountrySearch(object sender, Views.PatientInfoInputEventArgs e)
        {
            this.View.ExeBindCountry(Model.QueryCountrySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 入院部门模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInHospitalDeptSearch(object sender, Views.PatientInfoInputEventArgs e)
        {
            this.View.ExeInDept(Model.QueryDeptBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 出院部门模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnOutHospitalDeptSearch(object sender, Views.PatientInfoInputEventArgs e)
        {
            this.View.ExeOutDept(Model.QueryDeptBySearch(e.StrFuzzySearch));
        }

        ///// <summary>
        ///// 入院医生模糊查询
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void View_OnInHospitalDocSearch(object sender, Views.PatientInfoInputEventArgs e)
        //{
        //    //this.View.ExeInDoctor(Model.QueryDoctorBySearch(e.StrFuzzySearch));
        //    DataView dataView = e.TableFuzzySearch.DefaultView;
        //    dataView.RowFilter = ("  DOCTOR_NO LIKE '%" + e.StrFuzzySearch + "%' OR DOCTOR_NAME LIKE '%" + e.StrFuzzySearch + "%' ");
        //    DataTable dt = dataView.Table;
        //    View.ExeInDoctor(dt);
        //}

        ///// <summary>
        ///// 出院医生模糊查询
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void View_OnOutHospitalDocSearch(object sender, Views.PatientInfoInputEventArgs e)
        //{
        //    //this.View.ExeOutDoctor(Model.QueryDoctorBySearch(e.StrFuzzySearch));
        //    DataView dataView = e.TableFuzzySearch.DefaultView;
        //    dataView.RowFilter = ("  DOCTOR_NO LIKE '%" + e.StrFuzzySearch + "%' OR DOCTOR_NAME LIKE '%" + e.StrFuzzySearch + "%' ");
        //    DataTable dt = dataView.Table;
        //    View.ExeOutDoctor(dt);
        //}

        ///// <summary>
        ///// 根据入院部门查询医生
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void View_OnSearchInDoctorByDept(object sender, Views.PatientInfoInputEventArgs e)
        //{
        //    this.View.ExeSearchInDoctorByDept(Model.QueryDoctor(e.StrFuzzySearch));
        //}

        ///// <summary>
        ///// 根据出院部门查询医生
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void View_OnSearchOutDoctorByDept(object sender, Views.PatientInfoInputEventArgs e)
        //{
        //    this.View.ExeSearchOutDoctorByDept(Model.QueryDoctor(e.StrFuzzySearch));
        //}

        /// <summary>
        /// 模糊查询ICD编码（出院诊断1）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDOutDia1Search(object sender, Views.PatientInfoInputEventArgs e)
        {
            this.View.ExeICDOutDia1(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 模糊查询ICD编码（出院诊断2）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDOutDia2Search(object sender, Views.PatientInfoInputEventArgs e)
        {
            this.View.ExeICDOutDia2(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 模糊查询ICD编码（出院诊断3）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDOutDia3Search(object sender, Views.PatientInfoInputEventArgs e)
        {
            this.View.ExeICDOutDia3(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 模糊查询ICD编码（出院诊断4）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDOutDia4Search(object sender, Views.PatientInfoInputEventArgs e)
        {
            this.View.ExeICDOutDia4(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 模糊查询ICD编码(手术名称1）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDSurgery1Search(object sender, Views.PatientInfoInputEventArgs e)
        {
            this.View.ExeICDSurgery1(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        ///  模糊查询ICD编码(手术名称2）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDSurgery2Search(object sender, Views.PatientInfoInputEventArgs e)
        {
            this.View.ExeICDSurgery2(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        ///  模糊查询ICD编码(手术名称3）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDSurgery3Search(object sender, Views.PatientInfoInputEventArgs e)
        {
            this.View.ExeICDSurgery3(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        ///  模糊查询ICD编码(手术名称4）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDSurgery4Search(object sender, Views.PatientInfoInputEventArgs e)
        {
            this.View.ExeICDSurgery4(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 模糊查询ICD编码（病理诊断1）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDBLZD1Search(object sender, Views.PatientInfoInputEventArgs e)
        {
            this.View.ExeICDBLZD1(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 模糊查询ICD编码（病理诊断2）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDBLZD2Search(object sender, Views.PatientInfoInputEventArgs e)
        {
            this.View.ExeICDBLZD2(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 模糊查询ICD编码（院内感染1）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDYNGR1Search(object sender, Views.PatientInfoInputEventArgs e)
        {
            this.View.ExeICDYNGR1(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 模糊查询ICD编码（院内感染2）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDYNGR2Search(object sender, Views.PatientInfoInputEventArgs e)
        {
            this.View.ExeICDYNGR2(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 医生模糊查询
        /// </summary>
        /// <param name="e"></param>
        DataTable BindDoctorBySearch(Views.PatientInfoInputEventArgs e)
        {
           return Model.QueryDoctorBySearch(e.StrFuzzySearch);
        }
        /// <summary>
        /// 科主任模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnDeptDirectorBySearch(object sender, Views.PatientInfoInputEventArgs e)
        {
            View.ExeBindDeptDirector(BindDoctorBySearch(e));
        }

        /// <summary>
        /// 主（副）任医师模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnDeptDoctorBySearch(object sender, Views.PatientInfoInputEventArgs e)
        {
            View.ExeBindDeptDoctor(BindDoctorBySearch(e));
        }

        /// <summary>
        /// 主治医生模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnMainDoctorBySearch(object sender, Views.PatientInfoInputEventArgs e)
        {
            View.ExeBindMainDoctor(BindDoctorBySearch(e));
        }

        /// <summary>
        /// 住院医师模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInHospitalDoctorSearch(object sender, Views.PatientInfoInputEventArgs e)
        {
            View.ExeBindInHospitalDoctor(BindDoctorBySearch(e));
        }

        /// <summary>
        /// 进修医师模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnAdvanceStudyDoctorBySearch(object sender, Views.PatientInfoInputEventArgs e)
        {
            View.ExeBindAdvanceStudyDoctor(BindDoctorBySearch(e));
        }

        /// <summary>
        /// 研究生医生模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnGraduatePracticeDoctor(object sender, Views.PatientInfoInputEventArgs e)
        {
            View.ExeBindGraduatePracticeDoctor(BindDoctorBySearch(e));
        }

        /// <summary>
        /// 实习医生模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnPracticeDoctorBySearch(object sender, Views.PatientInfoInputEventArgs e)
        {
            View.ExeBindPracticeDoctor(BindDoctorBySearch(e));
        }

        /// <summary>
        /// 质控医生模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnQCDoctorBySearch(object sender, Views.PatientInfoInputEventArgs e)
        {
            View.ExeBindQCDoctor(BindDoctorBySearch(e));
        }

        /// <summary>
        /// 质控护士模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnQCNurseBySearch(object sender, Views.PatientInfoInputEventArgs e)
        {
            View.ExeBindQCNurse(BindDoctorBySearch(e));
        }
        #endregion

        /// <summary>
        /// 焦点离开病案号时查询库中是否存在相同病案号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnCheckIsExistSameRecordNoAndInHospitalTime(object sender, Views.PatientInfoInputEventArgs e)
        {
            e.TablePatientInfoByRecordNo = null;
            DataTable dtRecordNo = Model.QueryIsExistRecordNo(e.RecordNo,e.InHospitalTime);
            if (dtRecordNo.Rows.Count > 0)
            {
                e.TablePatientInfoByRecordNo = dtRecordNo;
            }
        }

        /// <summary>
        /// 焦点聚焦ComBox2后按下数字快捷选择键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnKeyPressComBox2(object sender, Views.PatientInfoInputEventArgs e)
        {
            e.TableCombox2 = Model.QueryKeyPressComBox2(e.ComBox2Type);
        }
    }
}

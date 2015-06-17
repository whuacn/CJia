using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Presenters
{
    public class NewPatientInfoInputPresenter : CJia.Health.Tools.Presenter<Models.PatientInfoInputModel, Views.INewPatientInfoInputView>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public NewPatientInfoInputPresenter(Views.INewPatientInfoInputView view)
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
            this.View.OnInHospitalDeptSearch += View_OnInHospitalDeptSearch;
            this.View.OnOutHospitalDeptSearch += View_OnOutHospitalDeptSearch;
            this.View.OnCitySearch += View_OnCitySearch;
            this.View.OnCheckIsExistSameRecordNoAndInHospitalTime += View_OnCheckIsExistSameRecordNoAndInHospitalTime;
            View.OnKeyPressComBox2 += View_OnKeyPressComBox2;
        }

        #region 【绑定下拉选择框】
        /// <summary>
        /// 绑定性别
        /// </summary>
        void BindGender()
        {
            this.View.ExeBindGender(this.Model.QueryGender());
        }

        /// <summary>
        /// 绑定省
        /// </summary>
        void BindProvince()
        {
            this.View.ExeBindProvince(this.Model.QueryProvince());
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
        #endregion

        #region【响应事件】

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInit(object sender, Views.NewPatientInfoInputEventArgs e)
        {
            BindGender();
            BindProvince();
            BindDept();
            BindICDCode();
            BindTreatResult();
        }

        /// <summary>
        /// 插入病人表基本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void View_OnSavePatientInfo(object sender, Views.NewPatientInfoInputEventArgs e)
        {
            List<object> sqlParams = new List<object>();
            DataTable dtRecord = Model.QueryIsExistRecordNo(e.RecordNo, e.InHospitalTime);
            // 存在相同病案号，则为修改状态
            if (dtRecord.Rows.Count > 0)
            {
                Message.Show("库中已存在相同【病案号】+【住院次数】！");
                e.IsReturn = true;
                return;
            }
            if (Message.ShowQuery("确定要保存【" + e.PatientName + "】信息？") == Message.Result.Ok)
            {
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
                if (e.SurgeryDate1 == null)
                {
                    sqlParams.Add(DBNull.Value);
                }
                else
                {
                    sqlParams.Add(e.SurgeryDate1);
                }
                if (e.SurgeryDate2 == null)
                {
                    sqlParams.Add(DBNull.Value);
                }
                else
                {
                    sqlParams.Add(e.SurgeryDate2);
                }
                if (e.SurgeryDate3 == null)
                {
                    sqlParams.Add(DBNull.Value);
                }
                else
                {
                    sqlParams.Add(e.SurgeryDate3);
                }
                if (e.SurgeryDate4 == null)
                {
                    sqlParams.Add(DBNull.Value);
                }
                else
                {
                    sqlParams.Add(e.SurgeryDate4);
                }
                sqlParams.Add(e.RecordNo + "_" + e.InHospitalTime);
                Model.InsertPatientInfo(sqlParams);
                e.IsReturn = false;
                try
                {
                    string printer = Tools.ConfigHelper.GetAppStrings("Printer");
                    PrintHelper print = new PrintHelper();
                    print.PrintRecord(printer, false, e.RecordNo, e.PatientName, e.InHospitalTime.ToString());
                }
                catch
                {
                    View.ShowWarning("条码打印错误");
                }
            }
            // 如果取消保存
            else
            {
                e.IsReturn = true;
            }
        }

        /// <summary>
        /// 根据省筛选绑定市
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnProvinceTextChanged(object sender, Views.NewPatientInfoInputEventArgs e)
        {
            DataTable dtCity = Model.QueryCityByProvince(e.SelectedProvinceId);
            this.View.ExeBindCity(dtCity);
            e.TableCity = dtCity;
        }

        /// <summary>
        /// 焦点离开病案号时查询库中是否存在相同病案号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnCheckIsExistSameRecordNoAndInHospitalTime(object sender, Views.NewPatientInfoInputEventArgs e)
        {
            e.TablePatientInfoByRecordNo = null;
            DataTable dtRecordNo = Model.QueryIsExistRecordNo(e.RecordNo, e.InHospitalTime);
            if (dtRecordNo.Rows.Count > 0)
            {
                e.TablePatientInfoByRecordNo = dtRecordNo;
            }

            //e.TablePatientFromInterface = QueryPatientInfoFromInterface(sender,e);
        }

        /// <summary>
        /// 根据病案号和入院次数从接口中查询病人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        DataTable QueryPatientInfoFromInterface(object sender, Views.NewPatientInfoInputEventArgs e)
        {
            DataTable dtPatient = Model.QueryPatientInfoFromInterface(e.RecordNo, e.InHospitalTime);
            return dtPatient;
        }

        /// <summary>
        /// 焦点聚焦ComBox2后按下数字快捷选择键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnKeyPressComBox2(object sender, Views.NewPatientInfoInputEventArgs e)
        {
            e.TableCombox2 = Model.QueryKeyPressComBox2(e.ComBox2Type);
        }
        #endregion

        #region 【模糊查询】
        /// <summary>
        /// 根据省模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnProviceSearch(object sender, Views.NewPatientInfoInputEventArgs e)
        {
            View.ExeBindProvince(Model.QueryProvinceBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 市模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnCitySearch(object sender, Views.NewPatientInfoInputEventArgs e)
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
        /// 入院部门模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInHospitalDeptSearch(object sender, Views.NewPatientInfoInputEventArgs e)
        {
            this.View.ExeInDept(Model.QueryDeptBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 出院部门模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnOutHospitalDeptSearch(object sender, Views.NewPatientInfoInputEventArgs e)
        {
            this.View.ExeOutDept(Model.QueryDeptBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 模糊查询ICD编码（出院诊断1）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDOutDia1Search(object sender, Views.NewPatientInfoInputEventArgs e)
        {
            this.View.ExeICDOutDia1(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 模糊查询ICD编码（出院诊断2）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDOutDia2Search(object sender, Views.NewPatientInfoInputEventArgs e)
        {
            this.View.ExeICDOutDia2(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 模糊查询ICD编码（出院诊断3）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDOutDia3Search(object sender, Views.NewPatientInfoInputEventArgs e)
        {
            this.View.ExeICDOutDia3(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 模糊查询ICD编码（出院诊断4）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDOutDia4Search(object sender, Views.NewPatientInfoInputEventArgs e)
        {
            this.View.ExeICDOutDia4(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        /// 模糊查询ICD编码(手术名称1）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDSurgery1Search(object sender, Views.NewPatientInfoInputEventArgs e)
        {
            this.View.ExeICDSurgery1(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        ///  模糊查询ICD编码(手术名称2）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDSurgery2Search(object sender, Views.NewPatientInfoInputEventArgs e)
        {
            this.View.ExeICDSurgery2(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        ///  模糊查询ICD编码(手术名称3）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDSurgery3Search(object sender, Views.NewPatientInfoInputEventArgs e)
        {
            this.View.ExeICDSurgery3(Model.QueryICDBySearch(e.StrFuzzySearch));
        }

        /// <summary>
        ///  模糊查询ICD编码(手术名称4）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnICDSurgery4Search(object sender, Views.NewPatientInfoInputEventArgs e)
        {
            this.View.ExeICDSurgery4(Model.QueryICDBySearch(e.StrFuzzySearch));
        }
        #endregion
    }
}

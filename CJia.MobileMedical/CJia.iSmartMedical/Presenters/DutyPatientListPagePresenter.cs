using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJia.iSmartMedical.Data;

namespace CJia.iSmartMedical.Presenters
{
    public class DutyPatientListPagePresenter : Presenter<Models.MyPatientsPageModel, Views.IDutyPatientListPageView>
    {
        public DutyPatientListPagePresenter(Views.IDutyPatientListPageView view)
            : base(view)
        {
            View.OnShowDutyPatientList += View_OnShowDutyPatientList;
            View.OnAddDutyPatientList += View_OnAddDutyPatientList;
            View.OnQueryDutyIllfield += View_OnQueryDutyIllfield;
            View.OnQueryLeavehosPatient += View_OnQueryLeavehosPatient;
        }

        async void View_OnQueryLeavehosPatient(object sender, EventArgs e)
        {
            List<Data.Patient> patientList = await Model.QueryLeavehosPatient(iCommon.DeviceID);
            View.ExeShowDutyPatientList(patientList);
        }

        async void View_OnQueryDutyIllfield(object sender, EventArgs e)
        {
            List<Data.DoctorIllfield> dataList = await Model.QueryDoctorDutyIllfield(iCommon.DoctorID);
            View.ExeShowDutyIllfieldList(dataList);
        }

        async void View_OnAddDutyPatientList(object sender, Views.DutyPatientListEventArgs e)
        {
            try
            {
                iDB.IsDataInitComplete = false;
                await AddDutyPatient(e.SelectedPatient);
            }
            finally
            {
                iDB.IsDataInitComplete = true;
            }
        }

        async Task<bool> AddDutyPatient(List<Data.Patient> PatientList)
        {
            Models.SyncFromServerModel ServerSync = new Models.SyncFromServerModel();
            int maxValue = PatientList.Count * 6 + 1;
            int i = 1, pCount = 1;
            View.ExeShowSyncProgress(i, maxValue, "正在同步选择的病人至本地 ... ");
            //1.同步病人至本地库
            ServerSync.SyncDevicePatientsToLocal(PatientList);
            foreach (Patient patient in PatientList)
            {
                i++;
                View.ExeShowSyncProgress(i, maxValue, "正在同步第 " + pCount.ToString() + " 个病人医嘱至本地库 ... ");
                //2.同步病人医嘱至本地库
                await ServerSync.SyncDevicePatientAdvice(patient.InhosID);
                i++;
                View.ExeShowSyncProgress(i, maxValue, "正在同步第 " + pCount.ToString() + " 个病人检查报告 ... ");
                //3.同步病人检查报告
                await ServerSync.SyncDevicePatientCheckReport(patient.InhosID);
                i++;
                View.ExeShowSyncProgress(i, maxValue, "正在同步第 " + pCount.ToString() + " 个病人病历文书 ... ");
                //4.同步病人病历文书
                await ServerSync.SyncDevicePatientEmrDoc(patient.InhosID);
                i++;
                View.ExeShowSyncProgress(i, maxValue, "正在同步第 " + pCount.ToString() + " 个病人化验报告 ... ");
                //5.同步病人化验报告
                await ServerSync.SyncDevicePatientLisAdviceResult(patient.IllcaseNo);
                i++;
                View.ExeShowSyncProgress(i, maxValue, "正在同步第 " + pCount.ToString() + " 个病人的医生查房日志 ... ");
                //6.同步医生查房日志
                await ServerSync.SyncDeviceDoctorCheckLog(patient.InhosID);
                i++;
                View.ExeShowSyncProgress(i, maxValue, "正在同步第 " + pCount.ToString() + " 个病人费用信息 ... ");
                //7.同步病人费用信息
                await ServerSync.SyncDevicePatientFee(patient.InhosID);
                pCount++;
            }
            Model.SaveDutyPatientToLocal(iCommon.DoctorID, PatientList);
            View.ExeGoBack();
            return true;
        }

        async void View_OnShowDutyPatientList(object sender, Views.DutyPatientListEventArgs e)
        {
            List<Data.Patient> patientList = await Model.QueryIllfieldPatientList(e.IllfieldID);
            View.ExeShowDutyPatientList(patientList);
        }


        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}

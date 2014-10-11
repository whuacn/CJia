using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.MobileMedicalDoctor.Presenters
{
    public class MainPagePresenter : Presenter<Models.MainPageModel, Views.IMainPageView>
    {
        CJia.iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient service = new iSmartMedical.MobileMedicDoctorService.WebServiceSoapClient();
        Models.SyncFromServerModel ServerSync = new Models.SyncFromServerModel();
        public MainPagePresenter(Views.IMainPageView view)
            : base(view)
        {
            //View.OnLoadData += View_OnLoadData;
            View.OnQueryTileData += View_OnQueryTileData;
        }

        async void View_OnQueryTileData(object sender, EventArgs e)
        {
            //int[] PatientCount = Model.QueryPatientCount();
            List<int> PatientCount=new List<int>();
            CJia.iSmartMedical.MobileMedicDoctorService.QueryMyPatientCountResponse MyInHospitalPatientCount = await service.QueryMyPatientCountAsync(iCommon.DoctorID, "正住院");
            PatientCount.Add(int.Parse(Entity.XmlToListDic(MyInHospitalPatientCount.Body.QueryMyPatientCountResult)[0]["MyPatientCount"]));
            CJia.iSmartMedical.MobileMedicDoctorService.QueryDeptPatientCountResponse DeptPatientCount = await service.QueryDeptPatientCountAsync(iCommon.DeptID, "正住院");
            PatientCount.Add(int.Parse(Entity.XmlToListDic(DeptPatientCount.Body.QueryDeptPatientCountResult)[0]["DeptPatientCount"]));
            CJia.iSmartMedical.MobileMedicDoctorService.QueryDoctorPatientCountResponse DutyDoctorPatientCount = await service.QueryDoctorPatientCountAsync(iCommon.DoctorID, "值班病人");
            PatientCount.Add(int.Parse(Entity.XmlToListDic(DutyDoctorPatientCount.Body.QueryDoctorPatientCountResult)[0]["DoctorPatientsCount"]));
            CJia.iSmartMedical.MobileMedicDoctorService.QueryDoctorPatientCountResponse RecentDoctorPatientCount = await service.QueryDoctorPatientCountAsync(iCommon.DoctorID, "近期病人");
            PatientCount.Add(int.Parse(Entity.XmlToListDic(RecentDoctorPatientCount.Body.QueryDoctorPatientCountResult)[0]["DoctorPatientsCount"]));
            CJia.iSmartMedical.MobileMedicDoctorService.QueryMyPatientCountResponse MyOutHospitalPatientCount = await service.QueryMyPatientCountAsync(iCommon.DoctorID, "已出院");
            PatientCount.Add(int.Parse(Entity.XmlToListDic(MyOutHospitalPatientCount.Body.QueryMyPatientCountResult)[0]["MyPatientCount"]));
            CJia.iSmartMedical.MobileMedicDoctorService.NoPharmAdviceCountResponse NoPharmAdviceCount = await service.NoPharmAdviceCountAsync();
            PatientCount.Add(int.Parse(Entity.XmlToListDic(NoPharmAdviceCount.Body.NoPharmAdviceCountResult)[0]["NoPharmAdviceCount"]));
            CJia.iSmartMedical.MobileMedicDoctorService.PharmAdviceCountResponse PharmAdviceCount = await service.PharmAdviceCountAsync();
            PatientCount.Add(int.Parse(Entity.XmlToListDic(PharmAdviceCount.Body.PharmAdviceCountResult)[0]["PharmAdviceCount"]));

            View.ExeShowPatientCount(PatientCount);
        }
        
        //数据同步
        //async void View_OnLoadData(object sender, EventArgs e)
        //{
        //    //int Count = Model.QueryLoaclDataCount();
        //    CJia.iSmartMedical.MobileMedicDoctorService.QueryLoaclDataCountResponse x = await service.QueryLoaclDataCountAsync();
        //    List<Dictionary<string, string>> listDic = Entity.XmlToListDic(x.Body.QueryLoaclDataCountResult);
        //    int Count = int.Parse(listDic[0]["LoacalDataCount"]);
        //    if (Count > 0)
        //    {
        //        View.ExeLoadDataComplet();
        //        return;
        //    }
        //    View.ExeShowSyncProgress(1, 8, "正在同步病人至本地 ... ");
        //    //1.同步病人至本地库
        //    await ServerSync.SyncDevicePatients();
        //    View.ExeShowSyncProgress(2, 8, "正在同步病人医嘱至本地库 ... ");
        //    //2.同步病人医嘱至本地库
        //    await ServerSync.SyncDevicePatientAdvice("");
        //    View.ExeShowSyncProgress(3, 8, "正在同步病人检查报告 ... ");
        //    //3.同步病人检查报告
        //    await ServerSync.SyncDevicePatientCheckReport("");
        //    View.ExeShowSyncProgress(4, 8, "正在同步病人病历文书 ... ");
        //    //4.同步病人病历文书
        //    await ServerSync.SyncDevicePatientEmrDoc("");
        //    View.ExeShowSyncProgress(5, 8, "正在同步病人化验报告 ... ");
        //    //5.同步病人化验报告
        //    await ServerSync.SyncDevicePatientLisAdviceResult("");
        //    View.ExeShowSyncProgress(6, 8, "正在同步医生查房日志 ... ");
        //    //6.同步医生查房日志
        //    await ServerSync.SyncDeviceDoctorCheckLog("");
        //    View.ExeShowSyncProgress(7, 8, "正在同步病人费用信息 ... ");
        //    //7.同步病人费用信息
        //    await ServerSync.SyncDevicePatientFee("");
        //    View.ExeShowSyncProgress(8, 8, "正在同步静态数据 ... ");
        //    //8.同步静态数据
        //    await ServerSync.SyncStaticDataFromServer();

        //    View.ExeLoadDataComplet();
        //}

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}

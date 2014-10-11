using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJia.iSmartMedical.Presenters
{
    public class MainPagePresenter : Presenter<Models.MainPageModel, Views.IMainPageView>
    {
        Models.SyncFromServerModel ServerSync = new Models.SyncFromServerModel();
        public MainPagePresenter(Views.IMainPageView view)
            : base(view)
        {
            View.OnLoadData += View_OnLoadData;
            View.OnQueryTileData += View_OnQueryTileData;
        }

        void View_OnQueryTileData(object sender, EventArgs e)
        {
            int[] PatientCount = Model.QueryPatientCount();
            View.ExeShowPatientCount(PatientCount);
        }
        async void View_OnLoadData(object sender, EventArgs e)
        {
            int Count = Model.QueryLoaclDeviceDataCount();
            if (Count > 0)
            {//若设备中有数据，则非初次使用
                View.ExeLoadDataComplet();
                return;
            }
            //设备初次使用，
            View.ExeShowSyncProgress(1, 8, "正在同步住院病人至本地 ... ");
            //1.同步病人至本地库
            await ServerSync.SyncDevicePatients();
            View.ExeShowSyncProgress(2, 8, "正在同步病人医嘱信息 ... ");
            //2.同步病人医嘱至本地库
            await ServerSync.SyncDevicePatientAdvice("");
            View.ExeShowSyncProgress(3, 8, "正在同步病人检查报告 ... ");
            //3.同步病人检查报告
            await ServerSync.SyncDevicePatientCheckReport("");
            View.ExeShowSyncProgress(4, 8, "正在同步病人病历文书 ... ");
            //4.同步病人病历文书
            await ServerSync.SyncDevicePatientEmrDoc("");
            View.ExeShowSyncProgress(5, 8, "正在同步病人化验报告 ... ");
            //5.同步病人化验报告
            await ServerSync.SyncDevicePatientLisAdviceResult("");
            View.ExeShowSyncProgress(6, 8, "正在同步医生查房日志 ... ");
            //6.同步医生查房日志
            await ServerSync.SyncDeviceDoctorCheckLog("");
            View.ExeShowSyncProgress(7, 8, "正在同步病人费用信息 ... ");
            //7.同步病人费用信息
            await ServerSync.SyncDevicePatientFee("");
            View.ExeShowSyncProgress(8, 8, "正在同步静态数据 ... ");
            //8.同步静态数据
            await ServerSync.SyncStaticDataFromServer();

            View.ExeLoadDataComplet();
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }
    }
}

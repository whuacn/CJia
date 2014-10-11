using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;
using SQLite;
using Windows.UI.Xaml;

namespace CJia.iSmartMedical
{
    public class iDB
    {
        public static string DbFile = "";
        static DispatcherTimer dispTimer = new DispatcherTimer();
        static Models.SyncToServerModel SyncToServer = new Models.SyncToServerModel();
        static Models.SyncFromServerModel SyncFromServer = new Models.SyncFromServerModel();
        static iDB()
        {
            dispTimer.Interval = TimeSpan.FromSeconds(20);
            dispTimer.Tick += dispTimer_Tick;
            dispTimer.Start();
        }
        /// <summary>
        /// 标识数据是否初始化完成，如果在数据初始化时进行同步，会出错。
        /// </summary>
        public static bool IsDataInitComplete = false;
        static async void dispTimer_Tick(object sender, object e)
        {
            if (IsDataInitComplete)
            {
                try
                {
                    dispTimer.Stop();
                    await SyncLocalDataToServer();
                    await SyncServerStaticDataToLocal();
                    await SyncServerPatientDataToLocal();
                }
                finally
                {
                    dispTimer.Start();
                }
            }
        }

        public static event EventHandler SyncComplet;
        /// <summary>
        /// 同步本地数据到服务器
        /// </summary>
        public static async Task<bool> SyncLocalDataToServer()
        {
            if (!iCommon.IsConnected) return false;
            bool hasSync = await SyncToServer.SyncLocalDataToServer();
            if (hasSync && SyncComplet != null)
                SyncComplet(null, null);
            return true;
        }
        /// <summary>
        /// 同步服务器静态数据到本地
        /// </summary>
        public static async Task<bool> SyncServerStaticDataToLocal()
        {
            if (!iCommon.IsConnected) return false;
            bool hasSync = await SyncFromServer.SyncStaticDataFromServer();
            if (hasSync && SyncComplet != null)
                SyncComplet(null, null);
            return true;
        }
        /// <summary>
        /// 同步服务器中病人数据到本地
        /// </summary>
        public static async Task<bool> SyncServerPatientDataToLocal()
        {
            if (!iCommon.IsConnected) return false;
            bool hasSync = await SyncFromServer.SyncDeviceDataFromServer();
            if (hasSync && SyncComplet != null)
                SyncComplet(null, null);
            return true;
        }
        public async static void Init()
        {
            var LocalFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var Database = await LocalFolder.CreateFolderAsync("Database", CreationCollisionOption.OpenIfExists);
            DbFile = Path.Combine(Database.Path, "iLocalMobileMedical.db");
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DbFile))
            {
                SQLiteCommand cmd = conn.CreateCommand("");
                string[] aryScripts = GetInitScript().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string SqlInit in aryScripts)
                {
                    cmd.CommandText = SqlInit;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public async static Task<bool> ReInit()
        {
            var LocalFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var Database = await LocalFolder.CreateFolderAsync("Database", CreationCollisionOption.OpenIfExists);
            DbFile = Path.Combine(Database.Path, "iLocalMobileMedical.db");
            StorageFile storageFile = await Database.GetFileAsync("iLocalMobileMedical.db");
            if (storageFile != null)
            {
                await storageFile.DeleteAsync();
            }
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DbFile))
            {
                SQLiteCommand cmd = conn.CreateCommand("");
                string[] aryScripts = GetInitScript().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string SqlInit in aryScripts)
                {
                    cmd.CommandText = SqlInit;
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        #region 初始化脚本
        static string GetInitScript()
        {
            return @"
CREATE TABLE IF NOT EXISTS [iDevice] (
  [DeviceID] VARCHAR2(100) NOT NULL CONSTRAINT [pk_DeviceID] UNIQUE, 
  [DeviceName] VARCHAR2(100) NOT NULL, 
  [Notes] VARCHAR2(500), 
  [Status] VARCHAR2(50) NOT NULL, 
  [CreateDate] VARCHAR2(20) NOT NULL,
  [LastSaveDate] VARCHAR2(20));
CREATE TABLE IF NOT EXISTS [iDeviceOffice] (
  [DOID] VARCHAR2(100) NOT NULL CONSTRAINT [pk_DOID] UNIQUE, 
  [DeviceID] VARCHAR2(100) NOT NULL, 
  [OfficeID] VARCHAR2(50) NOT NULL, 
  [OfficeName] VARCHAR2, 
  [CreateDate] VARCHAR2(20), 
  [LastSaveDate] VARCHAR2(20));
CREATE TABLE IF NOT EXISTS [iDevicePatient] (
  [DPID] VARCHAR2(100) NOT NULL CONSTRAINT [pk_DPID] UNIQUE, 
  [DeviceID] VARCHAR2(100) NOT NULL, 
  [InhosID] VARCHAR2(50) NOT NULL, 
  [IllcaseNo] VARCHAR2(50), 
  [PatientName] VARCHAR2(100) NOT NULL, 
  [CreateDate] VARCHAR2(20) NOT NULL);
CREATE TABLE IF NOT EXISTS [iDeviceTableChange] (
  [DeviceID] VARCHAR2(50) NOT NULL,
  [TableName] VARCHAR2(50) NOT NULL, 
  [PrimaryKey] VARCHAR2(50) NOT NULL, 
  [LastChangeDate] VARCHAR2(50) NOT NULL);
CREATE TABLE IF NOT EXISTS [iDept] (
  [DeptID] VARCHAR2(20) NOT NULL CONSTRAINT [pk_DeptID] UNIQUE, 
  [DeptName] VARCHAR2(100) NOT NULL, 
  [DeptFlag] VARCHAR2(50) NOT NULL, 
  [Status] VARCHAR2(2) NOT NULL DEFAULT 1, 
  [CreateDate] VARCHAR2(20) NOT NULL);
CREATE TABLE IF NOT EXISTS [iIllfieldDept] (
  [IllfieldID] VARCHAR2(50) NOT NULL, 
  [DeptID] VARCHAR2(50) NOT NULL);
CREATE TABLE IF NOT EXISTS [User] (
  [ID] VARCHAR2(50) NOT NULL CONSTRAINT [pk_UserID] UNIQUE, 
  [Code] VARCHAR2(20) NOT NULL, 
  [Password] VARCHAR2(50) NOT NULL, 
  [Name] VARCHAR2(100) NOT NULL, 
  [DeptID] NUMBER NOT NULL, 
  [DeptName] VARCHAR2(100) NOT NULL,
  [UserType] VARCHAR2(50),
  [Status] VARCHAR2(2) NOT NULL DEFAULT 1);
CREATE TABLE IF NOT EXISTS [Patient] (
  [InhosID] VARCHAR2(50) NOT NULL CONSTRAINT [pk_Inhos_ID] UNIQUE, 
  [PatientID] VARCHAR2(50) NOT NULL, 
  [PatientCode] VARCHAR2(50) NOT NULL, 
  [PatientName] VARCHAR2(100) NOT NULL,
  [PatientType] VARCHAR2(100) NOT NULL,   
  [IDCardNo] VARCHAR2(20), 
  [Gender] VARCHAR2(10), 
  [Age] VARCHAR2(20),   
  [IllcaseNo] VARCHAR2(50) NOT NULL, 
  [InhosDate] VARCHAR2(20) NOT NULL, 
  [InhosType] VARCHAR2(20) NOT NULL, 
  [InhosStatus] VARCHAR2(50) NOT NULL, 
  [IllfieldID] VARCHAR2(50), 
  [IllfieldName] VARCHAR2(100), 
  [OfficeID] VARCHAR2(50), 
  [OfficeName] VARCHAR2(100), 
  [RoomID] VARCHAR2(20), 
  [RoomName] VARCHAR2(50),
  [BedID] VARCHAR2(50), 
  [BedName] VARCHAR2(100),   
  [BedDoctor] VARCHAR2(50), 
  [BedDoctorName] VARCHAR2(50), 
  [GradeName] VARCHAR2(100),   
  [FoodName] VARCHAR2(100), 
  [IllnessState] VARCHAR2(100), 
  [AllergicHistory] VARCHAR2(500),
  [DiagnoseName] VARCHAR2(500),
  [LeaveHosDate] VARCHAR2(20),
  [LeaveHosState] VARCHAR2(100),
  [EMRID] VARCHAR2(100),
  [Prepay] VARCHAR2(20) NOT NULL, 
  [FeeSum] VARCHAR2(20) NOT NULL, 
  [IsOweFee] VARCHAR2(2));
CREATE INDEX IF NOT EXISTS [idx_Patient_Name] ON [Patient] ([PatientName]);
CREATE INDEX IF NOT EXISTS [idx_Bed_Name] ON [Patient] ([BedName]);
CREATE TABLE IF NOT EXISTS [DoctorPatients] (
  [DPID] VARCHAR2(50) NOT NULL, 
  [DoctorID] VARCHAR2(50) NOT NULL, 
  [InhosID] VARCHAR2(50) NOT NULL, 
  [DPType] VARCHAR2(20) NOT NULL, 
  [CreateDate] VARCHAR2(50) NOT NULL);
CREATE INDEX IF NOT EXISTS [idx_DoctorPatientID] ON [DoctorPatients] ([DPID]);
CREATE TABLE IF NOT EXISTS [PatientAdvices] (
  [PAID] VARCHAR2(50) NOT NULL CONSTRAINT [pk_PatientAdviceID] UNIQUE, 
  [InhosID] VARCHAR2(50) NOT NULL, 
  [AdviceID] VARCHAR2(50) NOT NULL, 
  [PatientIllfield] VARCHAR2(50), 
  [PatientOffice] VARCHAR2(50), 
  [StandingFlag] VARCHAR2(20) NOT NULL, 
  [AdviceType] VARCHAR2(50) NOT NULL, 
  [AdviceName] VARCHAR2(300) NOT NULL, 
  [CommonName] VARCHAR2(300), 
  [AdviceShowName] VARCHAR2(1000), 
  [ViewGroup] VARCHAR2(20), 
  [GroupIndex] VARCHAR2(20), 
  [Spec] VARCHAR2(100), 
  [Dosage] VARCHAR2(100), 
  [UsageName] VARCHAR2(100), 
  [Frequence] VARCHAR2(100), 
  [Memo] VARCHAR2(300), 
  [ListDoctor] VARCHAR2(50), 
  [ListDoctorOffice] VARCHAR2(50), 
  [ListDate] VARCHAR2(50), 
  [PreStartDate] VARCHAR2(50), 
  [PreStopDate] VARCHAR2(50), 
  [StopDoctor] VARCHAR2(50), 
  [StopDate] VARCHAR2(50), 
  [AuditNurse] VARCHAR2(50), 
  [AuditDate] VARCHAR2(50), 
  [StopAuditNurse] VARCHAR2(50), 
  [StopAuditDate] VARCHAR2(50), 
  [AdviceStatus] VARCHAR2(50));
CREATE INDEX IF NOT EXISTS [idx_InhosID] ON [PatientAdvices] ([InhosID]);
CREATE INDEX IF NOT EXISTS [idx_AdviceName] ON [PatientAdvices] ([AdviceName]);
CREATE TABLE IF NOT EXISTS [DoctorCheckLog] (
  [DCLID] VARCHAR2(50) NOT NULL CONSTRAINT [pk_DoctorCheckID] UNIQUE, 
  [DeviceID] VARCHAR2(90) NOT NULL, 
  [InhosID] VARCHAR2(50) NOT NULL, 
  [DoctorID] VARCHAR2(50) NOT NULL, 
  [DoctorName] VARCHAR2(50), 
  [LogType] VARCHAR2(10), 
  [CheckDate] VARCHAR2(50) NOT NULL, 
  [CheckTime] VARCHAR2(20), 
  [CheckLog] VARCHAR2(500), 
  [Photo] BLOB, 
  [MedicalLog] BLOB, 
  [LastSaveDate] VARCHAR2(50));
CREATE INDEX IF NOT EXISTS [idx_DoctorCheckLog1] ON [DoctorCheckLog] ([DoctorID], [InhosID]);
CREATE TABLE IF NOT EXISTS [SyncLog] (
  [LogID] VARCHAR2(50) NOT NULL CONSTRAINT [pk_LogID] UNIQUE, 
  [DeviceID] VARCHAR2(100) NOT NULL, 
  [InhosID] VARCHAR2(50) NOT NULL, 
  [TableName] VARCHAR2(30) NOT NULL, 
  [KeyField] VARCHAR2(20) NOT NULL, 
  [KeyValue] VARCHAR2(50) NOT NULL, 
  [ChangeType] VARCHAR2(10) NOT NULL, 
  [ChangeDate] VARCHAR2(50) NOT NULL);
CREATE TABLE IF NOT EXISTS [PatientEmrDoc] (
  [InhosID] VARCHAR2(50) NOT NULL, 
  [SectionNo] VARCHAR2(20) NOT NULL, 
  [DocTypeID] VARCHAR2(10), 
  [DocTypeName] VARCHAR2(100), 
  [Title] VARCHAR2(200) NOT NULL, 
  [DocContent] CLOB, 
  [Creator] VARCHAR2(50), 
  [CreateDate] VARCHAR2(50), 
  [CreateTime] VARCHAR2(20), 
  [Status] VARCHAR2(10), 
  [Checker] VARCHAR2(50), 
  [CheckDate] VARCHAR2(50), 
  [LastSaveDate] VARCHAR2(50));
CREATE INDEX IF NOT EXISTS [idx_EmrDoc_InhosID] ON [PatientEmrDoc] ([InhosID]);
CREATE TABLE IF NOT EXISTS [iCode] (
  [Code] VARCHAR2(6) NOT NULL CONSTRAINT [pk_MMCode] UNIQUE, 
  [Name] VARCHAR2(50) NOT NULL, 
  [Value] VARCHAR2(500), 
  [GroupName] VARCHAR2(100) NOT NULL, 
  [Code2] VARCHAR2(10), 
  [Remark] VARCHAR2(100), 
  [Status] VARCHAR2(2) NOT NULL DEFAULT 1);
CREATE TABLE IF NOT EXISTS [LisAdvice] (
  [IllcaseNo] VARCHAR2(50) NOT NULL, 
  [AdviceID] VARCHAR2(50) NOT NULL, 
  [AdviceName] VARCHAR2(500) NOT NULL, 
  [Diagnose] VARCHAR2(200), 
  [Doctor] VARCHAR2(50), 
  [ApplyDate] VARCHAR2(20), 
  [Office] VARCHAR2(100), 
  [Reporter] VARCHAR2(50), 
  [ReportDate] VARCHAR2(20), 
  [SampleNo] VARCHAR2(50), 
  [TestDate] VARCHAR2(20));
CREATE INDEX IF NOT EXISTS [idx_LisAdvice_IllcaseNo] ON [LisAdvice] ([IllcaseNo]);
CREATE TABLE IF NOT EXISTS [LisResult] (
  [PatientID] VARCHAR2(50), 
  [IllcaseNo] VARCHAR2(50), 
  [AdviceInfo] VARCHAR2(500),
  [ApplyDate] VARCHAR2(20), 
  [ReportDate] VARCHAR2(20), 
  [SampleNo] VARCHAR2(50) NOT NULL, 
  [TestDate] VARCHAR2(20) NOT NULL, 
  [ItemCode] VARCHAR2(50), 
  [ItemName] VARCHAR2(200), 
  [TestResult] VARCHAR2(100), 
  [TestUnit] VARCHAR2(50), 
  [NormalRange] VARCHAR2(100), 
  [TestNote] VARCHAR2(200), 
  [CRISISValue] VARCHAR2(100));
CREATE INDEX IF NOT EXISTS [Idx_LisResult_SampleNo] ON [LisResult] ([SampleNo], [TestDate]);
CREATE TABLE IF NOT EXISTS [PatientPrepay] (
  [InhosID] VARCHAR2(50) NOT NULL, 
  [Prepay] NUMBER(12, 2) NOT NULL, 
  [PayDate] VARCHAR2(20) NOT NULL, 
  [Status] VARCHAR2(20) NOT NULL, 
  [BalanceDate] VARCHAR2(20));
CREATE INDEX IF NOT EXISTS [idx_Prepay_InhosID] ON [PatientPrepay] ([InhosID]);
CREATE TABLE IF NOT EXISTS [PatientFee] (
  [InhosID] VARCHAR2(50) NOT NULL, 
  [FeeTypeCode] VARCHAR2(100), 
  [FeeTypeName] VARCHAR2(100) NOT NULL, 
  [FeeSum] NUMBER(12, 2) NOT NULL);
CREATE INDEX IF NOT EXISTS [idx_PatientFee_InhosID] ON [PatientFee] ([InhosID]);
CREATE TABLE IF NOT EXISTS [iType2] (
  [AdviceTypeID2] VARCHAR2(50) NOT NULL CONSTRAINT [pk_AdviceTypeID2] UNIQUE, 
  [AdviceTypeName2] VARCHAR2(100) NOT NULL, 
  [AdviceTypeID] VARCHAR2(50) NOT NULL, 
  [Status] VARCHAR2(2) NOT NULL);
CREATE TABLE IF NOT EXISTS [iAdvice] (
  [AID] VARCHAR2(50) NOT NULL CONSTRAINT [pk_AdviceID] UNIQUE, 
  [AdviceID] VARCHAR2(50) NOT NULL, 
  [AdviceType] VARCHAR2(50) NOT NULL, 
  [StandingType] VARCHAR2(2) NOT NULL, 
  [AdviceCode] VARCHAR2(50), 
  [AdviceName] VARCHAR2(500) NOT NULL, 
  [CommonName] VARCHAR2(500), 
  [AdviceFilter] VARCHAR2(200), 
  [Spec] VARCHAR2(200), 
  [Price] VARCHAR2(20), 
  [Unit] VARCHAR2(50), 
  [Factory] VARCHAR2(500), 
  [Notes] VARCHAR2(200), 
  [DefaultDosage] VARCHAR2(50), 
  [DefaultUsage] VARCHAR2(50), 
  [DefaultFrequency] VARCHAR2(50), 
  [DefaultPharmType] VARCHAR2(50));
CREATE INDEX IF NOT EXISTS [idx_AdviceFilter] ON [iAdvice] ([AdviceType], [AdviceFilter]);
CREATE INDEX IF NOT EXISTS [idx_AdviceType1] ON [iAdvice] ([AdviceType]);
CREATE TABLE IF NOT EXISTS [iAdviceType] (
  [ATID] VARCHAR2(50) NOT NULL CONSTRAINT [pk_ATID] UNIQUE, 
  [Type2ID] VARCHAR2(50) NOT NULL, 
  [AdviceID] VARCHAR2(50) NOT NULL);
CREATE TABLE IF NOT EXISTS [iTableChange] (
  [TableName] VARCHAR2(50) NOT NULL, 
  [PrimaryKey] VARCHAR2(50) NOT NULL, 
  [LastChangeDate] VARCHAR2(50) NOT NULL);
CREATE TABLE IF NOT EXISTS [iFrequency] (
  [FrequencyID] VARCHAR2(50) NOT NULL CONSTRAINT [pk_FrequencyID] UNIQUE, 
  [FrequencyName] VARCHAR2(200) NOT NULL, 
  [FrequencyFilter] VARCHAR2(50), 
  [StandingFlag] VARCHAR2(10), 
  [UseFlag] VARCHAR2(10), 
  [OrderSeq] VARCHAR2(10), 
  [Notes] VARCHAR2(100));
CREATE TABLE IF NOT EXISTS [iUsage] (
  [UsageID] VARCHAR2(50) NOT NULL CONSTRAINT [pk_UsageID] UNIQUE, 
  [UsageName] VARCHAR2(200) NOT NULL, 
  [UsageTypeCode] VARCHAR2(50), 
  [UsageFilter] VARCHAR2(50), 
  [Notes] VARCHAR2(50));
CREATE TABLE IF NOT EXISTS [PadAdvice] (
  [PAID] VARCHAR2(50) NOT NULL CONSTRAINT [pk_PadAdivceID] UNIQUE, 
  [DeviceID] VARCHAR2(100) NOT NULL, 
  [InhosID] VARCHAR2(50) NOT NULL, 
  [PatientName] VARCHAR2(100) NOT NULL, 
  [DoctorID] VARCHAR2(50) NOT NULL, 
  [DoctorName] VARCHAR2(50) NOT NULL, 
  [AdviceTypeCode] VARCHAR2(10) NOT NULL, 
  [AdviceTypeName] VARCHAR2(50) NOT NULL, 
  [StandingTypeCode] VARCHAR2(10) NOT NULL, 
  [StandingTypeName] VARCHAR2(50) NOT NULL, 
  [AdviceID] VARCHAR2(50) NOT NULL, 
  [HiSAdviceID] VARCHAR2(50) NOT NULL, 
  [AdviceName] VARCHAR2(200) NOT NULL, 
  [AdviceShowName] VARCHAR2(500) NOT NULL,
  [CommonName] VARCHAR2(200), 
  [Spec] VARCHAR2(100), 
  [GroupIndex] VARCHAR2(50) NOT NULL, 
  [Dosage] VARCHAR2(20), 
  [DosageUnit] VARCHAR2(50), 
  [Amount] VARCHAR2(20), 
  [AmountUnit] VARCHAR2(50), 
  [UsageID] VARCHAR2(50), 
  [UsageName] VARCHAR2(100), 
  [FrequenceID] VARCHAR2(50), 
  [FrequenceName] VARCHAR2(100), 
  [PreStartDate] VARCHAR2(20), 
  [PreStopDate] VARCHAR2(20), 
  [Notes] VARCHAR2(500), 
  [CreateDate] VARCHAR2(20) NOT NULL, 
  [Status] VARCHAR2(20) NOT NULL, 
  [SyncStatus] VARCHAR2(20) NOT NULL, 
  [SyncDate] VARCHAR2(20));
CREATE INDEX IF NOT EXISTS [idx_PadPatientAdvice] ON [PadAdvice] ([InhosID]);
CREATE TABLE IF NOT EXISTS [CheckApply] (
  [InhosID] VARCHAR2(50) NOT NULL, 
  [IllcaseNo] VARCHAR2(50) NOT NULL, 
  [PatientName] VARCHAR2(50) NOT NULL, 
  [PatientClass] VARCHAR2(10), 
  [ApplyNo] VARCHAR2(100), 
  [TechSystem] VARCHAR2(20), 
  [ReportType] VARCHAR2(50), 
  [ReportName] VARCHAR2(500), 
  [ReportDate] VARCHAR2(50), 
  [SubmissionDate] VARCHAR2(50), 
  [TechNo] VARCHAR2(50), 
  [TechMothod] VARCHAR2(500), 
  [isNew] VARCHAR2(2) DEFAULT 1);
CREATE INDEX IF NOT EXISTS [idx_CheckApply_InhosID] ON [CheckApply] ([InhosID]);
CREATE INDEX IF NOT EXISTS [idx_CheckApply_ApplyNo] ON [CheckApply] ([ApplyNo]);
CREATE TABLE IF NOT EXISTS [CheckResult] (
  [ApplyNo] VARCHAR2(100) NOT NULL, 
  [TechSystem] VARCHAR2(20), 
  [SerialNo] VARCHAR2(50), 
  [ItemCode] VARCHAR2(50), 
  [ItemName] VARCHAR2(50), 
  [ItemResult] VARCHAR2(1000));
CREATE INDEX IF NOT EXISTS [idx_CheckResult_ApplyNo] ON [CheckResult] ([ApplyNo])";
        }
        #endregion
    }
}

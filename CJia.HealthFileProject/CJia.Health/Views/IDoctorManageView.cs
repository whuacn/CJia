using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Views 
{
    public interface IDoctorManageView : CJia.Health.Tools.IView
    {
        event EventHandler<DoctorArgs> OnQueryDoctor;

        event EventHandler<DoctorArgs> OnInsertDoctor;

        event EventHandler<DoctorArgs> OnUpdateDoctor;

        event EventHandler<DoctorArgs> OnDeleteDoctor;

        event EventHandler<DoctorArgs> OnQueryDocDescript;

        event EventHandler<DoctorArgs> OnCheckDoctorNo;

        event EventHandler<DoctorArgs> OnQueryDept;

        event EventHandler<DoctorArgs> OnInsertUserDoc;

        void exeBindIsDocNoHave(bool IsDocNoHave);

        void ExeBindDoctor(DataTable dtDoctor);

        void ExeBindDocDescript(DataTable dtDocDescript);

        void ExeBindDocDept(DataTable dtDocDept);
    }

    public class DoctorArgs : EventArgs
    {
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string DoctorName;

        /// <summary>
        /// 医生编号
        /// </summary>
        public string DoctorNo;

        /// <summary>
        /// 医生Id
        /// </summary>
        public string DoctorId;

        /// <summary>
        /// 拼音查询码
        /// </summary>
        public string DoctorPinyin;

        /// <summary>
        /// 科室ID
        /// </summary>
        public string DeptId;

        /// <summary>
        /// 科室名称
        /// </summary>
        public string DepeName;

        /// <summary>
        /// 职称ID
        /// </summary>
        public string DescriptId;

        /// <summary>
        /// 职称
        /// </summary>
        public string Descript;

        /// <summary>
        /// 登录用户ID
        /// </summary>
        public string UserId;

        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWord;
    }
}

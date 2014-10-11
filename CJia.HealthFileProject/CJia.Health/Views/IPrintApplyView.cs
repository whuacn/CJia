using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views
{
    public interface IPrintApplyView : CJia.Health.Tools.IView
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.PrintApplyEventArgs> OnInit;

        /// <summary>
        /// 查询病人事件
        /// </summary>
        event EventHandler<Views.PrintApplyEventArgs> OnPatientSearch;

        /// <summary>
        /// 双击病人列表绑定checkboxList图片信息
        /// </summary>
        event EventHandler<Views.PrintApplyEventArgs> OnPatientDoubleClick;

        ///// <summary>
        ///// 查询图片事件
        ///// </summary>
        //event EventHandler<Views.PrintApplyEventArgs> OnSelectPicture;

        /// <summary>
        /// 绑定病人列表
        /// </summary>
        /// <param name="dtGridPatient"></param>
        void ExeGridPatient(DataTable dtGridPatient);

        /// <summary>
        /// 绑定界面选择框图片信息
        /// </summary>
        /// <param name="dtPicture"></param>
        void ExeBindChkPicture(DataTable dtPicture);

        ///// <summary>
        ///// 绑定图片
        ///// </summary>
        ///// <param name="result"></param>
        //void ExePicture(DataTable result);

     
    }

    public class PrintApplyEventArgs : EventArgs
    {
        /// <summary>
        /// 开始时间（搜索）
        /// </summary>
        public DateTime StartDate;

        /// <summary>
        /// 截止时间（搜索）
        /// </summary>
        public DateTime EndDate;

        /// <summary>
        /// 录入开始时间
        /// </summary>
        public DateTime InputStartDate;

        /// <summary>
        /// 录入截至时间
        /// </summary>
        public DateTime InputEndDate;

        /// <summary>
        /// 查询时间是否为录入时间
        /// </summary>
        public bool isInput;

        /// <summary>
        /// 病人ID
        /// </summary>
        public string PatientId;

        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName;

        ///// <summary>
        ///// 身份证号
        ///// </summary>
        //public string Card;

        /// <summary>
        /// 病案号
        /// </summary>
        public string RecordNo;

        /// <summary>
        /// st_picture(HEALTH_ID)病人表主键病人ID
        /// </summary>
        public string HealthId;
      
    }
}

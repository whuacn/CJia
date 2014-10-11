using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// 修改批次对应冲药的接口
    /// </summary>
    public interface IEditBatchToRedDrugView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 修改批次
        /// </summary>
        event EventHandler<EditBatchToRedDrugEventArgs> OnUpdateBatchSet;

        /// <summary>
        /// 判断修改的批次执行时间是否有重叠
        /// </summary>
        event EventHandler<EditBatchToRedDrugEventArgs> OnIsRepeat;

        /// <summary>
        /// 传回UI层告知修改是否有重复
        /// </summary>
        /// <param name="isRepeat"></param>
        /// <returns></returns>
        void ExeIsRepeat(bool isRepeat);
    }

   /// <summary>
   /// 修改批次对应冲药的参数类
   /// </summary>
    public class EditBatchToRedDrugEventArgs : EventArgs
    {
        //public string timeType;    
        /// <summary>
        /// 批次执行时间
        /// </summary>
        public string BatchTime;   

        /// <summary>
        /// TimeSet  ID
        /// </summary>
        public long Time_id;        

        /// <summary>
        /// 批次ID
        /// </summary>
        public long Batch_id;     

        /// <summary>
        /// 当前登录用户ID
        /// </summary>
        public long User_id;        
    }
}
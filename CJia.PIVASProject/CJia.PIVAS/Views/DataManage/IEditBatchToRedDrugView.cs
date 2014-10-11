using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// �޸����ζ�Ӧ��ҩ�Ľӿ�
    /// </summary>
    public interface IEditBatchToRedDrugView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// �޸�����
        /// </summary>
        event EventHandler<EditBatchToRedDrugEventArgs> OnUpdateBatchSet;

        /// <summary>
        /// �ж��޸ĵ�����ִ��ʱ���Ƿ����ص�
        /// </summary>
        event EventHandler<EditBatchToRedDrugEventArgs> OnIsRepeat;

        /// <summary>
        /// ����UI���֪�޸��Ƿ����ظ�
        /// </summary>
        /// <param name="isRepeat"></param>
        /// <returns></returns>
        void ExeIsRepeat(bool isRepeat);
    }

   /// <summary>
   /// �޸����ζ�Ӧ��ҩ�Ĳ�����
   /// </summary>
    public class EditBatchToRedDrugEventArgs : EventArgs
    {
        //public string timeType;    
        /// <summary>
        /// ����ִ��ʱ��
        /// </summary>
        public string BatchTime;   

        /// <summary>
        /// TimeSet  ID
        /// </summary>
        public long Time_id;        

        /// <summary>
        /// ����ID
        /// </summary>
        public long Batch_id;     

        /// <summary>
        /// ��ǰ��¼�û�ID
        /// </summary>
        public long User_id;        
    }
}
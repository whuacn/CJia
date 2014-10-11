using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IPublishTask : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.PublishTaskArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        event EventHandler<Views.PublishTaskArgs> OnSave;

        /// <summary>
        /// 下拉选择任务类型
        /// </summary>
        event EventHandler<Views.PublishTaskArgs> OnSelectedDropTaskType;

        ///// <summary>
        ///// 查询文件Seq，重命名上传文件夹名称
        ///// </summary>
        //event EventHandler<Views.PublishTaskArgs> OnFileSeq;

        /// <summary>
        /// 绑定任务类型
        /// </summary>
        /// <param name="dtTaskType"></param>
        void ExeDropTaskType(DataTable dtTaskType);

        /// <summary>
        /// 保存是否成功
        /// </summary>
        /// <param name="bol"></param>
        void ExeIsSaveSuccess(bool bol);
    }

    public class PublishTaskArgs : EventArgs
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName;

        /// <summary>
        /// 模版ID
        /// </summary>
        public string TemplateId;

        /// <summary>
        /// 任务类型
        /// </summary>
        public string TaskType;

        /// <summary>
        /// 下达机关名称
        /// </summary>
        public string OrganName;

        /// <summary>
        /// 任务下达开始时间
        /// </summary>
        public DateTime? StartDate;

        /// <summary>
        /// 任务下达截止时间
        /// </summary>
        public DateTime? EndDate;

        /// <summary>
        /// 检查范围
        /// </summary>
        public string CheckScord;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark;

        /// <summary>
        /// 所选下拉任务类型ID
        /// </summary>
        public long SelectedDropTaskTypeId;

        /// <summary>
        /// 发布任务时是否存在执行机关，即下达机关（true 存在，false不存在）
        /// </summary>
        public bool IsExistOragnAdd = false;

        /// <summary>
        /// 创建人
        /// </summary>
        public DataTable User;

        /// <summary>
        /// 文件名称
        /// </summary>
        public List<string> FileName = new List<string>();

        /// <summary>
        /// 文件路径
        /// </summary>
        public List<string> FilePath = new List<string>();

        ///// <summary>
        ///// 文件Seq，确保唯一性
        ///// </summary>
        //public string FileSeq;
    }
}

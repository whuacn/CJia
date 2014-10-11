using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IEditTask : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.EditTaskArgs> OnInit;

        /// <summary>
        /// 下拉选择任务类型
        /// </summary>
        event EventHandler<Views.EditTaskArgs> OnSelectedDropTaskType;

        /// <summary>
        /// 保存事件
        /// </summary>
        event EventHandler<Views.EditTaskArgs> OnSave;

        ///// <summary>
        ///// 查询文件Seq，重命名上传文件夹名称
        ///// </summary>
        //event EventHandler<Views.EditTaskArgs> OnFileSeq;

        /// <summary>
        /// 绑定界面所选任务相关信息
        /// </summary>
        /// <param name="dtTask"></param>
        void ExeBindControl(DataTable dtTask);

         /// <summary>
        /// 绑定任务类型
        /// </summary>
        /// <param name="dtTaskType"></param>
        void ExeDropTaskType(DataTable dtTaskType);

        /// <summary>
        /// 绑定Grid文件
        /// </summary>
        /// <param name="dtFiles"></param>
        void ExeGridFile(DataTable dtFiles);

        /// <summary>
        /// 保存是否成功
        /// </summary>
        /// <param name="bol"></param>
        void ExeIsSaveSuccess(bool bol);
    }

    public class EditTaskArgs : EventArgs
    {
        /// <summary>
        /// 正在编辑的任务ID
        /// </summary>
        public string EditTaskId;

        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName;

        /// <summary>
        /// 模版ID
        /// </summary>
        public string TemplateId;
        
        /// <summary>
        /// 模版名称
        /// </summary>
        public string TemplateName;

        /// <summary>
        /// 任务类型ID
        /// </summary>
        public string TaskTypeId;

        /// <summary>
        /// 任务类型名称
        /// </summary>
        public string TaskTypeName;

        /// <summary>
        /// 组织名称
        /// </summary>
        public string OrganName;

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? StartDate;

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? EndDate;

        /// <summary>
        /// 检查范围
        /// </summary>
        public string CheckScord;

        /// <summary>
        /// 备注说明
        /// </summary>
        public string Remark;

        /// <summary>
        /// 所选下拉任务类型ID
        /// </summary>
        public long SelectedDropTaskTypeId;

        /// <summary>
        /// 编辑任务时是否存在执行机关，即下达机关（true 存在，false不存在）
        /// </summary>
        public bool IsExistOragnEdit = false;

        /// <summary>
        /// 登录用户信息
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

        /// <summary>
        /// 所要删除的文件ID
        /// </summary>
        public List<string> DeleteFilesId = new List<string>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views
{
    public interface IImagesInputView : CJia.Health.Tools.IView
    {
        /// <summary>
        /// 初始加载
        /// </summary>
        event EventHandler OnLoad;
        event EventHandler<ImagesInputArgs> OnInput;
        event EventHandler<ImagesInputArgs> OnProject;
        event EventHandler<ImagesInputArgs> OnRecordNO;
        event EventHandler<ImagesInputArgs> OnSelectPicture;
        event EventHandler<ImagesInputArgs> OnInputSave;
        event EventHandler<ImagesInputArgs> OnInputDelete;
        event EventHandler<ImagesInputArgs> OnReview;
        event EventHandler<ImagesInputArgs> OnMerge;
        event EventHandler<ImagesInputArgs> OnNoAgree;
        event EventHandler<ImagesInputArgs> OnShortKeyDown;//快捷键事件
        /// <summary>
        /// 初始绑定
        /// </summary>
        /// <param name="data"></param>
        void ExeInit(DataTable data);
        /// <summary>
        /// 绑定病案号
        /// </summary>
        /// <param name="data"></param>
        void ExeRecordNO(DataTable data);
        /// <summary>
        /// 绑定病案
        /// </summary>
        /// <param name="data"></param>
        void ExeBindPicture(DataTable data);
        /// <summary>
        /// 返回通过快捷键查询的项目分类
        /// </summary>
        /// <param name="data"></param>
        void ExeBindProjectByShortKey(DataTable data);
    }
    public class ImagesInputArgs : EventArgs
    {
        /// <summary>
        /// 保存的数据
        /// </summary>
        public List<Dictionary<string, string>> dict;
        /// <summary>
        /// 项目值
        /// </summary>
        public string SelectValue;
        /// <summary>
        /// 病案号值
        /// </summary>
        public string RecordNO;
        /// <summary>
        /// 待保存的病案信息
        /// </summary>
        public DataTable PictureData;
        /// <summary>
        /// 病人表id
        /// </summary>
        public string HealthID;
        /// <summary>
        /// 病案id
        /// </summary>
        public string PictureID;
        /// <summary>
        /// 页码
        /// </summary>
        public string Page;
        /// <summary>
        /// 附加页
        /// </summary>
        public string SubPage;
        /// <summary>
        /// 项目id
        /// </summary>
        public string ProID;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProName;
        /// <summary>
        /// 合并状态
        /// </summary>
        public string MergeState;
        /// <summary>
        /// 快捷键
        /// </summary>
        public string ShortKey;
    }
}

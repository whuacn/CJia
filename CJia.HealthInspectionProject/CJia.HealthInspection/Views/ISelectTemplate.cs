using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface ISelectTemplate : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.SelectTemplateArgs> OnInit;

        /// <summary>
        /// 选择大分类事件
        /// </summary>
        event EventHandler<Views.SelectTemplateArgs> OnDropBigSelectedChanged;

        /// <summary>
        /// 选择中分类事件
        /// </summary>
        event EventHandler<Views.SelectTemplateArgs> OnDropMiddleSelectedChanged;

        /// <summary>
        /// 根据类型查询模版
        /// </summary>
        event EventHandler<Views.SelectTemplateArgs> OnSelectTemp;

        /// <summary>
        /// 确定事件
        /// </summary>
        event EventHandler<Views.SelectTemplateArgs> OnQueryTempNameByIdForAdd;

        event EventHandler<SelectTemplateArgs> OnQueryTempNameByIDForEdit;

        event EventHandler<SelectTemplateArgs> ONQueryTempNameByIdForExeCheck;

        /// <summary>
        /// 绑定模版Grid
        /// </summary>
        /// <param name="dtTemplate"></param>
        void ExeGridTemp(DataTable dtTemplate);

        /// <summary>
        /// 绑定大分类
        /// </summary>
        /// <param name="dtBig"></param>
        void ExeDropBig(DataTable dtBig);

         /// <summary>
        /// 绑定中分类
        /// </summary>
        /// <param name="dtMiddle"></param>
        void ExeDropMiddle(DataTable dtMiddle);

        /// <summary>
        /// 绑定小分类
        /// </summary>
        /// <param name="dtSmall"></param>
        void ExeDropSmall(DataTable dtSmall);

        /// <summary>
        /// 根据模板id查询模板名称
        /// </summary>
        /// <param name="dtTemp"></param>
        void ExeGetTempNameForAdd(string TempName);

        void ExeGetTempNameForEdit(string TempName);

        void ExeGetTempNameForExeCheck(string TempName);
    }

    public class SelectTemplateArgs : EventArgs
    {
        /// <summary>
        /// 添加的模板ID
        /// </summary>
        public long TempIDAdd;

        /// <summary>
        /// 编辑是的模板ID
        /// </summary>
        public long TempIDEdit;

        /// <summary>
        /// 执行监督选择的模板ID
        /// </summary>
        public long TempIDExeTemp;
        /// <summary>
        /// 所选大分类ID
        /// </summary>
        public string SelectedBigTempId;

        /// <summary>
        /// 所选中分类ID
        /// </summary>
        public string SelectedMiddleTempId;

        /// <summary>
        /// 查询模版时所选类型ID
        /// </summary>
        public string TypeId;

        /// <summary>
        /// 模板大分类
        /// </summary>
        public string BigTypeID;

        /// <summary>
        /// 模板中分类
        /// </summary>
        public string MiddleTypeID;

        /// <summary>
        /// 模板小分类
        /// </summary>
        public string SmallTypeID;
        /// <summary>
        /// 组织ID 
        /// </summary>
        public long OrganId;
    }
}

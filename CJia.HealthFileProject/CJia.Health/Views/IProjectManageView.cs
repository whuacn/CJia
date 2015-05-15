using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Views
{
    public interface IProjectManageView: CJia.Health.Tools.IView
    {
        event EventHandler<ProjectKeyWordArg> OnQueryProject;

        event EventHandler<ProjectKeyWordArg> OnUpdateProject;

        event EventHandler<ProjectKeyWordArg> OnInsertProject;

        event EventHandler<ProjectKeyWordArg> OnDeleteProject;

        void ExeBindProject(DataTable dt);
    }

    public class ProjectKeyWordArg : EventArgs
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWord;

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName;

        /// <summary>
        /// 项目编号
        /// </summary>
        public string ProNo;

        /// <summary>
        /// 项目拼音查询码
        /// </summary>
        public string ProPinyin;

        /// <summary>
        /// 项目Id
        /// </summary>
        public string ProId;

        /// <summary>
        /// 登录用户ID
        /// </summary>
        public string UserID;
        /// <summary>
        /// 是否可以打印（1可以打印，0不可以）
        /// </summary>
        public string isPrint;
        /// <summary>
        /// 快捷键
        /// </summary>
        public string shortKey;
        /// <summary>
        /// 是否可以浏览（1可以浏览，0不可以）
        /// </summary>
        public string isLook;
    }
}

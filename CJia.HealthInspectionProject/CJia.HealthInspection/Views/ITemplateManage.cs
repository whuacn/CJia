using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Views
{
    public interface ITemplateManage:Tools.IPage
    {
        event EventHandler OnInitPage;
        event EventHandler<TemplateManageArgs> OnTreeClick;
        event EventHandler<TemplateManageArgs> OnDeleteTemp;
        void ExeBindTree(DataTable data);
        void ExeBindTemplate(DataTable data);
        void ExeIsSuccess(bool bol);
    }
    public class TemplateManageArgs : EventArgs
    {
        /// <summary>
        /// 模板id
        /// </summary>
        public string TemplateID;
        /// <summary>
        /// 模板类型id
        /// </summary>
        public string TypeID;

        /// <summary>
        /// 用户信息
        /// </summary>
        public DataTable User;
    }
}

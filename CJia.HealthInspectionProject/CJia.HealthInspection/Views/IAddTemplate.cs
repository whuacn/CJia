using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.HealthInspection.Views
{
    public interface IAddTemplate : Views.IAddCheckTitle
    {
        event EventHandler<AddTemplateArgs> OnSaveTemplate;
        event EventHandler<AddTemplateArgs> OnSmlTemplateChange;
        void ExeBindCheckTitle(DataTable data);
    }
    public class AddTemplateArgs : AddCheckTitleArgs
    {
        /// <summary>
        /// 小分类id
        /// </summary>
        public string SmallTemplateID;
        /// <summary>
        /// 模板名称
        /// </summary>
        public string TemplateName;
        /// <summary>
        /// 模板中检查题目数据源
        /// </summary>
        public DataTable CheckTitleToTempData;

        /// <summary>
        /// 所属组织流水号
        /// </summary>
        public string OrganId;
    }
}

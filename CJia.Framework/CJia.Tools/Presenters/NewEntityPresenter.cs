using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.Tools.Presenters
{
    public class NewEntityPresenter:CJia.Presenter<Views.INewEntityView>
    {
        public Models.NewEntityModel Model
        { get; private set; }

        public NewEntityPresenter(Views.INewEntityView view)
            : base(view)
        {
            this.Model = new Models.NewEntityModel();
        }

        protected override void OnViewSet()
        {
            this.View.Load += View_Load;
            this.View.Refresh += View_Refresh;
            this.View.Save += View_Save;
            this.View.Create += View_Create;
            this.View.FillMessage += View_FillMessage;
        }

        void View_FillMessage(object sender, EventArgs e)
        {
            string selectTableName = this.View.SelectionTableName;
            DataTable table = Model.GetTable(this.View.DataSource, this.View.UserAccound, this.View.SelectionTableName);
            this.View.TableName = this.View.SelectionTableName;
            this.View.ClassName = Model.GetFieldName(this.View.SelectionTableName) + "DataEntity";
            this.View.EntityExplain = table.Rows[0]["COMMENTS"].ToString();
        }

        string GetCode(DataTable cols)
        {
            StringBuilder formWork = new StringBuilder(this.View.FormWork);
            formWork = formWork.Replace("[命名空间]", this.View.NameSpaceName.Trim());
            formWork = formWork.Replace("[实体说明]", this.View.EntityExplain.Trim());
            formWork = formWork.Replace("[表名]", this.View.TableName.Trim());
            formWork = formWork.Replace("[类名]", this.View.ClassName.Trim());
            string colsFieldCode = Model.GetColsFieldCode(cols);
            formWork = formWork.Replace("[字段定义]", colsFieldCode);
            string colsAttributeCode = Model.GetColsAttributeCode(cols);
            formWork = formWork.Replace("[属性定义]", colsAttributeCode);
            return formWork.ToString();
        }

        bool TableIsNull(DataTable table)
        {
            if(table != null && table.Rows != null || table.Rows.Count != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        void View_Create(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.View.NameSpaceName)
                && !string.IsNullOrEmpty(this.View.ClassName)
                && !string.IsNullOrEmpty(this.View.TableName)
                && !string.IsNullOrEmpty(this.View.EntityExplain)
                && !string.IsNullOrEmpty(this.View.DataSource)
                && !string.IsNullOrEmpty(this.View.UserAccound))
            {
                DataTable cols = Model.GetTableSchema(this.View.DataSource, this.View.UserAccound, this.View.TableName);
                if(!TableIsNull(cols))
                {
                    string code = GetCode(cols);
                    this.View.FillCod(code);
                }
                else
                {
                    this.View.ShowMessage("未找到该数据源下的该用户名的该表或该视图信息！");
                }
            }
            else
            {
                this.View.ShowMessage("信息填写不完整！ 生成时数据源、用户名、命名空间、类名、表名、实体说明不能为空");
            }
        }

        void View_Save(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.View.NameSpaceName)
                && !string.IsNullOrEmpty(this.View.ClassName)
                && !string.IsNullOrEmpty(this.View.TableName)
                && !string.IsNullOrEmpty(this.View.EntityExplain)
                && !string.IsNullOrEmpty(this.View.SavaPath)
                && !string.IsNullOrEmpty(this.View.DataSource)
                && !string.IsNullOrEmpty(this.View.UserAccound))
            {
                DataTable cols = Model.GetTableSchema(this.View.DataSource, this.View.UserAccound, this.View.TableName);
                if(!TableIsNull(cols))
                {
                    string code = GetCode(cols);
                    StreamWriter writer = File.CreateText(this.View.SavaPath + this.View.ClassName + ".cs");
                    writer.Write(code);
                    writer.Dispose();
                    this.View.ShowMessage("保存实体成功！实体保存在" + this.View.SavaPath + this.View.ClassName + ".cs");
                }
                else
                {
                    this.View.ShowMessage("未找到该数据源下的该用户名的该表或该视图信息！");
                }
            }
            else
            {
                this.View.ShowMessage("信息填写不完整！ 保存时数据源、用户名、命名空间、类名、表名、实体说明、保存路径不能为空");
            }
        }

        void View_Refresh(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.View.DataSource)
                && !string.IsNullOrEmpty(this.View.UserAccound))
            {
                DataTable tables = this.Model.GetTableList(this.View.DataSource, this.View.UserAccound);
                if(!TableIsNull(tables))
                {
                    this.View.FillGcvTables(tables);
                }
                else
                {
                    this.View.ShowMessage("未找到该数据源下的该用户的表与视图信息！");
                }
            }
            else
            {
                this.View.ShowMessage("信息填写不完整！ 数据源、用户名不能为空！");
            }
        }

        void View_Load(object sender, EventArgs e)
        {
            Dictionary<string, List<string>> DBConfig = this.Model.GetDBConfig();
            this.View.ListDataSource(DBConfig);
        }
    }
}

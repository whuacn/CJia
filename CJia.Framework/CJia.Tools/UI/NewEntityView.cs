using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CJia.Tools.UI
{
    public partial class NewEntityView : DevExpress.XtraEditors.XtraUserControl, Views.INewEntityView
    {
        public NewEntityView()
        {
            InitializeComponent();
        }

        // 服务器数据库配置
        private Dictionary<string, List<string>> DBConfig
        {
            get;
            set;
        }

        protected object CreatePresenter()
        {
            return new Presenters.NewEntityPresenter(this);
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Refresh(sender, e);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Save(sender, e);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.Create(sender, e);
        }

        private void gctTables_DoubleClick(object sender, EventArgs e)
        {
            this.FillMessage(sender, e);
        }

        public string GetName(string name)
        {
            string[] strs = name.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder result = new StringBuilder();
            foreach(string str in strs)
            {
                result.Append(str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower());
            }
            return result.ToString();
        }

        #region INewEntityView 成员

        public string UserAccound
        {
            get
            {
                return this.txtUserCode.Text.ToUpper();
            }
        }

        public string DataSource
        {
            get
            {
                return this.cmbDataSource.Text;
            }
        }

        public string NameSpaceName
        {
            get
            {
                return this.edtNameSpace.Text;
            }
        }

        public string ClassName
        {
            get
            {
                return this.edtEntityName.Text;
            }
            set
            {
                this.edtEntityName.Text = value;
            }
        }

        public string TableName
        {
            get
            {
                return this.edtTableName.Text;                
            }
            set
            {
                this.edtTableName.Text = value;
            }
        }

        public string SelectionTableName
        {
            get
            {
                return gdvTables.GetFocusedDataRow()["表名"].ToString();
            }
        }

        public string EntityExplain
        {
            get
            {
                return this.edtComments.Text;                
            }
            set
            {
                this.edtComments.Text = value;
            }
        }

        public string SavaPath
        {
            get
            {
                return this.edtSavePath.Text;                
            }
        }

        public string FormWork
        {
            get
            {
                return this.txtTemplate.Text;
            }
        }

        public new event EventHandler Refresh;

        public event EventHandler Save;

        public event EventHandler Create;

        public event EventHandler FillMessage;

        public void ListDataSource(Dictionary<string, List<string>> dbConfig)
        {
            this.DBConfig = dbConfig;
            this.cmbClinctSystem.Properties.Items.AddRange(this.DBConfig.Keys);
            if(this.DBConfig.Count >= 0)
            {
                this.cmbClinctSystem.SelectedIndex = 0;
            }
        }


        public void FillGcvTables(DataTable tables)
        {
            this.gctTables.DataSource = tables;
        }

        public void FillCod(string code)
        {
            this.txtCodePreview.Text = code;
        }

        public void ShowMessage(string errorMessage)
        {
            MessageBox.Show(errorMessage);
        }

        #endregion

        private void cmbClinctSystem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
    #region Old
    /*
          private DataEntity.TColumns tColumn = new ESoSi.Test.DataEntity.TColumns();
        private void viewTable_DoubleClick(object sender, EventArgs e)
        {
            if (viewTable.FocusedRowHandle < 0) return;
            string TabName = this.viewTable.FocusedValue.ToString();

            string SqlText = String.Format(SQL_GET_TABLE_COLUMNS, TabName);

            tColumn.Query(SqlText);
            
            this.gridColumns.DataSource = tColumn.EntitySet;
            this.viewColumns.OptionsBehavior.Editable = true;
            for (int i = 0; i <= tColumn.Count - 1; i++ )
            {
                tColumn[i].PropertyName = CovertToCommonName(tColumn[i].ColumnName);
            }

            this.edtTableName.Text = TabName;

            int t = TabName.IndexOf(".");
            if (t > 0) TabName = TabName.Substring(t + 1);

            this.edtEntityName.Text = CovertToCommonName(TabName);
        }

        private string CovertToCommonName(string ColName)
        {
            ColName = ColName.ToLower();
            ColName = ColName.Substring(0, 1).ToUpper() + ColName.Substring(1);
            
            while (ColName.IndexOf("_") > 0)
            {
                int i = ColName.IndexOf("_");
                ColName = ColName.Substring(0, i) + ColName.Substring(i + 1, 1).ToUpper() + ColName.Substring(i + 2);
            }
            return ColName;
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            this.txtCodePreview.Text = this.txtTemplate.Text;
            txtCodePreview.Text = txtCodePreview.Text.Replace("[命名空间]", edtNameSpace.Text);
            txtCodePreview.Text = txtCodePreview.Text.Replace("[表名]", this.edtTableName.Text);
            txtCodePreview.Text = txtCodePreview.Text.Replace("[实体名]", this.edtEntityName.Text);
            txtCodePreview.Text = txtCodePreview.Text.Replace("[说明]", this.edtComments.Text);

            StringBuilder sbProperty = new StringBuilder();
            StringBuilder sbColumns = new StringBuilder();
            for (int i = 0; i <= tColumn.Count - 1; i++)
            {
                sbColumns.Append("\t/// <summary>\n");
                sbColumns.Append("\t/// " + tColumn[i].Comments + "\n");
                sbColumns.Append("\t/// </summary>\n");
                sbColumns.Append("\tpublic static string " + tColumn[i].ColumnName + " = \"" + tColumn[i].ColumnName + "\";\n");

                sbProperty.Append("\t/// <summary>\n");
                sbProperty.Append("\t/// "+tColumn[i].Comments+"\n");
                sbProperty.Append("\t/// </summary>\n");
                sbProperty.Append("\t[Field(Name=\"" + tColumn[i].ColumnName + "\", Caption=\"" + tColumn[i].ChineseName + "\"");
                switch(tColumn[i].DataType)
                {
                    case "VARCHAR2": sbProperty.Append(",MaxLength=" + tColumn[i].DataLength); break;
                    case "NUMBER": sbProperty.Append(",DataType=typeof(decimal)"); break;
                    case "DATE": sbProperty.Append(",DataType=typeof(DateTime)"); break;
                }
                if (tColumn[i].Nullable == "N")
                {
                    sbProperty.Append(",Nullable=false");
                }
                if (tColumn[i].Constraint == "P")
                {
                    sbProperty.Append(",isPrimaryKey=true");
                }
                sbProperty.Append(")]\n");
                sbProperty.Append("\tpublic string " + tColumn[i].PropertyName+"\n");
                sbProperty.Append("\t{\n");
                sbProperty.Append("\t\tget { return Get(); }\n");
                sbProperty.Append("\t\tset { Set(value); }\n");
                sbProperty.Append("\t}\n");
            }
            txtCodePreview.Text = txtCodePreview.Text.Replace("[字段定义]", sbColumns.ToString()); 
            txtCodePreview.Text = txtCodePreview.Text.Replace("[属性定义]", sbProperty.ToString());          
        }

        private void frmBuildEntity_Load(object sender, EventArgs e)
        {
            edtSavePath.Text = Application.StartupPath;
        }

        private void edtSavePath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.dialogSave.ShowDialog() == DialogResult.OK)
            {
                this.edtSavePath.Text = this.dialogSave.SelectedPath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.edtSavePath.Text)) return;
            string SavePath = this.edtSavePath.Text;
            if (SavePath.Substring(SavePath.Length - 1) != "\\")
            {
                SavePath += "\\";
            }
            txtCodePreview.SaveFile(SavePath + this.edtEntityName.Text + ".cs", System.Windows.Forms.RichTextBoxStreamType.PlainText);
        }
        */
    #endregion
}

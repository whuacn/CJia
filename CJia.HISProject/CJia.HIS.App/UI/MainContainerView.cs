using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Linq.Expressions;
using System.Configuration;
using System.Reflection;

namespace CJia.HIS.App.UI
{
    public partial class MainContainerView : CJia.HIS.View, Views.IMainContainerView
    {
        public Dictionary<string, object> ShortcutKeyDic = new Dictionary<string, object>();

        public MainContainerView()
        {
            InitializeComponent();
            this.Init(null, null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.MainContainerPresenter(this);
        }

        #region Tab �ؼ�����
        private void ShowPage(string Title, DevExpress.XtraEditors.XtraUserControl ucPage)
        {
            DevExpress.XtraTab.XtraTabPage xtraPage = new DevExpress.XtraTab.XtraTabPage();
            xtraPage.Text = Title;
            xtraPage.Controls.Add(ucPage);
            ucPage.Dock = DockStyle.Fill;
            this.xtcMain.TabPages.Add(xtraPage);
            this.xtcMain.SelectedTabPage = xtraPage;
        }
        private bool isExistPage(string PageTitle)
        {
            for(int i = 0; i < this.xtcMain.TabPages.Count; i++)
            {
                if(this.xtcMain.TabPages[i].Text == PageTitle)
                {
                    this.xtcMain.SelectedTabPageIndex = i;
                    return true;
                }
            }
            return false;
        }
        #endregion

        // �л�ϵͳ
        private void menSelete_Click(object sender, EventArgs e)
        {
            CJia.HIS.App.Tools.ShowForm.ShowSelectSytem();
        }

        // ע��
        private void menLogout_Click(object sender, EventArgs e)
        {
            CJia.HIS.App.Tools.ShowForm.ShowLogin();
        }

        // �˳�ϵͳ
        private void menExit_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        // ϵͳ�汾����Ϣ
        private void menAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CJia.HIS.SystemInfo.loginSystem["SYSTEM_ABOUT"].ToString(), "ϵͳ��Ϣ");
        }

        // ϵͳ������Ϣ
        private void menHelpInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CJia.HIS.SystemInfo.loginSystem["SYSTEM_HELP"].ToString(), "ϵͳ������Ϣ");
        }

        // ��ݼ�����
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if((keyData & Keys.Control) == Keys.Control)
            {
                string downKey = keyData.ToString();
                try
                {
                    if(this.ShortcutKeyDic[downKey] != null)
                    {
                        if(this.ShortcutKeyDic[downKey] is System.Windows.Forms.ToolStripButton)
                        {
                            System.Windows.Forms.ToolStripButton toolStripButton = this.ShortcutKeyDic[downKey] as System.Windows.Forms.ToolStripButton;
                            if(toolStripButton.Tag.ToString() != "")
                            {
                                this.ModuleId = toolStripButton.Tag.ToString();
                                this.MenuClickEven(null, null);
                            }
                        }
                    }
                }
                catch(KeyNotFoundException knfe)
                {
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
            // ��ݼ�����
        }


        #region IMainContainerView ��Ա

        #region ��ʼ���˵���
        DataTable menus = null;

        private string moduleId;
        /// <summary>
        /// ��ȡ�����Ĳ˵�id
        /// </summary>
        public string ModuleId
        {
            get
            {
                return moduleId;
            }
            private set
            {
                moduleId = value;
            }
        }

        /// <summary>
        /// ��ʼ���˵���
        /// </summary>
        public void IntiMenu(DataTable result)
        {
            this.menus = result;
            DataTable newResult = result.Clone();
            foreach(DataRow row in result.Rows)
            {
                if(row["SUP_MENU_ID"] == null || row["SUP_MENU_ID"] == DBNull.Value)
                {
                    DataRow newRow = newResult.NewRow();
                    this.Cope(row, newRow);
                    this.InsertDataTable(newResult, newRow, "MENU_SORT");
                }
            }
            foreach(DataRow row in newResult.Rows)
            {
                ToolStripMenuItem toolstripItem = new ToolStripMenuItem(row["MENU_NAME"].ToString() + "(&" + row["MENU_SHORTCUT_KEY"].ToString() + ")");
                toolstripItem.Tag = row["MODULE_ID"].ToString();
                toolstripItem.Click += toolstripItem_Click;
                this.menMain.Items.Insert(this.menMain.Items.Count - 1, toolstripItem);
                this.InsertSon(row, toolstripItem);
            }
        }

        //�˵������¼�
        void toolstripItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem roolStripMenuItem = sender as ToolStripMenuItem;
            if(roolStripMenuItem.Tag.ToString() != "")
            {
                this.ModuleId = roolStripMenuItem.Tag.ToString();
                this.MenuClickEven(sender, e);
            }
        }

        /// <summary>
        /// ���Լ����Ӳ˵����뵽�Լ��Ӳ˵���
        /// </summary>
        /// <param name="row"></param>
        /// <param name="toolstripItem"></param>
        private void InsertSon(DataRow father, ToolStripMenuItem fatherToolstripItem)
        {
            DataTable sonMenus = this.menus.Clone();
            foreach(DataRow row in this.menus.Rows)
            {
                if(row["SUP_MENU_ID"].ToString() == father["MENU_ID"].ToString())
                {
                    DataRow newRow = sonMenus.NewRow();
                    this.Cope(row, newRow);
                    this.InsertDataTable(sonMenus, newRow, "MENU_SORT");
                }
            }
            foreach(DataRow row in sonMenus.Rows)
            {
                ToolStripMenuItem sonToolstripItem = new ToolStripMenuItem(row["MENU_NAME"].ToString() + "(&" + row["MENU_SHORTCUT_KEY"].ToString() + ")");
                sonToolstripItem.Tag = row["MODULE_ID"].ToString();
                sonToolstripItem.Click += toolstripItem_Click;
                fatherToolstripItem.DropDownItems.Add(sonToolstripItem);
                this.InsertSon(row, sonToolstripItem);
            }
        }

        /// <summary>
        /// ���Ƶ�һ��row�е����ݵ��ڶ���row��
        /// </summary>
        /// <param name="row"></param>
        /// <param name="newRow"></param>
        private void Cope(DataRow row, DataRow newRow)
        {
            for(int i = 0; i < row.ItemArray.Length; i++)
            {
                newRow[i] = row[i];
            }
        }

        /// <summary>
        /// ��row����table�а�sort��������
        /// </summary>
        /// <param name="table">Ҫ����ı�</param>
        /// <param name="row">���������</param>
        /// <param name="sort">������</param>
        private void InsertDataTable(DataTable table, DataRow row, string sort)
        {
            if(table.Rows.Count == 0)
            {
                table.Rows.Add(row);
            }
            else
            {
                for(int i = 0; i < table.Rows.Count; i++)
                {
                    if(int.Parse(row[sort].ToString()) <= int.Parse(table.Rows[i][sort].ToString()))
                    {
                        table.Rows.Add(row);
                        return;
                    }
                }
                table.Rows.Add(row);
            }
        }

        #endregion

        #region ��ģ��

        /// <summary>
        /// ����module����Ӧ��ģ��
        /// </summary>
        /// <param name="module"></param>
        public DevExpress.XtraEditors.XtraUserControl OpenModule(DataTable module)
        {
            if(module != null && module.Rows != null && module.Rows.Count > 0)
            {
                object userControl = CJia.HIS.App.Tools.Reflection.GetInstance(
                                         module.Rows[0]["ASSEMBLY"].ToString()
                                         , module.Rows[0]["CLASSNAME"].ToString()
                                         , new object[0]);
                DevExpress.XtraEditors.XtraUserControl usercon = userControl as DevExpress.XtraEditors.XtraUserControl;
                int newHeight = this.Size.Height < usercon.Size.Height + 120 ? usercon.Size.Height + 120 : this.Size.Height;
                int newWidth = this.Size.Width < usercon.Size.Width + 10 ? usercon.Size.Width + 10 : this.Size.Width;
                this.ParentForm.Size = new Size(newWidth, newHeight);
                this.Size = new Size(newWidth, newHeight);
                if(!this.isExistPage(module.Rows[0]["MODULE_NAME"].ToString()))
                {
                    this.ShowPage(module.Rows[0]["MODULE_NAME"].ToString(), usercon);
                }
                return usercon;
            }
            return null;
        }

        #endregion

        #region IMainContainerView�¼�
        /// <summary>
        /// ��ʼ��ʱִ��
        /// </summary>
        public event EventHandler Init;
        /// <summary>
        /// �˵����ݹ����������¼�
        /// </summary>
        public event EventHandler MenuClickEven;
        #endregion

        #region ��ʼ����ݲ�����

        /// <summary>
        /// ��ʼ����ݲ˵�
        /// </summary>
        /// <param name="result"></param>
        public void IntiTool(DataTable result)
        {
            DataTable newResult = result.Clone();
            foreach(DataRow row in result.Rows)
            {
                DataRow newRow = newResult.NewRow();
                this.Cope(row, newRow);
                this.InsertDataTable(newResult, newRow, "TOOL_SORT");
            }
            foreach(DataRow row in newResult.Rows)
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainContainerView));
                ToolStripButton toolStripButton = new ToolStripButton();
                if(row["TOOL_IMAGE"].ToString() == "" && row["TOOL_NAME"].ToString() == "")
                {
                    toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.None;
                }
                else if(row["TOOL_IMAGE"].ToString() != "" && row["TOOL_NAME"].ToString() == "")
                {
                    toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
                    string a = row["TOOL_IMAGE"].ToString();
                    toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject(row["TOOL_IMAGE"].ToString())));
                }
                else if(row["TOOL_IMAGE"].ToString() == "" && row["TOOL_NAME"].ToString() != "")
                {
                    toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
                    toolStripButton.Text = row["TOOL_NAME"].ToString();
                }
                else
                {
                    toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    toolStripButton.Text = row["TOOL_NAME"].ToString();
                    string a = row["TOOL_IMAGE"].ToString();
                    toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject(row["TOOL_IMAGE"].ToString())));
                }
                toolStripButton.Tag = row["MODULE_ID"].ToString();
                toolStripButton.Click += toolStripButton_Click;
                if(row["TOOL_SHORTCUT_KEY"].ToString() != "")
                {
                    toolStripButton.ToolTipText = row["TOOL_NAME"].ToString() + "(CTRL + " + row["TOOL_SHORTCUT_KEY"].ToString() + " )";
                    HISMainForm hisMainForm = this.ParentForm as HISMainForm;
                    this.ShortcutKeyDic.Add(row["TOOL_SHORTCUT_KEY"].ToString().ToUpper() + ", Control", toolStripButton);
                }
                this.tolMain.Items.Add(toolStripButton);
            }
        }


        // ��ݲ˵������¼��󶨷���
        void toolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripButton roolStripMenuItem = sender as ToolStripButton;
            if(roolStripMenuItem.Tag.ToString() != "")
            {
                this.ModuleId = roolStripMenuItem.Tag.ToString();
                this.MenuClickEven(sender, e);
            }
        }

        #endregion

        #region ��ʼ��Ĭ��ģ����Ϣ

        /// <summary>
        /// ��ʼ��Ĭ��ģ��
        /// </summary>
        /// <param name="module">Ĭ��ģ��</param>
        public void initDefaultPage(DataTable module)
        {
            DevExpress.XtraEditors.XtraUserControl userCon = this.OpenModule(module);
        }


        #endregion

        #endregion




    }
}

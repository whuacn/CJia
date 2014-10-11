using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.Task
{
    public partial class EditTask : CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.IEditTask
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (!IsPostBack)
            {
                SetInit();
                editTaskArgs.EditTaskId = Request.QueryString["EditTaskID"];
                Session["SelectedTemplateNameEdit"] = null;
                OnInit(null,editTaskArgs);
                dropTaskType_SelectedIndexChanged(null, null);
            }
            if (Session["SelectedTemplateNameEdit"] != null)
            {
                txtTempName.Text = Session["SelectedTemplateNameEdit"].ToString();
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.EditTaskPresenter(this);
        }

        Views.EditTaskArgs editTaskArgs = new Views.EditTaskArgs();

        #region【虚方法实现】
        /// <summary>
        /// 实现虚方法
        /// </summary>
        /// <returns></returns>
        protected override bool InitPage()
        {
            this.B_gr_Main = gridFiles;
            return true;
        }
        #endregion

        #region 【界面事件】
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (dpkStart.SelectedDate > dpkEnd.SelectedDate)
            {
                Alert.Show("开始时间不得大于结束时间！");
                return;
            }
            editTaskArgs.EditTaskId = Request.QueryString["EditTaskId"];
            editTaskArgs.TaskName = txtTaskName.Text;
            editTaskArgs.TemplateId = Session["SelectedTemplateIdEdit"].ToString();
            editTaskArgs.TaskTypeId = dropTaskType.SelectedValue;
            editTaskArgs.OrganName = txtOrganName.Text;
            editTaskArgs.StartDate = dpkStart.SelectedDate;
            editTaskArgs.EndDate = dpkEnd.SelectedDate;
            editTaskArgs.CheckScord = txtCheckScode.Text;
            editTaskArgs.Remark = txtRemark.Text;
            editTaskArgs.User = (DataTable)Session["User"];
            if (Convert.ToBoolean(Session["IsExistOragnAdd"]) && txtOrganName.Text == "")
            {
                txtOrganName.Required = true;
                Alert.ShowInTop("请填写下达机构！");
                return;
            }
            
            UploadFiles();
            editTaskArgs.DeleteFilesId = Session["DeletedFiles"] as List<string>;
            OnSave(null, editTaskArgs);
        }

        // 选择模版事件
        protected void btnSelectTemp_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("SelectTemplate.aspx?status=2", "选择模版")); 
        }

        protected void dropTaskType_SelectedIndexChanged(object sender, EventArgs e)
        {
            editTaskArgs.SelectedDropTaskTypeId = Convert.ToInt64(dropTaskType.SelectedValue);
            OnSelectedDropTaskType(null, editTaskArgs);
            Session["IsExistOragnAdd"] = editTaskArgs.IsExistOragnEdit;
            if (!Convert.ToBoolean(Session["IsExistOragnAdd"]))
            {
                txtOrganName.Text = "";
                txtOrganName.Readonly = true;
            }
            else
            {
                txtOrganName.Readonly = false;
            }
        }


        // 添加文件到Grid
        protected void btnAddFile_Click(object sender, EventArgs e)
        {
            if (fupFile.FileName != "")
            {
                // 新添加的文件
                if (Session["DicFileEdit"] == null)
                {
                    Session["DicFileEdit"] = new Dictionary<int, HttpPostedFile>();
                }
                // 如果原任务没有文件
                if (ViewState["DataSource"] == null)
                {
                    DataTable dtData = new DataTable();
                    dtData.Columns.Add("file_no", typeof(string));
                    dtData.Columns.Add("file_name", typeof(string));
                    dtData.Columns.Add("data_type", typeof(string));
                    DataRow dr = dtData.NewRow();
                    dr["file_no"] = 1;
                    dr["file_name"] = fupFile.FileName;
                    dr["data_type"] = "new";
                    dtData.Rows.Add(dr);
                    gridFiles.DataSource = dtData;
                    gridFiles.DataBind();
                    ViewState["DataSource"] = dtData;

                    Dictionary<int, HttpPostedFile> dicPostFile = new Dictionary<int, HttpPostedFile>();
                    dicPostFile.Add(1,fupFile.PostedFile);
                    //List<HttpPostedFile> list1 = new List<HttpPostedFile>();
                    //list1.Add(fupFile.PostedFile);
                    Session["DicFileEdit"] = dicPostFile;
                }
                else
                {
                    DataTable dtSource = (DataTable)ViewState["DataSource"];
                    Dictionary<int, HttpPostedFile> a = Session["DicFileEdit"] as Dictionary<int, HttpPostedFile>;
                    a.Add(dtSource.Rows.Count + 1, fupFile.PostedFile);
                    Session["DicFileEdit"] = a;

                    DataRow drn = dtSource.NewRow();
                    drn["file_no"] = dtSource.Rows.Count + 1;
                    drn["file_name"] = fupFile.FileName;
                    drn["data_type"] = "new";
                    dtSource.Rows.Add(drn);
                    gridFiles.DataSource = dtSource;
                    gridFiles.DataBind();
                    ViewState["DataSource"] = dtSource;
                }
            }
        }

        // 删除附件
        protected void gridFiles_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] keys = this.gridFiles.DataKeys[e.RowIndex];
            // 此次所要删除的ID
            List<string> fileId;
            // 原本库中所存文件 此次所要删除的ID
            if (Session["DeletedFiles"] == null)
            {
                fileId = new List<string>();
            }
            else
            {
                fileId = Session["DeletedFiles"] as List<string>;
            }
            switch (e.CommandName)
            {
                case "Delete":
                    DataTable dtData = (DataTable)ViewState["DataSource"];

                    // 删除行
                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        if (dtData.Rows[i]["file_no"].ToString() == keys[0].ToString())
                        {
                            // 如果界面上移除的是存在数据库中的文件
                            if (dtData.Rows[i]["data_type"].ToString() == "old")
                            {
                                fileId.Add(dtData.Rows[i]["file_id"].ToString());
                                Session["DeletedFiles"] = fileId;
                            }
                            // 如果移除的是新添加的文件
                            else
                            {
                                Dictionary<int, HttpPostedFile> a = Session["DicFileEdit"] as Dictionary<int, HttpPostedFile>;
                                a.Remove(int.Parse(keys[0].ToString()));
                                Session["DicFileEdit"] = a;
                            }
                            dtData.Rows.Remove(dtData.Rows[i]);
                        }
                    }
                    // 重新排序
                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        dtData.Rows[i]["file_no"] = i + 1;
                    }
                    gridFiles.DataSource = dtData;
                    gridFiles.DataBind();
                    ViewState["DataSource"] = dtData;
                    break;
            }
        }
        #endregion

        #region 【自定义方法】
        /// <summary>
        /// 上传控件
        /// </summary>
        void UploadFiles()
        {
            if (ViewState["DataSource"] != null)
            {
                DataTable dtData = (DataTable)ViewState["DataSource"];
                if (dtData.Rows.Count > 0)
                {
                    // 所选择的全部文件
                    Dictionary<int, HttpPostedFile> dicFiles = Session["DicFileEdit"] as Dictionary<int, HttpPostedFile>;
                    // 所要保存文件的服务器路径
                    string serverPath = Server.MapPath("~\\UploadFiles");
                    // 文件名称
                    string fileName = "";
                    //上传路径
                    string filePath = "";
                    if (!Directory.Exists(serverPath))
                    {
                        // 创建文件夹  
                        Directory.CreateDirectory(serverPath);
                    }
                    foreach (KeyValuePair<int, HttpPostedFile> item in dicFiles)
                    {
                        fileName = item.Value.FileName;
                        filePath = serverPath + "\\" + fileName;
                        // 判断路径下是否存在相同文件名
                        if (File.Exists(filePath))
                        {
                            string fileExtensition = System.IO.Path.GetExtension(fileName);//扩展名
                            fileName = fileName.Remove(fileName.LastIndexOf(".")); // 去掉扩展名的路径
                            //OnFileSeq(null, editTaskArgs);
                            //filePath = serverPath + "\\" + fileName + editTaskArgs.FileSeq + fileExtensition;
                            string guid = Guid.NewGuid().ToString();
                            filePath = serverPath + "\\" + fileName + guid + fileExtensition;
                            fileName = fileName + guid + fileExtensition;
                        }
                        editTaskArgs.FileName.Add(fileName);
                        editTaskArgs.FilePath.Add("UploadFiles/" + fileName);
                        try
                        {
                            item.Value.SaveAs(filePath);
                        }
                        catch (Exception ex)
                        {
                            Alert.Show(ex.ToString());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 置空
        /// </summary>
        void SetInit()
        {
            Session["DeletedFiles"] = null;
            ViewState["DataSource"] = null;
            Session["DicFileEdit"] = null;
        }
        #endregion

        #region 【接口实现】
        /// <summary>
        /// 绑定界面所选任务相关信息
        /// </summary>
        /// <param name="dtTask"></param>
        public void ExeBindControl(DataTable dtTask)
        {
            DataRow dr = dtTask.Rows[0];
            txtTaskName.Text = dr["task_name"].ToString();
            Session["SelectedTemplateIdEdit"] = Convert.ToInt64(dr["template_id"]);
            txtTempName.Text = dr["template_name"].ToString();
            dropTaskType.Text = dr["task_type_name"].ToString();
            dropTaskType.SelectedValue = dr["task_type_id"].ToString();
            txtOrganName.Text = dr["organ_name"].ToString();
            dpkStart.SelectedDate = (DateTime)dr["start_date"];
            dpkEnd.SelectedDate = (DateTime)dr["end_date"];
            txtCheckScode.Text = dr["check_scode"].ToString();
            txtRemark.Text = dr["remark"].ToString();
        }

        /// <summary>
        /// 绑定任务类型
        /// </summary>
        /// <param name="dtTaskType"></param>
        public void ExeDropTaskType(DataTable dtTaskType)
        {
            dropTaskType.DataSource = dtTaskType;
            dropTaskType.DataTextField = "TASK_TYPE_NAME";
            dropTaskType.DataValueField = "TASK_TYPE_ID";
            dropTaskType.DataBind();
        }

        /// <summary>
        /// 绑定Grid文件
        /// </summary>
        /// <param name="dtFiles"></param>
        public void ExeGridFile(DataTable dtFiles)
        {
            // 添加一列标志列“data_type”，new代表新添加的数据；old代表从数据库查询出来的数据
            dtFiles.Columns.Add("file_no",typeof(string));
            dtFiles.Columns.Add("data_type",typeof(string));
            for (int i = 0; i < dtFiles.Rows.Count;i++ )
            {
                dtFiles.Rows[i]["file_no"] = i + 1;
                dtFiles.Rows[i]["data_type"] = "old";
            }
            InitGrid(dtFiles);
            ViewState["DataSource"] = dtFiles;
        }

        /// <summary>
        /// 保存是否成功
        /// </summary>
        /// <param name="bol"></param>
        public void ExeIsSaveSuccess(bool bol)
        {
            if (bol)
            {
                Alert.ShowInTop("修改成功！", "提示对话框", ActiveWindow.GetHidePostBackReference());
            }
            else
            {
            Alert.ShowInTop("修改失败，请与管理员联系……！", "提示对话框");
            }
        }
        #endregion

        #region 【接口事件】

        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.EditTaskArgs> OnInit;

        /// <summary>
        /// 下拉选择任务类型
        /// </summary>
        public event EventHandler<Views.EditTaskArgs> OnSelectedDropTaskType;

        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.EditTaskArgs> OnSave;

        ///// <summary>
        ///// 查询文件Seq，重命名上传文件夹名称
        ///// </summary>
        //public event EventHandler<Views.EditTaskArgs> OnFileSeq;

        #endregion
    }
}
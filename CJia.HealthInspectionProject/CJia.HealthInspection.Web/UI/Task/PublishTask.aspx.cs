using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.Task
{
    public partial class PublishTask : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.IPublishTask
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetInit();
                Session["SelectedTemplateNameAdd"] = null;
                OnInit(null, null);
                dropTaskType_SelectedIndexChanged(null, null);
            }
            if (Session["SelectedTemplateNameAdd"] != null)
            {
                txtTempName.Text = Session["SelectedTemplateNameAdd"].ToString();
            }
        }


        protected override object CreatePresenter()
        {
            return new Presenters.PublishTaskPresenter(this);
        }

        Views.PublishTaskArgs publishArg = new Views.PublishTaskArgs();

        #region 【界面事件】
        protected void btnSelectTemp_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(win_Edit.GetShowReference("SelectTemplate.aspx?status=1", "选择模版"));
        }

        protected void dropTaskType_SelectedIndexChanged(object sender, EventArgs e)
        {
            publishArg.SelectedDropTaskTypeId = Convert.ToInt64(dropTaskType.SelectedValue);
            OnSelectedDropTaskType(null, publishArg);
            Session["IsExistOragnAdd"] = publishArg.IsExistOragnAdd;
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
                //for (int i = 0; i < gridFiles.Rows.Count; i++)
                //{
                //    string strKey = gridFiles.Rows[i].Values[0].ToString();
                //    //string subStr = str.Substring(str.IndexOf(">") + 1, str.LastIndexOf(">"));
                //    string subStrKey = strKey.Substring(strKey.IndexOf('>') + 1, strKey.LastIndexOf('<') - strKey.IndexOf('>') - 1);
                //    string strName = gridFiles.Rows[i].Values[1].ToString();
                //    //string subStr = str.Substring(str.IndexOf(">") + 1, str.LastIndexOf(">"));
                //    string subStrName = strName.Substring(strName.IndexOf('>') + 1, strName.LastIndexOf('<') - strName.IndexOf('>') - 1);
                //    dtData.Rows.Add(subStrKey, subStrName);
                //}

                // 如果是第一次添加文件
                if (ViewState["DataSource"] == null)
                {
                    DataTable dtData = new DataTable();
                    dtData.Columns.Add("file_id", typeof(string));
                    dtData.Columns.Add("file_name", typeof(string));
                    DataRow dr = dtData.NewRow();
                    dr["file_id"] = 1;
                    dr["file_name"] = fupFile.FileName;
                    dtData.Rows.Add(dr);
                    gridFiles.DataSource = dtData;
                    gridFiles.DataBind();
                    ViewState["DataSource"] = dtData;

                    List<HttpPostedFile> list1 = new List<HttpPostedFile>();
                    list1.Add(fupFile.PostedFile);
                    Session["ListFile"] = new List<HttpPostedFile>();
                    Session["ListFile"] = list1;
                }
                else
                {
                    DataTable dtSource = (DataTable)ViewState["DataSource"];
                    DataRow drn = dtSource.NewRow();
                    drn["file_id"] = dtSource.Rows.Count + 1;
                    drn["file_name"] = fupFile.FileName;
                    dtSource.Rows.Add(drn);
                    gridFiles.DataSource = dtSource;
                    gridFiles.DataBind();
                    ViewState["DataSource"] = dtSource;

                    List<HttpPostedFile> a = Session["ListFile"] as List<HttpPostedFile>;
                    a.Add(fupFile.PostedFile);
                    Session["ListFile"] = a;
                }
            }
        }

        // 删除附件
        protected void gridFiles_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] keys = this.gridFiles.DataKeys[e.RowIndex];
            switch (e.CommandName)
            {
                case "Delete":
                    DataTable dtData = (DataTable)ViewState["DataSource"];
                    // 删除行
                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        if (dtData.Rows[i]["file_id"].ToString() == keys[0].ToString())
                        {
                            dtData.Rows.Remove(dtData.Rows[i]);
                            List<HttpPostedFile> a = Session["ListFile"] as List<HttpPostedFile>;
                            a.RemoveAt(i);
                            Session["ListFile"] = a;
                        }
                       
                    }
                    // 重新排序
                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        dtData.Rows[i]["file_id"] = i + 1;
                    }
                    gridFiles.DataSource = dtData;
                    gridFiles.DataBind();
                    ViewState["DataSource"] = dtData;
                    break;
            }
        }

        // 保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (dpkStart.SelectedDate > dpkEnd.SelectedDate)
            {
                Alert.Show("开始时间不得大于结束时间！");
                return;
            }
            publishArg.TaskName = txtTaskName.Text;
            publishArg.TemplateId = Session["SelectedTemplateIdAdd"].ToString();
            publishArg.TaskType = dropTaskType.SelectedValue;
            publishArg.OrganName = txtOrganName.Text;
            publishArg.StartDate = dpkStart.SelectedDate;
            publishArg.EndDate = dpkEnd.SelectedDate;
            publishArg.CheckScord = txtCheckScode.Text;
            publishArg.Remark = txtRemark.Text;
            publishArg.User = (DataTable)Session["User"];

            if (Convert.ToBoolean(Session["IsExistOragnAdd"]) && txtOrganName.Text == "")
            {
                txtOrganName.Required = true;
                Alert.ShowInTop("请填写下达机构！");
                return;
            }
            UploadFiles();
            OnSave(null, publishArg);
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
                    List<HttpPostedFile> listFiles = Session["ListFile"] as List<HttpPostedFile>;
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
                    for (int i = 0; i < listFiles.Count; i++)
                    {
                        fileName = listFiles[i].FileName;
                        filePath = serverPath + "\\"+ fileName;
                        // 判断路径下是否存在相同文件名
                        if (File.Exists(filePath))
                        {
                            string fileExtensition = System.IO.Path.GetExtension(fileName);//扩展名
                            fileName = fileName.Remove(fileName.LastIndexOf(".")); // 去掉扩展名的路径
                            //OnFileSeq(null, publishArg);
                            //filePath = serverPath + "\\" + fileName + publishArg.FileSeq + fileExtensition;
                            string guid = Guid.NewGuid().ToString();
                            filePath = serverPath + "\\" + fileName + guid +fileExtensition;
                            fileName = fileName + guid  + fileExtensition;
                        }
                        publishArg.FileName.Add(fileName);
                        publishArg.FilePath.Add("UploadFiles/" + fileName);
                        try
                        {
                            listFiles[i].SaveAs(filePath);
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
            Session["ListFile"] = null;
            ViewState["DataSource"] = null;
        }
        #endregion

        #region 【接口实现】
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
        /// 保存是否成功
        /// </summary>
        /// <param name="bol"></param>
        public void ExeIsSaveSuccess(bool bol)
        {
            if (bol)
            {
                Alert.ShowInTop("添加成功！", "提示对话框", "location.href=location.href;");
            }
            else
            {
                Alert.ShowInTop("添加失败，请与管理员联系……！", "提示对话框");
            }
        }
        #endregion

        #region 【接口事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.PublishTaskArgs> OnInit;

        ///// <summary>
        ///// 查询文件Seq，重命名上传文件夹名称
        ///// </summary>
        //public event EventHandler<Views.PublishTaskArgs> OnFileSeq;

        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.PublishTaskArgs> OnSave;

        /// <summary>
        /// 下拉选择任务类型
        /// </summary>
        public event EventHandler<Views.PublishTaskArgs> OnSelectedDropTaskType;
        #endregion

        #region 【委托例子】
        //protected void btnSelectTemp_Click1(object sender, EventArgs e)
        //{
        //    PageContext.RegisterStartupScript(win_Edit.GetShowReference("SelectTemplate.aspx", "选择模版"));
        //    SelectTemplate s = new SelectTemplate();
        //    s.OnChange += s_OnChange;

        //}

        //void s_OnChange(object sender, EventArgs e)
        //{
        //    txtTempName.Text = Common.SelectedTemplateName;
        //}
        #endregion
    }
}
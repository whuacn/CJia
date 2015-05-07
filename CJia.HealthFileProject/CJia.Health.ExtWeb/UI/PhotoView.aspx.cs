using CJia.Health.Tools;
using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.Health.ExtWeb.UI
{
    public partial class PhotoView : CJia.Health.Tools.Page, CJia.Health.Views.Web.IMyPictureView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    if (Request.QueryString["ID"] != null)
                    {
                        if (OnLoadPicture != null)
                        {
                            string healthID = Request.QueryString["ID"].ToString();
                            myPictureArgs.HealthID = healthID;
                            OnLoadPicture(sender, myPictureArgs);
                        }
                    }
                }
            }
        }
        protected override object CreatePresenter()
        {
            return new Presenters.Web.MyPicturePresenter(this);
        }
        /// <summary>
        /// 参数
        /// </summary>
        Views.Web.MyPictureArgs myPictureArgs = new Views.Web.MyPictureArgs();

        #region IMyPictureView成员
        public event EventHandler<Views.Web.MyPictureArgs> OnLoadPicture;
        public event EventHandler<Views.Web.MyPictureArgs> OnProjectChanged;
        public void ExeBindPicture(DataTable data)
        {
            BindPatient(data);
            gr_project.DataSource = data;
            gr_project.DataBind();
        }
        public void ExeBindProject(DataTable data)
        {

        }
        public void ExeBindPictureByProjectID(DataTable data)
        {

        }
        #endregion

        #region 内部调用方法
        /// <summary>
        /// 绑定病人
        /// </summary>
        public void BindPatient(DataTable data)
        {
            DataRow dr = data.Rows[0];
            lblRecordNO.Text = dr["RECORDNO"].ToString();
            lblTimes.Text = dr["IN_HOSPITAL_TIME"].ToString();
            lblName.Text = dr["PATIENT_NAME"].ToString();
            lblGender.Text = dr["GENDER_NAME"].ToString();
            lblBirthDay.Text = dr["BIRTHDAY2"].ToString();
        }
        #endregion
        private void GetPicture(int rowIndex)
        {
            DataTable userData = Session["User"] as DataTable;
            string userID = userData.Rows[0]["USER_ID"].ToString();
            string userName = userData.Rows[0]["USER_NAME"].ToString();
            object[] keys = this.gr_project.DataKeys[rowIndex];
            string HostName = ConfigHelper.GetAppStrings("ftp_ip");
            string UserName = Utils.AESDecrypt(ConfigHelper.GetAppStrings("ftp_userName"));
            string Password = Utils.AESDecrypt(ConfigHelper.GetAppStrings("ftp_password"));
            string uri = "ftp://" + HostName + "/" + keys[1].ToString() + "/" + keys[2].ToString();
            string path = Server.MapPath("/") + @"Cache";
            try
            {
                string fileName = keys[2].ToString();
                string name = fileName.Replace(".pdf", "");
                string downLoadFile = path + "\\" + fileName;
                string pdfData = downLoadFile.Replace(".pdf", "");
                string waterText = Tools.Help.GetAddressIP() + " " + userName + " " + DateTime.Now.ToString();
                string picSave = pdfData + "_" + userID + ".Jpeg";
                if (File.Exists(pdfData + ".Jpeg"))
                {
                    if (File.Exists(pdfData + "_" + userID + ".Jpeg"))
                    {
                        pimg.ImageUrl = "../Cache/" + name + "_" + userID + ".Jpeg";
                        pimg.ImageWidth = new Unit(730);
                        return;
                    }
                    else
                    {
                        Tools.Help.AddWaterText(pdfData + ".Jpeg", picSave, waterText, Help.WaterPositionMode.Center, "Red", 100);
                        pimg.ImageUrl = "../Cache/" + name + "_" + userID + ".Jpeg";
                        pimg.ImageWidth = new Unit(730);
                        return;
                    }
                }
                bool bol = CJia.Health.Tools.Help.DownLoadFileByUri(uri, path, UserName, Password);
                if (bol)
                {
                    CJia.Health.Tools.PDFHelp.ConvertPDF2Image(pdfData, PDFPassword, 1, 1, ImageFormat.Jpeg, PDFHelp.Definition.One);
                    File.Delete(pdfData);
                    Tools.Help.AddWaterText(pdfData + ".Jpeg", picSave, waterText, Help.WaterPositionMode.Center, "Red", 100);
                    pimg.ImageUrl = "../Cache/" + name + "_" + userID + ".Jpeg";
                    pimg.ImageWidth = new Unit(730);
                }
                else
                {
                    Alert.Show("此图片不存在或已删除，请与管理员联系。。。");
                }
            }
            catch { }
        }
        protected void gr_project_RowClick(object sender, ExtAspNet.GridRowClickEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                GetPicture(e.RowIndex);
            }
        }

        protected void btnBig_Click(object sender, EventArgs e)
        {
            if (pimg.ImageUrl.Length > 0)
            {
                Unit u = pimg.ImageWidth;
                pimg.ImageWidth = new Unit(u.Value + 50);
            }
        }

        protected void BtnSmall_Click(object sender, EventArgs e)
        {
            if (pimg.ImageUrl.Length > 0)
            {
                Unit u = pimg.ImageWidth;
                if (u.Value - 50 >= 730)
                    pimg.ImageWidth = new Unit(u.Value - 50);
            }
        }

        protected void btnFirst_Click(object sender, EventArgs e)
        {
            if (gr_project.Rows.Count > 0)
            {
                GetPicture(0);
                gr_project.SelectedRowIndexArray = new int[] { 0 };
            }
        }

        protected void btnPre_Click(object sender, EventArgs e)
        {
            if (gr_project.Rows.Count > 0)
            {
                int[] index = gr_project.SelectedRowIndexArray;
                if (index.Length > 0)
                {
                    if (index[0] > 0)
                    {
                        GetPicture(index[0] - 1);
                        gr_project.SelectedRowIndexArray = new int[] { index[0] - 1 };
                    }
                }
                else
                {
                    GetPicture(0);
                    gr_project.SelectedRowIndexArray = new int[] { 0 };
                }
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (gr_project.Rows.Count > 0)
            {
                int[] index = gr_project.SelectedRowIndexArray;
                if (index.Length > 0)
                {
                    if (index[0] < gr_project.Rows.Count - 1)
                    {
                        GetPicture(index[0] + 1);
                        gr_project.SelectedRowIndexArray = new int[] { index[0] + 1 };
                    }
                }
                else
                {
                    GetPicture(0);
                    gr_project.SelectedRowIndexArray = new int[] { 0 };
                }
            }
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            if (gr_project.Rows.Count > 0)
            {
                GetPicture(gr_project.Rows.Count - 1);
                gr_project.SelectedRowIndexArray = new int[] { gr_project.Rows.Count - 1 };
            }
        }
    }
}
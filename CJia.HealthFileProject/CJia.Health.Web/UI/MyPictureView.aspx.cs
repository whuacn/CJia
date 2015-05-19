using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CJia.Health.Web.UI
{
    public partial class MyPictureView : CJia.Health.Tools.Page, CJia.Health.Views.Web.IMyPictureView
    {
        public int PageSize = 1;
        public int curpage = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bool bol = true;// CJia.Health.Tools.Help.Connect("127.0.0.1", "deng", "asdfghjkl;'");
                if (OnLoadPicture != null && bol)
                {
                    string healthID = Request.QueryString["id"].ToString();
                    myPictureArgs.HealthID = healthID;
                    OnLoadPicture(sender, myPictureArgs);
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
        public void ExeBindPicture(DataTable data, DataTable patInfo)
        {
            if (data != null)
            {
                CJia.Health.User.PictureData = data;
                BindPatient();
                BindPicture();
                lblMsg.Visible = false;
            }
            else
            {
                lblMsg.Visible = true;
                pictureTab.Visible = false;
            }
        }
        public void ExeBindProject(DataTable data)
        {
            if (data != null)
            {
                lbProject.DataSource = data;
                lbProject.DataTextField = "PRO_NAME";
                lbProject.DataValueField = "PRO_ID";
                lbProject.DataBind();
                lblAmount.Text = data.Rows.Count.ToString();
            }
        }
        public void ExeBindPictureByProjectID(DataTable data)
        {
            if (data != null)
            {
                CJia.Health.User.PictureData = data;
                BindPicture();
            }
        }
        #endregion

        #region 内部调用方法
        /// <summary>
        /// 绑定病人
        /// </summary>
        public void BindPatient()
        {
            DataTable PictureData = CJia.Health.User.PictureData;
            lblRecordNO.Text = PictureData.Rows[0]["RECORDNO"].ToString();
            lblPatientName.Text = PictureData.Rows[0]["PATIENT_NAME"].ToString();
            lblGender.Text = PictureData.Rows[0]["GENDER_NAME"].ToString();
            lblBirth.Text = DateTime.Parse(PictureData.Rows[0]["BIRTHDAY"].ToString()).ToShortDateString();
            lblJob.Text = PictureData.Rows[0]["JOB_NAME"].ToString();
            lblInHosState.Text = PictureData.Rows[0]["IN_HOSPITAL_TYPE_NAME"].ToString();
            lblInHosDept.Text = PictureData.Rows[0]["IN_HOSPITAL_DEPT_NAME"].ToString();
            //lblOutHosDoctor.Text = PictureData.Rows[0]["OUT_HOSPITAL_DOCTOR_NAME"].ToString();
            if (PictureData.Rows[0]["OUTDIA_NAME1"] != null)
            {
                lblCYZD.Text = PictureData.Rows[0]["OUTDIA_NAME1"].ToString();
            }
            else if (PictureData.Rows[0]["OUTDIA_NAME2"] != null)
            {
                lblCYZD.Text = PictureData.Rows[0]["OUTDIA_NAME2"].ToString();
            }
            else if (PictureData.Rows[0]["OUTDIA_NAME3"] != null)
            {
                lblCYZD.Text = PictureData.Rows[0]["OUTDIA_NAME3"].ToString();
            }
            else if (PictureData.Rows[0]["OUTDIA_NAME4"] != null)
            {
                lblCYZD.Text = PictureData.Rows[0]["OUTDIA_NAME4"].ToString();
            }
            if (PictureData.Rows[0]["SURGERY_NAME1"] != null)
            {
                lblSSMC.Text = PictureData.Rows[0]["SURGERY_NAME1"].ToString();
            }
            else if (PictureData.Rows[0]["SURGERY_NAME2"] != null)
            {
                lblSSMC.Text = PictureData.Rows[0]["SURGERY_NAME2"].ToString();
            }
            else if (PictureData.Rows[0]["SURGERY_NAME3"] != null)
            {
                lblSSMC.Text = PictureData.Rows[0]["SURGERY_NAME3"].ToString();
            }
            else if (PictureData.Rows[0]["SURGERY_NAME4"] != null)
            {
                lblSSMC.Text = PictureData.Rows[0]["SURGERY_NAME4"].ToString();
            }
            if (PictureData.Rows[0]["YNGR_NAME1"] != null)
            {
                lblYNGR.Text = PictureData.Rows[0]["YNGR_NAME1"].ToString();
            }
            else if (PictureData.Rows[0]["YNGR_NAME2"] != null)
            {
                lblYNGR.Text = PictureData.Rows[0]["YNGR_NAME2"].ToString();
            }
        }
        /// <summary>
        /// 绑定图片
        /// </summary>
        public void BindPicture()
        {
            curpage = Convert.ToInt32(labPage.Text);
            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = CJia.Health.User.PictureData.DefaultView;
            ps.AllowPaging = true; //是否可以分页
            ps.PageSize = PageSize; //显示的数量
            ps.CurrentPageIndex = curpage - 1; //取得当前页的页码
            lnkbtnUp.Enabled = true;
            lnkbtnNext.Enabled = true;
            lnkbtnBack.Enabled = true;
            lnkbtnOne.Enabled = true;
            if (curpage == 1)
            {
                lnkbtnOne.Enabled = false;//不显示第一页按钮
                lnkbtnUp.Enabled = false;//不显示上一页按钮
            }
            if (curpage == ps.PageCount)
            {
                lnkbtnNext.Enabled = false;//不显示下一页
                lnkbtnBack.Enabled = false;//不显示最后一页
            }
            this.labBackPage.Text = Convert.ToString(ps.PageCount);
            pictureList.DataSource = ps;
            pictureList.DataBind();
        }
        /// <summary>
        /// 获得图片路径
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public string GetSrc(string src)
        {
            //string ipPath = CJia.Health.Tools.ConfigHelper.GetAppStrings("IP_PATH");
            ////string pathSrc = "..\\images" + "\\" + src;
            //string pathSrc = ipPath + src;
            //return pathSrc;
            //string str = "";
            //str = ("http://192.168.1.6:8090/" + src).Replace('\\', '/');
            return "~/CheckCode.aspx?id=" + src;
            //return str;
        }
        #endregion

        protected void lnkbtnOne_Click(object sender, EventArgs e)
        {
            labPage.Text = "1";
            BindPicture();
        }

        protected void lnkbtnUp_Click(object sender, EventArgs e)
        {
            labPage.Text = Convert.ToString(Convert.ToInt32(labPage.Text) - 1);
            BindPicture();
        }

        protected void lnkbtnNext_Click(object sender, EventArgs e)
        {
            labPage.Text = Convert.ToString(Convert.ToInt32(labPage.Text) + 1);
            BindPicture();
        }

        protected void lnkbtnBack_Click(object sender, EventArgs e)
        {
            labPage.Text = labBackPage.Text;
            BindPicture();
        }

        protected void lbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbProject.SelectedValue != null)
            {
                if (OnProjectChanged != null)
                {
                    labPage.Text = "1";
                    string healthID = Request.QueryString["id"].ToString();
                    myPictureArgs.HealthID = healthID;
                    myPictureArgs.ProjectID = lbProject.SelectedValue;
                    OnProjectChanged(sender, myPictureArgs);
                }
            }
        }

    }
}
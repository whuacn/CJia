using CJia.Health.Views.Web;
using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.Health.ExtWeb.UI
{
    public partial class MyQuery : CJia.Health.Tools.Page, Views.Web.IQueryPatientView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    if (OnInit != null)
                    {
                        OnInit(null, null);
                    }
                    //InitMyFav();
                }
            }
        }
        private void InitMyFav()
        {
            if (Session["User"] != null)
            {
                DataTable userData = Session["User"] as DataTable;
                DataTable myFav = GetMyfavourite(userData.Rows[0]["USER_ID"].ToString());
                DataRow dr = myFav.NewRow();
                dr["FAVORITES_NAME"] = "<<请选择收藏夹>>";
                dr["FAVORITES_ID"] = "0";
                myFav.Rows.InsertAt(dr, 0);
                BindDropDownDate(dlMyFav, myFav, "FAVORITES_NAME", "FAVORITES_ID");
            }
        }
        protected override object CreatePresenter()
        {
            return new Presenters.Web.QueryPatientPresenter(this);
        }
        Views.Web.QueryPatientArgs queryPatientArgs = new Views.Web.QueryPatientArgs();
        #region IQueryPatientView成员
        public event EventHandler<QueryPatientArgs> OnApply;
        public void ExeBindPatient(DataTable data)
        {
            Session["MyQuery"] = new DataTable();
            Session["MyQuery"] = data;
            InitGrid(data);
        }
        public event EventHandler<QueryPatientArgs> OnFavourite;
        public void ExeBindIsFav(bool bol)
        {
            if (bol)
            {
                Alert.ShowInTop("收藏成功");
                win_MyFav.Hidden = true;
            }
            else
            {
                Alert.ShowInTop("收藏失败");
            }
        }
        public event EventHandler OnInit;
        public event EventHandler<Views.Web.QueryPatientArgs> OnProviceChanged;
        public event EventHandler<Views.Web.QueryPatientArgs> OnDeptChanged;
        public void ExeBind(DataTable icdData, DataTable zlData, DataTable dept, DataTable provice)
        {
            if (dept != null && dept.Rows.Count > 0)
            {
                DataRow dr = dept.NewRow();
                dr["DEPT_NAME"] = "全部";
                dr["DEPT_ID"] = "0";
                dept.Rows.InsertAt(dr, 0);
            }
            BindDropDownDate(cbRYKS, dept, "DEPT_NAME", "DEPT_ID");
            BindDropDownDate(cbCYKS, dept, "DEPT_NAME", "DEPT_ID");
        }
        public void ExeBindCity(DataTable data)
        {

        }
        public void ExeBIndDoctor(DataTable data, int i)
        {

        }
        public event EventHandler<Views.Web.QueryPatientArgs> OnSelect;
        public void ExeBindSelectRecord(DataTable data)
        {
            Session["MyQuery"] = new DataTable();
            Session["MyQuery"] = data;
            InitGrid(data);
        }
        #endregion

        #region 内部调用方法
        /// <summary>
        /// 绑定有关icd值得显示
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="data"></param>
        public void BindDropDownDate(ExtAspNet.DropDownList cb, DataTable data, string dataTextField, string dataValueField)
        {
            if (data != null)
            {
                cb.DataSource = data;
                cb.DataTextField = dataTextField;
                cb.DataValueField = dataValueField;
                cb.DataBind();
            }
        }
        /// <summary>
        /// 获得查询条件
        /// </summary>
        public MyPatient GetUserSelect()
        {
            MyPatient patient = new MyPatient();
            if (txtRecordNO.Text.Trim().Length > 0)
            {
                patient.RecordNO = txtRecordNO.Text.Trim();
            }
            if (startDate.Text.Trim().Length > 0 && endDate.Text.Trim().Length > 0)
            {
                DateTime date = DateTime.Parse(startDate.Text.Trim());
                DateTime date1 = DateTime.Parse(endDate.Text.Trim());
                patient.StartDate = DateTime.Parse(date.Year.ToString() + "/" + date.Month.ToString() + "/" + date.Day.ToString());
                patient.EndDate = DateTime.Parse(date1.Year.ToString() + "/" + date1.Month.ToString() + "/" + date1.Day.ToString());
            }
            if (CYZD.Text.Trim().Length > 0)
            {
                patient.CYZD = CYZD.Text.Trim();
            }
            if (SSMC.Text.Trim().Length > 0)
            {
                patient.SSMC = SSMC.Text.Trim();
            }
            if (txtPatientName.Text.Trim().Length > 0)
            {
                patient.PatientName = txtPatientName.Text.Trim();
            }
            if (cbRYKS.SelectedValue.Length > 0 && cbRYKS.SelectedValue != "0")
            {
                patient.RYDept = cbRYKS.SelectedValue;
            }
            if (cbCYKS.SelectedValue.Length > 0 && cbCYKS.SelectedValue != "0")
            {
                patient.CYDept = cbCYKS.SelectedValue;
            }
            return patient;
        }
        public void InitGrid(DataTable data)
        {
            if (data != null)
            {
                PagedDataSource ps = new PagedDataSource();
                ps.DataSource = data.DefaultView;
                ps.AllowPaging = true; //是否可以分页
                ps.PageSize = gr_Main.PageSize; //显示的数量
                ps.CurrentPageIndex = gr_Main.PageIndex; //取得当前页的页码
                gr_Main.RecordCount = data.Rows.Count;
                gr_Main.DataSource = ps;
                gr_Main.DataBind();
            }
        }
        #endregion

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            if (OnSelect != null && Session["User"] != null)
            {
                gr_Main.PageIndex = 0;
                queryPatientArgs.Patient = GetUserSelect();
                queryPatientArgs.UserData = Session["User"] as DataTable;
                OnSelect(sender, queryPatientArgs);
            }
        }

        protected void btnResert_Click(object sender, EventArgs e)
        {
            txtRecordNO.Text = "";
            txtPatientName.Text = "";
            startDate.Text = "";
            endDate.Text = "";
            CYZD.Text = "";
            SSMC.Text = "";
            cbCYKS.SelectedValue = "0";
            cbRYKS.SelectedValue = "0";
        }

        protected void gr_Main_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {

            object[] keys = this.gr_Main.DataKeys[e.RowIndex];
            switch (e.CommandName)
            {
                case "Info":
                    if (Session["User"] != null)
                    {
                        PageContext.RegisterStartupScript(win_Edit.GetShowReference("PatientInfoView.aspx?ID=" + keys[0].ToString(), "基本信息"));
                    }
                    else
                    {
                        Alert.ShowInTop("连接超时，请刷新页面！");
                    }
                    break;
                case "Favorite":
                    if (Session["User"] != null)
                    {
                        string userID = (Session["User"] as DataTable).Rows[0]["USER_ID"].ToString();
                        bool bol = GetMyFavouriteByUserID(userID, keys[0].ToString());
                        if (!bol)
                        {
                            InitMyFav();
                            win_MyFav.Hidden = false;
                        }
                        else
                        {
                            Alert.ShowInTop("你已收藏！");
                        }
                    }
                    else
                    {
                        Alert.ShowInTop("连接超时，请刷新页面！");
                    }
                    break;
                case "Apply":
                    if (Session["User"] != null)
                    {
                        win_Reson.Hidden = false;
                    }
                    else
                    {
                        Alert.ShowInTop("连接超时，请刷新页面！");
                    }
                    break;
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (this.gr_Main.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请选择病案！");
                return;
            }
            string[] ids = new string[this.gr_Main.SelectedRowIndexArray.Length];
            for (int i = 0; i < this.gr_Main.SelectedRowIndexArray.Length; i++)
            {
                ids[i] = this.gr_Main.DataKeys[this.gr_Main.SelectedRowIndexArray[i]][0].ToString();
            }
            string reson = txtReson.Text.Trim();
            if (reson.Length > 0 && reson.Length < 51)
            {
                win_Reson.Hidden = true;
                queryPatientArgs.HealthIDList = ids.ToList();
                queryPatientArgs.Patient = GetUserSelect();
                queryPatientArgs.UserData = Session["User"] as DataTable;
                queryPatientArgs.Reason = reson;
                OnApply(null, queryPatientArgs);
            }
            else
                Alert.ShowInTop("请填写申请原因且长度不能超过50！");
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            if (this.gr_Main.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请选择病案！");
                return;
            }
            win_Reson.Hidden = false;
        }

        protected void gr_Main_PageIndexChange(object sender, GridPageEventArgs e)
        {
            if (Session["MyQuery"] != null)
            {
                this.gr_Main.PageIndex = e.NewPageIndex;
                DataTable dt = Session["MyQuery"] as DataTable;
                this.InitGrid(dt);
            }
        }

        protected void btnAddNewFav_Click(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                if (txtFavName.Text.Length > 0 && txtFavName.Text.Length < 11)
                {
                    string userID = (Session["User"] as DataTable).Rows[0]["USER_ID"].ToString();
                    string str = AddMyfavourite(userID, txtFavName.Text);
                    if (str == "2")
                    {
                        Alert.ShowInTop("新增成功");
                        txtFavName.Text = string.Empty;
                        InitMyFav();
                    }
                    else if (str == "1")
                        Alert.ShowInTop("新增失败，存在相同的收藏夹名称");
                    else
                        Alert.ShowInTop("新增失败");
                }
                else
                {
                    Alert.ShowInTop("收藏夹名称不能为空且长度必须小于10个字符");
                }
            }
            else
            {
                Alert.ShowInTop("连接超时，请刷新页面");
            }
        }

        protected void btnAllFav_Click(object sender, EventArgs e)
        {
            if (this.gr_Main.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请选择病案！");
                return;
            }
            else
            {

            }
            win_MyFav.Hidden = false;
        }

        protected void btnMyFav_Click(object sender, EventArgs e)
        {
            string[] ids = new string[this.gr_Main.SelectedRowIndexArray.Length];
            for (int i = 0; i < this.gr_Main.SelectedRowIndexArray.Length; i++)
            {
                ids[i] = this.gr_Main.DataKeys[this.gr_Main.SelectedRowIndexArray[i]][0].ToString();
            }
            string favID = dlMyFav.SelectedValue;
            if (favID.Length > 0 && favID != "0")
            {
                queryPatientArgs.HealthIDList = ids.ToList();
                queryPatientArgs.UserData = Session["User"] as DataTable;
                queryPatientArgs.FavouriteID = favID;
                OnFavourite(null, queryPatientArgs);
                dlMyFav.SelectedValue = "0";
            }
            else
            {
                Alert.ShowInTop("请选择收藏夹");
            }
        }

        protected void gr_Main_PreRowDataBound(object sender, GridPreRowEventArgs e)
        {
            LinkButtonField lbfEdit = gr_Main.FindColumn("lbf_fav") as LinkButtonField;
            LinkButtonField lbfApply = gr_Main.FindColumn("lbf_Apply") as LinkButtonField;
            DataTable userData = Session["User"] as DataTable;
            string userDaptID = userData.Rows[0]["DEPT_ID"].ToString();
            DataRowView dv = e.DataItem as DataRowView;
            DataRow dr = dv.Row;
            string inHos = dr["IN_HOSPITAL_DEPT"].ToString();
            string outHos = dr["OUT_HOSPITAL_DEPT"].ToString();
            if (userDaptID == inHos || userDaptID == outHos)
            {
                lbfEdit.Enabled = true;
                lbfApply.Enabled = false;
            }
            else
            {
                lbfEdit.Enabled = false;
                lbfApply.Enabled = true;
            }
        }

    }
}
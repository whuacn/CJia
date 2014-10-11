using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace CJia.Evaluation.Web.Backstage
{
    public partial class AddData : CJia.Evaluation.Tools.Page, CJia.Evaluation.Views.Backstage.IAddData
    {
        CJia.Evaluation.Views.Backstage.AddDataArgs addDataArgs = new Views.Backstage.AddDataArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnInitDataType(null, null);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.Backstage.AddDataPresenter(this);
        }

        #region【事件方法】
        protected void btn_Add_Data_Click(object sender, EventArgs e)
        {
            DataTable dtUser = Session["User"] as DataTable;
            addDataArgs.ColumnTreeId = Request.QueryString["ColumnTreeId"].ToString();
            Session["RefhColumnID"] = Request.QueryString["ColumnTreeId"].ToString();
            string strHtml = HttpUtility.UrlDecode(ckedit_add.Text);
            string strReplaceFile = strHtml.Replace(">/ckfinder/userfiles/files/", ">");
            addDataArgs.DataContent = strReplaceFile;
            addDataArgs.DataTitle = txt_Data_Name.Text;
            addDataArgs.DataType = ddl_Data_Type.SelectedValue;
            addDataArgs.UserID = dtUser.Rows[0]["USER_ID"].ToString();
            OnAddData(null, addDataArgs);
        }

        protected void btn_Cancle_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion

        #region【实现接口】
        public event EventHandler<Views.Backstage.AddDataArgs> OnInitDataType;

        public event EventHandler<Views.Backstage.AddDataArgs> OnAddData;

        public void ExeReturnMsg(bool bl)
        {
            if (!bl)
            {
                ExtAspNet.Alert.ShowInTop("添加失败！", ExtAspNet.MessageBoxIcon.Error);
            }
            else
            {
                Session["IsRefhData"] = "1";
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
        }

        public void ExeBindDataType(System.Data.DataTable dtDataType)
        {
            ddl_Data_Type.DataValueField = "TYPE_ID";
            ddl_Data_Type.DataTextField = "TYPE_VALUE";
            ddl_Data_Type.DataSource = dtDataType;
            ddl_Data_Type.DataBind();
        }
        #endregion


        
    }
}
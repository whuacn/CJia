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
    public partial class EditData : CJia.Evaluation.Tools.Page, CJia.Evaluation.Views.Backstage.IEditData
    {
        CJia.Evaluation.Views.Backstage.EditArgs editArgs = new Views.Backstage.EditArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["OperType"] != null && Request.QueryString["OperType"].ToString() == "Select")
            {
                btn_Save_Data.Hidden = true;
                ddl_Data_Type.Readonly = true;
                txt_Data_Name.Readonly = true;
                CKEditorControl1.ReadOnly = true;
            }
            if (!IsPostBack)
            {
                editArgs.DataID = Request.QueryString["DataId"].ToString();
                OnQueryDataById(null, editArgs);
                OnInitDataType(null, null);
            }
            //CKEditorControl1.Text = "<p style='text-align: center;'><span style='color:#FF0000'>Hello Word</span></p>";
        }

        protected override object CreatePresenter()
        {
            return new Presenters.Backstage.EditDataPresenter(this);
        }

        #region【页面事件】
        protected void btn_Save_Data_Click(object sender, EventArgs e)
        {
            DataTable dtUser = Session["User"] as DataTable; 
            editArgs.DataID = Request.QueryString["DataId"].ToString();
            editArgs.DataTitle = txt_Data_Name.Text;
            editArgs.DataContent = CKEditorControl1.Text;
            editArgs.UserId = dtUser.Rows[0]["USER_ID"].ToString();
            editArgs.DataType = ddl_Data_Type.SelectedValue;
            OnUpdateData(null, editArgs);
        }

        protected void btn_Cancle_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion

        #region【实现接口】
        public event EventHandler<Views.Backstage.EditArgs> OnInitDataType;

        public event EventHandler<Views.Backstage.EditArgs> OnQueryDataById;

        public event EventHandler<Views.Backstage.EditArgs> OnUpdateData;

        public void ExeReturnMsg(bool bl)
        {
            if (!bl)
            {
                ExtAspNet.Alert.ShowInTop("修改失败！", ExtAspNet.MessageBoxIcon.Error);
            }
            else
            {
                ExtAspNet.Alert.ShowInTop("保存成功！", ExtAspNet.MessageBoxIcon.Information);
                editArgs.DataID = Request.QueryString["DataId"].ToString();
                OnQueryDataById(null, editArgs);
            }
        }

        public void ExeBindData(System.Data.DataTable dtData)
        {
            if (dtData != null && dtData.Rows != null && dtData.Rows.Count > 0)
            {
                txt_Data_Name.Text = dtData.Rows[0]["DATA_NAME"].ToString();
                ddl_Data_Type.SelectedValue = dtData.Rows[0]["DATA_TYPE"].ToString();
                CKEditorControl1.Text = dtData.Rows[0]["DATA_CONTENT"].ToString();
            }
            else
            {
                ExtAspNet.Alert.ShowInTop("没有查到信息", ExtAspNet.MessageBoxIcon.Warning);
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
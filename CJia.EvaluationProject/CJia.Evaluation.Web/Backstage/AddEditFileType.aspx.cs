using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.Evaluation.Web.Backstage
{
    public partial class AddFileType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["OperType"].ToString() == "Update")
                {
                    txt_TypeValue.Text = Request.QueryString["TypeValue"].ToString();
                }
            }
        }

        protected bool AddFileTypeData(string TypeValue)
        {
            using (Adapter ad = new Adapter())
            {
                object[] sqlParams = new object[1] { TypeValue };
                return ad.Execute(@"insert into gm_type(type_code, type_name, type_value, type_id,status)
                                                    values('10','资料类别',?,gm_type_seq.nextval,'1')", sqlParams) > 0 ? true : false;
            }
        }

        protected bool EditFileTypeData(string TypeID, string TypeValue)
        {
            using (Adapter ad = new Adapter())
            {
                object[] sqlParams = new object[2] { TypeValue, TypeID };
                return ad.Execute(@"update gm_type set type_value=? where type_id=?", sqlParams) > 0 ? true : false;
            }
        }


        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["OperType"].ToString() == "Insert")
            {
                bool bol = AddFileTypeData(txt_TypeValue.Text);
                if (bol)
                {
                    PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
                }
                else
                {
                    ExtAspNet.Alert.ShowInTop("保存失败！", ExtAspNet.MessageBoxIcon.Error);
                }
            }
            else if (Request.QueryString["OperType"].ToString() == "Update")
            {
                bool bol = EditFileTypeData(Request.QueryString["TypeID"].ToString(), txt_TypeValue.Text);
                if (bol)
                {
                    PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
                }
                else
                {
                    ExtAspNet.Alert.ShowInTop("保存失败！", ExtAspNet.MessageBoxIcon.Error);
                }
            }
        }


    }
}
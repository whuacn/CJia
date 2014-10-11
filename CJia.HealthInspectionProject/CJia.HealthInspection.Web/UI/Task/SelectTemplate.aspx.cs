using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.Task
{
    public partial class SelectTemplate : CJia.HealthInspection.Tools.Page, CJia.HealthInspection.Views.ISelectTemplate
    {
        Views.SelectTemplateArgs selectTempArgs = new Views.SelectTemplateArgs();
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (!IsPostBack)
            {
                selectTempArgs.OrganId = Convert.ToInt64((Session["User"] as DataTable).Rows[0]["ORGAN_ID"]);
                OnInit(null, selectTempArgs);
                dropBig_SelectedIndexChanged(null, null);
                dropMiddle_SelectedIndexChanged(null, null);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.SelectTemplatePresenter(this);
        }

        #region 【界面事件】
        protected void dropBig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropBig.SelectedValue == "0")
            {
                dropMiddle.Items.Clear();
                dropMiddle.Items.Insert(0, new ExtAspNet.ListItem("全部", "0"));
                dropMiddle.SelectedValue = "0";
                dropSmall.Items.Clear();
                dropSmall.Items.Insert(0, new ExtAspNet.ListItem("全部", "0"));
                dropSmall.SelectedValue = "0";
            }
            else
            {
                selectTempArgs.SelectedBigTempId = dropBig.SelectedValue;
                OnDropBigSelectedChanged(null, selectTempArgs);
                dropMiddle_SelectedIndexChanged(null, null);
            }
        }

        protected void dropMiddle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropMiddle.SelectedValue == "0" || dropMiddle.SelectedValue==null)
            {
                dropSmall.Items.Clear();
                dropSmall.Items.Insert(0, new ExtAspNet.ListItem("全部", "0"));
                dropSmall.SelectedValue = "0";
            }
            else
            {
                selectTempArgs.SelectedMiddleTempId = dropMiddle.SelectedValue;
                OnDropMiddleSelectedChanged(null, selectTempArgs);
            }
        }

        protected void gridTemp_RowDoubleClick(object sender, ExtAspNet.GridRowClickEventArgs e)
        {
            object[] key = gridTemp.DataKeys[e.RowIndex];
            if (Request.QueryString["status"] == "1")
            {
                Session["SelectedTemplateIdAdd"] = Convert.ToInt64(key[0]);
                //selectTempArgs.TempID = Convert.ToInt64(Session["SelectedTemplateIdEdit"]);
                selectTempArgs.TempIDAdd = Convert.ToInt64(key[0]);
                OnQueryTempNameByIdForAdd(null, selectTempArgs);
            }
            if (Request.QueryString["status"] == "2")
            {
                Session["SelectedTemplateIdEdit"] = Convert.ToInt64(key[0]);
                //selectTempArgs.TempID = Convert.ToInt64(Session["SelectedTemplateIdEdit"]);
                selectTempArgs.TempIDEdit = Convert.ToInt64(key[0]);
                OnQueryTempNameByIDForEdit(null, selectTempArgs);
            }
            if (Request.QueryString["status"] == "3")
            {
                Session["ExeTempID"] = Convert.ToInt64(key[0]);
                //selectTempArgs.TempID = Convert.ToInt64(Session["ExeTempID"]);
                selectTempArgs.TempIDExeTemp = Convert.ToInt64(key[0]);
                ONQueryTempNameByIdForExeCheck(null, selectTempArgs);
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference()); // 关闭当前窗口
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            selectTempArgs.OrganId = Convert.ToInt64((Session["User"] as DataTable).Rows[0]["ORGAN_ID"]);
            selectTempArgs.BigTypeID = dropBig.SelectedValue == "0" ? "" : dropBig.SelectedValue;
            selectTempArgs.MiddleTypeID = dropMiddle.SelectedValue == "0" ? "" : dropMiddle.SelectedValue;
            selectTempArgs.SmallTypeID = dropSmall.SelectedValue == "0" ? "" : dropSmall.SelectedValue;
            OnSelectTemp(null, selectTempArgs);
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (this.gridTemp.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInTop("请选择模版...");
                return;
            }
            if (Request.QueryString["status"] == "1")
            {
                Session["SelectedTemplateIdAdd"] = gridTemp.DataKeys[gridTemp.SelectedRowIndexArray[0]][0];
                //Common.SelectedTemplateIdAdd = (long)gridTemp.DataKeys[gridTemp.SelectedRowIndexArray[0]][0];
                selectTempArgs.TempIDAdd = Convert.ToInt64(gridTemp.DataKeys[gridTemp.SelectedRowIndexArray[0]][0]);
                OnQueryTempNameByIdForAdd(null, selectTempArgs);
            }
            if (Request.QueryString["status"] == "2")
            {
                Session["SelectedTemplateIdEdit"] = gridTemp.DataKeys[gridTemp.SelectedRowIndexArray[0]][0];
                //Common.SelectedTemplateIdEdit = (long)gridTemp.DataKeys[gridTemp.SelectedRowIndexArray[0]][0];
                selectTempArgs.TempIDEdit = Convert.ToInt64(gridTemp.DataKeys[gridTemp.SelectedRowIndexArray[0]][0]);
                ONQueryTempNameByIdForExeCheck(null, selectTempArgs);
            }
            if (Request.QueryString["status"] == "3")
            {
                Session["ExeTempID"] = gridTemp.DataKeys[gridTemp.SelectedRowIndexArray[0]][0];
                selectTempArgs.TempIDExeTemp = Convert.ToInt64(gridTemp.DataKeys[gridTemp.SelectedRowIndexArray[0]][0]);
                ONQueryTempNameByIdForExeCheck(null, selectTempArgs);
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            //OnChange(null, null); //【委托例子】
        }
        #endregion

        #region 【接口绑定】

        /// <summary>
        /// 绑定模版Grid
        /// </summary>
        /// <param name="dtTemplate"></param>
        public void ExeGridTemp(DataTable dtTemplate)
        {
            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = dtTemplate.DefaultView;
            ps.AllowPaging = true;
            ps.PageSize = gridTemp.PageSize;
            ps.CurrentPageIndex = gridTemp.PageIndex;
            gridTemp.RecordCount = dtTemplate.Rows.Count;
            gridTemp.DataSource = dtTemplate;
            gridTemp.DataBind();
            InitGrid(dtTemplate);
        }

        /// <summary>
        /// 绑定大分类
        /// </summary>
        /// <param name="dtBig"></param>
        public void ExeDropBig(DataTable dtBig)
        {
            BindDropDownList(dtBig, dropBig, "BIG_TEMPLATE_NAME", "BIG_TEMPLATE_ID");
            dropBig.Items.Insert(0, new ExtAspNet.ListItem("全部", "0"));
        }

        /// <summary>
        /// 绑定中分类
        /// </summary>
        /// <param name="dtMiddle"></param>
        public void ExeDropMiddle(DataTable dtMiddle)
        {
            BindDropDownList(dtMiddle, dropMiddle, "MIDDLE_TEMPLATE_NAME", "MIDDLE_TEMPLATE_ID");
            dropMiddle.Items.Insert(0, new ExtAspNet.ListItem("全部", "0"));
        }

        /// <summary>
        /// 绑定小分类
        /// </summary>
        /// <param name="dtSmall"></param>
        public void ExeDropSmall(DataTable dtSmall)
        {
            BindDropDownList(dtSmall, dropSmall, "SMALL_TEMPLATE_NAME", "SMALL_TEMPLATE_ID");
            dropSmall.Items.Insert(0, new ExtAspNet.ListItem("全部", "0"));
        }

        public void ExeGetTempNameForAdd(string TempName)
        {
            Session["SelectedTemplateNameAdd"] = TempName;
        }

        public void ExeGetTempNameForEdit(string TempName)
        {
            Session["SelectedTemplateNameEdit"] = TempName;
        }

        public void ExeGetTempNameForExeCheck(string TempName)
        {
            Session["SelectedTemplateNameExeCheck"] = TempName;
        }
        #endregion

        #region 【自定义方法】
        /// <summary>
        /// 实现虚方法
        /// </summary>
        /// <returns></returns>
        protected override bool InitPage()
        {
            this.B_gr_Main = gridTemp;
            return true;
        }

        /// <summary>
        /// 绑定下拉框数据
        /// </summary>
        /// <param name="dt">所要绑定数据源DataTable</param>
        /// <param name="dropDownList">界面控件下拉框</param>
        /// <param name="textField">显示字段</param>
        /// <param name="valueField">值字段</param>
        public void BindDropDownList(DataTable dt, ExtAspNet.DropDownList dropDownList, string textField, string valueField)
        {
            dropDownList.DataSource = dt;
            dropDownList.DataTextField = textField;
            dropDownList.DataValueField = valueField;
            dropDownList.DataBind();
        }
        #endregion

        #region 【接口事件】
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.SelectTemplateArgs> OnInit;

        /// <summary>
        /// 选择大分类事件
        /// </summary>
        public event EventHandler<Views.SelectTemplateArgs> OnDropBigSelectedChanged;

        /// <summary>
        /// 选择中分类事件
        /// </summary>
        public event EventHandler<Views.SelectTemplateArgs> OnDropMiddleSelectedChanged;

        /// <summary>
        /// 根据类型查询模版
        /// </summary>
        public event EventHandler<Views.SelectTemplateArgs> OnSelectTemp;

        public event EventHandler<Views.SelectTemplateArgs> OnQueryTempNameByIdForAdd;

        public event EventHandler<Views.SelectTemplateArgs> OnQueryTempNameByIDForEdit;

        public event EventHandler<Views.SelectTemplateArgs> ONQueryTempNameByIdForExeCheck;
        #endregion

        //public event EventHandler OnChange; //【委托例子】








        
    }
}
using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CJia.HealthInspection.Web.UI.Unit
{
    public partial class EditUnit : CJia.HealthInspection.Tools.Page,CJia.HealthInspection.Views.IEditUnit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                editUnitArgs.User = (DataTable)Session["User"];
                editUnitArgs.UnitId = Request.QueryString["EditUnitId"];
                OnInit(null, editUnitArgs);
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.EditUnitPresenter(this);
        }

        Views.EditUnitArgs editUnitArgs = new Views.EditUnitArgs();

        #region【界面事件】

        protected void btnSave_Click(object sender, EventArgs e)
        {
            editUnitArgs.UnitName = txt_unitName.Text;
            editUnitArgs.Address = txt_dizhi.Text;
            editUnitArgs.DaiMa = txt_daima.Text;
            editUnitArgs.FaRen = txt_faren.Text;
            editUnitArgs.FaRenNO = txt_farenzhenhao.Text;
            editUnitArgs.FaRenType = ddl_farenType.SelectedValue;
            editUnitArgs.FuZeRen = txt_fuzeren.Text;
            editUnitArgs.FuZeRenType = ddl_fuzerenType.SelectedValue;
            editUnitArgs.FuZeRenNO = txt_fuzerenzhenhao.Text;
            editUnitArgs.XukeZhenhao = txt_xuke.Text;
            editUnitArgs.UnitType = ddl_leixing.SelectedValue;
            editUnitArgs.IsHuYuan = ddl_huyuan.SelectedValue;
            editUnitArgs.HuType = ddl_huleixing.SelectedValue;
            editUnitArgs.QuXianNO = txt_suoshuquxian.Text;
            editUnitArgs.ZhuCeAddress = txt_zhucedizhi.Text;
            editUnitArgs.JingjiType = ddl_ecoType.SelectedValue;
            editUnitArgs.LianxiRen = txt_lianxiren.Text;
            editUnitArgs.LianxiTelePhone = txt_lianxidianhua.Text;
            editUnitArgs.YouBian = txt_youbian.Text;
            editUnitArgs.FaZhenName = txt_fazhenjigou.Text;
            editUnitArgs.ShenQingType = ddl_shenqingType.SelectedValue;
            editUnitArgs.XuKeData = dpk_xuke.SelectedDate;
            editUnitArgs.StartData = dp_start.SelectedDate;
            editUnitArgs.EndData = dp_end.SelectedDate;
            editUnitArgs.User = (DataTable)Session["User"];
            editUnitArgs.UnitId = Request.QueryString["EditUnitId"];
            OnSave(null,editUnitArgs);
        }
        #endregion

        #region【自定义事件】
        /// <summary>
        /// 绑定下拉框
        /// </summary>
        /// <param name="down">下拉框ID</param>
        /// <param name="dtData">数据源</param>
        /// <param name="textField">显示字段</param>
        /// <param name="valueField">值字段</param>
        void BindDropDown(DataTable dtData,ExtAspNet.DropDownList down)
        {
            down.DataSource = dtData;
            down.DataTextField = "NAME";
            down.DataValueField = "CODE";
            down.DataBind();
        }
        #endregion

        #region【接口绑定】

        /// <summary>
        /// 绑定界面所选单位相关信息
        /// </summary>
        /// <param name="dtUnit"></param>
        public void ExeBindControl(DataTable dtUnit)
        {
            DataRow dr = dtUnit.Rows[0];
            txt_xuke.Text = dr["LESENCE"].ToString();
            txt_unitName.Text = dr["UNIT_NAME"].ToString();

            ddl_leixing.SelectedValue = dr["UNIT_TYPE"].ToString();
            ddl_huyuan.SelectedValue = dr["IS_HOUSEHOLD"].ToString();
            ddl_huleixing.SelectedValue = dr["HOUSEHOLD_TYPE"].ToString();

            txt_suoshuquxian.Text = dr["COUNTY"].ToString();
            txt_zhucedizhi.Text = dr["REGISTER_ADDRESS"].ToString();
            txt_daima.Text = dr["UNIT_CODE"].ToString();
            txt_faren.Text = dr["LEGAL_PERSON"].ToString();
            ddl_farenType.SelectedValue = dr["LEGAL_LICENSE_TYPE"].ToString();
            txt_farenzhenhao.Text = dr["LEGAL_LICENSE_NO"].ToString();
            txt_fuzeren.Text = dr["RESPONSIBLE_PERSON"].ToString();
            ddl_fuzerenType.SelectedValue = dr["RESPONSIBLE_LICENSE_TYPE"].ToString();
            txt_fuzerenzhenhao.Text = dr["RESPONSIBLE_LICENSE_NO"].ToString();
            ddl_ecoType.SelectedValue = dr["ECO_TYPE"].ToString();
            txt_lianxiren.Text = dr["CONTACT"].ToString();
            txt_lianxidianhua.Text = dr["TELEPHONE"].ToString();
            txt_youbian.Text = dr["POSTCODE"].ToString();
            txt_dizhi.Text = dr["REGISTER_ADDRESS"].ToString();

            txt_fazhenjigou.Text = dr["ISSUE_NAME"].ToString();
            ddl_shenqingType.SelectedValue = dr["APPLY_TYPE"].ToString();
            //dpk_xuke.Text = dr["PERMIT_DATA"].ToString();
            if (dr["PERMIT_DATA"].ToString() != "")
            {
                dpk_xuke.SelectedDate = DateTime.Parse(dr["PERMIT_DATA"].ToString());
            }
            if (dr["START_DATA"].ToString() != "")
            {
                dp_start.SelectedDate = DateTime.Parse(dr["START_DATA"].ToString());
            }
            if (dr["END_DATA"].ToString() != "")
            {
                dp_end.SelectedDate = DateTime.Parse(dr["END_DATA"].ToString());
            }
        }

        /// <summary>
        /// 绑定下拉框
        /// </summary>
        /// <param name="unitType">类型</param>
        /// <param name="IDType">证件类型</param>
        /// <param name="ecoType">经济类型</param>
        /// <param name="applyType">申请类别</param>
        public void ExeBindDropDown(DataTable unitType, DataTable IDType, DataTable ecoType, DataTable applyType)
        {
            BindDropDown(unitType, ddl_leixing);
            BindDropDown(IDType, ddl_farenType);
            BindDropDown(IDType, ddl_fuzerenType);
            BindDropDown(applyType, ddl_shenqingType);
            BindDropDown(ecoType, ddl_ecoType);
        }

        /// <summary>
        /// 弹出信息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isCloseWindow">是否关闭当前窗口，true：关闭；false：不关闭</param>
        public void ExeMessageBox(string message, bool isCloseWindow)
        {
            if (isCloseWindow)
            {
                Alert.ShowInTop(message, "提示对话框", ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.ShowInTop(message, "提示对话框");
            }
        }
        #endregion

        #region【接口事件】

        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler<Views.EditUnitArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.EditUnitArgs> OnSave;

        #endregion
    }
}
using ExtAspNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CJia.HealthInspection;

namespace CJia.HealthInspection.Web.UI.Unit
{
    public partial class AddUnit : Tools.Page,Views.IAddUnit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (OnInitPage != null)
                {
                    OnInitPage(null, null);
                }
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.AddUnitPresenter(this);
        }
        #region IAddUnit成员
        public event EventHandler OnInitPage;
        public event EventHandler OnSave;
        public void ExeBindType(DataTable unitType, DataTable IDType, DataTable ecoType, DataTable applyType)
        {
            BindDDL(unitType, ddl_leixing);
            BindDDL(IDType, ddl_farenType);
            BindDDL(IDType, ddl_fuzerenType);
            BindDDL(applyType, ddl_shenqingType);
            BindDDL(ecoType, ddl_ecoType);
        }
        public void ExeIsSuccess(bool bol)
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
        #region 内部调用方法
        /// <summary>
        /// 绑定下拉框数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ddl"></param>
        public void BindDDL(DataTable data, ExtAspNet.DropDownList ddl)
        {
            ddl.DataSource = data;
            ddl.DataTextField = "NAME";
            ddl.DataValueField = "CODE";
            ddl.DataBind();
        }
        /// <summary>
        /// 设置单位
        /// </summary>
        public void BindUnit()
        {
            CJia.HealthInspection.Unit.UnitName = txt_unitName.Text;
            CJia.HealthInspection.Unit.Address=txt_dizhi.Text;
            CJia.HealthInspection.Unit.DaiMa=txt_daima.Text;
            CJia.HealthInspection.Unit.FaRen=txt_faren.Text;
            CJia.HealthInspection.Unit.FaRenNO=txt_farenzhenhao.Text;
            CJia.HealthInspection.Unit.FaRenType=ddl_farenType.SelectedValue;
            CJia.HealthInspection.Unit.FuZeRen=txt_fuzeren.Text;
            CJia.HealthInspection.Unit.FuZeRenType=ddl_fuzerenType.SelectedValue;
            CJia.HealthInspection.Unit.FuZeRenNO=txt_fuzerenzhenhao.Text;
            CJia.HealthInspection.Unit.XukeZhenhao=txt_xuke.Text;
            CJia.HealthInspection.Unit.UnitType=ddl_leixing.SelectedValue;
            CJia.HealthInspection.Unit.IsHuYuan=ddl_huyuan.SelectedValue;
            CJia.HealthInspection.Unit.HuTpye=ddl_huleixing.SelectedValue;
            CJia.HealthInspection.Unit.QuXianNO=txt_suoshuquxian.Text;
            CJia.HealthInspection.Unit.ZhuCeAddress=txt_zhucedizhi.Text;
            CJia.HealthInspection.Unit.JingjiType=ddl_ecoType.SelectedValue;
            CJia.HealthInspection.Unit.LianxiRen=txt_lianxiren.Text;
            CJia.HealthInspection.Unit.LianxiTelePhone=txt_lianxidianhua.Text;
            CJia.HealthInspection.Unit.YouBian=txt_youbian.Text;
            CJia.HealthInspection.Unit.FaZhenName=txt_fazhenjigou.Text;
            CJia.HealthInspection.Unit.ShenQingType=ddl_shenqingType.SelectedValue;
            CJia.HealthInspection.Unit.XuKeData=dp_xuke.SelectedDate;
            CJia.HealthInspection.Unit.StartData=dp_start.SelectedDate;
            CJia.HealthInspection.Unit.EndData = dp_end.SelectedDate;
            CJia.HealthInspection.Unit.OrganId = ((DataTable)Session["User"]).Rows[0]["organ_id"].ToString();
        }
        #endregion
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (OnSave != null)
            {
                BindUnit();
                OnSave(null, null);
            }
        }
    }
}
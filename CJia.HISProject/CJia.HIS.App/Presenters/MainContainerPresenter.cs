using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.HIS.App.Presenters
{
    public class MainContainerPresenter : CJia.HIS.Presenter<Models.MainContainerModel,Views.IMainContainerView>
    {

        public MainContainerPresenter(Views.IMainContainerView view)
            : base(view)
        {
            this.View.Load += View_Load;
            this.View.Init += View_Init;
            this.View.MenuClickEven += View_MenuClickEven;
        }

        void View_Load(object sender, EventArgs e)
        {
            DataTable module = this.Model.GetModule(CJia.HIS.SystemInfo.loginSystem["DEFAULT_MODULE_ID"].ToString());
            if(module == null || module.Rows == null || module.Rows.Count < 1)
            {
                this.View.initDefaultPage(null);
            }
            else
            {
                this.View.initDefaultPage(module);
            }
        }

        void View_Init(object sender, EventArgs e)
        {
            DataTable menus = this.Model.GetMenu(CJia.HIS.SystemInfo.User["USER_ID"].ToString(), CJia.HIS.SystemInfo.loginSystem["SYSTEM_ID"].ToString());
            this.View.IntiMenu(menus);
            DataTable tools = this.Model.GetTool(CJia.HIS.SystemInfo.User["USER_ID"].ToString(), CJia.HIS.SystemInfo.loginSystem["SYSTEM_ID"].ToString());
            this.View.IntiTool(tools);

        }

        void View_MenuClickEven(object sender, EventArgs e)
        {
            DataTable module = this.Model.GetModule(this.View.ModuleId);
            this.View.OpenModule(module);
            
        }

        protected override void OnInitView()
        {
            base.OnInitView();
        }

    }
}
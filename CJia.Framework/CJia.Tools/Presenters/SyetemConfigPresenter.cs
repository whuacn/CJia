using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CJia.Tools.Presenters
{
    public class SyetemConfigPresenter : CJia.Presenter<Views.ISystemConfigView>
    {
        private Models.SyetemConfigModel Model
        {
            get;
            set;
        }

         public SyetemConfigPresenter(Views.ISystemConfigView view)
            : base(view)
        {
            this.Model = new Models.SyetemConfigModel();
        }

        protected override void OnViewSet()
        {
            this.View.Load += View_Load;
            this.View.CreateSystemTable += View_CreateSystemTable;
        }

        void View_CreateSystemTable(object sender, EventArgs e)
        {
            this.InitClientConfig();
            string[] sqlStrings =  this.View.ModelSql.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            this.View.InitSchedule(sqlStrings.Length);
            int i = 1;
            foreach(string sqlString in sqlStrings)
            {
                try
                {
                    this.Model.Execute(this.View.DBName, sqlString);
                    i++;
                }
                catch(Exception ex)
                {
                    this.View.ShowMessage("第" + i + "条sql语句执行错误！" + ex.Message);
                    return;
                }
                this.View.NextSchedule();
            }
            this.View.ShowMessage("创建系统表成功");
        }

        void InitClientConfig()
        {
            CJia.ClientConfig.ClientNo = this.View.SystemNO.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[0];
            CJia.ClientConfig.SystemNo = this.View.SystemNO.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[1];
        }

        void View_Load(object sender, EventArgs e)
        {
            this.View.InitDBConfig(this.Model.QueryDBConfig());
        }

    }
}

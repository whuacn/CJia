using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.HIS.App.Presenters
{
    public class SelectSystemPresenter : CJia.HIS.Presenter<Models.SelectSystemModel, Views.ISelectSystemView>
    {

        public SelectSystemPresenter(Views.ISelectSystemView view)
            : base(view)
        {
            this.View.Load += View_Load;
            this.View.SelectSysEven += View_SelectSysEven;
        }

        void View_SelectSysEven(object sender, EventArgs e)
        {
            CJia.HIS.SystemInfo.loginSystem = this.View.SelectedSys;
        }

        void View_Load(object sender, EventArgs e)
        {
            int result = this.GetLoad();
            switch(result)
            {
                case 0:
                    this.View.ShowMessage("���û�û���κ�ϵͳ���Է���!");
                    this.View.CloseFrom();
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// ��ȡ�û��ܷ��ʵ�ϵͳ�б�
        /// </summary>
        /// <returns>0 û�ÿɷ��ʵ�ϵͳ 1 �������ݳɹ�</returns>
        public int GetLoad()
        {
            DataTable result = this.Model.GetSystem(CJia.HIS.SystemInfo.User["USER_ID"].ToString());
            if(result == null || result.Rows == null || result.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                this.View.SetSystems(result);
                return 1;
            }
        }


        protected override void OnInitView()
        {
            base.OnInitView();
        }

    }
}
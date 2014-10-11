using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters.DataManage
{
    /// <summary>
    /// ��Ӳ�����Ӧ�÷���P��
    /// </summary>
    public class AddDeptUsagePresenter:PIVAS.Tools.Presenter<CJia.PIVAS.Models.DataManage.AddDeptUsageModel,CJia.PIVAS.Views.DataManage.IAddDeptUsageView>
    {

        public AddDeptUsagePresenter(Views.DataManage.IAddDeptUsageView view)
            : base(view)
        {
            this.View.OnInitLoadDept += View_OnInitLoadData;
            this.View.OnInsertData += View_OnInsertData;
            this.View.OnRowClick += View_OnRowClick;
        }

        
        void View_OnInitLoadData(object sender, Views.DataManage.AddDeptUsageEventArgs e)
        {
            DataTable dtDept = new DataTable();
            dtDept = this.Model.QueryDept();
            this.View.ExeInitLoadDept(dtDept);
        }

        /// <summary>
        /// ���벡����Ӧ�÷�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInsertData(object sender, Views.DataManage.AddDeptUsageEventArgs e)
        {
            bool blIsRepeat = this.Model.QueryIsRepeat(e.OfficeId, e.UsageId);
            if (blIsRepeat==false)
            {
                bool blIsInsert = this.Model.InsertPivas(e.OfficeId, e.OfficeName, e.UsageId, e.UsageName, e.UserId);
                if(blIsInsert)
                {
                    //this.View.ShowMessage("��ӳɹ�");
                    this.View.CloseWindow();
                }
                else
                {
                    this.View.ShowMessage("���ʧ��");
                }
            }
            else
            {
                this.View.ShowMessage("����������һ����ͬ����");
            }
            
        }

        /// <summary>
        /// ��������������һ�д���  ���ݻ�ȡ���ò���id���õ���Ӧû������÷�ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnRowClick(object sender, Views.DataManage.AddDeptUsageEventArgs e)
        {
            DataTable dtUsage = new DataTable();
            dtUsage = this.Model.QueryUsage(e.OfficeId);
            this.View.ExtLoadUsage(dtUsage);
        }

        protected override void OnInitView()
        {

        }

    }
}
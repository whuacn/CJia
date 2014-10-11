using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters
{
    /// <summary>
    /// �������P��
    /// </summary>
    public class MainFromPresenter : CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.MainFromModel, CJia.PIVAS.Views.IMainFromView>
    {

        /// <summary>
        /// ��¼�Ĺ��췽��
        /// </summary>
        /// <param name="view"></param>
        public MainFromPresenter(Views.IMainFromView view)
            : base(view)
        {
            this.View.OnQueryNoCheckAdvice += View_OnQueryNoCheckAdvice;
            this.View.OnQueryExceptionLabel += View_OnQueryExceptionLabel;
            this.View.OnQueryStorage += View_OnQueryStorage;
            this.View.OnQueryNoPrintLabel += View_OnQueryNoPrintLabel;
        }

        /// <summary>
        /// ��ѯδ��ӡƿ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnQueryNoPrintLabel(object sender, Views.MainFromEventArgs e)
        {
            this.View.ExeQueryNoPrintLabel(this.Model.QueryNoPrintLabel());
        }


        /// <summary>
        /// ��дOnInitView ����
        /// </summary>
        protected override void OnInitView()
        {
        }

        //��ѯ��治��ҩƷ
        void View_OnQueryStorage(object sender, Views.MainFromEventArgs e)
        {
            this.View.ExeQueryStorage(this.Model.QueryStorage());

        }
        //��ѯδ���ҽ������
        void View_OnQueryNoCheckAdvice(object sender, Views.MainFromEventArgs e)
        {
            this.View.ExeQueryNoCheckAdvice(this.Model.QueryNoCheckAdvice());
        }

        //��ѯ�Ƿ����쳣��ƿ��
        void View_OnQueryExceptionLabel(object sender, Views.MainFromEventArgs e)
        {
            this.View.ExeQueryExceptionLabel(this.Model.QueryExpetionLabel());
        }

    }
}
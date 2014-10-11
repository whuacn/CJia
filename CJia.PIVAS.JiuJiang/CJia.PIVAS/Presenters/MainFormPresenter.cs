using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace CJia.PIVAS.Presenters
{
    /// <summary>
    /// 主界面的P层
    /// </summary>
    public class MainFromPresenter : CJia.PIVAS.Tools.Presenter<CJia.PIVAS.Models.MainFromModel, CJia.PIVAS.Views.IMainFromView>
    {

        /// <summary>
        /// 登录的构造方法
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
        /// 查询未打印瓶贴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnQueryNoPrintLabel(object sender, Views.MainFromEventArgs e)
        {
            this.View.ExeQueryNoPrintLabel(this.Model.QueryNoPrintLabel());
        }


        /// <summary>
        /// 重写OnInitView 方法
        /// </summary>
        protected override void OnInitView()
        {
        }

        //查询库存不足药品
        void View_OnQueryStorage(object sender, Views.MainFromEventArgs e)
        {
            this.View.ExeQueryStorage(this.Model.QueryStorage());

        }
        //查询未审核医嘱方法
        void View_OnQueryNoCheckAdvice(object sender, Views.MainFromEventArgs e)
        {
            this.View.ExeQueryNoCheckAdvice(this.Model.QueryNoCheckAdvice());
        }

        //查询是否有异常的瓶贴
        void View_OnQueryExceptionLabel(object sender, Views.MainFromEventArgs e)
        {
            this.View.ExeQueryExceptionLabel(this.Model.QueryExpetionLabel());
        }

    }
}
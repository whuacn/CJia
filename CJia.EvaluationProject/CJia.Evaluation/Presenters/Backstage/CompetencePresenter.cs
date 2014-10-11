using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Presenters.Backstage
{
    public class CompetencePresenter : CJia.Evaluation.Tools.PresenterPage<Models.Backstage.CompetenceModel,Views.Backstage.ICompetence>
    {
        public CompetencePresenter(Views.Backstage.ICompetence view)
            : base(view)
        {
            view.OnInitColumn += view_OnInitColumn;
            view.OninitMenu += view_OninitMenu;
            view.OnDepeteInsertCompetence += view_OnDepeteInsertCompetence;
        }

        void view_OnDepeteInsertCompetence(object sender, Views.Backstage.CompetenceArgs e)
        {
            bool isDeleteInsert = Model.DeleteInsertCompetence(e.obListDelete, e.obListInsert);
            View.ExeReturnInsertMsg(isDeleteInsert);
        }

        void view_OninitMenu(object sender, Views.Backstage.CompetenceArgs e)
        {
            DataTable dtMenu = Model.QueryMenuTree();
            DataTable dtMenuComptence = Model.QueryMenuCompetence(e.UserID);
            View.ExeBindMenu(dtMenu, dtMenuComptence);
        }

        void view_OnInitColumn(object sender, Views.Backstage.CompetenceArgs e)
        {
            DataTable dtColumn = Model.QueryColumTree();
            DataTable dtColumnComptence = Model.QueryColumnCompetence(e.UserID);
            View.ExeBindColumn(dtColumn, dtColumnComptence);
        }
    }
}

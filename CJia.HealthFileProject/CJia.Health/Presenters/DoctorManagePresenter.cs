using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Presenters
{
    public class DoctorManagePresenter : CJia.Health.Tools.Presenter<Models.DoctorManageModel, Views.IDoctorManageView>
    {
        public DoctorManagePresenter(Views.IDoctorManageView view)
            : base(view)
        {
            view.OnQueryDoctor += view_OnQueryDoctor;
            view.OnInsertDoctor += view_OnInsertDoctor;
            view.OnUpdateDoctor += view_OnUpdateDoctor;
            view.OnDeleteDoctor += view_OnDeleteDoctor;
            view.OnQueryDocDescript += view_OnQueryDocDescript;
            view.OnQueryDept += view_OnQueryDept;
            view.OnCheckDoctorNo += view_OnCheckDoctorNo;
            view.OnInsertUserDoc += view_OnInsertUserDoc;
        }

        void view_OnInsertUserDoc(object sender, Views.DoctorArgs e)
        {
            bool isInser;
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                isInser = Model.InsertDocUser(trans.ID, e.DoctorName, e.DoctorNo, e.DoctorPinyin, e.DeptId, e.DescriptId, User.UserData.Rows[0]["USER_ID"].ToString());
                trans.Complete();
            }
            if (!isInser)
            {
                Message.Show("插入失败");
            }
        }

        void view_OnCheckDoctorNo(object sender, Views.DoctorArgs e)
        {
            bool IsHave = Model.CheckUserNo(e.DoctorNo);
            View.exeBindIsDocNoHave(IsHave);
        }

        void view_OnQueryDept(object sender, Views.DoctorArgs e)
        {
            DataTable dtDept = Model.QueryDept(e.KeyWord);
            View.ExeBindDocDept(dtDept);
        }

        void view_OnQueryDocDescript(object sender, Views.DoctorArgs e)
        {
            DataTable dtDocDesript = Model.QueryDocDescript(e.KeyWord);
            View.ExeBindDocDescript(dtDocDesript);
        }

        void view_OnDeleteDoctor(object sender, Views.DoctorArgs e)
        {
            bool IsDeleteDoctor;
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                IsDeleteDoctor = Model.DeleteDoctor(trans.ID, e.UserId, e.DoctorId, e.DoctorNo);
                trans.Complete();
            }
            if (!IsDeleteDoctor)
            {
                View.ShowMessage("删除失败");
            }
        }

        void view_OnUpdateDoctor(object sender, Views.DoctorArgs e)
        {
            bool IsUpdateDoctor = Model.UpdateDoctor(e.DoctorName, e.DoctorNo, e.DoctorPinyin, e.DeptId, e.DescriptId, e.UserId);
            if (!IsUpdateDoctor)
            {
                View.ShowMessage("修改失败");
            }
        }

        void view_OnQueryDoctor(object sender, Views.DoctorArgs e)
        {
            DataTable dtDoc = Model.QueryDoctor(e.KeyWord);
            View.ExeBindDoctor(dtDoc);
        }

        void view_OnInsertDoctor(object sender, Views.DoctorArgs e)
        {
            bool IsInsertDoctor = Model.AddDoctor(e.DoctorName, e.DoctorNo, e.DoctorPinyin, e.DeptId, e.DescriptId, e.UserId);
            if (!IsInsertDoctor)
            {
                View.ShowMessage("添加失败");
            }
        }
    
    }
}

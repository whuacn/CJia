using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Presenters
{
    public class ImagesInputPresenter : CJia.Health.Tools.Presenter<Models.ImagesInputModel, Views.IImagesInputView>
    {
        public ImagesInputPresenter(Views.IImagesInputView view)
            : base(view)
        {
            view.OnLoad += view_OnLoad;
            view.OnInput += view_OnInput;
            view.OnProject += view_OnProject;
            view.OnRecordNO += view_OnRecordNO;
            view.OnSelectPicture += view_OnSelectPicture;
            view.OnInputDelete += view_OnInputDelete;
            view.OnInputSave += view_OnInputSave;
            view.OnReview += view_OnReview;
            view.OnMerge += view_OnMerge;
            view.OnNoAgree += view_OnNoAgree;
            view.OnShortKeyDown += view_OnShortKeyDown;
        }

        void view_OnShortKeyDown(object sender, Views.ImagesInputArgs e)
        {
            DataTable data = Model.GetProjectByShortKey(e.ShortKey);
            View.ExeBindProjectByShortKey(data);
        }

        void view_OnNoAgree(object sender, Views.ImagesInputArgs e)
        {
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                Model.DeletePicByPage(trans.ID, e.HealthID, User.UserData.Rows[0]["USER_ID"].ToString(), e.Page, e.SubPage);
                trans.Complete();
            }
        }

        void view_OnMerge(object sender, Views.ImagesInputArgs e)
        {
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                Model.ModifyPatientInfoCheckState(trans.ID, e.HealthID, e.MergeState, User.UserData.Rows[0]["USER_ID"].ToString());
                //Model.ModifyPictureCheckState(trans.ID, e.HealthID, User.UserData.Rows[0]["USER_ID"].ToString(), e.MergeState);
                trans.Complete();
            }
        }

        void view_OnReview(object sender, Views.ImagesInputArgs e)
        {
            DataTable data = Model.GetPictureByHealthID(e.HealthID);
            if (data != null)
            {
                using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
                {
                    bool bol1 = Model.ModifyPatientInfoCheckState(trans.ID, e.HealthID, "103", User.UserData.Rows[0]["USER_ID"].ToString());
                    bool bol2 = Model.ModifyPictureCheckStateByCase(trans.ID, e.HealthID, User.UserData.Rows[0]["USER_ID"].ToString(), "103");
                    if (bol1 || bol2)
                    {
                        View.ShowMessage("提交审核成功！");
                    }
                    trans.Complete();
                }
            }
            else
            {
                View.ShowMessage("此病案还未入库任何图片");
            }
        }

        void view_OnInputSave(object sender, Views.ImagesInputArgs e)
        {
            Model.ModifyPictureByID(e.PictureID, e.Page, e.SubPage, e.ProID, e.ProName, User.UserData.Rows[0]["USER_ID"].ToString());
        }

        void view_OnInputDelete(object sender, Views.ImagesInputArgs e)
        {
            Model.DeletePictureByID(e.PictureID, User.UserData.Rows[0]["USER_ID"].ToString());
        }

        void view_OnSelectPicture(object sender, Views.ImagesInputArgs e)
        {
            DataTable data = Model.GetPictureByHealthID(e.HealthID);
            View.ExeBindPicture(data);
        }

        void view_OnRecordNO(object sender, Views.ImagesInputArgs e)
        {
            DataTable data = Model.GetRecordNO(e.RecordNO);
            View.ExeRecordNO(data);
        }

        void view_OnProject(object sender, Views.ImagesInputArgs e)
        {
            DataTable data = Model.GetProject(e.SelectValue);
            View.ExeInit(data);
        }

        void view_OnInput(object sender, Views.ImagesInputArgs e)
        {
            DateTime date = Model.GetSysdate();
            using (CJia.Transaction trans = new Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                foreach (DataRow dr in e.PictureData.Rows)
                {
                    Model.AddPicture(trans.ID, dr, User.UserData.Rows[0]["USER_ID"].ToString(), User.UserData.Rows[0]["USER_NAME"].ToString(), date);
                }
                trans.Complete();
            }
        }

        void view_OnLoad(object sender, EventArgs e)
        {
            DataTable data = Model.GetProject();
            View.ExeInit(data);
        }

    }
}

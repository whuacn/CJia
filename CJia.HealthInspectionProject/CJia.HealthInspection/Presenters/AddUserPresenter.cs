using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class AddUserPresenter : Tools.PresenterPage<Models.AddUserModel, Views.IAddUser>
    {
        public AddUserPresenter(Views.IAddUser view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnSave += view_OnSave;
            
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.AddUserArgs e)
        {
            View.ExeCheckBoxList(Model.QueryRoleByOrganId(e.User.Rows[0]["organ_id"].ToString()));
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSave(object sender, Views.AddUserArgs e)
        {
            List<object> sqlParams = new List<object>();
            if (Model.QueryIsExistSameUserNo(e.UserNo))
            {
                View.ExeMessageBox("存在相同用户名，请修改...");
                return; 
            }
            string userSeq = Model.QueryUserSeq();
            //string roleSeq = Model.QueryRoleSeq();
            string createId = e.User.Rows[0]["user_id"].ToString();
            string organId = e.User.Rows[0]["organ_id"].ToString();
            bool isSuccess = false;
            sqlParams.Add(userSeq);
            sqlParams.Add(e.UserNo);
            sqlParams.Add(e.UserName);
            sqlParams.Add(createId);
            sqlParams.Add(organId);
            sqlParams.Add(e.UserType);
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                if (Model.InsertUser(trans.ID,sqlParams))
                {
                    for (int i = 0; i < e.RoleArr.Count; i++)
                    {
                        Model.InsertUserRole(trans.ID, userSeq, e.RoleArr[i], createId);
                    }

                    View.ExeMessageBox("保存成功！");
                    isSuccess = true;
                }
                trans.Complete();
            }

            if (!isSuccess)
            {
                View.ExeMessageBox("保存失败，请联系管理员...");
            }
        }
    }
}

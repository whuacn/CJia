using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class EditSupervisePresenter : CJia.HealthInspection.Tools.PresenterPage<Models.EditSuperviseModel,Views.IEditSupervise>
    {
        public EditSupervisePresenter(Views.IEditSupervise view)
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
        void view_OnInit(object sender, Views.EditSuperviseArgs e)
        {
            View.ExeBindControl(Model.QueryUserById(e.UserId));
            View.ExeBindTree(Model.QueryAllFunctionExceptSup(), Model.QueryUserIdOwnFunction(e.UserId));
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSave(object sender, Views.EditSuperviseArgs e)
        {
            List<object> sqlParams = new List<object>();
            if (Model.QueryIsExistSameUserNoUpdate(e.UserId,e.UserNo))
            {
                View.ExeMessageBox("存在相同用户名，请修改...",false);
                return;
            }
            string loginUserId = e.LoginUser.Rows[0]["user_id"].ToString();
            sqlParams.Add(e.UserNo);
            sqlParams.Add(e.UserName);
            sqlParams.Add(e.OrganId);
            sqlParams.Add(loginUserId);
            sqlParams.Add(e.UserId);
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                // 修改用户表
                if (Model.UpdateUser(trans.ID, sqlParams))
                {
                    // 删除该用户原有功能（删除角色功能表）
                    Model.DeleteRoleFunctionByRoleId(trans.ID, loginUserId, e.RoleId);
                    // 插入角色功能表新数据
                    Model.InsertRoleFunction(trans.ID, e.RoleId, e.ListFunction, loginUserId);
                    View.ExeMessageBox("修改成功！",true);
                }
                else
                {
                    View.ExeMessageBox("修改失败,请联系管理员...",false);
                }
                trans.Complete();
            }
            
        }
    }
}

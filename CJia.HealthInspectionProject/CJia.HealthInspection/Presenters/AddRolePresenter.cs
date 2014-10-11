using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class AddRolePresenter : CJia.HealthInspection.Tools.PresenterPage<Models.AddRoleModel,Views.IAddRole>
    {
        public AddRolePresenter(Views.IAddRole view)
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
        void view_OnInit(object sender, Views.AddRoleArgs e)
        {
            View.ExeBindTree(Model.QueryUserIdOwnFunction(e.User.Rows[0]["user_id"].ToString()));
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSave(object sender, Views.AddRoleArgs e)
        {
            bool isSuccess = false;
            string organId = e.User.Rows[0]["organ_id"].ToString();
            // 0代表超级管理员所拥有角色；1代表超级管理员（为组织管理员）所建角色；2代表组织管理员（为普通用户）所建角色
            string roleType = "2";
            if (Model.QueryExistSameRoleName(e.RoleName,organId))
            {
                View.ExeMessageBox("该组织下存在相同角色名，请修改...",false);
                return;
            }
            string createBy = e.User.Rows[0]["user_id"].ToString();
            // 角色表Seq
            string roleSeq = Model.QueryRoleSeq();
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                // 插入角色表
                if (Model.InsertRole(trans.ID,roleSeq, e.RoleName, createBy,organId,roleType))
                {
                    // 插入角色功能表
                    Model.InsertRoleFunction(trans.ID, roleSeq, e.ListFunction, createBy);
                    isSuccess = true;
                    View.ExeMessageBox("保存成功！",false);
                    
                }
                trans.Complete();
            }
            if (!isSuccess)
            {
                View.ExeMessageBox("保存失败,请联系管理员...",false);
            }
        }
    }
}

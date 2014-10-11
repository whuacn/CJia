using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class AddSupervisePresenter : Tools.PresenterPage<Models.AddSuperviseModel, Views.IAddSupervise>
    {
        public AddSupervisePresenter(Views.IAddSupervise view)
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
        void view_OnInit(object sender, Views.AddSuperviseArgs e)
        {
            View.ExeBindTree(Model.QueryAllFunctionExceptSup());
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSave(object sender, Views.AddSuperviseArgs e)
        {
            List<object> sqlParams = new List<object>();
            if (Model.QueryIsExistSameUserNo(e.UserNo))
            {
                View.ExeMessageBox("存在相同用户名，请修改...");
                return; 
            }
            string createBy = e.User.Rows[0]["user_id"].ToString();
            bool isSuccess = false;
            // 用户表Seq
            string userSeq = Model.QueryUserSeq();
            // 角色表Seq
            string roleSeq = Model.QueryRoleSeq();
            sqlParams.Add(userSeq);
            sqlParams.Add(e.UserNo);
            sqlParams.Add(e.UserName);
            sqlParams.Add(createBy);
            sqlParams.Add(e.OrganId);
            sqlParams.Add(e.UserType);
            // 如果不是超级管理员(即普通管理员)
            if (!e.IsCheckSupper)
            {
                using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
                {
                   
                    // 普通管理员自动为其创建一个名叫“管理员”的角色名
                    string roleName = "管理员";
                    // 插入用户表
                    if (Model.InsertUser(trans.ID,sqlParams))
                    {
                        // 插入角色表
                        if (Model.InsertRole(trans.ID, roleSeq, roleName, createBy,e.OrganId,e.RoleType))
                        {
                            // 插入用户角色表
                            if (Model.InsertUserRole(trans.ID, userSeq, roleSeq, createBy))
                            {
                                // 插入角色功能表
                                Model.InsertRoleFunction(trans.ID, roleSeq, e.ListFunction, createBy);
                                View.ExeMessageBox("保存成功！");
                                isSuccess = true;
                            }
                        }
                    }
                    trans.Complete();
                }
            }
            // 超级管理员
            else
            {
                using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
                {
                    if (Model.InsertUser(trans.ID,sqlParams))
                    {
                        // 如果不存在超级管理员角色
                        if (Model.QueryExistSuperRole())
                        {
                            // 创建超级管理员角色
                            if (Model.InsertRole(trans.ID, "1000000001", "超级管理员", createBy, "360000", "0"))
                            {
                                List<string> superFun = new List<string>();
                                superFun.Add("10");
                                superFun.Add("43");
                                superFun.Add("44");
                                // 往角色功能表插入超级管理员的角色功能
                                if (Model.InsertRoleFunction(trans.ID, "1000000001", superFun, createBy))
                                {
                                    if (Model.InsertUserRole(trans.ID, userSeq, "1000000001", createBy))
                                    {
                                        View.ExeMessageBox("保存成功！");
                                        isSuccess = true;
                                    }
                                }
                            }
                        }
                        // 如果存在超级管理员角色
                        else
                        {
                            if (Model.InsertUserRole(trans.ID, userSeq, "1000000001", createBy))
                            {
                                View.ExeMessageBox("保存成功！");
                                isSuccess = true;
                            }
                        }
                       
                    }
                    trans.Complete();
                }
            }

            if (!isSuccess)
            {
                View.ExeMessageBox("保存失败，请联系管理员...");
            }
        }
    }
}

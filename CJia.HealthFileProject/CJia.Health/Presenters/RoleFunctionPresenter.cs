using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Presenters
{
    public class RoleFunctionPresenter: CJia.Health.Tools.Presenter<Models.RoleFunctionModel,Views.IRoleFunctionView>
    {
        public RoleFunctionPresenter(Views.IRoleFunctionView view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnAdd += view_OnAdd;
            view.OnUpdate += view_OnUpdate;
            view.OnDelete += view_OnDelete;
            view.OnSearch += view_OnSearch;
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.RoleFunctionArgs e)
        {
            BindUserType();
            BindGridRole();
        }

        #region【绑定方法】
        /// <summary>
        /// 绑定用户类型
        /// </summary>
        void BindUserType()
        {
            View.ExeBindUserType(Model.QueryUserType());
        }

        /// <summary>
        /// 绑定Grid
        /// </summary>
        void BindGridRole()
        {
            View.ExeBindGridRole(Model.QueryRoleFunctionUnionUserType());
        }

        /// <summary>
        /// 保存时查询是否存在相同名称
        /// </summary>
        /// <param name="e"></param>
        /// <returns>false:不存在；true:存在</returns>
        bool IsExistSameFunctionNameWhenInsert(Views.RoleFunctionArgs e)
        {
            bool isExist = false;
            DataTable dt = Model.QueryWhenInsertIsExistSameFunctionName(e.FuncionName);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    isExist = true;
                }
            }
            return isExist;
        }

        ///// <summary>
        ///// 更新时查询是否存在相同名称
        ///// </summary>
        ///// <param name="e"></param>
        ///// <returns>false:不存在；true:存在</returns>
        //bool IsExistSameFunctionNameWhenUpdate(Views.RoleFunctionArgs e)
        //{
        //    bool isExist = false;
        //    DataTable dt = Model.QueryWhenUpdateIsExistSameFunctionName(e.FuncionName,e.ExistName);
        //    if (dt != null)
        //    {
        //        if (dt.Rows.Count > 0)
        //        {
        //            isExist = true;
        //        }
        //    }
        //    return isExist;
        //}
        #endregion

        #region【事件响应】

        /// <summary>
        /// 新增角色功能事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnAdd(object sender, Views.RoleFunctionArgs e)
        {
            if (IsExistSameFunctionNameWhenInsert(e))
            {
                Message.Show("库中存在相同名称，请修改！");
            }
            else
            {
                if (Message.ShowQuery("确定要保存【" + e.FuncionName + "】?") == Message.Result.Ok)
                {
                    Model.InsertRoleFunction(e.FuncionName, e.UserType);
                    BindGridRole();
                }
            }
        }

        /// <summary>
        /// 修改角色功能事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnUpdate(object sender, Views.RoleFunctionArgs e)
        {
            DataTable dtExistSameName = Model.QueryExistSameFunctionNameWhenUpdate(e.FunctionId,e.FuncionName,e.UserType);
            if(dtExistSameName.Rows.Count > 0)
            {
                Message.Show("库中存在其它相同名称，请修改！");
                return;
            }
            else
            {
                if (Message.ShowQuery("确定要修改【" + e.ExistName + "】?") == Message.Result.Ok)
                {
                    Model.UpdateRoleFounction(e.FunctionId, e.FuncionName, e.UserType);
                    BindGridRole();
                }
            }
        }

        /// <summary>
        /// 删除角色功能事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnDelete(object sender, Views.RoleFunctionArgs e)
        {
            if (Message.ShowQuery("确定要删除【" + e.FuncionName + "】?") == Message.Result.Ok)
            {
                if (Model.DeleteRoleFounction(e.FunctionId))
                {
                    BindGridRole();
                }
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSearch(object sender, Views.UserArgs e)
        {
            View.ExeBindGridRole(Model.QuerySearchFunctionUnionUserType(e.KeyWord));
        }
        #endregion
    }
}

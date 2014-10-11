using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class EditUnitPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.EditUnitModel,Views.IEditUnit>
    {
        public EditUnitPresenter(Views.IEditUnit view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnSave += view_OnSave;
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSave(object sender, Views.EditUnitArgs e)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(e.UnitName);
            sqlParams.Add(e.Address);
            sqlParams.Add(e.DaiMa);
            sqlParams.Add(e.FaRen);
            sqlParams.Add(e.FaRenNO);
            sqlParams.Add(e.FaRenType);
            sqlParams.Add(e.FuZeRen);
            sqlParams.Add(e.FuZeRenNO);
            sqlParams.Add(e.FuZeRenType);
            sqlParams.Add(e.XukeZhenhao);
            sqlParams.Add(e.UnitType);
            sqlParams.Add(e.IsHuYuan);
            sqlParams.Add(e.HuType);
            sqlParams.Add(e.QuXianNO);
            sqlParams.Add(e.ZhuCeAddress);
            sqlParams.Add(e.JingjiType);
            sqlParams.Add(e.LianxiRen);
            sqlParams.Add(e.LianxiTelePhone);
            sqlParams.Add(e.YouBian);
            sqlParams.Add(e.FaZhenName);
            sqlParams.Add(e.ShenQingType);
            sqlParams.Add(e.XuKeData);
            if (e.StartData == null)
            {
                sqlParams.Add("");
            }
            else
            {
                sqlParams.Add(e.StartData);
            }
            if (e.EndData == null)
            {
                sqlParams.Add("");
            }
            else
            {
                sqlParams.Add(e.EndData);
            }
            sqlParams.Add(e.User.Rows[0]["user_id"].ToString());
            sqlParams.Add(e.UnitId);
            if (Model.UpdateUnitByUnitId(sqlParams))
            {
                View.ExeMessageBox("修改成功！", true);
            }
            else
            {
                View.ExeMessageBox("修改失败,请联系管理员...",false);
            }
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.EditUnitArgs e)
        {
            BindDropDown();
            SetControl(e);
        }

        #region【自定义方法】
        /// <summary>
        /// 绑定下拉框
        /// </summary>
        void BindDropDown()
        {
            

            DataTable unitType = Model.QueryDownType("UNIT_TYPE");
            DataRow drUnitType = unitType.NewRow();
            drUnitType["code"] = "";
            drUnitType["name"] = "不指定";
            unitType.Rows.InsertAt(drUnitType, 0);

            DataTable IDType = Model.QueryDownType("ID_TYPE");
            DataRow drIDType = IDType.NewRow();
            drIDType["code"] = "";
            drIDType["name"] = "不指定";
            IDType.Rows.InsertAt(drIDType, 0);

            DataTable ecoType = Model.QueryDownType("ECO_TYPE");
            DataRow drEcoType = ecoType.NewRow();
            drEcoType["code"] = "";
            drEcoType["name"] = "不指定";
            ecoType.Rows.InsertAt(drEcoType, 0);

            //ecoType.Rows.InsertAt(dr,0);
            DataTable applyType = Model.QueryDownType("APPLY_TYPE");
            DataRow drApplyType = applyType.NewRow();
            drApplyType["code"] = "";
            drApplyType["name"] = "不指定";
            applyType.Rows.InsertAt(drApplyType, 0);
            //applyType.Rows.InsertAt(dr,0);
            View.ExeBindDropDown(unitType, IDType, ecoType, applyType);
        }

        /// <summary>
        /// 绑定界面控件值
        /// </summary>
        void SetControl(Views.EditUnitArgs e)
        {
            DataTable dt = Model.QueryUnitInfoByUnitId(e.UnitId);
            View.ExeBindControl(Model.QueryUnitInfoByUnitId(e.UnitId));
        }
        #endregion
    }
}

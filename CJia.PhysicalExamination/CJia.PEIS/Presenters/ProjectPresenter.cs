//***************************************************
// 文件名（File Name）:      DeptMode.cs
//
// 表（Tables）:            
//                          
// 视图（Views）:           
//                          
// 作者（Author）:           曾翠玲
//
// 日期（Create Date）:     2013.4.8
// 
// 修改记录（Revision History）：
//               R1：
//                   修改作者：
//                   修改日期：
//                   修改理由：
//***************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PEIS.Presenters
{
    public class ProjectPresenter : CJia.PEIS.Tools.Presenter<Models.ProjectModel, Views.IProjectView>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="view">接口</param>
        public ProjectPresenter(Views.IProjectView view)
            : base(view)
        {
            this.View.OnInit += View_OnInit;
            this.View.OnAddPro += View_OnAddPro;
            this.View.OnInsertPro += View_OnInsertPro;
            this.View.OnAddControlDefault += View_OnAddControlDefault;
            this.View.OnUpdatePro += View_OnUpdatePro;
            this.View.OnStopPro += View_OnStopPro;
            this.View.OnReStartPro += View_OnReStartPro;
            this.View.OnGridProjectClick += View_OnGridProjectClick;
            this.View.OnAfterFocusNodeDeptPro += View_OnAfterFocusNodeDeptPro;
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInit(object sender, Views.ProjectEventArgs e)
        {
            BindDeptProTree();
           // BindGridProject(e);
            BindProType();
            BindSmsSet();
            BindBeforeMeal();
            BindApplyGender();
            BindCostType();
            BindSpeciesType();
            BindUnitMeasurement();
            BindCommonProType();
            BindControlType();
        }

        /// <summary>
        /// 在treeList中绑定科室及其下所属项目
        /// </summary>
        void BindDeptProTree()
        {
            View.ExeDeptProBindTree(Model.SelectDeptProBindTree());
        }

        /// <summary>
        /// 绑定Grid项目数据
        /// </summary>
        void BindGridProject(Views.ProjectEventArgs e)
        {
            View.ExeBindGridProject(Model.SelectProBindGridProject(e.DeptId));
        }

     

        /// <summary>
        /// 添加项目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnAddPro(object sender, Views.ProjectEventArgs e)
        {
            View.ExeBindProSortNo(Model.GetNextProSortNo());
        }

        /// <summary>
        /// 保存项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnInsertPro(object sender, Views.ProjectEventArgs e)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(e.ProName);
            sqlParams.Add(e.SortNo);
            sqlParams.Add(e.ProFirstPinyin);
            sqlParams.Add(e.ProEnglishName);
            sqlParams.Add(e.ProType);
            sqlParams.Add(e.DeptId);
            sqlParams.Add(e.ExecuteId);
            sqlParams.Add(e.CommonProType);
            sqlParams.Add(e.DefaultValue);
            sqlParams.Add(e.UnitMeasurement);
            sqlParams.Add(e.ApplyGender);
            sqlParams.Add(e.CostType);
            sqlParams.Add(e.ControlType);
            sqlParams.Add(e.ControlDefaultName);
            sqlParams.Add(e.ControlTypeWidth);
            sqlParams.Add(e.IsInputPro);
            sqlParams.Add(e.ParentId);
            sqlParams.Add(e.IsFeePro);
            sqlParams.Add(e.BeroreMeal);
            sqlParams.Add(e.SmsSet);
            sqlParams.Add(e.IsReadDataDirect);
            sqlParams.Add(e.LisCorrespondProId);
            sqlParams.Add(e.LisCorresPondProName);
            sqlParams.Add(e.LisProId);
            sqlParams.Add(e.LisProName);
            sqlParams.Add(e.HisCorrespondProId);
            sqlParams.Add(e.HisCorresPondProName);
            sqlParams.Add(e.HisProId);
            sqlParams.Add(e.HisProName);
            sqlParams.Add(e.HisFirstPinyin);
            sqlParams.Add(e.ReferencePrice);
            sqlParams.Add(e.ExecutePrice);
            sqlParams.Add(e.IsNumericalPro);
            sqlParams.Add(e.SpeciesType);
            sqlParams.Add(e.IsSumMust);
            sqlParams.Add(e.RefUpMail);
            sqlParams.Add(e.RefUpFemail);
            sqlParams.Add(e.RefUpPrompt);
            sqlParams.Add(e.RefLowerMail);
            sqlParams.Add(e.RefLowerFemail);
            sqlParams.Add(e.RefLowerPrompt);
            sqlParams.Add(e.AlarmUpMail);
            sqlParams.Add(e.AlarmUpFemail);
            sqlParams.Add(e.AlarmUpPrompt);
            sqlParams.Add(e.AlarmLowerMail);
            sqlParams.Add(e.AlarmLowerFemail);
            sqlParams.Add(e.AlarmLowerPrompt);
            sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
            sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));

            if (Model.InsertProject(sqlParams))
            {
                Message.Show("体检项目【" + e.ProName + "】保存成功");
                BindGridProject(e);
            }
            BindDeptProTree();
            
        }

        /// <summary>
        /// 插入控件预设值表
        /// </summary>
        /// <param name="e"></param>
        void InsertControlValue(Views.ProjectEventArgs e)
        {
            DataTable dtInsertControl = e.AddControlValue;
            DataTable dt = dtInsertControl.Clone();
            if (dtInsertControl != null)
            {
                if (dtInsertControl.Columns.Contains("is_new_col"))
                {
                    for (int i = 0; i < dtInsertControl.Rows.Count; i++)
                    {
                        if (dtInsertControl.Rows[i]["is_new_col"].ToString() == "add")
                        {
                            dt.ImportRow(dtInsertControl.Rows[i]);
                        }
                    }
                    dt.Columns.Remove("is_new_col");
                }
                Model.InsertControlDefault(dt);
            }
        }

        /// <summary>
        /// 删除控件预设值
        /// </summary>
        /// <param name="e"></param>
        void DeleteControlValue(Views.ProjectEventArgs e)
        {
            DataTable dtDeleteControl = e.DeleteControlValue;
            if (dtDeleteControl != null)
            {
                if (dtDeleteControl.Columns.Contains("is_new_col"))
                {
                    for (int i = 0; i < dtDeleteControl.Rows.Count; i++)
                    {
                        if (dtDeleteControl.Rows[i]["is_new_col"].ToString() == "delete")
                        {
                            Model.DeleteControlsDefaultById(long.Parse(dtDeleteControl.Rows[i]["control_default_id"].ToString()));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 修改控件预设值状态
        /// </summary>
        /// <param name="e"></param>
        void UpdateControlValue(Views.ProjectEventArgs e)
        {
            DataTable dtUpdateControl = e.UpdateControlValue;
            for (int i = 0; i < dtUpdateControl.Rows.Count; i++)
            {
                Model.UpdateControlsDefaultCheckedStatusById(long.Parse(dtUpdateControl.Rows[i]["control_default_id"].ToString()), dtUpdateControl.Rows[i]["is_checked"].ToString());
            }
        }
       

        /// <summary>
        /// 修改项目表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnUpdatePro(object sender, Views.ProjectEventArgs e)
        {
            List<object> sqlParams = new List<object>();
            sqlParams.Add(e.ProName);
            sqlParams.Add(e.ProFirstPinyin);
            sqlParams.Add(e.ProEnglishName);
            sqlParams.Add(e.ProType);
            sqlParams.Add(e.CommonProType);
            sqlParams.Add(e.DefaultValue);
            sqlParams.Add(e.UnitMeasurement);
            sqlParams.Add(e.ApplyGender);
            sqlParams.Add(e.CostType);
            sqlParams.Add(e.ControlType);
            sqlParams.Add(e.ControlDefaultName);
            sqlParams.Add(e.ControlTypeWidth);
            sqlParams.Add(e.IsInputPro);
            sqlParams.Add(e.IsFeePro);
            sqlParams.Add(e.BeroreMeal);
            sqlParams.Add(e.SmsSet);
            sqlParams.Add(e.IsReadDataDirect);
            sqlParams.Add(e.ReferencePrice);
            sqlParams.Add(e.ExecutePrice);
            sqlParams.Add(e.IsNumericalPro);
            sqlParams.Add(e.SpeciesType);
            sqlParams.Add(e.IsSumMust);
            sqlParams.Add(e.RefUpMail);
            sqlParams.Add(e.RefUpFemail);
            sqlParams.Add(e.RefUpPrompt);
            sqlParams.Add(e.RefLowerMail);
            sqlParams.Add(e.RefLowerFemail);
            sqlParams.Add(e.RefLowerPrompt);
            sqlParams.Add(e.AlarmUpMail);
            sqlParams.Add(e.AlarmUpFemail);
            sqlParams.Add(e.AlarmUpPrompt);
            sqlParams.Add(e.AlarmLowerMail);
            sqlParams.Add(e.AlarmLowerFemail);
            sqlParams.Add(e.AlarmLowerPrompt);
            sqlParams.Add(long.Parse(User.UserData.Rows[0]["user_id"].ToString()));
            sqlParams.Add(e.ProId);

            InsertControlValue(e);
            DeleteControlValue(e);
            UpdateControlValue(e);
            if (Model.UpdateProject(sqlParams))
            {
                Message.Show("体检项目【" + e.ProName + "】修改成功");
                BindGridProject(e);
            }
            e.DeleteControlValue = null;
            e.AddControlValue = null;
            e.UpdateControlValue = null;
        }  

        /// <summary>
        /// 添加控件预设值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnAddControlDefault(object sender, Views.ProjectEventArgs e)
        {
            //if (Model.InsertControlDefault(e.ControlDefaultName, e.ProId, e.IsDefaultValue, e.IsChecked))
            //{
            //    Message.Show("控件预设值添加成功");
            //}

            //  流水号
            long controlDefaultId = Model.SelectControlsDefaultNextSeq();
            long userId = long.Parse(User.UserData.Rows[0]["user_id"].ToString());
            DataTable dtControlValue = e.AddControlValue;
            if (!dtControlValue.Columns.Contains("is_new_col"))
            {
                DataColumn dcName = new DataColumn("is_new_col", typeof(string)); // 新添加一列“是否为新数据 true代表是，false代表不是”，区分表中是否存在此行数据
                dtControlValue.Columns.Add(dcName);
            }
            dtControlValue.Rows.Add(controlDefaultId,e.ControlDefaultName,e.ProId,e.IsChecked,"add");
            this.View.ExeShowControlValue(dtControlValue);
        }

        

        /// <summary>
        /// 停用项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnStopPro(object sender, Views.ProjectEventArgs e)
        {
            Model.UpdateProjectByStop(e.ProId);
        }

        /// <summary>
        /// 启用项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnReStartPro(object sender, Views.ProjectEventArgs e)
        {
            Model.UpdateProjectByReStart(e.ProId);
        }

        /// <summary>
        /// 网格单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnGridProjectClick(object sender, Views.ProjectEventArgs e)
        {
            View.ExeSelectProStatus(Model.SelectProStatusByProId(e.ProId));
            this.View.ExeShowControlValue(Model.SelectControlsDefaultByProId(e.ProId));
        }

        /// <summary>
        /// 显示控件预设值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnLoadControlValue(object sender, Views.ProjectEventArgs e)
        {
            this.View.ExeShowControlValue(Model.SelectControlsDefaultByProId(e.ProId));
        }

        /// <summary>
        /// 点击树状结构查询所选中科室下属项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void View_OnAfterFocusNodeDeptPro(object sender, Views.ProjectEventArgs e)
        {
            BindGridProject(e);
        }

        #region 下拉默认值绑定

        /// <summary>
        /// 科室类别
        /// </summary>
        void BindProType()
        {
            View.ExeBindProType(Model.SelectBindProType());
        }

        /// <summary>
        /// 短信设置
        /// </summary>
        void BindSmsSet()
        {
            View.ExeBindSmsSet(Model.SelectBindSmsSet());
        }

        /// <summary>
        /// 是否为餐前项目
        /// </summary>
        void BindBeforeMeal()
        {
            View.ExeBindBeforeMeal(Model.SelectBindBeforeMeal());
        }

        /// <summary>
        /// 适用性别
        /// </summary>
        void BindApplyGender()
        {
            View.ExeBindApplyGender(Model.SelectBindApplyGender());
        }

        /// <summary>
        /// 费用类别
        /// </summary>
        void BindCostType()
        {
            View.ExeBindCostType(Model.SelectBindCostType());
        }

        /// <summary>
        /// 标本种类
        /// </summary>
        void BindSpeciesType()
        {
            View.ExeBindSpeciesType(Model.SelectBindSpeciesType());
        }

        /// <summary>
        /// 计量单位
        /// </summary>
        void BindUnitMeasurement()
        {
            View.ExeBindUnitMeasurement(Model.SelectBindUnitMeasurement());
        }

        /// <summary>
        /// 常用项目类别
        /// </summary>
        void BindCommonProType()
        {
            View.ExeBindCommonProType(Model.SelectBindCommonProType());
        }

        /// <summary>
        /// 控件类别
        /// </summary>
        void BindControlType()
        {
            View.ExeBindControlType(Model.SelectBindControlType());
        }
        #endregion
    }
}

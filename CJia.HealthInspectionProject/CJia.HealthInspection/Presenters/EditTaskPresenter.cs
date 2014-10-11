using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class EditTaskPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.EditTaskModel,Views.IEditTask>
    {
        public EditTaskPresenter(Views.IEditTask view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnSelectedDropTaskType += view_OnSelectedDropTaskType;
            //view.OnFileSeq += view_OnFileSeq;
            view.OnSave += view_OnSave;
            
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.EditTaskArgs e)
        {
            BindDropTaskType();
            View.ExeBindControl(Model.QueryTaskById(e.EditTaskId));
            // 根据当前所选任务ID查询所属文件
            View.ExeGridFile(Model.QueryFilesByTaskId(e.EditTaskId));
        }

        #region【自定义方法】
        /// <summary>
        /// 绑定下拉任务类型
        /// </summary>
        void BindDropTaskType()
        {
            View.ExeDropTaskType(Model.QueryTaskType());
        }
        #endregion

        /// <summary>
        /// 下拉选择任务类型事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSelectedDropTaskType(object sender, Views.EditTaskArgs e)
        {
            DataTable dt = Model.QueryTaskTypeById(e.SelectedDropTaskTypeId);
            if (dt != null && dt.Rows.Count > 0)
            {
                e.IsExistOragnEdit = true;
            }
            else
            {
                e.IsExistOragnEdit = false;
            }
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSave(object sender, Views.EditTaskArgs e)
        {
            System.Data.DataRow dr = e.User.Rows[0];
            bool isSaveSuccess = false;
            List<object> sqlParams = new List<object>();
            sqlParams.Add(e.TaskName);
            sqlParams.Add(e.TemplateId);
            sqlParams.Add(e.StartDate);
            sqlParams.Add(e.EndDate);
            sqlParams.Add(dr["USER_ID"]);
            sqlParams.Add(dr["USER_NAME"].ToString());
            sqlParams.Add(dr["USER_ID"]);
            sqlParams.Add(e.TaskTypeId);
            sqlParams.Add(e.OrganName);
            sqlParams.Add(e.CheckScord);
            sqlParams.Add(e.Remark);
            sqlParams.Add(e.EditTaskId);
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                // 修改任务
                if (Model.UpdateTask(trans.ID,sqlParams))
                {
                    if (e.DeleteFilesId != null)
                    {
                        // 根据文件ID删除文件
                        for (int m = 0; m < e.DeleteFilesId.Count; m++)
                        {
                            Model.DeleteFileById(trans.ID, e.DeleteFilesId[m], dr["USER_ID"].ToString());
                        }
                    }
                    if (e.FileName != null)
                    {
                        for (int i = 0; i < e.FileName.Count; i++)
                        {
                            // 插入文件表
                            Model.InsertFiles(trans.ID, e.FileName[i], e.FilePath[i], e.EditTaskId, dr["USER_ID"].ToString());
                        }
                    }
                    isSaveSuccess = true;
                }
                trans.Complete();
            }
            View.ExeIsSaveSuccess(isSaveSuccess);
        }

        /////// <summary>
        /////// 查询文件Seq，重命名文件
        /////// </summary>
        /////// <param name="sender"></param>
        /////// <param name="e"></param>
        //void view_OnFileSeq(object sender, Views.EditTaskArgs e)
        //{
        //    e.FileSeq = Model.QueryFileSeq();
        //}
    }
}

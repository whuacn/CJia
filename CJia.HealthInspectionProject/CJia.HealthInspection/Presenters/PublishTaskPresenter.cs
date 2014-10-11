using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Presenters
{
    public class PublishTaskPresenter : CJia.HealthInspection.Tools.PresenterPage<Models.PublishTaskModel,Views.IPublishTask>
    {
        public PublishTaskPresenter(Views.IPublishTask view)
            : base(view)
        {
            view.OnInit += view_OnInit;
            view.OnSave += view_OnSave;
            view.OnSelectedDropTaskType += view_OnSelectedDropTaskType;
            //view.OnFileSeq += view_OnFileSeq;
        }

        
        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnInit(object sender, Views.PublishTaskArgs e)
        {
            BindTaskType();
        }

        #region【自定义方法】
        /// <summary>
        /// 查询所有任务类型
        /// </summary>
        void BindTaskType()
        {
            View.ExeDropTaskType(Model.QueryTaskType());
        }
        #endregion

        ///// <summary>
        ///// 查询文件Seq，重命名文件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void view_OnFileSeq(object sender, Views.PublishTaskArgs e)
        //{
        //    e.FileSeq = Model.QueryFileSeq();
        //}

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSave(object sender, Views.PublishTaskArgs e)
        {
            System.Data.DataRow dr = e.User.Rows[0];
            bool isSaveSuccess = false;
            List<object> sqlParams = new List<object>();
            string taskSeq = Model.QueryTaskSeq();
            sqlParams.Add(taskSeq);
            sqlParams.Add(e.TaskName);
            sqlParams.Add(e.TemplateId);
            sqlParams.Add(e.StartDate);
            sqlParams.Add(e.EndDate);
            sqlParams.Add(dr["USER_ID"]);
            sqlParams.Add(dr["USER_NAME"].ToString());
            sqlParams.Add(dr["USER_ID"]);
            sqlParams.Add(e.TaskType);
            sqlParams.Add(e.OrganName);
            sqlParams.Add(e.CheckScord);
            sqlParams.Add(e.Remark);
            sqlParams.Add(e.User.Rows[0]["organ_id"].ToString());
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                // 插入任务表
                if (Model.InsertTask(trans.ID,sqlParams))
                {
                    for(int i=0;i<e.FileName.Count;i++)
                    {
                        // 插入文件表
                        if (Model.InsertFiles(trans.ID, e.FileName[i], e.FilePath[i], taskSeq, dr["USER_ID"].ToString()))
                        {
                            isSaveSuccess = true;
                        }
                        else
                        {
                            isSaveSuccess = false;
                        }
                    }
                }
                trans.Complete();
            }
            View.ExeIsSaveSuccess(isSaveSuccess);
            
        }

        /// <summary>
        /// 根据Id查询任务类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_OnSelectedDropTaskType(object sender, Views.PublishTaskArgs e)
        {
            DataTable dt = Model.QueryTaskTypeById(e.SelectedDropTaskTypeId);
            if (dt != null && dt.Rows.Count > 0)
            {
                e.IsExistOragnAdd = true;
            }
            else
            {
                e.IsExistOragnAdd = false;
            }

        }
    }
}

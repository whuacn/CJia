using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models.FrontStage
{
    public class FirstOneModel : CJia.Evaluation.Tools.Model
    {
        /// <summary>
        /// 根据id查询出所有子集
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetTreeDataByID(string id)
        {
            using (Adapter ad = new Adapter())
            {
                object[] sqlparams = { id };
                DataTable dtResult = ad.Query(Models.SqlToos.SqlQueryTreeByID, sqlparams);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    return dtResult;
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 根据id查询出父一级
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetTreePatDataByID(string id)
        {
            using (Adapter ad = new Adapter())
            {
                object[] sqlparams = { id };
                DataTable dtResult = ad.Query(Models.SqlToos.SqlQueryPatTree, sqlparams);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    return dtResult;
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 根据父级id查询出树形
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetTreeByPatID(string id)
        {
            using (Adapter ad = new Adapter())
            {
                object[] sqlparams = { id };
                DataTable dtResult = ad.Query(Models.SqlToos.SqlQueryTreeByPatID, sqlparams);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    return dtResult;
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 根据id查询出自己
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetTreeBySelfID(string id)
        {
            using (Adapter ad = new Adapter())
            {
                object[] sqlparams = { id };
                DataTable dtResult = ad.Query(Models.SqlToos.SqlQueryTreeBySelfID, sqlparams);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    return dtResult;
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 根据id查询资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetZLByID(string id)
        {
            using (Adapter ad = new Adapter())
            {
                object[] sqlparams = { id };
                DataTable dtResult = ad.Query(Models.SqlToos.SqlQueryZLByID, sqlparams);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    return dtResult;
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 根据id查询出所有父级
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetParentByID(string id)
        {
            using (Adapter ad = new Adapter())
            {
                object[] sqlparams = { id };
                DataTable dtResult = ad.Query(Models.SqlToos.SqlQueryParentByID, sqlparams);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    return dtResult;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

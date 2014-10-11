using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models.Backstage
{
    public class EditColumTreeModel : CJia.Evaluation.Tools.Model
    {
        /// <summary>
        /// 根据节点ID查询树状节点的详细信息
        /// </summary>
        /// <param name="ColumnId"></param>
        /// <returns></returns>
        public DataTable QueryColumnNode(string ColumnId)
        { 
            using(Adapter ad=new Adapter())
            {
                object[] ob = new object[] { ColumnId };
                DataTable dtColumnNode = ad.Query(SqlToos.SqlQueryColumnNode, ob);
                return dtColumnNode;
            }
        }

        /// <summary>
        /// 查询栏目等级
        /// </summary>
        /// <returns></returns>
        public DataTable QueryColumnGrade()
        {
            using (Adapter ad = new Adapter())
            {
                DataTable dtColumnGrade = ad.Query(SqlToos.SqlQueryColumnGrade, null);
                return dtColumnGrade;
            }
        }

        /// <summary>
        /// 修改树状节点
        /// </summary>
        /// <param name="ColumnName"></param>
        /// <param name="ColumnDescript"></param>
        /// <param name="ColumnNo"></param>
        /// <param name="ColumnGrade"></param>
        /// <param name="updateBy"></param>
        /// <param name="ColumnTreeID"></param>
        /// <returns></returns>
        public bool UpdateColumnTree(string ColumnName, string ColumnDescript, int ColumnNo, long ColumnGrade, string checkway, string score, string scoreStandard, long updateBy, string ColumnTreeID, List<string> DutyDept, List<string> HelpDept)
        {
            using (Adapter ad = new Adapter())
            {
                List<object[]> ob1 = new List<object[]>();
                ob1.Add(new object[] { ColumnName, ColumnDescript, ColumnNo, ColumnGrade, checkway, score, scoreStandard, updateBy, ColumnTreeID });
                List<object[]> ob2 = new List<object[]>();
                ob2.Add(new object[] { updateBy, ColumnTreeID });
                List<object[]> ob3 = new List<object[]>();
                if (DutyDept.Count > 0)
                {
                    for (int i = 0; i < DutyDept.Count; i++)
                    {
                        ob3.Add(new object[] { ColumnTreeID, DutyDept[i], "1", updateBy });
                    }
                }
                if (HelpDept.Count > 0)
                {
                    for (int j = 0; j < HelpDept.Count; j++)
                    {
                        ob3.Add(new object[] { ColumnTreeID, HelpDept[j], "2", updateBy });
                    }
                }
                List<object[]> ob4 = new List<object[]>();
                ob4.Add(new object[] { ColumnName, updateBy, ColumnDescript, ColumnTreeID });
                bool isUpdate = ad.ExeTransaction(SqlToos.SqlUpdateColumnTree, ob1, SqlToos.SqlDeleteDutyHelpDept, ob2, SqlToos.SqlInsertDutyHelpDept, ob3, SqlToos.SqlUpdatettCheck, ob4) > 0 ? true : false;
                return isUpdate;
            }
        }

        /// <summary>
        /// 根据栏目id查询责任科室
        /// </summary>
        /// <param name="ColumnID"></param>
        /// <returns></returns>
        public DataTable QueryDutyDept(string ColumnID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { ColumnID };
                DataTable dtDutyDept = ad.Query(SqlToos.SqlSelectDutyDept, ob);
                return dtDutyDept;
            }
        }

        /// <summary>
        /// 根据栏目id查询协助科室
        /// </summary>
        /// <param name="ColumnID"></param>
        /// <returns></returns>
        public DataTable QueryHelpDept(string ColumnID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { ColumnID };
                DataTable dtHelpDept = ad.Query(SqlToos.SqlSelectHelpDept, ob);
                return dtHelpDept;
            }
        }
        /// <summary>
        /// 查询科室
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllDept()
        {
            using (Adapter ad = new Adapter())
            {
                DataTable dtDept = ad.Query(SqlToos.SqlQueryAllDept, null);
                return dtDept;
            }
        }

        /// <summary>
        /// 删除栏目下的责任科室和协助科室
        /// </summary>
        /// <param name="ColumnID"></param>
        /// <returns></returns>
        public bool DeleteDutyHelpDept(string ColumnID)
        {
            using (Adapter ad = new Adapter())
            {
                object[] ob = new object[] { ColumnID };
                return ad.Execute(SqlToos.SqlDeleteDutyHelpDept, ob) > 0 ? true : false;
            }
        }

        //public bool updatettCheck(string columnName, string updateBy, string descripition, string columnID)
        //{
        //    using (Adapter ad = new Adapter())
        //    { 
        //        object[] ob
        //    }
        //}
    }

}

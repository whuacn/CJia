using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Models.Backstage
{
    public class AddColumnTreeModel : CJia.Evaluation.Tools.Model
    {
        /// <summary>
        /// 增加栏目
        /// </summary>
        /// <param name="ColumnName"></param>
        /// <param name="ColumnDescript"></param>
        /// <param name="ColumnGrade"></param>
        /// <param name="ColumnNo"></param>
        /// <param name="ParentId"></param>
        /// <param name="CreaterBy"></param>
        /// <returns></returns>
        public bool AddColumnTree(string ColumnName, string ColumnDescript,int ColumnNo, long ColumnGrade, string ParentId, long CreaterBy,string CheckWay, string Score, string ScoreStandard, List<string> DutyDept, List<string> HelpDept)
        {
            using (Adapter ad = new Adapter())
            {
                string ColumnTreeseq = ad.QueryScalar(SqlToos.SqlQueryCloumnNextVal, null);
                List<object[]> listob1 = new List<object[]>();
                listob1.Add(new object[] { ColumnName, ColumnDescript, ColumnNo, ColumnGrade, ParentId, CreaterBy, CheckWay, Score, ScoreStandard });
                List<object[]> listob2 = new List<object[]>();
                if (DutyDept.Count > 0)
                {
                    for (int i = 0; i <= DutyDept.Count; i++)
                    {
                        listob2.Add(new object[] { ColumnTreeseq, DutyDept[i], '1', CreaterBy });
                    }
                }
                if (HelpDept.Count > 0)
                {
                    for (int j = 0; j < HelpDept.Count; j++)
                    {
                        listob2.Add(new object[] { ColumnTreeseq, HelpDept[j], '2', CreaterBy });
                    }
                }
                bool bl = ad.ExeTransaction(SqlToos.SqlAddColumnTree, listob1, SqlToos.SqlInsertDutyHelpDept, listob2) > 0 ? true : false;
                return bl;
            }
        }

        /// <summary>
        /// 添加栏目时如果是4级栏目则往审核表里插入这条数据
        /// </summary>
        /// <param name="ColumnArgs"></param>
        /// <param name="CheckArgs"></param>
        /// <returns></returns>
        public bool InsertColumntree(string ColumnName, string ColumnDescript, int ColumnNo, long ColumnGrade, string ParentId, long CreaterBy, string CheckWay, string Score, string ScoreStandard, List<string> DutyDept, List<string> HelpDept)
        {
            using (Adapter ad = new Adapter())
            {
                string ColumnTreeseq = ad.QueryScalar(SqlToos.SqlQueryCloumnNextVal, null);
                List<object[]> listob1 = new List<object[]>();
                listob1.Add(new object[] { ColumnTreeseq, ColumnName, ColumnDescript, ColumnNo, ColumnGrade, ParentId, CreaterBy, CheckWay, Score, ScoreStandard });
                List<object[]> listob2 = new List<object[]>();
                listob2.Add(new object[] { ColumnTreeseq, ColumnName, CreaterBy, ColumnDescript });
                List<object[]> listob3 = new List<object[]>();
                if (DutyDept.Count > 0)
                {
                    for (int i = 0; i < DutyDept.Count; i++)
                    {
                        listob3.Add(new object[] { ColumnTreeseq, DutyDept[i], "1", CreaterBy });
                    }
                }
                if (HelpDept.Count > 0)
                {
                    for (int j = 0; j < HelpDept.Count; j++)
                    {
                        listob3.Add(new object[] { ColumnTreeseq, HelpDept[j], "2", CreaterBy });
                    }
                }
                bool bl = ad.ExeTransaction(SqlToos.SqlInsertColumnTree, listob1, SqlToos.SqlInsertCheck, listob2, SqlToos.SqlInsertDutyHelpDept, listob3) > 0 ? true : false;
                return bl;
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
    }
}

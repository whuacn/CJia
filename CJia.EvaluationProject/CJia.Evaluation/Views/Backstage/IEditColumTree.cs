using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Views.Backstage
{
    public interface IEditColumTree : CJia.Evaluation.Tools.IPage
    {
        event EventHandler<EditColumTreeArgs> OnQueryColumnNode;
        event EventHandler<EditColumTreeArgs> OnUpdateColumnTree;
        void ExeBindColumnNode(DataTable dtColumnNode, DataTable dtAllDept, DataTable dtDutyDept, DataTable dtHeptDept);
        void ExeReturnUpdateMsg(bool isUpdate);
    }

    public class EditColumTreeArgs : EventArgs
    {
        /// <summary>
        /// 节点ID
        /// </summary>
        public string ColumnID;

        /// <summary>
        /// 栏目名称
        /// </summary>
        public string ColumnTreeName;

        /// <summary>
        /// 栏目说明
        /// </summary>
        public string ColumnTreeDescript;

        /// <summary>
        /// 栏目序号
        /// </summary>
        public int ColumnNo;

        /// <summary>
        /// 栏目等级
        /// </summary>
        public long ColumnGrade;

        /// <summary>
        /// 当前登录用户ID
        /// </summary>
        public long UserID;

        /// <summary>
        /// 评审方法
        /// </summary>
        public string CheckWay;

        /// <summary>
        /// 分配分数
        /// </summary>
        public string Score;

        /// <summary>
        /// 评分标准
        /// </summary>
        public string ScoreStandard;

        /// <summary>
        /// 责任科室
        /// </summary>
        public List<string> DutyDept;

        /// <summary>
        /// 协助科室
        /// </summary>
        public List<string> HelpDept;
    }
}

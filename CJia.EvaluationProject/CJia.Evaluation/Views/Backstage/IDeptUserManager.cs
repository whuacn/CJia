using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Evaluation.Views.Backstage
{
    public interface IDeptUserManager : CJia.Evaluation.Tools.IPage
    {
        event EventHandler<DeptUserManagerArgs> OnInitDept;
        event EventHandler<DeptUserManagerArgs> OnQueryUserByDeptId;
        event EventHandler<DeptUserManagerArgs> OnDeleteDept;
        event EventHandler<DeptUserManagerArgs> OnIsHaveChildDept;
        event EventHandler<DeptUserManagerArgs> OnDeleteUser;
        void ExeBindDept(DataTable dtDept);
        void ExeBindUser(DataTable dtUser);
        void ExeReturnDeleteMsg(bool isDelete);
        void ExeInsertUser(bool isHaveChildDept);
        void ExeReturnDeleteUserMsg(bool isDelete);
    }
    public class DeptUserManagerArgs : EventArgs
    {
        /// <summary>
        /// 科室id
        /// </summary>
        public string DeptId;

        /// <summary>
        /// 登录用户ID
        /// </summary>
        public string UserID;

        public string UserName;

        public string UserCode;

        public string UserPwd;

        /// <summary>
        /// 删除用户ID
        /// </summary>
        public string userId;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views.Web
{
    public interface IQueryPatientView:CJia.Health.Tools.IPage
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler OnInit;
        event EventHandler<QueryPatientArgs> OnProviceChanged;
        event EventHandler<QueryPatientArgs> OnDeptChanged;
        event EventHandler<QueryPatientArgs> OnApply;
        /// <summary>
        /// 查询事件
        /// </summary>
        event EventHandler<QueryPatientArgs> OnSelect;
        /// <summary>
        /// 绑定查询返回的病案信息
        /// </summary>
        /// <param name="data"></param>
        void ExeBindSelectRecord(DataTable data);
        void ExeBindPatient(DataTable data);
        /// <summary>
        /// 初始化绑定
        /// </summary>
        /// <param name="icdData"></param>
        /// <param name="zlData"></param>
        /// <param name="dept"></param>
        /// <param name="provice"></param>
        void ExeBind(DataTable icdData, DataTable zlData, DataTable dept, DataTable provice);
        /// <summary>
        /// 绑定城市
        /// </summary>
        /// <param name="data"></param>
        void ExeBindCity(DataTable data);
        /// <summary>
        /// 绑定医生
        /// </summary>
        /// <param name="data"></param>
        void ExeBIndDoctor(DataTable data,int i);
       
    }
    public class QueryPatientArgs:EventArgs
    {
        /// <summary>
        /// 标示
        /// </summary>
        public int i = 0;
        /// <summary>
        /// 省份ID
        /// </summary>
        public string ProviceID;
        /// <summary>
        /// 部门ID
        /// </summary>
        public string DeptID;
        /// <summary>
        /// 病案查询条件
        /// </summary>
        public MyPatient Patient;
        public DataTable UserData;
        /// <summary>
        /// 病案号
        /// </summary>
        public List<string> HealthIDList;
        /// <summary>
        /// 借阅原因
        /// </summary>
        public string Reason;
    }
}

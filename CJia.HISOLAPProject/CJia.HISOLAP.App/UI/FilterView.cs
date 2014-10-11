using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.HISOLAP.App.Tools;

namespace CJia.HISOLAP.App.UI
{

    public partial class FilterView : DevExpress.XtraEditors.XtraUserControl
    {
        public FilterView()
        {
            InitializeComponent();
            this.Init();
        }

        #region 公有属性

        /// <summary>
        /// 用户选择的开始时间
        /// </summary>
        public DateTime selectStartDateTime
        {
            get
            {
                int selectYear = Convert.ToInt32(this.cbStartNF.SelectedItem.ToString().Replace("年", ""));
                int selectJD = Convert.ToInt32(this.cbStartJD.SelectedItem.ToString().Replace("季度", ""));
                int selectMounth = Convert.ToInt32(this.cbStartYF.SelectedItem.ToString().Replace("月", ""));
                int selectRQ = Convert.ToInt32(this.cbStartRQ.SelectedItem.ToString().Replace("日", ""));
                DateTime result = new DateTime();
                if(this.rbYear.Checked)
                {
                    result = new DateTime(selectYear, 1, 1, 0, 0, 0);
                }
                if(this.rbJD.Checked)
                {
                    result = new DateTime(selectYear, selectJD * 3 - 2, 1, 0, 0, 0);
                }
                if(this.rbMounth.Checked)
                {
                    result = new DateTime(selectYear, selectMounth, 1, 0, 0, 0);
                }
                if(this.rbDay.Checked)
                {
                    result = new DateTime(selectYear, selectMounth, selectRQ, 0, 0, 0);
                }
                return result;
            }
        }

        /// <summary>
        /// 用户选择的结束时间
        /// </summary>
        public DateTime selectEndDateTime
        {
            get
            {
                int selectYear;
                int selectJD;
                int selectMounth;
                int selectRQ;

                if(this.rbQJ.Checked)
                {
                    selectYear = Convert.ToInt32(this.cbEndNF.SelectedItem.ToString().Replace("年", ""));
                    selectJD = Convert.ToInt32(this.cbEndJD.SelectedItem.ToString().Replace("季度", ""));
                    selectMounth = Convert.ToInt32(this.cbEndYF.SelectedItem.ToString().Replace("月", ""));
                    selectRQ = Convert.ToInt32(this.cbEndRQ.SelectedItem.ToString().Replace("日", ""));
                }
                else
                {
                    selectYear = Convert.ToInt32(this.cbStartNF.SelectedItem.ToString().Replace("年", ""));
                    selectJD = Convert.ToInt32(this.cbStartJD.SelectedItem.ToString().Replace("季度", ""));
                    selectMounth = Convert.ToInt32(this.cbStartYF.SelectedItem.ToString().Replace("月", ""));
                    selectRQ = Convert.ToInt32(this.cbStartRQ.SelectedItem.ToString().Replace("日", ""));
                }

                DateTime result = new DateTime();
                if(this.rbYear.Checked)
                {
                    result = new DateTime(selectYear, 12, 31, 23, 59, 59);
                }
                if(this.rbJD.Checked)
                {
                    if(selectJD == 4)
                    {
                        result = new DateTime(selectYear, 12, 31, 23, 59, 59);
                    }
                    else
                    {
                        result = new DateTime(selectYear, selectJD * 3 + 1, 1, 0, 0, 0).AddSeconds(-1);
                    }
                }
                if(this.rbMounth.Checked)
                {
                    if(selectMounth == 12)
                    {
                        result = new DateTime(selectYear, selectMounth, 31, 23, 59, 59);
                    }
                    else
                    {
                        result = new DateTime(selectYear, selectMounth + 1, 1, 0, 0, 0).AddSeconds(-1);
                    }
                }
                if(this.rbDay.Checked)
                {
                    result = new DateTime(selectYear, selectMounth, selectRQ, 23, 59, 59);
                }
                return result;
            }
        }

        /// <summary>
        /// 选择的时间字符显示
        /// </summary>
        public string selectDateStr
        {
            get
            {
                string startDateStr = "";
                string endDateStr = "";

                if(this.rbYear.Checked)
                {
                    startDateStr = this.cbStartNF.SelectedItem.ToString();
                    endDateStr = this.cbEndNF.SelectedItem.ToString();
                }
                if(this.rbJD.Checked)
                {
                    startDateStr = this.cbStartNF.SelectedItem.ToString() + this.cbStartJD.SelectedItem.ToString();
                    endDateStr = this.cbEndNF.SelectedItem.ToString() + this.cbEndJD.SelectedItem.ToString();
                }
                if(this.rbMounth.Checked)
                {
                    startDateStr = this.cbStartNF.SelectedItem.ToString() + this.cbStartYF.SelectedItem.ToString();
                    endDateStr = this.cbEndNF.SelectedItem.ToString() + this.cbEndYF.SelectedItem.ToString();
                }
                if(this.rbDay.Checked)
                {
                    startDateStr = this.cbStartNF.SelectedItem.ToString() + this.cbStartYF.SelectedItem.ToString() + this.cbStartRQ.SelectedItem.ToString();
                    endDateStr = this.cbEndNF.SelectedItem.ToString() + this.cbEndYF.SelectedItem.ToString() + this.cbEndRQ.SelectedItem.ToString();
                }

                if(this.rbDG.Checked)
                {
                    return startDateStr;
                }
                else
                {
                    return startDateStr + " 至 " + endDateStr;
                }
            }
        }


        private bool isUseDept = false;
        /// <summary>
        /// 是否使用科室选择
        /// </summary>
        public bool IsUseDept
        {
            set
            {
                this.isUseDept = value;
                this.gbDept.Visible = this.isUseDept;
                this.btnRefresh1.Visible = !this.isUseDept;
                this.btnRefresh2.Visible = this.isUseDept;
            }
            get
            {
                return this.isUseDept;
            }
        }

        /// <summary>
        /// 是否选择了所有科室
        /// </summary>
        public bool IsSelectAllDept
        {
            get
            {
                Dictionary<string, string> depts = new Dictionary<string, string>();
                if(this.isDX)
                {
                    if(this.cbDept.SelectedValue.ToString() == "ALL")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    bool isAll = true;
                    foreach(DevExpress.XtraTreeList.Nodes.TreeListNode treeListNode in this.ctlDept.Nodes)
                    {
                        if(treeListNode.CheckState != CheckState.Checked)
                        {
                            isAll = false;
                        }
                    }
                    return isAll;
                }
            }
        }

        /// <summary>
        /// 选择的病区
        /// </summary>
        public Dictionary<string, string> selectDepts
        {
            get
            {
                Dictionary<string, string> depts;
                if(this.isDX)
                {
                    depts = new Dictionary<string, string>();
                    depts.Add(this.cbDept.Text, this.cbDept.SelectedValue.ToString());
                }
                else
                {
                    DXSelectDepts.Clear();
                    this.getTreeListNodsCheck(this.ctlDept.Nodes);
                    depts = DXSelectDepts;
                }
                return depts;
            }
        }

        /// <summary>
        /// /// <summary>
        /// 下拉框数据源
        /// </summary>
        /// </summary>
        private DataTable data;

        public DataTable Data
        {
            set 
            {
                this.data = value;
            }
            get
            {
                return this.data;
            }
        }


        /// <summary>
        /// 所有科室
        /// </summary>
        private DataTable DeptData;
        /// <summary>
        /// 科室名称字段名
        /// </summary>
        private string DeptNameFieldName;
        /// <summary>
        /// 科室代码字段名
        /// </summary>
        private string DeptCodeFieldName;
        /// <summary>
        /// 上级科室名称
        /// </summary>
        private string ParentDeptNameFieldName;


        #endregion

        #region 事件

        /// <summary>
        /// 刷新事件
        /// </summary>
        public event EventHandler<RefreshEventArgs> OnRefresh;

        #endregion

        #region 界面事件方法

        private bool isDX = true;
        //单选多选切换
        private void btnDX_Click(object sender, EventArgs e)
        {
            isDX = !isDX;
            this.cbDept.Enabled = isDX;
            this.ctlDept.Enabled = !isDX;
            if(isDX)
            {
                this.btnDX.Text = "多选";
            }
            else
            {
                this.btnDX.Text = "单选";
            }
        }

        private void rbRQ_CheckedChanged(object sender, EventArgs e)
        {
            this.rbChanged();
        }

        // 日期修改事件
        private void cbRQ_SelectedValueChanged(object sender, EventArgs e)
        {
            if(!this.IsInit)
            {

                int startYear = Convert.ToInt32(this.cbStartNF.SelectedItem.ToString().Replace("年", ""));
                int endYear = Convert.ToInt32(this.cbEndNF.SelectedItem.ToString().Replace("年", ""));

                int startMounth = Convert.ToInt32(this.cbStartYF.SelectedItem.ToString().Replace("月", ""));
                int endMounth = Convert.ToInt32(this.cbEndYF.SelectedItem.ToString().Replace("月", ""));


                this.cbStartRQ.Items.Clear();
                for(int i = 1; i <= this.getDayCount(startYear, startMounth); i++)
                {
                    this.cbStartRQ.Items.Add(i + "日");
                }
                this.cbStartRQ.SelectedItem = 1 + "日";

                int dayCount = this.getDayCount(endYear, endMounth);
                this.cbEndRQ.Items.Clear();
                for(int i = 1; i <= dayCount; i++)
                {
                    this.cbEndRQ.Items.Add(i + "日");
                }
                this.cbEndRQ.SelectedItem = dayCount + "日";

            }
        }

        // 刷新按钮方法实现
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshEventArgs refreshEventArgs = new RefreshEventArgs()
            {
                SelectStartDateTime = this.selectStartDateTime,
                SelectEndDateTime = this.selectEndDateTime,
                SelectDateStr = this.selectDateStr,
                SelectDepts = this.selectDepts,
                IsUseDept = this.IsUseDept,
                IsSelectAllDept = this.IsSelectAllDept
            };
            refreshEventArgs.filterDataDeptStr = CJia.HISOLAP.App.Tools.Help.FilterDataDept(refreshEventArgs);
            if(this.OnRefresh != null)
            {
                this.OnRefresh(this, refreshEventArgs);
            }
        }

        #endregion

        #region 内部方法


        Dictionary<string, string> DXSelectDepts = new Dictionary<string, string>();
        /// <summary>
        /// 获取多选选择的科室
        /// </summary>
        /// <param name="treeListNodes"></param>
        private void getTreeListNodsCheck(DevExpress.XtraTreeList.Nodes.TreeListNodes treeListNodes)
        {
            if(treeListNodes != null && treeListNodes.Count > 0)
            {
                foreach(DevExpress.XtraTreeList.Nodes.TreeListNode treeListNode in treeListNodes)
                {
                    if(treeListNode.CheckState == CheckState.Checked)
                    {
                        DXSelectDepts.Add(treeListNode.GetValue(this.DeptNameFieldName).ToString(), treeListNode.GetValue(this.DeptCodeFieldName).ToString());
                    }
                    this.getTreeListNodsCheck(treeListNode.Nodes);
                }
            }
        }

        private bool IsInit = true;
        /// <summary>
        /// 初始化方法
        /// </summary>
        private void Init()
        {
            this.rbChanged();
            DateTime now = DateTime.Now;
            this.IsUseDept = false;
            int newYear = now.Year;
            for(int i = 0; i < 30; i++)
            {
                this.cbStartNF.Items.Add((newYear - i + "年").ToString());
                this.cbEndNF.Items.Add((newYear - i + "年").ToString());
            }
            this.cbStartNF.SelectedItem = newYear.ToString() + "年";
            this.cbEndNF.SelectedItem = newYear.ToString() + "年";

            for(int i = 1; i <= 4; i++)
            {
                this.cbStartJD.Items.Add(i + "季度");
                this.cbEndJD.Items.Add(i + "季度");
            }
            this.cbStartJD.SelectedItem = "1季度";
            this.cbEndJD.SelectedItem = "4季度";

            for(int i = 1; i <= 12; i++)
            {
                this.cbStartYF.Items.Add(i + "月");
                this.cbEndYF.Items.Add(i + "月");
            }
            this.cbStartYF.SelectedItem = "1月";
            this.cbEndYF.SelectedItem = "12月";

            for(int i = 1; i <= 31; i++)
            {
                this.cbStartRQ.Items.Add(i + "日");
                this.cbEndRQ.Items.Add(i + "日");
            }
            this.cbStartRQ.SelectedItem = "1日";
            this.cbEndRQ.SelectedItem = "31日";
            this.IsInit = false;
        }

        /// <summary>
        /// 测试方法
        /// </summary>
        private void Test()
        {


            DataTable dt = new DataTable();
            dt.Columns.Add("DEPT_NAME");
            dt.Columns.Add("DEPT_CODE");
            dt.Columns.Add("UP_DEPT_NAME");
            dt.Columns.Add("UP_DEPT_CODE");
            dt.Rows.Add("科室1", "1", "", "");
            dt.Rows.Add("科室11", "11", "科室1", "1");
            dt.Rows.Add("科室12", "12", "科室1", "1");
            dt.Rows.Add("科室13", "13", "科室1", "1");
            dt.Rows.Add("科室131", "131", "科室13", "13");
            dt.Rows.Add("科室132", "132", "科室13", "13");
            dt.Rows.Add("科室2", "2", "", "");
            dt.Rows.Add("科室3", "3", "", "");

            this.BindDepts(dt, "DEPT_NAME", "DEPT_CODE", "UP_DEPT_CODE");
        }

        /// <summary>
        /// 时间选择框是否显示
        /// </summary>
        private void rbChanged()
        {
            if(this.rbYear.Checked)
            {
                this.cbStartNF.Enabled = true;
                this.cbEndNF.Enabled = true;
                this.cbStartJD.Enabled = false;
                this.cbEndJD.Enabled = false;
                this.cbStartYF.Enabled = false;
                this.cbEndYF.Enabled = false;
                this.cbStartRQ.Enabled = false;
                this.cbEndRQ.Enabled = false;
            }
            if(this.rbJD.Checked)
            {
                this.cbStartNF.Enabled = true;
                this.cbEndNF.Enabled = true;
                this.cbStartJD.Enabled = true;
                this.cbEndJD.Enabled = true;
                this.cbStartYF.Enabled = false;
                this.cbEndYF.Enabled = false;
                this.cbStartRQ.Enabled = false;
                this.cbEndRQ.Enabled = false;
            }
            if(this.rbMounth.Checked)
            {
                this.cbStartNF.Enabled = true;
                this.cbEndNF.Enabled = true;
                this.cbStartJD.Enabled = false;
                this.cbEndJD.Enabled = false;
                this.cbStartYF.Enabled = true;
                this.cbEndYF.Enabled = true;
                this.cbStartRQ.Enabled = false;
                this.cbEndRQ.Enabled = false;
            }
            if(this.rbDay.Checked)
            {
                this.cbStartNF.Enabled = true;
                this.cbEndNF.Enabled = true;
                this.cbStartJD.Enabled = false;
                this.cbEndJD.Enabled = false;
                this.cbStartYF.Enabled = true;
                this.cbEndYF.Enabled = true;
                this.cbStartRQ.Enabled = true;
                this.cbEndRQ.Enabled = true;
            }
            if(this.rbDG.Checked)
            {
                this.cbEndNF.Enabled = false;
                this.cbEndJD.Enabled = false;
                this.cbEndYF.Enabled = false;
                this.cbEndRQ.Enabled = false;
            }
        }


        /// <summary>
        ///计算某年某月一共有多少天
        /// </summary>
        /// <param name="year"></param>
        /// <param name="mounth"></param>
        /// <returns></returns>
        private int getDayCount(int year, int mounth)
        {
            int dayCount = 31;
            switch(mounth)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    dayCount = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    dayCount = 30;
                    break;
                case 2:
                    if(year % 400 == 0 || year % 4 == 0 && year % 100 != 0)
                    {
                        dayCount = 29;
                    }
                    else
                    {
                        dayCount = 28;
                    }
                    break;
                default:
                    dayCount = 31;
                    break;
            }
            return dayCount;
        }

        #endregion

        #region  外部方法

        /// <summary>
        /// 绑定默认科室
        /// </summary>
        public void BindDefaultDepts()
        {
            //DataTable deptData = CJia.HISOLAP.App.Tools.Help.DeptData;
            this.BindDepts(this.Data, Data.Columns[1].ColumnName, Data.Columns[0].ColumnName, Data.Columns[2].ColumnName);
        }


        /// <summary>
        /// 绑定科室
        /// </summary>
        /// <param name="deptData">科室数据</param>
        /// <param name="deptNameFieldName">科室名称字段名</param>
        /// <param name="deptCodeFieldName">科室编号字段名</param>
        /// <param name="parentDeptCodeFieldName">上级科室名</param>
        public void BindDepts(DataTable deptData, string deptNameFieldName, string deptCodeFieldName, string parentDeptCodeFieldName)
        {
            if(deptData != null && deptData.Rows != null && deptData.Rows.Count > 0)
            {
                foreach(DataRow row in deptData.Rows)
                {
                    if(row[parentDeptCodeFieldName] == null || row[parentDeptCodeFieldName].ToString() == "")
                    {
                        row[parentDeptCodeFieldName] = "ALL";
                    }
                }


                this.DeptData = deptData;

                this.DeptNameFieldName = deptNameFieldName;
                this.DeptCodeFieldName = deptCodeFieldName;
                this.ParentDeptNameFieldName = parentDeptCodeFieldName;

                this.ctlDept.DataSource = this.DeptData.Copy();
                this.ctlDept.KeyFieldName = deptCodeFieldName;
                this.ctlDept.ParentFieldName = parentDeptCodeFieldName;
                this.treeListColumn1.FieldName = deptNameFieldName;

                this.cbDept.DataSource = this.DeptData;
                this.cbDept.DisplayMember = deptNameFieldName;
                this.cbDept.ValueMember = deptCodeFieldName;

                //this.cbIffield.SelectedValue.ToString() 

            }
            else
            {
                this.isUseDept = false;
                this.DeptData = null;
                this.DeptNameFieldName = "";
                this.DeptCodeFieldName = "";
                this.ParentDeptNameFieldName = "";
            }
            this.ctlDept.ExpandAll();
        }

        #endregion

    }


    /// <summary>
    /// 刷新事件参数类
    /// </summary>
    public class RefreshEventArgs : EventArgs
    {
        /// <summary>
        /// 查询的开始时间
        /// </summary>
        public DateTime SelectStartDateTime;
        /// <summary>
        /// 查询的结束时间
        /// </summary>
        public DateTime SelectEndDateTime;
        /// <summary>
        /// 查询的字符显示
        /// </summary>
        public string SelectDateStr;
        /// <summary>
        /// 是否使用了科室筛选
        /// </summary>
        public bool IsUseDept;
        /// <summary>
        /// 是否筛选了科室
        /// </summary>
        public bool IsSelectAllDept;
        /// <summary>
        /// 选择的科室 字典为 科室名称 与 科室编号对应 
        /// </summary>
        public Dictionary<string, string> SelectDepts;

        /// <summary>
        /// 选择过滤条件 对应的sql
        /// </summary>
        public string filterDataDeptStr;

    }

}

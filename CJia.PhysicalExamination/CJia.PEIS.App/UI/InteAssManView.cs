//***************************************************
// 文件名（File Name）:      InteAssManView.cs（智能评估UI层）
//
// 数据表（Tables）:         nothing
// 视图(Views)               nothing
//
// 作者（Author）:           郭婷
//
// 日期（Create Date）:     2013.4.9
//***************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.PEIS.App.UI
{
    /// <summary>
    /// 智能评估UI层
    /// </summary>
    public partial class InteAssManView : CJia.PEIS.Tools.View, CJia.PEIS.Views.IInteAssManView
    {
        public InteAssManView()
        {
            InitializeComponent();
            Init();
        }
        protected override object CreatePresenter()
        {
            return new Presenters.InteAssManPresenter(this);
        }

        /// <summary>
        /// 评估模板维护参数设置
        /// </summary>
        Views.InteAssEventArgs inteAssEventArgs = new Views.InteAssEventArgs();

        #region IAssTemManView成员
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler OnInit;
        /// <summary>
        /// 搜索科室/项目事件
        /// </summary>
        public event EventHandler<Views.InteAssEventArgs> OnSearchDeptPro;
        /// <summary>
        /// 搜索评估事件
        /// </summary>
        public event EventHandler<Views.InteAssEventArgs> OnSearchInteAss;
        /// <summary>
        /// 启用评估事件
        /// </summary>
        public event EventHandler<Views.InteAssEventArgs> OnStartInteAss;
        /// <summary>
        /// 停用评估事件
        /// </summary>
        public event EventHandler<Views.InteAssEventArgs> OnStopInteAss;
        /// <summary>
        /// 添加评估事件
        /// </summary>
        public event EventHandler OnAddInteAss;
        /// <summary>
        /// 保存评估
        /// </summary>
        public event EventHandler<Views.InteAssEventArgs> OnSaveInteAss;
        /// <summary>
        /// 绑定科室项目列表
        /// </summary>
        /// <param name="data"></param>
        public void ExeBindDeptPro(DataTable dtDeptPro)
        {
            trDeptPro.DataSource = dtDeptPro;
            if (dtDeptPro == null) return;
            trDeptPro.KeyFieldName = "key_id";
            trDeptPro.ParentFieldName = "parent_id";
        }
        /// <summary>
        /// 根据首拼绑定科室项目列表
        /// </summary>
        /// <param name="data"></param>
        public void ExeBindDeptProByPY(DataTable dtDeptPro)
        {
            trDeptPro.DataSource = dtDeptPro;
            if (dtDeptPro == null) return;
            trDeptPro.KeyFieldName = "key_id";
            trDeptPro.ParentFieldName = "parent_id";
        }
        /// <summary>
        /// 绑定全部评估列表
        /// </summary>
        /// <param name="dtInteAss"></param>
        public void ExeBindInteAss(DataTable dtInteAss)
        {
            gridInteAss.DataSource = dtInteAss;
            if (dtInteAss == null) return;
        }
        /// <summary>
        /// 根据评估首拼绑定评估列表
        /// </summary>
        /// <param name="dtInteAss"></param>
        public void ExeBindInteAssByPY(DataTable dtInteAss)
        {
            gridInteAss.DataSource = dtInteAss;
            if (dtInteAss == null) return;
        }
        /// <summary>
        /// 绑定性别
        /// </summary>
        public void ExeBindGender(DataTable dtGender)
        {
            cbGender.Properties.DataSource = dtGender;
            if (dtGender == null) return;
            cbGender.Properties.DisplayMember = "code_name";
            cbGender.Properties.ValueMember = "code_id";

            if (dtGender.Rows.Count == 0)
            {
                AddNewRowWhenNull(dtGender);
            }
            this.cbGender.EditValue = dtGender.Rows[0]["code_id"];  // 默认值
        }
        /// <summary>
        /// 绑定评估Seq值
        /// </summary>
        public void ExeBindNextInteAssSeq(int inteAssSeq)
        {
            txtAssID.Text = inteAssSeq.ToString();
        }
        #endregion

        #region 自定义函数
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            cbGender.EditValue = "7";//所有
            if (OnInit != null)
            {
                OnInit(null, null);
            }
        }
        /// <summary>
        /// 当查询下拉相应表数据为空时，添加一空行值
        /// </summary>
        /// <param name="dtData"></param>
        public void AddNewRowWhenNull(DataTable dtData)
        {
            DataRow dr = dtData.NewRow();
            object[] newRowContent = { 0, "" };
            dr.ItemArray = newRowContent;
            dtData.Rows.Add(dr);
        }
        /// <summary>
        /// 根据科室/项目首拼搜索
        /// </summary>
        public void SearchDeptPro()
        {
            inteAssEventArgs.DeptProPY = btnSearchDeptPro.Text;
            if (OnSearchDeptPro != null)
            {
                OnSearchDeptPro(null, inteAssEventArgs);
            }
        }
        /// <summary>
        /// 根据评估首拼搜索
        /// </summary>
        public void SearchInteAss()
        {
            inteAssEventArgs.InteAssPY = btnSearchInteAss.Text;
            if (OnSearchInteAss != null)
            {
                OnSearchInteAss(null, inteAssEventArgs);
            }
        }
        /// <summary>
        /// 启用评估
        /// </summary>
        public void StartInteAss()
        {
            if (gvInteAss.FocusedRowHandle < 0) return;
            inteAssEventArgs.InteAssId = int.Parse(gvInteAss.GetFocusedDataRow()["inte_assess_id"].ToString());
            string status = gvInteAss.GetFocusedDataRow()["status"].ToString();
            if (status == "1")
            {
                Message.Show("该评估正在使用中");
                return;
            }
            if (OnStartInteAss != null)
            {
                OnStartInteAss(null, inteAssEventArgs);
            }
            Init();
        }
        /// <summary>
        /// 停用评估
        /// </summary>
        public void StopInteAss()
        {
            if (gvInteAss.FocusedRowHandle < 0) return;
            inteAssEventArgs.InteAssId = int.Parse(gvInteAss.GetFocusedDataRow()["inte_assess_id"].ToString());
            string status = gvInteAss.GetFocusedDataRow()["status"].ToString();
            if (status == "0")
            {
                Message.Show("该评估已停用");
                return;
            }
            if (OnStopInteAss != null)
            {
                OnStopInteAss(null, inteAssEventArgs);
            }
            Init();
        }
        /// <summary>
        /// 添加评估
        /// </summary>
        public void AddInteAss()
        {
            txtInteAssName.Text = "";
            cbGender.EditValue = "7";
            txtMinAge.Text = "0";
            txtMaxAge.Text = "150";
            mlAssTem.Text = "";
            mlHealthPre.Text = "";
            mlRemark.Text = "";
            if (OnAddInteAss != null)
            {
                OnAddInteAss(null, null);
            }
            Init();
        }
        /// <summary>
        /// 保存评估
        /// </summary>
        public void SaveInteAss()
        {
            if (txtAssID.Text == "") return;
            inteAssEventArgs.InteAssId = int.Parse(txtAssID.Text);
            inteAssEventArgs.InteAssName = txtInteAssName.Text;
            inteAssEventArgs.Gender = int.Parse(cbGender.EditValue.ToString());
            inteAssEventArgs.MinAge = int.Parse(txtMinAge.Text);
            inteAssEventArgs.MaxAge = int.Parse(txtMaxAge.Text);
            inteAssEventArgs.AssTem = mlAssTem.Text;
            inteAssEventArgs.Remark = mlRemark.Text;
            inteAssEventArgs.UserId = User.UserData.Rows[0]["user_id"].ToString();
            inteAssEventArgs.InteAssPY = CJia.Controls.CJiaSpellEditor.ToChString(txtInteAssName.Text);
            if (OnSaveInteAss != null)
            {
                OnSaveInteAss(null, inteAssEventArgs);
            }
            Init();
        }
        /// <summary>
        /// 取消评估
        /// </summary>
        public void CancelInteAss()
        {
            if (txtAssID.Text == "") return;
            txtInteAssName.Text = "";
            cbGender.EditValue = "7";
            txtMinAge.Text = "0";
            txtMaxAge.Text = "150";
            mlAssTem.Text = "";
            mlHealthPre.Text = "";
            mlRemark.Text = "";
        }
        #endregion

        #region 控件事件
        //搜索科室/项目事件
        private void btnSearchDeptPro_Click(object sender, EventArgs e)
        {
            SearchDeptPro();
        }
        //搜索评估事件
        private void btnSearchInteAss_Click(object sender, EventArgs e)
        {
            SearchInteAss();
        }
        //评估网格点击事件
        private void gvInteAss_Click(object sender, EventArgs e)
        {
            if (gvInteAss.FocusedRowHandle < 0) return;
            DataRow drFocus = gvInteAss.GetFocusedDataRow();
            string status = drFocus["status"].ToString();
            txtAssID.Text = drFocus["inte_assess_id"].ToString();
            txtInteAssName.Text = drFocus["inte_assess_name"].ToString();
            cbGender.EditValue = drFocus["suit_gender"].ToString();
            txtMinAge.Text = drFocus["suit_min_age"].ToString();
            txtMaxAge.Text = drFocus["suit_max_age"].ToString();
            mlAssTem.Text = drFocus["assess_tem"].ToString();
            mlRemark.Text = drFocus["remark"].ToString();
            if (status == "1")//有效
            {
                btnStartInteAss.Enabled = false;
                btnStopInteAss.Enabled = true;
            }
            else
            {
                btnStartInteAss.Enabled = true;
                btnStopInteAss.Enabled = false;
            }
        }
        //启用评估事件
        private void btnStartInteAss_Click(object sender, EventArgs e)
        {
            StartInteAss();
        }
        //停用评估事件
        private void btnStopInteAss_Click(object sender, EventArgs e)
        {
            StopInteAss();
        }
        //添加评估事件
        private void btnAddInteAss_Click(object sender, EventArgs e)
        {
            AddInteAss();
        }
        //取消评估事件
        private void btnCancelInteAss_Click(object sender, EventArgs e)
        {
            CancelInteAss();
        }
        //保存评估事件
        private void btnSaveInteAss_Click(object sender, EventArgs e)
        {
            SaveInteAss();
        }
        //评估模板列表
        private void btnAssTem_Click(object sender, EventArgs e)
        {
            string assTem = mlAssTem.Text;
            AssTemView assTemView = new AssTemView(assTem);
            CJia.PEIS.Tools.Help.NewBorderForm("添加评估模板",assTemView);
        }
        #endregion        

        #region 控制停用模板样式
        private void gvInteAss_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (gvInteAss.GetRowCellValue(e.RowHandle, colStatus).ToString() == "停用")
            {
                //字体颜色
                e.Appearance.ForeColor = Color.DarkGray;
                //删除线
                e.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Strikeout);
            }
        }
        #endregion
    }
}

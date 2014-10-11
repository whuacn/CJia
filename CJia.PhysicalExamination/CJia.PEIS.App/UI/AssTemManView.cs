//***************************************************
// 文件名（File Name）:      AssTemManView.cs（评估模板维护UI层）
//
// 数据表（Tables）:         nothing
// 视图(Views)               nothing
//
// 作者（Author）:           郭婷
//
// 日期（Create Date）:     2013.4.7
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
    /// 评估模板维护UI层
    /// </summary>
    public partial class AssTemManView : CJia.PEIS.Tools.View, CJia.PEIS.Views.IAssTemManView
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AssTemManView()
        {
            InitializeComponent();
            Init();
        }
        protected override object CreatePresenter()
        {
            return new Presenters.AssTemManPresenter(this);
        }
        /// <summary>
        /// 评估模板维护参数设置
        /// </summary>
        Views.AssTemEventArgs assTemEventArgs = new Views.AssTemEventArgs();

        #region IAssTemManView成员
        /// <summary>
        /// 初始化事件
        /// </summary>
        public event EventHandler OnInit;
        /// <summary>
        /// 搜索事件
        /// </summary>
        public event EventHandler<Views.AssTemEventArgs> OnSearch;
        /// <summary>
        /// 启用事件
        /// </summary>
        public event EventHandler<Views.AssTemEventArgs> OnStart;
        /// <summary>
        /// 停用事件
        /// </summary>
        public event EventHandler<Views.AssTemEventArgs> OnStop;
        /// <summary>
        /// 添加事件
        /// </summary>
        public event EventHandler OnAdd;
        /// <summary>
        /// 保存事件
        /// </summary>
        public event EventHandler<Views.AssTemEventArgs> OnSave;

        /// <summary>
        /// 绑定科室
        /// </summary>
        /// <param name="data"></param>
        public void ExeBindDept(DataTable dtDept)
        {
            cbDept.Properties.DataSource = dtDept;
            if (dtDept == null) return;
            cbDept.Properties.DisplayMember = "dept_name";
            cbDept.Properties.ValueMember = "dept_id";

            cbDept2.Properties.DataSource = dtDept;
            if (dtDept == null) return;
            cbDept2.Properties.DisplayMember = "dept_name";
            cbDept2.Properties.ValueMember = "dept_id";

            if (dtDept.Rows.Count == 0)
            {
                AddNewRowWhenNull(dtDept);
            }
            this.cbDept.EditValue = dtDept.Rows[0]["dept_id"];  // 默认值
            this.cbDept2.EditValue = dtDept.Rows[0]["dept_id"];  // 默认值
        }
        /// <summary>
        /// 绑定性别
        /// </summary>
        /// <param name="dtGender"></param>
        public void ExeBindGender(DataTable dtGender)
        {
            cbGender.Properties.DataSource = dtGender;
            if (dtGender == null) return;
            cbGender.Properties.DisplayMember = "code_name";
            cbGender.Properties.ValueMember = "code_id";

            cbGender2.Properties.DataSource = dtGender;
            if (dtGender == null) return;
            cbGender2.Properties.DisplayMember = "code_name";
            cbGender2.Properties.ValueMember = "code_id";

            if (dtGender.Rows.Count == 0)
            {
                AddNewRowWhenNull(dtGender);
            }
            this.cbGender.EditValue = dtGender.Rows[0]["code_id"];  // 默认值
            this.cbGender2.EditValue = dtGender.Rows[0]["code_id"];  // 默认值
        }
        /// <summary>
        /// 绑定模板内容
        /// </summary>
        /// <param name="dtAssTem"></param>
        public void ExeBindAssTem(DataTable dtAssTem)
        {
            gridAssTem.DataSource = dtAssTem;
            if (dtAssTem == null) return;
        }
        /// <summary>
        /// 绑定下一个Seq值
        /// </summary>
        /// <param name="assTemSeq"></param>
        public void ExeBindAssTemSeq(int assTemSeq)
        {
            txtAssTemId.Text = assTemSeq.ToString();
        }
        #endregion

        #region 自定义函数
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
        /// 初始化
        /// </summary>
        private void Init()
        {
            btnStartAss.Enabled = false;
            btnStopAss.Enabled = true;
            if (OnInit != null)
            {
                OnInit(null, null);
            }
        }
        /// <summary>
        /// 搜索模板
        /// </summary>
        public void SearchAssTem()
        {
            assTemEventArgs.ContentPY = txtContentPY.Text.ToString();
            if (cbDept.EditValue.ToString() != "")
            {
                assTemEventArgs.DeptId = int.Parse(cbDept.EditValue.ToString());
            }
            if (cbGender.EditValue.ToString() != "")
            {
                assTemEventArgs.Gender = int.Parse(cbGender.EditValue.ToString());
            }
            if (cbStopAss.Checked)
            {
                btnStartAss.Enabled = true;
                btnStopAss.Enabled = false;
                assTemEventArgs.IsStopAss = true;
            }
            else 
            {
                btnStartAss.Enabled = false;
                btnStopAss.Enabled = true;
                assTemEventArgs.IsStopAss = false;
            }
            if (OnSearch != null)
            {
                OnSearch(null, assTemEventArgs);
            }
        }
        /// <summary>
        /// 启用模板
        /// </summary>
        public void StartAssTem()
        {
            if (gvAssTem.FocusedRowHandle < 0) return;
            string status = gvAssTem.GetFocusedDataRow()["status"].ToString();
            if (status == "1")
            {
                Message.Show("该模板正在使用中");
                return;
            }
            assTemEventArgs.AssTemId = int.Parse(gvAssTem.GetFocusedDataRow()["assess_tem_id"].ToString());
            if (OnStart != null)
            {
                OnStart(null, assTemEventArgs);
            }
            SearchAssTem();
        }
        /// <summary>
        /// 停用模板
        /// </summary>
        public void StopAssTem()
        {
            if (gvAssTem.FocusedRowHandle < 0) return;
            string status = gvAssTem.GetFocusedDataRow()["status"].ToString();
            if (status == "0")
            {
                Message.Show("该模板已停用");
                return;
            }
            assTemEventArgs.AssTemId = int.Parse(gvAssTem.GetFocusedDataRow()["assess_tem_id"].ToString());
            if (OnStop != null)
            {
                OnStop(null, assTemEventArgs);
            }
            SearchAssTem();
        }
        /// <summary>
        /// 添加模板
        /// </summary>
        public void AddAssTem()
        {
            Init();
            mlContent.Text = "";
            mlRemark.Text = "";
            if (OnAdd != null)
            {
                OnAdd(null, null);
            }
            SearchAssTem();
        }
        /// <summary>
        /// 保存模板
        /// </summary>
        public void SaveAssTem()
        {
            if (txtAssTemId.Text == "") return;
            assTemEventArgs.AssTemId = int.Parse(txtAssTemId.Text);
            assTemEventArgs.DeptId = int.Parse(cbDept2.EditValue.ToString());
            assTemEventArgs.Gender = int.Parse(cbGender2.EditValue.ToString());
            assTemEventArgs.AssTemContent = mlContent.Text;
            assTemEventArgs.ContentPY = CJia.Controls.CJiaSpellEditor.ToChString(mlContent.Text);
            assTemEventArgs.Remark = mlRemark.Text;
            assTemEventArgs.UserId = User.UserData.Rows[0]["user_id"].ToString();
            if (OnSave != null)
            {
                OnSave(null, assTemEventArgs);
            }
            SearchAssTem();
        }
        /// <summary>
        /// 取消（清空内容）
        /// </summary>
        public void CancelAssTem()
        {
            if (txtAssTemId.Text == "") return;
            txtAssTemId.Text = "";
            Init();
            mlContent.Text = "";
            mlRemark.Text = "";
        }
        #endregion

        #region 控件事件
        // 点击模板内容网格事件
        private void gvAssTem_Click(object sender, EventArgs e)
        {
            if (gvAssTem.FocusedRowHandle < 0) return;
            DataRow drFocus = gvAssTem.GetFocusedDataRow();
            string status = drFocus["status"].ToString();
            txtAssTemId.Text = drFocus["assess_tem_id"].ToString();
            cbDept2.EditValue = drFocus["suit_dept_id"].ToString();
            cbGender2.EditValue = drFocus["suit_gender"].ToString();
            mlContent.Text = drFocus["assess_tem_content"].ToString();
            mlRemark.Text = drFocus["remark"].ToString();
            if (status == "1")//有效
            {
                btnStartAss.Enabled = false;
                btnStopAss.Enabled = true;
            }
            else
            {
                btnStartAss.Enabled = true;
                btnStopAss.Enabled = false;
            }
        }
        //搜索按钮事件
        private void btnAssTem_Click(object sender, EventArgs e)
        {
            SearchAssTem();
        }
        //启用
        private void btnStartAss_Click(object sender, EventArgs e)
        {
            StartAssTem();
        }
        //停用
        private void btnStopAss_Click(object sender, EventArgs e)
        {
            StopAssTem();
        }
        //添加
        private void btnAddAssTem_Click(object sender, EventArgs e)
        {
            AddAssTem();
        }
        //保存
        private void btnSaveAss_Click(object sender, EventArgs e)
        {
            SaveAssTem();
        }
        //取消
        private void btnCancelAss_Click(object sender, EventArgs e)
        {
            CancelAssTem();
        }
        #endregion

        #region 控制停用模板样式
        private void gvAssTem_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (gvAssTem.GetRowCellValue(e.RowHandle, colTemStatus).ToString() == "停用")
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CJia.PIVAS.App.UI.DataManage
{
    /// <summary>
    /// 批次对应冲药Ui层
    /// </summary>
    public partial class BatchToRedDrugView : CJia.PIVAS.Tools.View, CJia.PIVAS.Views.DataManage.IBatchToRedDrugView
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public BatchToRedDrugView()
        {
            InitializeComponent();
        }

        //重写创建P层
        protected override object CreatePresenter()
        {
            return new Presenters.DataManage.BatchToRedDrugPresenter(this);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GcBatch_Load(object sender, EventArgs e)
        {
            this.OnLoadData(null, null);
        }

        //修改
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            CJia.PIVAS.Views.DataManage.BatchToRedDrugEventArgs editargs = new Views.DataManage.BatchToRedDrugEventArgs();
            editargs.TimeType = "2";
            this.OnInitEdit(null, editargs);
        }


        #region【实现接口】
        //初始化gridcontrol数据
        public event EventHandler<Views.DataManage.BatchToRedDrugEventArgs> OnLoadData;

        //初始化编辑页面的数据
        public event EventHandler<Views.DataManage.BatchToRedDrugEventArgs> OnInitEdit;

        //为gridcontrol控件绑定数据源
        public void ExeinitData(DataTable dt)
        {
            GcBatch.DataSource = dt;
        }
        
        //初始化弹出框修改界面的值
        public void ExeinitEditData(DataTable dt) 
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                DataRow dr = gridView1.GetFocusedDataRow();
                long timeId = long.Parse(dr["TIME_ID"].ToString());
                long batchId = long.Parse(dr["BATCH_ID"].ToString());
                string batchTime = dr["BATCH_TIME"].ToString();
                EditBatchToRedDrugView editBatchToRedDrug = new EditBatchToRedDrugView(dt, timeId, batchId, batchTime);
                this.ShowAsWindow("修改批次对应冲药和时间", editBatchToRedDrug);
                this.OnLoadData(null, null);
            }
            else
            {
                CJia.PIVAS.Tools.Message.Show("请选则数据");
            }
        }

        #endregion

        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    BtnRefresh.Focus();
                    this.OnLoadData(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}

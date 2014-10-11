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
    /// 频率对应批次的UI层
    /// </summary>
    public partial class FrequencyToBatchView : CJia.PIVAS.Tools.View, CJia.PIVAS.Views.DataManage.IFrequencyToBatchView
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public FrequencyToBatchView()
        {
            InitializeComponent();
        }

        //重写CreatePresenter()
        protected override object CreatePresenter()
        {
            return new Presenters.DataManage.FrequencyToBatchPresenter(this);
        }

        //初始化载入事件
        private void GcFrequencyToBatch_Load(object sender, EventArgs e)
        {
            this.OnLoadData(null, null);
        }

        //添加频率对应批次数据
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddFrequenceToBeachView adddFrequency = new AddFrequenceToBeachView();
            ShowAsWindow("增加频率对应批次", adddFrequency);
            this.OnLoadData(null, null);
        }

        //修改频率对应批次数据
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                DataRow dr = gridView1.GetFocusedDataRow();
                long frequencybatchid = long.Parse(dr["FREQUENCY_BATCH_ID"].ToString());
                string frequencyName = dr["FREQUENCY_NAME"].ToString();
                string batchs = dr["BATCHS_NAME"].ToString();
                List<int> ListBatch = CJia.PIVAS.Common.BatchHandle(batchs);
                EditFrequencyToBatchView editFrequency = new EditFrequencyToBatchView(1, frequencybatchid, frequencyName, CJia.PIVAS.Common.BatchHandle(batchs));
                ShowAsWindow("修改频率对应批次", editFrequency);
                this.OnLoadData(null, null);
            }
            else
            {
                CJia.PIVAS.Tools.Message.Show("请选则数据");
            }
        }

        //删除选中频率对应批次的数据
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                if (CJia.PIVAS.Tools.Message.ShowQuery("确认是否删除", CJia.PIVAS.Tools.Message.Button.YesNo) == CJia.PIVAS.Tools.Message.Result.Yes)
                {
                    DataRow dr = gridView1.GetFocusedDataRow();
                    CJia.PIVAS.Views.DataManage.FrequencyToBatchEventArgs frequencybatch = new Views.DataManage.FrequencyToBatchEventArgs();
                    frequencybatch.FrequencyBatchId = long.Parse(dr["FREQUENCY_BATCH_ID"].ToString());
                    frequencybatch.UserId = User.UserId;
                    this.OnDeleteFrequencyBatch(null, frequencybatch);
                    this.OnLoadData(null, null);
                }
                else
                {
                    return;
                }
            }
            else
            {
                CJia.PIVAS.Tools.Message.Show("请选则数据");
            }
        }


        #region【实现接口】

        //初始化频率对应批次数据
        public event EventHandler<Views.DataManage.FrequencyToBatchEventArgs> OnLoadData;

        //添加频率对应批次
        public event EventHandler<Views.DataManage.FrequencyToBatchEventArgs> OnAddFrequencyToBatch;

        //删除频率对应批次
        public event EventHandler<Views.DataManage.FrequencyToBatchEventArgs> OnDeleteFrequencyBatch;

        //为gridcontrol绑定数据源
        public void ExeinitData(DataTable dt)
        {
            GcFrequencyToBatch.DataSource = dt;
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

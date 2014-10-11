using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace CJia.PIVAS.App.UI.DataManage
{
    /// <summary>
    /// 修改批次对应冲药UI层
    /// </summary>
    public partial class EditBatchToRedDrugView : CJia.PIVAS.Tools.View, CJia.PIVAS.Views.DataManage.IEditBatchToRedDrugView
    {
        /// <summary>
        /// 修改批次对应冲药的构造方法
        /// </summary>
        public EditBatchToRedDrugView()
        {
            InitializeComponent();
        }

        //重写穿件P层方法
        protected override object CreatePresenter()
        {
            return new Presenters.DataManage.EditBatchToRedDrugPresenter(this);
        }

        /// <summary>
        /// 记录选中行的TimeId（第一次冲药，第二次冲药）
        /// </summary>
        private long TimeId;   
 
        /// <summary>
        /// 记录选中行的Batchi（第几批次）
        /// </summary>
        private long BatchId;

        /// <summary>
        /// 修改的批次执行时间是否有重叠
        /// </summary>
        private bool IsRepeat;

        /// <summary>
        /// 修改页面的带参数构造方法
        /// </summary>
        /// <param name="dt">冲药的DataTable</param>
        /// <param name="timeId">当前选中行的TimeID</param>
        public EditBatchToRedDrugView(DataTable dt,long timeId,long batchId ,string batchTime)
        {
            InitializeComponent();
            TimeId = timeId;
            BatchId = batchId;
            TeBatchTime.Time = DateTime.Parse(batchTime);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CheckedListBoxItem item = new CheckedListBoxItem(dt.Rows[i]["Time_id"],dt.Rows[i]["TIME_NAME"].ToString());
                ClcRedDrug.Items.Add(item);
                //选中当前批次对应的冲药
                if (timeId == long.Parse(dt.Rows[i]["Time_id"].ToString()))
                {
                    item.CheckState = CheckState.Checked;
                }
            }  

        }
       
        // 控制单选  只能选一个
        private void ClcRedDrug_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            for (int i = 0; i < ClcRedDrug.Items.Count; i++)
            {
                if (i != e.Index)//除去触发SelectedIndexChanged事件以外的选中项都处于未选中状态  
                {
                    ClcRedDrug.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
                }
            }
        }

        //修改批次对应冲药
        private void BtnSure_Click(object sender, EventArgs e)
        {
            EditBatchToDrug();
        }

        private void EditBatchToDrug()
        {
            bool isSelect = false; //表示是否选中了冲药
            if (CJia.PIVAS.Tools.Message.ShowQuery("是否确认修改", CJia.PIVAS.Tools.Message.Button.YesNo) == CJia.PIVAS.Tools.Message.Result.Yes)
            {
                CJia.PIVAS.Views.DataManage.EditBatchToRedDrugEventArgs editbatch = new Views.DataManage.EditBatchToRedDrugEventArgs();
                for (int i = 0; i < ClcRedDrug.Items.Count; i++)
                {
                    if (ClcRedDrug.Items[i].CheckState == CheckState.Checked)
                    {
                        editbatch.Time_id = long.Parse(ClcRedDrug.Items[i].Value.ToString());
                        isSelect = isSelect || true;
                    }
                }
                if (!isSelect)
                {
                    CJia.PIVAS.Tools.Message.Show("请选择批次！");
                    return;
                }
                editbatch.Batch_id = BatchId;
                editbatch.BatchTime = TeBatchTime.Text;
                editbatch.User_id = User.UserId;
                this.OnIsRepeat(null, editbatch);
                if (!IsRepeat)
                {
                    this.OnUpdateBatchSet(null, editbatch);
                    this.CloseWindow();
                }
                else
                {
                    CJia.PIVAS.Tools.Message.ShowWarning("修改的批次执行时间应该在前后两个批次之间");
                }
            }
            else
            {
                return;
            }
        }

        //取消
        private void BtnCancle_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        #region【实现接口】

        //修改批次
        public event EventHandler<Views.DataManage.EditBatchToRedDrugEventArgs> OnUpdateBatchSet;

        //判断添加的批次执行时间是否有重叠
        public event EventHandler<Views.DataManage.EditBatchToRedDrugEventArgs> OnIsRepeat;

        //传回UI层告知修改是否有重复
        public void ExeIsRepeat(bool isRepeat)
        {
            IsRepeat = isRepeat;
        }
        #endregion

        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    BtnSure.Focus();
                    this.EditBatchToDrug();
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion








        
    }
}

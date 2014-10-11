using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;


namespace CJia.PIVAS.App.UI.DataManage
{
    /// <summary>
    /// 修改频率对应批次的P层
    /// </summary>
    public partial class EditFrequencyToBatchView : CJia.PIVAS.Tools.View, CJia.PIVAS.Views.DataManage.IEditFrequencyToBatchView
    {
        public EditFrequencyToBatchView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 缓存  把频率对应批次ID存起来
        /// </summary>
        private long Frequencybatchid;

        /// <summary>
        /// 初始值要选中的批次
        /// </summary>
        private List<int> Batchs;

        /// <summary>
        /// 组号
        /// </summary>
        private string GroupIndex;

        /// <summary>
        /// 定义是谁进的这个页面 1代表静态数据维护 2代表审方
        /// </summary>
        private int WhichPage;

        /// <summary>
        /// 带参数的构造方法(静态数据维护用)
        /// </summary>
        /// <param name="frequencyId">频率Id</param>
        /// <param name="frequencyName">频率名称</param>
        public EditFrequencyToBatchView(int whichPage,long frequencybatchid, string frequencyName, List<int> batchs)
        {
            InitializeComponent();
            TeFrequency.Text = frequencyName;
            Frequencybatchid = frequencybatchid;
            Batchs = batchs;
        }

        /// <summary>
        /// 带参数的构造方法 （审方用）
        /// </summary>
        /// <param name="groupIndex"></param>
        /// <param name="frequency"></param>
        /// <param name="batchs"></param>
        public EditFrequencyToBatchView(int whichPage,string groupIndex, string frequency, List<int> batchs)
        {
            InitializeComponent();
            WhichPage = whichPage;
            GroupIndex = groupIndex;
            TeFrequency.Text = frequency;
            Batchs = batchs;
        }


        /// <summary>
        /// 初始化数据事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditFrequencyToBatchView_Load(object sender, EventArgs e)
        {
            this.OnInitLoadBatch(null, null);
        }

        /// <summary>
        /// 确定修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSure_Click(object sender, EventArgs e)
        {
            this.EditFrequencyToBatch();
        }

        /// <summary>
        /// 修改频率对应批次
        /// </summary>
        private void EditFrequencyToBatch()
        {
            if (CJia.PIVAS.Tools.Message.ShowQuery("确认是否修改", CJia.PIVAS.Tools.Message.Button.YesNo) == CJia.PIVAS.Tools.Message.Result.Yes)
            {
                CJia.PIVAS.Views.DataManage.EditFrequencyToBatchEventArgs editFreBatArgs = new Views.DataManage.EditFrequencyToBatchEventArgs();
                if (WhichPage == 2)
                {
                    editFreBatArgs.UserId = User.UserId;
                    editFreBatArgs.BatchsName = CJia.PIVAS.Common.GetBatchsName(ClbcBatch);
                    editFreBatArgs.GroupIndex = GroupIndex;
                    this.OnUpdateCheckFrequencyBatch(null, editFreBatArgs);
                }
                else
                {
                    editFreBatArgs.FrequencyBatchId = Frequencybatchid;
                    editFreBatArgs.BatchsName = CJia.PIVAS.Common.GetBatchsName(ClbcBatch);
                    editFreBatArgs.UserId = User.UserId;
                    this.OnUpdateFrequencyBatch(null, editFreBatArgs);
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 点击取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancle_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.DataManage.EditFrequencyToBatchPresenter(this);
        }


        #region【实现接口】

        //初始化页面数据
        public event EventHandler<Views.DataManage.EditFrequencyToBatchEventArgs> OnInitLoadBatch;

        //修改频率对应批次
        public event EventHandler<Views.DataManage.EditFrequencyToBatchEventArgs> OnUpdateFrequencyBatch;

        //审方修改批次
        public event EventHandler<Views.DataManage.EditFrequencyToBatchEventArgs> OnUpdateCheckFrequencyBatch;

        /// <summary>
        /// 初始化批次多选框并选中次频率对应的批次
        /// </summary>
        /// <param name="dt"></param>
        public void ExeInitLoadBatch(DataTable dt)
        {
            //int j = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CheckedListBoxItem item = new CheckedListBoxItem(dt.Rows[i]["BATCH_NO"], dt.Rows[i]["BATCH_NAME"].ToString());
                ClbcBatch.Items.Add(item);
                for (int j = 0; j < Batchs.Count; j++)
                {
                    if (Batchs[j] == int.Parse(dt.Rows[i]["BATCH_NO"].ToString()))
                    {
                        item.CheckState = CheckState.Checked;
                    }
                   
                }
            }
            
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="isSuccess"></param>
        public void ExeCloseWindow(bool isSuccess)
        {
            if (isSuccess)
            {
                this.ParentForm.Close();
            }
        }
        #endregion

        #region 【自定义方法】
        ///// <summary>
        ///// 获取到选中的批次
        ///// </summary>
        ///// <returns></returns>
        //public static string GetBatchsName(CheckedListBoxControl clbc)
        //{
        //    string batchasName="";
        //    for (int i = 0; i < clbc.Items.Count; i++)
        //    {
        //        if (clbc.Items[i].CheckState == CheckState.Checked)
        //        {
        //            batchasName = batchasName + clbc.Items[i].Value + "-";
        //        }
        //    }
        //    return batchasName;
        //}

        #endregion

        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    BtnSure.Focus();
                    this.EditFrequencyToBatch();
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
        
    }
}

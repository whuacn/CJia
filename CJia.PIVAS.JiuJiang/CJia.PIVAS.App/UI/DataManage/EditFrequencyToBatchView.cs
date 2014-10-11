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
        private List<string> Batchs;

        private string illfieldId;

        /// <summary>
        /// 选中的批次对应的数字
        /// </summary>
        private List<string> BatchsInt = new List<string>();

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
        public EditFrequencyToBatchView(int whichPage, long frequencybatchid, string frequencyName, List<string> batchs)
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
        public EditFrequencyToBatchView(int whichPage, string groupIndex, string frequency, string illfieldId, List<string> batchs)
        {
            InitializeComponent();
            WhichPage = whichPage;
            GroupIndex = groupIndex;
            TeFrequency.Text = frequency;
            this.illfieldId = illfieldId;
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
            if(IsSeclect())
            {
                if(CJia.PIVAS.Tools.Message.ShowQuery("确认是否修改", CJia.PIVAS.Tools.Message.Button.YesNo) == CJia.PIVAS.Tools.Message.Result.Yes)
                {
                    CJia.PIVAS.Views.DataManage.EditFrequencyToBatchEventArgs editFreBatArgs = new Views.DataManage.EditFrequencyToBatchEventArgs();
                    if(WhichPage == 2)
                    {
                        string batchStr = this.OnQueryFrequencytoBatch(this.TeFrequency.Text, this.illfieldId).ToString();
                        if(batchStr.Length / 2 != this.BatchsInt.Count)
                        {
                            Message.ShowWarning("只能修改批次！不能增加或减少批次！");
                            return;
                        }
                        //if(this.BatchsInt.Count != this.Batchs.Count)
                        //{
                        //    Message.ShowWarning("只能修改批次！不能增加或减少批次！");
                        //    return;
                        //}
                        editFreBatArgs.UserId = User.UserId;
                        editFreBatArgs.BatchsName = CJia.PIVAS.Common.GetBatchsName(this.BatchsInt);
                        editFreBatArgs.GroupIndex = GroupIndex;
                        this.OnUpdateCheckFrequencyBatch(null, editFreBatArgs);
                    }
                    else
                    {
                        editFreBatArgs.FrequencyBatchId = Frequencybatchid;
                        editFreBatArgs.BatchsName = CJia.PIVAS.Common.GetBatchsName(this.BatchsInt);
                        editFreBatArgs.UserId = User.UserId;
                        this.OnUpdateFrequencyBatch(null, editFreBatArgs);
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                Message.Show("您未选择该频率对应批次！请选择！");
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

        //以选排序双击事件
        private void lbcUseOrderBy_DoubleClick(object sender, EventArgs e)
        {
            this.ToRitht();
        }

        //未选排序双击事件
        private void lbcNoUseOrderBy_DoubleClick(object sender, EventArgs e)
        {
            this.Tolift();
        }

        //排序向左按钮单机事件
        private void btnToLift_Click(object sender, EventArgs e)
        {
            this.Tolift();
        }

        //排序向右按钮单击事件
        private void butToRigth_Click(object sender, EventArgs e)
        {
            this.ToRitht();
        }


        #region【实现接口】

        //初始化页面数据
        public event EventHandler<Views.DataManage.EditFrequencyToBatchEventArgs> OnInitLoadBatch;

        //修改频率对应批次
        public event EventHandler<Views.DataManage.EditFrequencyToBatchEventArgs> OnUpdateFrequencyBatch;

        //审方修改批次
        public event EventHandler<Views.DataManage.EditFrequencyToBatchEventArgs> OnUpdateCheckFrequencyBatch;

        //根据频率获取批次
        public event Tools.Delegate.ResTwoPar OnQueryFrequencytoBatch;


        /// <summary>
        /// 初始化批次多选框并选中次频率对应的批次
        /// </summary>
        /// <param name="dt"></param>
        public void ExeInitLoadBatch(DataTable dt)
        {
            //int j = 0;
            dt = CJia.PIVAS.Tools.Helper.GetDataSource(dt.Select(" BATCH_ID <>  '1000000005' "));
            dt.DefaultView.Sort = "BATCH_NO asc";
            dt = dt.DefaultView.ToTable();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                lbcNoUseBatch.Items.Add(dt.Rows[i]["BATCH_NAME"].ToString() + ' ' + dt.Rows[i]["BATCH_NO"].ToString());
                for(int j = 0; j < Batchs.Count; j++)
                {
                    string batchNo = dt.Rows[i]["BATCH_NO"].ToString();
                    if(Batchs[j] == batchNo)
                    {
                        this.BatchsInt.Add(dt.Rows[i]["BATCH_NO"].ToString());
                        lbcUseBatch.Items.Add(dt.Rows[i]["BATCH_NAME"].ToString() + ' ' + dt.Rows[i]["BATCH_NO"].ToString());
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
            if(isSuccess)
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

        /// <summary>
        /// 判断多选框checklistboxcontrol是否有选中  true为已选中
        /// </summary>
        /// <param name="clbc"></param>
        /// <returns></returns>
        private bool IsSeclect()
        {
            if(this.lbcUseBatch.Items == null || this.lbcUseBatch.Items.Count == 0)
            {
                return false;
            }
            return true;
        }


        //将未选着的排序方式list中选着的一行转移到已选择的排序方式list中
        private void Tolift()
        {
            if(this.lbcNoUseBatch.SelectedItem != null)
            {
                string selectItem = this.lbcNoUseBatch.SelectedItem.ToString();
                this.lbcUseBatch.Items.Add(selectItem);
                this.BatchsInt.Add(selectItem.Split(' ')[1]);
            }
        }

        //将已选择的排序方式list中选着的一行转移到未选择的排序方式list中
        private void ToRitht()
        {
            if(this.lbcUseBatch.SelectedItem != null)
            {
                string selectItem = this.lbcUseBatch.SelectedItem.ToString();
                this.BatchsInt.Remove(selectItem.Split(' ')[1]);
                this.lbcUseBatch.Items.Remove(selectItem);
            }
            //将未选着的排序方式list中选着的一行转移到已选择的排序方式list中
        }

        #endregion

        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch(keyData)
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

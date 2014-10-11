using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Health.App.UI
{
    public partial class BorrowTimeLenthView : CJia.Health.Tools.View, CJia.Health.Views.IBorrowTimeLenthView
    {
        Health.Views.BorrowTimeLenthArgs borrowTimeArgs = new Views.BorrowTimeLenthArgs();
        public BorrowTimeLenthView()
        {
            InitializeComponent();
            OnQueryDocDescript(null, null);
            OnQueryBorrowTime(null, null);
        }

        protected override object CreatePresenter()
        {
            return new Presenters.BorrowTimeLenthPresenter(this);
        }

        #region【事件】
        private void gcBorrowTime_SizeChanged(object sender, EventArgs e)
        {
            int formHeight = this.Height;
            int formWidth = this.Width;
            int pnlHeight;
            pnlHeight = formHeight;
            int location = (formWidth - pnlBorrpwTime.Width) / 2;
            pnlBorrpwTime.Location = new Point(location, 5);
            this.VerticalScroll.Value = VerticalScroll.Minimum;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddBorrowTime_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(int.Parse(txtBorrowTime.Text).ToString());
            //Form frm = new Form();
            //AddBorrowTimeView add = new AddBorrowTimeView();
            //frm.Controls.Add(add);
            //frm.ShowDialog();
            if (txtBorrowTime.Text != "")
            {
                GetArgs();
                borrowTimeArgs.BorrowTimeId = " ";
                Health.Models.BorrowTimeLenthModel model = new Models.BorrowTimeLenthModel();
                int i = model.CheckDesRepeat(borrowTimeArgs.DocDes, borrowTimeArgs.BorrowTimeId);
                if (i == 0)
                {
                    if (CJia.Health.Tools.Message.ShowQuery("是否添加此数据", CJia.Health.Tools.Message.Button.YesNo) == CJia.Health.Tools.Message.Result.Yes)
                    {
                        GetArgs();
                        OnInsertBorrowTime(null, borrowTimeArgs);
                        OnQueryBorrowTime(null, null);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    Message.ShowWarning("此职称数据已存在");
                }
            }
            else
            {
                MessageBox.Show("借阅时间不能为空");
            }
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdateBorrowTime_Click(object sender, EventArgs e)
        {
            if (txtBorrowTime.Text != "")
            {
                GetArgs();
                Health.Models.BorrowTimeLenthModel model = new Models.BorrowTimeLenthModel();
                int i = model.CheckDesRepeat(borrowTimeArgs.DocDes, borrowTimeArgs.BorrowTimeId);
                if (i == 0)
                {
                    if (CJia.Health.Tools.Message.ShowQuery("是否修改此数据", CJia.Health.Tools.Message.Button.YesNo) == CJia.Health.Tools.Message.Result.Yes)
                    {
                        OnUpdateBorrowTime(null, borrowTimeArgs);
                        OnQueryBorrowTime(null, null);
                    }
                    else
                    { return; }
                }
                else
                {
                    Message.ShowWarning("已有此职称数据，请点击此职称修改");
                }
            }
            else
            {
                MessageBox.Show("借阅时间不能为空");
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteBorrowTime_Click(object sender, EventArgs e)
        {
            GetArgs();
            if (CJia.Health.Tools.Message.ShowQuery("是否修改此数据", CJia.Health.Tools.Message.Button.YesNo) == CJia.Health.Tools.Message.Result.Yes)
            {
                OnDeleteBorrowTime(null, borrowTimeArgs);
                OnQueryBorrowTime(null, null);
            }
            else
            {
                return;
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetFocusData();
        }
        #endregion

        #region【接口实现】
        public event EventHandler<Views.BorrowTimeLenthArgs> OnQueryBorrowTime;

        public event EventHandler<Views.BorrowTimeLenthArgs> OnQueryDocDescript;

        public event EventHandler<Views.BorrowTimeLenthArgs> OnInsertBorrowTime;

        public event EventHandler<Views.BorrowTimeLenthArgs> OnUpdateBorrowTime;

        public event EventHandler<Views.BorrowTimeLenthArgs> OnDeleteBorrowTime;

        public void ExeBindData(DataTable dt)
        {
            gcBorrowTime.DataSource = dt;
        }

        public void ExeBindDocDescript(DataTable dt)
        {
            cbDocDes.Properties.DataSource = dt;
            cbDocDes.Properties.DisplayMember = "NAME";
            cbDocDes.Properties.ValueMember = "CODE";
        }
        #endregion

        #region【普通方法】

        /// <summary>
        /// 控制借阅时间输入框只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBorrowTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            { e.Handled = true; }
        }

        /// <summary>
        /// 获取参数列表
        /// </summary>
        private void GetArgs()
        {
            borrowTimeArgs.DocDes = cbDocDes.EditValue.ToString();
            borrowTimeArgs.BorrowTime = int.Parse(txtBorrowTime.Text);
        }

        /// <summary>
        /// 获取网格焦点数据并为输入框赋值
        /// </summary>
        private void GetFocusData()
        {
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr != null)
            {
                cbDocDes.EditValue = dr["DOC_DESCRIPT_ID"].ToString();
                //string str = dr["NAME"].ToString();
                //cbDocDes.Text = str;
                //cbDocDes.SelectedText = str;
                string strTimeLenth = dr["TIME_LENTH"].ToString();
                txtBorrowTime.Text = strTimeLenth.Substring(0, strTimeLenth.Length - 3);
                borrowTimeArgs.BorrowTimeId = dr["BORROW_TIME_ID"].ToString();
            }
        }

        #endregion

        #region【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    BtnAddBorrowTime.Focus();
                    this.BtnAddBorrowTime_Click(null, null);
                    return true;
                case Keys.F2:
                    BtnUpdateBorrowTime.Focus();
                    this.BtnUpdateBorrowTime_Click(null, null);
                    return true;
                case Keys.F3:
                    BtnDeleteBorrowTime.Focus();
                    BtnDeleteBorrowTime_Click(null, null);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

    }
}

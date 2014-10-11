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
    public partial class CheckReasonView : UserControl
    {
        public bool isOk = false;

        public string reason
        {
            get
            {
                return this.txtCheckReason.Text;
            }
        }


        public string reasonId;

        public CheckReasonView()
        {
            InitializeComponent();
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            isOk = true;
            this.FindForm().Close();
        }

        /// <summary>
        /// 绑定常用审核原因
        /// </summary>
        /// <param name="data"></param>
        public void BindData(DataTable data)
        {
            this.cgCheckReason.DataSource = data;
        }

        /// <summary>
        /// 增加审核原因
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCheckReason_Click(object sender, EventArgs e)
        {
            this.OnAddCheckReason(null, new CheckReasonEventArgs()
            {
                checkReason = this.txtCheckReason.Text.Trim()
            });
            DataTable dt = this.cgCheckReason.DataSource as DataTable;
            DataRow dr = dt.NewRow();
            dr["CHECK_REASON"] = this.txtCheckReason.Text.Trim();
            dt.Rows.Add(dr);
        }

        private void btnRemonCheckReason_Click(object sender, EventArgs e)
        {
            DataRow checkReason = this.gvCheckReason.GetFocusedDataRow();
            if(checkReason != null)
            {
                string reasonId = checkReason["CHECK_REASON_ID"].ToString();
                this.OnRemoveCheckReason(null, new CheckReasonEventArgs()
                {
                    checkReasonId = reasonId
                });
                
                DataTable dt = this.cgCheckReason.DataSource as DataTable;
                dt.Rows.Remove(checkReason);
                //DataRow[] selectRows = dt.Select(" CHECK_REASON_ID = '" + reasonId + "'");
                //if(selectRows != null && selectRows.Length > 0)
                //{
                //    dt.Rows.Remove(selectRows[0]);
                //}
            }
        }

        string allNumber = "";
        private void cgCheckReason_KeyDown(object sender, KeyEventArgs e)
        {
            int keyInt = this.KeysToInt(e.KeyData);
            if(keyInt == -1)
            {
                allNumber = "";
            }
            else
            {
                allNumber += keyInt;
            }
            if(allNumber != "")
            {
                int allInt = int.Parse(allNumber);
                this.gvCheckReason.MoveFirst();
                this.gvCheckReason.MoveBy(allInt - 1);
            }

            switch(e.KeyData)
            {
                case Keys.Escape:
                    this.FindForm().Close();
                    break;
                case Keys.F5:
                    isOk = true;
                    this.FindForm().Close();
                    break;
                case Keys.F6:
                    this.OnAddCheckReason(null, new CheckReasonEventArgs()
                    {
                        checkReason = this.txtCheckReason.Text.Trim()
                    });
                    DataTable dt = this.cgCheckReason.DataSource as DataTable;
                    DataRow dr = dt.NewRow();
                    dr["CHECK_REASON"] = this.txtCheckReason.Text.Trim();
                    dt.Rows.Add(dr);
                    break;
                case Keys.F7:
                    DataRow checkReason = this.gvCheckReason.GetFocusedDataRow();
                    if(checkReason != null)
                    {
                        string reasonId = checkReason["CHECK_REASON_ID"].ToString();
                        this.OnRemoveCheckReason(null, new CheckReasonEventArgs()
                        {
                            checkReasonId = reasonId
                        });
                        DataTable data = this.cgCheckReason.DataSource as DataTable;
                        DataRow[] selectRows = data.Select(" CHECK_REASON_ID = '" + reasonId + "'");
                        if(selectRows != null && selectRows.Length > 0)
                        {
                            data.Rows.Remove(selectRows[0]);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch(keyData)
            {
                case Keys.Escape:
                    this.FindForm().Close();
                    break;
                case Keys.F5:
                    isOk = true;
                    this.FindForm().Close();
                    break;
                case Keys.F6:
                    this.OnAddCheckReason(null, new CheckReasonEventArgs()
                    {
                        checkReason = this.txtCheckReason.Text.Trim()
                    });
                    DataTable dt = this.cgCheckReason.DataSource as DataTable;
                    DataRow dr = dt.NewRow();
                    dr["CHECK_REASON"] = this.txtCheckReason.Text.Trim();
                    dt.Rows.Add(dr);
                    break;
                case Keys.F7:
                    DataRow checkReason = this.gvCheckReason.GetFocusedDataRow();
                    if(checkReason != null)
                    {
                        string reasonId = checkReason["CHECK_REASON_ID"].ToString();
                        this.OnRemoveCheckReason(null, new CheckReasonEventArgs()
                        {
                            checkReasonId = reasonId
                        });
                        DataTable data = this.cgCheckReason.DataSource as DataTable;
                        DataRow[] selectRows = data.Select(" CHECK_REASON_ID = '" + reasonId + "'");
                        if(selectRows != null && selectRows.Length > 0)
                        {
                            data.Rows.Remove(selectRows[0]);
                        }
                    }
                    break;
                default:
                    break;
            }
            return false;
        }

        /// <summary>
        /// 将建值转化成对应的数字
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns> -1 为不是数字控件</returns>
        private int KeysToInt(Keys keyData)
        {
            int value = -1;
            switch(keyData)
            {
                case Keys.D0:
                case Keys.NumPad0:
                    value = 0;
                    break;
                case Keys.D1:
                case Keys.NumPad1:
                    value = 1;
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    value = 2;
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    value = 3;
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    value = 4;
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    value = 5;
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    value = 6;
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    value = 7;
                    break;
                case Keys.D8:
                case Keys.NumPad8:
                    value = 8;
                    break;
                case Keys.D9:
                case Keys.NumPad9:
                    value = 9;
                    break;
            }
            return value;
        }

        private void gvCheckReason_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow checkReason = this.gvCheckReason.GetFocusedDataRow();
            this.txtCheckReason.Text = checkReason["CHECK_REASON"].ToString();
            this.reasonId = checkReason["CHECK_REASON_ID"].ToString();
        }

        private void txtCheckReason_KeyDown(object sender, KeyEventArgs e)
        {
            this.reasonId = "";
        }

        public event EventHandler<CheckReasonEventArgs> OnAddCheckReason;
        public event EventHandler<CheckReasonEventArgs> OnRemoveCheckReason;




    }

    public class CheckReasonEventArgs : EventArgs
    {
        public string checkReason;

        public string checkReasonId;
    }
}

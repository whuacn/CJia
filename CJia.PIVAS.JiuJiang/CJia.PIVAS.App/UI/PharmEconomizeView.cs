using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.PIVAS.Views;

namespace CJia.PIVAS.App.UI
{
    public partial class PharmEconomizeView : Tools.View, Views.IPharmEconomizeView
    {
        public PharmEconomizeView()
        {
            InitializeComponent();
            this.Init();
        }

        protected override object CreatePresenter()
        {
            return new Presenters.PharmEconomizePresenter(this);
        }

        private void Init()
        {
            DateTime now = CJia.PIVAS.Tools.Helper.Sysdate;
            this.dtpStartTime.Value = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            this.dtpEndTime.Value = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
            this.OnInitIffield(null, null);
            PharmEconomizeViewEventArgs pharmEconomizeViewEventArgs = new PharmEconomizeViewEventArgs();
            pharmEconomizeViewEventArgs.illfitld = "0";
            this.OnSelectFilterPharm(null, pharmEconomizeViewEventArgs);
            pharmFilterView.addPharmFilter += pharmFilterView_addPharmFilter;
            pharmFilterView.deletePharmFilter += pharmFilterView_deletePharmFilter;
        }



        #region 属性

        /// <summary>
        /// 药品过滤
        /// </summary>
        CJia.PIVAS.App.UI.PharmFilterView pharmFilterView = new PharmFilterView();

        /// <summary>
        /// 选择的药品
        /// </summary>
        List<string> selectPharmList
        {
            get
            {
                List<string> selectPharm = new List<string>();
                if(pharmFilterView.selectPharm != null && pharmFilterView.selectPharm.Rows != null && pharmFilterView.selectPharm.Rows.Count > 0)
                {
                    foreach(DataRow row in pharmFilterView.selectPharm.Rows)
                    {
                        selectPharm.Add(row["PHARM_ID"].ToString());
                    }
                }
                return selectPharm;
            }
        }

        /// <summary>
        /// 选择的药品
        /// </summary>
        DataTable selectPharm
        {
            get
            {
                return pharmFilterView.selectPharm;
            }
        }

        private DataTable FilterPharm;

        private DataTable pharmData;

        private decimal KCAllAcount;

        private decimal SJAllAcount;

        private decimal JYAllAcount;

        private decimal NOZJ;

        private decimal RKZLAllAcount;

        private decimal RKZJAllAcount;



        private DataTable AddPharmDetail;

        private DataTable AddPharmAll;

        CJia.PIVAS.App.UI.AddPharmView addPharmView = new AddPharmView();


        #endregion

        #region 界面事件


        void pharmFilterView_deletePharmFilter(object parameter1, object parameter2)
        {
            this.OnDeleteFilterPharm(null, new PharmEconomizeViewEventArgs()
            {
                illfitld = parameter1.ToString(),
                pharmId = parameter2.ToString()
            });
        }

        void pharmFilterView_addPharmFilter(object parameter1, object parameter2)
        {
            this.OnAddFilterPharm(null, new PharmEconomizeViewEventArgs()
            {
                illfitld = parameter1.ToString(),
                pharmId = parameter2.ToString()
            });
        }

        private void rbDetail_CheckedChanged(object sender, EventArgs e)
        {
            if(rbDetail.Checked)
            {
                this.gcAddPharm.DataSource = this.AddPharmDetail;
                this.gcAddPharm.MainView = this.gvEconomizeDetail;
            }
            else
            {
                this.gcAddPharm.DataSource = this.AddPharmAll;
                this.gcAddPharm.MainView = this.gvEconomize;
            }
        }

        private void cbIffield_SelectedValueChanged(object sender, EventArgs e)
        {
            PharmEconomizeViewEventArgs pharmEconomizeViewEventArgs = new PharmEconomizeViewEventArgs();
            pharmEconomizeViewEventArgs.illfitld = this.cbIffield.SelectedValue.ToString();
            this.OnSelectFilterPharm(null, pharmEconomizeViewEventArgs);
        }

        // 药品入库
        private void btnAddPharm_Click(object sender, EventArgs e)
        {
            this.OnSelectPharmEconomize(null, new Views.PharmEconomizeViewEventArgs()
            {
                startDate = this.dtpStartTime.Value,
                endDate = this.dtpEndTime.Value,
                pharmIds = this.selectPharmList,
                illfitld = this.cbIffield.SelectedValue.ToString()
            });
            if(this.cbIffield.SelectedValue.ToString() != "0")
            {
                this.OnSelectPharmEconomize(null, new Views.PharmEconomizeViewEventArgs()
                {
                    startDate = this.dtpStartTime.Value,
                    endDate = this.dtpEndTime.Value,
                    pharmIds = this.selectPharmList,
                    illfitld = this.cbIffield.SelectedValue.ToString()
                });

                this.addPharmView = new AddPharmView();
                this.addPharmView.BindPharmData(this.pharmData, this.FilterPharm);
                this.addPharmView.AddPharm += addPharmView_AddPharm;
                this.ShowAsWindow(this.cbIffield.Text + " 药品入库", addPharmView);
            }
            else
            {
                Message.Show("不能对全部病区进行一次操作！");
            }
        }

        // 药品入库事件调用方法
        object addPharmView_AddPharm()
        {
            return this.OnAddPharm(this.addPharmView.PharmData, this.cbIffield.SelectedValue.ToString());
        }

        // 药品过滤界面单击事件
        private void btnFilterPharm_Click(object sender, EventArgs e)
        {
            this.ShowAsWindow(this.cbIffield.Text + " 药品筛选", pharmFilterView);
        }

        // 获取药品节约数量
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.OnSelectPharmEconomize(null, new Views.PharmEconomizeViewEventArgs()
            {
                startDate = this.dtpStartTime.Value,
                endDate = this.dtpEndTime.Value,
                pharmIds = this.selectPharmList,
                illfitld = this.cbIffield.SelectedValue.ToString()
            });
        }

        // 过滤0切换
        private void cbFilterZero_CheckedChanged(object sender, EventArgs e)
        {
            this.FilterZero();
            this.SetAllAcount();
        }

        // 打印
        private void btnPrintStorage_Click(object sender, EventArgs e)
        {
            CJia.PIVAS.App.UI.PharmEconomizeReport pharmEconomizeReport = new PharmEconomizeReport();
            pharmEconomizeReport.DataBindDataTable(this.AddPharmAll, this.cbIffield.Text, this.dtpStartTime.Value.ToShortDateString(), this.dtpEndTime.Value.ToShortDateString(), this.RKZLAllAcount.ToString(), this.RKZJAllAcount.ToString());
        }

        #endregion

        #region IPharmEconomizeView 成员

        public event EventHandler<Views.PharmEconomizeViewEventArgs> OnSelectFilterPharm;

        public event EventHandler<Views.PharmEconomizeViewEventArgs> OnSelectPharmEconomize;

        public event EventHandler<PharmEconomizeViewEventArgs> OnAddFilterPharm;

        public event EventHandler<PharmEconomizeViewEventArgs> OnDeleteFilterPharm;

        public event EventHandler<Views.SendPharmSelectEventArgs> OnInitIffield;

        public event Tools.Delegate.ResTwoPar OnAddPharm;



        public void ExeSelectAddPharm(DataTable detail, DataTable all)
        {
            this.AddPharmDetail = detail;
            this.AddPharmAll = all;
            if(rbDetail.Checked)
            {
                this.gcAddPharm.DataSource = this.AddPharmDetail;
                this.gcAddPharm.MainView = this.gvEconomizeDetail;
            }
            else
            {
                this.gcAddPharm.DataSource = this.AddPharmAll;
                this.gcAddPharm.MainView = this.gvEconomize;
            }
            this.SetAddPharmAcount();
        }

        /// <summary>
        /// 获取药品过滤信息
        /// </summary>
        /// <param name="result"></param>
        public void ExeSelectFilterPharm(DataTable result)
        {
            this.FilterPharm = result;
            pharmFilterView.BindData(result, this.cbIffield.SelectedValue.ToString());
        }

        /// <summary>
        /// 获取节约药品信息
        /// </summary>
        /// <param name="result"></param>
        public void ExeSelectPharmEconomize(DataTable result)
        {
            this.pharmData = result;
            this.FilterZero();
            this.SetAllAcount();

        }

        //初始化病区回调函数
        public void ExeInitIffield(DataTable result)
        {
            DataRow dr = result.NewRow();
            dr["OFFICE_NAME"] = "< 全部 >";
            dr["OFFICE_ID"] = 0;
            result.Rows.InsertAt(dr, 0);
            this.cbIffield.DataSource = result;
            this.cbIffield.DisplayMember = "OFFICE_NAME";
            this.cbIffield.ValueMember = "OFFICE_ID";
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// 过滤0节约药物
        /// </summary>
        private void FilterZero()
        {
            if(this.pharmData != null && this.pharmData.Rows != null && this.pharmData.Rows.Count > 0)
            {
                this.gcPharm.DataSource = this.GetDataSource(this.pharmData.Select(" ALL_ECONOMIZE_PHARM_AMOUNT <> 0 "));
            }
            else
            {
                this.gcPharm.DataSource = this.pharmData;
            }
        }

        /// <summary>
        /// 设置数量
        /// </summary>
        private void SetAllAcount()
        {
            DataTable Data = this.gcPharm.DataSource as DataTable;
            decimal KC = 0;
            decimal SJ = 0;
            decimal JY = 0;
            decimal ZJ = 0;
            if(Data != null && Data.Rows != null && Data.Rows.Count > 0)
            {
                foreach(DataRow row in Data.Rows)
                {
                    KC += (decimal)(row["all_fee_pharm_amount"]);
                    SJ += (decimal)(row["all_reality_pharm_amount"]);
                    JY += (decimal)(row["all_economize_pharm_amount"]);
                    ZJ += (decimal)(row["all_money"]);
                }
            }
            this.KCAllAcount = KC;
            this.SJAllAcount = SJ;
            this.JYAllAcount = JY;
            this.NOZJ = ZJ;
            this.labelControl7.Text = KC.ToString();
            this.labelControl8.Text = SJ.ToString();
            this.labelControl9.Text = JY.ToString();
            this.txtNoAllMoney.Text = ZJ.ToString();

        }



        /// <summary>
        /// 设置数量
        /// </summary>
        private void SetAddPharmAcount()
        {
            DataTable Data = this.gcAddPharm.DataSource as DataTable;
            decimal RKZL = 0;
            decimal RKZJ = 0;
            if(Data != null && Data.Rows != null && Data.Rows.Count > 0)
            {
                foreach(DataRow row in Data.Rows)
                {
                    RKZL += (decimal)(row["economize_count"]);
                    RKZJ += (decimal)(row["all_money"]);
                }
            }
            this.RKZLAllAcount = RKZL;
            this.RKZJAllAcount = RKZJ;


            this.txtAllAddPharmCount.Text = RKZL.ToString();
            this.txtAllMoney.Text = RKZJ.ToString();

        }

        /// <summary>
        //　将ROW数组转成datatable
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        private DataTable GetDataSource(DataRow[] rows)
        {
            DataTable result = new DataTable();
            if(rows != null && rows.Length != 0)
            {
                result = rows[0].Table.Clone();
                for(int i = 0; i < rows.Length; i++)
                {
                    DataRow row = result.NewRow();
                    row.ItemArray = rows[i].ItemArray;
                    result.Rows.Add(row);
                }
                return result;
            }
            return result;
        }

        #endregion

    }
}

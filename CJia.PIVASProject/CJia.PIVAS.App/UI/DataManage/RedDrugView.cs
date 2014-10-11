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
    /// 时间维护的UI层
    /// </summary>
    public partial class RedDrugView : CJia.PIVAS.Tools.View,CJia.PIVAS.Views.DataManage.IRedDrugView
    {
        public RedDrugView()
        {
            InitializeComponent();
        }

        //定义全局的参数类实例
        CJia.PIVAS.Views.DataManage.RedDrugEventArgs redArgs = new Views.DataManage.RedDrugEventArgs();

        /// <summary>
        /// 带全局变量（判断进那个页面）的构造方法
        /// </summary>
        /// <param name="whichPage"></param>
        public RedDrugView(int whichPage)
        {
            InitializeComponent();
            WhichPage = whichPage;
        }

        protected override object CreatePresenter()
        {
            return new Presenters.DataManage.RedDrugViewPresenter(this);
        }
        

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gc_RedDrug_Load(object sender, EventArgs e)
        {
            //this.LoadData(whichPage);
            redArgs.Whichpage=WhichPage;
            this.OnLoadData(null, redArgs);
        }
                
        /// <summary>
        /// 添加TimeSet  冲药或者拉单  根据构造函数参数确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //参数WhichPage表示进哪个页面  1表示拉单 2表示冲药
            EditTimeSetView editTimeSet = new EditTimeSetView(WhichPage);
            this.ShowAsWindow("添加", editTimeSet);
            redArgs.Whichpage = WhichPage;
            this.OnLoadData(null, redArgs);
        }

        /// <summary>
        /// 删除选中数据 冲药或者拉单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                if (CJia.PIVAS.Tools.Message.ShowQuery("是否确认删除", CJia.PIVAS.Tools.Message.Button.YesNo) == CJia.PIVAS.Tools.Message.Result.Yes)
                {
                    DataRow dr = gridView1.GetFocusedDataRow();
                    redArgs.TimeId = long.Parse(dr["time_id"].ToString());
                    redArgs.UserId = User.UserId;
                    this.OnDeleteTimeSet(null, redArgs);
                    redArgs.Whichpage = WhichPage;
                    this.OnLoadData(null, redArgs);
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

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                DataRow dr = gridView1.GetFocusedDataRow();
                EditTimeSetView editTimeSet = new EditTimeSetView(WhichPage, 1, dr);
                this.ShowAsWindow("修改", editTimeSet);
                redArgs.Whichpage = WhichPage;
                this.OnLoadData(null, redArgs);
            }
            else
            {
                CJia.PIVAS.Tools.Message.Show("请选则数据");
            }
        }


        #region【实现接口】

        /// <summary>
        /// 定义全局变量来判断是点的哪个页面 1代表拉单2代表冲药 
        /// </summary>
        private int whichPage;
        public int WhichPage
        {
            get
            {
                return whichPage;
            }
            set
            {
                whichPage = value;
            }
        }

        //初始化载入数据
        public event EventHandler<Views.DataManage.RedDrugEventArgs> OnLoadData;
        
        //删除数据
        public event EventHandler<Views.DataManage.RedDrugEventArgs> OnDeleteTimeSet;

        /// <summary>
        /// 初始化gridcontrol
        /// </summary>
        /// <param name="dt"></param>
        public void ExeInitData(DataTable dt)
        {
            Gc_RedDrug.DataSource = dt;
        }

        #endregion

        #region 【快捷键】
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    BtnRefresh.Focus();
                    redArgs.Whichpage = WhichPage;
                    this.OnLoadData(null, redArgs);
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}

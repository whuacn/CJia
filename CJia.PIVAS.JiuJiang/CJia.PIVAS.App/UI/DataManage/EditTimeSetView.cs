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
    /// 修改时间数据的Ui层
    /// </summary>
    public partial class EditTimeSetView : CJia.PIVAS.Tools.View, CJia.PIVAS.Views.DataManage.IEditTimeSetView
    {
        private long TimeId;    //定义一个TImeID来记录选中的这行数据的TimeID

        /// <summary>
        /// 定义全局变量来判断是点的哪个页面 1代表拉单2代表冲药
        /// </summary>
        private int whichPage;
        public int WhichPage
        {
            set { whichPage = value; }
            get { return whichPage; }
        }

        /// <summary>
        /// 1代表是修改数据
        /// </summary>
        private int type;
        public int Type
        {
            set { type = value; }
            get { return type; }
        }

        /// <summary>
        /// 要插入的数据是否有交叉
        /// </summary>
        bool IsRepeat = false;
        
        /// <summary>
        /// 带0个参数的构造方法
        /// </summary>
        public EditTimeSetView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 带参数的构造方法 1表示拉单的添加页面，2表示冲药的添加页面，0代表拉单和冲药的修改页面
        /// </summary>
        /// <param name="whichPage"></param>
        public EditTimeSetView(int whichPage)
        {
            InitializeComponent();
            WhichPage = whichPage;
            if (whichPage == 1)
            {
                labelControl1.Text = "拉单名称:";
            }
            else
            {
                labelControl1.Text = "冲药名称:";
            }
        }

        /// <summary>
        /// 带datarow的构造函数 type=1代表修改页面 whichpage代表是拉单页面还是冲药页面 1表示拉单的添加页面，2表示冲药的添加页面
        /// </summary>
        /// <param name="dr"></param>
        public EditTimeSetView(int whichpages,int type,DataRow dr)
        {
            if (type == 1)
            {
                Type = type;
                WhichPage = whichpages;
                InitializeComponent();
                TimeId = long.Parse(dr["time_id"].ToString());  //获取当前记录的TimeId
                TeName.Text = dr["TIME_NAME"].ToString();
                TeStartTime.Time = DateTime.Parse(dr["start_time"].ToString());
                if (dr["over_time"] == DBNull.Value)
                {
                    TeOverTime.Text = "";
                }
                else
                {
                    TeOverTime.Time = DateTime.Parse(dr["over_time"].ToString());
                }
                if (whichPage == 1)
                {
                    labelControl1.Text = "拉单名称:";
                }
                else
                {
                    labelControl1.Text = "冲药名称:";
                }
            }
        }

        protected override object CreatePresenter()
        {
            return new Presenters.DataManage.EditTimeSetPresenter(this);
        }

        
        //拉单或冲药的确定修改和添加
        private void BtnSure_Click(object sender, EventArgs e)
        {
            this.EditTime();
        }

        /// <summary>
        /// 修改时间表
        /// </summary>
        private void EditTime()
        {
            if (TeName.Text == "")
            {
                CJia.PIVAS.Tools.Message.Show("请填写名称");
                TeName.Focus();
                return;
            }

            //if (DateTime.Parse(TeStartTime.Text) >= (DateTime.Parse(TeOverTime.Text) == DateTime.Parse("00:00") ? DateTime.Parse("00:00").AddDays(1) : DateTime.Parse(TeOverTime.Text)))
            //{
            if (DateTime.Parse(TeStartTime.Text) >= DateTime.Parse(TeOverTime.Text))
            {
                CJia.PIVAS.Tools.Message.ShowWarning("开始时间不能等于或晚于截止时间");
                return;
            }
            else
            {
                CJia.PIVAS.Views.DataManage.EditTimeSetEventArgs editTimeSetArgs = new Views.DataManage.EditTimeSetEventArgs();
                editTimeSetArgs.TimeId = TimeId;
                editTimeSetArgs.StartTime = TeStartTime.Text;
                //if (TeOverTime.Text == "00:00")
                //{
                //    //editTimeSetArgs.OverTime = null;
                //    //editTimeSetArgs.EndTime = DateTime.Parse("00:00").AddDays(1).ToString();
                //}
                //else
                //{
                //    editTimeSetArgs.OverTime = TeOverTime.Text;
                //    editTimeSetArgs.EndTime = TeOverTime.Text;
                //}
                editTimeSetArgs.OverTime = TeOverTime.Text;
                editTimeSetArgs.EndTime = TeOverTime.Text;
                editTimeSetArgs.Whichpage = WhichPage;
                editTimeSetArgs.TimeName = TeName.Text;
                editTimeSetArgs.UserId = User.UserId;


                if (Type == 1)    //修改
                {
                    editTimeSetArgs.WhichHandle = 2;
                    this.OnIsUpdateRepeat(null, editTimeSetArgs);
                    if (!IsRepeat)
                    {
                        if (CJia.PIVAS.Tools.Message.ShowQuery("是否确认修改", CJia.PIVAS.Tools.Message.Button.YesNo) == CJia.PIVAS.Tools.Message.Result.Yes)
                        {
                            this.OnUpdateTimeSet(null, editTimeSetArgs);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        CJia.PIVAS.Tools.Message.Show("修改的时间与前后有交叉");
                        TeStartTime.Focus();
                        TeStartTime.SelectAll();
                        return;
                    }
                }
                else
                {
                    this.OnIsInsertRepeat(null, editTimeSetArgs);
                    if (!IsRepeat)
                    {
                        if (CJia.PIVAS.Tools.Message.ShowQuery("是否确认添加", CJia.PIVAS.Tools.Message.Button.YesNo) == CJia.PIVAS.Tools.Message.Result.Yes)
                        {
                            this.OnInserttimeSet(null, editTimeSetArgs);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        CJia.PIVAS.Tools.Message.Show("修改的时间与前后有交叉");
                        TeStartTime.Focus();
                        TeStartTime.SelectAll();
                        return;
                    }
                }
            }
        }

        //取消操作
        private void BtnCancle_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }


        #region【实现接口】

        //修改
        public event EventHandler<Views.DataManage.EditTimeSetEventArgs> OnUpdateTimeSet;

        //添加
        public event EventHandler<Views.DataManage.EditTimeSetEventArgs> OnInserttimeSet;

        /// <summary>
        /// 判断修改时间是否有重叠
        /// </summary>
        public event EventHandler<Views.DataManage.EditTimeSetEventArgs> OnIsUpdateRepeat;

        /// <summary>
        /// 判断添加时间是否有重叠
        /// </summary>
        public event EventHandler<Views.DataManage.EditTimeSetEventArgs> OnIsInsertRepeat;

        /// <summary>
        /// 传回值告知是否有重复
        /// </summary>
        /// <param name="isRepeat"></param>
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
                    this.EditTime();
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

















        
    }
}

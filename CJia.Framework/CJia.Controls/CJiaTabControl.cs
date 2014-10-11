using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnimatorNS;
using System.ComponentModel;
using System.Drawing;

namespace CJia.Controls
{
    /// <summary>
    /// 选项卡
    /// </summary>
    public class CJiaTabControl:DevExpress.XtraTab.XtraTabControl
    {
        /// <summary>
        /// 动画类
        /// </summary>
        public Animator animator;
        /// <summary>
        /// CJiaTabControl构造函数
        /// </summary>
        public CJiaTabControl()
        {
            //animator
            animator = new Animator();
            animator.AnimationType = AnimationType.VertSlide;
            animator.DefaultAnimation.TimeCoeff = 1f;
            animator.DefaultAnimation.AnimateOnlyDifferences = false;

            Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(213)))), ((int)(((byte)(238)))));
            Appearance.Options.UseBackColor = true;
            AppearancePage.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
            AppearancePage.Header.BorderColor = System.Drawing.Color.Transparent;
            AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 10F);
            AppearancePage.Header.Options.UseBackColor = true;
            AppearancePage.Header.Options.UseBorderColor = true;
            AppearancePage.Header.Options.UseFont = true;
            AppearancePage.HeaderActive.BackColor = System.Drawing.Color.White;
            AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.DimGray;
            AppearancePage.HeaderActive.Options.UseBackColor = true;
            AppearancePage.HeaderActive.Options.UseForeColor = true;
            AppearancePage.PageClient.BackColor = System.Drawing.Color.White;
            BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
            HeaderButtons = ((DevExpress.XtraTab.TabButtons)((((DevExpress.XtraTab.TabButtons.Prev | DevExpress.XtraTab.TabButtons.Next)
            | DevExpress.XtraTab.TabButtons.Close)
            | DevExpress.XtraTab.TabButtons.Default)));
            LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            LookAndFeel.UseDefaultLookAndFeel = false;
            Size = new System.Drawing.Size(450, 250);
            CloseButtonClick += CJiaTabControl_CloseButtonClick;
        }

        void CJiaTabControl_CloseButtonClick(object sender, EventArgs e)
        {
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs EArg = (DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs)e;
            string tbpName = EArg.Page.Text;
            string tbpSelectName = this.SelectedTabPage.Text;
            foreach (DevExpress.XtraTab.XtraTabPage xtp in this.TabPages)
            {
                if (xtp.Text == tbpName)
                {
                    if (tbpName == tbpSelectName)
                    {
                        int index = this.SelectedTabPageIndex;
                        this.SelectedTabPageIndex = index - 1;
                    }
                    this.TabPages.Remove(xtp);
                    xtp.Dispose();
                    return;
                }
            }
        }

        //#region 动画效果
        ///// <summary>
        ///// 动画效果属性
        ///// </summary>
        //[TypeConverter(typeof(ExpandableObjectConverter))]
        //public Animation Animation
        //{
        //    get { return animator.DefaultAnimation; }
        //    set { animator.DefaultAnimation = value; }
        //}
        ///// <summary>
        ///// 重写选项卡的Selecting事件
        ///// </summary>
        ///// <param name="e"></param>
        //protected override void OnSelecting(DevExpress.XtraTab.TabPageCancelEventArgs e)
        //{
        //    base.OnSelecting(e);
        //    //animator.BeginUpdateSync(this, false, null, new Rectangle(0, ItemSize.Height + 3, Width, Height - ItemSize.Height - 3));
        //    animator.BeginUpdateSync(this, false, null, new Rectangle(0, 33, Width, Height - 27));
        //    if (this.IsHandleCreated)
        //        BeginInvoke(new MethodInvoker(() => animator.EndUpdate(this)));
        //}
        //#endregion

        #region  Tab控件操作
        /// <summary>
        /// 将用户控件添加到tab中
        /// </summary>
        /// <param name="pageTitle">tabpage名</param>
        /// <param name="userControl">用户控件</param>
        public void ShowPage(string pageTitle, UserControl userControl)
        {
            DevExpress.XtraTab.XtraTabPage page1 = new DevExpress.XtraTab.XtraTabPage();
            page1.Controls.Add(userControl);
            page1.Text = pageTitle;
            page1.Name = pageTitle;
            page1.AutoScroll = true;
            this.TabPages.Add(page1);
            userControl.Dock = DockStyle.Fill;
            this.SelectedTabPage = page1;
        }
        /// <summary>
        /// 判断将要添加的page是否存在
        /// </summary>
        /// <param name="PageTitle">tabpage名</param>
        /// <returns>bool</returns>
        public bool isExistPage(string PageTitle)
        {
            for (int i = 0; i < this.TabPages.Count; i++)
            {
                if (this.TabPages[i].Name == PageTitle)
                {
                    this.SelectedTabPage = this.TabPages[i];
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}

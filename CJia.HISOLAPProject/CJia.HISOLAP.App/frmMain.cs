using CJia.HISOLAP.App.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.HISOLAP.App
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            lblLoginTime.Text = DateTime.Now.ToString();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void bBtn_hlyy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void xTC_Click(object sender, EventArgs e)
        {

        }




        #region  Tab控件操作
        /// <summary>
        ///根据标题在tabpage中显示出页面
        ///增加新按钮需 1.在该方法的switch中加一个case，case后面的字符为按钮的text属性值
        ///case中new出你要显示的用户控件
        ///2.并且按钮的单击事件绑定到 menubutton_click 方法上
        /// </summary>
        /// <param name="pageTitle">button的text属性字段</param>
        private void MenuShowPage(string pageTitle, string name, Image pageImage)
        {
            if (!isExistPage(name))
            {
                UserControl uc = new UserControl();
                switch (name)
                {
                    case "bBtn_yxgl"://运行管理
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.DeptData;
                        uc = new NewRunningManager();
                        break;
                    case "bBtn_mz"://手术麻醉
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.DeptData;
                        uc = new NewSurgicalView();
                        break;
                    case "bBtn_zdss"://重点手术
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.DeptData;
                        uc = new NewKeyOperationView();
                        break;
                    case "bBtn_YCQK"://压疮情况
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.DeptData;
                        uc = new NewYCQK1();
                        break;
                    case "bBtn_dbz"://单病种
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.DeptData;
                        uc = new NewSingleDiseaseView();
                        break;
                    case "bBtn_zzyx"://重症医学
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.DeptData;
                        uc = new NewZZJHQK();
                        break;
                    case "bBtn_wssqyf"://围手术期预防
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.DeptData;
                        uc = new NewOperationBP();
                        break;
                    case "bBtn_wssqbp"://围手术期备皮
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.DeptData;
                        uc = new NewOperationYF();
                        break;
                    case "bBtn_zdjb"://重点疾病
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.DeptData;
                        uc = new NewZYZDJBQK();
                        break;
                    case "bBtn_yygr"://医院感染
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.DeptData;
                        uc = new NewInfactView();
                        break;
                    case "bBtn_bfz"://手术并发
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.DeptData;
                        uc = new NewSurguryComplication();
                        break;
                    case "bBtn_hlyy"://合理用药
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.DeptData;
                        uc = new NewHLYYQK();
                        break;
                    case "barButtonItem20"://手术并发（二）
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.DeptData;
                        uc = new NewSSBFZQK();
                        break;
                    case "btn_script"://审核脚本定义
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.DeptData;
                        uc = new UI.HQMS.CheckScript();
                        break;
                    case "btnReport"://数据上报
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.DeptData;
                        uc = new UI.HQMS.CheckReportView();
                        break;
                    case "bBi_kjywsyl":
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.DeptData_KJ;
                        uc= new UI.Antibacterials.KJYWSYL();
                        break;
                    case "bBi_bqkjywsyl":
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.ILLFIELDData_KJ;
                        uc = new UI.Antibacterials.BQKJYWSYL();
                        break;
                    case "bBtni_bqkjywsyqd":
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.ILLFIELDData_KJ;
                        uc = new UI.Antibacterials.BQKJYWSYQD();
                        break;
                    case "bBtni_kjywsyje":
                        BZUserControl.data = CJia.HISOLAP.App.Tools.Help.DeptData_KJ;
                        uc = new UI.Antibacterials.KJYWSYJE();
                        break;
                    default:
                        break;
                }
                if (uc != null)
                {
                    ShowPage(pageTitle, pageImage, uc);
                }
            }
        }
        //所有在tabpage中显示页面的按钮单击事件
        private void MenuButton_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string pageTitle = (e.Item as DevExpress.XtraBars.BarItem).Caption;//获得tabpage名称
            string name = (e.Item as DevExpress.XtraBars.BarItem).Name;//获得tabpage名称
            //Image pageImage = changeImageSize((e.Item as DevExpress.XtraBars.BarButtonItem).LargeGlyph, 16, 16);
            Image pageImage = (e.Item as DevExpress.XtraBars.BarButtonItem).LargeGlyph;
            Bitmap bit = null;
            if (pageImage != null)
                bit = new Bitmap(pageImage, 16, 16);
            this.MenuShowPage(pageTitle, name, bit);
        }
        /// <summary>
        /// 将用户控件添加到tab中
        /// </summary>
        /// <param name="name">tabpage名</param>
        /// <param name="userControl">用户控件</param>
        public void ShowPage(string pageTitle, Image pageImage, UserControl userControl)
        {
            DevExpress.XtraTab.XtraTabPage page1 = new DevExpress.XtraTab.XtraTabPage();
            page1.Controls.Add(userControl);
            page1.Text = pageTitle;
            page1.Name = pageTitle;
            page1.Image = pageImage;
            page1.AutoScroll = true;
            xTC.TabPages.Add(page1);
            userControl.Dock = DockStyle.Fill;
            xTC.SelectedTabPage = page1;
        }
        /// <summary>
        /// 判断将要添加的page是否存在
        /// </summary>
        /// <param name="PageTitle">tabpage名</param>
        /// <returns>bool</returns>
        public bool isExistPage(string PageTitle)
        {
            for (int i = 0; i < xTC.TabPages.Count; i++)
            {
                if (xTC.TabPages[i].Name == PageTitle)
                {
                    xTC.SelectedTabPage = xTC.TabPages[i];
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 双击删除选中tabpage  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabMain_DoubleClick(object sender, EventArgs e)
        {
            if (xTC.SelectedTabPage != null)
            {
                int index = xTC.SelectedTabPageIndex;
                this.xTC.SelectedTabPage.Dispose();
                xTC.SelectedTabPageIndex = index - 1;
            }
        }
        private void xTC_CloseButtonClick(object sender, EventArgs e)
        {
            if (xTC.SelectedTabPage != null)
            {
                int index = xTC.SelectedTabPageIndex;
                this.xTC.SelectedTabPage.Dispose();
                xTC.SelectedTabPageIndex = index - 1;
            }
        }

        #endregion


        private Dictionary<Image, Image> oldNewImages = new Dictionary<Image, Image>();
        /// <summary>
        /// 改变图片大小
        /// </summary>
        /// <param name="oldImage"></param>
        /// <param name="ImgWidth"></param>
        /// <param name="ImgHeight"></param>
        /// <returns></returns>
        private Image changeImageSize(Image oldImage, int ImgWidth, int ImgHeight)
        {
            try
            {
                return oldNewImages[oldImage];
            }
            catch (KeyNotFoundException knfe)
            {
                Bitmap bitmap = new Bitmap(ImgWidth, ImgHeight);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.Clear(Color.White);
                graphics.InterpolationMode = InterpolationMode.High;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.DrawImage(oldImage, new Rectangle(0, 0, ImgWidth, ImgHeight));
                graphics.Dispose();
                oldNewImages.Add(oldImage, bitmap);
                return bitmap;
            }
            catch (Exception exc)
            {
                //throw exc;
                return null;
            }
        }

        private void bLst_Style_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {
            defaultLookAndFeel1.LookAndFeel.SkinName = bLst_Style.Strings[e.Index];
            Application.DoEvents();
        }

    }
}

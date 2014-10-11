using GdiPlusLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using TwainLib;

namespace CJia.Health.App.UI
{
    public partial class ScanForm : Form, IMessageFilter
    {
        /// <summary>
        /// 判断扫描是否完成
        /// </summary>
        public static bool isSuccessEnd;
        bool msgfilter;
        int Page = 0;
        string MyProductName = "扫描程序";
        public ScanForm()
        {
            InitializeComponent();
            Tw = new Twain(MyProductName);
            Tw.Init(this.Handle);
        }
        public ScanForm(string path, string recordNO, string inhosTimes)
        {
            InitializeComponent();
            Tw = new Twain(MyProductName);
            Tw.Init(this.Handle);
            txtFolder.Text = path;
            txtID.Text = recordNO;
            txtTimes.Text = inhosTimes;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtFolder.Text.Length > 0)
            {
                if (!msgfilter)
                {
                    this.Enabled = false;
                    msgfilter = true;
                    Application.AddMessageFilter(this);
                }
                Tw.Acquire();
            }
        }

        #region IMessageFilter 成员 及 扫描仪 图片保存
        BITMAPINFOHEADER bmi;
        Rectangle bmprect;
        IntPtr dibhand;
        IntPtr bmpptr;
        IntPtr pixptr;
        bool IMessageFilter.PreFilterMessage(ref System.Windows.Forms.Message m)
        {
            TwainCommand Tc = Tw.PassMessage(ref m);
            if (Tc == TwainCommand.Not)
                return false;
            if (Tc == TwainCommand.Null)//by dh
            {
                return false;
            }
            switch (Tc)
            {
                case TwainCommand.CloseRequest:
                    timer1.Stop();
                    break;
                case TwainCommand.CloseOk:
                    EndScanning();
                    Tw.CloseSrc();
                    break;
                case TwainCommand.DeviceEvent:
                    timer1.Stop();
                    break;
                case TwainCommand.TransferReady:
                    timer1.Enabled = true;
                    timer1.Interval = 10;
                    timer1.Start();
                    ArrayList LstPic = Tw.TransferPictures();//点击扫描按钮
                    EndScanning();
                    Tw.CloseSrc();
                    string inhosTimes = txtTimes.Text;
                    if (inhosTimes.ToString().Length == 1)
                    {
                        inhosTimes = "0" + inhosTimes;
                    }
                    for (int i = 0; i < LstPic.Count; ++i)
                    {
                        IntPtr Img = (IntPtr)LstPic[i];
                        Page++;
                        string page = SetPage(Page);
                        string fileName = txtID.Text + "_" + inhosTimes + "_" + page + "_00";
                        bmpptr = GlobalLock(Img);
                        pixptr = GetPixelInfo(bmpptr);
                        Gdip.SaveDIBAs(txtFolder.Text, fileName, bmpptr, pixptr);//保存图片
                    }
                    isSuccessEnd = true;//已完成
                    OnRefresh(null, null);//刷新图片采集主窗体
                    timer1.Stop();
                    this.Close();
                    break;
            }
            return true;
        }

        private string SetPage(int oldpage)
        {
            string str;
            if (oldpage.ToString().Length == 1)
            {
                str = "00" + oldpage.ToString();
            }
            else if (oldpage.ToString().Length == 2)
            {
                str = "0" + oldpage.ToString();
            }
            else
            {
                str = oldpage.ToString();
            }
            return str;
        }

        private void EndScanning()
        {
            if (msgfilter)
            {
                Application.RemoveMessageFilter(this);
                msgfilter = false;
                this.Enabled = true;
                //this.Activate();
            }
        }

        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern int SetDIBitsToDevice(IntPtr hdc, int xdst, int ydst,
                                                int width, int height, int xsrc, int ysrc, int start, int lines,
                                                IntPtr bitsptr, IntPtr bmiptr, int color);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GlobalLock(IntPtr handle);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GlobalFree(IntPtr handle);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string outstr);

        protected IntPtr GetPixelInfo(IntPtr bmpptr)
        {
            bmi = new BITMAPINFOHEADER();
            Marshal.PtrToStructure(bmpptr, bmi);

            bmprect.X = bmprect.Y = 0;
            bmprect.Width = bmi.biWidth;
            bmprect.Height = bmi.biHeight;

            if (bmi.biSizeImage == 0)
                bmi.biSizeImage = ((((bmi.biWidth * bmi.biBitCount) + 31) & ~31) >> 3) * bmi.biHeight;

            int p = bmi.biClrUsed;
            if ((p == 0) && (bmi.biBitCount <= 8))
                p = 1 << bmi.biBitCount;
            p = (p * 4) + bmi.biSize + (int)bmpptr;
            return (IntPtr)p;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        internal class BITMAPINFOHEADER
        {
            public int biSize;
            public int biWidth;
            public int biHeight;
            public short biPlanes;
            public short biBitCount;
            public int biCompression;
            public int biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public int biClrUsed;
            public int biClrImportant;
        }
        #endregion

        private void txtStartPage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Page = int.Parse(txtStartPage.Text.ToString()) - 1;
            }
            catch
            {
                Page = 0;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            OnRefresh(null, null);
        }

        public event EventHandler OnRefresh;
        public event EventHandler OnGetFocus;

        private void ScanForm_Activated(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            OnGetFocus(null, null);
        }

        private void ScanForm_Leave(object sender, EventArgs e)
        {
            
        }
    }
}

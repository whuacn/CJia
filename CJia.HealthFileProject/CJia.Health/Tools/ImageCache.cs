using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace CJia.Health.Tools
{
    /// <summary>
    /// 病案缓存类
    /// </summary>
    public class ImageCache : IDisposable
    {
        ThreadStart ts;
        Thread thread;
        public ImageCache()
        {
            Connect();
        }
        public ImageCache(List<string> picPaths)
        {
            Connect();
            this.picPaths = picPaths;
            ThreadStart ts = new ThreadStart(DownLoadStream);
            Thread thread = new Thread(ts);
            thread.Start();
        }
        /// <summary>
        /// 病案缓存字典
        /// </summary>
        private Dictionary<string, Image> DicImage = null;

        /// <summary>
        /// 病案地址列表
        /// </summary>
        private List<string> picPaths = null;

        /// <summary>
        /// 开始下载病案
        /// </summary>
        /// <param name="picPaths">病案路径列表</param>
        public void DowImage(List<string> picPaths)
        {
            this.picPaths = picPaths;
            ts = new ThreadStart(Download);
            thread = new Thread(ts);
            thread.Start();
        }
        /// <summary>
        /// 开始下载病案FileStream
        /// </summary>
        /// <param name="picPaths">病案路径列表</param>
        public void DowImageStream()
        {
            //this.picPaths = picPaths;
            //ThreadStart ts = new ThreadStart(DownLoadStream);
            //Thread thread = new Thread(ts);
            // thread.Start();
        }
        /// <summary>
        /// 下载病案
        /// </summary>
        private void Download()
        {
            if (this.DicImage != null)
            {
                this.DicImage.Clear();
            }
            this.DicImage = new Dictionary<string, Image>();
            if (this.picPaths != null)
            {
                for (int i = 0; i < this.picPaths.Count; i++)
                {
                    this.DicImage.Add(this.picPaths[i], Image.FromFile(this.picPaths[i]));
                }
            }
        }
        /// <summary>
        /// 使用FileStream方式下载病案
        /// </summary>
        private void DownLoadStream()
        {
            if (this.DicImage != null)
            {
                this.DicImage.Clear();
            }
            this.DicImage = new Dictionary<string, Image>();
            if (this.picPaths != null)
            {
                for (int i = 0; i < this.picPaths.Count; i++)
                {
                    using (FileStream fs = new FileStream(this.picPaths[i], FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        Bitmap bt = new Bitmap(fs);
                        this.DicImage.Add(this.picPaths[i], bt);
                        fs.Flush(true);
                        fs.Close();//释放资源
                        fs.Dispose();
                    }
                }
            }
            GC.Collect();
        }

        /// <summary>
        /// 获取病案
        /// </summary>
        /// <param name="picPath">病案路径</param>
        /// <returns></returns>
        public Image GetImage(string picPath)
        {
            if (this.DicImage != null)
            {
                bool isHave = false;
                foreach (string key in this.DicImage.Keys)
                {
                    if (key == picPath)
                    {
                        isHave = true;
                        break;
                    }
                }
                if (isHave)
                {
                    return this.DicImage[picPath];
                }
            }
            return Image.FromFile(picPath);
        }
        /// <summary>
        /// 获取病案FileStream
        /// </summary>
        /// <param name="picPath">病案路径</param>
        /// <returns></returns>
        public Image GetImageStream(string picPath)
        {
            if (this.DicImage != null)
            {
                bool isHave = false;
                foreach (string key in this.DicImage.Keys)
                {
                    if (key == picPath)
                    {
                        isHave = true;
                        break;
                    }
                }
                if (isHave)
                {
                    return this.DicImage[picPath];
                }
            }
            FileStream fs = new FileStream(picPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            Bitmap bt = new Bitmap(fs);
            fs.Close();//释放资源
            fs.Dispose();
            return bt;
        }
        /// <summary>
        /// 连接到病案服务器
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            string IP = CJia.Health.Tools.ConfigHelper.GetAppStrings("PIC_SAVE_IP");
            string userName = CJia.Health.Tools.ConfigHelper.GetAppStrings("PIC_SAVE_USER_NAME");
            string password = CJia.Health.Tools.ConfigHelper.GetAppStrings("PIC_SAVE_PWD");
            bool bol = CJia.Health.Tools.Help.Connect(IP, userName, password);
            return bol;
        }

        public void Dispose()
        {
            if (ts != null && thread != null && thread.ThreadState == ThreadState.Running)
            {
                thread.Abort();
            }
            GC.Collect();
        }
    }
}

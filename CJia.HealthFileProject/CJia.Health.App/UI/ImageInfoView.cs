using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CJia.Health.Tools;
using System.Threading;

namespace CJia.Health.App.UI
{
    public partial class ImageInfoView : UserControl
    {
        public ImageInfoView(DataTable pics)
        {
            InitializeComponent();
            this.BindPic(pics);
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }
        Thread thread;
        UI.Loading load;
        /// <summary>
        /// ftp服务器ip
        /// </summary>
        private string HostName = ConfigHelper.GetAppStrings("ftp_ip");
        /// <summary>
        /// ftp验证 用户名
        /// </summary>
        private string UserName = Utils.AESDecrypt(ConfigHelper.GetAppStrings("ftp_userName"));
        /// <summary>
        /// ftp验证 密码
        /// </summary>
        private string Password = Utils.AESDecrypt(ConfigHelper.GetAppStrings("ftp_password"));
        // 病案列表绑定事件
        public void BindPic(DataTable picPath)
        {
            if (picPath != null && picPath.Rows != null && picPath.Rows.Count > 0)
            {
                this.cJiaPanel1.Visible = true;
                imagePanel.Controls.Clear();
                List<string> pics = new List<string>();
                this.Enabled = false;
                //this.ParentForm.Enabled = false;
                load = new UI.Loading();
                CJia.Health.Tools.Help.NewRedBorderFrom(load);
                thread = new Thread(new ParameterizedThreadStart(Loading));
                thread.Start((object)picPath);
            }
            else
            {
                this.cJiaPanel1.Visible = false;
            }
        }
        private void Loading(object picData)
        {
            DataTable picPath = (DataTable)picData;
            for (int i = 0; i < picPath.Rows.Count; i++)
            {
                string host = "ftp://" + CJia.Health.Tools.ConfigHelper.GetAppStrings("ftp_ip");
                string path = host + "/" + picPath.Rows[i]["STORAGE_PATH"].ToString().ToString().Replace('\\', '/') + "/" + picPath.Rows[i]["PICTURE_NAME"].ToString();
                Image img = CJia.Health.Tools.Help.GetImageByUri(path, UserName, Password);
                if (img != null)
                {
                    if (i == 0)
                    {
                        this.picDA.Image = img;
                        this.labTitle.Text = picPath.Rows[i]["pro_name"].ToString();
                        this.labPageNo.Text = picPath.Rows[i]["PAGE_NO"].ToString() + " " + picPath.Rows[i]["SUBPAGE"].ToString();
                    }
                    this.AddPicStr(img, picPath.Rows[i]["pro_name"].ToString(), picPath.Rows[i]["PAGE_NO"].ToString() + " " + picPath.Rows[i]["SUBPAGE"].ToString());
                }
            }
            this.Enabled = true;
            //this.ParentForm.Enabled = true;
            load.ParentForm.Close();
        }

        private void panel_Enter(object sender, EventArgs e)
        {
            CJia.Controls.CJiaPanel panel = sender as CJia.Controls.CJiaPanel;
            if (imagePanel.Controls != null && imagePanel.Controls.Count > 0)
            {
                for (int i = 0; i < imagePanel.Controls.Count; i++)
                {
                    if (imagePanel.Controls[i] is CJia.Controls.CJiaPanel)
                    {
                        imagePanel.Controls[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
                    }
                }
            }
            panel.BackColor = Color.LightCyan;
            imageTitle imagetitle = panel.Tag as imageTitle;
            this.picDA.Image = imagetitle.image;
            this.labTitle.Text = imagetitle.title;
            this.labPageNo.Text = imagetitle.pageNo;
        }

        //高度
        private int height = 0;

        //增加病案
        private void AddPic(Image picImage, string title, string pageNo)
        {
            imageTitle imagetitle = new imageTitle()
            {
                image = picImage,
                title = title,
                pageNo = pageNo
            };
            CJia.Controls.CJiaPicture pic = new Controls.CJiaPicture();
            pic.Image = picImage;
            pic.Location = new System.Drawing.Point(1, 1);
            pic.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            pic.Properties.Appearance.Options.UseBackColor = true;
            pic.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pic.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            pic.Size = new System.Drawing.Size(160, 120);

            CJia.Controls.CJiaLabel label = new Controls.CJiaLabel();
            label.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            label.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            label.Location = new System.Drawing.Point(1, 130);
            label.Size = new System.Drawing.Size(156, 16);
            label.Text = title + " " + pageNo;

            CJia.Controls.CJiaLabel line = new Controls.CJiaLabel();
            line.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            line.LineVisible = true;
            line.Location = new System.Drawing.Point(1, 142);
            line.LookAndFeel.SkinName = "Office 2010 Blue";
            line.LookAndFeel.UseDefaultLookAndFeel = false;
            line.Size = new System.Drawing.Size(160, 10);

            CJia.Controls.CJiaPanel panel = new Controls.CJiaPanel();
            panel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            panel.Appearance.Options.UseBackColor = true;
            panel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panel.Controls.Add(label);
            panel.Controls.Add(pic);
            panel.Controls.Add(line);
            panel.Location = new System.Drawing.Point(3, height + 3);
            panel.LookAndFeel.SkinName = "Office 2010 Silver";
            panel.LookAndFeel.UseDefaultLookAndFeel = false;
            panel.Size = new System.Drawing.Size(140, 130);
            panel.Tag = imagetitle;
            panel.Enter += new System.EventHandler(panel_Enter);

            imagePanel.Controls.Add(panel);

            this.height += 130;
        }

        private void AddPicStr(Image img, string title, string pageNo)
        {
            this.AddPic(img, title, pageNo);
        }


        public class imageTitle
        {
            public Image image;

            public string title;

            public string pageNo;
        }
    }
}

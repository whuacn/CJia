using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Controls
{
    /// <summary>
    /// 文件选择控件
    /// </summary>
    public class CJiaOpenFolder : DevExpress.XtraEditors.ButtonEdit
    {
        /// <summary>
        /// CJiaOpenFile构造函数
        /// </summary>
        public CJiaOpenFolder()
        {
            Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            Properties.Appearance.Options.UseFont = true;
            Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            Size = new System.Drawing.Size(135, 22);
            ButtonClick += CJiaOpenFile_ButtonClick;//选择文件夹
        }

        void CJiaOpenFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                this.Text = foldPath;
            }
        }
    }
}

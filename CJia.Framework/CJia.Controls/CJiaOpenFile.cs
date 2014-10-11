using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Controls
{
    /// <summary>
    /// 文件选择控件
    /// </summary>
    public class CJiaOpenFile:DevExpress.XtraEditors.ButtonEdit
    {
        /// <summary>
        /// CJiaOpenFile构造函数
        /// </summary>
        public CJiaOpenFile()
        {
            Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            Properties.Appearance.Options.UseFont = true;
            Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            Size = new System.Drawing.Size(135, 22);
            ButtonClick += CJiaOpenFile_ButtonClick;//选择文件
        }

        void CJiaOpenFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog newFile = new System.Windows.Forms.OpenFileDialog();
            if (newFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (newFile.ValidateNames)
                {
                    this.Text = newFile.FileName;
                }
            }
        }
    }
}

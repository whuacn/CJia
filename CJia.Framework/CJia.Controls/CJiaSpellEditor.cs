using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.ObjectModel;
using Microsoft.International.Converters.PinYinConverter;

namespace CJia.Controls
{
    /// <summary>
    /// 拼音编辑器
    /// </summary>
    public class CJiaSpellEditor
    {
        /// <summary>
        /// 将汉字转换成首拼
        /// </summary>
        /// <returns></returns> 
        public static string ToChString(string strChinese)
        {
            System.Collections.ArrayList al = new System.Collections.ArrayList();
            Regex MyRegex = new Regex("^[\u4e00-\u9fa5]$");
            foreach (Char c in strChinese)
            {
                if (MyRegex.IsMatch(c.ToString()))
                {
                    al.Add(GetPinyins(c));
                }
                else
                {
                    al.Add(new string[] { c.ToString(), c.ToString() });
                }
            }
            return GetFirstSpell(al);
        }

        private static string GetFirstSpell(ArrayList alPinyinData)
        {
            StringBuilder sbPy = new StringBuilder();
            for (int i = 0; i <= alPinyinData.Count - 1; i++)
            {
                string[] pyData = (string[])alPinyinData[i];
                if (pyData.Length > 2)
                {
                    //若有多音字，则显示窗口由用户选择；
                    return GetFirstSpellFromUser(alPinyinData);
                }
                else
                {
                    //无多音字
                    sbPy.Append(pyData[1].Substring(0, 1));
                }
            }
            return sbPy.ToString();
        }

        private static string GetFirstSpellFromUser(ArrayList alPinyinData)
        {
            #region 初始化Form
            DevExpress.XtraEditors.XtraForm frmPinyin = NewForm();
            DevExpress.XtraGrid.GridControl gridPinyin = new DevExpress.XtraGrid.GridControl();
            DevExpress.XtraGrid.Views.Grid.GridView viewPinyin = new DevExpress.XtraGrid.Views.Grid.GridView();
            CJia.Controls.CJiaPanel cJiaPanel1 = new CJiaPanel();
            CJia.Controls.CJiaLabel cJiaLabel1 = new CJiaLabel();
            CJia.Controls.BtnSave btnSave1 = new BtnSave();
            DevExpress.XtraEditors.XtraUserControl userControl1 = new DevExpress.XtraEditors.XtraUserControl();
            CJia.Controls.CJiaPanel cJiaPanel2 = new CJiaPanel();
            // 
            // cJiaPanel1
            // 
            cJiaPanel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(180)))), ((int)(((byte)(228)))));
            cJiaPanel1.Appearance.Options.UseBackColor = true;
            cJiaPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            cJiaPanel1.Controls.Add(cJiaLabel1);
            cJiaPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            cJiaPanel1.Location = new System.Drawing.Point(0, 0);
            cJiaPanel1.LookAndFeel.UseDefaultLookAndFeel = false;
            cJiaPanel1.Name = "cJiaPanel1";
            cJiaPanel1.Size = new System.Drawing.Size(525, 35);
            cJiaPanel1.TabIndex = 2;
            // 
            // cJiaLabel1
            // 
            cJiaLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            cJiaLabel1.Appearance.ForeColor = System.Drawing.Color.White;
            cJiaLabel1.Location = new System.Drawing.Point(5, 11);
            cJiaLabel1.Name = "cJiaLabel1";
            cJiaLabel1.Size = new System.Drawing.Size(144, 16);
            cJiaLabel1.TabIndex = 2;
            cJiaLabel1.Text = "请确认多音字拼音码";
            // gridPinyin
            gridPinyin.EmbeddedNavigator.Name = "";
            gridPinyin.Dock = System.Windows.Forms.DockStyle.Top;
            gridPinyin.Location = new System.Drawing.Point(0, 35);
            gridPinyin.LookAndFeel.SkinName = "Office 2010 Blue";
            gridPinyin.LookAndFeel.UseDefaultLookAndFeel = false;
            gridPinyin.MainView = viewPinyin;
            gridPinyin.Name = "gridPinyin";
            gridPinyin.Size = new System.Drawing.Size(525, 141);
            gridPinyin.TabIndex = 1;
            gridPinyin.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            viewPinyin});
            // viewPinyin
            #region viewPinyin
            viewPinyin.GridControl = gridPinyin;
            viewPinyin.Name = "viewPinyin";
            viewPinyin.OptionsView.ColumnAutoWidth = false;
            viewPinyin.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            viewPinyin.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            viewPinyin.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            viewPinyin.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            viewPinyin.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            viewPinyin.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            viewPinyin.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            viewPinyin.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            viewPinyin.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            viewPinyin.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            viewPinyin.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            viewPinyin.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            viewPinyin.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            viewPinyin.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            viewPinyin.Appearance.Empty.Options.UseBackColor = true;
            viewPinyin.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            viewPinyin.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            viewPinyin.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            viewPinyin.Appearance.EvenRow.Options.UseBackColor = true;
            viewPinyin.Appearance.EvenRow.Options.UseBorderColor = true;
            viewPinyin.Appearance.EvenRow.Options.UseForeColor = true;
            viewPinyin.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            viewPinyin.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            viewPinyin.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            viewPinyin.Appearance.FilterCloseButton.Options.UseBackColor = true;
            viewPinyin.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            viewPinyin.Appearance.FilterCloseButton.Options.UseForeColor = true;
            viewPinyin.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            viewPinyin.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            viewPinyin.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            viewPinyin.Appearance.FilterPanel.Options.UseBackColor = true;
            viewPinyin.Appearance.FilterPanel.Options.UseForeColor = true;
            viewPinyin.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            viewPinyin.Appearance.FixedLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            viewPinyin.Appearance.FixedLine.Options.UseBackColor = true;
            viewPinyin.Appearance.FixedLine.Options.UseBorderColor = true;
            viewPinyin.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            viewPinyin.Appearance.FocusedCell.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            viewPinyin.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            viewPinyin.Appearance.FocusedCell.Options.UseBackColor = true;
            viewPinyin.Appearance.FocusedCell.Options.UseForeColor = true;
            viewPinyin.Appearance.FocusedRow.BackColor = System.Drawing.Color.White;
            viewPinyin.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            viewPinyin.Appearance.FocusedRow.Options.UseBackColor = true;
            viewPinyin.Appearance.FocusedRow.Options.UseBorderColor = true;
            viewPinyin.Appearance.FocusedRow.Options.UseFont = true;
            viewPinyin.Appearance.FocusedRow.Options.UseForeColor = true;
            viewPinyin.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            viewPinyin.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            viewPinyin.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            viewPinyin.Appearance.FooterPanel.Options.UseBackColor = true;
            viewPinyin.Appearance.FooterPanel.Options.UseBorderColor = true;
            viewPinyin.Appearance.FooterPanel.Options.UseForeColor = true;
            viewPinyin.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            viewPinyin.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            viewPinyin.Appearance.GroupButton.Options.UseBackColor = true;
            viewPinyin.Appearance.GroupButton.Options.UseBorderColor = true;
            viewPinyin.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            viewPinyin.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            viewPinyin.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            viewPinyin.Appearance.GroupFooter.Options.UseBackColor = true;
            viewPinyin.Appearance.GroupFooter.Options.UseBorderColor = true;
            viewPinyin.Appearance.GroupFooter.Options.UseForeColor = true;
            viewPinyin.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            viewPinyin.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            viewPinyin.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            viewPinyin.Appearance.GroupPanel.Options.UseBackColor = true;
            viewPinyin.Appearance.GroupPanel.Options.UseForeColor = true;
            viewPinyin.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            viewPinyin.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            viewPinyin.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            viewPinyin.Appearance.GroupRow.Options.UseBackColor = true;
            viewPinyin.Appearance.GroupRow.Options.UseBorderColor = true;
            viewPinyin.Appearance.GroupRow.Options.UseForeColor = true;
            viewPinyin.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            viewPinyin.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            viewPinyin.Appearance.HeaderPanel.Options.UseBackColor = true;
            viewPinyin.Appearance.HeaderPanel.Options.UseBorderColor = true;
            viewPinyin.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            viewPinyin.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            viewPinyin.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            viewPinyin.Appearance.HideSelectionRow.Options.UseBackColor = true;
            viewPinyin.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            viewPinyin.Appearance.HideSelectionRow.Options.UseForeColor = true;
            viewPinyin.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            viewPinyin.Appearance.HorzLine.Options.UseBackColor = true;
            viewPinyin.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            viewPinyin.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            viewPinyin.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            viewPinyin.Appearance.OddRow.Options.UseBackColor = true;
            viewPinyin.Appearance.OddRow.Options.UseBorderColor = true;
            viewPinyin.Appearance.OddRow.Options.UseForeColor = true;
            viewPinyin.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            viewPinyin.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            viewPinyin.Appearance.Preview.Options.UseFont = true;
            viewPinyin.Appearance.Preview.Options.UseForeColor = true;
            viewPinyin.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            viewPinyin.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            viewPinyin.Appearance.Row.Options.UseBackColor = true;
            viewPinyin.Appearance.Row.Options.UseForeColor = true;
            viewPinyin.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            viewPinyin.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            viewPinyin.Appearance.RowSeparator.Options.UseBackColor = true;
            viewPinyin.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            viewPinyin.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            viewPinyin.Appearance.SelectedRow.Options.UseBackColor = true;
            viewPinyin.Appearance.SelectedRow.Options.UseForeColor = true;
            viewPinyin.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            viewPinyin.Appearance.TopNewRow.Options.UseBackColor = true;
            viewPinyin.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            viewPinyin.Appearance.VertLine.Options.UseBackColor = true;

            viewPinyin.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            //viewPinyin.OptionsBehavior.Editable = false;
            viewPinyin.OptionsCustomization.AllowFilter = false;
            viewPinyin.OptionsSelection.EnableAppearanceFocusedCell = true;
            viewPinyin.OptionsView.EnableAppearanceEvenRow = true;
            viewPinyin.OptionsView.EnableAppearanceOddRow = true;
            viewPinyin.OptionsView.ShowGroupPanel = false;
            viewPinyin.RowHeight = 25;
            viewPinyin.OptionsView.ShowIndicator = false;
            viewPinyin.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            #endregion
            // 
            // btnSave1
            // 
            btnSave1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10F);
            btnSave1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            btnSave1.Appearance.Options.UseFont = true;
            btnSave1.Appearance.Options.UseForeColor = true;
            btnSave1.CustomText = "确认";
            btnSave1.Image = Properties.Resources.Save;
            btnSave1.Location = new System.Drawing.Point(435, 7);
            btnSave1.LookAndFeel.SkinName = "Office 2010 Blue";
            btnSave1.LookAndFeel.UseDefaultLookAndFeel = false;
            btnSave1.Name = "btnSave1";
            btnSave1.Selectable = false;
            btnSave1.Size = new System.Drawing.Size(80, 28);
            btnSave1.TabIndex = 4;
            btnSave1.Text = "确认";
            btnSave1.Click += new EventHandler(btnOk_Click);
            // 
            // cJiaPanel2
            // 
            cJiaPanel2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            cJiaPanel2.Appearance.BackColor2 = System.Drawing.Color.White;
            cJiaPanel2.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(157)))), ((int)(((byte)(189)))));
            cJiaPanel2.Appearance.Options.UseBackColor = true;
            cJiaPanel2.Appearance.Options.UseBorderColor = true;
            cJiaPanel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            cJiaPanel2.Controls.Add(btnSave1);
            cJiaPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            cJiaPanel2.Location = new System.Drawing.Point(0, 172);
            cJiaPanel2.LookAndFeel.SkinName = "Office 2010 Silver";
            cJiaPanel2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            cJiaPanel2.LookAndFeel.UseDefaultLookAndFeel = false;
            cJiaPanel2.Name = "cJiaPanel2";
            cJiaPanel2.Size = new System.Drawing.Size(525, 41);
            cJiaPanel2.TabIndex = 4;
            // 
            // UserControl1
            // 
            userControl1.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            userControl1.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            userControl1.Controls.Add(cJiaPanel2);
            userControl1.Controls.Add(gridPinyin);
            userControl1.Controls.Add(cJiaPanel1);
            userControl1.Name = "UserControl1";
            userControl1.Size = new System.Drawing.Size(525, 215);

            frmPinyin.Controls.Add(userControl1);
            userControl1.Dock = DockStyle.Fill;
            frmPinyin.AcceptButton = btnSave1;
            #endregion

            #region 获取拼音
            DataTable dt = BuildTable(alPinyinData);
            DataRow dr = dt.NewRow();
            for (int i = 0; i <= alPinyinData.Count - 1; i++)
            {
                string[] pyData = (string[])alPinyinData[i];

                #region New Grid Column
                DevExpress.XtraGrid.Columns.GridColumn gridColumn = new DevExpress.XtraGrid.Columns.GridColumn();
                gridColumn.Caption = pyData[0];
                gridColumn.FieldName = dt.Columns[i].ColumnName;
                gridColumn.OptionsColumn.AllowEdit = false;
                gridColumn.Visible = true;
                gridColumn.VisibleIndex = viewPinyin.Columns.Count + 1;
                gridColumn.Width = 60;
                gridColumn.AppearanceCell.Options.UseTextOptions = true;
                gridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridColumn.AppearanceHeader.Options.UseTextOptions = true;
                gridColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                #endregion

                dr[i] = pyData[1];
                if (pyData.Length > 2)
                {
                    DevExpress.XtraEditors.Repository.RepositoryItemComboBox boxPinyin = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                    boxPinyin.AutoHeight = false;
                    boxPinyin.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                    for (int j = 1; j <= pyData.Length - 1; j++)
                    {
                        boxPinyin.Items.Add(pyData[j]);
                    }
                    gridColumn.ColumnEdit = boxPinyin;
                    gridColumn.OptionsColumn.AllowEdit = true;
                    gridColumn.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
                    gridColumn.AppearanceHeader.Options.UseForeColor = true;
                }
                viewPinyin.Columns.Add(gridColumn);
            }
            dt.Rows.Add(dr);
            gridPinyin.DataSource = dt;
            frmPinyin.ShowDialog();
            viewPinyin.PostEditor();
            #endregion

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= alPinyinData.Count - 1; i++)
            {
                sb.Append(dt.Rows[0][i].ToString().Substring(0, 1));
            }
            return sb.ToString();
        }

        static void btnOk_Click(object sender, EventArgs e)
        {
            ((sender as CJia.Controls.BtnSave).Parent.Parent.Parent as DevExpress.XtraEditors.XtraForm).Close();
        }

        private static DataTable BuildTable(ArrayList alPinyinData)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i <= alPinyinData.Count - 1; i++)
            {
                dt.Columns.Add();
            }
            return dt;
        }

        /// <summary>
        /// 创建一个模式窗体.
        /// </summary>
        /// <returns></returns>
        private static DevExpress.XtraEditors.XtraForm NewForm()
        {
            DevExpress.XtraEditors.XtraForm xForm = new DevExpress.XtraEditors.XtraForm();
            xForm.FormBorderStyle = FormBorderStyle.None;
            xForm.Height = 215;
            xForm.Width = 525;
            xForm.StartPosition = FormStartPosition.CenterScreen;
            return xForm;
        }

        private static string[] GetPinyins(Char c)
        {
            System.Collections.ArrayList alPinyin = new System.Collections.ArrayList();
            alPinyin.Add(c.ToString());
            ChineseChar x = new ChineseChar(c);
            foreach (string s in x.Pinyins)
            {
                if (s != null)
                {
                    string py = s.Substring(0, s.Length - 1);
                    if (alPinyin.IndexOf(py) == -1)
                    {
                        alPinyin.Add(py);
                    }
                }
            }
            return (string[])alPinyin.ToArray(typeof(string));
        }
    }
}

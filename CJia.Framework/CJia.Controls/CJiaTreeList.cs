using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CJia.Controls
{
    /// <summary>
    /// TreeList控件
    /// </summary>
    public class CJiaTreeList : DevExpress.XtraTreeList.TreeList
    {
        /// <summary>
        /// CJiaTreeList构造函数
        /// </summary>
        public CJiaTreeList()
        {
            Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            Appearance.Empty.Options.UseBackColor = true;
            Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            Appearance.EvenRow.Options.UseBackColor = true;
            Appearance.EvenRow.Options.UseBorderColor = true;
            Appearance.EvenRow.Options.UseForeColor = true;
            Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            Appearance.FocusedCell.Options.UseBackColor = true;
            Appearance.FocusedCell.Options.UseForeColor = true;
            Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(223)))));
            Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(175)))), ((int)(((byte)(223)))));
            Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            Appearance.FocusedRow.Options.UseBackColor = true;
            Appearance.FocusedRow.Options.UseBorderColor = true;
            Appearance.FocusedRow.Options.UseForeColor = true;
            Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            Appearance.FooterPanel.Options.UseBackColor = true;
            Appearance.FooterPanel.Options.UseBorderColor = true;
            Appearance.FooterPanel.Options.UseForeColor = true;
            Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            Appearance.GroupButton.Options.UseBackColor = true;
            Appearance.GroupButton.Options.UseBorderColor = true;
            Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            Appearance.GroupFooter.Options.UseBackColor = true;
            Appearance.GroupFooter.Options.UseBorderColor = true;
            Appearance.GroupFooter.Options.UseForeColor = true;
            Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
            Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            Appearance.HeaderPanel.Options.UseBackColor = true;
            Appearance.HeaderPanel.Options.UseBorderColor = true;
            Appearance.HeaderPanel.Options.UseForeColor = true;
            Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            Appearance.HideSelectionRow.Options.UseBackColor = true;
            Appearance.HideSelectionRow.Options.UseBorderColor = true;
            Appearance.HideSelectionRow.Options.UseForeColor = true;
            Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            Appearance.HorzLine.Options.UseBackColor = true;
            Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            Appearance.OddRow.BackColor2 = System.Drawing.Color.White;
            Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            Appearance.OddRow.Options.UseBackColor = true;
            Appearance.OddRow.Options.UseForeColor = true;
            Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            Appearance.Preview.Options.UseFont = true;
            Appearance.Preview.Options.UseForeColor = true;
            Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            Appearance.Row.BackColor2 = System.Drawing.Color.White;
            Appearance.Row.ForeColor = System.Drawing.Color.Black;
            Appearance.Row.Options.UseBackColor = true;
            Appearance.Row.Options.UseForeColor = true;
            Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            Appearance.SelectedRow.Options.UseBackColor = true;
            Appearance.SelectedRow.Options.UseForeColor = true;
            Appearance.TreeLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            Appearance.TreeLine.Options.UseBackColor = true;
            Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            Appearance.VertLine.Options.UseBackColor = true;
            Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            LookAndFeel.SkinName = "Office 2010 Blue";
            LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            LookAndFeel.UseDefaultLookAndFeel = false;
            OptionsBehavior.AllowIndeterminateCheckState = true;
            OptionsBehavior.Editable = false;
            OptionsSelection.EnableAppearanceFocusedCell = false;
            OptionsView.ShowCheckBoxes = true;
            OptionsView.ShowColumns = false;
            OptionsView.ShowFocusedFrame = false;
            OptionsView.ShowHorzLines = false;
            OptionsView.ShowIndicator = false;
            OptionsView.ShowVertLines = false;
            Size = new System.Drawing.Size(180, 380);
            BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.treeList_BeforeCheckNode);
            AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList_AfterCheckNode);
        }

        /// <summary>
        /// 点击节点前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        /// <summary>
        /// 点击节点后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        /// <summary>
        /// 选择子节点时触发
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        private void SetCheckedChildNodes(DevExpress.XtraTreeList.Nodes.TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        /// <summary>
        /// 选择父节点时触发
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        private void SetCheckedParentNodes(DevExpress.XtraTreeList.Nodes.TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }

        /// <summary>
        /// 判断此节点下的所有子节点是否选中
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Boolean IsChildsChecked(DevExpress.XtraTreeList.Nodes.TreeListNode node)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                if (node.Nodes[i].CheckState == CheckState.Unchecked)
                    return false;
                if (node.Nodes[i].HasChildren)
                    IsChildsChecked(node.Nodes[i]);
            }
            return true;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.Tools.Models
{
    public class CreateMvpModel
    {
        public string GetEntity(String model,string projectName,string uiName)
        {
            StringBuilder newStr = new StringBuilder(model);
            newStr.Replace("[项目名称]", projectName);
            newStr.Replace("[UI名]", uiName);
            return newStr.ToString();
        }

        public string GetDesigner(string projectName, string uiName)
        {
            string model = @"namespace [项目名称].UI
{
    partial class [UI名]View
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name=""disposing"">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion
    }
}";
            return this.GetEntity(model, projectName, uiName);
        }
    }
}

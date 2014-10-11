namespace CJia.Server
{
    partial class AddDBName
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDBConection = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDBType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSystemNO = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtDBConection
            // 
            this.txtDBConection.Location = new System.Drawing.Point(110, 115);
            this.txtDBConection.Name = "txtDBConection";
            this.txtDBConection.Size = new System.Drawing.Size(415, 21);
            this.txtDBConection.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "连接字符串：";
            // 
            // txtDBType
            // 
            this.txtDBType.Location = new System.Drawing.Point(110, 75);
            this.txtDBType.Name = "txtDBType";
            this.txtDBType.Size = new System.Drawing.Size(415, 21);
            this.txtDBType.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "数据库类型：";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(374, 35);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(151, 21);
            this.txtDBName.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "数据库名：";
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(450, 158);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 11;
            this.btnEnter.Text = "确认";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "系统编号：";
            // 
            // cmbSystemNO
            // 
            this.cmbSystemNO.FormattingEnabled = true;
            this.cmbSystemNO.Location = new System.Drawing.Point(110, 36);
            this.cmbSystemNO.Name = "cmbSystemNO";
            this.cmbSystemNO.Size = new System.Drawing.Size(151, 20);
            this.cmbSystemNO.TabIndex = 18;
            // 
            // AddDBName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 206);
            this.Controls.Add(this.cmbSystemNO);
            this.Controls.Add(this.txtDBConection);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDBType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDBName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.label1);
            this.Name = "AddDBName";
            this.Text = "AddDBName";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDBConection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDBType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSystemNO;
    }
}
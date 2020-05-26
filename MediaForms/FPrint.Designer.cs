namespace C_sharp_experience.MediaForms
{
    partial class FPrint
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
            if (disposing && (components != null))
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBCirculation = new System.Windows.Forms.TextBox();
            this.textBIssueNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBPereodicity = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Тираж";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Номер экземпляра";
            // 
            // textBCirculation
            // 
            this.textBCirculation.Location = new System.Drawing.Point(40, 178);
            this.textBCirculation.Name = "textBCirculation";
            this.textBCirculation.Size = new System.Drawing.Size(161, 20);
            this.textBCirculation.TabIndex = 6;
            this.textBCirculation.Text = "1";
            this.textBCirculation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBIssueNum
            // 
            this.textBIssueNum.Location = new System.Drawing.Point(40, 228);
            this.textBIssueNum.Name = "textBIssueNum";
            this.textBIssueNum.Size = new System.Drawing.Size(161, 20);
            this.textBIssueNum.TabIndex = 7;
            this.textBIssueNum.Text = "1";
            this.textBIssueNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBIssueNum_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Переодичность";
            // 
            // comboBPereodicity
            // 
            this.comboBPereodicity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBPereodicity.FormattingEnabled = true;
            this.comboBPereodicity.Location = new System.Drawing.Point(40, 276);
            this.comboBPereodicity.Name = "comboBPereodicity";
            this.comboBPereodicity.Size = new System.Drawing.Size(161, 21);
            this.comboBPereodicity.TabIndex = 9;
            // 
            // FPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBPereodicity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBIssueNum);
            this.Controls.Add(this.textBCirculation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "FPrint";
            this.Text = "FPrint";
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.textBCirculation, 0);
            this.Controls.SetChildIndex(this.textBIssueNum, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.comboBPereodicity, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBCirculation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBIssueNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBPereodicity;
    }
}
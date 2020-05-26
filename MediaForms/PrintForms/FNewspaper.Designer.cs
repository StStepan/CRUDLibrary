namespace C_sharp_experience.MediaForms.PrintForms
{
    partial class FNewspaper
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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.radioBOfficialTrue = new System.Windows.Forms.RadioButton();
            this.comboBAudience = new System.Windows.Forms.ComboBox();
            this.BSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(253, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Целевая аудитория";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(256, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Официальное СМИ";
            // 
            // radioBOfficialTrue
            // 
            this.radioBOfficialTrue.AutoSize = true;
            this.radioBOfficialTrue.Location = new System.Drawing.Point(259, 127);
            this.radioBOfficialTrue.Name = "radioBOfficialTrue";
            this.radioBOfficialTrue.Size = new System.Drawing.Size(40, 17);
            this.radioBOfficialTrue.TabIndex = 13;
            this.radioBOfficialTrue.TabStop = true;
            this.radioBOfficialTrue.Text = "Да";
            this.radioBOfficialTrue.UseVisualStyleBackColor = true;
            // 
            // comboBAudience
            // 
            this.comboBAudience.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBAudience.FormattingEnabled = true;
            this.comboBAudience.Location = new System.Drawing.Point(256, 61);
            this.comboBAudience.Name = "comboBAudience";
            this.comboBAudience.Size = new System.Drawing.Size(121, 21);
            this.comboBAudience.TabIndex = 14;
            // 
            // BSave
            // 
            this.BSave.Location = new System.Drawing.Point(122, 306);
            this.BSave.Name = "BSave";
            this.BSave.Size = new System.Drawing.Size(148, 44);
            this.BSave.TabIndex = 15;
            this.BSave.Text = "Сохранить";
            this.BSave.UseVisualStyleBackColor = true;
            this.BSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // FNewspaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 362);
            this.Controls.Add(this.BSave);
            this.Controls.Add(this.comboBAudience);
            this.Controls.Add(this.radioBOfficialTrue);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Name = "FNewspaper";
            this.Text = "FNewspaper";
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.radioBOfficialTrue, 0);
            this.Controls.SetChildIndex(this.comboBAudience, 0);
            this.Controls.SetChildIndex(this.BSave, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioBOfficialTrue;
        private System.Windows.Forms.ComboBox comboBAudience;
        private System.Windows.Forms.Button BSave;
    }
}
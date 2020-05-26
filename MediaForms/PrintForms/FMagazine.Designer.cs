namespace C_sharp_experience.MediaForms.PrintForms
{
    partial class FMagazine
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
            this.comboBCategory = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBVolume = new System.Windows.Forms.TextBox();
            this.BSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(259, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Вид журнала";
            // 
            // comboBCategory
            // 
            this.comboBCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBCategory.FormattingEnabled = true;
            this.comboBCategory.Location = new System.Drawing.Point(262, 63);
            this.comboBCategory.Name = "comboBCategory";
            this.comboBCategory.Size = new System.Drawing.Size(121, 21);
            this.comboBCategory.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(262, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Объем журнала (стр)";
            // 
            // textBVolume
            // 
            this.textBVolume.Location = new System.Drawing.Point(262, 124);
            this.textBVolume.Name = "textBVolume";
            this.textBVolume.Size = new System.Drawing.Size(100, 20);
            this.textBVolume.TabIndex = 13;
            this.textBVolume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBVolume_KeyPress);
            // 
            // BSave
            // 
            this.BSave.Location = new System.Drawing.Point(126, 319);
            this.BSave.Name = "BSave";
            this.BSave.Size = new System.Drawing.Size(162, 46);
            this.BSave.TabIndex = 14;
            this.BSave.Text = "Сохранить";
            this.BSave.UseVisualStyleBackColor = true;
            this.BSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // FMagazine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 386);
            this.Controls.Add(this.BSave);
            this.Controls.Add(this.textBVolume);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBCategory);
            this.Controls.Add(this.label6);
            this.Name = "FMagazine";
            this.Text = "FMagazine";
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.comboBCategory, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.textBVolume, 0);
            this.Controls.SetChildIndex(this.BSave, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBCategory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBVolume;
        private System.Windows.Forms.Button BSave;
    }
}
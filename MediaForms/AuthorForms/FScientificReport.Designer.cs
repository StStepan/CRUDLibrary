namespace C_sharp_experience.MediaForms.AuthorForms
{
    partial class FScientificReport
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
            this.label4 = new System.Windows.Forms.Label();
            this.comboBSubject = new System.Windows.Forms.ComboBox();
            this.BSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Область";
            // 
            // comboBSubject
            // 
            this.comboBSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBSubject.FormattingEnabled = true;
            this.comboBSubject.Location = new System.Drawing.Point(40, 237);
            this.comboBSubject.Name = "comboBSubject";
            this.comboBSubject.Size = new System.Drawing.Size(200, 21);
            this.comboBSubject.TabIndex = 7;
            // 
            // BSave
            // 
            this.BSave.Location = new System.Drawing.Point(40, 291);
            this.BSave.Name = "BSave";
            this.BSave.Size = new System.Drawing.Size(161, 53);
            this.BSave.TabIndex = 8;
            this.BSave.Text = "Сохранить";
            this.BSave.UseVisualStyleBackColor = true;
            this.BSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // FScientificReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 356);
            this.Controls.Add(this.BSave);
            this.Controls.Add(this.comboBSubject);
            this.Controls.Add(this.label4);
            this.Name = "FScientificReport";
            this.Text = "FScientificReport";
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.comboBSubject, 0);
            this.Controls.SetChildIndex(this.BSave, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBSubject;
        private System.Windows.Forms.Button BSave;
    }
}
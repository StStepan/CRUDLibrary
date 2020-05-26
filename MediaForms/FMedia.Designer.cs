namespace C_sharp_experience.MediaForms
{
    partial class FMedia
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.datePickerPublished = new System.Windows.Forms.DateTimePicker();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Дата публикации";
            // 
            // datePickerPublished
            // 
            this.datePickerPublished.Location = new System.Drawing.Point(40, 125);
            this.datePickerPublished.MaxDate = new System.DateTime(2020, 5, 26, 0, 0, 0, 0);
            this.datePickerPublished.Name = "datePickerPublished";
            this.datePickerPublished.Size = new System.Drawing.Size(200, 20);
            this.datePickerPublished.TabIndex = 2;
            this.datePickerPublished.Value = new System.DateTime(2020, 5, 26, 0, 0, 0, 0);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(40, 63);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(200, 20);
            this.textBoxName.TabIndex = 3;
            // 
            // FMedia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.datePickerPublished);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FMedia";
            this.Text = "MediaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datePickerPublished;
        private System.Windows.Forms.TextBox textBoxName;
    }
}
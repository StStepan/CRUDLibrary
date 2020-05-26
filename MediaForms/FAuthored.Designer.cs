namespace C_sharp_experience.MediaForms
{
    partial class FAuthored
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
            this.textBAuthor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Автор";
            // 
            // textBAuthor
            // 
            this.textBAuthor.Location = new System.Drawing.Point(40, 184);
            this.textBAuthor.Name = "textBAuthor";
            this.textBAuthor.Size = new System.Drawing.Size(200, 20);
            this.textBAuthor.TabIndex = 5;
            // 
            // FAuthored
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 287);
            this.Controls.Add(this.textBAuthor);
            this.Controls.Add(this.label3);
            this.Name = "FAuthored";
            this.Text = "FAuthored";
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.textBAuthor, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBAuthor;
    }
}
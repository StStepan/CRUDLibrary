namespace C_sharp_experience
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewMedium = new System.Windows.Forms.ListView();
            this.columnHeaderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BAdd = new System.Windows.Forms.Button();
            this.BEdit = new System.Windows.Forms.Button();
            this.BDelete = new System.Windows.Forms.Button();
            this.comboBMediaSelect = new System.Windows.Forms.ComboBox();
            this.BView = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewMedium
            // 
            this.listViewMedium.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderID,
            this.columnHeaderName,
            this.columnHeaderType});
            this.listViewMedium.FullRowSelect = true;
            this.listViewMedium.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewMedium.HideSelection = false;
            this.listViewMedium.Location = new System.Drawing.Point(12, 12);
            this.listViewMedium.MultiSelect = false;
            this.listViewMedium.Name = "listViewMedium";
            this.listViewMedium.Size = new System.Drawing.Size(499, 283);
            this.listViewMedium.TabIndex = 0;
            this.listViewMedium.UseCompatibleStateImageBehavior = false;
            this.listViewMedium.View = System.Windows.Forms.View.Details;
            this.listViewMedium.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listViewMedium_ColumnWidthChanging);
            // 
            // columnHeaderID
            // 
            this.columnHeaderID.Tag = "";
            this.columnHeaderID.Text = "ID";
            this.columnHeaderID.Width = 50;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Название";
            this.columnHeaderName.Width = 344;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Тип";
            this.columnHeaderType.Width = 100;
            // 
            // BAdd
            // 
            this.BAdd.Location = new System.Drawing.Point(22, 13);
            this.BAdd.Name = "BAdd";
            this.BAdd.Size = new System.Drawing.Size(93, 21);
            this.BAdd.TabIndex = 1;
            this.BAdd.Text = "Добавить";
            this.BAdd.UseVisualStyleBackColor = true;
            this.BAdd.Click += new System.EventHandler(this.Add_Click);
            // 
            // BEdit
            // 
            this.BEdit.Location = new System.Drawing.Point(22, 81);
            this.BEdit.Name = "BEdit";
            this.BEdit.Size = new System.Drawing.Size(220, 50);
            this.BEdit.TabIndex = 2;
            this.BEdit.Text = "Редактировать";
            this.BEdit.UseVisualStyleBackColor = true;
            this.BEdit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // BDelete
            // 
            this.BDelete.Location = new System.Drawing.Point(22, 147);
            this.BDelete.Name = "BDelete";
            this.BDelete.Size = new System.Drawing.Size(220, 50);
            this.BDelete.TabIndex = 3;
            this.BDelete.Text = "Удалить";
            this.BDelete.UseVisualStyleBackColor = true;
            this.BDelete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // comboBMediaSelect
            // 
            this.comboBMediaSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBMediaSelect.FormattingEnabled = true;
            this.comboBMediaSelect.Items.AddRange(new object[] {
            "Газета",
            "Журнал",
            "Книга",
            "Научная работа"});
            this.comboBMediaSelect.Location = new System.Drawing.Point(121, 13);
            this.comboBMediaSelect.Name = "comboBMediaSelect";
            this.comboBMediaSelect.Size = new System.Drawing.Size(130, 21);
            this.comboBMediaSelect.TabIndex = 4;
            // 
            // BView
            // 
            this.BView.Location = new System.Drawing.Point(23, 222);
            this.BView.Name = "BView";
            this.BView.Size = new System.Drawing.Size(219, 52);
            this.BView.TabIndex = 5;
            this.BView.Text = "Просмотреть";
            this.BView.UseVisualStyleBackColor = true;
            this.BView.Click += new System.EventHandler(this.BView_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BView);
            this.groupBox1.Controls.Add(this.comboBMediaSelect);
            this.groupBox1.Controls.Add(this.BDelete);
            this.groupBox1.Controls.Add(this.BEdit);
            this.groupBox1.Controls.Add(this.BAdd);
            this.groupBox1.Location = new System.Drawing.Point(517, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 283);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 306);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listViewMedium);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Электронная библиотека";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewMedium;
        private System.Windows.Forms.Button BAdd;
        private System.Windows.Forms.Button BEdit;
        private System.Windows.Forms.Button BDelete;
        public System.Windows.Forms.ColumnHeader columnHeaderID;
        public System.Windows.Forms.ColumnHeader columnHeaderName;
        public System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ComboBox comboBMediaSelect;
        private System.Windows.Forms.Button BView;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}


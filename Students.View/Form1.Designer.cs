namespace Students.View
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dataGridViewStudents = new DataGridView();
            buttonAdd = new Button();
            buttonDelete = new Button();
            buttonRefresh = new Button();
            buttonToggleMode = new Button();
            textBoxFirstName = new TextBox();
            textBoxLastName = new TextBox();
            textBoxGroup = new TextBox();
            labelFirstName = new Label();
            labelLastName = new Label();
            labelGroup = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewStudents
            // 
            dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudents.Location = new Point(43, 25);
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.RowHeadersWidth = 82;
            dataGridViewStudents.Size = new Size(1126, 376);
            dataGridViewStudents.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(56, 723);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(150, 46);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(230, 723);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(150, 46);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(1019, 728);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(150, 46);
            buttonRefresh.TabIndex = 3;
            buttonRefresh.Text = "Обновить";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // buttonToggleMode
            // 
            buttonToggleMode.Location = new Point(404, 723);
            buttonToggleMode.Name = "buttonToggleMode";
            buttonToggleMode.Size = new Size(382, 46);
            buttonToggleMode.TabIndex = 4;
            buttonToggleMode.Text = "Переключить на Dapper";
            buttonToggleMode.UseVisualStyleBackColor = true;
            buttonToggleMode.Click += buttonToggleMode_Click;
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(244, 444);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(200, 39);
            textBoxFirstName.TabIndex = 5;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(244, 510);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(200, 39);
            textBoxLastName.TabIndex = 6;
            // 
            // textBoxGroup
            // 
            textBoxGroup.Location = new Point(244, 576);
            textBoxGroup.Name = "textBoxGroup";
            textBoxGroup.Size = new Size(200, 39);
            textBoxGroup.TabIndex = 7;
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Location = new Point(60, 445);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(61, 32);
            labelFirstName.TabIndex = 2;
            labelFirstName.Text = "Имя";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Location = new Point(58, 510);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(113, 32);
            labelLastName.TabIndex = 1;
            labelLastName.Text = "Фамилия";
            // 
            // labelGroup
            // 
            labelGroup.AutoSize = true;
            labelGroup.Location = new Point(59, 577);
            labelGroup.Name = "labelGroup";
            labelGroup.Size = new Size(91, 32);
            labelGroup.TabIndex = 0;
            labelGroup.Text = "Группа";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1223, 843);
            Controls.Add(labelGroup);
            Controls.Add(labelLastName);
            Controls.Add(labelFirstName);
            Controls.Add(textBoxGroup);
            Controls.Add(textBoxLastName);
            Controls.Add(textBoxFirstName);
            Controls.Add(buttonToggleMode);
            Controls.Add(buttonRefresh);
            Controls.Add(buttonDelete);
            Controls.Add(buttonAdd);
            Controls.Add(dataGridViewStudents);
            Name = "Form1";
            Text = "Студенты";
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewStudents;
        private Button buttonAdd;
        private Button buttonDelete;
        private Button buttonRefresh;
        private Button buttonToggleMode; 
        private TextBox textBoxFirstName;
        private TextBox textBoxLastName;
        private TextBox textBoxGroup; 
        private Label labelFirstName;
        private Label labelLastName;
        private Label labelGroup; 
    }
}
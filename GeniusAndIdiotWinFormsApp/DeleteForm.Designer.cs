namespace GeniusAndIdiotWinFormsApp
{
    partial class DeleteForm
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
            BackButton = new Button();
            dataGridView1 = new DataGridView();
            Number = new DataGridViewTextBoxColumn();
            Question = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            NumberDeleteTextBox = new TextBox();
            DeleteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // BackButton
            // 
            BackButton.Location = new Point(12, 12);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(94, 29);
            BackButton.TabIndex = 0;
            BackButton.Text = "НАЗАД";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Number, Question });
            dataGridView1.Location = new Point(12, 47);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(736, 270);
            dataGridView1.TabIndex = 1;
            // 
            // Number
            // 
            Number.HeaderText = "Номер";
            Number.MinimumWidth = 6;
            Number.Name = "Number";
            Number.ReadOnly = true;
            Number.Width = 65;
            // 
            // Question
            // 
            Question.HeaderText = "Вопрос";
            Question.MinimumWidth = 6;
            Question.Name = "Question";
            Question.ReadOnly = true;
            Question.Width = 618;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(316, 21);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 2;
            label1.Text = "ВОПРОСЫ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(168, 330);
            label2.Name = "label2";
            label2.Size = new Size(407, 20);
            label2.TabIndex = 3;
            label2.Text = "ВВЕДИТЕ НОМЕР ВОПРОСА, КОТОРЫЙ ХОТИТЕ УДАЛИТЬ";
            // 
            // NumberDeleteTextBox
            // 
            NumberDeleteTextBox.Location = new Point(299, 381);
            NumberDeleteTextBox.Name = "NumberDeleteTextBox";
            NumberDeleteTextBox.Size = new Size(143, 27);
            NumberDeleteTextBox.TabIndex = 4;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(579, 381);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.RightToLeft = RightToLeft.No;
            DeleteButton.Size = new Size(136, 29);
            DeleteButton.TabIndex = 5;
            DeleteButton.Text = "ПОДТВЕРДИТЬ";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // DeleteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(753, 436);
            Controls.Add(DeleteButton);
            Controls.Add(NumberDeleteTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(BackButton);
            Name = "DeleteForm";
            Text = "DeleteForm";
            Load += DeleteForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BackButton;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn Question;
        private Label label1;
        private Label label2;
        private TextBox NumberDeleteTextBox;
        private Button DeleteButton;
    }
}
namespace GeniusAndIdiotWinFormsApp
{
    partial class deleteForm
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
            deleteDataGridView = new DataGridView();
            question = new DataGridViewTextBoxColumn();
            label1 = new Label();
            deletedquestionTextBox = new TextBox();
            label2 = new Label();
            deleteQuestionbutton1 = new Button();
            backButton = new Button();
            ((System.ComponentModel.ISupportInitialize)deleteDataGridView).BeginInit();
            SuspendLayout();
            // 
            // deleteDataGridView
            // 
            deleteDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            deleteDataGridView.Columns.AddRange(new DataGridViewColumn[] { question });
            deleteDataGridView.Location = new Point(3, 56);
            deleteDataGridView.Name = "deleteDataGridView";
            deleteDataGridView.RowHeadersWidth = 51;
            deleteDataGridView.Size = new Size(727, 196);
            deleteDataGridView.TabIndex = 0;
            deleteDataGridView.CellContentClick += dataGridView1_CellContentClick;
            // 
            // question
            // 
            question.HeaderText = "Вопрос";
            question.MinimumWidth = 6;
            question.Name = "question";
            question.ToolTipText = "опа";
            question.Width = 674;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(285, 20);
            label1.Name = "label1";
            label1.Size = new Size(191, 20);
            label1.TabIndex = 1;
            label1.Text = "СПИСОК ВСЕХ ВОПРОСОВ";
            // 
            // deletedquestionTextBox
            // 
            deletedquestionTextBox.Location = new Point(188, 336);
            deletedquestionTextBox.Name = "deletedquestionTextBox";
            deletedquestionTextBox.Size = new Size(354, 27);
            deletedquestionTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(118, 291);
            label2.Name = "label2";
            label2.Size = new Size(536, 20);
            label2.TabIndex = 3;
            label2.Text = "ВНИМАТЕЛЬНО ПЕРЕПИШИТЕ СЮДА ВОПРОС,КОТОРЫЙ ХОТИТЕ УДАЛИТЬ";
            // 
            // deleteQuestionbutton1
            // 
            deleteQuestionbutton1.Location = new Point(285, 379);
            deleteQuestionbutton1.Name = "deleteQuestionbutton1";
            deleteQuestionbutton1.Size = new Size(157, 29);
            deleteQuestionbutton1.TabIndex = 4;
            deleteQuestionbutton1.Text = "ПОДТВЕРДИТЬ";
            deleteQuestionbutton1.UseVisualStyleBackColor = true;
            deleteQuestionbutton1.Click += deleteQuestionbutton1_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(23, 11);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 5;
            backButton.Text = "НАЗАД";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // deleteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 429);
            Controls.Add(backButton);
            Controls.Add(deleteQuestionbutton1);
            Controls.Add(label2);
            Controls.Add(deletedquestionTextBox);
            Controls.Add(label1);
            Controls.Add(deleteDataGridView);
            Name = "deleteForm";
            Text = "deleteForm";
            Load += deleteForm_Load;
            ((System.ComponentModel.ISupportInitialize)deleteDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView deleteDataGridView;
        private Label label1;
        private TextBox deletedquestionTextBox;
        private DataGridViewTextBoxColumn question;
        private Label label2;
        private Button deleteQuestionbutton1;
        private Button backButton;
    }
}
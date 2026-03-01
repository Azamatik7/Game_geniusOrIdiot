namespace GeniusAndIdiotWinFormsApp
{
    partial class AddForm
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
            label1 = new Label();
            newQuestionTextBox = new TextBox();
            label2 = new Label();
            newAnswerTextBox = new TextBox();
            button1 = new Button();
            BackButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(130, 72);
            label1.Name = "label1";
            label1.Size = new Size(352, 20);
            label1.TabIndex = 0;
            label1.Text = "ВВЕДИТЕ ВОПРОС, КОТОРЫЙ ХОТИТЕ ДОБАВИТЬ";
            label1.Click += label1_Click;
            // 
            // newQuestionTextBox
            // 
            newQuestionTextBox.Location = new Point(149, 125);
            newQuestionTextBox.Margin = new Padding(3, 4, 3, 4);
            newQuestionTextBox.Name = "newQuestionTextBox";
            newQuestionTextBox.Size = new Size(283, 27);
            newQuestionTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(205, 217);
            label2.Name = "label2";
            label2.Size = new Size(178, 20);
            label2.TabIndex = 2;
            label2.Text = "ВВЕДИТЕ ОТВЕТ К НЕМУ";
            // 
            // newAnswerTextBox
            // 
            newAnswerTextBox.Location = new Point(149, 292);
            newAnswerTextBox.Margin = new Padding(3, 4, 3, 4);
            newAnswerTextBox.Name = "newAnswerTextBox";
            newAnswerTextBox.Size = new Size(283, 27);
            newAnswerTextBox.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(447, 392);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(132, 31);
            button1.TabIndex = 4;
            button1.Text = "ПОДТВЕРДИТЬ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // BackButton
            // 
            BackButton.Location = new Point(12, 27);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(94, 29);
            BackButton.TabIndex = 5;
            BackButton.Text = "НАЗАД";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(611, 467);
            Controls.Add(BackButton);
            Controls.Add(button1);
            Controls.Add(newAnswerTextBox);
            Controls.Add(label2);
            Controls.Add(newQuestionTextBox);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddForm";
            Text = "AddForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox newQuestionTextBox;
        private Label label2;
        private TextBox newAnswerTextBox;
        private Button button1;
        private Button BackButton;
    }
}
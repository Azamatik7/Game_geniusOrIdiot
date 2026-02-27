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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(114, 54);
            label1.Name = "label1";
            label1.Size = new Size(280, 15);
            label1.TabIndex = 0;
            label1.Text = "ВВЕДИТЕ ВОПРОС, КОТОРЫЙ ХОТИТЕ ДОБАВИТЬ";
            label1.Click += label1_Click;
            // 
            // newQuestionTextBox
            // 
            newQuestionTextBox.Location = new Point(130, 94);
            newQuestionTextBox.Name = "newQuestionTextBox";
            newQuestionTextBox.Size = new Size(248, 23);
            newQuestionTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(179, 163);
            label2.Name = "label2";
            label2.Size = new Size(139, 15);
            label2.TabIndex = 2;
            label2.Text = "ВВЕДИТЕ ОТВЕТ К НЕМУ";
            // 
            // newAnswerTextBox
            // 
            newAnswerTextBox.Location = new Point(130, 219);
            newAnswerTextBox.Name = "newAnswerTextBox";
            newAnswerTextBox.Size = new Size(248, 23);
            newAnswerTextBox.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(391, 294);
            button1.Name = "button1";
            button1.Size = new Size(103, 23);
            button1.TabIndex = 4;
            button1.Text = "ПОДТВЕРДИТЬ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 350);
            Controls.Add(button1);
            Controls.Add(newAnswerTextBox);
            Controls.Add(label2);
            Controls.Add(newQuestionTextBox);
            Controls.Add(label1);
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
    }
}
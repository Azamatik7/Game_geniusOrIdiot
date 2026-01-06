namespace GeniusAndIdiotWinFormsApp
{
    partial class AddQuestionForm
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
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            BackButton = new Button();
            AddButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 77);
            label1.Name = "label1";
            label1.Size = new Size(349, 40);
            label1.TabIndex = 0;
            label1.Text = "ВВЕДИТЕ ВОПРОС КОТОРЫЙ ХОТИТЕ ДОБАВИТЬ\r\n\r\n";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(115, 120);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(239, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 187);
            label2.Name = "label2";
            label2.Size = new Size(272, 20);
            label2.TabIndex = 2;
            label2.Text = "ВВЕДИТЕ ОТВЕТ К ВАШЕМУ ВОПРОСУ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(115, 245);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(239, 27);
            textBox2.TabIndex = 3;
            // 
            // BackButton
            // 
            BackButton.Location = new Point(12, 12);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(79, 29);
            BackButton.TabIndex = 4;
            BackButton.Text = "НАЗАД";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(377, 280);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(94, 29);
            AddButton.TabIndex = 5;
            AddButton.Text = "ДОБАВИТЬ";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // AddQuestionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 321);
            Controls.Add(AddButton);
            Controls.Add(BackButton);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "AddQuestionForm";
            Text = "AddQuestionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Button BackButton;
        private Button AddButton;
    }
}
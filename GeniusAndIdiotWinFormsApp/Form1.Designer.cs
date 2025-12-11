namespace GeniusAndIdiotWinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            questionNumberlabel = new Label();
            userAnswerTextBox = new TextBox();
            Submitbutton = new Button();
            questionLabel = new Label();
            SuspendLayout();
            // 
            // questionNumberlabel
            // 
            questionNumberlabel.AutoSize = true;
            questionNumberlabel.Font = new Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            questionNumberlabel.Location = new Point(93, 21);
            questionNumberlabel.Name = "questionNumberlabel";
            questionNumberlabel.Size = new Size(82, 20);
            questionNumberlabel.TabIndex = 0;
            questionNumberlabel.Text = "Вопрос 1";
            // 
            // userAnswerTextBox
            // 
            userAnswerTextBox.Location = new Point(52, 145);
            userAnswerTextBox.Name = "userAnswerTextBox";
            userAnswerTextBox.Size = new Size(177, 23);
            userAnswerTextBox.TabIndex = 1;
            // 
            // Submitbutton
            // 
            Submitbutton.Location = new Point(77, 199);
            Submitbutton.Name = "Submitbutton";
            Submitbutton.Size = new Size(120, 47);
            Submitbutton.TabIndex = 2;
            Submitbutton.Text = "ОТВЕТИТЬ";
            Submitbutton.UseVisualStyleBackColor = true;
            Submitbutton.Click += Submitbutton_Click;
            // 
            // questionLabel
            // 
            questionLabel.AutoEllipsis = true;
            questionLabel.AutoSize = true;
            questionLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            questionLabel.Location = new Point(61, 54);
            questionLabel.MaximumSize = new Size(200, 0);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new Size(70, 21);
            questionLabel.TabIndex = 3;
            questionLabel.Text = "question";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 348);
            Controls.Add(questionLabel);
            Controls.Add(Submitbutton);
            Controls.Add(userAnswerTextBox);
            Controls.Add(questionNumberlabel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label questionNumberlabel;
        private TextBox userAnswerTextBox;
        private Button Submitbutton;
        private Label questionLabel;
    }
}

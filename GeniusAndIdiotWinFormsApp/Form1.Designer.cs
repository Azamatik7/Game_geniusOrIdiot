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
            questionNumberlabel.Location = new Point(131, 25);
            questionNumberlabel.Name = "questionNumberlabel";
            questionNumberlabel.Size = new Size(100, 23);
            questionNumberlabel.TabIndex = 0;
            questionNumberlabel.Text = "Вопрос 1";
            // 
            // userAnswerTextBox
            // 
            userAnswerTextBox.Location = new Point(70, 222);
            userAnswerTextBox.Margin = new Padding(3, 4, 3, 4);
            userAnswerTextBox.Name = "userAnswerTextBox";
            userAnswerTextBox.Size = new Size(202, 27);
            userAnswerTextBox.TabIndex = 1;
            // 
            // Submitbutton
            // 
            Submitbutton.Location = new Point(94, 305);
            Submitbutton.Margin = new Padding(3, 4, 3, 4);
            Submitbutton.Name = "Submitbutton";
            Submitbutton.Size = new Size(137, 63);
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
            questionLabel.Location = new Point(70, 79);
            questionLabel.MaximumSize = new Size(229, 0);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new Size(88, 28);
            questionLabel.TabIndex = 3;
            questionLabel.Text = "question";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 458);
            Controls.Add(questionLabel);
            Controls.Add(Submitbutton);
            Controls.Add(userAnswerTextBox);
            Controls.Add(questionNumberlabel);
            Margin = new Padding(3, 4, 3, 4);
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

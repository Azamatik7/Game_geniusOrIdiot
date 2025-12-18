namespace GeniusAndIdiotWinFormsApp
{
    partial class ChoiceForm
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
            choiceActionLabel = new Label();
            playButton = new Button();
            recordsButton = new Button();
            addQuestionbutton = new Button();
            deleteButton = new Button();
            SuspendLayout();
            // 
            // choiceActionLabel
            // 
            choiceActionLabel.AutoSize = true;
            choiceActionLabel.Location = new Point(99, 46);
            choiceActionLabel.Name = "choiceActionLabel";
            choiceActionLabel.Size = new Size(126, 15);
            choiceActionLabel.TabIndex = 0;
            choiceActionLabel.Text = "ВЫБЕРИТЕ ДЕЙСТВИЕ";
            // 
            // playButton
            // 
            playButton.Location = new Point(115, 86);
            playButton.Name = "playButton";
            playButton.Size = new Size(84, 32);
            playButton.TabIndex = 1;
            playButton.Text = "ИГРАТЬ";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += playButton_Click;
            // 
            // recordsButton
            // 
            recordsButton.Location = new Point(115, 135);
            recordsButton.Name = "recordsButton";
            recordsButton.Size = new Size(84, 32);
            recordsButton.TabIndex = 2;
            recordsButton.Text = "РЕКОРДЫ";
            recordsButton.UseVisualStyleBackColor = true;
            // 
            // addQuestionbutton
            // 
            addQuestionbutton.Location = new Point(115, 186);
            addQuestionbutton.Name = "addQuestionbutton";
            addQuestionbutton.Size = new Size(84, 32);
            addQuestionbutton.TabIndex = 3;
            addQuestionbutton.Text = "ДОБАВИТЬ";
            addQuestionbutton.UseVisualStyleBackColor = true;
            addQuestionbutton.Click += button1_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(115, 234);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(84, 32);
            deleteButton.TabIndex = 4;
            deleteButton.Text = "УБРАТЬ";
            deleteButton.UseVisualStyleBackColor = true;
            // 
            // ChoiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 287);
            Controls.Add(deleteButton);
            Controls.Add(addQuestionbutton);
            Controls.Add(recordsButton);
            Controls.Add(playButton);
            Controls.Add(choiceActionLabel);
            Name = "ChoiceForm";
            Text = "ChoiceForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label choiceActionLabel;
        private Button playButton;
        private Button recordsButton;
        private Button addQuestionbutton;
        private Button deleteButton;
    }
}
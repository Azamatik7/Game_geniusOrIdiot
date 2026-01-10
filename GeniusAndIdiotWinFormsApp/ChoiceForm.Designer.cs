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
            choiceActionLabel.Location = new Point(113, 61);
            choiceActionLabel.Name = "choiceActionLabel";
            choiceActionLabel.Size = new Size(160, 20);
            choiceActionLabel.TabIndex = 0;
            choiceActionLabel.Text = "ВЫБЕРИТЕ ДЕЙСТВИЕ";
            // 
            // playButton
            // 
            playButton.Location = new Point(131, 115);
            playButton.Margin = new Padding(3, 4, 3, 4);
            playButton.Name = "playButton";
            playButton.Size = new Size(96, 43);
            playButton.TabIndex = 1;
            playButton.Text = "ИГРАТЬ";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += playButton_Click;
            // 
            // recordsButton
            // 
            recordsButton.Location = new Point(131, 180);
            recordsButton.Margin = new Padding(3, 4, 3, 4);
            recordsButton.Name = "recordsButton";
            recordsButton.Size = new Size(96, 43);
            recordsButton.TabIndex = 2;
            recordsButton.Text = "РЕКОРДЫ";
            recordsButton.UseVisualStyleBackColor = true;
            recordsButton.Click += recordsButton_Click;
            // 
            // addQuestionbutton
            // 
            addQuestionbutton.Location = new Point(131, 248);
            addQuestionbutton.Margin = new Padding(3, 4, 3, 4);
            addQuestionbutton.Name = "addQuestionbutton";
            addQuestionbutton.Size = new Size(96, 43);
            addQuestionbutton.TabIndex = 3;
            addQuestionbutton.Text = "ДОБАВИТЬ";
            addQuestionbutton.UseVisualStyleBackColor = true;
            addQuestionbutton.Click += button1_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(131, 312);
            deleteButton.Margin = new Padding(3, 4, 3, 4);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(96, 43);
            deleteButton.TabIndex = 4;
            deleteButton.Text = "УБРАТЬ";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click_1;
            // 
            // ChoiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(381, 383);
            Controls.Add(deleteButton);
            Controls.Add(addQuestionbutton);
            Controls.Add(recordsButton);
            Controls.Add(playButton);
            Controls.Add(choiceActionLabel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ChoiceForm";
            Text = "ChoiceForm";
            Load += ChoiceForm_Load;
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
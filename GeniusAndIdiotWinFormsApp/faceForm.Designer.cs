namespace GeniusAndIdiotWinFormsApp
{
    partial class faceForm
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
            greetingLabel = new Label();
            nameLabel = new Label();
            userNameTextBox = new TextBox();
            acceptButton = new Button();
            SuspendLayout();
            // 
            // greetingLabel
            // 
            greetingLabel.AutoSize = true;
            greetingLabel.Location = new Point(103, 47);
            greetingLabel.Name = "greetingLabel";
            greetingLabel.Size = new Size(234, 15);
            greetingLabel.TabIndex = 1;
            greetingLabel.Text = "Добро пожаловать в Игру Гений и Идиот";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(154, 91);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(111, 15);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Введите Ваше имя:";
            nameLabel.Click += nameLabel_Click;
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(154, 132);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(111, 23);
            userNameTextBox.TabIndex = 3;
            userNameTextBox.TextChanged += userNameTextBox_TextChanged;
            // 
            // acceptButton
            // 
            acceptButton.Location = new Point(154, 183);
            acceptButton.Name = "acceptButton";
            acceptButton.Size = new Size(111, 28);
            acceptButton.TabIndex = 4;
            acceptButton.Text = "ПОДТВЕРДИТЬ";
            acceptButton.UseVisualStyleBackColor = true;
            acceptButton.Click += acceptButton_Click;
            // 
            // faceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 262);
            Controls.Add(acceptButton);
            Controls.Add(userNameTextBox);
            Controls.Add(nameLabel);
            Controls.Add(greetingLabel);
            Name = "faceForm";
            Text = "faceForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label greetingLabel;
        private Label nameLabel;
        private TextBox userNameTextBox;
        private Button acceptButton;
    }
}
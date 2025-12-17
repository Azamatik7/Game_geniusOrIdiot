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
            greetingLabel.Location = new Point(118, 63);
            greetingLabel.Name = "greetingLabel";
            greetingLabel.Size = new Size(298, 20);
            greetingLabel.TabIndex = 1;
            greetingLabel.Text = "Добро пожаловать в Игру Гений и Идиот";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(176, 121);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(141, 20);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Введите Ваше имя:";
            nameLabel.Click += nameLabel_Click;
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(176, 176);
            userNameTextBox.Margin = new Padding(3, 4, 3, 4);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(126, 27);
            userNameTextBox.TabIndex = 3;
            // 
            // acceptButton
            // 
            acceptButton.Location = new Point(176, 244);
            acceptButton.Margin = new Padding(3, 4, 3, 4);
            acceptButton.Name = "acceptButton";
            acceptButton.Size = new Size(127, 37);
            acceptButton.TabIndex = 4;
            acceptButton.Text = "ПОДТВЕРДИТЬ";
            acceptButton.UseVisualStyleBackColor = true;
            acceptButton.Click += acceptButton_Click;
            // 
            // faceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 349);
            Controls.Add(acceptButton);
            Controls.Add(userNameTextBox);
            Controls.Add(nameLabel);
            Controls.Add(greetingLabel);
            Margin = new Padding(3, 4, 3, 4);
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
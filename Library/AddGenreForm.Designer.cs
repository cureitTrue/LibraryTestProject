namespace Library
{
    partial class AddGenreForm
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
            bookGenreTextBox = new TextBox();
            okButton = new Button();
            bookGenreLabel = new Label();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // bookGenreTextBox
            // 
            bookGenreTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bookGenreTextBox.Location = new Point(147, 7);
            bookGenreTextBox.Name = "bookGenreTextBox";
            bookGenreTextBox.Size = new Size(280, 27);
            bookGenreTextBox.TabIndex = 0;
            // 
            // okButton
            // 
            okButton.Location = new Point(12, 45);
            okButton.Name = "okButton";
            okButton.Size = new Size(204, 31);
            okButton.TabIndex = 1;
            okButton.Text = "Добавить";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += OnOkButtonClick;
            // 
            // bookGenreLabel
            // 
            bookGenreLabel.AutoSize = true;
            bookGenreLabel.Location = new Point(12, 10);
            bookGenreLabel.Name = "bookGenreLabel";
            bookGenreLabel.Size = new Size(129, 20);
            bookGenreLabel.TabIndex = 3;
            bookGenreLabel.Text = "Название жанра:";
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cancelButton.Location = new Point(223, 45);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(204, 31);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += OnCancelButtonClick;
            // 
            // AddGenreForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 88);
            Controls.Add(cancelButton);
            Controls.Add(bookGenreLabel);
            Controls.Add(okButton);
            Controls.Add(bookGenreTextBox);
            Name = "AddGenreForm";
            Text = "Добавить жанр";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox bookGenreTextBox;
        private Button okButton;
        private Label bookGenreLabel;
        private Button cancelButton;
    }
}
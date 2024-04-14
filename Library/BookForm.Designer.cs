namespace Library
{
    partial class BookForm
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
            okButton = new Button();
            bookNameTextBox = new TextBox();
            bookGenreComboBox = new ComboBox();
            bookAuthorTextBox = new TextBox();
            bookDescTextBox = new TextBox();
            bookNameLabel = new Label();
            bookAuthorLabel = new Label();
            bookGenreLabel = new Label();
            bookDescLabel = new Label();
            addBookGenreButton = new Button();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            okButton.Location = new Point(12, 165);
            okButton.Name = "okButton";
            okButton.Size = new Size(556, 29);
            okButton.TabIndex = 6;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += OnOkButtonClick;
            // 
            // bookNameTextBox
            // 
            bookNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bookNameTextBox.Location = new Point(100, 7);
            bookNameTextBox.Name = "bookNameTextBox";
            bookNameTextBox.Size = new Size(468, 27);
            bookNameTextBox.TabIndex = 0;
            // 
            // bookGenreComboBox
            // 
            bookGenreComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bookGenreComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            bookGenreComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            bookGenreComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            bookGenreComboBox.FormattingEnabled = true;
            bookGenreComboBox.Location = new Point(100, 127);
            bookGenreComboBox.MaxDropDownItems = 30;
            bookGenreComboBox.Name = "bookGenreComboBox";
            bookGenreComboBox.Size = new Size(434, 28);
            bookGenreComboBox.TabIndex = 2;
            // 
            // bookAuthorTextBox
            // 
            bookAuthorTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bookAuthorTextBox.Location = new Point(100, 47);
            bookAuthorTextBox.Name = "bookAuthorTextBox";
            bookAuthorTextBox.Size = new Size(468, 27);
            bookAuthorTextBox.TabIndex = 1;
            // 
            // bookDescTextBox
            // 
            bookDescTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bookDescTextBox.Location = new Point(100, 87);
            bookDescTextBox.Name = "bookDescTextBox";
            bookDescTextBox.Size = new Size(468, 27);
            bookDescTextBox.TabIndex = 4;
            // 
            // bookNameLabel
            // 
            bookNameLabel.AutoSize = true;
            bookNameLabel.Location = new Point(12, 10);
            bookNameLabel.Name = "bookNameLabel";
            bookNameLabel.Size = new Size(80, 20);
            bookNameLabel.TabIndex = 7;
            bookNameLabel.Text = "Название:";
            // 
            // bookAuthorLabel
            // 
            bookAuthorLabel.AutoSize = true;
            bookAuthorLabel.Location = new Point(12, 50);
            bookAuthorLabel.Name = "bookAuthorLabel";
            bookAuthorLabel.Size = new Size(54, 20);
            bookAuthorLabel.TabIndex = 8;
            bookAuthorLabel.Text = "Автор:";
            // 
            // bookGenreLabel
            // 
            bookGenreLabel.AutoSize = true;
            bookGenreLabel.Location = new Point(12, 130);
            bookGenreLabel.Name = "bookGenreLabel";
            bookGenreLabel.Size = new Size(51, 20);
            bookGenreLabel.TabIndex = 9;
            bookGenreLabel.Text = "Жанр:";
            // 
            // bookDescLabel
            // 
            bookDescLabel.AutoSize = true;
            bookDescLabel.Location = new Point(12, 90);
            bookDescLabel.Name = "bookDescLabel";
            bookDescLabel.Size = new Size(82, 20);
            bookDescLabel.TabIndex = 10;
            bookDescLabel.Text = "Описание:";
            // 
            // addBookGenreButton
            // 
            addBookGenreButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addBookGenreButton.Image = Properties.Resources.plus;
            addBookGenreButton.Location = new Point(540, 127);
            addBookGenreButton.Name = "addBookGenreButton";
            addBookGenreButton.Size = new Size(28, 28);
            addBookGenreButton.TabIndex = 3;
            addBookGenreButton.UseVisualStyleBackColor = true;
            addBookGenreButton.Click += OnAddBookGenreButtonClick;
            // 
            // BookForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 205);
            Controls.Add(addBookGenreButton);
            Controls.Add(bookDescLabel);
            Controls.Add(bookGenreLabel);
            Controls.Add(bookAuthorLabel);
            Controls.Add(bookNameLabel);
            Controls.Add(bookDescTextBox);
            Controls.Add(bookAuthorTextBox);
            Controls.Add(bookGenreComboBox);
            Controls.Add(bookNameTextBox);
            Controls.Add(okButton);
            Name = "BookForm";
            Text = "Книга";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button okButton;
        private TextBox bookNameTextBox;
        private ComboBox bookGenreComboBox;
        private TextBox bookAuthorTextBox;
        private TextBox bookDescTextBox;
        private Label bookNameLabel;
        private Label bookAuthorLabel;
        private Label bookGenreLabel;
        private Label bookDescLabel;
        private Button addBookGenreButton;
    }
}
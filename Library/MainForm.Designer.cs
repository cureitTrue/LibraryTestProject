namespace Library
{
    partial class MainForm
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            myLibraryBookAuthorSearchLabel = new Label();
            myLibraryBookAuthorSearchTextBox = new TextBox();
            myLibrarySearchButton = new Button();
            myLibraryDataGridView = new DataGridView();
            myLibraryBookNameColumn = new DataGridViewTextBoxColumn();
            myLibraryBookAuthorColumn = new DataGridViewTextBoxColumn();
            myLibraryBookGenreColumn = new DataGridViewTextBoxColumn();
            myLibraryBookGenreSearchLabel = new Label();
            myLibraryBookNameSearchLabel = new Label();
            myLibraryBookGenreSearchComboBox = new ComboBox();
            myLibraryBookNameSearchTextBox = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)myLibraryDataGridView).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(807, 452);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(myLibraryBookAuthorSearchLabel);
            tabPage1.Controls.Add(myLibraryBookAuthorSearchTextBox);
            tabPage1.Controls.Add(myLibrarySearchButton);
            tabPage1.Controls.Add(myLibraryDataGridView);
            tabPage1.Controls.Add(myLibraryBookGenreSearchLabel);
            tabPage1.Controls.Add(myLibraryBookNameSearchLabel);
            tabPage1.Controls.Add(myLibraryBookGenreSearchComboBox);
            tabPage1.Controls.Add(myLibraryBookNameSearchTextBox);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(799, 419);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Моя библиотека";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // myLibraryBookAuthorSearchLabel
            // 
            myLibraryBookAuthorSearchLabel.AutoSize = true;
            myLibraryBookAuthorSearchLabel.Location = new Point(254, 8);
            myLibraryBookAuthorSearchLabel.Name = "myLibraryBookAuthorSearchLabel";
            myLibraryBookAuthorSearchLabel.Size = new Size(98, 20);
            myLibraryBookAuthorSearchLabel.TabIndex = 7;
            myLibraryBookAuthorSearchLabel.Text = "Автор книги:";
            // 
            // myLibraryBookAuthorSearchTextBox
            // 
            myLibraryBookAuthorSearchTextBox.Location = new Point(254, 32);
            myLibraryBookAuthorSearchTextBox.Name = "myLibraryBookAuthorSearchTextBox";
            myLibraryBookAuthorSearchTextBox.Size = new Size(200, 27);
            myLibraryBookAuthorSearchTextBox.TabIndex = 2;
            // 
            // myLibrarySearchButton
            // 
            myLibrarySearchButton.Location = new Point(666, 30);
            myLibrarySearchButton.Name = "myLibrarySearchButton";
            myLibrarySearchButton.Size = new Size(125, 29);
            myLibrarySearchButton.TabIndex = 4;
            myLibrarySearchButton.Text = "Поиск";
            myLibrarySearchButton.UseVisualStyleBackColor = true;
            myLibrarySearchButton.Click += OnMyLibrarySearchButtonClick;
            // 
            // myLibraryDataGridView
            // 
            myLibraryDataGridView.AllowUserToAddRows = false;
            myLibraryDataGridView.AllowUserToDeleteRows = false;
            myLibraryDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            myLibraryDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            myLibraryDataGridView.Columns.AddRange(new DataGridViewColumn[] { myLibraryBookNameColumn, myLibraryBookAuthorColumn, myLibraryBookGenreColumn });
            myLibraryDataGridView.Location = new Point(8, 65);
            myLibraryDataGridView.MultiSelect = false;
            myLibraryDataGridView.Name = "myLibraryDataGridView";
            myLibraryDataGridView.ReadOnly = true;
            myLibraryDataGridView.RowHeadersVisible = false;
            myLibraryDataGridView.RowHeadersWidth = 51;
            myLibraryDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            myLibraryDataGridView.Size = new Size(783, 348);
            myLibraryDataGridView.TabIndex = 5;
            myLibraryDataGridView.MouseClick += OnMyLibraryDataGridViewMouseClick;
            myLibraryDataGridView.MouseDoubleClick += OnMyLibraryDataGridViewMouseDoubleClick;
            // 
            // myLibraryBookNameColumn
            // 
            myLibraryBookNameColumn.HeaderText = "Название";
            myLibraryBookNameColumn.MinimumWidth = 6;
            myLibraryBookNameColumn.Name = "myLibraryBookNameColumn";
            myLibraryBookNameColumn.ReadOnly = true;
            myLibraryBookNameColumn.Width = 240;
            // 
            // myLibraryBookAuthorColumn
            // 
            myLibraryBookAuthorColumn.HeaderText = "Автор";
            myLibraryBookAuthorColumn.MinimumWidth = 6;
            myLibraryBookAuthorColumn.Name = "myLibraryBookAuthorColumn";
            myLibraryBookAuthorColumn.ReadOnly = true;
            myLibraryBookAuthorColumn.Width = 205;
            // 
            // myLibraryBookGenreColumn
            // 
            myLibraryBookGenreColumn.HeaderText = "Жанр";
            myLibraryBookGenreColumn.MinimumWidth = 6;
            myLibraryBookGenreColumn.Name = "myLibraryBookGenreColumn";
            myLibraryBookGenreColumn.ReadOnly = true;
            myLibraryBookGenreColumn.Width = 210;
            // 
            // myLibraryBookGenreSearchLabel
            // 
            myLibraryBookGenreSearchLabel.AutoSize = true;
            myLibraryBookGenreSearchLabel.Location = new Point(460, 8);
            myLibraryBookGenreSearchLabel.Name = "myLibraryBookGenreSearchLabel";
            myLibraryBookGenreSearchLabel.Size = new Size(95, 20);
            myLibraryBookGenreSearchLabel.TabIndex = 8;
            myLibraryBookGenreSearchLabel.Text = "Жанр книги:";
            // 
            // myLibraryBookNameSearchLabel
            // 
            myLibraryBookNameSearchLabel.AutoSize = true;
            myLibraryBookNameSearchLabel.Location = new Point(8, 8);
            myLibraryBookNameSearchLabel.Name = "myLibraryBookNameSearchLabel";
            myLibraryBookNameSearchLabel.Size = new Size(170, 20);
            myLibraryBookNameSearchLabel.TabIndex = 6;
            myLibraryBookNameSearchLabel.Text = "Название книги/автор:";
            // 
            // myLibraryBookGenreSearchComboBox
            // 
            myLibraryBookGenreSearchComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            myLibraryBookGenreSearchComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            myLibraryBookGenreSearchComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            myLibraryBookGenreSearchComboBox.FormattingEnabled = true;
            myLibraryBookGenreSearchComboBox.Location = new Point(460, 31);
            myLibraryBookGenreSearchComboBox.MaxDropDownItems = 30;
            myLibraryBookGenreSearchComboBox.Name = "myLibraryBookGenreSearchComboBox";
            myLibraryBookGenreSearchComboBox.Size = new Size(200, 28);
            myLibraryBookGenreSearchComboBox.TabIndex = 3;
            // 
            // myLibraryBookNameSearchTextBox
            // 
            myLibraryBookNameSearchTextBox.Location = new Point(8, 32);
            myLibraryBookNameSearchTextBox.Name = "myLibraryBookNameSearchTextBox";
            myLibraryBookNameSearchTextBox.Size = new Size(240, 27);
            myLibraryBookNameSearchTextBox.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 452);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "Библиотека";
            Load += OnMainFormLoad;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)myLibraryDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label myLibraryBookGenreSearchLabel;
        private Label myLibraryBookNameSearchLabel;
        private ComboBox myLibraryBookGenreSearchComboBox;
        private TextBox myLibraryBookNameSearchTextBox;
        private DataGridView myLibraryDataGridView;
        private Button myLibrarySearchButton;
        private TextBox myLibraryBookAuthorSearchTextBox;
        private Label myLibraryBookAuthorSearchLabel;
        private DataGridViewTextBoxColumn myLibraryBookNameColumn;
        private DataGridViewTextBoxColumn myLibraryBookAuthorColumn;
        private DataGridViewTextBoxColumn myLibraryBookGenreColumn;
    }
}

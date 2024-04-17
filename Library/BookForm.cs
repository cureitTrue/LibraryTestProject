using Library.Models;

namespace Library
{
    public partial class BookForm : Form
    {
        private bool _createNewBook = false;

        public BookForm()
        {
            InitializeComponent();
        }

        public void ShowForm(string title, string okText, BookData book)
        {
            Text = title;
            okButton.Text = okText;
            _createNewBook = false;

            bookNameTextBox.ReadOnly = true;
            bookAuthorTextBox.ReadOnly = true;
            bookDescTextBox.ReadOnly = true;
            addBookGenreButton.Enabled = false;

            bookNameTextBox.Text = book.Name;
            bookAuthorTextBox.Text = book.Author;
            bookDescTextBox.Text = book.Desc;
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                bookGenreComboBox.Items.Clear();
                bookGenreComboBox.Items.Add(dbContext.Find<GenreData>(book.GenreId));
                bookGenreComboBox.SelectedIndex = 0;
            }

            ShowDialog();
        }

        public void ShowForm(string title, string okText)
        {
            Text = title;
            okButton.Text = okText;
            _createNewBook = true;

            bookGenreComboBox.Items.Clear();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                foreach (GenreData genre in dbContext.Genres.OrderBy(x => x.GenreStr))
                {
                    if (string.IsNullOrWhiteSpace(genre.GenreStr))
                    {
                        continue;
                    }
                    bookGenreComboBox.Items.Add(genre);
                }
            }
            bookGenreComboBox.SelectedIndex = 0;

            ShowDialog();
        }

        private void OnOkButtonClick(object sender, EventArgs e)
        {
            if (_createNewBook)
            {
                if (string.IsNullOrWhiteSpace(bookNameTextBox.Text) ||
                   string.IsNullOrWhiteSpace(bookAuthorTextBox.Text) ||
                   string.IsNullOrWhiteSpace(bookDescTextBox.Text) ||
                   string.IsNullOrWhiteSpace(bookGenreComboBox.Text))
                {
                    MessageBox.Show("Сначала заполните все поля!");
                    return;
                }

                using (DatabaseContext dbContext = new DatabaseContext())
                {
                    Random rnd = new Random();
                    string localId = rnd.Next(10).ToString();
                    while (dbContext.Books.Any(x => x.LocalId == localId))
                    {
                        localId = rnd.Next(10).ToString();
                    }

                    dbContext.Books.Add(new BookData()
                    {
                        Name = bookNameTextBox.Text,
                        Author = bookAuthorTextBox.Text,
                        Desc = bookDescTextBox.Text,
                        GenreId = ((GenreData)bookGenreComboBox.SelectedItem).Id,
                        LocalId = localId
                    });
                    dbContext.SaveChanges();
                }
            }
            Close();
        }

        private void OnAddBookGenreButtonClick(object sender, EventArgs e)
        {
            AddGenreForm addGenreForm = new AddGenreForm();
            addGenreForm.ShowForm();

            bookGenreComboBox.Items.Clear();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                foreach (GenreData genre in dbContext.Genres.OrderBy(x => x.GenreStr))
                {
                    if (string.IsNullOrWhiteSpace(genre.GenreStr))
                    {
                        continue;
                    }
                    bookGenreComboBox.Items.Add(genre);
                }
            }
            bookGenreComboBox.SelectedIndex = 0;
        }
    }
}
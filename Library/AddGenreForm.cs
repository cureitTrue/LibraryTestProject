using Library.Models;

namespace Library
{
    public partial class AddGenreForm : Form
    {
        public AddGenreForm()
        {
            InitializeComponent();
        }

        public void ShowForm()
        {
            ShowDialog();
        }

        private void OnOkButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(bookGenreTextBox.Text))
            {
                MessageBox.Show("Введите название жанра, который хотите добавить");
                return;
            }

            using (DatabaseContext dbContext = new DatabaseContext())
            {
                dbContext.Genres.Add(new GenreData()
                {
                    GenreStr = bookGenreTextBox.Text
                });
                dbContext.SaveChanges();
            }
            Close();
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
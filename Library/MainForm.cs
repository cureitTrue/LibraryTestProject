using Library.Models;

namespace Library
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                if (dbContext.Genres.Count() == 0)
                {
                    GenreData[] genres =
                    [
                        new GenreData { GenreStr = "Военное дело" },
                        new GenreData { GenreStr = "Деловая литература" },
                        new GenreData { GenreStr = "Детективы и Триллеры" },
                        new GenreData { GenreStr = "Детское" },
                        new GenreData { GenreStr = "Документальная литература" },
                        new GenreData { GenreStr = "Домоводство (Дом и семья)" },
                        new GenreData { GenreStr = "Драматургия" },
                        new GenreData { GenreStr = "Компьютеры и Интернет" },
                        new GenreData { GenreStr = "Любовные романы" },
                        new GenreData { GenreStr = "Наука, Образование" },
                        new GenreData { GenreStr = "Поэзия" },
                        new GenreData { GenreStr = "Приключения" },
                        new GenreData { GenreStr = "Проза" },
                        new GenreData { GenreStr = "Прочее" },
                        new GenreData { GenreStr = "Религия и духовность" },
                        new GenreData { GenreStr = "Справочная литература" },
                        new GenreData { GenreStr = "Старинное" },
                        new GenreData { GenreStr = "Техника" },
                        new GenreData { GenreStr = "Фантастика" },
                        new GenreData { GenreStr = "Фольклор" },
                        new GenreData { GenreStr = "Юмор" }
                    ];
                    dbContext.Genres.AddRange(genres);
                    dbContext.SaveChanges();
                }

                myLibraryDataGridView.ClearSelection();
                myLibraryDataGridView.Rows.Clear();
                foreach (BookData bookData in dbContext.Books.OrderBy(x => x.Name))
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(myLibraryDataGridView);
                    int index = myLibraryDataGridView.Rows.Add(row);
                    row = myLibraryDataGridView.Rows[index];

                    if (row != null)
                    {
                        row.Tag = bookData.LocalId;

                        DataGridViewCell myLibraryBookNameCell = row.Cells["myLibraryBookNameColumn"];
                        DataGridViewCell myLibraryBookAuthorCell = row.Cells["myLibraryBookAuthorColumn"];
                        DataGridViewCell myLibraryBookGenreCell = row.Cells["myLibraryBookGenreColumn"];

                        myLibraryBookNameCell.Value = bookData.Name;
                        myLibraryBookAuthorCell.Value = bookData.Author;
                        myLibraryBookGenreCell.Value = dbContext.Find<GenreData>(bookData.GenreId).GenreStr;
                    }
                }

                genresDataGridView.ClearSelection();
                genresDataGridView.Rows.Clear();
                foreach (GenreData genreData in dbContext.Genres.OrderBy(x => x.GenreStr))
                {
                    if (string.IsNullOrWhiteSpace(genreData.GenreStr))
                    {
                        continue;
                    }

                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(genresDataGridView);
                    int index = genresDataGridView.Rows.Add(row);
                    row = genresDataGridView.Rows[index];

                    if (row != null)
                    {
                        row.Tag = genreData.Id;

                        DataGridViewCell genreCell = row.Cells["genreColumn"];
                        genreCell.Value = genreData.GenreStr;
                    }
                }

                myLibraryBookGenreSearchComboBox.Items.Clear();
                myLibraryBookGenreSearchComboBox.Items.Add("Не выбран");
                foreach (GenreData genre in dbContext.Genres.OrderBy(x => x.GenreStr))
                {
                    if (string.IsNullOrWhiteSpace(genre.GenreStr))
                    {
                        continue;
                    }
                    myLibraryBookGenreSearchComboBox.Items.Add(genre);
                }
                myLibraryBookGenreSearchComboBox.SelectedIndex = 0;
            }
        }

        private void OnGenresDataGridViewMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridViewRow selectedRow = null;
                DataGridView.HitTestInfo hitTestInfo = genresDataGridView.HitTest(e.X, e.Y);
                int rowIndex = hitTestInfo.RowIndex;
                int columnIndex = hitTestInfo.ColumnIndex;

                if (rowIndex >= 0)
                {
                    selectedRow = genresDataGridView.Rows[rowIndex];
                }

                if (selectedRow != null)
                {
                    selectedRow.Selected = true;
                }

                ContextMenuStrip m = new ContextMenuStrip();
                m.Items.Add("Добавить", null, delegate (object s, EventArgs args)
                {
                    DisableControls(tabPage2);
                    try
                    {
                        AddGenreForm addGenreForm = new AddGenreForm();
                        addGenreForm.ShowForm();

                        Invoke(new Action(() =>
                        {
                            genresDataGridView.ClearSelection();
                            genresDataGridView.Rows.Clear();

                            using (DatabaseContext dbContext = new DatabaseContext())
                            {
                                foreach (GenreData genreData in dbContext.Genres.OrderBy(x => x.GenreStr))
                                {
                                    if (string.IsNullOrWhiteSpace(genreData.GenreStr))
                                    {
                                        continue;
                                    }

                                    DataGridViewRow row = new DataGridViewRow();
                                    row.CreateCells(genresDataGridView);
                                    int index = genresDataGridView.Rows.Add(row);
                                    row = genresDataGridView.Rows[index];

                                    if (row != null)
                                    {
                                        row.Tag = genreData.Id;

                                        DataGridViewCell genreCell = row.Cells["genreColumn"];
                                        genreCell.Value = genreData.GenreStr;
                                    }
                                }

                                myLibraryBookGenreSearchComboBox.Items.Clear();
                                myLibraryBookGenreSearchComboBox.Items.Add("Не выбран");
                                foreach (GenreData genre in dbContext.Genres.OrderBy(x => x.GenreStr))
                                {
                                    if (string.IsNullOrWhiteSpace(genre.GenreStr))
                                    {
                                        continue;
                                    }
                                    myLibraryBookGenreSearchComboBox.Items.Add(genre);
                                }
                                myLibraryBookGenreSearchComboBox.SelectedIndex = 0;
                            }
                        }));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        EnableControls(tabPage2);
                    }
                });

                m.Items.Add("Удалить", null, async delegate (object s, EventArgs args)
                {
                    DisableControls(tabPage2);
                    await Task.Run(() =>
                    {
                        try
                        {
                            if (selectedRow == null)
                            {
                                return;
                            }

                            using (DatabaseContext dbContext = new DatabaseContext())
                            {
                                foreach (GenreData genreData in dbContext.Genres.OrderBy(x => x.GenreStr))
                                {
                                    if (genreData.Id.ToString() == selectedRow.Tag.ToString())
                                    {
                                        genreData.GenreStr = string.Empty;
                                    }
                                }
                                dbContext.SaveChanges();
                            }

                            Invoke(new Action(() =>
                            {
                                myLibraryDataGridView.ClearSelection();
                                myLibraryDataGridView.Rows.Clear();

                                genresDataGridView.ClearSelection();
                                genresDataGridView.Rows.Clear();

                                using (DatabaseContext dbContext = new DatabaseContext())
                                {
                                    foreach (BookData bookData in dbContext.Books.OrderBy(x => x.Name))
                                    {
                                        DataGridViewRow row = new DataGridViewRow();
                                        row.CreateCells(myLibraryDataGridView);
                                        int index = myLibraryDataGridView.Rows.Add(row);
                                        row = myLibraryDataGridView.Rows[index];

                                        if (row != null)
                                        {
                                            row.Tag = bookData.LocalId;

                                            DataGridViewCell myLibraryBookNameCell = row.Cells["myLibraryBookNameColumn"];
                                            DataGridViewCell myLibraryBookAuthorCell = row.Cells["myLibraryBookAuthorColumn"];
                                            DataGridViewCell myLibraryBookGenreCell = row.Cells["myLibraryBookGenreColumn"];

                                            myLibraryBookNameCell.Value = bookData.Name;
                                            myLibraryBookAuthorCell.Value = bookData.Author;
                                            myLibraryBookGenreCell.Value = dbContext.Find<GenreData>(bookData.GenreId).GenreStr;
                                        }
                                    }

                                    foreach (GenreData genreData in dbContext.Genres.OrderBy(x => x.GenreStr))
                                    {
                                        if (string.IsNullOrWhiteSpace(genreData.GenreStr))
                                        {
                                            continue;
                                        }

                                        DataGridViewRow row = new DataGridViewRow();
                                        row.CreateCells(genresDataGridView);
                                        int index = genresDataGridView.Rows.Add(row);
                                        row = genresDataGridView.Rows[index];

                                        if (row != null)
                                        {
                                            row.Tag = genreData.Id;

                                            DataGridViewCell genreCell = row.Cells["genreColumn"];
                                            genreCell.Value = genreData.GenreStr;
                                        }
                                    }
                                }
                            }));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            EnableControls(tabPage2);
                        }
                    });
                });

                m.Items.Add("Обновить", null, async delegate (object s, EventArgs args)
                {
                    DisableControls(tabPage2);
                    await Task.Run(() =>
                    {
                        try
                        {
                            Invoke(new Action(() =>
                            {
                                genresDataGridView.ClearSelection();
                                genresDataGridView.Rows.Clear();

                                using (DatabaseContext dbContext = new DatabaseContext())
                                {
                                    foreach (GenreData genreData in dbContext.Genres.OrderBy(x => x.GenreStr))
                                    {
                                        if (string.IsNullOrWhiteSpace(genreData.GenreStr))
                                        {
                                            continue;
                                        }

                                        DataGridViewRow row = new DataGridViewRow();
                                        row.CreateCells(genresDataGridView);
                                        int index = genresDataGridView.Rows.Add(row);
                                        row = genresDataGridView.Rows[index];

                                        if (row != null)
                                        {
                                            row.Tag = genreData.Id;

                                            DataGridViewCell genreCell = row.Cells["genreColumn"];
                                            genreCell.Value = genreData.GenreStr;
                                        }
                                    }
                                }
                            }));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            EnableControls(tabPage2);
                        }
                    });
                });

                m.Show(genresDataGridView, new Point(e.X, e.Y));
            }
        }

        private void OnMyLibraryDataGridViewMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridViewRow selectedRow = null;
                DataGridView.HitTestInfo hitTestInfo = myLibraryDataGridView.HitTest(e.X, e.Y);
                int rowIndex = hitTestInfo.RowIndex;
                int columnIndex = hitTestInfo.ColumnIndex;

                if (rowIndex >= 0)
                {
                    selectedRow = myLibraryDataGridView.Rows[rowIndex];
                }

                if (selectedRow != null)
                {
                    selectedRow.Selected = true;
                }

                ContextMenuStrip m = new ContextMenuStrip();
                m.Items.Add("Добавить", null, delegate (object s, EventArgs args)
                {
                    DisableControls(tabPage1);
                    try
                    {
                        BookForm bookForm = new BookForm();
                        bookForm.ShowForm("Добавить новую книгу", "Добавить");

                        Invoke(new Action(() =>
                        {
                            myLibraryDataGridView.ClearSelection();
                            myLibraryDataGridView.Rows.Clear();

                            genresDataGridView.ClearSelection();
                            genresDataGridView.Rows.Clear();

                            using (DatabaseContext dbContext = new DatabaseContext())
                            {
                                foreach (BookData bookData in dbContext.Books.OrderBy(x => x.Name))
                                {
                                    DataGridViewRow row = new DataGridViewRow();
                                    row.CreateCells(myLibraryDataGridView);
                                    int index = myLibraryDataGridView.Rows.Add(row);
                                    row = myLibraryDataGridView.Rows[index];

                                    if (row != null)
                                    {
                                        row.Tag = bookData.LocalId;

                                        DataGridViewCell myLibraryBookNameCell = row.Cells["myLibraryBookNameColumn"];
                                        DataGridViewCell myLibraryBookAuthorCell = row.Cells["myLibraryBookAuthorColumn"];
                                        DataGridViewCell myLibraryBookGenreCell = row.Cells["myLibraryBookGenreColumn"];

                                        myLibraryBookNameCell.Value = bookData.Name;
                                        myLibraryBookAuthorCell.Value = bookData.Author;
                                        myLibraryBookGenreCell.Value = dbContext.Find<GenreData>(bookData.GenreId).GenreStr;
                                    }
                                }

                                foreach (GenreData genreData in dbContext.Genres.OrderBy(x => x.GenreStr))
                                {
                                    if (string.IsNullOrWhiteSpace(genreData.GenreStr))
                                    {
                                        continue;
                                    }

                                    DataGridViewRow row = new DataGridViewRow();
                                    row.CreateCells(genresDataGridView);
                                    int index = genresDataGridView.Rows.Add(row);
                                    row = genresDataGridView.Rows[index];

                                    if (row != null)
                                    {
                                        row.Tag = genreData.Id;

                                        DataGridViewCell genreCell = row.Cells["genreColumn"];
                                        genreCell.Value = genreData.GenreStr;
                                    }
                                }

                                myLibraryBookGenreSearchComboBox.Items.Clear();
                                myLibraryBookGenreSearchComboBox.Items.Add("Не выбран");
                                foreach (GenreData genre in dbContext.Genres.OrderBy(x => x.GenreStr))
                                {
                                    if (string.IsNullOrWhiteSpace(genre.GenreStr))
                                    {
                                        continue;
                                    }
                                    myLibraryBookGenreSearchComboBox.Items.Add(genre);
                                }
                                myLibraryBookGenreSearchComboBox.SelectedIndex = 0;
                            }
                        }));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        EnableControls(tabPage1);
                    }
                });

                m.Items.Add("Удалить", null, async delegate (object s, EventArgs args)
                {
                    DisableControls(tabPage1);
                    await Task.Run(() =>
                    {
                        try
                        {
                            if (selectedRow == null)
                            {
                                return;
                            }

                            using (DatabaseContext dbContext = new DatabaseContext())
                            {
                                foreach (BookData bookData in dbContext.Books.OrderBy(x => x.Name))
                                {
                                    if (bookData.LocalId == selectedRow.Tag.ToString())
                                    {
                                        dbContext.Books.Remove(bookData);
                                    }
                                }
                                dbContext.SaveChanges();
                            }

                            Invoke(new Action(() =>
                            {
                                myLibraryDataGridView.ClearSelection();
                                myLibraryDataGridView.Rows.Clear();

                                using (DatabaseContext dbContext = new DatabaseContext())
                                {
                                    foreach (BookData bookData in dbContext.Books.OrderBy(x => x.Name))
                                    {
                                        DataGridViewRow row = new DataGridViewRow();
                                        row.CreateCells(myLibraryDataGridView);
                                        int index = myLibraryDataGridView.Rows.Add(row);
                                        row = myLibraryDataGridView.Rows[index];

                                        if (row != null)
                                        {
                                            row.Tag = bookData.LocalId;

                                            DataGridViewCell myLibraryBookNameCell = row.Cells["myLibraryBookNameColumn"];
                                            DataGridViewCell myLibraryBookAuthorCell = row.Cells["myLibraryBookAuthorColumn"];
                                            DataGridViewCell myLibraryBookGenreCell = row.Cells["myLibraryBookGenreColumn"];

                                            myLibraryBookNameCell.Value = bookData.Name;
                                            myLibraryBookAuthorCell.Value = bookData.Author;
                                            myLibraryBookGenreCell.Value = dbContext.Find<GenreData>(bookData.GenreId).GenreStr;
                                        }
                                    }
                                }
                            }));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            EnableControls(tabPage1);
                        }
                    });
                });

                m.Items.Add("Обновить", null, async delegate (object s, EventArgs args)
                {
                    DisableControls(tabPage1);
                    await Task.Run(() =>
                    {
                        try
                        {
                            Invoke(new Action(() =>
                            {
                                myLibraryDataGridView.ClearSelection();
                                myLibraryDataGridView.Rows.Clear();

                                using (DatabaseContext dbContext = new DatabaseContext())
                                {
                                    foreach (BookData bookData in dbContext.Books.OrderBy(x => x.Name))
                                    {
                                        DataGridViewRow row = new DataGridViewRow();
                                        row.CreateCells(myLibraryDataGridView);
                                        int index = myLibraryDataGridView.Rows.Add(row);
                                        row = myLibraryDataGridView.Rows[index];

                                        if (row != null)
                                        {
                                            row.Tag = bookData.LocalId;

                                            DataGridViewCell myLibraryBookNameCell = row.Cells["myLibraryBookNameColumn"];
                                            DataGridViewCell myLibraryBookAuthorCell = row.Cells["myLibraryBookAuthorColumn"];
                                            DataGridViewCell myLibraryBookGenreCell = row.Cells["myLibraryBookGenreColumn"];

                                            myLibraryBookNameCell.Value = bookData.Name;
                                            myLibraryBookAuthorCell.Value = bookData.Author;
                                            myLibraryBookGenreCell.Value = dbContext.Find<GenreData>(bookData.GenreId).GenreStr;
                                        }
                                    }
                                }
                            }));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            EnableControls(tabPage1);
                        }
                    });
                });

                m.Show(myLibraryDataGridView, new Point(e.X, e.Y));
            }
        }

        private void OnMyLibraryDataGridViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridViewRow selectedRow = null;
                DataGridView.HitTestInfo hitTestInfo = myLibraryDataGridView.HitTest(e.X, e.Y);
                int rowIndex = hitTestInfo.RowIndex;
                int columnIndex = hitTestInfo.ColumnIndex;

                if (rowIndex >= 0)
                {
                    selectedRow = myLibraryDataGridView.Rows[rowIndex];
                }

                if (selectedRow != null)
                {
                    selectedRow.Selected = true;
                }

                DisableControls(tabPage1);
                try
                {
                    if (selectedRow == null)
                    {
                        return;
                    }

                    BookData bookData1 = null;
                    using (DatabaseContext dbContext = new DatabaseContext())
                    {
                        foreach (BookData bookData in dbContext.Books.OrderBy(x => x.Name))
                        {
                            if (bookData.LocalId == selectedRow.Tag.ToString())
                            {
                                bookData1 = bookData;
                                break;
                            }
                        }
                    }

                    if (bookData1 != null)
                    {
                        BookForm bookForm = new BookForm();
                        bookForm.ShowForm("Просмотреть книгу", "Закрыть", bookData1);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    EnableControls(tabPage1);
                }
            }
        }

        private async void OnMyLibrarySearchButtonClick(object sender, EventArgs e)
        {
            DisableControls(tabPage1);
            await Task.Run(() =>
            {
                try
                {
                    Invoke(new Action(() =>
                    {
                        myLibraryDataGridView.ClearSelection();
                        myLibraryDataGridView.Rows.Clear();

                        using (DatabaseContext dbContext = new DatabaseContext())
                        {
                            foreach (BookData bookData in dbContext.Books.OrderBy(x => x.Name))
                            {
                                string bookGenre = dbContext.Find<GenreData>(bookData.GenreId).GenreStr;

                                if (!string.IsNullOrWhiteSpace(myLibraryBookNameSearchTextBox.Text) && !bookData.Name.ToLower().Contains(myLibraryBookNameSearchTextBox.Text.ToLower().Trim()) && !bookData.Author.ToLower().Contains(myLibraryBookNameSearchTextBox.Text.ToLower().Trim()))
                                {
                                    continue;
                                }

                                if (!string.IsNullOrWhiteSpace(myLibraryBookAuthorSearchTextBox.Text) && !bookData.Author.ToLower().Contains(myLibraryBookAuthorSearchTextBox.Text.ToLower().Trim()))
                                {
                                    continue;
                                }

                                if (!string.IsNullOrWhiteSpace(myLibraryBookGenreSearchComboBox.Text) && (myLibraryBookGenreSearchComboBox.Text.ToLower().Trim() != "не выбран") && (bookGenre.ToLower().Trim() != myLibraryBookGenreSearchComboBox.Text.ToLower().Trim()))
                                {
                                    continue;
                                }

                                DataGridViewRow row = new DataGridViewRow();
                                row.CreateCells(myLibraryDataGridView);
                                int index = myLibraryDataGridView.Rows.Add(row);
                                row = myLibraryDataGridView.Rows[index];

                                if (row != null)
                                {
                                    row.Tag = bookData.LocalId;

                                    DataGridViewCell myLibraryBookNameCell = row.Cells["myLibraryBookNameColumn"];
                                    DataGridViewCell myLibraryBookAuthorCell = row.Cells["myLibraryBookAuthorColumn"];
                                    DataGridViewCell myLibraryBookGenreCell = row.Cells["myLibraryBookGenreColumn"];

                                    myLibraryBookNameCell.Value = bookData.Name;
                                    myLibraryBookAuthorCell.Value = bookData.Author;
                                    myLibraryBookGenreCell.Value = bookGenre;
                                }
                            }
                        }
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    EnableControls(tabPage1);
                }
            });
        }

        private void EnableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c != null)
                {
                    Invoke(new Action(() =>
                    {
                        c.Enabled = true;
                    }));
                }
            }
        }

        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c != null)
                {
                    Invoke(new Action(() =>
                    {
                        c.Enabled = false;
                    }));
                }
            }
        }
    }
}
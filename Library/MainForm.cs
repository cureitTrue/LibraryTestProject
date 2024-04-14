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
                        new GenreData { Genre = "������� ����" },
                        new GenreData { Genre = "������� ����������" },
                        new GenreData { Genre = "��������� � ��������" },
                        new GenreData { Genre = "�������" },
                        new GenreData { Genre = "�������������� ����������" },
                        new GenreData { Genre = "����������� (��� � �����)" },
                        new GenreData { Genre = "�����������" },
                        new GenreData { Genre = "���������� � ��������" },
                        new GenreData { Genre = "�������� ������" },
                        new GenreData { Genre = "�����, �����������" },
                        new GenreData { Genre = "������" },
                        new GenreData { Genre = "�����������" },
                        new GenreData { Genre = "�����" },
                        new GenreData { Genre = "������" },
                        new GenreData { Genre = "������� � ����������" },
                        new GenreData { Genre = "���������� ����������" },
                        new GenreData { Genre = "���������" },
                        new GenreData { Genre = "�������" },
                        new GenreData { Genre = "����������" },
                        new GenreData { Genre = "��������" },
                        new GenreData { Genre = "����" }
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
                        myLibraryBookGenreCell.Value = bookData.Genre;
                    }
                }

                myLibraryBookGenreSearchComboBox.Items.Clear();
                myLibraryBookGenreSearchComboBox.Items.Add("�� ������");
                foreach (GenreData genre in dbContext.Genres.OrderBy(x => x.Genre))
                {
                    myLibraryBookGenreSearchComboBox.Items.Add(genre.Genre);
                }
                myLibraryBookGenreSearchComboBox.SelectedIndex = 0;
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
                m.Items.Add("��������", null, delegate (object s, EventArgs args)
                {
                    DisableControls(tabPage1);
                    try
                    {
                        BookForm bookForm = new BookForm();
                        bookForm.ShowForm("�������� ����� �����", "��������");

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
                                        myLibraryBookGenreCell.Value = bookData.Genre;
                                    }
                                }

                                myLibraryBookGenreSearchComboBox.Items.Clear();
                                myLibraryBookGenreSearchComboBox.Items.Add("�� ������");
                                foreach (GenreData genre in dbContext.Genres.OrderBy(x => x.Genre))
                                {
                                    myLibraryBookGenreSearchComboBox.Items.Add(genre.Genre);
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

                m.Items.Add("�������", null, async delegate (object s, EventArgs args)
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
                                            myLibraryBookGenreCell.Value = bookData.Genre;
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

                m.Items.Add("��������", null, async delegate (object s, EventArgs args)
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
                                            myLibraryBookGenreCell.Value = bookData.Genre;
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
                        bookForm.ShowForm("����������� �����", "�������", bookData1);
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
                                if (!string.IsNullOrWhiteSpace(myLibraryBookNameSearchTextBox.Text) && !bookData.Name.ToLower().Contains(myLibraryBookNameSearchTextBox.Text.ToLower().Trim()) && !bookData.Author.ToLower().Contains(myLibraryBookNameSearchTextBox.Text.ToLower().Trim()))
                                {
                                    continue;
                                }

                                if (!string.IsNullOrWhiteSpace(myLibraryBookAuthorSearchTextBox.Text) && !bookData.Author.ToLower().Contains(myLibraryBookAuthorSearchTextBox.Text.ToLower().Trim()))
                                {
                                    continue;
                                }

                                if (!string.IsNullOrWhiteSpace(myLibraryBookGenreSearchComboBox.Text) && (myLibraryBookGenreSearchComboBox.Text.ToLower().Trim() != "�� ������") && (bookData.Genre.ToLower().Trim() != myLibraryBookGenreSearchComboBox.Text.ToLower().Trim()))
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
                                    myLibraryBookGenreCell.Value = bookData.Genre;
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
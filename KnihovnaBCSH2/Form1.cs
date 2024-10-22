using LiteDB;
using System.Windows.Forms;

namespace KnihovnaBCSH2
{
    public partial class Form1 : Form
    {
        private Database _db = new Database();

        public Form1()
        {
            InitializeComponent();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            LoadKnihy();
        }
        private void LoadKnihy(string searchTerm = "")
        {
            var knihy = string.IsNullOrWhiteSpace(searchTerm)
               ? _db.Knihy.FindAll().ToList() 
               : _db.Knihy.Find(k =>
                   k.Nazev.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                   k.Autor.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                   k.ISBN.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                   k.RokVydani.ToString().Contains(searchTerm) || 
                   k.Zanr.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                   k.Nakladatelstvi.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList(); 

            dataGridView1.DataSource = null; 
            dataGridView1.DataSource = knihy; 
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            using (var addBookForm = new AddBookForm())
            {
                if (addBookForm.ShowDialog() == DialogResult.OK)
                {
                    var newBook = addBookForm.NewBook;

                    _db.Knihy.Insert(newBook);

                    LoadKnihy();
                }
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) 
            {
                var selectedId = (ObjectId)dataGridView1.SelectedRows[0].Cells["Id"].Value;

                var deleted = _db.Knihy.Delete(selectedId);

                if (deleted)
                {
                    LoadKnihy(); 
                }
                else
                {
                    MessageBox.Show("The selected book could not be deleted.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a book to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim(); 
            LoadKnihy(searchTerm);
        }
    }
}

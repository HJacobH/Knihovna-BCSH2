using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnihovnaBCSH2
{
    public partial class AddBookForm : Form
    {
        public Kniha NewBook { get; private set; }
        private Database _db;

        public AddBookForm(Database db)
        {
            InitializeComponent();
            _db = db;

            LoadSections();
        }

        private void LoadSections()
        {
            var sections = _db.Sekce.FindAll().ToList();

            cmbSection.DataSource = sections;
            cmbSection.DisplayMember = "Category";
            cmbSection.ValueMember = "Id"; 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                MessageBox.Show(cmbSection.SelectedValue?.ToString());
                NewBook = new Kniha
                {
                    ISBN = txtISBN.Text.Trim(),
                    Nazev = txtNazev.Text.Trim(),
                    Autor = txtAutor.Text.Trim(),
                    RokVydani = int.Parse(txtRokVydani.Text.Trim()),
                    Zanr = txtZanr.Text.Trim(),
                    Nakladatelstvi = txtNakladatelstvi.Text.Trim(),
                    SekceId = cmbSection.SelectedValue?.ToString()
                };

                DialogResult = DialogResult.OK; 
                Close(); 
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                MessageBox.Show("ISBN is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNazev.Text))
            {
                MessageBox.Show("Title is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAutor.Text))
            {
                MessageBox.Show("Author is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtZanr.Text))
            {
                MessageBox.Show("Genre is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNakladatelstvi.Text))
            {
                MessageBox.Show("Publisher is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txtRokVydani.Text.Trim(), out int year) || year < 1700 || year > DateTime.Now.Year)
            {
                MessageBox.Show("Year of Publication must be a between 1700 and the current year.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbSection.SelectedValue == null)
            {
                MessageBox.Show("A section must be selected.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true; 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

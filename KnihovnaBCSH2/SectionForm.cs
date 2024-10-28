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
    public partial class SectionForm : Form
    {
        public SekceKnihovny NewSection { get; private set; }

        public SectionForm()
        {
            InitializeComponent();
            cmbCategory.Items.AddRange(new string[] { "Sci-Fi", "Fantasy", "Mystery", "Romance", "Non-Fiction", "Biography" });
            cmbCategory.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                NewSection = new SekceKnihovny
                {
                    Id = Guid.NewGuid().ToString(),
                    Room = txtRoom.Text.Trim(),
                    Category = cmbCategory.SelectedItem.ToString(),
                    Description = txtDescription.Text.Trim(),
                    BookIds = new List<string>()
                };

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtRoom.Text))
            {
                MessageBox.Show("Room is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Category selection is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}

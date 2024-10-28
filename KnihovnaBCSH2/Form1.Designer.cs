namespace KnihovnaBCSH2
{
    partial class Form1
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
            dataGridView1 = new DataGridView();
            btnAddBook = new Button();
            btnDeleteBook = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnAddSection = new Button();
            btnLoadSections = new Button();
            btnLoadBooks = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(10, 35);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(592, 293);
            dataGridView1.TabIndex = 0;
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(607, 35);
            btnAddBook.Margin = new Padding(3, 2, 3, 2);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(82, 22);
            btnAddBook.TabIndex = 1;
            btnAddBook.Text = "Add Book";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.Location = new Point(607, 62);
            btnDeleteBook.Margin = new Padding(3, 2, 3, 2);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(82, 22);
            btnDeleteBook.TabIndex = 2;
            btnDeleteBook.Text = "Delete Book";
            btnDeleteBook.UseVisualStyleBackColor = true;
            btnDeleteBook.Click += btnDeleteBook_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(10, 9);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(592, 23);
            txtSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(607, 8);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(82, 22);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnAddSection
            // 
            btnAddSection.Location = new Point(607, 89);
            btnAddSection.Name = "btnAddSection";
            btnAddSection.Size = new Size(81, 23);
            btnAddSection.TabIndex = 5;
            btnAddSection.Text = "Add Section";
            btnAddSection.UseVisualStyleBackColor = true;
            btnAddSection.Click += btnAddSection_Click;
            // 
            // btnLoadSections
            // 
            btnLoadSections.Location = new Point(607, 303);
            btnLoadSections.Name = "btnLoadSections";
            btnLoadSections.Size = new Size(91, 23);
            btnLoadSections.TabIndex = 6;
            btnLoadSections.Text = "Load Sections";
            btnLoadSections.UseVisualStyleBackColor = true;
            btnLoadSections.Click += btnLoadSections_Click;
            // 
            // btnLoadBooks
            // 
            btnLoadBooks.Location = new Point(607, 274);
            btnLoadBooks.Name = "btnLoadBooks";
            btnLoadBooks.Size = new Size(91, 23);
            btnLoadBooks.TabIndex = 7;
            btnLoadBooks.Text = "Load Books";
            btnLoadBooks.UseVisualStyleBackColor = true;
            btnLoadBooks.Click += btnLoadBooks_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnLoadBooks);
            Controls.Add(btnLoadSections);
            Controls.Add(btnAddSection);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnDeleteBook);
            Controls.Add(btnAddBook);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnAddBook;
        private Button btnDeleteBook;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnAddSection;
        private Button btnLoadSections;
        private Button btnLoadBooks;
    }
}

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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 47);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(676, 391);
            dataGridView1.TabIndex = 0;
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(694, 47);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(94, 29);
            btnAddBook.TabIndex = 1;
            btnAddBook.Text = "Add Book";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.Location = new Point(694, 82);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(94, 29);
            btnDeleteBook.TabIndex = 2;
            btnDeleteBook.Text = "Delete Book";
            btnDeleteBook.UseVisualStyleBackColor = true;
            btnDeleteBook.Click += btnDeleteBook_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(676, 27);
            txtSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(694, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnDeleteBook);
            Controls.Add(btnAddBook);
            Controls.Add(dataGridView1);
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
    }
}

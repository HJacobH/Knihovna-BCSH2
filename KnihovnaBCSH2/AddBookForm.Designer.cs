
namespace KnihovnaBCSH2
{
    partial class AddBookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNakladatelstvi = new TextBox();
            txtZanr = new TextBox();
            txtRokVydani = new TextBox();
            txtAutor = new TextBox();
            txtNazev = new TextBox();
            txtISBN = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            isbnLabel = new Label();
            nazevLabel = new Label();
            autorLabel = new Label();
            rokVydaniLabel = new Label();
            zanrLabel = new Label();
            nakladatelstviLabel = new Label();
            cmbSection = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtNakladatelstvi
            // 
            txtNakladatelstvi.Location = new Point(111, 135);
            txtNakladatelstvi.Margin = new Padding(3, 2, 3, 2);
            txtNakladatelstvi.Name = "txtNakladatelstvi";
            txtNakladatelstvi.Size = new Size(110, 23);
            txtNakladatelstvi.TabIndex = 14;
            // 
            // txtZanr
            // 
            txtZanr.Location = new Point(111, 110);
            txtZanr.Margin = new Padding(3, 2, 3, 2);
            txtZanr.Name = "txtZanr";
            txtZanr.Size = new Size(110, 23);
            txtZanr.TabIndex = 13;
            // 
            // txtRokVydani
            // 
            txtRokVydani.Location = new Point(111, 86);
            txtRokVydani.Margin = new Padding(3, 2, 3, 2);
            txtRokVydani.Name = "txtRokVydani";
            txtRokVydani.Size = new Size(110, 23);
            txtRokVydani.TabIndex = 12;
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(111, 61);
            txtAutor.Margin = new Padding(3, 2, 3, 2);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(110, 23);
            txtAutor.TabIndex = 11;
            // 
            // txtNazev
            // 
            txtNazev.Location = new Point(111, 36);
            txtNazev.Margin = new Padding(3, 2, 3, 2);
            txtNazev.Name = "txtNazev";
            txtNazev.Size = new Size(110, 23);
            txtNazev.TabIndex = 10;
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(111, 11);
            txtISBN.Margin = new Padding(3, 2, 3, 2);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(110, 23);
            txtISBN.TabIndex = 9;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(10, 194);
            btnOK.Margin = new Padding(3, 2, 3, 2);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(82, 22);
            btnOK.TabIndex = 16;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(138, 194);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(82, 22);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // isbnLabel
            // 
            isbnLabel.AutoSize = true;
            isbnLabel.Location = new Point(10, 14);
            isbnLabel.Name = "isbnLabel";
            isbnLabel.Size = new Size(35, 15);
            isbnLabel.TabIndex = 18;
            isbnLabel.Text = "ISBN:";
            // 
            // nazevLabel
            // 
            nazevLabel.AutoSize = true;
            nazevLabel.Location = new Point(10, 38);
            nazevLabel.Name = "nazevLabel";
            nazevLabel.Size = new Size(42, 15);
            nazevLabel.TabIndex = 19;
            nazevLabel.Text = "Nazev:";
            // 
            // autorLabel
            // 
            autorLabel.AutoSize = true;
            autorLabel.Location = new Point(10, 63);
            autorLabel.Name = "autorLabel";
            autorLabel.Size = new Size(40, 15);
            autorLabel.TabIndex = 20;
            autorLabel.Text = "Autor:";
            // 
            // rokVydaniLabel
            // 
            rokVydaniLabel.AutoSize = true;
            rokVydaniLabel.Location = new Point(10, 88);
            rokVydaniLabel.Name = "rokVydaniLabel";
            rokVydaniLabel.Size = new Size(68, 15);
            rokVydaniLabel.TabIndex = 21;
            rokVydaniLabel.Text = "Rok vydání:";
            // 
            // zanrLabel
            // 
            zanrLabel.AutoSize = true;
            zanrLabel.Location = new Point(12, 112);
            zanrLabel.Name = "zanrLabel";
            zanrLabel.Size = new Size(34, 15);
            zanrLabel.TabIndex = 22;
            zanrLabel.Text = "Žánr:";
            // 
            // nakladatelstviLabel
            // 
            nakladatelstviLabel.AutoSize = true;
            nakladatelstviLabel.Location = new Point(10, 137);
            nakladatelstviLabel.Name = "nakladatelstviLabel";
            nakladatelstviLabel.Size = new Size(84, 15);
            nakladatelstviLabel.TabIndex = 23;
            nakladatelstviLabel.Text = "Nakladatelství:";
            // 
            // cmbSection
            // 
            cmbSection.FormattingEnabled = true;
            cmbSection.Location = new Point(111, 163);
            cmbSection.Name = "cmbSection";
            cmbSection.Size = new Size(110, 23);
            cmbSection.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 166);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 25;
            label1.Text = "Sekce:";
            // 
            // AddBookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(231, 224);
            Controls.Add(label1);
            Controls.Add(cmbSection);
            Controls.Add(nakladatelstviLabel);
            Controls.Add(zanrLabel);
            Controls.Add(rokVydaniLabel);
            Controls.Add(autorLabel);
            Controls.Add(nazevLabel);
            Controls.Add(isbnLabel);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtNakladatelstvi);
            Controls.Add(txtZanr);
            Controls.Add(txtRokVydani);
            Controls.Add(txtAutor);
            Controls.Add(txtNazev);
            Controls.Add(txtISBN);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddBookForm";
            Text = "AddBook";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtNakladatelstvi;
        private TextBox txtZanr;
        private TextBox txtRokVydani;
        private TextBox txtAutor;
        private TextBox txtNazev;
        private TextBox txtISBN;
        private Button btnOK;
        private Button btnCancel;
        private Label isbnLabel;
        private Label nazevLabel;
        private Label autorLabel;
        private Label rokVydaniLabel;
        private Label zanrLabel;
        private Label nakladatelstviLabel;
        private ComboBox cmbSection;
        private Label label1;
    }
}

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
            txtSekceId = new TextBox();
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
            SuspendLayout();
            // 
            // txtSekceId
            // 
            txtSekceId.Location = new Point(127, 213);
            txtSekceId.Name = "txtSekceId";
            txtSekceId.Size = new Size(125, 27);
            txtSekceId.TabIndex = 15;
            // 
            // txtNakladatelstvi
            // 
            txtNakladatelstvi.Location = new Point(127, 180);
            txtNakladatelstvi.Name = "txtNakladatelstvi";
            txtNakladatelstvi.Size = new Size(125, 27);
            txtNakladatelstvi.TabIndex = 14;
            // 
            // txtZanr
            // 
            txtZanr.Location = new Point(127, 147);
            txtZanr.Name = "txtZanr";
            txtZanr.Size = new Size(125, 27);
            txtZanr.TabIndex = 13;
            // 
            // txtRokVydani
            // 
            txtRokVydani.Location = new Point(127, 114);
            txtRokVydani.Name = "txtRokVydani";
            txtRokVydani.Size = new Size(125, 27);
            txtRokVydani.TabIndex = 12;
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(127, 81);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(125, 27);
            txtAutor.TabIndex = 11;
            // 
            // txtNazev
            // 
            txtNazev.Location = new Point(127, 48);
            txtNazev.Name = "txtNazev";
            txtNazev.Size = new Size(125, 27);
            txtNazev.TabIndex = 10;
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(127, 15);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(125, 27);
            txtISBN.TabIndex = 9;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(12, 258);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 29);
            btnOK.TabIndex = 16;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(158, 258);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // isbnLabel
            // 
            isbnLabel.AutoSize = true;
            isbnLabel.Location = new Point(12, 18);
            isbnLabel.Name = "isbnLabel";
            isbnLabel.Size = new Size(44, 20);
            isbnLabel.TabIndex = 18;
            isbnLabel.Text = "ISBN:";
            // 
            // nazevLabel
            // 
            nazevLabel.AutoSize = true;
            nazevLabel.Location = new Point(12, 51);
            nazevLabel.Name = "nazevLabel";
            nazevLabel.Size = new Size(53, 20);
            nazevLabel.TabIndex = 19;
            nazevLabel.Text = "Nazev:";
            // 
            // autorLabel
            // 
            autorLabel.AutoSize = true;
            autorLabel.Location = new Point(12, 84);
            autorLabel.Name = "autorLabel";
            autorLabel.Size = new Size(49, 20);
            autorLabel.TabIndex = 20;
            autorLabel.Text = "Autor:";
            // 
            // rokVydaniLabel
            // 
            rokVydaniLabel.AutoSize = true;
            rokVydaniLabel.Location = new Point(12, 117);
            rokVydaniLabel.Name = "rokVydaniLabel";
            rokVydaniLabel.Size = new Size(84, 20);
            rokVydaniLabel.TabIndex = 21;
            rokVydaniLabel.Text = "Rok vydání:";
            // 
            // zanrLabel
            // 
            zanrLabel.AutoSize = true;
            zanrLabel.Location = new Point(14, 150);
            zanrLabel.Name = "zanrLabel";
            zanrLabel.Size = new Size(42, 20);
            zanrLabel.TabIndex = 22;
            zanrLabel.Text = "Žánr:";
            // 
            // nakladatelstviLabel
            // 
            nakladatelstviLabel.AutoSize = true;
            nakladatelstviLabel.Location = new Point(12, 183);
            nakladatelstviLabel.Name = "nakladatelstviLabel";
            nakladatelstviLabel.Size = new Size(106, 20);
            nakladatelstviLabel.TabIndex = 23;
            nakladatelstviLabel.Text = "Nakladatelství:";
            // 
            // AddBookForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 299);
            Controls.Add(nakladatelstviLabel);
            Controls.Add(zanrLabel);
            Controls.Add(rokVydaniLabel);
            Controls.Add(autorLabel);
            Controls.Add(nazevLabel);
            Controls.Add(isbnLabel);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtSekceId);
            Controls.Add(txtNakladatelstvi);
            Controls.Add(txtZanr);
            Controls.Add(txtRokVydani);
            Controls.Add(txtAutor);
            Controls.Add(txtNazev);
            Controls.Add(txtISBN);
            Name = "AddBookForm";
            Text = "AddBook";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSekceId;
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
    }
}
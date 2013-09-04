namespace EnititySearch.UI
{
    partial class KeywordAliasEditor
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
            this.grdAlias = new System.Windows.Forms.DataGridView();
            this.cmbKeyword = new System.Windows.Forms.ComboBox();
            this.btnNewAlilas = new System.Windows.Forms.Button();
            this.btnDeleteAlias = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdAlias)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdAlias
            // 
            this.grdAlias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdAlias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAlias.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdAlias.Location = new System.Drawing.Point(0, 41);
            this.grdAlias.Name = "grdAlias";
            this.grdAlias.Size = new System.Drawing.Size(333, 168);
            this.grdAlias.TabIndex = 0;
            this.grdAlias.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAlias_CellValueChanged);
            // 
            // cmbKeyword
            // 
            this.cmbKeyword.FormattingEnabled = true;
            this.cmbKeyword.Location = new System.Drawing.Point(12, 12);
            this.cmbKeyword.Name = "cmbKeyword";
            this.cmbKeyword.Size = new System.Drawing.Size(240, 21);
            this.cmbKeyword.TabIndex = 1;
            this.cmbKeyword.SelectedIndexChanged += new System.EventHandler(this.refreshAliasDataGrid);
            // 
            // btnNewAlilas
            // 
            this.btnNewAlilas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewAlilas.Location = new System.Drawing.Point(258, 12);
            this.btnNewAlilas.Name = "btnNewAlilas";
            this.btnNewAlilas.Size = new System.Drawing.Size(32, 23);
            this.btnNewAlilas.TabIndex = 2;
            this.btnNewAlilas.Text = "+";
            this.btnNewAlilas.UseVisualStyleBackColor = true;
            this.btnNewAlilas.Click += new System.EventHandler(this.btnNewAlilas_Click);
            // 
            // btnDeleteAlias
            // 
            this.btnDeleteAlias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAlias.Location = new System.Drawing.Point(296, 12);
            this.btnDeleteAlias.Name = "btnDeleteAlias";
            this.btnDeleteAlias.Size = new System.Drawing.Size(32, 23);
            this.btnDeleteAlias.TabIndex = 3;
            this.btnDeleteAlias.Text = "-";
            this.btnDeleteAlias.UseVisualStyleBackColor = true;
            this.btnDeleteAlias.Click += new System.EventHandler(this.btnDeleteAlias_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnNewAlilas);
            this.pnlMain.Controls.Add(this.btnDeleteAlias);
            this.pnlMain.Controls.Add(this.grdAlias);
            this.pnlMain.Controls.Add(this.cmbKeyword);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(333, 209);
            this.pnlMain.TabIndex = 4;
            // 
            // KeywordAliasEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 209);
            this.Controls.Add(this.pnlMain);
            this.Name = "KeywordAliasEditor";
            this.Text = "Keyword Alias Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KeywordAliasEditor_FormClosing);
            this.Load += new System.EventHandler(this.KeywordAliasEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAlias)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdAlias;
        private System.Windows.Forms.ComboBox cmbKeyword;
        private System.Windows.Forms.Button btnNewAlilas;
        private System.Windows.Forms.Button btnDeleteAlias;
        public System.Windows.Forms.Panel pnlMain;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects.DataClasses;
using EnititySearch.Keywords;

namespace EnititySearch.UI
{
    public partial class KeywordAliasEditor : Form
    {
        private EnititySearchDBEntities1 _Entities = new EnititySearchDBEntities1();        

        public KeywordAliasEditor()
        {
            InitializeComponent();
        }

        private void KeywordAliasEditor_Load(object sender, EventArgs e)
        {
            init();
        }

        public void init()
        {
            var keywords = KeywordBase.getDerivedClasses();

            var entityKeywords = _Entities.Keywords.ToList();

            foreach (var keyword in keywords)
            {
                if (entityKeywords.Where(o => o.Name == keyword.Name).Count() == 0)
                {
                    _Entities.ExecuteStoreCommand("INSERT INTO Keyword (Name) VALUES ({0});", keyword.Name);
                }
            }

            _Entities.SaveChanges();

            cmbKeyword.DataSource = _Entities.Keywords.Select(o => o.Name);
        }

        private int getKeywordID()
        {
            return _Entities.Keywords.ToList().Where(o => o.Name == getKeyword()).First().ID;
        }

        private String getKeyword()
        {
            return cmbKeyword.SelectedItem.ToString();
        }

        private void refresh()
        {
            _Entities = new EnititySearchDBEntities1();
            refreshAliasDataGrid(null, null);  
        }

        private void refreshAliasDataGrid(object sender, EventArgs e)
        {
            var key = getKeyword();
            
            grdAlias.DataSource = _Entities.Keywords.Where(o => o.Name == key)
                                          .Select(o => o.Aliases).FirstOrDefault().OrderBy(o => o.Name).ToList();

            foreach (DataGridViewColumn column in grdAlias.Columns)
                column.Visible = false;

            grdAlias.Columns["Name"].Visible = true;

            grdAlias.Refresh();
        }

        private void KeywordAliasEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
           _Entities.ExecuteStoreCommand("DELETE FROM Alias where Name is null or Name = ''");
        }

        private void btnNewAlilas_Click(object sender, EventArgs e)
        {
            _Entities.SaveChanges();
            _Entities.ExecuteStoreCommand("INSERT INTO Alias (KeywordID) VALUES ({0});", getKeywordID());
            refresh();
        }

        private void btnDeleteAlias_Click(object sender, EventArgs e)
        {
            if (grdAlias.SelectedRows.Count != 0){
                _Entities.SaveChanges();
                _Entities.ExecuteStoreCommand("DELETE FROM Alias where ID = {0};", grdAlias.SelectedRows[0].Cells[0].Value);
                refresh();
            }
        }

        private void grdAlias_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _Entities.SaveChanges();
        }
    }
}

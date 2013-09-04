using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EnititySearch.UI;

namespace EnititySearch
{
    public partial class Main : Form
    {

        private EnititySearchDBEntities1 Entities = new EnititySearchDBEntities1();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            gridContact.DataSource = Entities.Contacts;
            gridContact.Columns["ID"].Visible = false;

            var form = new KeywordAliasEditor();

            grpKeywordAliasEditor.Controls.Add(form.pnlMain);
            form.init();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Contact> removeObjects = (from Contact value in Entities.Contacts where value.Name == null select value).ToList();
            
            foreach(var value in removeObjects)
                Entities.Contacts.DeleteObject(value);

            Entities.SaveChanges();
        }

        private void btnKeywordAliasEditor_Click(object sender, EventArgs e)
        {
            (new UI.KeywordAliasEditor()).Show();
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            SearchEngine Search = new SearchEngine();

            Search.addField("Age");
            Search.addField("Name");
            Search.addField("Weight", new List<string>() { "weight", "weigh" });
            Search.addField("Birthday");

            txtParse.Text = Search.Search(textBox1.Text);
            
            //Doesn't handle nulls
            //var test = Entities.Contacts.DynamicWhere(o => o["AGE"] == 1).ToList();

            //var test = Entities.Contacts.Where("it.Age > 20 and it.Name like 'nick'").ToList();
        }
    }
}

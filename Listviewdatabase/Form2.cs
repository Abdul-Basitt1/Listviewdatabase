using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listviewdatabase
{
    public partial class Form2 : Form
    {
        
        
        public Form2()
        {
            InitializeComponent();
            listView1.Visible = false;
            dataGridView1.Visible = false;
        }

        private void search_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach(ListViewItem lvi in Form1.listview.Items)
            {
                string str = lvi.SubItems[1].Text;
                if(str.ToUpper() == searchname.Text.ToUpper())
                {
                    listView1.Items.Add((ListViewItem)lvi.Clone());
                }
            }
        }

        private void showallrecord_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
            dataGridView1.Visible = false;
            foreach(ListViewItem lvi in Form1.listview.Items)
            {
                listView1.Items.Add((ListViewItem)lvi.Clone());
            }
        }

        private void goback_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void showdatabase_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            dataGridView1.Visible = true;
            SqlConnection sqlc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM dataent", sqlc);
            sqlc.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqlc.Close();
            dataGridView1.DataSource = dt;
        }

    }
}

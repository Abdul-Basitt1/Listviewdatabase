using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listviewdatabase
{
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();
        public Form1()
        {
            InitializeComponent();
        }
        public static ListView listview = new ListView();
        private void save_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem(fname.Text);
            lvi.SubItems.Add(lname.Text);
            string gen = "";
            if(male.Checked)
            {
                gen = "male";
            }
            else
            {
                gen = "female";
            }
            lvi.SubItems.Add(gen);
            lvi.SubItems.Add(contact.Text.ToString());
            lvi.SubItems.Add(address.Text);
            lvi.SubItems.Add(whsnum.Text.ToString());
            lvi.SubItems.Add(whsname.Text);
            listview.Items.Add(lvi);
            MessageBox.Show("Data saved");
        }

        private void show_Click(object sender, EventArgs e)
        {
            form2.Show();
            this.Hide();

        }

        private void update_Click(object sender, EventArgs e)
        {
            
            foreach (ListViewItem lvi in listview.Items)
            {
                string contactnum = lvi.SubItems[3].Text.ToString();
                if (contact.Text == contactnum)
                {
                    lvi.SubItems[0].Text = fname.Text;
                    lvi.SubItems[1].Text = lname.Text;
                    lvi.SubItems[4].Text = address.Text;
                    lvi.SubItems[5].Text = whsnum.Text;
                    lvi.SubItems[6].Text = whsname.Text;
                    MessageBox.Show("Data updated");
                }
            }
        }

        private void addtodatabase_Click(object sender, EventArgs e)
        {
            string fn = fname.Text;
            string ln = lname.Text;
            string gd = "";
            if (male.Checked)
            {
                gd = "male";
            }
            else
            {
                gd = "female";
            }
            string gnd = gd;
            string cnt = contact.Text;
            string add = address.Text;
            string whsc = whsnum.Text;
            string whsn = whsname.Text;
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection sqlc = new SqlConnection(connection);
            string query = "INSERT INTO dataent(FirstName,LastName,Gender,Contact,Address,WarehouseNo,WarehouseName) VALUES('" + fn + "', '" + ln + "','" + gnd + "','" + cnt + "','" + add + "','" + whsc + "','" + whsn + "')";
            SqlCommand sqlCommand = new SqlCommand(query, sqlc);
            sqlc.Open();
            int comm = sqlCommand.ExecuteNonQuery();
            if (comm > 0)
            {
                MessageBox.Show("Data Inserted Successfully");
                
            }
            else if (comm == 0)
            {
                MessageBox.Show("Failure! Data not inserted");
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            male.Checked = false;
            female.Checked = false;
            fname.Text = "";
            lname.Text = "";
            contact.Text = "";
            address.Text = "";
            whsnum.Text = "";
            whsname.Text = "";
        }

        private void search_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listview.Items)
            {
                string contactnum = lvi.SubItems[3].Text.ToString();
                if (contact.Text == contactnum)
                {
                    fname.Text = lvi.SubItems[0].Text;
                    lname.Text = lvi.SubItems[1].Text;
                    address.Text = lvi.SubItems[4].Text;
                    whsnum.Text = lvi.SubItems[5].Text;
                    whsname.Text = lvi.SubItems[6].Text;
                    MessageBox.Show("Data searched");
                    
                }
            }
        }

        
    }
}

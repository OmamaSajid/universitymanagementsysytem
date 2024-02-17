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

namespace omamasaleha
{
    public partial class Form14 : Form
    {
        string id = Form1.std;
        string name;
        string query; 
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
        public Form14()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form15 form15 = new Form15();
            form15.Show();
           // this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();
            form13.Show();
            //this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
           // this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
           // this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
           // this.Hide();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            conn.Open();
            textBox3.Text = id;
            textBox3.ReadOnly = true;
            query = "select name from student where id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string nm= dr["name"].ToString();
                textBox2.Text = nm;
                textBox2.ReadOnly = true;

            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form16 form16 = new Form16();
            form16.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Visual ")
            {
                Form17 f = new Form17();
                f.Show();
            }
            else
            {
                Form16 f = new Form16();
                f.Show();
            }
        }
    }
}
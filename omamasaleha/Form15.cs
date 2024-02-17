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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace omamasaleha
{
    public partial class Form15 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source= DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
        string query;
        string id = Form1.std;
        function fn = new function();
        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            textBox1.Text = id;
            textBox1.ReadOnly = true;
            conn.Open();
            query = "select * from student where id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string nm = dr["name"].ToString();
                string fnm = dr["father_name"].ToString();
                string ad= dr["address"].ToString();
                string mail= dr["email"].ToString();
                string phoneno = dr["phoneno"].ToString();
                textBox6.Text = nm;
                textBox7.Text = fnm;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox3.Text = ad;
                textBox5.Text = mail;
                textBox9.Text = phoneno;
                textBox2.Text = "NO";
                
                textBox2.ReadOnly = true;
               
            }
            else
            {
                MessageBox.Show("incorrect credentaials");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form14 f = new Form14();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id=textBox1.Text;
            string address=textBox3.Text;
            string email=textBox5.Text;
            string phoneno=textBox9.Text;
            query = "update student set address=@address,email=@email,phoneno=@phoneno where id=@id";
            string msg = "Saved successfully";
            fn.stdata(query, msg, id, address, email, phoneno);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.ReadOnly = true;
        }
    }
}

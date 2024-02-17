using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace omamasaleha
{
    public partial class Form6 : Form
    {
        string query;
        DataSet ds;
        function fn = new function();
        public Form6()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            query = "INSERT INTO instructor(inst_id, inst_name,qualification,inst_phoneno,inst_email,inst_address) VALUES (@inst_id, @inst_name,@qualification,@inst_phoneno,@inst_email,@inst_address)";

            string message = "inserted successfully";
            string id = textBox5.Text;
            string nm = textBox4.Text;
            string ql = textBox3.Text;
            string pno = textBox2.Text;
            string eml = textBox1.Text;
            string add = textBox7.Text;
            fn.instdata(query, message, id, nm, ql, pno, eml, add);

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            query = "SELECT p.inst_id, p.inst_name, p.qualification, p.inst_phoneno,p.inst_email,p.inst_address,d.c_id " +
           "FROM instructor p " +
           "JOIN course d ON p.c_id = d.c_id";
            ds = fn.getdata(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            query = "update instructor set inst_id=@inst_id, inst_name=@inst_name,qualification= @qualification,inst_phoneno=@inst_phoneno,inst_email=@inst_email,inst_address=@inst_address where  inst_id=@inst_id";

            string message = "Updated successfully";
            string id = textBox5.Text;
            string nm = textBox4.Text;
            string ql = textBox3.Text;
            string pno = textBox2.Text;
            string eml = textBox1.Text;
            string add = textBox7.Text;
            fn.instdata(query, message, id, nm, ql, pno, eml, add);
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.Location = new Point(250, 90);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source= DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
            try
            {
               
                conn.Open();
                //SqlCommand cmd = new SqlCommand("select * from advisor",conn);
                string query = "select * from instructor where inst_id='" + textBox5.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                SqlCommandBuilder bulder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source= DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
            try
            {
                conn.Open();
                //SqlCommand cmd = new SqlCommand("select * from advisor",conn);
                string query = "select * from instructor where inst_name='" + textBox4.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                SqlCommandBuilder bulder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "  ";
            textBox2.Text = "  ";
            textBox3.Text = "  ";
            textBox4.Text = "  ";
            textBox5.Text = "   ";
            textBox7.Text = "   ";
        }
    }
}

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
    public partial class Form5 : Form
    {
        function fn = new function();
        string query;
        DataSet ds;
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            query = "INSERT INTO department(dept_id, dpt_name, faculty_no) VALUES (@dept_id, @dpt_name, @faculty_no)";

            string message = "inserted successfully";
            string id = textBox2.Text;
            string name = textBox1.Text;
            string faculty = textBox3.Text;


            fn.dptdata(query, message, id, name, faculty);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            query = "update department set dept_id=@dept_id, dpt_name=@dpt_name, faculty_no=@faculty_no where dept_id=@dept_id";

            string message = "Updated successfully";
            string id = textBox2.Text;
            string name = textBox1.Text;
            string faculty = textBox3.Text;


            fn.dptdata(query, message, id, name, faculty);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
           // form2.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.Location = new Point(250, 90);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source= DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
            try
            {
                conn.Open();
                //SqlCommand cmd = new SqlCommand("select * from advisor",conn);
                string query = "select * from department where dept_id='" + textBox2.Text + "'";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source= DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
            try
            {
                conn.Open();
                //SqlCommand cmd = new SqlCommand("select * from advisor",conn);
                string query = "select * from department where dpt_name='" + textBox1.Text + "'";
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

        private void button6_Click(object sender, EventArgs e)
        {
            query = "select * from department";
            ds = fn.getdata(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

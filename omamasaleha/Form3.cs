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
    public partial class Form3 : Form
    {
        function fn = new function();
        string query;
        DataSet ds;
        string type = Form1.UserType;
        public Form3()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //query = "select program_id, bachelors, masters, phd from program";
            query = "SELECT p.program_id, p.bachelors, p.masters, p.phd, d.dpt_name " +
            "FROM program p " +
            "JOIN department d ON p.dept_id = d.dept_id";
            ds = fn.getdata(query);
           dataGridView1.DataSource = ds.Tables[0];
           
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            query = "INSERT INTO program(program_id, bachelors, masters, phd) VALUES (@program_id, @bachelors, @masters, @phd)";

            string message = "inserted successfully";
            string id = textBox1.Text;
            string bs = textBox4.Text;
            string ms = textBox3.Text;
            string pd = textBox2.Text;
           
            fn.prgmdata(query,message,id,bs,ms,pd);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            query = "update program set program_id=@program_id,bachelors=@bachelors,masters=@masters,phd=@phd where program_id=@program_id ";
            string message = " Updated successfully";
            string id = textBox1.Text;
            string bs = textBox4.Text;
            string ms = textBox3.Text;
            string pd = textBox2.Text;
            fn.prgmdata(query, message, id, bs, ms, pd);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Location = new Point(250, 90);
            if (type == "Admin")
            {
                button1.Visible = true;
                button2.Visible = true;
                button4.Visible = true;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
                button4.Visible = false;
                query = "SELECT p.program_id, p.bachelors, p.masters, p.phd, d.dpt_name " +
            "FROM program p " +
            "JOIN department d ON p.dept_id = d.dept_id";
                ds = fn.getdata(query);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source= DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
            try
            {
                
                conn.Open();
                //SqlCommand cmd = new SqlCommand("select * from advisor",conn);
                string query = "select * from program where program_id='" + textBox1.Text + "'";
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source= DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
            try
            {
                conn.Open();
                //SqlCommand cmd = new SqlCommand("select * from advisor",conn);
                string query = "select * from program where bachelors='" + textBox5.Text + "' OR masters='" + textBox5.Text + " 'OR phd='" + textBox5.Text + "'";
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

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
           // form2.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

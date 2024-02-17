using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data.SqlClient;
namespace omamasaleha
{
    public partial class Form4 : Form
    {
        function fn = new function();
        string query;
        DataSet ds;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Location = new Point(250, 90);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            query = "select * from advisor";
            ds = fn.getdata(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "insert into advisor(adv_id, adv_name, class_under_advisory, adv_officeno) values(@adv_id, @adv_name, @class_under_advisory, @adv_officeno)";
            string msg = "inserted succesfully";
            string advId = textBox4.Text;
            string advName = textBox3.Text;
            string classUnderAdvisory = textBox2.Text;
            string advOfficeNo = textBox1.Text;
            fn.advdata(query, msg, advId, advName, classUnderAdvisory, advOfficeNo);

        }

        private void button3_Click(object sender, EventArgs e)
        {
           string query = "update advisor set adv_id=@adv_id, adv_name=@adv_name, class_under_advisory=@class_under_advisory, adv_officeno=@adv_officeno where adv_id=@adv_id" ;
            string msg = "updated succesfully";
            string advId = textBox4.Text;
            string advName = textBox3.Text;
            string classUnderAdvisory = textBox2.Text;
            string advOfficeNo = textBox1.Text;
            fn.advdata(query, msg, advId, advName, classUnderAdvisory, advOfficeNo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source= DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
            try
            {
                string adv_id = textBox4.Text;
                string adv_name = textBox3.Text;
                conn.Open();
                //SqlCommand cmd = new SqlCommand("select * from advisor",conn);
                string query = "select * from advisor where adv_id='" + textBox4.Text + "'";
                // string query = "select * from advisor where adv_id=@adv_id or adv_name =@adv_name ";
               // string query = "select * from advisor where adv_id='" + textBox4.Text + "' or adv_name='" + textBox3.Text + "' ";
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source= DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
            try
            {
                conn.Open();
                //SqlCommand cmd = new SqlCommand("select * from advisor",conn);
                string query = "select * from advisor where adv_name='" + textBox3.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                SqlCommandBuilder bulder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch(SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
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
            SqlConnection conn = new SqlConnection("Data Source= DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
            try
            {
                conn.Open();
                //SqlCommand cmd = new SqlCommand("select * from advisor",conn);
                string query = "select * from advisor where class_under_advisory='" + textBox2.Text + "'";
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
                string query = "select * from advisor where  adv_officeno='" + textBox1.Text + "'";
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

        private void button9_Click(object sender, EventArgs e)
        {
            Form2 d2 = new Form2();
            this.Hide();
            d2.Show();
        }
    }
}

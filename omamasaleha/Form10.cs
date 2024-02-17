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
    public partial class Form10 : Form
    {
        function fn = new function();
        DataSet ds;
        string query;
        string usertype = Form1.UserType;
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            this.Location = new Point(250, 90);
            if (usertype == "User")
            {


                query = "select c_id,c_name,c_hours from course";
                ds = fn.getdata(query);
                dataGridView1.DataSource = ds.Tables[0];
              //  button1.Visible = false;
                label4.Visible = true;
                textBox1.Visible = true;
                dataGridView1.Width = 400;
                dataGridView1.Height = 270;
            }
            else
            {
                string query = "SELECT s.name AS student_name, s.id AS student_id, s.father_name, c.c_id AS course_id, c.c_name AS course_name, ce.c_reg_id FROM student s JOIN course_enrollment ce ON s.id = ce.id JOIN course c ON ce.c_id = c.c_id";
                ds = fn.getdata(query);
                dataGridView1.DataSource = ds.Tables[0];
                button1.Visible = true;
                label4.Visible = false;
                textBox1.Visible = false;
                dataGridView1.Width = 660;
                dataGridView1.Height = 259;
                button1.Visible = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select c_id,c_name,c_hours from course";
            ds = fn.getdata(query);
            dataGridView1.DataSource = ds.Tables[0];

        }
       


         private void textBox1_TextChanged(object sender, EventArgs e)
         {

             SqlConnection conn = new SqlConnection("Data Source= DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
             try
             {
                 conn.Open();
                 //SqlCommand cmd = new SqlCommand("select * from advisor",conn);
                 string query = "select c_id,c_name,c_hours from course where c_id='" + textBox1.Text + "' OR c_name='" + textBox1.Text + " '";
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

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

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
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source= DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
           // this.Hide();
           // this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*SqlConnection conn = new SqlConnection("Data Source= DESKTOP-G1GC6P9; Initial Catalog= project; Trusted_Connection=True");
            conn.Open();
            string query = "select count(*) as total_adv from advisor";
            SqlCommand cmd = new SqlCommand(query, conn);
            int totaladv = (int)cmd.ExecuteScalar();
            MessageBox.Show($"Total Advisors: {totaladv}", "Total Advisors");
            conn.Close();*/
           

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form4 = new Form3();
            form4.Show();
           // this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
           // this.Hide();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source= DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
            conn.Open();
            string query = "select count(*) as tstd from student";
            SqlCommand cmd = new SqlCommand(query, conn);
            int total = (int)cmd.ExecuteScalar();
            button5.Text = total.ToString();
            string courseQuery = "SELECT COUNT(*) AS totalCourses FROM course";
            SqlCommand courseCmd = new SqlCommand(courseQuery, conn);
            int totalCourses = (int)courseCmd.ExecuteScalar();
            textBox3.Text = totalCourses.ToString();
            textBox3.ReadOnly = true;
            
            string departmentQuery = "SELECT COUNT(*) AS totalDepartments FROM department";
            SqlCommand departmentCmd = new SqlCommand(departmentQuery, conn);
            int totalDepartments = (int)departmentCmd.ExecuteScalar();
            textBox2.Text = totalDepartments.ToString();
            textBox2.ReadOnly = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form10 form7 = new Form10();
            form7.Show();
            //this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();
            
            form13.Show();
            //this.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Form17 form17 = new Form17();
            form17.Show();
        }
    }
}

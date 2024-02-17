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
using System.Windows.Forms.DataVisualization.Charting;

namespace omamasaleha
{
    public partial class Form7 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
        function fn = new function();
        string query;
        DataSet ds;
        string usertype = Form1.UserType;
        string id = Form1.std;
        private int clickCount = 0;

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.Location = new Point(250, 90);
            Random rand = new Random();
            int randomnumber = rand.Next();
            textBox6.Text = randomnumber.ToString();
            textBox2.Text = randomnumber.ToString();
            textBox2.ReadOnly = true;
            textBox7.Text = DateTime.Now.ToString("yyyy-MM-dd");
            fillcode();
           
            textBox5.Text = DateTime.Now.Year.ToString();
            if (usertype == "Admin")
            {
                label12.Visible = true;
            }
            else
            {
                conn.Open();
                query = "select name from student where id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string stdname = dr["name"].ToString();
                    textBox1.Text = stdname;
                    /* if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                     {

                         string studentName = ds.Tables[0].Rows[0]["name"].ToString();
                         textBox1.Text = studentName;
                     }*/


                    label12.Visible = false;
                    textBox1.ReadOnly = true;


                }
                else
                {
                    MessageBox.Show("NO ID");
                }
            }


        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clickCount++;
            if (clickCount == 1)
            {
                string Id = textBox2.Text;
                string query = "INSERT INTO course_enrollment (c_reg_id, c_year, reg_startdate, c_id, id) VALUES (@c_reg_id, @c_year, @reg_startdate, @c_id, @id)";
                string msg = "inserted succesfully";

                string course = textBox3.Text ;
                string year = textBox5.Text;
                string reg = textBox6.Text;
                string start = textBox7.Text;


                fn.coursedata(query, msg, reg, year, start, course, Id);
            }
            else
            {
                Random rand = new Random();
                int randomnumber = rand.Next();
                string Id = randomnumber.ToString();
                string query = "INSERT INTO course_enrollment (c_reg_id, c_year, reg_startdate, c_id, id) VALUES (@c_reg_id, @c_year, @reg_startdate, @c_id, @id)";
                string msg = "inserted succesfully";

                string course =  textBox3.Text;
                string year = textBox5.Text;
                string reg = textBox6.Text;
                string start = textBox7.Text;


                fn.coursedata(query, msg, reg, year, start, course, Id);
            }

        }

        private void label12_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";

            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.ReadOnly = true;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");

            try
            {
                conn.Open();

                if (comboBox1.SelectedItem != null)
                {
                    string c_name = comboBox1.SelectedItem.ToString();
                    query = "SELECT * FROM course WHERE c_name = @c_name";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@c_name", c_name);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                textBox3.Text = dr["c_id"].ToString();
                                textBox4.Text= dr["c_hours"].ToString();
                            }
                            else
                            {
                                textBox3.ReadOnly = true;
                                textBox4.ReadOnly = true;
                            }
                        }
                    }
                }
                else
                {
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., display an error message
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        private void fillcode()
        {

            comboBox1.Items.Clear();

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select c_name from course";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["c_name"].ToString());
            }
            conn.Close();
        }
       /* private void fillname()
        {
            comboBox2.Items.Clear();

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select c_id from course";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["c_id"].ToString());
            }
            conn.Close();
        }*/
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.ReadOnly = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
        }
    }
}

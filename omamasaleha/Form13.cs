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
    public partial class Form13 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
        string query;
       
        string ty = Form1.UserType;
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            this.Location = new Point(250, 90);
            if (ty == "Admin")
            {
                button1.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                button2.Visible = true;
                button5.Visible = false;
            }
            else
            {
                button1.Visible = false;
                label2.Visible = false;
                textBox1.Visible = false;
                button2.Visible = false;
                button5.Visible = true;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string id = textBox1.Text;
                string type = comboBox1.SelectedItem.ToString();

                query = "SELECT fd.*, s.name FROM fee_details fd " +
                 "INNER JOIN student s ON fd.id = s.id " +
                 "WHERE fd.id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    richTextBox1.Clear();
                    richTextBox1.SelectionFont = new Font("Times New Roman", 16, FontStyle.Bold); 
                    richTextBox1.Text += "*******************************************\n";
                    richTextBox1.Text += "******  FEE RECEIPT SYSTEM    ******\n";
                    richTextBox1.Text += "*******************************************\n";
                    richTextBox1.Text += "Issue Date : " + DateTime.Now.Date + "\n\n";
                    richTextBox1.Text += "FEE ID: " + dr["fee_id"] + "\n \n";
                    richTextBox1.Text += "Student ID: " + dr["id"] + "\n\n";
                    richTextBox1.Text += "Student Name: " + dr["name"] + "\n\n";

                    richTextBox1.Text += "Semester: " + dr["semester_id"] + "\n\n";
                    richTextBox1.Text += "Bank name: " + dr["bank_name"] + "\n\n";
                    richTextBox1.Text += "Extra charges: " + dr["extra_charges"] + "\n\n";
                    double extraCharges = Convert.ToDouble(dr["extra_charges"]);
                    double totalFee = 0;

                    if (type == "study_charges")
                    {
                        richTextBox1.Text += "Tuition Fee: " + dr["study_charges"] + "\n";
                        totalFee = Convert.ToDouble(dr["study_charges"]) + extraCharges;
                        richTextBox1.Text += "\n************************************ \n";
                        richTextBox1.Text += "Total Fee: $" + totalFee + "\n\n";
                    }
                    else if (type == "hostel_charges")
                    {
                        richTextBox1.Text += "Hostel Charges: " + dr["hostel_charges"] + "\n";
                        totalFee = Convert.ToDouble(dr["hostel_charges"]) + extraCharges;
                        richTextBox1.Text += "\n************************************ \n";
                        richTextBox1.Text += "Total Fee: $" + totalFee + "\n\n";
                    }
                   

                    richTextBox1.Text += "Due Date\time: " + dr["due_date"] + "\n\n";


                }
                else
                {
                    richTextBox1.Text += "Student not found.";
                }
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
        public void useer()
        {
            conn.Open();
            try
            {
                

                String id = Form1.std;
                string type = comboBox1.SelectedItem.ToString();
               // string type = comboBox1.SelectedItem?.ToString();
                query = "SELECT fd.*, s.name FROM fee_details fd " +
                 "INNER JOIN student s ON fd.id = s.id " +
                 "WHERE fd.id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    richTextBox1.Clear();
                    richTextBox1.SelectionFont = new Font("Times New Roman", 16, FontStyle.Bold);
                    richTextBox1.Text += "*******************************************\n";
                    richTextBox1.Text += "******  FEE RECEIPT SYSTEM    ******\n";
                    richTextBox1.Text += "*******************************************\n";
                    richTextBox1.Text += "Issue Date : " + DateTime.Now.Date + "\n\n";
                    richTextBox1.Text += "FEE ID: " + dr["fee_id"] + "\n \n";
                    richTextBox1.Text += "Student ID: " + dr["id"] + "\n\n";
                    richTextBox1.Text += "Student Name: " + dr["name"] + "\n\n";

                    richTextBox1.Text += "Semester: " + dr["semester_id"] + "\n\n";
                    richTextBox1.Text += "Bank name: " + dr["bank_name"] + "\n\n";
                    richTextBox1.Text += "Extra charges: " + dr["extra_charges"] + "\n\n";
                    double extraCharges = Convert.ToDouble(dr["extra_charges"]);
                    double totalFee = 0;
                    if (type == "study_charges")
                    {
                        richTextBox1.Text += "Tuition Fee: " + dr["study_charges"] + "\n";
                        totalFee = Convert.ToDouble(dr["study_charges"]) + extraCharges;
                        richTextBox1.Text += "\n************************************ \n";
                        richTextBox1.Text += "Total Fee: $" + totalFee + "\n\n";

                    }
                    else if (type == "hostel_charges")
                    {
                        richTextBox1.Text += "Hostel Charges: " + dr["hostel_charges"] + "\n";
                        totalFee = Convert.ToDouble(dr["hostel_charges"]) + extraCharges;
                        richTextBox1.Text += "\n************************************ \n";
                        richTextBox1.Text += "Total Fee: $" + totalFee + "\n\n";
                    }
                  

                    richTextBox1.Text += "Due Date\time: " + dr["due_date"] + "\n\n";
                    richTextBox1.Text += "\n \n \n \n \n \n \n \t"; 
                   
                    


                }
                else
                {
                    richTextBox1.Text += "Student not found.";
                }
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
       
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            
            richTextBox1.Clear();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new Font("Microsoft Sans Serif", 18, FontStyle.Bold),Brushes.Black,new Point(10,10));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            useer();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

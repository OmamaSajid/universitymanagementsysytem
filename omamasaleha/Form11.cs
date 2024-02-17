using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace omamasaleha
{
    public partial class Form11 : Form
    {
        string randomcode;
        public static string to;
        string query;
        function fn = new function();
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");


        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            this.Location = new Point(250, 90);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();
                string email = textBox1.Text;
                query = "select * from student where email=@email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string from, password, messagebody;
                    Random rand = new Random();
                    randomcode = (rand.Next(999999)).ToString();
                    MailMessage message = new MailMessage();
                    to = (textBox1.Text).ToString();
                    from = "omamasajid345@gmail.com";
                    password = "apww kcan ftat lmdy";
                    messagebody = $"your recovery code is{randomcode}";
                    message.To.Add(to);
                    message.From = new MailAddress(from);
                    message.Body = messagebody;
                    message.Subject = "PASSWORD RESET CODE";
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                    smtpClient.EnableSsl = true;
                    smtpClient.Port = 587;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Credentials = new NetworkCredential(from, password);
                    try
                    {
                        smtpClient.Send(message);
                        MessageBox.Show("code successfully send");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("incorret credentials");
                }
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
        private bool IsValidEmail(string email)
        {
            
            string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (randomcode == (textBox3.Text).ToString())
            {
                to = textBox1.Text;
                Form12 form12 = new Form12();
                form12.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("wrong recovery code");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

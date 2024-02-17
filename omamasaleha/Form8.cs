using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace omamasaleha
{
    public partial class Form8 : Form
    {
        function fn=new function();
        string query;
        DataSet ds;
        string usertype = Form1.UserType;
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            this.Location = new Point(250, 90);
            Random rand = new Random();
            int randomnum = rand.Next();
            textBox3.Text = randomnum.ToString();
            if (usertype == "Admin")
            {
                label9.Visible = true;
            }
            else
            {
                label9.Visible = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsValidEmail(textBox5.Text))
            {
                MessageBox.Show("Invalid email format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            else
            {
                string query = "insert into student(id,name,father_name,address,email,phoneno) values(@id,@name,@father_name,@address,@email,@phoneno)";
                string msg = "inserted succesfully";
                string Id = textBox3.Text;
                string father = textBox2.Text;
                string address = textBox4.Text;
                string email = textBox5.Text;
                string phoneno = textBox6.Text;
                string name = textBox1.Text;
                fn.stddata(query, msg, Id, name, father, address, email, phoneno);
            }
           

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.ReadOnly = true;

        }
        private bool IsValidEmail(string email)
        {
            
            string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

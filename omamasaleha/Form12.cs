using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace omamasaleha
{
    public partial class Form12 : Form
    {
        string query;
        function fn = new function();
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            this.Location = new Point(250, 90);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            query= "update login set student_id=@student_id, password=@password where student_id=@student_id";
            string id = textBox1.Text;
            string pass = textBox2.Text;
            string message = "resetted password successfully";
            fn.logindata(query, message, id, pass);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

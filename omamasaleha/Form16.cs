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
    public partial class Form16 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
        string query;
        DataSet ds;
        function fn = new function();
        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            string id = Form1.std;
            query = "select Discrete,database_subject,oop_subject,DLD_subject,stats_subject from attendance";
            ds = fn.getdata(query);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form17 f = new Form17();
            f.Show();
            this.Hide();
        }
    }
}

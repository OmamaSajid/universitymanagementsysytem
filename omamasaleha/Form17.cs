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
using System.Windows.Forms.DataVisualization.Charting;

namespace omamasaleha
{
    public partial class Form17 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
        string idd = Form1.std;

        public Form17()
        {
            InitializeComponent();
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            // DisplayAttendanceChart("2");
            DisplayAttendanceChart(idd);


        }
        private void DisplayAttendanceChart(string id)
        {

            try
            {
                conn.Open();

                string query = $"SELECT Discrete, database_subject, oop_subject, DLD_subject,stats_subject FROM attendance WHERE id = @id";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    chart1.Series.Clear();

                    foreach (string subject in new string[] { "Discrete", "database_subject", "oop_subject", "DLD_subject", "stats_subject" })
                    {
                        Series series = new Series(subject);
                        series.ChartType = SeriesChartType.Column;


                        string attendanceStatus = reader[subject].ToString();


                        double height = GetColumnHeight(attendanceStatus);
                        series.Points.AddXY(subject, height);

                        chart1.Series.Add(series);
                    }
                }
                else
                {
                    MessageBox.Show("No attendance data found for the specified ID.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }
        private double GetColumnHeight(string attendanceStatus)
        {

            switch (attendanceStatus)
            {
                case "Present":
                    return 1.0;
                case "Absent":
                    return 0.5;
                case "Leave":
                    return 0.75;
                default:
                    return 0.0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form14 f = new Form14();
           
            this.Hide();
        }
    }
}

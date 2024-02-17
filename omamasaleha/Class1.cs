using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;
using System.Xml.Linq;

namespace omamasaleha
{
    internal class function
    {
        public SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-L0742M3; Initial Catalog= project; Trusted_Connection=True");
            return conn;

        }
        public DataSet getdata(String query)
        {
            SqlConnection con = GetConnection();
           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void setdata(String query, String msg)
        {
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
               
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                con.Close();
            }
        }
        public void advdata(string query,string msg,string adv_id,string adv_name,string class_under_advisory,string adv_officeno)
        {
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@adv_id", int.Parse(adv_id));
                cmd.Parameters.AddWithValue("@adv_name", adv_name);
                cmd.Parameters.AddWithValue("@class_under_advisory", class_under_advisory);
                cmd.Parameters.AddWithValue("@adv_officeno", adv_officeno);
                cmd.ExecuteNonQuery();
                
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                con.Close();
            }
        }
        public void prgmdata(string query, string msg, string program_id, string bachelors, string masters, string phd)
        {
           
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@program_id", int.Parse(program_id));
                cmd.Parameters.AddWithValue("@bachelors", bachelors);
                cmd.Parameters.AddWithValue("@masters", masters);
                cmd.Parameters.AddWithValue("@phd", phd);
                //cmd.Parameters.AddWithValue("@dept_id", dept_id);

                cmd.ExecuteNonQuery();
               
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                con.Close();
            }
        }
        public void dptdata(string query, string msg, string dept_id, string dpt_name, string faculty_no)
        {
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@dept_id", int.Parse(dept_id));
                cmd.Parameters.AddWithValue("@dpt_name", dpt_name);
                cmd.Parameters.AddWithValue("@faculty_no", faculty_no);
                cmd.ExecuteNonQuery();
                
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                con.Close();
            }
        }
        public void logindata(string query, string msg, string student_id, string password)
        {
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@student_id", int.Parse(student_id));
                cmd.Parameters.AddWithValue("@password", password);
                cmd.ExecuteNonQuery();
                
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                con.Close();
            }
        }
        public void instdata(string query, string msg, string inst_id,string  inst_name, string qualification, string inst_phoneno, string inst_email, string inst_address)
        {
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@inst_id", int.Parse(inst_id));
                cmd.Parameters.AddWithValue("@inst_name", inst_name);
                cmd.Parameters.AddWithValue("@qualification", qualification);
                cmd.Parameters.AddWithValue("@inst_phoneno", int.Parse(inst_phoneno));
                cmd.Parameters.AddWithValue("@inst_email", inst_email);
                cmd.Parameters.AddWithValue("@inst_address", inst_address);
                cmd.ExecuteNonQuery();
                
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                con.Close();
            }
        }
        public void stddata(string query, string msg, string id,string name,string father_name, string address,string email,string phoneno ) { 
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", int.Parse(id));
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@father_name", father_name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phoneno", int.Parse(phoneno));
                cmd.ExecuteNonQuery();

                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
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
                con.Close();
            }
        }
        public void stdata(string query, string msg, string id,  string address, string email, string phoneno)
        {
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", int.Parse(id));
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phoneno", int.Parse(phoneno));
                cmd.ExecuteNonQuery();

                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                con.Close();
            }
        }
        public void coursedata(string query, string msg, string c_reg_id,string c_year,string  reg_startdate, string c_id, string id)
        {
            SqlConnection con = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@c_reg_id", int.Parse(id));
                cmd.Parameters.AddWithValue("@c_year", int.Parse(c_year));
                cmd.Parameters.AddWithValue("@reg_startdate", DateTime.Parse(reg_startdate));
                cmd.Parameters.AddWithValue("@c_id", int.Parse(c_id));
                cmd.Parameters.AddWithValue("@id", int.Parse(id));
                cmd.ExecuteNonQuery();
                
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                con.Close();
            }
        }
    }
}

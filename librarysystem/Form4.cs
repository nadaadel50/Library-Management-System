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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace librarysystem
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-2F27L5N\\SQLEXPRESS;Initial Catalog=libraryManagementSystem;Integrated Security=True;");

            connect.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO LIBRARY_BRANCH VALUES  (@BranchId, @BranchName, @Location, @WorkHours, @ContactInfo)", connect);
            cmd.Parameters.AddWithValue("@BranchId", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@BranchName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Location", textBox3.Text);
            cmd.Parameters.AddWithValue("@WorkHours", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@ContactInfo", decimal.Parse(textBox5.Text));

            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Successfully Saved.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-2F27L5N\\SQLEXPRESS;Initial Catalog=libraryManagementSystem;Integrated Security=True;");

            connect.Open();
            SqlCommand cmd = new SqlCommand("UPDATE LIBRARY_BRANCH SET  BRANCH_NAME = @BranchName, LOCATION = @Location, WORK_HOURS =  @WorkHours, CONTACT_INFO = @ContactInfo WHERE BRANCH_ID = @BranchId ", connect);
            cmd.Parameters.AddWithValue("@BranchId", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@BranchName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Location", textBox3.Text);
            cmd.Parameters.AddWithValue("@WorkHours", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@ContactInfo", decimal.Parse(textBox5.Text));

            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Successfully Updated.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-2F27L5N\\SQLEXPRESS;Initial Catalog=libraryManagementSystem;Integrated Security=True;");

            connect.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM LIBRARY_BRANCH WHERE BRANCH_ID = @BranchId", connect);
            cmd.Parameters.AddWithValue("@BranchId", int.Parse(textBox1.Text));

            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Successfully Deleted.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-2F27L5N\\SQLEXPRESS;Initial Catalog=libraryManagementSystem;Integrated Security=True;");

            connect.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM LIBRARY_BRANCH", connect);
            

            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Successfully Deleted All Records.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin_Control adminControl = new Admin_Control();
            adminControl.Show();
        }
    }
}

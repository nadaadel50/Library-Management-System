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

namespace librarysystem
{
    public partial class Form1 : Form
    {
        //static string ConnectionString = "Server=localhost;Database=libraryManagmentSystem;Integrated Security=True";
        //SqlConnection connect = new SqlConnection(ConnectionString);


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        //sign up 
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-2F27L5N\\SQLEXPRESS;Initial Catalog=libraryManagementSystem;Integrated Security=True;");
            connect.Open();
            if (radioButton2.Checked)
            {
                string query = "INSERT INTO [STUDENT] VALUES(@id ,@fname ,@lName,@address ,@email)";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@id", textBox3.Text);
                cmd.Parameters.AddWithValue("@fName", textBox1.Text);
                cmd.Parameters.AddWithValue("@lName", textBox2.Text);
                cmd.Parameters.AddWithValue("@address", textBox5.Text);
                cmd.Parameters.AddWithValue("@email", textBox4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student Data inserted successfully !");
                Borrow borrow = new Borrow();
                borrow.Show();

            }
            else if (radioButton1.Checked)
            {
                {
                    string query = "INSERT INTO [ADMIN] VALUES (@id ,@fName ,@lName,@email ,@address)";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@id", textBox3.Text);
                    cmd.Parameters.AddWithValue("@fName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@lName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@address", textBox5.Text);
                    cmd.Parameters.AddWithValue("@email", textBox4.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Admin Data inserted successfully !");
                    Admin_Control adminControl = new Admin_Control();
                    adminControl.Show();
                }
                connect.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
                

        

    

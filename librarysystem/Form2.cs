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

namespace librarysystem
{
    public partial class Form2 : Form
    {
        //static string ConnectionString = "Server=localhost;Database=libraryManagmentSystem;Integrated Security=True";
        //SqlConnection con = new SqlConnection(ConnectionString);
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-2F27L5N\\SQLEXPRESS;Initial Catalog=libraryManagementSystem;Integrated Security=True;");
            connect.Open();

            String query = "INSERT INTO [BOOK] (BOOK_ID, PUBLISHER_ID, BOOK_NAME, PRICE, CATEGORY, ISBN, PUBLICATION_YEAR) VALUES (@BOOK_ID, @PUBLISHER_ID, @BOOK_NAME, @PRICE, @CATEGORY, @ISBN, @PUBLICATION_YEAR)";
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@BOOK_ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@PUBLISHER_ID", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@BOOK_NAME", textBox3.Text);
            cmd.Parameters.AddWithValue("@PRICE", decimal.Parse(textBox7.Text));  
            cmd.Parameters.AddWithValue("@CATEGORY", textBox4.Text);
            cmd.Parameters.AddWithValue("@ISBN", textBox5.Text);
            cmd.Parameters.AddWithValue("@PUBLICATION_YEAR", int.Parse(textBox6.Text));  

            cmd.ExecuteNonQuery();
            MessageBox.Show("Book Added successfully !");
            connect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-2F27L5N\\SQLEXPRESS;Initial Catalog=libraryManagementSystem;Integrated Security=True;");
            connect.Open();

            SqlCommand cmd = new SqlCommand("UPDATE BOOK SET BOOK_ID = @BOOK_ID, PUBLISHER_ID = @PUBLISHER_ID, BOOK_NAME= @BOOK_NAME, PRICE = @PRICE, CATEGORY = @CATEGORY, ISBN = @ISBN, PUBLICATION_YEAR = @PUBLICATION_YEAR WHERE BOOK_ID = @BOOK_ID", connect);
            cmd.Parameters.AddWithValue("@BOOK_ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@PUBLISHER_ID", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@BOOK_NAME", textBox3.Text);
            cmd.Parameters.AddWithValue("@PRICE", decimal.Parse(textBox7.Text));  
            cmd.Parameters.AddWithValue("@CATEGORY", textBox4.Text);
            cmd.Parameters.AddWithValue("@ISBN", textBox5.Text);
            cmd.Parameters.AddWithValue("@PUBLICATION_YEAR", int.Parse(textBox6.Text));  

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated.");
            connect.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-2F27L5N\\SQLEXPRESS;Initial Catalog=libraryManagementSystem;Integrated Security=True;");

            connect.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM BOOK WHERE BOOK_ID = @BOOK_ID", connect);
            cmd.Parameters.AddWithValue("@BOOK_ID", int.Parse(textBox1.Text));

            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Successfully Deleted.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-2F27L5N\\SQLEXPRESS;Initial Catalog=libraryManagementSystem;Integrated Security=True;");

            connect.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM BOOK", connect);
      
            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Successfully Deleted All Records From BOOK Table.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin_Control adminControl = new Admin_Control();
            adminControl.Show();
        }

    }
}

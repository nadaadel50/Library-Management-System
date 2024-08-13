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
    public partial class Borrow : Form
    {
        public Borrow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-2F27L5N\\SQLEXPRESS;Initial Catalog=libraryManagementSystem;Integrated Security=True;");

            connect.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO BORROW VALUES  (@BookId, @StudentId, @BorrowDate, @ReturnDate)", connect);
            cmd.Parameters.AddWithValue("@BookId", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@StudentId", textBox2.Text);
            cmd.Parameters.AddWithValue("@BorrowDate", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@ReturnDate", int.Parse(textBox4.Text));

            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Successfully Borrowed.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-2F27L5N\\SQLEXPRESS;Initial Catalog=libraryManagementSystem;Integrated Security=True;");

            connect.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM BORROW WHERE BOOK_ID = @BookId", connect);
            cmd.Parameters.AddWithValue("@BookId", int.Parse(textBox1.Text));

            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Successfully Returned.");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string connectionString = "Data Source=DESKTOP-2F27L5N\\SQLEXPRESS;Initial Catalog=libraryManagementSystem;Integrated Security=True;";


            string query = $"SELECT * FROM BORROW";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                }
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-2F27L5N\\SQLEXPRESS;Initial Catalog=libraryManagementSystem;Integrated Security=True;";


            string query = $"SELECT * FROM BORROW AS a INNER JOIN STUDENT AS b ON a.STUDENT_ID = b.STUDENT_ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-2F27L5N\\SQLEXPRESS;Initial Catalog=libraryManagementSystem;Integrated Security=True;";


            string query = $"SELECT * FROM BORROW AS a LEFT JOIN STUDENT AS b ON a.STUDENT_ID = b.STUDENT_ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-2F27L5N\\SQLEXPRESS;Initial Catalog=libraryManagementSystem;Integrated Security=True;";


            string query = $"SELECT * FROM BORROW AS a RIGHT JOIN STUDENT AS b ON a.STUDENT_ID = b.STUDENT_ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                }
            }
        }
    }
}

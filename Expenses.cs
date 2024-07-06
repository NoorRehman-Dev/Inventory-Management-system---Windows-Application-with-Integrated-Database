using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Shop
{
    public partial class Expenses : Form
    {
        public Expenses()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(connection.Get());

        private void Expenses_Load(object sender, EventArgs e)
        {
            fetchData();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Category_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void expense1_Load(object sender, EventArgs e)
        {

        }
       

        private void label8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check if the user clicked Yes
            if (result == DialogResult.Yes)
            {
                // If yes, exit the application
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LOGIN lg = new LOGIN();
            lg.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            Attendants att = new Attendants();
            att.Show();
            await Task.Delay(500);
            this.Hide();
        }

        private void Add_Click(object sender, EventArgs e)
        {

            try
            {
                if (Box1.Text == "" || Box2.Text == "" || Box3.Text == "" || Box4.Text == "" || Box5.Text == "" || Box6.Text == "")
                {
                    MessageBox.Show("Can't Add !\t\n Missing Info");
                }
                else
                {
                    Con.Open();
                    String query = "INSERT INTO Expense (ExpenseId, ExpenseName, Cost_of_1_product, Quantity, TotalAmount, Date) " +
                                   "VALUES ('" + Box1.Text + "', '" + Box2.Text + "', " + Box3.Text + ", '" + Box4.Text + "', " + Box5.Text + ", '" + Box6.Text + "')";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Expense Added Successfully");
                    Con.Close();
                    Box1.Text = "";
                    Box2.Text = "";
                    Box3.Text = "";
                    Box4.Text = "";
                    Box5.Text = "";
                    Box6.Text = "";
                    fetchData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                if (Box1.Text == "")
                {
                    MessageBox.Show("Missing Info");
                }
                else
                {
                    Con.Open();
                    String query = "UPDATE Expense SET ExpenseName=@ExpenseName, Cost_of_1_product=@Cost_of_1_product, Quantity=@Quantity, Date=@Date, TotalAmount=@TotalAmount WHERE ExpenseID=@ExpenseID";
                    SqlCommand command = new SqlCommand(query, Con);

                    // Use parameterized queries to prevent SQL injection
                    command.Parameters.AddWithValue("@ExpenseName", Box2.Text);
                    command.Parameters.AddWithValue("@Cost_of_1_product", Convert.ToDouble(Box3.Text)); // Assuming Cost_of_1_product is numeric
                    command.Parameters.AddWithValue("@Quantity", Convert.ToInt32(Box4.Text)); // Assuming Quantity is integer
                    command.Parameters.AddWithValue("@Date", Convert.ToDateTime(Box6.Text)); // Assuming Date is datetime
                    command.Parameters.AddWithValue("@TotalAmount", Convert.ToDouble(Box5.Text)); // Assuming TotalAmount is numeric
                    command.Parameters.AddWithValue("@ExpenseID", Convert.ToInt32(Box1.Text)); // Assuming ExpenseID is integer

                    command.ExecuteNonQuery();
                    MessageBox.Show("Expense is Updated Successfully");
                    Con.Close();
                    Box1.Text = "";
                    Box2.Text = "";
                    Box3.Text = "";
                    Box4.Text = "";
                    Box5.Text = "";
                    Box6.Text = "";
                    fetchData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Box1.Text == "")
                {
                    MessageBox.Show("Product Not Selected \nPlease select the Product to delete");
                }
                else
                {
                    Con.Open();
                    String query = "delete from Expense where ExpenseID=" + Box1.Text + "";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Expense Deleted Successfully");
                    Con.Close();
                    Box1.Text = "";
                    Box2.Text = "";
                    Box3.Text = "";
                    Box4.Text = "";
                    Box5.Text = "";
                    Box6.Text = "";
                    fetchData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            Box1.Text = String.Empty;
            Box2.Text = String.Empty;
            Box3.Text = String.Empty;
            Box4.Text = String.Empty;
            Box5.Text = String.Empty;
            Box6.Text = String.Empty;
        }

        private void Searching_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Expense WHERE ExpenseID=@ExpenseID", Con))
                {
                    Con.Open();
                    cmd.Parameters.AddWithValue("@ExpenseID", Box1.Text);
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void Referesh_Click(object sender, EventArgs e)
        {
            fetchData();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Category att = new Category();
            att.Show();
            await Task.Delay(500);
            this.Hide();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            Forms att = new Forms();
            att.Show();
            await Task.Delay(500);
            this.Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            History att = new History();
            att.Show();
            await Task.Delay(500);
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private async void button8_Click(object sender, EventArgs e)
        {
            Refunds att = new Refunds();
            att.Show();
            await Task.Delay(500);
            this.Hide();
        }
        private void fetchData()
        {
            Con.Open();
            string query = "select * from Expense";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var data = new DataSet();
            sda.Fill(data);
            dataGridView2.DataSource = data.Tables[0];
            Con.Close();

        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Box1.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            Box2.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            Box3.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            Box4.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
            Box5.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
            Box6.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}

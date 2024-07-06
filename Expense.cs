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
using System.Runtime.InteropServices;
namespace Shop
{
    public partial class Expense : UserControl
    {
        public Expense()
        {
            InitializeComponent();
        }
        

        private void label8_Click(object sender, EventArgs e)
        {
            // Access the parent form directly
             ParentForm.WindowState = FormWindowState.Minimized;
           
        }
        SqlConnection Con = new SqlConnection(connection.Get());
        private FormWindowState WindowState;

        private void Box1_TextChanged(object sender, EventArgs e)
        {

        }
        private void fetchData()
        {
            Con.Open();
            string query = "SELECT ExpenseID , ExpenseName , Cost_of_1_product , Quantity, Date, TotalAmount FROM Expense";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var data = new DataSet();
            sda.Fill(data);
            dataGridView2.DataSource = data.Tables[0];

           

            Con.Close();

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

        private void refresh_Click(object sender, EventArgs e)
        {
            fetchData();
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

        private async void button3_Click(object sender, EventArgs e)
        {
            Attendants att = new Attendants();
            att.Show();
            await Task.Delay(500);
            this.Hide();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Category ct = new Category();
            ct.Show();
            await Task.Delay(500);
            this.Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            Forms f = new Forms();
            f.Show();
            await Task.Delay(500);
            this.Hide();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            Forms pd = new Forms();
            pd.Show();
            await Task.Delay(500);
            this.Hide();
        }




        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LOGIN lg = new LOGIN();
            lg.Show();
            this.Hide();
        }

        private void Expense_Load(object sender, EventArgs e)
        {
            fetchData();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                Box1.Text = row.Cells[0].Value.ToString();
                Box2.Text = row.Cells[1].Value.ToString();
                Box3.Text = row.Cells[2].Value.ToString();
                Box4.Text = row.Cells[3].Value.ToString();
                Box6.Text = row.Cells[4].Value.ToString();
                Box5.Text = row.Cells[5].Value.ToString();
            }
        }

        private void Referesh_Click(object sender, EventArgs e)
        {
            fetchData();
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            Refunds pd = new Refunds();
            pd.Show();
            await Task.Delay(500);
            this.Hide();
        }
    }
}

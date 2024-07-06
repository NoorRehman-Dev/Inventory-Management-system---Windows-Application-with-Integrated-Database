using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop
{
    public partial class Refunds : Form
    {
        public Refunds()
        {
            InitializeComponent();
        }

        private void Refunds_Load(object sender, EventArgs e)
        {
            FetchCat();
            FetchCat2();
            fetchData();
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
            History h = new History();
            h.Show();
            await Task.Delay(500);
            this.Hide();
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            Expenses h = new Expenses();
            h.Show();
            await Task.Delay(500);
            this.Hide();
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            Forms h = new Forms();
            h.Show();
            await Task.Delay(500);
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check if the user clicked Yes
            if (result == DialogResult.Yes)
            {
                // If yes, exit the application
                Application.Exit();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }
        SqlConnection Con = new SqlConnection(connection.Get());
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Forms_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void fetchDataSpecificText()
        {
            Con.Open();
            string query = "select * from ProdTable1 where ProdName like '" + "%" + search.Text + "%" + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var data = new DataSet();
            sda.Fill(data);
            prodList.DataSource = data.Tables[0];
            Con.Close();
        }

        private void FetchCat()
        {
            Con.Open();
            String query = "select CatName from CatTable1";
            SqlCommand command = new SqlCommand(query, Con);
            SqlDataReader read;
            read = command.ExecuteReader();
            DataTable data = new DataTable();
            data.Columns.Add("CatName", typeof(string));
            data.Load(read);
            category.ValueMember = "catName";
            category.DataSource = data;
            Con.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            LOGIN lg = new LOGIN();
            lg.Show();
            this.Hide();
        }
        private void FetchCat2()
        {
            Con.Open();
            String query = "select CatName from CatTable1";
            SqlCommand command = new SqlCommand(query, Con);
            SqlDataReader read;
            read = command.ExecuteReader();
            DataTable data = new DataTable();
            data.Columns.Add("CatName", typeof(string));
            data.Load(read);
            categoryS.ValueMember = "catName";
            categoryS.DataSource = data;
            Con.Close();
        }
        private void fetchDataSpecific()
        {
            Con.Open();
            string query = "select * from ProdTable1 where Category='" + categoryS.SelectedValue.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var data = new DataSet();
            sda.Fill(data);
            prodList.DataSource = data.Tables[0];
            Con.Close();
        }
        private void prodaddbtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (prodname.Text == "" || quantity.Text == "" || price.Text == "" || category.Text == "")
                {
                    MessageBox.Show("Can't Add !\t\n Missing Info");
                }
                else
                {
                    Con.Open();
                    String query = "insert into ProdTable1 (ProdName, Quantity, Price, Category) values ('" + prodname.Text + "'," + quantity.Text + "," + price.Text + ",'" + category.Text + "')";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product Added Successfully");
                    Con.Close();
                    prodid.Text = "";
                    prodname.Text = "";
                    quantity.Text = "";
                    price.Text = "";
                    tid.Text = "";
                    tqty.Text = "";
                    fetchData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }

        private void prodList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void prodList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            prodid.Text = prodList.SelectedRows[0].Cells[0].Value.ToString();
            prodname.Text = prodList.SelectedRows[0].Cells[1].Value.ToString();
            quantity.Text = prodList.SelectedRows[0].Cells[2].Value.ToString();
            price.Text = prodList.SelectedRows[0].Cells[3].Value.ToString();
            category.Text = prodList.SelectedRows[0].Cells[4].Value.ToString();
            tid.Text = prodList.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void prodeditbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (prodid.Text == "")
                {
                    MessageBox.Show("Product Not Selected \nPlease select the product to edit");
                }
                else
                {
                    Con.Open();
                    String query = "update ProdTable1 set ProdName='" + prodname.Text + "', Quantity=" + quantity.Text + ", Price=" + price.Text + ", Category='" + category.Text + "'where ProdID=" + prodid.Text + ";";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product Edited Successfully");
                    Con.Close();
                    prodid.Text = "";
                    prodname.Text = "";
                    quantity.Text = "";
                    price.Text = "";
                    tid.Text = "";
                    tqty.Text = "";
                    fetchData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }

        private void proddelbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (prodid.Text == "")
                {
                    MessageBox.Show("Product Not Selected \nPlease select the Product to delete");
                }
                else
                {
                    Con.Open();
                    String query = "delete from ProdTable1 where ProdID=" + prodid.Text + "";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted Successfully");
                    Con.Close();
                    prodid.Text = "";
                    prodname.Text = "";
                    quantity.Text = "";
                    price.Text = "";
                    tid.Text = "";
                    tqty.Text = "";
                    fetchData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (tqty.Text == "" || tid.Text == "")
                {
                    MessageBox.Show("Missing Info");
                }
                else
                {
                    Con.Open();
                    String query = "update ProdTable1 set Quantity = Quantity+" + Convert.ToInt32(tqty.Text) + " where ProdID=" + tid.Text + ";";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product Quantity Increased Successfully");
                    Con.Close();
                    prodid.Text = "";
                    prodname.Text = "";
                    quantity.Text = "";
                    price.Text = "";
                    tid.Text = "";
                    tqty.Text = "";
                    fetchData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            fetchDataSpecificText();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            fetchData();
        }
        private void fetchData()
        {
            Con.Open();
            string query = "select * from ProdTable1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var data = new DataSet();
            sda.Fill(data);
            prodList.DataSource = data.Tables[0];
            Con.Close();
        }

       
        private void categoryS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

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

namespace Shop
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(connection.Get());
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            username.Text = "";
            password.Text = "";
        }
       
        private async void loginbtn_Click(object sender, EventArgs e)
        {
            if (username.Text == "" || password.Text == "")
            {
                MessageBox.Show("\tMissing Credentials\t");
            }
            else if (role.SelectedIndex == -1)
            {
                MessageBox.Show("\tPlease select a role\t");
            }
            else
            {
                if (role.SelectedItem.ToString() == "ADMIN")
                {
                    string user = username.Text;
                    string pass = password.Text;
                    try
                    {
                        string query = "SELECT * FROM login_Owner WHERE username=@Username AND password=@Password";
                        SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                        sda.SelectCommand.Parameters.AddWithValue("@Username", user);
                        sda.SelectCommand.Parameters.AddWithValue("@Password", pass);

                        DataTable dtable = new DataTable();
                        sda.Fill(dtable);

                        if (dtable.Rows.Count > 0)
                        {
                            // If admin credentials are correct, perform necessary actions.
                            Attendants att = new Attendants();
                            Loading l = new Loading();
                            l.Show();
                            await Task.Delay(2000);
                            att.Show();
                            this.Hide();
                        }
                        else
                        {
                            // If admin credentials are incorrect, display an error message.
                            MessageBox.Show("\tAdmin Credentials Wrong\t");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                else if (role.SelectedItem.ToString() == "ATTENDANT")
                {
                    string user = username.Text;
                    string pass = password.Text;
                    try
                    {
                        string query = "SELECT * FROM AttTable WHERE AttName=@Username AND Password=@Password";
                        SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                        sda.SelectCommand.Parameters.AddWithValue("@Username", user);
                        sda.SelectCommand.Parameters.AddWithValue("@Password", pass);

                        DataTable dtable = new DataTable();
                        sda.Fill(dtable);

                        if (dtable.Rows.Count > 0)
                        {
                            // If attendant credentials are correct, open the selling form.
                            SellingForm sellingForm = new SellingForm();
                            sellingForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            // If attendant credentials are incorrect, display an error message.
                            MessageBox.Show("\tAttendant Credentials Wrong\t");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }




        }

        private void LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            ResetPasswordForm reset = new ResetPasswordForm();
            reset.Show();
            
        }
    }
    public static class Globals
    {
        static String NameOfUser;

        internal static string Get()
        {
            return NameOfUser;
        }

        internal static void Set(string text)
        {
            NameOfUser = text;
        }
    }
}

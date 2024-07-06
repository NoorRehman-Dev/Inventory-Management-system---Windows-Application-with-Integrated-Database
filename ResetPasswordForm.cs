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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Shop
{
    public partial class ResetPasswordForm : Form
    {
        public ResetPasswordForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(connection.Get());

        private void ResetPasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection Con = new SqlConnection(connection.Get())) // Use using statement for automatic disposal of connection
                {
                    Con.Open();
                    SqlCommand validateCmd = new SqlCommand("SELECT COUNT(*) FROM login_Owner WHERE username=@Username", Con);
                    validateCmd.Parameters.AddWithValue("@Username", user.Text); // Use the .Text property to get the text from the TextBox
                    int userCount = (int)validateCmd.ExecuteScalar();

                    if (userCount == 0)
                    {
                        MessageBox.Show("Username is incorrect. Please enter a valid username.");
                        return; // Stop further execution
                    }
                } // Close connection here

                // Continue with the rest of the code for password reset
                if (newPassword.Text == "" || confirmPassword.Text == "" || challenge.Text == "")
                {
                    MessageBox.Show("Please enter all the fields.");
                }
                else if (newPassword.Text != confirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match.");
                }
                else if (challenge.Text != "QANSHA") // Replace "QANSHA" with the actual challenge string
                {
                    MessageBox.Show("Wrong NickName of BESTFRIEND");
                }
                else
                {
                    using (SqlConnection Con = new SqlConnection(connection.Get())) // Use using statement for automatic disposal of connection
                    {
                        Con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE login_Owner SET Password=@Password WHERE username=@Username", Con);
                        cmd.Parameters.AddWithValue("@Password", newPassword.Text);
                        cmd.Parameters.AddWithValue("@Username", user.Text); // Use the .Text property to get the text from the TextBox
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Password RESET successful.");
                        this.Close();
                    } // Close connection here
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void display_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}

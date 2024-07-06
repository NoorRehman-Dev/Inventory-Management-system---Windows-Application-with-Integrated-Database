namespace Shop
{
    partial class ResetPasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.display = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.newPassword = new System.Windows.Forms.TextBox();
            this.confirmPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.challenge = new System.Windows.Forms.TextBox();
            this.clearbtn = new System.Windows.Forms.Button();
            this.loginbtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.TextBox();
            this.display.SuspendLayout();
            this.SuspendLayout();
            // 
            // display
            // 
            this.display.BackColor = System.Drawing.Color.Maroon;
            this.display.Controls.Add(this.challenge);
            this.display.Controls.Add(this.label6);
            this.display.Controls.Add(this.label2);
            this.display.Controls.Add(this.label1);
            this.display.Location = new System.Drawing.Point(1, -4);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(345, 469);
            this.display.TabIndex = 1;
            this.display.Paint += new System.Windows.Forms.PaintEventHandler(this.display_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 69);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(78, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reset";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(530, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 27);
            this.label3.TabIndex = 5;
            this.label3.Text = "ADMIN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(364, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "NEW PASSWORD";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(364, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "CONFIRM PASS.";
            // 
            // newPassword
            // 
            this.newPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPassword.Location = new System.Drawing.Point(565, 214);
            this.newPassword.Name = "newPassword";
            this.newPassword.Size = new System.Drawing.Size(220, 29);
            this.newPassword.TabIndex = 8;
            // 
            // confirmPassword
            // 
            this.confirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPassword.Location = new System.Drawing.Point(565, 269);
            this.confirmPassword.Name = "confirmPassword";
            this.confirmPassword.Size = new System.Drawing.Size(220, 29);
            this.confirmPassword.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Mongolian Baiti", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(11, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(329, 30);
            this.label6.TabIndex = 2;
            this.label6.Text = "Best Friend\'s NickName:";
            // 
            // challenge
            // 
            this.challenge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.challenge.Location = new System.Drawing.Point(61, 291);
            this.challenge.Name = "challenge";
            this.challenge.Size = new System.Drawing.Size(220, 29);
            this.challenge.TabIndex = 10;
            // 
            // clearbtn
            // 
            this.clearbtn.BackColor = System.Drawing.Color.White;
            this.clearbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearbtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.clearbtn.Location = new System.Drawing.Point(565, 357);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(92, 30);
            this.clearbtn.TabIndex = 10;
            this.clearbtn.Text = "CANCEL";
            this.clearbtn.UseVisualStyleBackColor = false;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // loginbtn
            // 
            this.loginbtn.BackColor = System.Drawing.Color.White;
            this.loginbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginbtn.ForeColor = System.Drawing.Color.Maroon;
            this.loginbtn.Location = new System.Drawing.Point(674, 357);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Size = new System.Drawing.Size(111, 30);
            this.loginbtn.TabIndex = 11;
            this.loginbtn.Text = "RESET";
            this.loginbtn.UseVisualStyleBackColor = false;
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(364, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "USER NAME";
            // 
            // user
            // 
            this.user.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.Location = new System.Drawing.Point(565, 156);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(220, 29);
            this.user.TabIndex = 13;
            // 
            // ResetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(821, 462);
            this.Controls.Add(this.user);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.loginbtn);
            this.Controls.Add(this.clearbtn);
            this.Controls.Add(this.confirmPassword);
            this.Controls.Add(this.newPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.display);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ResetPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResetPasswordForm";
            this.Load += new System.EventHandler(this.ResetPasswordForm_Load);
            this.display.ResumeLayout(false);
            this.display.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel display;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox newPassword;
        private System.Windows.Forms.TextBox confirmPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox challenge;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button loginbtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox user;
    }
}
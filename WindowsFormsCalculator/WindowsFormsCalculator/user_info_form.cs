using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsCalculator
{
    public partial class user_info_form : Form
    {
        private List<user> users = new List<user>(); //  list of users
        private user actual_user; // actual user logged in
        private Form login; // actual login instance
        public user_info_form(List<user> users, user u, Form login)
        {
            InitializeComponent();
            this.users = users;
            this.actual_user = u;
            this.login = login;
        }
        // textBox1 = USERNAME
        // textBox2 = NAME
        // textBox3 = EMAIL
        // textBox4 = PASSWORD
        // textBox5 = NUMBER OF OPERATIONS

        private void user_info_form_Load(object sender, EventArgs e) // we set the user information in the text boxes
        {
            textBox1.Text = this.actual_user.username;
            textBox2.Text = this.actual_user.name;
            textBox3.Text = this.actual_user.email;
            textBox4.Text = this.actual_user.password;
            textBox5.Text = this.actual_user.n_operations.ToString();
        }

        private void button15_Click(object sender, EventArgs e) // back to calculator
        {
            this.Close();
            calculator_form Calculator = new calculator_form(users, actual_user, this.login);
            Calculator.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.login.Show();
            this.Close();
        }
         private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != textBox2.Text) // the name and username are not the same
            {
                if (Program.PasswordOK(textBox4.Text) == 1) // Password is OK
                {
                    actual_user.username = textBox1.Text;
                    actual_user.name = textBox2.Text;
                    actual_user.password = textBox4.Text;

                    Program.Write_User_File(this.users);// We rewrite the user_file.txt with the new information
                    MessageBox.Show("Profile successfully saved!");
                }
                else { MessageBox.Show("Check out that passwords match or that it matches the requirements.\nAt least 8 characters long, including:\n  - One uppercase \n  - One lower case \n  - One number\n  - One special symbol"); }
            }
            else { MessageBox.Show("Username and name have to be different"); }
        }
    }
}

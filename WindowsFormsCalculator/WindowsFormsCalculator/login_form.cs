using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCalculator
{
    public partial class login_form : Form
    {
        private List<user> users = new List<user>(); //  list of users
        public login_form(List<user> users)
        {
            InitializeComponent();
            this.users = users;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // SING UP (REGISTER)
        {
            this.Hide(); // we hide the login form
            this.textBox1.Clear(); // we clear the textboxes
            this.textBox2.Clear();
            register_form Register = new register_form(users, this); // we open a register form
            Register.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // FORGOT PASSWORD?
        {
            this.Hide(); // we hide the login form
            this.textBox1.Clear(); // we clear the textboxes
            this.textBox2.Clear();
            password_recovery_form Register = new password_recovery_form(users, this); // we create a password recovery form
            Register.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // EXIT APPLICATION
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e) // BUTTON 
        {
            //When this button is clicked it checks there is a name and password that corresponds to a user
            int Flag = 0;
            int index = 0;
            int i = 0;
            foreach (user u in users)//We search in the users list for the specific username and password
            {
                if ((u.username == textBox1.Text && u.password == textBox2.Text))
                {
                    index = i;
                    Flag++;
                    break;
                }
                i++;
            }
            if (Flag > 0) // if the flag is up, we open the calculator form
            {
                this.Hide();
                this.textBox1.Clear();
                this.textBox2.Clear();
                calculator_form Calculator = new calculator_form(users, users[index], this);
                Calculator.Show();
            }
            else
            {
                MessageBox.Show("Password and user do not match");
            }
        }
    }
}

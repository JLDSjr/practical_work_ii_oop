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
    public partial class password_recovery_form : Form
    {
        private List<user> users = new List<user>(); //  list of users
        private Form login; // actual login instance
        public password_recovery_form(List<user> users, Form login)
        {
            InitializeComponent();
            this.users = users;
            this.login = login;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // BACK TO LOGIN
        {
            this.login.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) // SEND PASSWORD RECOVERY
        {
            int flag;
            int index;
            int i;

            flag = 0;
            index = 0;
            i = 0;
            foreach (user u in users)
            {
                if (u.username == textBox1.Text && u.name == textBox2.Text && u.email== textBox3.Text)
                {
                    index = i;
                    flag++;
                    break;
                }
                i++;
            }
            if (flag == 1)
            {
                if (Program.PasswordOK(textBox4.Text) == 1)
                {
                    this.users[index].password = textBox4.Text;
                    MessageBox.Show("Password changed successfully!");
                    Program.Write_User_File(users);// We rewrite the user_file.txt with the new password
                    this.login.Show();
                    this.Close();
                }
                else { MessageBox.Show("Check out that passwords match or that it matches the requirements.\nAt least 8 characters long, including:\n  - One uppercase \n  - One lower case \n  - One number\n  - One special symbol"); }
            }
            else { MessageBox.Show("User not found"); }
        }
    }
}

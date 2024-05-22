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
    public partial class register_form : Form
    {
        private List<user> users = new List<user>(); //  list of users
        private Form login; // actual login instance
        public register_form(List<user> users, Form login)
        {
            InitializeComponent();
            this.users = users;
            this.login = login;
        }
        // textBox1 = USERNAME
        // textBox2 = NAME
        // textBox3 = EMAIL
        // textBox4 = PASSWORD
        // textBox5 = REPEAT PASSWORD
        // checkBox1 = ACCPET TERMS AND CONDITIONS

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // BACK TO LOGIN
        {
            login.Show();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // READ TERMS AND CONDITIONS
        {
            MessageBox.Show("The teacher will approve the student :)\n\n\t      _.-'''''-._\r\n\t    .'  _     _  '.\r\n\t   /   (_)   (_)   \\\r\n\t  |  ,            ,  |\r\n\t  |  \\`.       .`/  |\r\n\t   \\  '.`'\"\"'\"`.'  /\r\n\t    '.  `'---'`  .'\r\n\t      '-.____.-'");
        }

        private void button1_Click(object sender, EventArgs e) // SEND INFORMATION
        {
            //When this button is clicked it checks if the user have the requirements to be added.
            int Flag = 0;
            foreach (user i in users)
            {
                if (i.username == textBox1.Text) { Flag++; }
            }
            if (Flag == 0) // the username doesn't exist
            {
                if (textBox1.Text != textBox2.Text) // the name and username are not the same
                {
                    if (checkBox1.Checked) // terms and conditions are accepted
                    {
                        if (Program.PasswordOK(textBox4.Text) == 1 && textBox4.Text == textBox5.Text) // Password is OK
                        {
                            users.Add(new user(textBox1.Text, textBox2.Text, textBox4.Text, textBox3.Text, 0));//We register a new user in the users list

                            Program.Write_User_File(users);// We rewrite the user_file.txt with the new user added

                            this.Close();
                            login_form Login = new login_form(users);
                            Login.Show();
                        }
                        else { MessageBox.Show("Check out that passwords match or that it matches the requirements.\nAt least 8 characters long, including:\n  - One uppercase \n  - One lower case \n  - One number\n  - One special symbol"); }
                    }
                    else{MessageBox.Show("Please accept terms and conditions");}
                }
                else { MessageBox.Show("Username and name have to be different"); }
            }
            else { MessageBox.Show("There's already an user with that username"); }
        }
    }
}

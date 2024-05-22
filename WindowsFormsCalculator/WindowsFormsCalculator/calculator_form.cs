using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsCalculator
{
    public partial class calculator_form : Form
    {
        private List<user> users = new List<user>(); //  list of users
        private user actual_user; // actual user logged in
        private calculator calc = new calculator();  // calculator instance for operations
        private Form login; // actual login instance

        public calculator_form(List<user> users, user u, Form login)
        {
            InitializeComponent();
            this.users = users;
            this.actual_user = u;
            this.login = login;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // SING OUT (back to login)
        {
            this.login.Show();
            this.Close();
        }

        private void button15_Click(object sender, EventArgs e) // USERINFO
        {
            this.Close();
            user_info_form UserInfo = new user_info_form(users, actual_user, this.login);
            UserInfo.Show();
        }

        private void button1_Click(object sender, EventArgs e) // 1
        {
            textBox1.Text += "1";
        }

        private void button6_Click(object sender, EventArgs e) // 2
        {
            textBox1.Text += "2";
        }

        private void button7_Click(object sender, EventArgs e) // 3
        {
            textBox1.Text += "3";
        }

        private void button5_Click(object sender, EventArgs e) // 4
        {
            textBox1.Text += "4";
        }

        private void button3_Click(object sender, EventArgs e) // 5
        {
            textBox1.Text += "5";
        }

        private void button8_Click(object sender, EventArgs e) // 6
        {
            textBox1.Text += "6";
        }

        private void button4_Click(object sender, EventArgs e) // 7
        {
            textBox1.Text += "7";
        }

        private void button2_Click(object sender, EventArgs e) // 8
        {
            textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e) // 9
        {
            textBox1.Text += "9";
        }

        private void button20_Click(object sender, EventArgs e) // 0
        {
            textBox1.Text += "0";
        }

        private void button19_Click(object sender, EventArgs e) // +/- (*(-1))
        {
            string text = textBox1.Text;
            string minus = "-";

            try
            {
                if (!textBox1.Text.Contains(" "))// if the string doesn't contain spaces means that the user is still with the first operand
                {
                    if (textBox1.Text[0] == '-')
                    {
                        string t = textBox1.Text.Substring(1, textBox1.Text.Length - 1);
                        textBox1.Text = t;
                    }
                    else
                    {
                        textBox1.Text = minus + text; // in that case we add a minus sign to the left of the string to change its sign
                    }
                }
                else // if not we add the minus sign to the left of the second operand
                {
                    string[] c = text.Split(' ');
                    if (c.Count() != 3)
                    {
                        MessageBox.Show("Invalid operation");
                    }
                    else
                    {
                        if (c[2][0] == '-')
                        {
                            string t = c[2].Substring(1, c[2].Length - 1);
                            c[2] = t;
                            textBox1.Text = c[0] + " " + c[1] + " " + c[2];
                        }
                        else
                        {
                            c[2] = minus + c[2];
                            textBox1.Text = c[0] + " " + c[1] + " " + c[2];
                        }
                    }
                }
            }
            catch { MessageBox.Show("Invalid operation"); }
        }
        private void button18_Click(object sender, EventArgs e) // , (decimals)
        {
            textBox1.Text += ",";
        }

        private void button10_Click(object sender, EventArgs e) // + (add)
        {
            textBox1.Text += " + ";
        }

        private void button11_Click(object sender, EventArgs e) // - (subtract)
        {
            textBox1.Text += " - ";
        }

        private void button12_Click(object sender, EventArgs e) // * (multiply)
        {
            textBox1.Text += " * ";
        }

        private void button17_Click(object sender, EventArgs e) // / (division)
        {
            textBox1.Text += " / ";
        }

        private void button13_Click(object sender, EventArgs e) // ^ (pow)
        {
            textBox1.Text += " ^ ";
        }

        private void button14_Click(object sender, EventArgs e) // % (modulus)
        {
            textBox1.Text += " % ";
        }

        private void button16_Click(object sender, EventArgs e) // = (equal)
        {
            string sol;

       
            sol = calc.Perform_operation(textBox1.Text); // we perform the operation
            if (sol != null) // if the operation is not null we proceed to show the solution to the user
            {
                textBox1.Text = sol; // we show the solution
                this.actual_user.n_operations += 1; // we add to the user profile n_operations that another operation was made
                Program.Write_User_File(this.users);// We rewrite the user_file.txt with the new information
            }
        }
        private void button21_Click(object sender, EventArgs e) // del (delete)
        {
            if (textBox1.Text.Length > 0)
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }
        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}

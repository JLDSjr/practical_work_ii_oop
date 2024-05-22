using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCalculator
{
    public class user
    {
        //In this class use encapsulation.

        //attributes
        public string username {  get; set; } //stores users username
        public string name { get; set; } //stores users name
        public string password {get; set;} //stores users password
        public string email { get; set;} // stores users email
        public int n_operations{ get; set;} // stores the number of operations made by a user

        //constructor
        public user() { }
        public user(string username ,string name, string password, string email, int n_operations)
        {
            this.username = username;
            this.name = name;
            this.password = password;
            this.email = email;
            this.n_operations = n_operations;

        }
    }
}

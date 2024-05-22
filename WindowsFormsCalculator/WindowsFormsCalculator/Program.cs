using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCalculator
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]

        public static void Write_User_File(List<user> users) // this function helps to write the file with all the users.
        {

            string separator = ",";//our separator will be a comma
            var path = "../../../../files/user_file.txt";//this is the .txt where the information is going to be saved


            if (File.Exists(path))
            {
                // Borra el contenido del archivo
                File.WriteAllText(path, "");
            }


            using (StreamWriter sw = new StreamWriter(path, true))
            {
                try//we make an exception in case we get an error
                {
                    foreach (user i in users)//we start writing all the users
                    {
                        sw.WriteLine(i.username + separator + i.name + separator + i.password + separator + i.email + separator + i.n_operations);
                    }

                }
                catch (Exception e)//if there is an error we will get an error message
                {
                    Console.WriteLine(e.Message);
                }
                finally//we close the .txt file
                {
                    sw.Close();
                }
            }
        }

        public static void Read_User_File(List<user> users) // this function helps to write the file with all the users.
        {
            int index_user = 0;//this will count the number of users 


            //This algorithim will read the user file 
            char separator = ','; // our separator is a comma
            var path = "../../../../files/user_file.txt"; // we will read from this file
            StreamReader sr_usuario = File.OpenText(path); // we open the file

            string line = "";
            while ((line = sr_usuario.ReadLine()) != null)
            {
                users.Add(new user() { });// We add a new user for every line of information
                string[] values = line.Split(separator);// We use the split function to divide the areas of information
                for (int i = 0; i < values.Length; i++)
                {
                    if (i == 0)
                    {
                        users[index_user].username = values[i]; // We set the username (postion 0)

                    }
                    if (i == 1)
                    {
                        users[index_user].name = values[i]; // name (position 1)

                    }
                    if (i == 2)
                    {
                        users[index_user].password = values[i]; // password (position 2)

                    }
                    if (i == 3)
                    {
                        users[index_user].email = values[i]; // email (position 3)

                    }
                    if (i == 4)
                    {
                        users[index_user].n_operations = int.Parse(values[i]); // number of operations (position 4)

                    }

                }
                index_user++;
            }
            sr_usuario.Close();

        }

        public static int PasswordOK(string Password)
        {
            // In this function the password introduced by the user will be checked to meet this requirements
            // Those are: More than 7 alphanumeric characters, and at leas 1 number, 1 uppercase, and 1 lowercase
            // It will return 1 if the password is correct and 0 if not

            // at least 8 characters long, including one upper and one lower case letter, one number, and one special symbol

            int symbol = 0;
            int capital = 0;
            int undercase = 0;
            int number = 0;
            for (int i = 0; i < Password.Length; i++)
            {
                char c = Password[i];
                if (char.IsSymbol(c) || c == '!' || c == '%' || c == '&' || c == '/' || c == '(' || c == ')' || c == '=' || c == '?' || c == '¿' || c == '¡' || c == '#' || c == '@')
                {
                    symbol++;
                }
                if (char.IsUpper(c))
                {
                    capital++;
                }
                if (char.IsLower(c))
                {
                    undercase++;
                }
                if (char.IsNumber(c))
                {
                    number++;
                }
            }
            if (Password.Length >= 8 && symbol > 0 && capital > 0 && undercase > 0 && number > 0) { return 1; }
            else { return 0; }

        }
        static void Main()
        {

            List<user> users = new List<user>();

            Read_User_File(users);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login_form(users));
        }
    }
}

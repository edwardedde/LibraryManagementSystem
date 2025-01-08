using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class User
    {
        ///create user account

        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User() { }

        public static void CreateAccount(User user)
        {
            Console.WriteLine("Username and password must be more than 6 symbols long");

            while (true)
            {

                Console.WriteLine("Insert a new username:");
                string username = Console.ReadLine();

                if (username.Length > 6)
                {
                    user.Username = username;

                    Console.WriteLine("Insert a new Password:");
                    string password = Console.ReadLine();
                    
                    if(password.Length > 6)
                    {
                        user.Password = password;
                        Console.WriteLine("User created, now you can use the system");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("password must be longer than 6 symbols");
                    }

                }
                else
                {
                    Console.WriteLine("username must be more than 6 symbols long, try again");
                }

            }


        }
    }
}

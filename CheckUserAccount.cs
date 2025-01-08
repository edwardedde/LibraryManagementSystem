using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class CheckUserAccount
    {
        
        public void Login(User user)
        {
            while (true)
            {
                Console.WriteLine("--Login--");

                Console.WriteLine("Enter username:");
                var check_username = Console.ReadLine();

                Console.WriteLine("Enterpassword:");
                var check_password = Console.ReadLine();

                if (check_username == user.Username && check_password == user.Password)
                {
                    Console.WriteLine("Login successful");

                }
                else
                {
                    Console.WriteLine("wrong username or password!!");
                }
            }
        }
    }
}

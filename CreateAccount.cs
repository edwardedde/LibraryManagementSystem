using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LibraryManagementSystem
{
    public class CreateAccount
    {
        public List<User> UserAccounts = new List<User>(); //list to store created accounts
                                                           

        private void SaveAccounts(string filePathAccounts) //enter the file where to store accounts
        {
            try
            {
                string json = JsonConvert.SerializeObject(UserAccounts, Formatting.Indented); //serializes user objects into json string
                File.WriteAllText(filePathAccounts, json); //writes the string into the file
                Console.WriteLine("Account saved successfully.");
            }
            catch (Exception ex)//error handling, writes to console where error occured
            {
                Console.WriteLine($"An error occurred while saving the account: {ex.Message}");
            }
        }

        public void LoadAccounts(string filePathAccounts)//enter the file where it should load from
        {
            try
            {
                if (File.Exists(filePathAccounts)) //checks if file exists
                {
                    string json = File.ReadAllText(filePathAccounts);//reads text from file
                    UserAccounts = JsonConvert.DeserializeObject<List<User>>(json);//creates user objects from the json string adds them into a List
                    Console.WriteLine("Accounts loaded successfully.");
                }
                else
                {
                    Console.WriteLine("No saved accounts found. checks if file exists");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading the accounts: {ex.Message}");
            }
        }


        public void CreateAccounts(User user)
        {
            string username;
            string password;

            Console.WriteLine("Username and password must be more than 6 symbols long");

            while (true)
            {

                Console.WriteLine("Insert a new username:");
                username = Console.ReadLine();

                if (username.Length > 6)//minimum lenght for username
                {
                    user.Username = username;

                    Console.WriteLine("Insert a new Password:");
                    password = Console.ReadLine();
                    
                    if(password.Length > 6)//minimum lenght for password
                    {
                        user.Password = password;
                        Console.WriteLine($"User {username} created, now you can use the system\n-------");
                        
                        break;
                    }
                    else
                    {
                        Console.WriteLine("password must be longer than 6 symbols, try again!");
                    }

                }
                else
                {
                    Console.WriteLine("username must be more than 6 symbols long, try again");
                }

            }
            User newUser = new User(username, password); 
            UserAccounts.Add(newUser); //add new user to list UserAccounts 
            Console.WriteLine($"{username} created successfully!");
            SaveAccounts("accounts.json");
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace LibraryManagementSystem
{
    public class CheckUserAccount
    {

        public List<User> UserAccounts = new List<User>();

        public bool Login()
        {

            while (true)
            {
                Console.WriteLine("-- Login --");

                Console.Write("Enter username: ");
                string check_username = Console.ReadLine();

                Console.Write("Enter password: ");
                string check_password = Console.ReadLine();

                
                User matchedUser = null;

                foreach (var account in UserAccounts)
                {
                    if (account.Username == check_username && account.Password == check_password)
                    {
                        matchedUser = account;
                        break; // Exit the loop once a match is found
                    }
                }

                if (matchedUser != null)
                {
                    Console.WriteLine("Login successful. Welcome, " + matchedUser.Username + "!");
                    return true;
                     // continu3e to the next part of the program
                }
                else
                {
                    Console.WriteLine("Wrong username or password. Please try again.\n");
                }
            }
        }

        public void LoadAccounts(string filePathAccounts)///enter the file where it should load from
        {
            try
            {
                if (File.Exists(filePathAccounts)) ///checks if file exists
                {
                    string json = File.ReadAllText(filePathAccounts);
                    UserAccounts = JsonConvert.DeserializeObject<List<User>>(json);
                    Console.WriteLine("Accounts loaded successfully.");///first reads text from file and then creates user objects from the json string and adds them into a List
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
    }
}

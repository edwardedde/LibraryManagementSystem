﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace LibraryManagementSystem
{
    public class CheckUserAccount
    {
     
        private string filePathAccounts = "accounts.json"; // Path to the accounts JSON file
        
        public bool Login()
        {
            // Load accounts from the file
            List<User> accounts = LoadAccounts();

            while (true)
            {
                Console.WriteLine("-- Login --");

                Console.Write("Enter username: ");
                string check_username = Console.ReadLine();

                Console.Write("Enter password: ");
                string check_password = Console.ReadLine();

                
                User matchedUser = null;

                foreach (var account in accounts)
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
                     // continue to the next part of the program
                }
                else
                {
                    Console.WriteLine("Wrong username or password. Please try again.\n");
                }
            }
        }

        private List<User> LoadAccounts()//method that returns a list of User objects
        {
            try
            {
                if (File.Exists(filePathAccounts)) // Check if the file exists
                {
                    string json = File.ReadAllText(filePathAccounts); //json string the text from the file 
                    return JsonConvert.DeserializeObject<List<User>>(json); //turns the string into a list of User obejcts
                }
                else
                {
                    Console.WriteLine("No saved accounts found. Please create an account first.");
                    return new List<User>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading the accounts: {ex.Message}");
                return new List<User>();
            }
        }
    }
}

using System.Security.Cryptography.X509Certificates;

namespace LibraryManagementSystem;

class Program
{

    static void Main(string[] args)
    {
        //instances of classes to access the methods
        Library library = new Library();

        User user = new User(); 

        CreateAccount creatAccount = new CreateAccount();


        CheckUserAccount CheckAgent = new CheckUserAccount();
        
         
        //files that hold books and accounts
        string filePathBooks = "library.json";

        string filePathAccounts = "accounts.json"; 


        library.LoadBooks(filePathBooks);

        creatAccount.LoadAccounts(filePathAccounts);

        bool loggedIn = false;


        //Main program starts
        while (!loggedIn) // The loop will execute as long as 'loggedIn' is 'false'.
        {
            Console.WriteLine("Create an account by pressing 1 or Login account by pressing 2");
            string LogInChoice = Console.ReadLine();

            switch (LogInChoice)
            {
                case "1":
                    // Create a new account
                    creatAccount.CreateAccounts(user);
                    break;

                case "2":
                    // Attempt login
                    if (CheckAgent.Login()) // If login is successful
                    {
                        loggedIn = true;
                    }
                    else
                    {
                        Console.WriteLine("Login failed. Try again!\n");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }

        Console.WriteLine("Welcome to the Library Management System\n----------------------------------------");

        //Library system starts
        while (true)
        {

            Console.WriteLine("1. Add a Book\n2. Search for a Book\n3. View All Books\n4. Delete a Book\n5. Edit book\n6.Exit");

            Console.Write("Enter your choice: ");
            string Choice = Console.ReadLine();
            

            switch (Choice)
            {
                case "1":
                    library.AddBook();
                    break;
                case "2":
                    library.SearchBook();
                    break;
                case "3":
                    library.ViewBooks();
                    break;
                case "4":
                    library.DeleteBook();
                    break;
                case "5":
                    library.EditBook();
                    break;
                case "6":
                    library.SaveBooks(filePathBooks);
                    return;
                //case 7 to ask user if they want to access/delete or update an account
                default:
                    Console.WriteLine("-------\nInvalid input\n-------");
                    break;

            }
        }
    }
}
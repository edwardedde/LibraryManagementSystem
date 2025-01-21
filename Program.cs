namespace LibraryManagementSystem;

class Program
{

    static void Main(string[] args)
    {
        Library library = new Library();
        User user = new User(); ///empty instance so that user can be created
        CreatAccount creatAccount = new CreatAccount();

        CheckUserAccount CheckAgent = new CheckUserAccount();
        
         

        string filePath = "library.json";

        string filePathAccounts = "accounts.json"; ///to hold accounts created

        library.LoadBooks(filePath);

        creatAccount.LoadAccounts(filePathAccounts);

        


        Console.WriteLine("Create an account by pressing 1 or Login account by pressing 2");
        string LogInChoice = Console.ReadLine();


        switch (LogInChoice)
        {
            case "1":
                creatAccount.CreateAccount(user);
                break;
            case "2":
                CheckAgent.Login();
                return ;
            default:
                return;

        }

        Console.WriteLine("Welcome to the Library Management System\n----------------------------------------");


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
                    return;
                default:
                    Console.WriteLine("-------\nInvalid input\n-------");
                    break;

            }
        }
    }
}
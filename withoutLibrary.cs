/*namespace LibraryManagementSystem;

class Program
{

    static void Main(string[] args)
    {

        Book book = new Book();

        string Filepath = "Saves.json";

        book.loadBooks(Filepath);

        

        Console.WriteLine("Welcome to the Library Management System\n-----------------------------------------");

        Console.WriteLine("1. Add a Book\n2. Search for a Book\n3. View All Books\n4. Delete a Book\n5. Exit");

        while(true)
        {           
            Console.Write("Enter your choice: ");
            string Choice = Console.ReadLine();
            
            if(Choice == "1")
            { 
                Book.AddBook();             
            }
            else if(Choice == "2")
            {
                Book.SearchBook();
            }
            else if(Choice == "3")
            {
                Book.ViewBooks();
            }
            else if(Choice == "4")
            {
                Book.DeleteBook();
            }
            else
            {
                book.Savebooks(Filepath);
                Console.WriteLine("Exiting the program. Goodbye!");
                break;
            }
        }
    }
}*/
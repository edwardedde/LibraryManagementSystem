/*namespace LibraryManagementSystem;

class Program
{

    static void Main(string[] args)
    {
        Library library = new Library();

        string filePath = "library.json";

        library.LoadBooks(filePath);

        Console.WriteLine("Welcome to the Library Management System\n-----------------------------------------");

        Console.WriteLine("1. Add a Book\n2. Search for a Book\n3. View All Books\n4. Delete a Book\n5. Exit");

        while(true)
        {           
            Console.Write("Enter your choice: ");
            string Choice = Console.ReadLine();
            
            if(Choice == "1")
            { 
                library.AddBook();             
            }
            else if(Choice == "2")
            {
                library.SearchBook();
            }
            else if(Choice == "3")
            {
                library.ViewBooks();
            }
            else if(Choice == "4")
            {
                library.DeleteBook();
            }
            else
            {
                library.SaveBooks(filePath);
                Console.WriteLine("Exiting the program. Goodbye!");
                break;
            }
        }
    }
}*/
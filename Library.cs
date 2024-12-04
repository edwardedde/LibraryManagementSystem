using Newtonsoft.Json;

namespace LibraryManagementSystem
{
    class Library
    {
        public List<Book> BookList = new List<Book>();
        public void SaveBooks(string filePath) ///enter the file where to store books
        {
            try
            {
                string json = JsonConvert.SerializeObject(BookList, Formatting.Indented); ///makes book objects into json string
                File.WriteAllText(filePath, json); ///writes the string into the file
                Console.WriteLine("Library saved successfully.");
            }
            catch (Exception ex)///error handling, writes to console where error occured
            {
                Console.WriteLine($"An error occurred while saving the library: {ex.Message}");
            }
        }

         public void LoadBooks(string filePath)///enter the file where it should load from
        {
            try
            {
                if (File.Exists(filePath)) ///checks if file exists
                {
                    string json = File.ReadAllText(filePath);
                    BookList = JsonConvert.DeserializeObject<List<Book>>(json); 
                    Console.WriteLine("Library loaded successfully.");///first reads text from file and then creates Book objects from the json string and adds them into a List
                }
                else
                {
                    Console.WriteLine("No saved library found. checks if file exists");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading the library: {ex.Message}");
            }
        }


        public void AddBook() ///three while loops to check user inputs
        {
            string title;
            string author;
            int year;

            while (true)
            {
                Console.Write("Enter the title of the book: ");
                title = Console.ReadLine();

                if (string.IsNullOrEmpty(title)) ///empty input check
                {
                    Console.WriteLine("Title cannot be empty. Please enter a title.");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter the author of the book: ");
                author = Console.ReadLine();

                if (string.IsNullOrEmpty(author))
                {
                    Console.WriteLine("Author cannot be empty. Please enter an author.");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter the year of publication: ");
                string inputYear = Console.ReadLine();

                try
                {
                    year = int.Parse(inputYear);

                    if (year > DateTime.Now.Year) ///year cannot be in the future
                    {
                        Console.WriteLine("Year cannot be in the future. Please enter a valid year.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid year format. Please enter a valid year.");
                }
            }

            Book newBook = new Book(title, author, year); ///add new book to the BookList
            BookList.Add(newBook);
            Console.WriteLine($"Book '{title}' by {author} added successfully!");
        }

        public Book SearchBooks(string title) ///Uses book class so that it can access original Title and compare it to the parameter
        {
            foreach (var book in BookList)
            {
                if(book.Title == title)
                {
                    return book;
                }
            }    
            return null;
        }

        public void SearchBook() ///used in main
        {
            Console.Write("Enter the title to search: ");
            string title = Console.ReadLine();

            Book book = SearchBooks(title); /// result assigned to book object 
            if (book != null)
            {
                Console.WriteLine($"Book found\nTitle: {book.Title}\nAuthor: {book.Author}\nYear: {book.Year}");
            }
            else
            {
                Console.WriteLine("Didn't find any book with that title.");
            }
        }
        public void ViewBooks() /// loops through list of books and writes out each book with details(if there are any)
        {
            if (BookList.Count == 0)
            {
                Console.WriteLine("No books in the library.");
            }
            else
            {
                Console.WriteLine("Books in the library:");
                foreach (var book in BookList)
                {
                    Console.WriteLine($"Title: {book.Title} | Author: {book.Author} | Year: {book.Year}");
                }
            }
        }


        public void DeleteBook()
        {
            Console.Write("Enter the title of the book you want to delete: ");
            string title = Console.ReadLine().ToLower();

            Book book = SearchBooks(title); ///searches book by title

            if (book != null)
            {
                Console.Write($"Book found. Are you sure you want to delete '{book.Title}'? (Y/N): "); ///double checks if user wants to delete book
                string choice = Console.ReadLine().ToLower();

                if (choice == "y")
                {
                    BookList.Remove(book);
                    Console.WriteLine($"Book '{book.Title}' deleted.");
                }
                else
                {
                    Console.WriteLine("Book not deleted.");
                }
            }
            else
            {
                Console.WriteLine("Didn't find any book with that title.");
            }
        }
    }
}
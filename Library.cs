using System.Text.Json;
namespace LibraryManagementSystem
{
    class Library
    {
        public List<Book> BookList { get; private set; } = new List<Book>();

        public void SaveBooks(string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(BookList);
                File.WriteAllText(filePath, json);
                Console.WriteLine("Library saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the library: {ex.Message}");
            }
        }

         public void LoadBooks(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    BookList = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
                    Console.WriteLine("Library loaded successfully.");
                }
                else
                {
                    Console.WriteLine("No saved library found. Starting with an empty library.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading the library: {ex.Message}");
            }
        }


        public void AddBook()
        {
            string title;
            string author;
            int year;

            while (true)
            {
                Console.Write("Enter the title of the book: ");
                title = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(title))
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

                if (string.IsNullOrWhiteSpace(author))
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

                    if (year > DateTime.Now.Year)
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

            Book newBook = new Book(title, author, year);
            BookList.Add(newBook);
            Console.WriteLine($"Book '{title}' by {author} added successfully!");
        }

        public Book SearchBooks(string title) //figure this out
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

        public void SearchBook()
        {
            Console.Write("Enter the title to search: ");
            string title = Console.ReadLine();

            Book book = SearchBooks(title);
            if (book != null)
            {
                Console.WriteLine($"Book found\nTitle: {book.Title}\nAuthor: {book.Author}\nYear: {book.Year}");
            }
            else
            {
                Console.WriteLine("Didn't find any book with that title.");
            }
        }
        public void ViewBooks()
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

            Book book = SearchBooks(title);

            if (book != null)
            {
                Console.Write($"Book found. Are you sure you want to delete '{book.Title}'? (Y/N): ");
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
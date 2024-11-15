using System.Text.Json;
    class Book
    {
        public static List<Book> bookList = new List<Book>();
        
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(){}

        
        public Book(string _Title, string _Author, int _Year)
        {
            this.Title = _Title;
            this.Author = _Author;
            this.Year = _Year;
        }

        public void Savebooks(string Filepath)
        {
            try
            {
                string json = JsonSerializer.Serialize(bookList);
                File.WriteAllText(Filepath, json);
                Console.WriteLine("books saved!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"something went wrong {e.Message}");
            }
        }

        public void loadBooks(string Filepath)
        {
            try
            {
                if(File.Exists(Filepath))
                {
                    string json = File.ReadAllText(Filepath);
                    bookList = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
                    Console.WriteLine("books loaded!");
                }
                else
                {
                    Console.WriteLine("No books saved so nothing was loaded");
                }
            }
            catch (Exception e)
            {
                
                Console.WriteLine($"error loading {e.Message}");
            }
        }
        

        public static void AddBook()
        {
            string title;
            string author;
            int year;

            while(true)
            {
                Console.Write("Enter the title of the book:");
                title = Console.ReadLine();
                
                if(title.Length == 0)
                {
                    Console.WriteLine("title cant be empty, enter a title");
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
                if (author.Length == 0)
                {
                    Console.WriteLine("Author cannot be empty. Please enter a valid author.");
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
                    year = int.Parse(inputYear); // Try to parse the input as an integer
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
            bookList.Add(newBook);

            Console.WriteLine("Book added successfully!");
            
        }

        public static void SearchBook()
        {
            Console.Write("Enter the title to search: ");
            string title = Console.ReadLine().ToLower();
            
            foreach (var book in bookList)
            {
                if(book.Title == title)
                {
                    Console.WriteLine($"Book found\nTitle: {book.Title}\nAuthor: {book.Author}\nYear: {book.Year}");
                    break;
                }
                else
                {
                    Console.WriteLine("didnt find any book with that title");
                    break;
                }
            }
        }
        
        public static void ViewBooks()
        {
            if(bookList.Count == 0)
                {
                    Console.WriteLine("booklist empty");
                }
                else
                {
                    foreach (var book in bookList)
                    {
                        Console.WriteLine("Books in the library:");
                        Console.WriteLine($"Title: {book.Title} Author: {book.Author} Year: {book.Year}");  
                    }
                }   
        }

        public static void DeleteBook()
        {
            Console.Write("Enter the title of the book you want to delete: ");
            string title = Console.ReadLine().ToLower();

            var bookListCopy = new List<Book>(bookList);

            foreach (var book in bookListCopy)
            {
                if(book.Title == title)
                {
                    Console.Write($"Book found , are yuo sure you want to delete Y/N: ");
                    string choice = Console.ReadLine().ToLower();

                    while(true)
                    {
                        if(choice == "y")
                        {
                            Console.WriteLine($"ok {book.Title} deleted");
                            bookList.Remove(book);
                            break;
                        }
                        else if(choice == "n")
                        {
                            Console.WriteLine("ok book not deleted");
                            break;
                        } 
                        else
                        {
                            Console.WriteLine("sorry press either Y for yes and N for no");
                            choice = Console.ReadLine().ToLower();
                            
                        }
                    }
                    return;
                }
            }
            Console.WriteLine("Didn't find any book with that title");
        }
    }
namespace LibraryManagementSystem
{
    class Book
    {   
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }

        public Book(string _Title, string _Author, int _Year, string _Description)
        {
            this.Title = _Title;
            this.Author = _Author;
            this.Year = _Year;
            this.Description = _Description;
        }
    }
}
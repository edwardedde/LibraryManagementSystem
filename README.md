Library Management System - My First GitHub Project

This is my first project pushed to GitHub! 🎉
Project Overview:

This program is a simple library management system written in C#. It allows users to add, search, view, and delete books from a library. The program also saves and loads books using JSON serialization, ensuring that the data persists between sessions.
Files:
    Program.cs - The main entry point of the application, where user interaction occurs.
    Library.cs - Contains the logic for managing the library's collection of books.
    Book.cs - Defines the structure of a book object.
    books.json - Stores the data of books in JSON format.

How It Works:
    Upon starting, the program loads books that were previously added from the books.json file.
    You can add, search, view, and delete books within the session.
    When the program ends, it saves any newly added books to books.json using the Newtonsoft.Json library's SerializeObject and DeserializeObject methods to handle the data.


I got the idea for this project from ChatGPT by asking, "Give me a coding task in C# that would be presented to a person being interviewed for a junior developer role." 😄

This is the beginning of my coding journey (at least publicly)! Feel free to explore the code and provide feedback!

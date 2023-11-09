using System;
using System.Collections.Generic;

namespace BookLibrary
{
    class Book
    {
        public static int BookIdCounter = 1;

        public string Name { get; set; }
        public int BookId { get; set; }
        public Author Author { get; set; }
        public int Year { get; set; }
        public int Available { get; set; }

        public Book()
        {
            BookId = BookIdCounter++;
        }
    }

    class Author
    {
        public string Name { get; set; }
    }

    class Library
    {
        public List<Book> Books { get; set; }

        public Library()
        {
            Books = new List<Book>();
        }

        public void AddBook()
        {
            Console.Write("Enter book's name: ");
            string booksName = Console.ReadLine();
            Console.Write("Enter author's name: ");
            string authorsName = Console.ReadLine();
            Console.Write("Enter book's year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter quantity available: ");
            int available = Convert.ToInt32(Console.ReadLine());

            Books.Add(new Book { Name = booksName, Author = new Author { Name = authorsName }, Year = year, Available = available });
        }

        public void BorrowBooks()
        {
            Console.Write("Enter the book ID to borrow: ");
            int bookId = Convert.ToInt32(Console.ReadLine());

            Book bookToBorrow = Books.Find(book => book.BookId == bookId);

            if (bookToBorrow != null && bookToBorrow.Available > 0)
            {
                bookToBorrow.Available--;
                Console.WriteLine($"Book '{bookToBorrow.Name}' by {bookToBorrow.Author.Name} has been borrowed. {bookToBorrow.Available} copies available.");
            }
            else
            {
                Console.WriteLine("Book not found or not available.");
            }
        }
    }

    class Program
    {
        static Library library = new Library();

        static void Main()
        {
            while (true)
            {
                Login();
            }
        }

        static void Login()
        {
            Console.Write("Login as Customer(1) or Staff(2)? (Enter any other key to exit): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    library.BorrowBooks();
                    break;
                case "2":
                    library.AddBook();
                    break;
                default:
                    Console.WriteLine("Thank you! We wish you will come again!");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}

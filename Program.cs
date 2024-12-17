using System;
using System.Collections.Generic;

namespace overloading_of_operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookList bookList = new BookList();

            bookList.AddBook(new Book("Book 1", "Author 1"));
            bookList.AddBook(new Book("Book 2", "Author 2"));
            bookList.AddBook(new Book("Book 3", "Author 3"));

            Console.WriteLine(bookList.ContainsBook(new Book("Book 2", "Author 2")));
            Console.WriteLine(bookList.ContainsBook(new Book("Book 4", "Author 4")));

            bookList.RemoveBook(new Book("Book 1", "Author 1"));

            Console.WriteLine(bookList.ContainsBook(new Book("Book 1", "Author 1")));
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }

    public class BookList
    {
        private List<Book> books;

        public BookList()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }

        public bool ContainsBook(Book book)
        {
            return books.Contains(book);
        }

        public Book this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }
    }
}

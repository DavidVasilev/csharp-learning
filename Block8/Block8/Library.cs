using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Block8
{
    public class Library
    {
        private static int totalBooksCreated = 0;
        private List<Book> ListBooks;
        
        public Library()
        {
            ListBooks = new List<Book>();
        }
        public void AddBook(Book book)
        {
            ListBooks.Add(book);
            totalBooksCreated++;
            Console.WriteLine($"Книга {book} успешно добавлена в библиотеку!");
        }
        public void RemoveBook(Book book)
        {
            if (ListBooks.Remove(book))
                Console.WriteLine($"Книга \"{book.Title}\" удалена из библиотеки.");
            else
                Console.WriteLine($"Книга \"{book.Title}\" не найдена.");
        }
        public List<Book> FindByAuthor(string author)
        {
            return ListBooks.FindAll(x => x.Author == author);
        }
        public void PrintAll()
        {
            if (ListBooks.Count == 0)
            {
                Console.WriteLine("Библиотека пуста.");
                return;
            }

            Console.WriteLine("=== Список всех книг ===");
            foreach (Book book in ListBooks)
            {
                book.PrintInfo();
            }
        }

        public int GetCount()
        {
            return ListBooks.Count;
        }

        public static int GetTotalBooksCreated()
        {
            return totalBooksCreated;
        }
    }
}

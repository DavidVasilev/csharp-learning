using Block8;
using System;
using System.Collections.Generic;

namespace ProjectLibrary
{
    class MyProject
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Library library = new Library();

            library.AddBook(new Book("Война и мир", "Лев Толстой", 1869, Genre.Fiction));
            library.AddBook(new Book("Краткая история времени", "Стивен Хокинг", 1988, Genre.Science));
            library.AddBook(new Book("1984", "Джордж Оруэлл", 1949, Genre.Fiction));
            library.AddBook(new Book("Сапиенс", "Юваль Ной Харари", 2011, Genre.History));
            library.AddBook(new Book("Властелин колец", "Дж. Р. Р. Толкин", 1954, Genre.Fantasy));

            library.PrintAll();

            Book b1 = new Book("Мастер и Маргарита", "Михаил Булгаков", 1967, Genre.Fiction);
            Book b2 = new Book("Дюна", "Фрэнк Герберт", 1965, Genre.Fantasy);
            library.AddBook(b1);
            library.AddBook(b2);

            b1.Borrow();
            b2.Borrow();
            b1.Borrow();

            b1.Return();

            List<Book> found = library.FindByAuthor("Лев Толстой");
            if (found.Count == 0)
                Console.WriteLine("Книги не найдены.");
            else
                foreach (Book b in found)
                    Console.WriteLine(b.ToString());


            try
            {
                Book badBook = new Book("Старая книга", "Неизвестный", 1800, Genre.History);
                library.AddBook(badBook);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка при создании книги: {ex.Message}");
            }

            Book sameAsB1 = new Book("Мастер и Маргарита", "Михаил Булгаков", 2000, Genre.Fiction);
            Book differentBook = new Book("Дюна", "Фрэнк Герберт", 1965, Genre.Fantasy);

            Console.WriteLine($"b1.Equals(sameAsB1)       = {b1.Equals(sameAsB1)}");
            Console.WriteLine($"b1.Equals(differentBook)  = {b1.Equals(differentBook)}");

            // 9. BookDto
            BookDto dto = new BookDto(b1.Title, b1.Author, b1.Year);
            Console.WriteLine(dto.ToString());

            // 10. Итоги
            Console.WriteLine($"Книг сейчас в библиотеке:  {library.GetCount()}");
            Console.WriteLine($"Всего книг было создано:    {Library.GetTotalBooksCreated()}");
        }
    }
}
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

            // 1. Создать библиотеку
            Console.WriteLine("=== 1. Создание библиотеки ===");
            Library library = new Library();

            // 2. Добавить 5 книг
            Console.WriteLine("\n=== 2. Добавление 5 книг ===");
            library.AddBook(new Book("Война и мир", "Лев Толстой", 1869, Genre.Fiction));
            library.AddBook(new Book("Краткая история времени", "Стивен Хокинг", 1988, Genre.Science));
            library.AddBook(new Book("1984", "Джордж Оруэлл", 1949, Genre.Fiction));
            library.AddBook(new Book("Сапиенс", "Юваль Ной Харари", 2011, Genre.History));
            library.AddBook(new Book("Властелин колец", "Дж. Р. Р. Толкин", 1954, Genre.Fantasy));

            // 3. Вывести все книги
            Console.WriteLine("\n=== 3. Все книги ===");
            library.PrintAll();

            // 4. Выдача книг
            Console.WriteLine("\n=== 4. Выдача книг ===");
            Book b1 = new Book("Мастер и Маргарита", "Михаил Булгаков", 1967, Genre.Fiction);
            Book b2 = new Book("Дюна", "Фрэнк Герберт", 1965, Genre.Fantasy);
            library.AddBook(b1);
            library.AddBook(b2);

            b1.Borrow();
            b2.Borrow();
            b1.Borrow(); // повторная выдача — должно быть сообщение об ошибке

            // 5. Возврат книги
            Console.WriteLine("\n=== 5. Возврат книги ===");
            b1.Return();

            // 6. Поиск по автору
            Console.WriteLine("\n=== 6. Поиск книг по автору ===");
            List<Book> found = library.FindByAuthor("Лев Толстой");
            if (found.Count == 0)
                Console.WriteLine("Книги не найдены.");
            else
                foreach (Book b in found)
                    Console.WriteLine(b.ToString());

            // 7. Книга с неверным годом
            Console.WriteLine("\n=== 7. Книга с неверным годом ===");
            try
            {
                Book badBook = new Book("Старая книга", "Неизвестный", 1800, Genre.History);
                library.AddBook(badBook);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка при создании книги: {ex.Message}");
            }
            // ✅ catch закрывается ЗДЕСЬ — остальной код вне try-catch

            // 8. Сравнение книг
            Console.WriteLine("\n=== 8. Сравнение книг ===");
            Book sameAsB1 = new Book("Мастер и Маргарита", "Михаил Булгаков", 2000, Genre.Fiction);
            Book differentBook = new Book("Дюна", "Фрэнк Герберт", 1965, Genre.Fantasy);

            Console.WriteLine($"b1.Equals(sameAsB1)       = {b1.Equals(sameAsB1)}");
            Console.WriteLine($"b1.Equals(differentBook)  = {b1.Equals(differentBook)}");

            // 9. BookDto
            Console.WriteLine("\n=== 9. BookDto ===");
            BookDto dto = new BookDto(b1.Title, b1.Author, b1.Year);
            Console.WriteLine(dto.ToString());

            // 10. Итоги
            Console.WriteLine("\n=== 10. Итоги ===");
            Console.WriteLine($"Книг сейчас в библиотеке:  {library.GetCount()}");
            Console.WriteLine($"Всего книг было создано:    {Library.GetTotalBooksCreated()}");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
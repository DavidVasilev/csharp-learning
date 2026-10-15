using System;
using System.Text;

namespace Block8
{
    public enum Genre
    {
        Fiction,
        NonFiction,
        Science,
        History,
        Fantasy
    }

    public class Book
    {
        private static int count = 1;
        private readonly int number;
        private const int MIN_YEAR = 1900;
        private const int MAX_YEAR = 2026;
        private int year;
        private bool isAvailable;

        public string Title { get; set; }
        public string Author { get; set; }
        public Genre Genre { get; set; }

        public int Year
        {
            get { return year; }
            set
            {
                if (value < MIN_YEAR || value > MAX_YEAR)
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        $"Год должен быть в диапазоне от {MIN_YEAR} до {MAX_YEAR}."
                    );
                year = value;
            }
        }

        public int Number => number;
        public bool IsAvailable => isAvailable;

        public Book(string title, string author, int year, Genre genre)
        {
            this.number = count++;
            this.Title = title;
            this.Author = author;
            this.Genre = genre;
            this.Year = year;
            this.isAvailable = true;
        }

        public void Borrow()
        {
            if (isAvailable)
            {
                isAvailable = false;
                Console.WriteLine($"Книга \"{Title}\" выдана.");
            }
            else
            {
                Console.WriteLine($"Книга \"{Title}\" уже выдана.");
            }
        }

        public void Return()
        {
            if (!isAvailable)
            {
                isAvailable = true;
                Console.WriteLine($"Книга \"{Title}\" возвращена в библиотеку.");
            }
            else
            {
                Console.WriteLine($"Книга \"{Title}\" уже находится в библиотеке.");
            }
        }

        public void PrintInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-----------------------------");
            sb.AppendLine($"Уникальный номер: {number}");
            sb.AppendLine($"Название:         {Title}");
            sb.AppendLine($"Автор:            {Author}");
            sb.AppendLine($"Год издания:      {Year}");
            sb.AppendLine($"Жанр:             {Genre}");
            sb.AppendLine($"Доступность:      {(isAvailable ? "В библиотеке" : "Выдана")}");
            sb.AppendLine("-----------------------------");
            Console.Write(sb.ToString());
        }

        public override string ToString()
        {
            return $"Book: {Title}, {Author} ({Year})";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Book))
                return false;

            Book other = (Book)obj;
            return this.Title == other.Title && this.Author == other.Author;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Author);
        }
    }

    public record BookDto(string Title, string Author, int Year);
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Практика_8_модуль
{
    public class Student
    {
        private static int count = 1;
        public readonly int NumberId;//Уникальный номер — автоматически, менять нельзя
        public string Name { get; set; } = "Nonw";
        public string Group { get; set; } = "Nonw";
        public List<int> Balls { get; private set; } = new List<int>();
        public double Average {  get; private set; }

        public Student(string name, string group)
        {
            this.Name = name;
            this.Group = group;
            NumberId = count++;
        }
        public void AddGrade(params int[] grade)
        {
            bool isTrue = true;
            foreach (var value in grade)
            {
                if (value < 2 || value > 5)
                    isTrue = false;
            }
            if (isTrue)
            {
                double sum = 0;
                for (int i = 0; i < grade.Length; i++)
                {
                    Balls.Add(grade[i]);
                }
                foreach (var item in Balls)
                {
                    sum += item;
                }
                Average = sum / (double)Balls.Count;
            }
            else
                Console.WriteLine("ERROR");
        }
        public double GetAverage
        {
            get { return Average; }
        }
        public override bool Equals(object? obj)
        {
            if(obj is Student other)
                return Name == other.Name && Group == other.Group;
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Group);
        }
        public override string ToString()
        {
            return $"Student: {Name}, {Group}";
        }
    }
    record StudentDto(string Name, string Group);
}

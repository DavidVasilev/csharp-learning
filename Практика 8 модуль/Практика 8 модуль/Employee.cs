using System;
using System.Collections.Generic;
using System.Text;

namespace Практика_8_модуль
{
    public class Employee
    {
        private static int count = 1;
        public readonly int NumberId;//Уникальный номер — автоматически, менять нельзя
        public string Name { get; set; } = "None";//Имя — можно менять
        public string Title { get; set; } = "None";//Должность — можно менять
        public double Salary { get; private set; } = 1000;//Зарплата — скрытое поле, не может быть отрицательной
        public int Experience { get; private set; }//Стаж — скрытое поле, не может быть отрицательным


        public Employee(string name, string title)
        {
            this.Name = name;
            this.Title = title;
            this.NumberId = count++;
        }
        public void RaiseSalary(int percent)
        {
            if (percent <= 0)
                Console.WriteLine("ERROR");
            else
                this.Salary *= 1 + (double)percent / 100;
        }
        public void AddExperience(int years)
        {
            if (years <= 0)
                Console.WriteLine("ERROR");
            else
                Experience += years;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"ID: {this.NumberId}\nимя: {this.Name}\nдолжность: {this.Title}\nзарплата: {this.Salary}\nстаж: {this.Experience}");
        }
        public override string ToString()
        {
            return $"Employee: {Name}, {NumberId}";
        }
    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace Практика_8_модуль
{
    class Program
    {
        static void Main()
        {
            //Employee
            var employee1 = new Employee(name: "Валера", title: "Опер");
            var employee2 = new Employee(name: "Костян", title: "Дежерный");

            employee1.PrintInfo();
            employee1.RaiseSalary(10);
            employee1.AddExperience(2);
            employee1.PrintInfo();

            employee2.RaiseSalary(-5);
            employee2.AddExperience(0);
            employee2.PrintInfo();

            //Student
            var student1 = new Student("Alesha","IS-25");
            var student2 = new Student("Alesha", "IS-25");

            Console.WriteLine(student1.Equals(student2));
            student1.AddGrade(4, 5, 5);
            student2.AddGrade(1, 5, 5);
            student2.AddGrade(2, 5, 5);
            StudentDto studentA = new StudentDto("Alesha", "IS-25");
            StudentDto studentB = new StudentDto("Alesha", "IS-25");
            Console.WriteLine(studentA);
            Console.WriteLine(studentB);
            StudentDto studentC = studentA with { Group = "IS-25", Name = "Jojo" };
        }
    }
}

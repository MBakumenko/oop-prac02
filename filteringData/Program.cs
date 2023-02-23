using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace filteringData;

class Student
{
    public string Name { get; set; }
    public double Grade { get; set; }
}

class Program
{
    static void Main()
    {
        // Читання даних із файлу з інформацією про студентів
        List<Student> students = new List<Student>();
        string[] lines = File.ReadAllLines("students_data.txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            string name = parts[0];
            double grade = double.Parse(parts[1]);
            Student student = new Student { Name = name, Grade = grade };
            students.Add(student);
        }

        // Відсіювання студентів з оцінками вище 80 з допомогою лямбда-виразу
        var filteredStudentsAbove80 = students.Where(student => student.Grade >= 80);
        // Відсіювання студентів з оцінками нижче 80 з допомогою лямбда-виразу
        var filteredStudentsBelow80 = students.Where(student => student.Grade <= 80);

        // Виведення студентів з оцінками вище 80
        Console.WriteLine("Students with a grade over 80: \n");
        foreach (var student in filteredStudentsAbove80)
        {
            Console.WriteLine(student.Name + " " + student.Grade);
        }

        // Виведення студентів з оцінками нижче 80
        Console.WriteLine("\nStudents with a grade below 80: \n");
        foreach (var student in filteredStudentsBelow80)
        {
            Console.WriteLine(student.Name + " " + student.Grade);
        }
    }
}
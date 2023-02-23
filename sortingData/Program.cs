using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace sortingData;

class Employee
{
    public string Name { get; set; }
    public int Salary { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Читання даних про робітників із файлу
        List<Employee> employees = new List<Employee>();
        using (StreamReader reader = new StreamReader("employee_data.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                employees.Add(new Employee { Name = parts[0], Salary = int.Parse(parts[1]) });
            }
        }

        // Сортування робітників за розміром зарплатами з допомогою лямбда-виразу
        var sortedEmployees = employees.OrderByDescending(e => e.Salary);

        // Виведення середніх зарплат робітників із різних країн
        Console.WriteLine("Average employee salaries in EU countries (in EURO): \n");
        foreach (Employee employee in sortedEmployees)
        {
            Console.WriteLine("{0}: {1}", employee.Name, employee.Salary);
        }
    }
}
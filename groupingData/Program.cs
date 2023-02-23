using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace groupingData;

class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Читання даних з файлу
        List<Product> products = new List<Product>();
        using (StreamReader reader = new StreamReader("product_data.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] fields = line.Split(',');
                products.Add(new Product { Name = fields[0], Category = fields[1], Price = decimal.Parse(fields[2]) });
            }
        }

        // Групування продуктів за категоріями
        var groupedProducts = products.GroupBy(p => p.Category);

        // Виведення продуктів за категоріями
        Console.WriteLine("Products grouped by category: \n");
        foreach (var group in groupedProducts)
        {
            Console.WriteLine("{0}:", group.Key);
            foreach (Product product in group)
            {
                Console.WriteLine("\t{0}: {1}", product.Name, product.Price);
            }
        }
    }
}
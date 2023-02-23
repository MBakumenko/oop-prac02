using System;
using System.Collections.Generic;

namespace delegateString;
class Program
{
    delegate int StringLengthDelegate(string s);

    static void Main(string[] args)
    {
        // Створення списку рядків
        List<string> strings = new List<string> { "Ukraine", "will", "win", "this", "war", "soon" };

        // Створення делегату використовуючи лямбда-вираз
        StringLengthDelegate stringLength = s => s.Length;

        // Опрацювання списку з допомогою делегату
        foreach (string s in strings)
        {
            int length = stringLength(s);
            Console.WriteLine("{0}: {1}", s, length);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_16
{
    internal class Program
    {

        class Toy
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public int MinAge { get; set; }
            public int MaxAge { get; set; }

            public override string ToString()
            {
                return $"Название: {Name}, Цена: {Price} руб., Возраст: от {MinAge} до {MaxAge} лет";
            }

            public int CompareTo(object obj)
            {
                if (obj is Toy other)
                    return Price.CompareTo(other.Price);
                else
                    throw new ArgumentException("Объект не является игрушкой.");
            }
        }
        static void Main(string[] args)
        {
            //Задание  1
            string fileName = "input.txt";
            int charCount = 0;

            using (StreamReader reader = new StreamReader(fileName))
            {
                string content = reader.ReadToEnd();
                foreach (char c in content)
                {
                    Console.WriteLine($"Символ: {c}, Код: {(int)c}");
                    charCount++;
                }
            }

            Console.WriteLine($"Общее количество символов: {charCount}");
            Console.WriteLine("Коды символов, обозначающих конец строки: 13, 10");
            Console.WriteLine("Код пробела: 32");

            //Задание 2

            int N = 10;
            char C = 'A';
            string fileName2 = "output.txt";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int i = 1; i <= N; i++)
                {
                    writer.WriteLine(new string(C, i));
                }
            }

            //Задание 3

            string file1 = "file1.txt";
            string file2 = "file2.txt";

            using (StreamWriter writer = new StreamWriter(file1, true))
            {
                using (StreamReader reader = new StreamReader(file2))
                {
                    writer.Write(reader.ReadToEnd());
                }
            }


            //задание 4

            string inputFile = "input.txt";
            string outputFile = "output.txt";
            int minAge = 5;
            int maxAge = 10;

            List<Toy> toys = new List<Toy>();


            using (StreamReader reader = new StreamReader(inputFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    toys.Add(new Toy
                    {
                        Name = parts[0],
                        Price = double.Parse(parts[1]),
                        MinAge = int.Parse(parts[2]),
                        MaxAge = int.Parse(parts[3])
                    });
                }
            }


            var filteredToys = toys.Where(t => t.MinAge >= minAge && t.MaxAge <= maxAge).OrderBy(t => t.Price);

            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                foreach (var toy in filteredToys)
                {
                    writer.WriteLine(toy);
                }
            }


        }
    }
}
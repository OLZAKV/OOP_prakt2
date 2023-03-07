using System;
using System.Text;
using System.IO;

namespace Створення_делегатів_за_допомогою_лямбда_виразів
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string path = @"D:\\ТестуванняЛямбдаВиразів3.txt";

            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не знайдено.");
            }
            else
            {
                string[] readText = File.ReadAllLines(path);
                Operation processline = x => Console.WriteLine(x.Length);

                foreach (string s in readText)
                {
                    processline(s);
                }
                
                Console.ReadLine();
            }
        }
        delegate void Operation(string x);
    }
}

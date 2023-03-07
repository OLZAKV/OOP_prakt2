using System.IO;
using System;
using System.Text;

namespace Сортування_даних_за_допомогою_лямбда_виразів
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int value;
            int Rows = 15;
            bool Error = false;//C:\\Users\\alex\\Documents\\GitHub\\OOP_prakt2\\OOP_prakt2\\ТестуванняЛямбдаВиразів2.txt
            string path = @"D:\\ТестуванняЛямбдаВиразів2.txt";
            string[,] Table1 = new string[2, Rows];
            string Name, Point;

            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не знайдено.");
            }
            else
            {
                Operation CompareLines = (x, y) =>
                {
                    if (int.Parse(Table1[1, x]) < int.Parse(Table1[1, y]))
                    {
                        Name = Table1[0, x];
                        Point = Table1[1, x];
                        Table1[0, x] = Table1[0, y];
                        Table1[1, x] = Table1[1, y];
                        Table1[0, y] = Name;
                        Table1[1, y] = Point;
                    }
                };

                string[] readText = File.ReadAllLines(path);
                int i = 0;
                foreach (string s in readText)
                {
                    ParseLine(Table1, s, i);

                    try
                    {
                        value = int.Parse(Table1[1, i]);
                    }
                    catch
                    {
                        Console.WriteLine("Помилка отримання даних з файла. Не вдалося перетворити в число строку - " + Table1[1, i]);
                        Error = true;
                        break;
                    }
                    i++;

                    if (i == Rows)
                    {
                        break;
                    }
                }
                if(!Error)
                {
                    for(int u = 0; u < i - 1; u++)
                    {
                        for (int j = u + 1; j < i; j++)
                        {
                            CompareLines(u, j);
                        }
                    }

                    for (int p = 0; p < i; p++)
                    {
                        Console.WriteLine(Table1[0, p] + " " + Table1[1, p]);
                    }
                }
                Console.ReadLine();
            }
        }
        static void ParseLine(string[,] Tbl1, string Row, int Position)
        {
            int StartingPosition = 0;
            for (int i = 0; i < 2; i++)
            {
                int CurrentPosition = Row.IndexOf(' ', StartingPosition);
                if (CurrentPosition == -1)
                {
                    CurrentPosition = Row.Length;
                }
                Tbl1[i, Position] = Row.Substring(StartingPosition, CurrentPosition - StartingPosition);
                StartingPosition = CurrentPosition + 1;
            }
        }

        delegate void Operation(int x, int y);
    }
}

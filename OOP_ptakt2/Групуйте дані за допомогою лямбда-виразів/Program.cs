using System;
using System.Text;
using System.IO;

namespace Групуйте_дані_за_допомогою_лямбда_виразів
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int value;
            int Rows = 15;//C:\\Users\\alex\\Documents\\GitHub\\OOP_prakt2\\OOP_prakt2\\ТестуванняЛямбдаВиразів3.txt
            string path = @"D:\\ТестуванняЛямбдаВиразів3.txt";
            string[,] Table1 = new string[2, Rows];
            string Name, Point;

            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не знайдено.");
            }
            else
            {
                Operation SameGroup = (x, y) =>
                {
                    if (Table1[0, x] == Table1[0, y])
                    {
                        if(x + 1 < y)
                        {
                            Name = Table1[0, x + 1];
                            Point = Table1[1, x + 1];
                            Table1[0, x + 1] = Table1[0, y];
                            Table1[1, x + 1] = Table1[1, y];
                            Table1[0, y] = Name;
                            Table1[1, y] = Point;
                        }
                        return true;
                    }
                    else return false;
                };

                string[] readText = File.ReadAllLines(path);
                int i = 0;
                foreach (string s in readText)
                {
                    ParseLine(Table1, s, i);
                    i++;

                    if (i == Rows)
                    {
                        break;
                    }
                }

                int u = 0;
                while (u < i - 1)
                {
                    for (int j = u + 1; j < i; j++)
                    {
                        if (SameGroup(u, j)) u++;
                    }
                    u++;
                }

                for (int p = 0; p < i; p++)
                {
                    Console.WriteLine(Table1[0, p] + " " + Table1[1, p]);
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

        delegate bool Operation(int x, int y);
    }
}

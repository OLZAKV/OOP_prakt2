using System.IO;
using System;
using System.Text;


namespace Фільтрування_даних_за_допомогою_лямбда_виразів
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int Threshold = 10;
            int value;
            int Rows = 15;//C:\\Users\\alex\\Documents\\GitHub\\OOP_prakt2\\OOP_prakt2\\ТестуванняЛямбдаВиразів1.txt
            string path = @"D:\\ТестуванняЛямбдаВиразів1.txt";
            string[,] Table1 = new string[3, Rows];

            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не знайдено.");
            }
            else
            {
                Operation IsApplicable = (x, y) => x >= y;

                string[] readText = File.ReadAllLines(path);
                int i = 0;
                foreach (string s in readText)
                {
                    ParseLine(Table1, s, i);

                    try
                    {
                        value = int.Parse(Table1[2, i]);
                        if (IsApplicable(value, Threshold))
                        {
                            Console.WriteLine(Table1[0, i] + " " + Table1[1, i] + " " + Table1[2, i]);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Помилка отримання даних з файла. Не вдалося перетворити в число строку - " + Table1[2, i]);
                        break;
                    }
                    i++;
                    
                    if(i == Rows)
                    {
                        break;
                    }
                }
                Console.ReadLine();
            }
        }
        static void ParseLine (string[,] Tbl1, string Row, int Position)
        {
            int StartingPosition = 0;
            for(int i = 0; i < 3; i++)
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

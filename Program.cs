using System;
using System.Globalization;
using System.IO;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"C:\Users\motta\OneDrive\Documentos\file1.txt";
            string targetPath = @"C:\Users\motta\OneDrive\Documentos\file2.txt";

            try
            {
                string[] lines = File.ReadAllLines(sourcePath);
                using (StreamWriter sw = File.AppendText(targetPath))
                {
                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(',');
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);
                        double total = price * quantity;
                        sw.WriteLine(name + ',' + total.ToString("F2", CultureInfo.InvariantCulture));
                        Console.WriteLine(name + ',' + total.ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }

}
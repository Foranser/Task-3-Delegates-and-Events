using System;
using System.Collections.Generic;
using System.IO;
using Task3.DelegatesAndEvents.Extensions;
using Task3.DelegatesAndEvents.FileSystem;

namespace Task3.DelegatesAndEvents
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var directory = args.Length > 0 ? args[0] : Environment.CurrentDirectory;

            var found = new List<string>();
            var scanner = new FileScanner();

            scanner.FileFound += (sender, e) =>
            {
                var a = (FileArgs)e;
                Console.WriteLine($"Найден файл: {a.FileName}");
                found.Add(a.FileName);

                if (Path.GetExtension(a.FileName).Equals(".exe", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Найден .exe — остановка поиска");
                    a.Cancel = true;
                }
            };

            scanner.Scan(directory);

            var max = found.GetMax(p => new FileInfo(p).Length);
            Console.WriteLine();

            if (max == null)
            {
                Console.WriteLine("Файлы не найдены.");
                return;
            }

            Console.WriteLine($"Максимальный файл: {max}");
            Console.WriteLine($"Размер: {new FileInfo(max).Length} байт");
        }
    }
}

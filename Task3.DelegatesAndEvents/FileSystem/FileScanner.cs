using System;
using System.IO;

namespace Task3.DelegatesAndEvents.FileSystem
{
    public class FileScanner
    {
        public event EventHandler FileFound;

        public void Scan(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory))
                throw new ArgumentException("Путь к каталогу пустой.", nameof(directory));

            if (!Directory.Exists(directory))
                throw new DirectoryNotFoundException(directory);

            foreach (var file in Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories))
            {
                var args = new FileArgs(file);
                FileFound?.Invoke(this, args);

                if (args.Cancel)
                    break;
            }
        }
    }
}

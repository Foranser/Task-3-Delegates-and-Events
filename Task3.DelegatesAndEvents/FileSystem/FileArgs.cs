using System;

namespace Task3.DelegatesAndEvents.FileSystem
{
    public class FileArgs : EventArgs
    {
        public string FileName { get; }
        public bool Cancel { get; set; }

        public FileArgs(string fileName)
        {
            FileName = fileName;
        }
    }
}

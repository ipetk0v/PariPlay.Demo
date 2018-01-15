using PariPlay.Demo.Helpers;
using PariPlay.Demo.Interfaces;
using System;
using System.IO;
using System.Text;

namespace PariPlay.Demo
{
    public class Engine : IEngine
    {
        private IInput readInputFromConsole;

        public Engine()
        {
            readInputFromConsole = new ConsoleInput();
        }

        public string Input()
        {
            var inputText = string.Empty;

            inputText = readInputFromConsole.ReadLine();

            return inputText;
        }

        public void Create(string consoleInput)
        {
            string path = Helper.filePath;

            if (File.Exists(path))
            {
                FileEdit(path, consoleInput);
            }
            else
            {
                FileCreate(path, consoleInput);
            }

        }

        private void FileEdit(string path, string consoleInput)
        {
            using (FileStream fs = File.Open
                (path, FileMode.Append, FileAccess.Write, FileShare.None))
            {
                WriteInFile(fs,consoleInput);
            }
        }

        private void FileCreate(string path, string consoleInput)
        {
            using (FileStream fs = File.Create(path))
            {
                WriteInFile(fs,consoleInput);
            }
        }

        private void WriteInFile(FileStream fs, string consoleInput)
        {
            Byte[] info = new UTF8Encoding(true)
                .GetBytes(Environment.NewLine + consoleInput);
            fs
                .Write(info, 0, info.Length);
        }
    }
}

using PariPlay.Demo.Helpers;
using PariPlay.Demo.Interfaces;
using System;
using System.IO;
using System.Text;

namespace PariPlay.Demo
{
    public class Engine : IEngine
    {
        private IReader readInputFromConsole;
        private IWriter writeOutputInConsole;
        private static Engine instance;

        // Lock synchronization object
        private static object syncLock = new object();

        protected Engine()
        {
            readInputFromConsole = new ConsoleReader();
            writeOutputInConsole = new ConsoleWriter();
        }

        // Method that reads input from the console
        public string Input()
        {
            var inputText = string.Empty;

            while (inputText == string.Empty)
            {
                inputText = readInputFromConsole.ReadLine();

                if (inputText == string.Empty)
                {
                    writeOutputInConsole.WriteLine(Helper.WriteError);
                }
            }


            return inputText;
        }

        //Мethod that checks if the file exists.
        //If it does not exist it creates it, if it exists, edit it.
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

        //A method that edits the current file
        private void FileEdit(string path, string consoleInput)
        {
            using (FileStream fs = File.Open
                (path, FileMode.Append, FileAccess.Write, FileShare.None))
            {
                WriteInFile(fs,consoleInput);
            }
        }

        //Mathod that create file
        private void FileCreate(string path, string consoleInput)
        {
            using (FileStream fs = File.Create(path))
            {
                WriteInFile(fs,consoleInput);
            }
        }

        //Мethod that records the incoming data in the file
        private void WriteInFile(FileStream fs, string consoleInput)
        {
            Byte[] info = new UTF8Encoding(true)
                .GetBytes(Environment.NewLine + consoleInput);
            fs
                .Write(info, 0, info.Length);
        }

        //Get Engine instance
        public static Engine Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.

            if (instance == null)
            {
                lock (syncLock)
                {
                    instance = new Engine();
                }
            }

            return instance;
        }
    }
}

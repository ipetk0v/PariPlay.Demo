using PariPlay.Demo.Interfaces;
using System;

namespace PariPlay.Demo
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}

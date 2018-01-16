using PariPlay.Demo.Interfaces;
using System;

namespace PariPlay.Demo
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}

using PariPlay.Demo.Interfaces;
using System;

namespace PariPlay.Demo
{
    public class ConsoleInput : IInput
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}

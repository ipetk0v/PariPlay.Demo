using System;
using System.IO;

namespace PariPlay.Demo.Helpers
{
    public static class Helper
    {
        public static string filePath = Path.Combine(Environment.GetFolderPath(
                         System.Environment.SpecialFolder.DesktopDirectory), "output.txt");

        public const string WriteError = "Please write something!";
    }
}

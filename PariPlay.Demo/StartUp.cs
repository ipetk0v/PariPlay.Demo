namespace PariPlay.Demo
{
    public class StartUp
    {
        public static void Main()
        {
            var engine = new Engine();
            var consoleInput = engine.Input();
            engine.Create(consoleInput);
        }
    }
}

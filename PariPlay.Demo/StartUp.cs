namespace PariPlay.Demo
{
    public class StartUp
    {
        public static void Main()
        {
            Engine engine = Engine.Instance();
            var consoleInput = engine.Input();
            engine.Create(consoleInput);
        }
    }
}

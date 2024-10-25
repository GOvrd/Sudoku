
namespace SudokuCore
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Core core = new Core();
            core.Init();
            Screen.Show(core.Field);
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                Screen.MoveCursor(keyInfo);
                //core.Init();
                Screen.Show(core.Field);
                //Screen.ShowPos();
                //Thread.Sleep(1000);
            } while (keyInfo.Key != ConsoleKey.Escape);
        }
    }
}
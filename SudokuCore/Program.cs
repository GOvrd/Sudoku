
namespace SudokuCore
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Core core = new Core();
            core.Init();
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();
                Console.Clear();
                Screen.MoveCursor(keyInfo);
                core.Init();
                Screen.Show(core.Field);
                //Screen.ShowPos();
                //Thread.Sleep(1000);
            } while (keyInfo.Key != ConsoleKey.Escape);
            //Screen.Show(core.Field);
        }
    }
}
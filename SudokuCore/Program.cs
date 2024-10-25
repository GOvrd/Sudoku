
namespace SudokuCore
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Core core = new Core();
            core.Init();
            while (true) {
                Console.Clear();
                core.Init();
                Screen.Show(core.Field);
                Thread.Sleep(1000);
            }
            //Screen.Show(core.Field);
        }
    }
}
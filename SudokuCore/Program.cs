
namespace SudokuCore
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Core core = new Core();
            core.Init();
            Screen.Show(core.Field);
        }
    }
}
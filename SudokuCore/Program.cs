
namespace SudokuCore
{
    internal class Program
    {
        public static int CheckNumber(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.D1) return 1;
            if (keyInfo.Key == ConsoleKey.D2) return 2;
            if (keyInfo.Key == ConsoleKey.D3) return 3;
            if (keyInfo.Key == ConsoleKey.D4) return 4;
            if (keyInfo.Key == ConsoleKey.D5) return 5;
            if (keyInfo.Key == ConsoleKey.D6) return 6;
            if (keyInfo.Key == ConsoleKey.D7) return 7;
            if (keyInfo.Key == ConsoleKey.D8) return 8;
            if (keyInfo.Key == ConsoleKey.D9) return 9;
            else return -1;
        }
        private static void Main(string[] args)
        {
            //Core core = new Core();
            Core.Init();
            Screen.Show(Core.Field);
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(false);
                if(Core.State == Core.States.NonInit &&  keyInfo.Key == Config.NewTableKey)
                {
                    Core.Generator();
                }
                if(CheckNumber(keyInfo) != -1)
                {
                    string message = "";
                    try
                    {
                        if (Core.SetValue(Screen.CursorPosY, Screen.CursorPosX, CheckNumber(keyInfo)))
                        {
                            Screen.Show(Core.Field);
                            Console.SetCursorPosition(0, 14);
                            message = "Sucsess";
                        }
                    }
                    catch(Exception ex)
                    {
                        message = ex.Message;
                    }
                    Console.SetCursorPosition(0, 14);
                    Console.Write(message);
                    Thread.Sleep(2000);
                }
                //if (keyInfo.Key == ConsoleKey.Enter)
                //{
                //    Console.SetCursorPosition(0, 14);
                //    Console.Write("Enter number: ");
                //    //Console.ReadLine();
                //    //keyInfo = Console.ReadKey(false);
                //    if (core.SetValue(Screen.CursorPosX, Screen.CursorPosY, Convert.ToInt32(Console.ReadLine())))
                //    {
                //        Console.Write("Sucsess");
                //        Thread.Sleep(2000);
                //    }
                //}
                Screen.MoveCursor(keyInfo);
                Screen.Show(Core.Field);

            } while (keyInfo.Key != ConsoleKey.Escape);
        }
        
    }
}
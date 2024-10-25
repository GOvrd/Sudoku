using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuCore
{
    internal static class Screen
    {
        private static string buffer = "";
        private static int cursorPosX = 0;
        private static int cursorPosY = 0;
        private static int[] posIndexX = {1, 3, 5, 9, 11, 13, 17, 19, 21 };
        private static int[] posIndexY = {1, 2, 3, 5, 6, 7, 9, 10, 11 };
        public static void ShowPos()
        {
            Console.WriteLine(cursorPosX.ToString() + "  " + cursorPosY.ToString());
        }
        public static void MoveCursor(ConsoleKeyInfo keyInfo)
        {
            if (-1 < cursorPosX && cursorPosX < Config.TableSize &&
                -1 < cursorPosY && cursorPosY < Config.TableSize)
            {
                if (cursorPosY != 0 && keyInfo.Key == ConsoleKey.W)
                {
                    cursorPosY += -1;
                }
                else if (cursorPosY != Config.TableSize - 1 && keyInfo.Key == ConsoleKey.S)
                {
                    cursorPosY += 1;
                }
                else if (cursorPosX != 0 && keyInfo.Key == ConsoleKey.A)
                {
                    cursorPosX += -1;
                }
                else if (cursorPosX != Config.TableSize - 1 && keyInfo.Key == ConsoleKey.D)
                {
                    cursorPosX += 1;
                }
            }
        }
        public static void Show(int[,] table)
        {
            Console.SetCursorPosition(posIndexX[cursorPosX] + 1, 0);
            Console.Write("v");
            Console.SetCursorPosition(0, posIndexY[cursorPosY]);
            Console.Write(">");
            Console.SetCursorPosition(1, 1);
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for(int j = 0; j < table.GetLength(1); j++)
                {
                    if(table[i, j] == 0)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write(" " + table[i, j]);
                    }
                    
                    if(j % 3 == 2)
                    {
                        if (j == Config.TableSize - 1)
                        {
                            Console.Write("\n");
                            Console.SetCursorPosition(Console.GetCursorPosition().Left + 1, Console.GetCursorPosition().Top);
                            if(i % 3 == 2 && i != Config.TableSize - 1)
                            {
                                Console.Write(" ------+-------+------\n");
                                Console.SetCursorPosition(Console.GetCursorPosition().Left + 1, Console.GetCursorPosition().Top);
                            }
                        }
                        else
                        {
                            Console.Write(" |");
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("X: " + (cursorPosX + 1).ToString() + "  Y:" + (cursorPosY + 1).ToString());
            //Console.Write(  " 1  2  3 | 4  5  6 | 7  8  9\n" +
            //                " 1  2  3 | 4  5  6 | 7  8  9\n" +
            //                " 1  2  3 | 4  5  6 | 7  8  9\n" +
            //                " --------+---------+--------\n" +
            //                " 1  2  3 | 4  5  6 | 7  8  9\n" +
            //                " 1  2  3 | 4  5  6 | 7  8  9\n" +
            //                " 1  2  3 | 4  5  6 | 7  8  9\n" +
            //                " --------+---------+--------\n" +
            //                " 1  2  3 | 4  5  6 | 7  8  9\n" +
            //                " 1  2  3 | 4  5  6 | 7  8  9\n" +
            //                " 1  2  3 | 4  5  6 | 7  8  9\n");
        }
    }
}

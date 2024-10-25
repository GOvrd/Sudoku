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
        public static void ShowPos()
        {
            Console.WriteLine(cursorPosX.ToString() + "  " + cursorPosY.ToString());
        }
        public static void MoveCursor(ConsoleKeyInfo keyInfo)
        {
            if (-1 < cursorPosX && cursorPosX < Config.TableSize &&
                -1 < cursorPosY && cursorPosY < Config.TableSize)
            {
                if (cursorPosX != 0 && keyInfo.Key == ConsoleKey.W)
                {
                    cursorPosX += -1;
                }
                else if (cursorPosX != Config.TableSize - 1 && keyInfo.Key == ConsoleKey.S)
                {
                    cursorPosX += 1;
                }
                else if (cursorPosY != 0 && keyInfo.Key == ConsoleKey.A)
                {
                    cursorPosY += -1;
                }
                else if (cursorPosY != Config.TableSize - 1 && keyInfo.Key == ConsoleKey.D)
                {
                    cursorPosY += 1;
                }
            }
        }
        public static void Show(int[,] table)
        {
            buffer = "";
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for(int j = 0; j < table.GetLength(1); j++)
                {
                    if(table[i, j] == 0)
                    {
                        buffer += "  ";
                    }
                    else
                    {
                        buffer += " " + table[i, j];
                    }
                    
                    if(j % 3 == 2)
                    {
                        if (j == Config.TableSize - 1)
                        {
                            buffer += "\n";
                            if(i % 3 == 2 && i != Config.TableSize - 1)
                            {
                                buffer += " ------+-------+------\n";
                            }
                        }
                        else
                        {
                            buffer += " |";
                        }
                    }
                }
            }
            //ConsoleKey.
            Console.WriteLine(buffer);
            Console.WriteLine(cursorPosX.ToString() + "  " + cursorPosY.ToString());
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuCore
{
    internal static class Screen
    {
        public static void Show(int[,] table)
        {
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
                        if (j == 9 - 1)
                        {
                            Console.Write("\n");
                            if(i % 3 == 2)
                            {
                                Console.Write(" ------+-------+------\n");
                            }
                        }
                        else
                        {
                            Console.Write(" |");
                        }
                    }

                }
            }
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

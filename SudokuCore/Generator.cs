using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuCore
{
    internal static class Generator
    {
        public static int[,] New()
        {
            int[,] field = new int[Config.TableSize, Config.TableSize];
            for (int i = 0; i < Config.TableSize; i++)
            {
                for (int j = 0; j < Config.TableSize; j++)
                {
                    field[i, j] = j;
                }
            }
            return field;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuCore
{
    internal static class Config
    {
        public static readonly int TableSize = 9;
        public static readonly int RegionSize = 3;
        public static readonly char EmptyChar = ' ';
        public static readonly ConsoleKey NewTableKey = ConsoleKey.N;
    }
}

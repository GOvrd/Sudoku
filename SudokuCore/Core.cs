using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SudokuCore {
    

    internal class Core
    {
        private static int[,] field = new int[9, 9];
        private static int tableSize = 9;
        private static int regionSize = 3;
        public int[,] Field { get{ return field; } }
        public int TableSize { get { return tableSize; } private set { } }
        public int RegionSize { get { return regionSize; } private set { } }

        public void Init()
        {
            for(int i = 0; i < field.GetLength(0); i++)
            {
                for(int j = 0; j < field.GetLength(1); j++)
                {
                    if 
                        (j == 4) field[i, j] = 0; 
                    else 
                        field[i, j] = j + 1;

                }
            }
        }
        
    }
}

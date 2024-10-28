using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SudokuCore {
    

    internal class Core
    {
        private static int[,] field = new int[Config.TableSize, Config.TableSize];
        private static int tableSize = Config.TableSize;
        private static int regionSize = Config.RegionSize;
        public int[,] Field { get{ return field; } }
        public int TableSize { get { return tableSize; } private set { } }
        public int RegionSize { get { return regionSize; } private set { } }

        public void Init()
        {
            //Random rnd = new Random();
            field = new int[Config.TableSize, Config.TableSize];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for(int j = 0; j < field.GetLength(1); j++)
                {
                    Random rnd = new Random();
                    field[i, j] = rnd.Next(0, 9);
                    //try
                    //{
                    //    while (SetValue(i, j, rnd.Next(1, 9))) ;
                    //}
                    //catch (Exception e) { }
                    //field[i, j] = rnd.Next(0, 9);
                }
            }
        }
        private bool checkRegion(int x, int y, int value)
        {
            for (int i = x * Config.RegionSize; i < (x + 1) * Config.RegionSize; i++)
            {
                for(int j = y * Config.RegionSize; j < (y + 1) * Config.RegionSize; j++)
                {
                    if(field[i, j] == value) return false;
                }
            }
            return true;
        }
        private bool checkColumn(int x, int value)
        {
            for (int i = 0; i < tableSize; i++)
            {
                if (field[i, x] == value) return false;
            }
            return true;
        }
        private bool checkSrting(int y, int value)
        {
            for (int i = 0; i < tableSize; i++)
            {
                if (field[y, i] == value) return false;
            }
            return true;
        }
        public bool SetValue(int x, int y, int value)
        {
            if (field[x,y] != 0)
            {
                throw new Exception("Cell not empty");
            }
            if (!checkRegion(x / 3, y / 3, value))
            {
                throw new Exception("There is such a number in the region");
            }
            if (!checkColumn(x, value))
            {
                throw new Exception("There is a number in the column");
            }
            if(!checkSrting(y, value))
            {
                throw new Exception("There is a number in the line");
            }
            
            field[x, y] = value;
            return true;
            //if (field[x, y] == 0 &&
            //    checkColumn(x, value) &&
            //    checkSrting(y, value) &&
            //    checkRegion(x / 3, y / 3, value))
            //{
            //    field[x, y] = value;
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

        }
        
    }
}

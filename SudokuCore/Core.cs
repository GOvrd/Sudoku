using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SudokuCore {
    

    internal static class Core
    {
        internal enum States
        {
            NonInit = 0,
            Generated = 1,
            Solved = 2
        }

        internal static class Generator
        {
            public static void New()
            {
                field = new int[Config.TableSize, Config.TableSize];
                for (int i = 0; i < Config.TableSize; i++)
                {
                    for (int j = 0; j < Config.TableSize; j++)
                    {
                        field[i, j] = j + 1;
                    }
                }
                int shift = 3;
                for (int i = 1; i < Config.TableSize; i++)
                {
                    for(int j = 0; j < Config.TableSize; j++)
                    {
                        field[i, j] = field[i - 1, j];
                    }
                    if (i % 3 == 0) 
                        shiftString(i, shift + 1);
                    else 
                        shiftString(i, shift);

                }
                //swapColumnsSmall(1, 2);
                //swapRowsSmall(1, 2);
                //swapRowsRegion(0, 1);
                //swapColumnsRegion(0, 1);
                state = States.Generated;
            }
            //Обмен двух строк в пределах одного района(swap_rows_small)
            //Обмен двух столбцов в пределах одного района(swap_colums_small)
            //Обмен двух районов по горизонтали(swap_rows_area)
            //Обмен двух районов по вертикали (swap_colums_area)
            //Начальный сдвиг по горизонтали (shiftString)
            //Начальный сдвиг по вертикали (shiftColumn)
            //Транспонирование (transposition)
            private static void swapRowsSmall(int first, int second)
            {
                for(int i = 0;i < Config.TableSize; i++)
                {
                    int tmp = field[first, i];
                    field[first, i] = field[second, i];
                    field[second, i] = tmp;
                }
            }
            private static void swapColumnsSmall(int first, int second)
            {
                for (int i = 0; i < Config.TableSize; i++)
                {
                    int tmp = field[i, first];
                    field[i, first] = field[i, second];
                    field[i, second] = tmp;
                }
                //transposition();
                //swapRowsSmall(first, second);
                //transposition();
            }
            private static void swapRowsRegion(int first, int second)
            {
                swapRowsSmall(first * Config.RegionSize, second * Config.RegionSize);
                swapRowsSmall(first * Config.RegionSize + 1, second * Config.RegionSize + 1);
                swapRowsSmall(first * Config.RegionSize + 2, second * Config.RegionSize + 2);
            }
            private static void swapColumnsRegion(int first, int second)
            {
                swapColumnsSmall(first * Config.RegionSize, second * Config.RegionSize);
                swapColumnsSmall(first * Config.RegionSize + 1, second * Config.RegionSize + 1);
                swapColumnsSmall(first * Config.RegionSize + 2, second * Config.RegionSize + 2);
            }
            private static void shiftString(int index, int shift)
            {
                for (int i = 0; i < shift; i++)
                {
                    int temp = field[index, 0];
                    for (int j = 0; j < Config.TableSize - 1; j++)
                    {
                        field[index, j] = field[index, j + 1];
                    }
                    field[index, Config.TableSize - 1] = temp;
                }
            }
            private static void shiftColumn(int index, int shift)
            {
                for (int i = 0; i < shift; i++)
                {
                    int temp = field[0, index];
                    for (int j = 0; j < Config.TableSize - 2; j++)
                    {
                        field[j, index] = field[j + 1, index];
                    }
                    field[Config.TableSize - 1, index] = temp;
                }
            }
            private static void transposition()
            {
                for (int i = 0; i < Config.TableSize; i++)
                {
                    for (int j = 0; j < Config.TableSize; j++)
                    {
                        int tmp = field[i, j];
                        field[i, j] = field[j, i];
                        field[j, i] = tmp;
                    }
                }
            }
        }

        private static int[,] field = new int[Config.TableSize, Config.TableSize];
        private static int tableSize = Config.TableSize;
        private static int regionSize = Config.RegionSize;
        private static States state = States.NonInit;

        private static bool checkRegion(int x, int y, int value)
        {
            for (int i = x * Config.RegionSize; i < (x + 1) * Config.RegionSize; i++)
            {
                for (int j = y * Config.RegionSize; j < (y + 1) * Config.RegionSize; j++)
                {
                    if (field[i, j] == value) return false;
                }
            }
            return true;
        }
        private static bool checkColumn(int x, int value)
        {
            for (int i = 0; i < tableSize; i++)
            {
                if (field[i, x] == value) return false;
            }
            return true;
        }
        private static bool checkSrting(int y, int value)
        {
            for (int i = 0; i < tableSize; i++)
            {
                if (field[y, i] == value) return false;
            }
            return true;
        }

        public static int[,] Field { get{ return field; } }
        public static int TableSize { get { return tableSize; } }
        public static int RegionSize { get { return regionSize; } }
        public static States State { get { return state; } }

        public static void Init()
        {
            for (int i = 0; i < Config.TableSize; i++)
            {
                for (int j = 0; j < Config.TableSize; j++)
                {
                    field[i, j] = 0;
                }
            }
        }        
        public static bool SetValue(int x, int y, int value)
        {
            if (field[x,y] != 0)
            {
                throw new Exception("Cell not empty");
            }
            if (!checkRegion(x / 3, y / 3, value))
            {
                throw new Exception("There is such a number in the region");
            }
            if (!checkColumn(y, value))
            {
                throw new Exception("There is a number in the column");
            }
            if(!checkSrting(x, value))
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

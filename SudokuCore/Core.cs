using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


//+---------------------------------------------+
//|                 CORE(STRUCTURE)             |
//|---------------===private===-----------------|
//|     field <==> matrix TableSize x TableSize |
//|                    (from Config file)       |
//|                                             |
//|     state - Not initialize,                 |
//|             generated or                    |
//|             solved                          |
//|---------==========================----------|
//|                                             |
//|                 Init()----------------------|-->
//|             Init field full zero            |
//|                                             |
//|               SetValue()-----------<--------|-<-
//|         Try set new value to field          |
//|           Or set and return true,           |
//|       or throw exeption with message        |
//|                                             |
//|                         +-------------------+
//|                         |     Generator     |
//|                         |                   |
//|                         |       New()-------|-->
//|                         |    Gen new field  |
//+-------------------------+-------------------+

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
            //map_seed will be more 100.000.000 and under 999.999.999
            public static void New(int map_seed = 0)
            //map_seed will be more 100.000.000 and under 999.999.999
            {
                //12345
                if (map_seed == 0)
                {
                    Random rnd = new Random();
                   map_seed = rnd.Next(10000, 99999);
                }
                seed = map_seed;
                field = new int[Config.TableSize, Config.TableSize];
                for (int i = 0; i < Config.TableSize; i++)
                {     
                    field[0, i] = i + 1;
                }
                for (int i = 1; i < Config.TableSize; i++)
                {
                    for(int j = 0; j < Config.TableSize; j++)
                    {
                        field[i, j] = field[i - 1, j];
                    }
                    if (i % Config.RegionSize == 0) shiftString(i, 1);
                    shiftString(i, Config.RegionSize);
                }
                for(int i = 0; i < (seed % 10) * 5; i++)
                {
                    swapColumnsSmall((seed % 100) % 3, (seed % 1000 / 10) % 3);
                    swapColumnsSmall((seed % 1000 / 10) % 3, (seed % 10000 / 100) % 3);
                    swapColumnsSmall((seed % 10000 / 100) % 3, seed % 3);

                    swapColumnsRegion((seed % 100) % 3, (seed % 1000 / 10) % 3);
                    swapColumnsRegion((seed % 1000 / 10) % 3, (seed % 10000 / 100) % 3);
                    swapColumnsRegion((seed % 10000 / 100) % 3, seed % 3);

                    swapRowsSmall((seed % 100) % 3, (seed % 1000 / 10) % 3);
                    swapRowsSmall((seed % 1000 / 10) % 3, (seed % 10000 / 100) % 3);
                    swapRowsSmall((seed % 10000 / 100) % 3, seed % 3);

                    swapRowsRegion((seed % 100) % 3, (seed % 1000 / 10) % 3);
                    swapRowsRegion((seed % 1000 / 10) % 3, (seed % 10000 / 100) % 3);
                    swapRowsRegion((seed % 10000 / 100) % 3, seed % 3);
                    if((seed % 1000 / 100) % 2 == 1)
                    {
                        transpose();
                    }
                }
                //swapColumnsSmall(1, 2);
                //swapRowsSmall(1, 2);
                //swapRowsRegion(0, 1);
                //swapColumnsRegion(0, 1);
                //transposition();
                //state = States.Generated;
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
                transpose();
                swapRowsSmall(first, second);
                transpose();
            }
            private static void swapRowsRegion(int first, int second)
            {
                swapRowsSmall(first * Config.RegionSize, second * Config.RegionSize);
                swapRowsSmall(first * Config.RegionSize + 1, second * Config.RegionSize + 1);
                swapRowsSmall(first * Config.RegionSize + 2, second * Config.RegionSize + 2);
            }
            private static void swapColumnsRegion(int first, int second)
            {
                transpose();
                swapRowsRegion(first, second);
                transpose();
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
            private static void transpose()
            {
                for (int i = 1; i < Config.TableSize; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        int tmp = field[i, j];
                        field[i, j] = field[j, i];
                        field[j, i] = tmp;
                    }
                }
            }
        }
        private static int seed = 12345;
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

        public static int Seed { get { return seed; } }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Board
    {
        private int[,] a = new int[9, 9];
        private int[] check = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public Board()
        {

        }
        public void Display()
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }
        }
        public int this[int x, int y]
        {
            get => a[x, y];
            set => a[x, y] = value > 0 && value < 10 ? value : a[x, y];
        }
    }
}

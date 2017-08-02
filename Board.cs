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
        public Board() { }
        public void Display()
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    Console.Write(a[j, i] + " ");
                Console.WriteLine();
            }
        }
        public int this[int x, int y]
        {
            get => a[x, y];
            set => a[x, y] = value > 0 && value < 10 ? value : a[x, y];
        }
        public bool NotFull
        {
            get
            {
                foreach(var x in a)
                {
                    if (x == 0)
                        return true;
                }
                return false;
            }
        }
        public void Check(int x, int y)
        {
            List<int> t = new List<int> ();
            for(int i=1;i<10;i++)
            {
                t.Add(i);
            }
            int c1 = x >= 0 && x < 3 ? 0 : x >= 3 && x < 6 ? 3 : 6;
            int c2 = y >= 0 && y < 3 ? 0 : y >= 3 && y < 6 ? 3 : 6;

            for (int i = c1; i < c1 + 3; i++)
            {
                for (int j = c2; j < c2 + 3; j++)
                {
                    t.Remove(a[i, j]);
                }
            }
            for (int i = 0; i < 9; i++)
            {
                t.Remove(a[x, i]);
                t.Remove(a[i, y]);
            }
            if (t.Count == 1)
            {
                a[x, y] = t[0];
            }
        }
    }
}

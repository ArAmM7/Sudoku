using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            Board a = new Board();
            {
                a[0, 0] = 7;
                a[1, 0] = 8;
                a[2, 0] = 2;
                a[7, 0] = 9;
                a[8, 0] = 6;
                a[0, 1] = 5;
                a[1, 1] = 4;
                a[1, 2] = 9;
                a[2, 1] = 3;
                a[7, 1] = 8;
                a[8, 1] = 7;
                a[0, 2] = 6;
                a[2, 2] = 1;
                a[6, 2] = 3;
                a[8, 2] = 5;
                a[3, 3] = 4;
                a[6, 3] = 6;
                a[7, 3] = 3;
                a[3, 4] = 8;
                a[4, 4] = 1;
                a[5, 4] = 7;
                a[6, 4] = 5;
                a[8, 4] = 4;
                a[3, 5] = 9;
                a[5, 5] = 6;
                a[7, 5] = 1;
                a[8, 5] = 8;
                a[1, 6] = 5;
                a[2, 6] = 9;
                a[3, 6] = 1;
                a[4, 6] = 6;
                a[2, 7] = 4;
                a[3, 7] = 3;
                a[4, 7] = 5;
                a[5, 7] = 9;
                a[0, 8] = 1;
                a[1, 8] = 6;
                a[2, 8] = 8;
                a[4, 8] = 7;
                a.Display();
            }
            int q = 0;
            while (a.NotFull)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (a[i, j] == 0)
                        {
                            a.Check(i, j);
                            q++;
                        }
                    }
                }
            }
            Console.Beep();
            Console.WriteLine(q);
            a.Display();
        }
    }
}

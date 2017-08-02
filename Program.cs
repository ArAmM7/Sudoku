using System;
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
            a[1, 1] = 5;
            a.Display();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Board
    {
        private int[,] a;

        private int steps;

        private int changes;

        public int Steps
        {
            get => steps;
        }

        private bool NotFull
        {
            get
            {
                foreach (var x in a)
                {
                    if (x == 0)
                        return true;
                }
                return false;
            }
        }

        public Board()
        {
            a = new int[9, 9];
            steps = 0;
            changes = 0;
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

        public void Start()
        {
            Console.WriteLine("enter the sudoku puzzle from the keyboard one row at a time using space to move to the next column, and enter to move to the next row \n P.S. use zero for empty slots");
            for (int i = 0; i < 9; i++)
            {
                string s = Console.ReadLine();
                for (int j = 0, k = 0; j < 9; j++, k += 2)
                {
                    a[i, j] = int.Parse(s[k].ToString());
                }
            }
            //checking for errors in the puzzle

            List<int> t = new List<int>();

            //checking in 3*3 squares one by one

            for (int i = 0; i < 7; i+=3)
            {
                for (int j = 0; j < 7; j+=3)
                {
                    t.Clear();
                    for (int x = i; x < i + 3; x++) 
                    {
                        for (int y = j; y < j + 3; y++)
                        {
                            if (a[x,y]!=0)
                            {
                                t.Add(a[x, y]); 
                            }
                        }
                    }
                    if(HasRepetition(t))
                    {
                        Finish();
                        return;
                    }
                }
            }
            //Console.WriteLine("passed check 1");

            //checking in rows and columns

            for (int i = 0; i < 9; i++) 
            {
                t.Clear();
                for (int j = 0; j < 9; j++)
                {
                    if (a[i, j] != 0)
                    {
                        t.Add(a[i, j]);
                    }
                }
                if (HasRepetition(t))
                {
                    Finish();
                    return;
                }
            }
            //Console.WriteLine("passed ceck 2");

            for (int i = 0; i < 9; i++)
            {
                t.Clear();
                for (int j = 0; j < 9; j++)
                {
                    if (a[j, i] != 0)
                    {
                        t.Add(a[j, i]);
                    }
                }
                if (HasRepetition(t))
                {
                    Finish();
                    return;
                }
            }
            //Console.WriteLine("passed check 3");
            Solve();
            Finish();
        }

        private void Solve()
        {
            while (NotFull)
            {
                changes = 0;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (a[i, j] == 0)
                        {
                            Check(i, j);
                            steps++;
                        }
                    }
                }
                if(changes == 0 )//no changes after one full loop on the board, means that the puzzle can't be solved(any further)
                {
                    return;
                }
            }
            //Console.WriteLine("solved");
        }
        
        private void Check(int x, int y)
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
                changes++;
            }
        }

        private void Finish()
        {
            if (!NotFull)
            {
                Console.WriteLine("\n solved in {0} steps \n", Steps);
                Display();
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\n puzzle can't be solved(any further or there are multiple solutions) after {0} steps or there are errors in the puzzle, check for errors or try another puzzle \n",Steps);
                Display();
                Console.ReadLine();
            }
        }

        public bool HasRepetition(List<int> lst)
        {
            if (lst.Count > 1) 
            {
                int reps = 0;
                foreach (int t1 in lst)
                {
                    foreach (int t2 in lst)
                    {
                        if (t1 == t2)////////////////////////////////////////////////////////////////////
                        {
                            reps++;
                        }
                    }
                }
                if (reps == lst.Count)
                {
                    return false;
                }
                return true; 
            }
            return false;
        }

    }
}
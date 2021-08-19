using System;
using System.Threading;

namespace SudokuSolver
{
    internal class Program
    {
        public static void Main()
        {
            string arg = "[5,3,0,0,7,0,0,0,0]\n[6,0,0,1,9,5,0,0,0]\n[0,9,8,0,0,0,0,6,0]\n[8,0,0,0,6,0,0,0,3]\n[4,0,0,8,0,3,0,0,1]\n[7,0,0,0,2,0,0,0,6]\n[0,6,0,0,0,0,2,8,0]\n[0,0,0,4,1,9,0,0,5]\n[0,0,0,0,8,0,0,7,9]";
            int[,] Field = SudokuFieldFactory.ParseSysArg(arg);
            int ctr = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Field[i, j] == 0) ctr++;
                }
            }
            UnknownCell[] lst = new UnknownCell[ctr];
            ctr = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Field[i, j] == 0)
                    {
                        lst[ctr] = new UnknownCell(i, j, Field);
                        ctr++;
                    }
                }
            }

            if (!Solver.MRV(Field, lst)) Console.WriteLine("An Error occured!");
            Console.WriteLine();
            Console.WriteLine(arg);
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(Field[i,j]+",");
                }
                Console.WriteLine();
            }
            /*int[,] emptyField = new int[9, 9];
            foreach (UnknownCell cell in lst)
            {
                emptyField[cell.i, cell.j] = cell.numOfPossible;
            }
            Console.WriteLine(arg);
            Console.WriteLine();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(emptyField[i,j]+",");
                }
                Console.WriteLine();
            }*/
        }
    }
}
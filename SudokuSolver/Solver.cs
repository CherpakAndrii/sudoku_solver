using System;

namespace SudokuSolver
{
    public class Solver
    {
        public static bool MRV(int[,] Field, UnknownCell[] lst)
        {
            /*int[,] nField = (int[,]) Field.MemberwiseClone();
            UnknownCell[] nlst = (UnknownCell[]) lst.MemberwiseClone();*/
            Array.Sort(lst, delegate(UnknownCell cell1, UnknownCell cell2) {  return cell1.numOfPossible.CompareTo(cell2.numOfPossible);});
            if (lst[0].setted) return true;
            foreach (int posVal in lst[0].possibleNums)
            {
                if (posVal != 0)
                {
                    if (!lst[0].fill(posVal, Field, lst))
                    {
                        Console.WriteLine("Okay, let`s try another number");
                        return false;
                    }
                    Console.WriteLine($"Ok, {posVal} on {lst[0].i}:{lst[0].j}");
                    if (MRV(Field, lst)) return true;
                }
            }
            return false;
        }
        
    }
}
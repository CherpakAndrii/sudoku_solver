using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    public class Solver
    {
        /*public static bool MRV(int[,] Field, UnknownCell[] lst)
        {
            //int[,] nField = (int[,]) Field.MemberwiseClone();
            //UnknownCell[] nlst = (UnknownCell[]) lst.MemberwiseClone();
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
        }*/
        public static bool Solve(ref int[,] Field, ref List<EmptyCell> lst, ref Row[] rows, ref Column[] columns, ref Sector[] sectors)
        {
            while (lst is {Count: > 0})
            {
                UpdatePossibleValues(ref lst, ref rows, ref columns, ref sectors);
                lst.Sort(delegate(EmptyCell cell1, EmptyCell cell2)
                {
                    return cell1.PossibleValues.Count.CompareTo(cell2.PossibleValues.Count);
                });
                if (!lst[0].fill(ref Field, ref rows, ref columns, ref sectors)) return false;
                lst.RemoveAt(0);
            }
            return true;
        }

        private static void UpdatePossibleValues(ref List<EmptyCell> lst, ref Row[] rows, ref Column[] columns, ref Sector[] sectors)
        {
            foreach (EmptyCell cell in lst)
            {
                cell.UpdatePossibleValues(ref rows, ref columns, ref sectors);
            }
        }
        
    }
}
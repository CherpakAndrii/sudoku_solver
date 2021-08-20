using System.Collections.Generic;

namespace SudokuSolver
{
    public class EmptyCell
    {
        public int row, col, sect;
        public bool setted;
        public HashSet<int> PossibleValues;
        

        public EmptyCell(int i, int j)
        {
            row = i;
            col = j;
            sect = i / 3 * 3 + j / 3;
            setted = false;
            PossibleValues = new HashSet<int>();
        }

        public bool fill(ref int[,] Field, ref Row[] rows, ref Column[] columns, ref Sector[] sectors)
        {
            if (PossibleValues.Count == 0) return false;
            int num = 0;
            foreach (int posNum in PossibleValues)
            {
                num = posNum;
                break;
            }
            Field[row, col] = num;
            setted = true;
            rows[row].PossibleValues.Remove(num);
            columns[col].PossibleValues.Remove(num);
            sectors[sect].PossibleValues.Remove(num);
            return true;
        }

        public void UpdatePossibleValues(ref Row[] rows, ref Column[] columns, ref Sector[] sectors)
        {
            PossibleValues = rows[row].PossibleValues;
            PossibleValues.IntersectWith(columns[col].PossibleValues);
            PossibleValues.IntersectWith(sectors[sect].PossibleValues);
        }
    }
}
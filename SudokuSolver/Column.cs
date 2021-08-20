using System.Collections.Generic;

namespace SudokuSolver
{
    public class Column
    {
        public int ColumnNum;
        public HashSet<int> PossibleValues;

        public Column(int[,] Matrix, int num)
        {
            PossibleValues = new HashSet<int>();
            ColumnNum = num;
            for (int posVal = 1; posVal < 10; posVal++)
            {
                bool flag = true;
                for (int cellNum = 0; cellNum < 9; cellNum++)
                {
                    if (Matrix[cellNum, ColumnNum] == posVal)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) PossibleValues.Add(posVal);
            }
        }
    }
}
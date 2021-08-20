using System.Collections.Generic;

namespace SudokuSolver
{
    public class Row
    {
        public int RowNum;
        public HashSet<int> PossibleValues;

        public Row(int[,] Matrix, int num)
        {
            PossibleValues = new HashSet<int>();
            RowNum = num;
            for (int posVal = 1; posVal < 10; posVal++)
            {
                bool flag = true;
                for (int cellNum = 0; cellNum < 9; cellNum++)
                {
                    if (Matrix[RowNum, cellNum] == posVal)
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
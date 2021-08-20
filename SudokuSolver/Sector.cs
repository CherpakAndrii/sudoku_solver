using System.Collections.Generic;

namespace SudokuSolver
{
    public class Sector
    {
        public int SectorNum;
        public HashSet<int> PossibleValues;

        public Sector(int[,] Matrix, int num)
        {
            PossibleValues = new HashSet<int>();
            SectorNum = num;
            for (int posVal = 1; posVal < 10; posVal++)
            {
                bool flag = true;
                for (int RowNum = SectorNum / 3 * 3; RowNum < SectorNum / 3 * 3 + 3; RowNum++)
                {
                    for (int ColumnNum = SectorNum % 3 * 3; RowNum < SectorNum % 3 * 3 + 3; RowNum++)
                    {
                        if (Matrix[RowNum, ColumnNum] == posVal)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if (flag) PossibleValues.Add(posVal);
            }
        }
    }
}
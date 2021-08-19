using System;

namespace SudokuSolver
{
    public class SudokuFieldFactory
    {
        public static int[,] ParseSysArg(String SysArg)
        {
            int[,] Field = new int[9, 9];

            int tipaIterator = 1;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Field[i, j] = SysArg[tipaIterator]-48;
                    tipaIterator += 2;
                }
                tipaIterator += 2;
            }

            return Field;
        }
    }
}
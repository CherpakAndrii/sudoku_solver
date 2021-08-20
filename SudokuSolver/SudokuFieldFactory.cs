using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    public class SudokuFieldFactory
    {
        public static int[,] ParseSysArg(String SysArg, ref List<EmptyCell> lst, ref Row[] rows, ref Column[] columns, ref Sector[] sectors)
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

            for (int ctr = 0; ctr < 9; ctr++)
            {
                rows[ctr] = new Row(Field, ctr);
                columns[ctr] = new Column(Field, ctr);
                sectors[ctr] = new Sector(Field, ctr);
                for (int j = 0; j < 9; j++)
                {
                    if (Field[ctr, j] == 0)
                    {
                        lst.Add(new EmptyCell(ctr, j));
                    }
                }
            }

            return Field;
        }
    }
}
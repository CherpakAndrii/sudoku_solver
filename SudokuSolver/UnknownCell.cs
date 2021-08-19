namespace SudokuSolver
{
    public class UnknownCell
    {
        public int i, j;
        public int[] possibleNums;
        public bool setted;
        public int numOfPossible = 9;
        

        public UnknownCell(int x, int y, int[,] Field)
        {
            possibleNums = new []{1, 2, 3, 4, 5, 6, 7, 8, 9};
            i = x;
            j = y;
            for (int ctr = 0; ctr < 9; ctr++)
            {
                if (Field[i, ctr]>0 && possibleNums[Field[i, ctr]-1] != 0)
                {
                    possibleNums[Field[i, ctr]-1] = 0;
                    numOfPossible--;
                }
                if (Field[ctr, j]>0 && possibleNums[Field[ctr, j] - 1] != 0)
                {
                    possibleNums[Field[ctr, j] - 1] = 0;
                    numOfPossible--;
                }

                for (int iterI = 0; iterI < 3; iterI++)
                {
                    for (int iterJ = 0; iterJ < 3; iterJ++)
                    {
                        if (Field[i/3+iterI, j/3+iterJ]>0 && possibleNums[Field[i/3+iterI, j/3+iterJ]-1] != 0)
                        {
                            possibleNums[Field[i/3+iterI, j/3+iterJ]-1] = 0;
                            numOfPossible--;
                        }
                    }
                }
            }
        }

        public bool fill(int num, int[,] Field, UnknownCell[] lst)
        {
            Field[i, j] = num;
            setted = true;
            numOfPossible = 10;
            foreach (UnknownCell cell in lst)
            {
                if ((cell.i == i || cell.j == j || cell.i/3 == i/3 && cell.j/3 == j/3) && !cell.setted)
                {
                    if (cell.possibleNums[num - 1] != 0)
                    {
                        cell.possibleNums[num - 1] = 0;
                        cell.numOfPossible--;
                        if (cell.numOfPossible == 0) return false;
                    }
                }
            }
            return true;
        }
    }
}
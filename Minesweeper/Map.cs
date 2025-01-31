using System;

namespace Minesweeper
{
    public class Map
    {
        private char[,] map;
        const int RADIUS = 1;

        public Map(int rows, int cols, int mines)
        {
            InitMap(rows, cols, mines);
            //Random random=new Random();
            //RegenerateMap(m, n, mines, random.Next(0, m), random.Next(0, n));
        }

        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public int Mines { get; set; }

        public char this[int i, int j]
        {
            get { return map[i, j]; }
            private set { map[i, j] = value; }
        }

        private bool IsZero(int dfci,
                            int fci,
                            int ifci,
                            int dfcj,
                            int fcj,
                            int ifcj)
        {
            return map[dfci, dfcj] == '0' &&
                   map[dfci, fcj] == '0' &&
                   map[dfci, ifcj] == '0' &&
                   map[fci, dfcj] == '0' &&
                   map[fci, fcj] == '0' &&
                   map[fci, ifcj] == '0' &&
                   map[ifci, dfcj] == '0' &&
                   map[ifci, fcj] == '0' &&
                   map[ifci, ifcj] == '0';
        }

        private void Shuffle(int fci, int fcj)
        {
            Random random = new Random();
            int dfci = fci - 1, ifci = fci + 1;
            int dfcj = fcj - 1, ifcj = fcj + 1;
            dfci = dfci > 0 ? dfci : 0;
            dfcj = dfcj > 0 ? dfcj : 0;
            ifci = ifci < Rows ? ifci : Rows - 1;
            ifcj = ifcj < Cols ? ifcj : Cols - 1;
            int r, c;
            for (int i = 0; i < Mines;)
            {
                r = random.Next(0, Rows);
                c = random.Next(0, Cols);
                if (map[r, c] != 'B' &&
                    r != fci &&
                    c != fcj)
                {
                    char temp = map[r, c];
                    map[r, c] = 'B';
                    if (!IsZero(dfci, fci, ifci, dfcj, fcj, ifcj))
                        map[r, c] = temp;
                    i++;
                }
            }
        }

        private void InitMap(int rows, int cols, int mines)
        {
            Rows = rows;
            Cols = cols;
            Mines = mines;
            map = new char[Rows, Cols];
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    map[i, j] = '0';
        }

        public void RegenerateMap(int rows, int cols, int mines
            , int firstClickedI, int firstClickedJ)
        {
            InitMap(rows, cols, mines);
            Shuffle(firstClickedI, firstClickedJ);
            Analyzing();
        }

        private void Analyzing()
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    if (map[i, j] != 'B')
                        map[i, j] = (CalcSrndBombs(i, j) + "")[0];
        }

        private int CalcSrndBombs(int row, int col)
        {
            int Bombs = 0;
            for (int i = row - RADIUS; i <= row + RADIUS; i++)
                if (i >= 0 && i < Rows)
                    for (int j = col - RADIUS; j <= col + RADIUS; j++)
                        if (j >= 0 && j < Cols && map[i, j] == 'B')
                            Bombs++;
            return Bombs;
        }
    }
}
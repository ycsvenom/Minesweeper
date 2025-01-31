namespace Minesweeper
{
    public class Mode
    {
        public int Rows;
        public int Cols;
        public int Mines;

        public Mode(int Rows, int Cols, int Mines)
        {
            this.Rows = Rows;
            this.Cols = Cols;
            this.Mines = Mines;
        }
    }
}

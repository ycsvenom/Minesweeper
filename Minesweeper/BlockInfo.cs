using System.Drawing;

namespace Minesweeper
{
    public class BlockInfo
    {
        public Point Location;
        private bool isOpened = false;
        public bool IsFlagged = false;
        public bool IsBomb = false;
        public static int BlocksOpened = 0;

        public BlockInfo(Point Loc)
        {
            Location = Loc;
        }

        public bool IsOpened
        {
            get => isOpened;
            set
            {
                if (value && !isOpened)
                    BlocksOpened++;
                isOpened = value;
            }
        }
    }
}

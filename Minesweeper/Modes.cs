namespace Minesweeper
{
    public static class Modes
    {
        public static Mode Easy = new Mode(9, 9, 10);
        public static Mode Intermediate = new Mode(16, 16, 40);
        public static Mode Expert = new Mode(30, 16, 99);
    }
}

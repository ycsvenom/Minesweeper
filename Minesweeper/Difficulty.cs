using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Difficulty : Form
    {
        public Mode CustomMode;

        public Difficulty(Mode nowMode)
        {
            InitializeComponent();
            CustomMode = nowMode;
        }

        private void BtnSetMode_Click(object sender, EventArgs e)
        {
            int rows = (int)nudRows.Value;
            int cols = (int)nudCols.Value;
            int mines = (int)nudMines.Value;
            int r = CustomMode.Rows, c = CustomMode.Cols, m = CustomMode.Mines;
            if (cols >= 2 && cols <= 40)
                c = cols;
            if (rows >= 2 && rows <= 40)
                r = rows;
            if (mines >= 2 && mines <= 960 && mines < Math.Ceiling(r * c * 0.6))
                m = mines;
            CustomMode = new Mode(r, c, m);
            Hide();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            nudRows.Value = CustomMode.Rows;
            nudCols.Value = CustomMode.Cols;
            nudMines.Value = CustomMode.Mines;
        }
    }
}

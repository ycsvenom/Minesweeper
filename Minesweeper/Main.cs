using Minesweeper.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;


/*
	1- Change Sound
	2- Add Settings Menu								Done
	3- Add Additional rows, columns and mines			Done
	4- Control Window Sizing							Done
	5- Enhance GUI										Done
	6- Fuck The loser (Message box "Fuck you loser")	Done
	7- if wins (you're gonna lose next time Butthead)	Done
	8- Add dark theme
	9- Add Hint (next Bomb revealed)
	10- add help
*/

namespace Minesweeper
{
    public partial class Main : Form
    {
        public static PictureBox pbRestart;
        public static Image[] LosingImages;
        public static Bool WinState = Bool.Qubit;
        readonly SoundPlayer BombSoundEffect = new SoundPlayer(Resources.BombEffect);
        readonly SoundPlayer WinSoundEffect = new SoundPlayer(Resources.Win);
        Mode mode = Modes.Easy;
        Game game;

        public Main()
        {
            InitializeComponent();

            pbRestart = new PictureBox
            {
                Location = new Point(385, 27),
                Image = Resources.normal,
                Name = "pbRestart",
                Size = new Size(60, 60),
                SizeMode = PictureBoxSizeMode.StretchImage,
                TabIndex = 12,
                TabStop = false
            };
            ((System.ComponentModel.ISupportInitialize)(pbRestart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pbRestart)).EndInit();
            pbRestart.Click += new EventHandler(Restart);
            Controls.Add(pbRestart);
            pbRestart.BringToFront();
        }

        public enum Bool
        {
            True,
            Qubit,
            False
        }


        private void Main_Load(object sender, EventArgs e)
        {
            game = new Game(Modes.Easy
                            , pnlContainer
                            , ChangePic
                            , Container_MouseUp
                            , Container_MouseDown);
            BombSoundEffect.Load();
            WinSoundEffect.Load();
            LosingImages = new Image[] { Resources.dead0, Resources.dead1, Resources.dead2, Resources.losing };

            CenterControl(pnlContainer);
            OutputLeftMines();
        }

        private void CenterControl(Control control)
        {
            int x = control.Parent.Width / 2 - control.Width / 2;
            int y = control.Parent.Height / 2 - control.Height / 2;
            control.Location = new Point(x, y);
        }

        bool firstClick = true;

        private void ChangePic(object sender, MouseEventArgs e)
        {
            if (WinState == Bool.Qubit)
            {
                PictureBox clicked = (PictureBox)sender;
                BlockInfo clickedInfo = game.GetInfo(clicked);
                bool wasBomb = false;
                if (firstClick)
                    game.GenearateMap(clicked);
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        if (clickedInfo.IsOpened)
                            wasBomb = game.RevealSurroundBlocks(clickedInfo.Location.X, clickedInfo.Location.Y);
                        else
                            wasBomb = game.OpenBlock(clicked);
                        break;

                    case MouseButtons.Right:
                        game.FlagBlock(clicked);
                        break;

                    case MouseButtons.Middle:
                        wasBomb = game.RevealSurroundBlocks(clickedInfo.Location.X, clickedInfo.Location.Y);
                        break;
                }
                if (wasBomb)
                    Lost(clicked);
                if (game.Rows * game.Cols - game.Mines == BlockInfo.BlocksOpened)
                    Win();
            }
            OutputLeftMines();
            firstClick = false;
        }


        private void OutputLeftMines()
        {
            lblLeftMines.Text = (game.Mines - game.Flags).ToString("D3");
            CenterControl(lblLeftMines);
        }

        private void Win()
        {
            WinState = Bool.True;
            pbRestart.Image = Resources.winning;
            game.FlagAllBombs();
            WinSoundEffect.Play();
            MessageBox.Show("You have win");
            //SpeechSynthesizer synthesizer = new SpeechSynthesizer
            //{
            //	Volume = 100,
            //	Rate = -1
            //};
            //synthesizer.Speak("you're gonna lose next time Butthead");
        }

        private void Lost(PictureBox Mine)
        {
            Mine.BackColor = Color.Red;
            Random random = new Random();
            pbRestart.Image = LosingImages[random.Next(0, LosingImages.Length)];
            BombSoundEffect.Play();
            WinState = Bool.False;
            game.RevealAllBombs();
            MessageBox.Show("You have Lost");
            //SpeechSynthesizer synthesizer = new SpeechSynthesizer
            //{
            //	Volume = 100, 
            //	Rate = -1 
            //};
            //synthesizer.Speak("Fuck You loser");
        }

        private void Restart(object sender, EventArgs e)
        {
            pbRestart.Image = Resources.normal;
            game.Resize(mode);
            PerformLayout();
            WinState = Bool.Qubit;
            OutputLeftMines();
            firstClick = true;
            //MessageBox.Show("Mines is More than blocks or very close to it! ");
        }

        //private Size btnSizeDiff;

        private void Main_ResizeBegin(object sender, EventArgs e)
        {
            //btnSizeDiff = Size - (Size)btnRestart.Location;
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            Size center = new Size(Size.Width / 2, Size.Height / 2);
            //btnRestart.Location = new Point(Size - btnSizeDiff);
            pnlBoard.Location = new Point(
                center.Width - pnlBoard.Width / 2, center.Height - pnlBoard.Height / 2
                );
            game.MaintainBlocksLocations();

        }

        bool isDown = false;

        private void pnlBoard_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
        }

        private void pnlBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                using (Control c = new Control { Parent = pnlBoard, Location = pnlBoard.PointToClient(new Point(e.X, e.Y)) })
                    pnlBoard.ScrollControlIntoView(c);
            }
        }

        private void pnlBoard_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }

        bool isSurprised = false;
        Image[] images = new Image[9];

        private void Container_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isSurprised && WinState == Bool.Qubit)
            {
                if (e.Button == MouseButtons.Left)
                {
                    pbRestart.Image = Resources.opening;
                    BlockInfo blockInfo = game.GetInfo((PictureBox)sender);
                    /*
					int x = blockInfo.Location.Y;
					int y = blockInfo.Location.X;
					for (int i = y - 1; i <= y + 1; i++)
						if (i >= 0 && i < game.Rows)
							for (int j = x - 1; j <= x + 1; j++)
								if (j >= 0 && j < game.Cols)
								{
									images[i * 3 + j] = game.Blocks[i][j].Image;
									game.Blocks[i][j].Image = Resources._0;
								}
					*/
                }
            }
            isSurprised = true;
        }

        private void Container_MouseUp(object sender, MouseEventArgs e)
        {
            if (WinState == Bool.Qubit)
            {

                if (e.Button == MouseButtons.Left)
                {
                    /*
					BlockInfo blockInfo = game.GetInfo((PictureBox)sender);
					int x = blockInfo.Location.Y;
					int y = blockInfo.Location.X;
					for (int i = y - 1; i <= y + 1; i++)
						if (i >= 0 && i < game.Rows)
							for (int j = x - 1; j <= x + 1; j++)
								if (j >= 0 && j < game.Cols)
								{
									game.Blocks[i][j].Image = images[i * 3 + j];
								}
					*/
                    pbRestart.Image = Resources.normal;
                    isSurprised = false;
                }
            }
        }

        private void ZoomInOut(object sender, MouseEventArgs e)
        {
            SuspendLayout();
            ResumeLayout(false);
            game.ResizeBlocks((e.Delta > 0 ? 1 : -1) * 4);
        }

        private void SelectNoMode()
        {
            tstrpOptModeEasy.Checked = false;
            tstrpOptModeIntermediate.Checked = false;
            tstrpOptModeHard.Checked = false;
            tstrpOptModeCustom.Checked = false;
        }

        private void OptModeIntermediate_Click(object sender, EventArgs e)
        {
            SelectNoMode();
            tstrpOptModeIntermediate.Checked = true;
            mode = Modes.Intermediate;
        }

        private void OptModeHard_Click(object sender, EventArgs e)
        {
            SelectNoMode();
            tstrpOptModeHard.Checked = true;
            mode = Modes.Expert;
        }

        private void OptModeEasy_Click(object sender, EventArgs e)
        {
            SelectNoMode();
            tstrpOptModeEasy.Checked = true;
            mode = Modes.Easy;
        }

        private void OptSettings_Click(object sender, EventArgs e)
        {

        }

        private void OptModeCustom_Click(object sender, EventArgs e)
        {
            Difficulty difficulty = new Difficulty(mode);
            difficulty.ShowDialog();
            mode = difficulty.CustomMode;
            SelectNoMode();
            tstrpOptModeCustom.Checked = true;
        }
    }
}

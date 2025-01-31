using Minesweeper.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Minesweeper
{
    class Game
    {
        private readonly Map map;
        private readonly SoundPlayer[] SoundEffects = new SoundPlayer[2];
        private readonly Board board;
        private readonly Panel pnlContainer;
        public List<List<PictureBox>> Blocks = new List<List<PictureBox>>();

        public Game(
                Mode mode,
                Panel Container,
                MouseEventHandler MouseClick,
                MouseEventHandler MouseUp,
                MouseEventHandler MouseDown
            )
        {
            map = new Map(mode.Rows, mode.Cols, mode.Mines);
            board = new Board(mode.Rows, mode.Cols
                , Container
                , MouseClick
                , MouseDown
                , MouseUp
                , ref Blocks);
            pnlContainer = Container;
            SoundEffects[0] = new SoundPlayer(Resources.BombEffect);
            SoundEffects[1] = new SoundPlayer(Resources.Win);
        }

        public int Flags { get; private set; }
        public int Rows => board.Rows;
        public int Cols => board.Cols;
        public int Mines => map.Mines;

        public void FlagBlock(PictureBox clicked)
        {
            if (!board.GetInfo(clicked).IsOpened)
            {
                clicked.Image = !board.GetInfo(clicked).IsFlagged ? Resources.Flag : Resources.Unopened;
                board.GetInfo(clicked).IsFlagged = !board.GetInfo(clicked).IsFlagged;
                Flags += board.GetInfo(clicked).IsFlagged ? 1 : -1;
            }
        }

        public BlockInfo GetInfo(PictureBox block)
        {
            return board.GetInfo(block);
        }

        //returns true if the Block opened is a bomb
        public bool OpenBlock(PictureBox clicked)
        {
            bool isBomb = false;
            BlockInfo clickedInfo = board.GetInfo(clicked);
            if (!clickedInfo.IsFlagged)
            {
                char blockContent = map[clickedInfo.Location.X, clickedInfo.Location.Y];
                if (blockContent != 'B')
                {
                    if (blockContent != '0')
                    {
                        clicked.Image = board.GetImage(int.Parse(blockContent.ToString()));
                        clickedInfo.IsOpened = true;
                    }
                    else
                        RevealConnectedBlocks(clickedInfo.Location.X, clickedInfo.Location.Y);
                }
                else
                    isBomb = true;
            }
            return isBomb;
        }

        // boolean function returns true when the player loses
        private bool RSBContinue(int R, int C)
        {
            bool isBomb = false;
            if (!board.GetInfo(Blocks[R][C]).IsFlagged)
            {
                switch (map[R, C])
                {
                    case '0':
                        RevealConnectedBlocks(R, C);
                        break;
                    case 'B':
                        isBomb = true;
                        break;
                    default:
                        Blocks[R][C].Image = board.GetImage(int.Parse(map[R, C] + ""));
                        board.GetInfo(Blocks[R][C]).IsOpened = true;
                        break;
                }
            }
            return isBomb;
        }

        private int CalcSrndFlags(int R, int C)
        {
            int Flagged = 0;
            for (int i = R - 1; i <= R + 1; i++)
                if (i >= 0 && i < board.Rows)
                    for (int j = C - 1; j <= C + 1; j++)
                        if (j >= 0 && j < board.Cols && !(i == R && j == C) && board.GetInfo(Blocks[i][j]).IsFlagged)
                            Flagged++;
            return Flagged;
        }

        public void RevealAllBombs()
        {
            ChangeBombsImage(Resources.Bomb);
        }

        public void FlagAllBombs()
        {
            ChangeBombsImage(Resources.Flag);
            Flags = Mines;
        }

        private void ChangeBombsImage(Image image)
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    if (map[i, j] == 'B')
                    {
                        board.GetBlock(i, j).Image = image;
                        board.GetInfo(i, j).IsBomb = true;
                    }
        }

        public void GenearateMap(PictureBox firstClicked)
        {
            BlockInfo binfo = GetInfo(firstClicked);
            int i = binfo.Location.X;
            int j = binfo.Location.Y;
            map.RegenerateMap(Rows, Cols, Mines, i, j);
        }

        public void Resize(Mode mode)
        {
            int rows = mode.Rows;
            int cols = mode.Cols;
            int mines = mode.Mines;
            int r = Rows, c = Cols, m = Mines;
            if (cols > 2 && cols <= 40)
                c = cols;
            if (rows > 2 && rows <= 40)
                r = rows;
            if (mines > 2 && mines <= 1000 && mines < Math.Ceiling(r * c * 0.6))
                m = mines;
            board.Resize(r, c);
            map.Mines = m;
            BlockInfo.BlocksOpened = 0;
            Flags = 0;
        }

        public bool RevealSurroundBlocks(int R, int C)
        {   //RSB
            bool isBomb = false;
            if (board.GetInfo(Blocks[R][C]).IsOpened)
            {
                if (int.Parse(map[R, C] + "") == CalcSrndFlags(R, C))
                {
                    for (int i = R - 1; i <= R + 1; i++)
                        if (i >= 0 && i < board.Rows)
                            for (int j = C - 1; j <= C + 1; j++)
                                if (j >= 0 && j < board.Cols && RSBContinue(i, j))
                                    isBomb = true;
                }
            }
            return isBomb;
        }

        private void RevealConnectedBlocks(int row, int col)
        {
            if (map[row, col] != '0' && char.IsLetterOrDigit(map[row, col]))
            {
                if (char.IsDigit(map[row, col]))
                {
                    Blocks[row][col].Image = board.GetImage(int.Parse(map[row, col].ToString()));
                    board.GetInfo(Blocks[row][col]).IsOpened = true;
                }
                return;
            }
            else
            {
                if (!board.GetInfo(Blocks[row][col]).IsOpened)
                {
                    Blocks[row][col].Image = Resources._0;
                    board.GetInfo(Blocks[row][col]).IsOpened = true;
                    RCBHelper(row - 1, col); //Upper Block
                    RCBHelper(row, col - 1); //Left Block
                    RCBHelper(row, col + 1); //Right Block 
                    RCBHelper(row + 1, col); //Lower Block
                    RCBHelper(row - 1, col - 1); //Upper Left Block
                    RCBHelper(row - 1, col + 1); //Upper Right Block
                    RCBHelper(row + 1, col - 1); //Lower Left Block
                    RCBHelper(row + 1, col + 1); //Lower Right Block
                }
                return;
            }
        }

        private void RCBHelper(int R, int C)
        {
            if (R < board.Rows && R >= 0 && C < board.Cols && C >= 0)
                RevealConnectedBlocks(R, C);
        }

        public void MaintainBlocksLocations()
        {
            board.ReInitLocations();
        }

        public void ResizeBlocks(int delta)
        {
            board.ResizeBlocks(delta);
        }
    }
}

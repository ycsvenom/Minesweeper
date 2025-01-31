using Minesweeper.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Minesweeper
{
    public class Board
    {
        private Image[] DigitImages;
        private int defaultSize; //DefaultSize
        private int defaultSpace; //Space
        private readonly Control.ControlCollection controls;
        private readonly List<List<BlockInfo>> blocksInfo;
        private readonly List<List<PictureBox>> blocks;
        private readonly MouseEventHandler MouseClick;
        private readonly MouseEventHandler MouseUp;
        private readonly MouseEventHandler MouseDown;
        private readonly Panel panel;

        public Board(int Rows, int Columns,
            Panel container,
            MouseEventHandler MouseClickEvent,
            MouseEventHandler MouseDownEvent,
            MouseEventHandler MouseUpEvent,
            ref List<List<PictureBox>> pBoxes,
            int DefaultSize = 40, int Space = 2)
        {
            defaultSize = DefaultSize;
            defaultSpace = Space;
            panel = container;
            blocks = pBoxes;
            MouseClick = MouseClickEvent;
            MouseUp = MouseUpEvent;
            MouseDown = MouseDownEvent;
            blocksInfo = new List<List<BlockInfo>>();
            controls = panel.Controls;
            InitMedia();
            Resize(Rows, Columns);
        }

        private Size Size { get { return panel.Size; } set { } }

        public int Rows
        {
            get { return R; }
            private set { R = value; }
        }

        public int Cols { get; private set; }

        public int Mines { get; private set; }

        public int R { get => R1; set => R1 = value; }
        public int R1 { get; set; }

        private void InitMedia()
        {
            DigitImages = new Image[10];
            DigitImages[0] = Resources._0;
            DigitImages[1] = Resources._1;
            DigitImages[2] = Resources._2;
            DigitImages[3] = Resources._3;
            DigitImages[4] = Resources._4;
            DigitImages[5] = Resources._5;
            DigitImages[6] = Resources._6;
            DigitImages[7] = Resources._7;
            DigitImages[8] = Resources._8;
        }

        private Point CalcCenter(Size size)
        {
            int x = (size.Width - (Cols * defaultSize + (defaultSpace * (Cols - 1)))) / 2;
            int y = (size.Height - (R * defaultSize + (defaultSpace * (Cols - 1)))) / 2;
            return new Point(x, y);
        }

        private void InitLocations()
        {
            ResizeContainer();
            Point center = CalcCenter(Size);
            for (int i = 0; i < R; i++)
                for (int j = 0; j < Cols; j++)
                    blocks[i][j].Location = new Point(center.X + (j * (defaultSize + defaultSpace)), center.Y + (i * (defaultSize + defaultSpace)));
        }

        private void GenerateBoard()
        {
            BlockInfo.BlocksOpened = 0;
            for (int i = blocks.Count; i < R; i++)
            {
                blocks.Add(new List<PictureBox>());
                blocksInfo.Add(new List<BlockInfo>());
            }
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < blocks[i].Count; j++)
                {
                    if (blocksInfo[i][j].IsOpened ||
                        blocksInfo[i][j].IsBomb ||
                        blocksInfo[i][j].IsFlagged)
                    {
                        blocks[i][j].Image = Resources.Unopened;
                        blocksInfo[i][j] = new BlockInfo(new Point(i, j));
                    }
                }
                for (int j = blocks[i].Count; j < Cols; j++)
                {
                    blocks[i].Add(new PictureBox
                    {
                        Name = string.Format("S_{0}_{1}", i, j),
                        Size = new Size(defaultSize, defaultSize),
                        BackColor = Color.FromArgb(62, 73, 122),
                        TabIndex = i * R + j,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        TabStop = false,
                        Image = Resources.Unopened
                    });
                    blocksInfo[i].Add(new BlockInfo(new Point(i, j)));
                    blocks[i][j].MouseClick += MouseClick;
                    blocks[i][j].MouseDown += MouseDown;
                    blocks[i][j].MouseUp += MouseUp;
                    controls.Add(blocks[i][j]);
                }
            }
            InitLocations();
        }

        public PictureBox GetBlock(int i, int j)
        {
            return blocks[i][j];
        }

        public void Resize(int rows, int cols)
        {
            if (rows * cols < Rows * Cols)
            {
                for (int i = blocks.Count - 1; i >= rows; i--)
                {
                    foreach (var item in blocks[i])
                        controls.Remove(item);
                    blocks.RemoveAt(i);
                    blocksInfo.RemoveAt(i);
                }
                for (int i = 0; i < blocks.Count; i++)
                    for (int j = blocks[i].Count - 1; j >= cols; j--)
                    {
                        controls.Remove(blocks[i][j]);
                        blocks[i].RemoveAt(j);
                        blocksInfo[i].RemoveAt(j);
                    }
            }
            Cols = cols;
            R = rows;
            GenerateBoard();
        }

        public Image GetImage(int index)
        {
            Image image = null;
            if (index >= 0 && index < DigitImages.Length)
                image = DigitImages[index];
            return image;
        }

        public void ReInitLocations()
        {
            InitLocations();
        }

        public BlockInfo GetInfo(int i, int j)
        {
            return blocksInfo[i][j];
        }

        public BlockInfo GetInfo(PictureBox block)
        {
            string[] coords = block.Name.Split('_');
            int i = int.Parse(coords[1]);
            int j = int.Parse(coords[2]);
            return GetInfo(i, j);
        }

        private void ResizeContainer()
        {
            int offset = 10;
            int width = defaultSize * Rows + ((Rows - 1) * defaultSpace) + offset * 2;
            int height = defaultSize * Cols + ((Cols - 1) * defaultSpace) + offset * 2;
            panel.Size = new Size(width, height);
        }

        public void ResizeBlocks(int delta)
        {
            int newSize = defaultSize + delta;
            if (newSize >= 20 && newSize <= 60)
            {
                defaultSize = newSize;
                ResizeContainer();
                Size nSize = new Size(defaultSize, defaultSize);
                Point center = CalcCenter(Size);
                for (int i = 0; i < R; i++)
                    for (int j = 0; j < Cols; j++)
                    {
                        panel.SuspendLayout();
                        panel.ResumeLayout(false);
                        blocks[i][j].Location = new Point(center.X + (j * (defaultSize + defaultSpace)), center.Y + (i * (defaultSize + defaultSpace)));
                        blocks[i][j].Size = nSize;
                    }
            }
        }
    }
}
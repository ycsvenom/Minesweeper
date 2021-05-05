using System;
using Minesweeper.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Minesweeper {
	public partial class Main : Form {
		public Main() {
			InitializeComponent();
		}

		public enum Bool {
			True,
			Qubit,
			False
		}

		public int M = 7;
		public int N = 7;
		public int Flags = 0;
		public int DS = 40; //DefaultSize
		public char[,] map;
		public int Sp = 2; //Space
		public int MinMines = 8;
		public Image[] Numbers = new Image[10];
		public List<List<PictureBox>> S = new List<List<PictureBox>>();
		public Bool WinState;
		SoundPlayer[] SoundEffects = new SoundPlayer[2];

		private Point CalcCenter() {
			int x = (Size.Width - (N * DS + (Sp * (N - 1)))) / 2;
			int y = (Size.Height - (M * DS + (Sp * (N - 1)))) / 2;
			return new Point(x, y);
		}

		private void Shuffle() {
			Random RN = new Random();
			int r, c;
			for (int i = 0; i < MinMines;) {
				r = RN.Next(0, M);
				c = RN.Next(0, N);
				if (map[r, c] != 'B') {
					map[r, c] = 'B';
					i++;
				}
			}
		}

		//Srnd=Surroundings
		private int CalcSrndBombs(int R, int C) {
			int Bombs = 0;
			for (int i = R - 1; i <= R + 1; i++)
				if (i >= 0 && i < M)
					for (int j = C - 1; j <= C + 1; j++)
						if (j >= 0 && j < N)
							if (map[i, j] == 'B')
								Bombs++;
			return Bombs;
		}

		private int CalcSrndFlags(int R, int C) {
			int Flagged = 0;
			for (int i = R - 1; i <= R + 1; i++)
				if (i >= 0 && i < M)
					for (int j = C - 1; j <= C + 1; j++)
						if (j >= 0 && j < N)
							if (!(i == R && j == C))
								if (GetInfo(S[i][j]).Flagged)
									Flagged++;
			return Flagged;
		}


		// boolean function returns true when the player loses
		private bool RSBContinue(int R, int C) {
			if (!GetInfo(S[R][C]).Flagged) {
				switch (map[R, C]) {
					case '0':
						RevealConnectedBlocks(R, C);
						break;
					case 'B':
						HasLost(S[R][C]);
						return true;
					default:
						S[R][C].Image = Numbers[int.Parse(map[R, C] + "")];
						GetInfo(S[R][C]).Opened = true;
						break;
				}
			}
			return false;
		}

		private void RevealSrndBlocks(int R, int C) {   //RSB
			if (GetInfo(S[R][C]).Opened) {
				if (int.Parse(map[R, C] + "") == CalcSrndFlags(R, C)) {
					for (int i = R - 1; i <= R + 1; i++)
						if (i >= 0 && i < M)
							for (int j = C - 1; j <= C + 1; j++)
								if (j >= 0 && j < N)
									if (RSBContinue(i, j))
										return;
				}
			}
		}

		private void Analyzing() {
			for (int i = 0; i < map.GetLength(0); i++) {
				for (int j = 0; j < map.GetLength(1); j++) {
					if (map[i, j] != 'B')
						map[i, j] = (CalcSrndBombs(i, j) + "")[0];
				}
			}
		}

		private void Main_Load(object sender, EventArgs e) {
			Numbers[0] = Resources._0;
			Numbers[1] = Resources._1;
			Numbers[2] = Resources._2;
			Numbers[3] = Resources._3;
			Numbers[4] = Resources._4;
			Numbers[5] = Resources._5;
			Numbers[6] = Resources._6;
			Numbers[7] = Resources._7;
			Numbers[8] = Resources._8;
			SoundEffects[0] = new SoundPlayer(Resources.BombEffect);
			SoundEffects[1] = new SoundPlayer(Resources.Win);
			InitBoard();
			InitGame();
		}

		private void ChangePic(object sender, MouseEventArgs e) {
			if (WinState == Bool.Qubit) {
				PictureBox Now = (PictureBox)sender;
				switch (e.Button) {
					case MouseButtons.Left:
						if (!((Info)Now.Tag).Flagged) {
							char N = map[((Info)Now.Tag).Location.X, ((Info)Now.Tag).Location.Y];
							if (N != 'B') {
								if (N != '0') {
									Now.Image = Numbers[int.Parse(N.ToString())];
									((Info)Now.Tag).Opened = true;
								}
								else
									RevealConnectedBlocks(((Info)Now.Tag).Location.X, ((Info)Now.Tag).Location.Y);
							}
							else
								HasLost(Now);
						}
						break;
					case MouseButtons.Right:
						if (!((Info)Now.Tag).Opened) {
							Now.Image = !((Info)Now.Tag).Flagged ? Resources.Flag : Resources.Unopened;
							((Info)Now.Tag).Flagged = !((Info)Now.Tag).Flagged;
							Flags += ((Info)Now.Tag).Flagged ? 1 : -1;
						}
						break;
					case MouseButtons.Middle:
						RevealSrndBlocks(((Info)Now.Tag).Location.X, ((Info)Now.Tag).Location.Y);
						break;
				}
				if (M * N - MinMines == Info.NOpened)
					HasWin();
			}
			MineN.Text = (MinMines - Flags >= 0 ? MinMines - Flags : 0) + "";
		}



		private void HasLost(PictureBox Mine) {
			Mine.Image = Resources.Bomb;
			SoundEffects[0].Play();
			WinState = Bool.False;
			MessageBox.Show("You have Lost");
		}

		private void RCBHelper(int R, int C) {
			if (R < M && R >= 0 && C < N && C >= 0)
				RevealConnectedBlocks(R, C);
		}

		private void RevealConnectedBlocks(int R, int C) {
			if (map[R, C] != '0' && char.IsLetterOrDigit(map[R, C])) {
				if (char.IsDigit(map[R, C])) {
					S[R][C].Image = Numbers[int.Parse(map[R, C].ToString())];
					GetInfo(S[R][C]).Opened = true;
				}
				return;
			}
			else {
				if (!GetInfo(S[R][C]).Opened) {
					S[R][C].Image = Resources._0;
					GetInfo(S[R][C]).Opened = true;
					RCBHelper(R - 1, C); //Upper Block
					RCBHelper(R, C - 1); //Left Block
					RCBHelper(R, C + 1); //Right Block 
					RCBHelper(R + 1, C); //Lower Block
					RCBHelper(R - 1, C - 1); //Upper Left Block
					RCBHelper(R - 1, C + 1); //Upper Right Block
					RCBHelper(R + 1, C - 1); //Lower Left Block
					RCBHelper(R + 1, C + 1); //Lower Right Block
				}
				return;
			}
		}

		private void InitGame() {
			Flags = 0;
			MineN.Text = (MinMines - Flags >= 0 ? MinMines - Flags : 0) + "";
			WinState = Bool.Qubit;
			Info.NOpened = 0;
			map = new char[M, N];
			for (int i = 0; i < S.Count; i++)
				for (int j = 0; j < S[i].Count; j++) {
					S[i][j].Image = Resources.Unopened;
					map[i, j] = '0';
					GetInfo(S[i][j]).Opened = false;
					GetInfo(S[i][j]).Flagged = false;
				}
			Shuffle();
			Analyzing();
		}

		private void RemoveRow(int R) {
			foreach (var item in S[R])
				Controls.Remove(item);
		}

		private void RemoveExceeds() {
			for (int i = S.Count - 1; i >= NR.Value; i--) {
				RemoveRow(i);
				S.RemoveAt(i);
			}
			for (int i = 0; i < S.Count; i++)
				for (int j = S[i].Count - 1; j >= NC.Value; j--) {
					Controls.Remove(S[i][j]);
					S[i].RemoveAt(j);
				}
		}

		private void Restart_Click(object sender, EventArgs e) {
			if (NR.Value * NC.Value - 2 > NM.Value) {
				if (NR.Value * NC.Value < M * N)
					RemoveExceeds();
				M = (int)NR.Value;
				N = (int)NC.Value;
				MinMines = (int)NM.Value;
				InitBoard();
				InitGame();
			}
			else
				MessageBox.Show("Number of Mines is More than Number of blocks or Really Near of it! ");
		}

		private void InitBoard() {
			for (int i = S.Count; i < M; i++)
				S.Add(new List<PictureBox>());
			for (int i = 0; i < M; i++) {
				for (int j = S[i].Count; j < N; j++) {
					S[i].Add(new PictureBox {
						Name = "S" + i + j,
						Tag = new Info(new Point(i, j), false),
						Size = new Size(DS, DS),
						TabIndex = i * M + j,
						SizeMode = PictureBoxSizeMode.StretchImage,
						TabStop = false
					});
					S[i][j].MouseClick += new MouseEventHandler(ChangePic);
					Controls.Add(S[i][j]);
				}
			}
			InitLocations();
		}

		private Info GetInfo(object sender) {
			return (Info)((PictureBox)sender).Tag;
		}

		private void InitLocations() {
			Point AlignCenter = CalcCenter();
			for (int i = 0; i < M; i++)
				for (int j = 0; j < N; j++)
					S[i][j].Location = new Point(AlignCenter.X + (j * (DS + Sp)), AlignCenter.Y + (i * (DS + Sp)));
		}

		private void HasWin() {
			WinState = Bool.True;
			SoundEffects[1].Play();
			MessageBox.Show("You have win");
		}
	}
}

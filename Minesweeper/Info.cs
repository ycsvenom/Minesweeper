using System.Drawing;

namespace Minesweeper {
	class Info {
		public Point Location;
		private bool opened;
		public bool Flagged = false;
		public static int NOpened = 0;

		public bool Opened {
			get { return opened; }
			set {
				if (value && !opened)
					NOpened++;
				opened = value;
			}
		}

		public Info(Point Loc,bool Op){
			Location = Loc;
			Opened = Op;
		}
	}
}

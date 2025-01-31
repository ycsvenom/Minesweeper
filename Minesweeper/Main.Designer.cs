
namespace Minesweeper {
	partial class Main {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.tstrpOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tstrpOptSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tstrpOptMode = new System.Windows.Forms.ToolStripMenuItem();
            this.tstrpOptModeEasy = new System.Windows.Forms.ToolStripMenuItem();
            this.tstrpOptModeIntermediate = new System.Windows.Forms.ToolStripMenuItem();
            this.tstrpOptModeHard = new System.Windows.Forms.ToolStripMenuItem();
            this.tstrpOptModeCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLeftMines = new System.Windows.Forms.Label();
            this.pnlBoard.SuspendLayout();
            this.menu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.AutoScroll = true;
            this.pnlBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(73)))), ((int)(((byte)(122)))));
            this.pnlBoard.Controls.Add(this.pnlContainer);
            this.pnlBoard.Location = new System.Drawing.Point(12, 93);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(860, 422);
            this.pnlBoard.TabIndex = 10;
            this.pnlBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlBoard_MouseDown);
            this.pnlBoard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlBoard_MouseMove);
            this.pnlBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlBoard_MouseUp);
            this.pnlBoard.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ZoomInOut);
            // 
            // pnlContainer
            // 
            this.pnlContainer.AutoSize = true;
            this.pnlContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(73)))), ((int)(((byte)(122)))));
            this.pnlContainer.Location = new System.Drawing.Point(236, 97);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(353, 204);
            this.pnlContainer.TabIndex = 11;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstrpOptions});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(884, 24);
            this.menu.TabIndex = 11;
            this.menu.Text = "menuStrip1";
            // 
            // tstrpOptions
            // 
            this.tstrpOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstrpOptSettings,
            this.tstrpOptMode});
            this.tstrpOptions.Name = "tstrpOptions";
            this.tstrpOptions.Size = new System.Drawing.Size(61, 20);
            this.tstrpOptions.Text = "Options";
            // 
            // tstrpOptSettings
            // 
            this.tstrpOptSettings.Name = "tstrpOptSettings";
            this.tstrpOptSettings.Size = new System.Drawing.Size(122, 22);
            this.tstrpOptSettings.Text = "Settings";
            this.tstrpOptSettings.Click += new System.EventHandler(this.OptSettings_Click);
            // 
            // tstrpOptMode
            // 
            this.tstrpOptMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstrpOptModeEasy,
            this.tstrpOptModeIntermediate,
            this.tstrpOptModeHard,
            this.tstrpOptModeCustom});
            this.tstrpOptMode.Name = "tstrpOptMode";
            this.tstrpOptMode.Size = new System.Drawing.Size(122, 22);
            this.tstrpOptMode.Text = "Difficulty";
            // 
            // tstrpOptModeEasy
            // 
            this.tstrpOptModeEasy.Checked = true;
            this.tstrpOptModeEasy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tstrpOptModeEasy.Name = "tstrpOptModeEasy";
            this.tstrpOptModeEasy.Size = new System.Drawing.Size(141, 22);
            this.tstrpOptModeEasy.Text = "Easy";
            this.tstrpOptModeEasy.Click += new System.EventHandler(this.OptModeEasy_Click);
            // 
            // tstrpOptModeIntermediate
            // 
            this.tstrpOptModeIntermediate.Name = "tstrpOptModeIntermediate";
            this.tstrpOptModeIntermediate.Size = new System.Drawing.Size(141, 22);
            this.tstrpOptModeIntermediate.Text = "Intermediate";
            this.tstrpOptModeIntermediate.Click += new System.EventHandler(this.OptModeIntermediate_Click);
            // 
            // tstrpOptModeHard
            // 
            this.tstrpOptModeHard.Name = "tstrpOptModeHard";
            this.tstrpOptModeHard.Size = new System.Drawing.Size(141, 22);
            this.tstrpOptModeHard.Text = "Hard";
            this.tstrpOptModeHard.Click += new System.EventHandler(this.OptModeHard_Click);
            // 
            // tstrpOptModeCustom
            // 
            this.tstrpOptModeCustom.Name = "tstrpOptModeCustom";
            this.tstrpOptModeCustom.Size = new System.Drawing.Size(141, 22);
            this.tstrpOptModeCustom.Text = "Custom";
            this.tstrpOptModeCustom.Click += new System.EventHandler(this.OptModeCustom_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblLeftMines);
            this.panel1.Location = new System.Drawing.Point(38, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 60);
            this.panel1.TabIndex = 12;
            // 
            // lblLeftMines
            // 
            this.lblLeftMines.AutoSize = true;
            this.lblLeftMines.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLeftMines.Font = new System.Drawing.Font("DS-Digital", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftMines.ForeColor = System.Drawing.Color.Red;
            this.lblLeftMines.Location = new System.Drawing.Point(3, 0);
            this.lblLeftMines.Name = "lblLeftMines";
            this.lblLeftMines.Size = new System.Drawing.Size(92, 47);
            this.lblLeftMines.TabIndex = 2;
            this.lblLeftMines.Text = "000";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 536);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.menu);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResizeBegin += new System.EventHandler(this.Main_ResizeBegin);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.pnlBoard.ResumeLayout(false);
            this.pnlBoard.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem tstrpOptions;
        private System.Windows.Forms.ToolStripMenuItem tstrpOptSettings;
        private System.Windows.Forms.ToolStripMenuItem tstrpOptMode;
        private System.Windows.Forms.ToolStripMenuItem tstrpOptModeEasy;
        private System.Windows.Forms.ToolStripMenuItem tstrpOptModeIntermediate;
        private System.Windows.Forms.ToolStripMenuItem tstrpOptModeHard;
        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem tstrpOptModeCustom;
        private System.Windows.Forms.Label lblLeftMines;
    }
}


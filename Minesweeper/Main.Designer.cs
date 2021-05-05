
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
			this.Restart = new System.Windows.Forms.Button();
			this.MineN = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.NC = new System.Windows.Forms.NumericUpDown();
			this.NR = new System.Windows.Forms.NumericUpDown();
			this.NM = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.NC)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NR)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NM)).BeginInit();
			this.SuspendLayout();
			// 
			// Restart
			// 
			this.Restart.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Restart.Location = new System.Drawing.Point(697, 472);
			this.Restart.Name = "Restart";
			this.Restart.Size = new System.Drawing.Size(134, 46);
			this.Restart.TabIndex = 0;
			this.Restart.Text = "Restart";
			this.Restart.UseVisualStyleBackColor = true;
			this.Restart.Click += new System.EventHandler(this.Restart_Click);
			// 
			// MineN
			// 
			this.MineN.AutoSize = true;
			this.MineN.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MineN.Location = new System.Drawing.Point(233, 9);
			this.MineN.Name = "MineN";
			this.MineN.Size = new System.Drawing.Size(35, 37);
			this.MineN.TabIndex = 2;
			this.MineN.Text = "0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(215, 37);
			this.label1.TabIndex = 3;
			this.label1.Text = "Mines Left:";
			// 
			// NC
			// 
			this.NC.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.NC.Location = new System.Drawing.Point(138, 330);
			this.NC.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NC.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.NC.Name = "NC";
			this.NC.Size = new System.Drawing.Size(52, 32);
			this.NC.TabIndex = 4;
			this.NC.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
			// 
			// NR
			// 
			this.NR.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.NR.Location = new System.Drawing.Point(138, 292);
			this.NR.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NR.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.NR.Name = "NR";
			this.NR.Size = new System.Drawing.Size(52, 32);
			this.NR.TabIndex = 5;
			this.NR.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
			// 
			// NM
			// 
			this.NM.Font = new System.Drawing.Font("Consolas", 15.75F);
			this.NM.Location = new System.Drawing.Point(138, 366);
			this.NM.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.NM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NM.Name = "NM";
			this.NM.Size = new System.Drawing.Size(52, 32);
			this.NM.TabIndex = 6;
			this.NM.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(10, 287);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 37);
			this.label2.TabIndex = 7;
			this.label2.Text = "Rows:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 324);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(107, 37);
			this.label3.TabIndex = 8;
			this.label3.Text = "Cols:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(12, 361);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(125, 37);
			this.label4.TabIndex = 9;
			this.label4.Text = "Mines:";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(843, 530);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.NM);
			this.Controls.Add(this.NR);
			this.Controls.Add(this.NC);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.MineN);
			this.Controls.Add(this.Restart);
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Minesweeper";
			this.Load += new System.EventHandler(this.Main_Load);
			((System.ComponentModel.ISupportInitialize)(this.NC)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NR)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NM)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Restart;
		private System.Windows.Forms.Label MineN;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown NC;
		private System.Windows.Forms.NumericUpDown NR;
		private System.Windows.Forms.NumericUpDown NM;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}


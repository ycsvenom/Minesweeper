
namespace Minesweeper
{
    partial class Difficulty
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpCustomMode = new System.Windows.Forms.GroupBox();
            this.btnSetMode = new System.Windows.Forms.Button();
            this.nudMines = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudCols = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudRows = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.grpCustomMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCustomMode
            // 
            this.grpCustomMode.Controls.Add(this.btnSetMode);
            this.grpCustomMode.Controls.Add(this.nudMines);
            this.grpCustomMode.Controls.Add(this.label3);
            this.grpCustomMode.Controls.Add(this.nudCols);
            this.grpCustomMode.Controls.Add(this.label2);
            this.grpCustomMode.Controls.Add(this.nudRows);
            this.grpCustomMode.Controls.Add(this.label1);
            this.grpCustomMode.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCustomMode.Location = new System.Drawing.Point(12, 12);
            this.grpCustomMode.Name = "grpCustomMode";
            this.grpCustomMode.Size = new System.Drawing.Size(217, 189);
            this.grpCustomMode.TabIndex = 0;
            this.grpCustomMode.TabStop = false;
            this.grpCustomMode.Text = "Custom Difficulty";
            // 
            // btnSetMode
            // 
            this.btnSetMode.Location = new System.Drawing.Point(6, 144);
            this.btnSetMode.Name = "btnSetMode";
            this.btnSetMode.Size = new System.Drawing.Size(200, 34);
            this.btnSetMode.TabIndex = 6;
            this.btnSetMode.Text = "Set";
            this.btnSetMode.UseVisualStyleBackColor = true;
            this.btnSetMode.Click += new System.EventHandler(this.BtnSetMode_Click);
            // 
            // nudMines
            // 
            this.nudMines.Location = new System.Drawing.Point(109, 102);
            this.nudMines.Maximum = new decimal(new int[] {
            950,
            0,
            0,
            0});
            this.nudMines.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudMines.Name = "nudMines";
            this.nudMines.Size = new System.Drawing.Size(97, 32);
            this.nudMines.TabIndex = 5;
            this.nudMines.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMines.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mines:";
            // 
            // nudCols
            // 
            this.nudCols.Location = new System.Drawing.Point(109, 64);
            this.nudCols.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudCols.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudCols.Name = "nudCols";
            this.nudCols.Size = new System.Drawing.Size(97, 32);
            this.nudCols.TabIndex = 3;
            this.nudCols.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCols.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Columns:";
            // 
            // nudRows
            // 
            this.nudRows.Location = new System.Drawing.Point(109, 26);
            this.nudRows.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudRows.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRows.Name = "nudRows";
            this.nudRows.Size = new System.Drawing.Size(97, 32);
            this.nudRows.TabIndex = 1;
            this.nudRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRows.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rows:";
            // 
            // Difficulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 212);
            this.Controls.Add(this.grpCustomMode);
            this.Name = "Difficulty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose Difficulty";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.grpCustomMode.ResumeLayout(false);
            this.grpCustomMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCustomMode;
        private System.Windows.Forms.NumericUpDown nudMines;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudCols;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudRows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetMode;
    }
}
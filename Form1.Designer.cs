
namespace MazeCalculator
{
    partial class frmMainMazeCalculator
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
            this.txtbWorkingDirectory = new System.Windows.Forms.TextBox();
            this.lblWorkingDirectory = new System.Windows.Forms.Label();
            this.txtbTextFileName = new System.Windows.Forms.TextBox();
            this.txtbPngFileName = new System.Windows.Forms.TextBox();
            this.lblTextFileName = new System.Windows.Forms.Label();
            this.lblPngFileName = new System.Windows.Forms.Label();
            this.lblMazeWidth = new System.Windows.Forms.Label();
            this.txtbMazeWidth = new System.Windows.Forms.TextBox();
            this.lblMazeHeight = new System.Windows.Forms.Label();
            this.txtbMazeHeight = new System.Windows.Forms.TextBox();
            this.btnApplySizeChanges = new System.Windows.Forms.Button();
            this.lblPointFrom = new System.Windows.Forms.Label();
            this.lblPointTo = new System.Windows.Forms.Label();
            this.txbPointFrom = new System.Windows.Forms.TextBox();
            this.txbPointTo = new System.Windows.Forms.TextBox();
            this.rbPathAB = new System.Windows.Forms.RadioButton();
            this.rbPathAC = new System.Windows.Forms.RadioButton();
            this.rbPathXY = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsPngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectAllCellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectAllCellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mazeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatePerfectMazeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculatePathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specialSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatePerfectMazePreserveWallsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbWorkingDirectory
            // 
            this.txtbWorkingDirectory.Location = new System.Drawing.Point(168, 76);
            this.txtbWorkingDirectory.Name = "txtbWorkingDirectory";
            this.txtbWorkingDirectory.Size = new System.Drawing.Size(392, 22);
            this.txtbWorkingDirectory.TabIndex = 1;
            this.txtbWorkingDirectory.Text = "Q:\\Persoonlijk\\Wiskunde en programmeren\\C#\\Mazes";
            // 
            // lblWorkingDirectory
            // 
            this.lblWorkingDirectory.AutoSize = true;
            this.lblWorkingDirectory.Location = new System.Drawing.Point(33, 81);
            this.lblWorkingDirectory.Name = "lblWorkingDirectory";
            this.lblWorkingDirectory.Size = new System.Drawing.Size(119, 17);
            this.lblWorkingDirectory.TabIndex = 2;
            this.lblWorkingDirectory.Text = "Working directory";
            // 
            // txtbTextFileName
            // 
            this.txtbTextFileName.Location = new System.Drawing.Point(168, 129);
            this.txtbTextFileName.Name = "txtbTextFileName";
            this.txtbTextFileName.Size = new System.Drawing.Size(392, 22);
            this.txtbTextFileName.TabIndex = 3;
            this.txtbTextFileName.Text = "MyFirstMaze.txt";
            // 
            // txtbPngFileName
            // 
            this.txtbPngFileName.Location = new System.Drawing.Point(168, 179);
            this.txtbPngFileName.Name = "txtbPngFileName";
            this.txtbPngFileName.Size = new System.Drawing.Size(392, 22);
            this.txtbPngFileName.TabIndex = 4;
            this.txtbPngFileName.Text = "MyFirstMaze.png";
            // 
            // lblTextFileName
            // 
            this.lblTextFileName.AutoSize = true;
            this.lblTextFileName.Location = new System.Drawing.Point(33, 134);
            this.lblTextFileName.Name = "lblTextFileName";
            this.lblTextFileName.Size = new System.Drawing.Size(92, 17);
            this.lblTextFileName.TabIndex = 5;
            this.lblTextFileName.Text = "Text filename";
            // 
            // lblPngFileName
            // 
            this.lblPngFileName.AutoSize = true;
            this.lblPngFileName.Location = new System.Drawing.Point(33, 184);
            this.lblPngFileName.Name = "lblPngFileName";
            this.lblPngFileName.Size = new System.Drawing.Size(93, 17);
            this.lblPngFileName.TabIndex = 6;
            this.lblPngFileName.Text = "png Filename";
            // 
            // lblMazeWidth
            // 
            this.lblMazeWidth.AutoSize = true;
            this.lblMazeWidth.Location = new System.Drawing.Point(33, 244);
            this.lblMazeWidth.Name = "lblMazeWidth";
            this.lblMazeWidth.Size = new System.Drawing.Size(78, 17);
            this.lblMazeWidth.TabIndex = 7;
            this.lblMazeWidth.Text = "Maze width";
            // 
            // txtbMazeWidth
            // 
            this.txtbMazeWidth.Location = new System.Drawing.Point(168, 239);
            this.txtbMazeWidth.Name = "txtbMazeWidth";
            this.txtbMazeWidth.Size = new System.Drawing.Size(100, 22);
            this.txtbMazeWidth.TabIndex = 8;
            this.txtbMazeWidth.Text = "30";
            // 
            // lblMazeHeight
            // 
            this.lblMazeHeight.AutoSize = true;
            this.lblMazeHeight.Location = new System.Drawing.Point(317, 244);
            this.lblMazeHeight.Name = "lblMazeHeight";
            this.lblMazeHeight.Size = new System.Drawing.Size(85, 17);
            this.lblMazeHeight.TabIndex = 9;
            this.lblMazeHeight.Text = "Maze height";
            // 
            // txtbMazeHeight
            // 
            this.txtbMazeHeight.Location = new System.Drawing.Point(441, 239);
            this.txtbMazeHeight.Name = "txtbMazeHeight";
            this.txtbMazeHeight.Size = new System.Drawing.Size(100, 22);
            this.txtbMazeHeight.TabIndex = 10;
            this.txtbMazeHeight.Text = "30";
            // 
            // btnApplySizeChanges
            // 
            this.btnApplySizeChanges.Location = new System.Drawing.Point(574, 228);
            this.btnApplySizeChanges.Name = "btnApplySizeChanges";
            this.btnApplySizeChanges.Size = new System.Drawing.Size(182, 45);
            this.btnApplySizeChanges.TabIndex = 11;
            this.btnApplySizeChanges.Text = "<-- Apply size changes";
            this.btnApplySizeChanges.UseVisualStyleBackColor = true;
            this.btnApplySizeChanges.Click += new System.EventHandler(this.btnApplySizeChanges_Click);
            // 
            // lblPointFrom
            // 
            this.lblPointFrom.AutoSize = true;
            this.lblPointFrom.Location = new System.Drawing.Point(621, 340);
            this.lblPointFrom.Name = "lblPointFrom";
            this.lblPointFrom.Size = new System.Drawing.Size(124, 17);
            this.lblPointFrom.TabIndex = 18;
            this.lblPointFrom.Text = "Point from e.g. 3,1";
            // 
            // lblPointTo
            // 
            this.lblPointTo.AutoSize = true;
            this.lblPointTo.Location = new System.Drawing.Point(621, 381);
            this.lblPointTo.Name = "lblPointTo";
            this.lblPointTo.Size = new System.Drawing.Size(108, 17);
            this.lblPointTo.TabIndex = 19;
            this.lblPointTo.Text = "Point to e.g. 5,8";
            // 
            // txbPointFrom
            // 
            this.txbPointFrom.Location = new System.Drawing.Point(765, 340);
            this.txbPointFrom.Name = "txbPointFrom";
            this.txbPointFrom.Size = new System.Drawing.Size(133, 22);
            this.txbPointFrom.TabIndex = 20;
            this.txbPointFrom.Text = "3,1";
            // 
            // txbPointTo
            // 
            this.txbPointTo.Location = new System.Drawing.Point(765, 382);
            this.txbPointTo.Name = "txbPointTo";
            this.txbPointTo.Size = new System.Drawing.Size(133, 22);
            this.txbPointTo.TabIndex = 21;
            this.txbPointTo.Text = "5,8";
            // 
            // rbPathAB
            // 
            this.rbPathAB.AutoSize = true;
            this.rbPathAB.Location = new System.Drawing.Point(368, 379);
            this.rbPathAB.Name = "rbPathAB";
            this.rbPathAB.Size = new System.Drawing.Size(138, 21);
            this.rbPathAB.TabIndex = 23;
            this.rbPathAB.Text = "Show path in png";
            this.rbPathAB.UseVisualStyleBackColor = true;
            // 
            // rbPathAC
            // 
            this.rbPathAC.AutoSize = true;
            this.rbPathAC.Location = new System.Drawing.Point(368, 406);
            this.rbPathAC.Name = "rbPathAC";
            this.rbPathAC.Size = new System.Drawing.Size(191, 21);
            this.rbPathAC.TabIndex = 24;
            this.rbPathAC.Text = "Show path to most distant";
            this.rbPathAC.UseVisualStyleBackColor = true;
            // 
            // rbPathXY
            // 
            this.rbPathXY.AutoSize = true;
            this.rbPathXY.Checked = true;
            this.rbPathXY.Location = new System.Drawing.Point(368, 433);
            this.rbPathXY.Name = "rbPathXY";
            this.rbPathXY.Size = new System.Drawing.Size(191, 21);
            this.rbPathXY.TabIndex = 25;
            this.rbPathXY.TabStop = true;
            this.rbPathXY.Text = "Show overall longest path";
            this.rbPathXY.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.mazeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1001, 28);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFromTextToolStripMenuItem,
            this.saveAsTextToolStripMenuItem,
            this.saveAsPngToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadFromTextToolStripMenuItem
            // 
            this.loadFromTextToolStripMenuItem.Name = "loadFromTextToolStripMenuItem";
            this.loadFromTextToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.loadFromTextToolStripMenuItem.Text = "Load from text";
            this.loadFromTextToolStripMenuItem.Click += new System.EventHandler(this.loadFromTextToolStripMenuItem_Click);
            // 
            // saveAsTextToolStripMenuItem
            // 
            this.saveAsTextToolStripMenuItem.Name = "saveAsTextToolStripMenuItem";
            this.saveAsTextToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.saveAsTextToolStripMenuItem.Text = "Save as text";
            this.saveAsTextToolStripMenuItem.Click += new System.EventHandler(this.saveAsTextToolStripMenuItem_Click);
            // 
            // saveAsPngToolStripMenuItem
            // 
            this.saveAsPngToolStripMenuItem.Name = "saveAsPngToolStripMenuItem";
            this.saveAsPngToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.saveAsPngToolStripMenuItem.Text = "Save as png";
            this.saveAsPngToolStripMenuItem.Click += new System.EventHandler(this.saveAsPngToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disconnectAllCellsToolStripMenuItem,
            this.connectAllCellsToolStripMenuItem,
            this.clearColorsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // disconnectAllCellsToolStripMenuItem
            // 
            this.disconnectAllCellsToolStripMenuItem.Name = "disconnectAllCellsToolStripMenuItem";
            this.disconnectAllCellsToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.disconnectAllCellsToolStripMenuItem.Text = "Disconnect all cells";
            this.disconnectAllCellsToolStripMenuItem.Click += new System.EventHandler(this.disconnectAllCellsToolStripMenuItem_Click);
            // 
            // connectAllCellsToolStripMenuItem
            // 
            this.connectAllCellsToolStripMenuItem.Name = "connectAllCellsToolStripMenuItem";
            this.connectAllCellsToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.connectAllCellsToolStripMenuItem.Text = "Connect all cells";
            this.connectAllCellsToolStripMenuItem.Click += new System.EventHandler(this.connectAllCellsToolStripMenuItem_Click);
            // 
            // clearColorsToolStripMenuItem
            // 
            this.clearColorsToolStripMenuItem.Name = "clearColorsToolStripMenuItem";
            this.clearColorsToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.clearColorsToolStripMenuItem.Text = "Clear colors";
            this.clearColorsToolStripMenuItem.Click += new System.EventHandler(this.clearColorsToolStripMenuItem_Click);
            // 
            // mazeToolStripMenuItem
            // 
            this.mazeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generatePerfectMazeToolStripMenuItem,
            this.calculatePathsToolStripMenuItem,
            this.specialSearchToolStripMenuItem,
            this.expandToolStripMenuItem,
            this.generatePerfectMazePreserveWallsToolStripMenuItem});
            this.mazeToolStripMenuItem.Name = "mazeToolStripMenuItem";
            this.mazeToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.mazeToolStripMenuItem.Text = "Maze";
            // 
            // generatePerfectMazeToolStripMenuItem
            // 
            this.generatePerfectMazeToolStripMenuItem.Name = "generatePerfectMazeToolStripMenuItem";
            this.generatePerfectMazeToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.generatePerfectMazeToolStripMenuItem.Text = "Generate perfect maze";
            this.generatePerfectMazeToolStripMenuItem.Click += new System.EventHandler(this.generatePerfectMazeToolStripMenuItem_Click);
            // 
            // calculatePathsToolStripMenuItem
            // 
            this.calculatePathsToolStripMenuItem.Name = "calculatePathsToolStripMenuItem";
            this.calculatePathsToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.calculatePathsToolStripMenuItem.Text = "Calculate paths";
            this.calculatePathsToolStripMenuItem.Click += new System.EventHandler(this.calculatePathsToolStripMenuItem_Click);
            // 
            // specialSearchToolStripMenuItem
            // 
            this.specialSearchToolStripMenuItem.Name = "specialSearchToolStripMenuItem";
            this.specialSearchToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.specialSearchToolStripMenuItem.Text = "Special search";
            this.specialSearchToolStripMenuItem.Click += new System.EventHandler(this.specialSearchToolStripMenuItem_Click);
            // 
            // expandToolStripMenuItem
            // 
            this.expandToolStripMenuItem.Name = "expandToolStripMenuItem";
            this.expandToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.expandToolStripMenuItem.Text = "Expand";
            this.expandToolStripMenuItem.Click += new System.EventHandler(this.expandToolStripMenuItem_Click);
            // 
            // generatePerfectMazePreserveWallsToolStripMenuItem
            // 
            this.generatePerfectMazePreserveWallsToolStripMenuItem.Name = "generatePerfectMazePreserveWallsToolStripMenuItem";
            this.generatePerfectMazePreserveWallsToolStripMenuItem.Size = new System.Drawing.Size(340, 26);
            this.generatePerfectMazePreserveWallsToolStripMenuItem.Text = "Generate perfect maze preserve walls";
            this.generatePerfectMazePreserveWallsToolStripMenuItem.Click += new System.EventHandler(this.generatePerfectMazePreserveWallsToolStripMenuItem_Click);
            // 
            // frmMainMazeCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 495);
            this.Controls.Add(this.rbPathXY);
            this.Controls.Add(this.rbPathAC);
            this.Controls.Add(this.rbPathAB);
            this.Controls.Add(this.txbPointTo);
            this.Controls.Add(this.txbPointFrom);
            this.Controls.Add(this.lblPointTo);
            this.Controls.Add(this.lblPointFrom);
            this.Controls.Add(this.btnApplySizeChanges);
            this.Controls.Add(this.txtbMazeHeight);
            this.Controls.Add(this.lblMazeHeight);
            this.Controls.Add(this.txtbMazeWidth);
            this.Controls.Add(this.lblMazeWidth);
            this.Controls.Add(this.lblPngFileName);
            this.Controls.Add(this.lblTextFileName);
            this.Controls.Add(this.txtbPngFileName);
            this.Controls.Add(this.txtbTextFileName);
            this.Controls.Add(this.lblWorkingDirectory);
            this.Controls.Add(this.txtbWorkingDirectory);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainMazeCalculator";
            this.Text = "Maze Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtbWorkingDirectory;
        private System.Windows.Forms.Label lblWorkingDirectory;
        private System.Windows.Forms.TextBox txtbTextFileName;
        private System.Windows.Forms.TextBox txtbPngFileName;
        private System.Windows.Forms.Label lblTextFileName;
        private System.Windows.Forms.Label lblPngFileName;
        private System.Windows.Forms.Label lblMazeWidth;
        private System.Windows.Forms.TextBox txtbMazeWidth;
        private System.Windows.Forms.Label lblMazeHeight;
        private System.Windows.Forms.TextBox txtbMazeHeight;
        private System.Windows.Forms.Button btnApplySizeChanges;
        private System.Windows.Forms.Label lblPointFrom;
        private System.Windows.Forms.Label lblPointTo;
        private System.Windows.Forms.TextBox txbPointFrom;
        private System.Windows.Forms.TextBox txbPointTo;
        private System.Windows.Forms.RadioButton rbPathAB;
        private System.Windows.Forms.RadioButton rbPathAC;
        private System.Windows.Forms.RadioButton rbPathXY;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsPngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectAllCellsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectAllCellsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mazeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatePerfectMazeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculatePathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specialSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatePerfectMazePreserveWallsToolStripMenuItem;
    }
}


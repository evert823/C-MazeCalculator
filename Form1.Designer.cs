
namespace MazeCalculator
{
    partial class Form1
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
            this.btnGeneratePerfectMaze = new System.Windows.Forms.Button();
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
            this.btnLoadFromText = new System.Windows.Forms.Button();
            this.btnSaveAsText = new System.Windows.Forms.Button();
            this.btnSaveAsPng = new System.Windows.Forms.Button();
            this.btnDisconnectAll = new System.Windows.Forms.Button();
            this.btnConnectAll = new System.Windows.Forms.Button();
            this.btnCalculateDistances = new System.Windows.Forms.Button();
            this.lblPointFrom = new System.Windows.Forms.Label();
            this.lblPointTo = new System.Windows.Forms.Label();
            this.txbPointFrom = new System.Windows.Forms.TextBox();
            this.txbPointTo = new System.Windows.Forms.TextBox();
            this.btnClearColors = new System.Windows.Forms.Button();
            this.rbPathAB = new System.Windows.Forms.RadioButton();
            this.rbPathAC = new System.Windows.Forms.RadioButton();
            this.rbPathXY = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnGeneratePerfectMaze
            // 
            this.btnGeneratePerfectMaze.Location = new System.Drawing.Point(36, 334);
            this.btnGeneratePerfectMaze.Name = "btnGeneratePerfectMaze";
            this.btnGeneratePerfectMaze.Size = new System.Drawing.Size(177, 23);
            this.btnGeneratePerfectMaze.TabIndex = 0;
            this.btnGeneratePerfectMaze.Text = "Generate perfect maze";
            this.btnGeneratePerfectMaze.UseVisualStyleBackColor = true;
            this.btnGeneratePerfectMaze.Click += new System.EventHandler(this.btnGeneratePerfectMaze_Click);
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
            // btnLoadFromText
            // 
            this.btnLoadFromText.Location = new System.Drawing.Point(583, 129);
            this.btnLoadFromText.Name = "btnLoadFromText";
            this.btnLoadFromText.Size = new System.Drawing.Size(120, 23);
            this.btnLoadFromText.TabIndex = 12;
            this.btnLoadFromText.Text = "Load from text";
            this.btnLoadFromText.UseVisualStyleBackColor = true;
            this.btnLoadFromText.Click += new System.EventHandler(this.btnLoadFromText_Click);
            // 
            // btnSaveAsText
            // 
            this.btnSaveAsText.Location = new System.Drawing.Point(730, 128);
            this.btnSaveAsText.Name = "btnSaveAsText";
            this.btnSaveAsText.Size = new System.Drawing.Size(129, 23);
            this.btnSaveAsText.TabIndex = 13;
            this.btnSaveAsText.Text = "Save as text";
            this.btnSaveAsText.UseVisualStyleBackColor = true;
            this.btnSaveAsText.Click += new System.EventHandler(this.btnSaveAsText_Click);
            // 
            // btnSaveAsPng
            // 
            this.btnSaveAsPng.Location = new System.Drawing.Point(730, 179);
            this.btnSaveAsPng.Name = "btnSaveAsPng";
            this.btnSaveAsPng.Size = new System.Drawing.Size(129, 23);
            this.btnSaveAsPng.TabIndex = 14;
            this.btnSaveAsPng.Text = "Save as png";
            this.btnSaveAsPng.UseVisualStyleBackColor = true;
            this.btnSaveAsPng.Click += new System.EventHandler(this.btnSaveAsPng_Click);
            // 
            // btnDisconnectAll
            // 
            this.btnDisconnectAll.Location = new System.Drawing.Point(36, 381);
            this.btnDisconnectAll.Name = "btnDisconnectAll";
            this.btnDisconnectAll.Size = new System.Drawing.Size(177, 23);
            this.btnDisconnectAll.TabIndex = 15;
            this.btnDisconnectAll.Text = "Disconnect all cells";
            this.btnDisconnectAll.UseVisualStyleBackColor = true;
            this.btnDisconnectAll.Click += new System.EventHandler(this.btnDisconnectAll_Click);
            // 
            // btnConnectAll
            // 
            this.btnConnectAll.Location = new System.Drawing.Point(36, 425);
            this.btnConnectAll.Name = "btnConnectAll";
            this.btnConnectAll.Size = new System.Drawing.Size(177, 23);
            this.btnConnectAll.TabIndex = 16;
            this.btnConnectAll.Text = "Connect all cells";
            this.btnConnectAll.UseVisualStyleBackColor = true;
            this.btnConnectAll.Click += new System.EventHandler(this.btnConnectAll_Click);
            // 
            // btnCalculateDistances
            // 
            this.btnCalculateDistances.Location = new System.Drawing.Point(255, 334);
            this.btnCalculateDistances.Name = "btnCalculateDistances";
            this.btnCalculateDistances.Size = new System.Drawing.Size(196, 23);
            this.btnCalculateDistances.TabIndex = 17;
            this.btnCalculateDistances.Text = "Calculate all distances";
            this.btnCalculateDistances.UseVisualStyleBackColor = true;
            this.btnCalculateDistances.Click += new System.EventHandler(this.btnCalculateDistances_Click);
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
            // btnClearColors
            // 
            this.btnClearColors.Location = new System.Drawing.Point(730, 75);
            this.btnClearColors.Name = "btnClearColors";
            this.btnClearColors.Size = new System.Drawing.Size(123, 23);
            this.btnClearColors.TabIndex = 22;
            this.btnClearColors.Text = "Clear colors";
            this.btnClearColors.UseVisualStyleBackColor = true;
            this.btnClearColors.Click += new System.EventHandler(this.btnClearColors_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 495);
            this.Controls.Add(this.rbPathXY);
            this.Controls.Add(this.rbPathAC);
            this.Controls.Add(this.rbPathAB);
            this.Controls.Add(this.btnClearColors);
            this.Controls.Add(this.txbPointTo);
            this.Controls.Add(this.txbPointFrom);
            this.Controls.Add(this.lblPointTo);
            this.Controls.Add(this.lblPointFrom);
            this.Controls.Add(this.btnCalculateDistances);
            this.Controls.Add(this.btnConnectAll);
            this.Controls.Add(this.btnDisconnectAll);
            this.Controls.Add(this.btnSaveAsPng);
            this.Controls.Add(this.btnSaveAsText);
            this.Controls.Add(this.btnLoadFromText);
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
            this.Controls.Add(this.btnGeneratePerfectMaze);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGeneratePerfectMaze;
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
        private System.Windows.Forms.Button btnLoadFromText;
        private System.Windows.Forms.Button btnSaveAsText;
        private System.Windows.Forms.Button btnSaveAsPng;
        private System.Windows.Forms.Button btnDisconnectAll;
        private System.Windows.Forms.Button btnConnectAll;
        private System.Windows.Forms.Button btnCalculateDistances;
        private System.Windows.Forms.Label lblPointFrom;
        private System.Windows.Forms.Label lblPointTo;
        private System.Windows.Forms.TextBox txbPointFrom;
        private System.Windows.Forms.TextBox txbPointTo;
        private System.Windows.Forms.Button btnClearColors;
        private System.Windows.Forms.RadioButton rbPathAB;
        private System.Windows.Forms.RadioButton rbPathAC;
        private System.Windows.Forms.RadioButton rbPathXY;
    }
}


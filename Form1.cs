using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeCalculator
{
    public partial class frmMainMazeCalculator : Form
    {
        public struct PointFromToEntry
        {
            public int i1;
            public int j1;
            public int i2;
            public int j2;
            public bool ValidEntry;
        }
        
        public MazeHandler MyMazeHandler;
        public MazeDrawer MyMazeDrawer;

        public frmMainMazeCalculator()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyMazeHandler = new MazeHandler(30,30);
            MyMazeDrawer = new MazeDrawer(MyMazeHandler.MainMaze);
        }

        private void btnApplySizeChanges_Click(object sender, EventArgs e)
        {
            string nsw;
            string nsh;
            int nw;
            int nh;

            nsw = txtbMazeWidth.Text;
            nsh = txtbMazeHeight.Text;

            if (int.TryParse(nsw, out nw) == false)
            {
                txtbMazeWidth.Text = "30";
                nw = 30;
            }
            if (int.TryParse(nsh, out nh) == false)
            {
                txtbMazeHeight.Text = "30";
                nh = 30;
            }

            MyMazeHandler.MainMaze.ResetMaze(nw, nh);
            MessageBox.Show("DONE");
        }

        private PointFromToEntry ValidatePointFromTo()
        {
            PointFromToEntry MyResult;

            MyResult.i1 = 0;
            MyResult.j1 = 0;
            MyResult.i2 = 0;
            MyResult.j2 = 0;
            MyResult.ValidEntry = false;

            string s1 = txbPointFrom.Text;
            string s2 = txbPointTo.Text;

            string[] a1 = s1.Split(',');
            string[] a2 = s2.Split(',');

            if (a1.Length != 2 || a2.Length != 2)
            {
                MessageBox.Show("Use format like 3,1 or 5,8 for point coordinates");
                return MyResult;
            }

            if (int.TryParse(a1[0], out MyResult.i1) == false)
            {
                MessageBox.Show("Use format like 3,1 or 5,8 for point coordinates");
                return MyResult;
            }
            if (int.TryParse(a1[1], out MyResult.j1) == false)
            {
                MessageBox.Show("Use format like 3,1 or 5,8 for point coordinates");
                return MyResult;
            }
            if (int.TryParse(a2[0], out MyResult.i2) == false)
            {
                MessageBox.Show("Use format like 3,1 or 5,8 for point coordinates");
                return MyResult;
            }
            if (int.TryParse(a2[1], out MyResult.j2) == false)
            {
                MessageBox.Show("Use format like 3,1 or 5,8 for point coordinates");
                return MyResult;
            }
            if (MyResult.i1 >= 0 & MyResult.j1 >= 0 & MyResult.i2 >= 0 & MyResult.j2 >= 0 &
                MyResult.i1 < MyMazeHandler.MainMaze.MazeWidth & MyResult.j1 < MyMazeHandler.MainMaze.MazeHeight & 
                MyResult.i2 < MyMazeHandler.MainMaze.MazeWidth & MyResult.j2 < MyMazeHandler.MainMaze.MazeHeight)
            {
                MyResult.ValidEntry = true;
                return MyResult;
            } else
            {
                MessageBox.Show("Coordinates are not in required range.");
                return MyResult;
            }
        }


        private void EnableAllControls(bool pEnable)
        {
            this.menuStrip1.Enabled = pEnable;
            this.btnApplySizeChanges.Enabled = pEnable;
            this.rbPathAB.Enabled = pEnable;
            this.rbPathAC.Enabled = pEnable;
            this.rbPathXY.Enabled = pEnable;
        }

        private void ShowNewSize()
        {
            txtbMazeWidth.Text = MyMazeHandler.MainMaze.MazeWidth.ToString();
            txtbMazeHeight.Text = MyMazeHandler.MainMaze.MazeHeight.ToString();
        }

        private void loadFromTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string inputfilepath = txtbWorkingDirectory.Text;
            if (inputfilepath.EndsWith("\\") == false)
            {
                inputfilepath += "\\";
            }
            inputfilepath += txtbTextFileName.Text;
            string[] inputLines = File.ReadAllLines(inputfilepath);
            MyMazeHandler.MainMaze.SetFromText(inputLines);
            ShowNewSize();
            MessageBox.Show("DONE");
        }

        private void saveAsTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string outputfilepath = txtbWorkingDirectory.Text;
            if (outputfilepath.EndsWith("\\") == false)
            {
                outputfilepath += "\\";
            }
            outputfilepath += txtbTextFileName.Text;
            string[] outputLines = MyMazeHandler.MainMaze.MazeAsText();
            File.WriteAllLines(outputfilepath, outputLines);
            MessageBox.Show("DONE");
        }

        private void saveAsPngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string outputpngpath = txtbWorkingDirectory.Text;
            if (outputpngpath.EndsWith("\\") == false)
            {
                outputpngpath += "\\";
            }
            outputpngpath += txtbPngFileName.Text;
            MyMazeDrawer.SaveMazeAsImage(outputpngpath);
            MessageBox.Show("DONE");
        }

        private void disconnectAllCellsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMazeHandler.MainMaze.OpenCloseWalls(false);
            MessageBox.Show("DONE");
        }

        private void connectAllCellsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMazeHandler.MainMaze.OpenCloseWalls(true);
            MessageBox.Show("DONE");
        }

        private void clearColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMazeHandler.MainMaze.ClearColors();
            MessageBox.Show("DONE");
        }

        private void generatePerfectMazeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableAllControls(false);
            this.MyMazeHandler.GeneratePerfectMaze();
            MessageBox.Show("Maze has been generated");
            EnableAllControls(true);
        }

        private void calculatePathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PointFromToEntry a = ValidatePointFromTo();
            if (a.ValidEntry == true)
            {
                EnableAllControls(false);
                MyMazeHandler.MainMaze.pAi = a.i1;
                MyMazeHandler.MainMaze.pAj = a.j1;
                MyMazeHandler.MainMaze.pBi = a.i2;
                MyMazeHandler.MainMaze.pBj = a.j2;

                if (MyMazeHandler.MainMaze.MazeWidth > 120 & rbPathXY.Checked == true)
                {
                    MessageBox.Show("The Show overall longest path option will be time taking for large mazes.");
                }

                MyMazeHandler.MainMaze.calculatePathDistance(rbPathAB.Checked, rbPathAC.Checked, rbPathXY.Checked);

                MessageBox.Show("Requested distance : " + this.MyMazeHandler.MainMaze.distance_AB.ToString());
                MessageBox.Show("Max distance from this point : " + this.MyMazeHandler.MainMaze.distance_AC.ToString()
                            + " --> " + this.MyMazeHandler.MainMaze.pCi.ToString() + "," + this.MyMazeHandler.MainMaze.pCj.ToString());

                if (rbPathXY.Checked == true)
                {
                    MessageBox.Show("Max distance overall : " + this.MyMazeHandler.MainMaze.distance_XY.ToString() + " --> "
                        + this.MyMazeHandler.MainMaze.pXi.ToString() + "," + this.MyMazeHandler.MainMaze.pXj.ToString() + ","
                        + this.MyMazeHandler.MainMaze.pYi.ToString() + "," + this.MyMazeHandler.MainMaze.pYj.ToString());
                }
                EnableAllControls(true);
            }
        }

        private void specialSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int d;
            int counter;
            d = 0;
            counter = 0;

            EnableAllControls(false);

            MyMazeHandler.MainMaze.ResetMaze(10, 10);

            ShowNewSize();

            this.MyMazeHandler.MainMaze.pAi = 0;
            this.MyMazeHandler.MainMaze.pAj = 0;
            this.MyMazeHandler.MainMaze.pBi = 9;
            this.MyMazeHandler.MainMaze.pBj = 9;

            while (counter < 200000)
            {
                counter++;
                MyMazeHandler.GeneratePerfectMaze();
                MyMazeHandler.MainMaze.calculatePathDistance(true, false, false);
                if (MyMazeHandler.MainMaze.distance_AB > d)
                {
                    d = MyMazeHandler.MainMaze.distance_AB;

                    string outputfilepath = txtbWorkingDirectory.Text;
                    if (outputfilepath.EndsWith("\\") == false)
                    {
                        outputfilepath += "\\";
                    }
                    outputfilepath += "Maze_10x10_longpath.txt";
                    string[] outputLines = MyMazeHandler.MainMaze.MazeAsText();
                    File.WriteAllLines(outputfilepath, outputLines);
                }
            }

            MessageBox.Show("Special search done");

            EnableAllControls(true);
        }

        private void expandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int expand_w;
            int expand_h;

            frmWidthHeightEntry MyEntryForm = new frmWidthHeightEntry();
            MyEntryForm.ShowDialog();

            expand_w = MyEntryForm.HorizontalValue;
            expand_h = MyEntryForm.VerticalValue;
                        
            this.MyMazeHandler.ExpandMaze(expand_w, expand_h);
            ShowNewSize();
            MessageBox.Show("DONE");
        }

        private void generatePerfectMazePreserveWallsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableAllControls(false);
            this.MyMazeHandler.GeneratePerfectMazePreservingWalls();
            MessageBox.Show("Maze has been generated");
            EnableAllControls(true);
        }
    }
}

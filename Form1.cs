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
    public partial class Form1 : Form
    {
        public struct PointFromToEntry
        {
            public int i1;
            public int j1;
            public int i2;
            public int j2;
            public bool ValidEntry;
        }
        
        public Maze MyMaze;
        public MazeDrawer MyMazeDrawer;

        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyMaze = new Maze(30, 30);
            MyMazeDrawer = new MazeDrawer(MyMaze);
        }

        private void btnGeneratePerfectMaze_Click(object sender, EventArgs e)
        {
            EnableAllControls(false);
            this.MyMaze.GeneratePerfectMaze();
            EnableAllControls(true);
        }

        private void btnLoadFromText_Click(object sender, EventArgs e)
        {
            string inputfilepath = txtbWorkingDirectory.Text;
            if (inputfilepath.EndsWith("\\") == false)
            {
                inputfilepath += "\\";
            }
            inputfilepath += txtbTextFileName.Text;
            string[] inputLines = File.ReadAllLines(inputfilepath);
            MyMaze.SetFromText(inputLines);
            MessageBox.Show("DONE");
        }

        private void btnSaveAsText_Click(object sender, EventArgs e)
        {
            string outputfilepath = txtbWorkingDirectory.Text;
            if (outputfilepath.EndsWith("\\") == false)
            {
                outputfilepath += "\\";
            }
            outputfilepath += txtbTextFileName.Text;
            string[] outputLines = MyMaze.MazeAsText();
            File.WriteAllLines(outputfilepath, outputLines);
            MessageBox.Show("DONE");
        }

        private void btnSaveAsPng_Click(object sender, EventArgs e)
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

            MyMaze.ResetMaze(nw, nh);
            MessageBox.Show("DONE");
        }

        private void btnDisconnectAll_Click(object sender, EventArgs e)
        {
            MyMaze.OpenCloseWalls(false);
            MessageBox.Show("DONE");
        }

        private void btnConnectAll_Click(object sender, EventArgs e)
        {
            MyMaze.OpenCloseWalls(true);
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
                MyResult.i1 < MyMaze.MazeWidth & MyResult.j1 < MyMaze.MazeHeight & 
                MyResult.i2 < MyMaze.MazeWidth & MyResult.j2 < MyMaze.MazeHeight)
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
            this.btnApplySizeChanges.Enabled = pEnable;
            this.btnCalculateDistances.Enabled = pEnable;
            this.btnClearColors.Enabled = pEnable;
            this.btnLoadFromText.Enabled = pEnable;
            this.btnSaveAsPng.Enabled = pEnable;
            this.btnSaveAsText.Enabled = pEnable;
            this.btnGeneratePerfectMaze.Enabled = pEnable;
            this.btnDisconnectAll.Enabled = pEnable;
            this.btnConnectAll.Enabled = pEnable;
            this.rbPathAB.Enabled = pEnable;
            this.rbPathAC.Enabled = pEnable;
            this.rbPathXY.Enabled = pEnable;
        }
        private void btnCalculateDistances_Click(object sender, EventArgs e)
        {

            PointFromToEntry a = ValidatePointFromTo();
            if (a.ValidEntry == true)
            {
                EnableAllControls(false);
                MyMaze.pAi = a.i1;
                MyMaze.pAj = a.j1;
                MyMaze.pBi = a.i2;
                MyMaze.pBj = a.j2;

                if (MyMaze.MazeWidth > 120 & rbPathXY.Checked == true)
                {
                    MessageBox.Show("The Show overall longest path option will be time taking for large mazes.");
                }

                MyMaze.calculatePathDistance(rbPathAB.Checked, rbPathAC.Checked, rbPathXY.Checked);
                EnableAllControls(true);
            }

        }

        private void btnClearColors_Click(object sender, EventArgs e)
        {
            MyMaze.ClearColors();
            MessageBox.Show("DONE");
        }
    }
}

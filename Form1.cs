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
            this.MyMaze.GeneratePerfectMaze();
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

        private void btnCalculateDistances_Click(object sender, EventArgs e)
        {
            int i1;
            int j1;
            int i2;
            int j2;


            MyMaze.calculatePathDistance();

            string s = "";

            i1 = 0; j1 = 0; i2 = MyMaze.MazeWidth - 1; j2 = MyMaze.MazeHeight - 1;
            s += i1.ToString() + "," + j1.ToString() + "," + i2.ToString() + "," + j2.ToString() + ","
                + MyMaze.MyCellPairs[i1, j1, i2, j2].PathDistance.ToString() + "\n";

            MessageBox.Show(s);
        }
    }
}

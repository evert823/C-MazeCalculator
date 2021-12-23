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

        private void button1_Click(object sender, EventArgs e)
        {
            string inputfilepath = "Q:\\Persoonlijk\\Wiskunde en programmeren\\C#\\Mazes\\MyFirstManualMaze.txt";
            string[] inputLines = File.ReadAllLines(inputfilepath);
            MyMaze.SetFromText(inputLines);

            this.MyMaze.GeneratePerfectMaze();

            string[] outputLines = MyMaze.MazeAsText();
            string outputfilepath = "Q:\\Persoonlijk\\Wiskunde en programmeren\\C#\\Mazes\\MyFirstMaze.txt";
            File.WriteAllLines(outputfilepath, outputLines);

            string outputpngpath = "Q:\\Persoonlijk\\Wiskunde en programmeren\\C#\\Mazes\\MyFirstMaze.png";
            MyMazeDrawer.SaveMazeAsImage(outputpngpath);

        }
    }
}

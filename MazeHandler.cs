using System.Windows.Forms;
using System.IO;

namespace MazeCalculator
{
    public class MazeHandler
    {

        //In this class we implement logic that requires more than one maze or consists of operations
        //between various instances of the Maze object

        public Maze MainMaze;
        public Maze MandatoryWalls;

        int mazecounter;

        public MazeHandler(int pDefaultWidth, int pDefaultHeight)
        {
            MainMaze = new Maze(pDefaultWidth, pDefaultHeight);
            MandatoryWalls = new Maze(pDefaultWidth, pDefaultHeight);
        }

        public void GeneratePerfectMaze()
        {
            MandatoryWalls.ResetMaze(MainMaze.MazeWidth, MainMaze.MazeHeight);
            MandatoryWalls.OpenCloseWalls(true);

            MainMaze.GeneratePerfectMaze(ref this.MandatoryWalls.MyWallsOfCell);
        }

        public void GeneratePerfectMazePreservingWalls()
        {
            CopyMaze(ref MainMaze, ref MandatoryWalls, 1, 1);
            MainMaze.GeneratePerfectMaze(ref this.MandatoryWalls.MyWallsOfCell);
        }

        public void ExpandMaze(int expand_w, int expand_h)
        {
            Maze MazeA = new Maze(MainMaze.MazeWidth, MainMaze.MazeHeight);
            CopyMaze(ref MainMaze, ref MazeA, 1, 1);
            CopyMaze(ref MazeA, ref MainMaze, expand_w, expand_h);
        }

        private void CopyMaze(ref Maze MazeFrom, ref Maze MazeTo, int expand_w, int expand_h)
        {
            int i;
            int j;
            int k;

            MazeTo.ResetMaze(MazeFrom.MazeWidth * expand_w, MazeFrom.MazeHeight * expand_h);
            MazeTo.OpenCloseWalls(true);

            for (i = 0; i < MazeFrom.MazeWidth; i++)
            {
                for (j = 0; j < MazeFrom.MazeHeight; j++)
                {
                    for (k = i * expand_w; k < (i + 1) * expand_w; k++)
                    {
                        MazeTo.MyWallsOfCell[k, ((j + 1) * expand_h) - 1].OpenToTop = MazeFrom.MyWallsOfCell[i, j].OpenToTop;
                    }
                    for (k = j * expand_h; k < (j + 1) * expand_h; k++)
                    {
                        MazeTo.MyWallsOfCell[((i + 1) * expand_w) - 1, k].OpenToRight = MazeFrom.MyWallsOfCell[i, j].OpenToRight;
                    }
                    for (k = i * expand_w; k < (i + 1) * expand_w; k++)
                    {
                        MazeTo.MyWallsOfCell[k, j * expand_h].OpenToBottom = MazeFrom.MyWallsOfCell[i, j].OpenToBottom;
                    }
                    for (k = j * expand_h; k < (j + 1) * expand_h; k++)
                    {
                        MazeTo.MyWallsOfCell[i * expand_w, k].OpenToLeft = MazeFrom.MyWallsOfCell[i, j].OpenToLeft;
                    }
                }
            }

        }
        
        private void ProcessWallSubSet(int[] pWallSubSet, int nw, string dumplocation)
        {
            string[] s;
            int k;
            int m;
            int i1;
            int j1;
            int i2;
            int j2;
            string dumpfilename;

            MainMaze.OpenCloseWalls(true);

            for (k = 0; k < pWallSubSet.Length; k++)
            {
                m = pWallSubSet[k];
                i1 = MainMaze.WallDoorList[m, 0];
                j1 = MainMaze.WallDoorList[m, 1];
                i2 = MainMaze.WallDoorList[m, 2];
                j2 = MainMaze.WallDoorList[m, 3];

                MainMaze.SetDirectConnection(i1, j1, i2, j2, false);
            }

            if(MainMaze.MazeIsConnected() == true)
            {
                mazecounter++;
                dumpfilename = "AllPerfectmazes.txt";

                s = MainMaze.MazeAsText();
                //File.AppendAllLines(dumplocation + dumpfilename, s);
                //File.AppendAllText(dumplocation + dumpfilename, "-------------------------\n");
            }
        }

        private void LoopOverAllWallSubSets(int[] pWallSubSet, int nw, string dumplocation)
        {
            int[] MyWallSubSet;
            int k;
            int m;
            int previousvalue;

            //MessageBox.Show("Enters LoopOver with array length " + pWallSubSet.Length.ToString());

            if (pWallSubSet.Length >= nw)
            {
                ProcessWallSubSet(pWallSubSet, nw, dumplocation);
            } else
            {
                MyWallSubSet = new int[pWallSubSet.Length + 1];
                for (k = 0; k < pWallSubSet.Length; k++)
                {
                    MyWallSubSet[k] = pWallSubSet[k];
                }
                k = pWallSubSet.Length;

                if (k > 0)
                {
                    previousvalue = pWallSubSet[k - 1];
                } else
                {
                    previousvalue = -1;
                }

                for (m = previousvalue + 1; m < MainMaze.NumberOfWallDoors; m++)
                {
                    MyWallSubSet[k] = m;
                    LoopOverAllWallSubSets(MyWallSubSet, nw, dumplocation);
                }
            }
        }

        public void GenerateAllPerfectMazes(string dumplocation)
        {
            int nw;//The number of real walls any perfect maze has
            int[] MyWallSubSet;

            this.mazecounter = 0;

            //Generates all perfect mazes that exist with width and height of current mainmaze
            MainMaze.GenerateWallDoorList();

            nw = (MainMaze.MazeWidth - 1) * (MainMaze.MazeHeight -1);

            MyWallSubSet = new int[0];
            LoopOverAllWallSubSets(MyWallSubSet, nw, dumplocation);

            MessageBox.Show("Total number of mazes found : " + mazecounter.ToString());
        }
    }
}

namespace MazeCalculator
{
    public class MazeHandler
    {

        //In this class we implement logic that requires more than one maze or consists of operations
        //between various instances of the Maze object

        public Maze MainMaze;
        public Maze MandatoryWalls;

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
    }
}

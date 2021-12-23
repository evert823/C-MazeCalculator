using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeCalculator
{
    public struct CellPair
    {
        public bool CellsAdjacent;
        public bool CellsDirectlyConnected;//Means Cells are adjacent and have no wall between them
        public int PathDistance; //Non-commutatively stored distance FROM i1, j1 TO i2, j2
    }

    public class Maze
    {
        public int MazeWidth;
        public int MazeHeight;
        public int NoPath;

        public CellPair[,,,] MyCellPairs;

        private int[,] WallDoorPermutation;//n, i1, j1, i2, j2
        private int NumberOfWallDoors;

        public Maze(int pWidth, int pHeight)
        {
            this.ResetMaze(pWidth, pHeight);
        }

        private void ResetMaze(int pWidth, int pHeight)
        {
            int i1;
            int j1;
            int i2;
            int j2;

            this.MazeWidth = pWidth;
            this.MazeHeight = pHeight;

            this.MyCellPairs = null;
            this.MyCellPairs = new CellPair[this.MazeWidth, this.MazeHeight, this.MazeWidth, this.MazeHeight];

            for (i1 = 0; i1 < this.MazeWidth; i1++)
            {
                for (j1 = 0; j1 < this.MazeHeight; j1++)
                {
                    for (i2 = 0; i2 < this.MazeWidth; i2++)
                    {
                        for (j2 = 0; j2 < this.MazeHeight; j2++)
                        {
                            this.MyCellPairs[i1, j1, i2, j2].CellsDirectlyConnected = false;
                            this.MyCellPairs[i1, j1, i2, j2].CellsAdjacent = false;
                            if ((i1 == i2 & Math.Abs(j1 - j2) == 1) |
                                (j1 == j2 & Math.Abs(i1 - i2) == 1))
                            {
                                this.MyCellPairs[i1, j1, i2, j2].CellsAdjacent = true;
                            }
                        }
                    }
                }
            }

        }


        private void InitDistance()
        {
            int i1;
            int j1;
            int i2;
            int j2;

            this.NoPath = (this.MazeWidth * this.MazeHeight) + 1;//Exclusive upper limit for a real distance

            for (i1 = 0; i1 < this.MazeWidth; i1++)
            {
                for (j1 = 0; j1 < this.MazeHeight; j1++)
                {
                    for (i2 = 0; i2 < this.MazeWidth; i2++)
                    {
                        for (j2 = 0; j2 < this.MazeHeight; j2++)
                        {
                            if (i1 == i2 & j1 == j2)
                            {
                                this.MyCellPairs[i1, j1, i2, j2].PathDistance = 0;
                            } else if (this.MyCellPairs[i1, j1, i2, j2].CellsDirectlyConnected == true)
                            {
                                this.MyCellPairs[i1, j1, i2, j2].PathDistance = 1;
                            } else
                            {
                                this.MyCellPairs[i1, j1, i2, j2].PathDistance = this.NoPath;
                            }
                        }
                    }
                }
            }
        }



        private void OpenCloseWalls(bool pOpen)
        {
            int i;
            int j;

            for (i = 0; i < this.MazeWidth; i++)
            {
                for (j = 0; j < this.MazeHeight; j++)
                {
                    if (i < this.MazeWidth - 1)
                    {
                        this.SetDirectConnection(i, j, i + 1, j, pOpen);
                    }
                    if (j < this.MazeHeight - 1)
                    {
                        this.SetDirectConnection(i, j, i, j + 1, pOpen);
                    }
                }
            }
        }
        private void GenerateWallDoorPermutation()
        {
            int i;
            int j;
            int m;
            Random MyRandom;

            //private int[,,,,] WallDoorPermutation;//n, i1, j1, i2, j2
            int n = (this.MazeHeight - 1) * this.MazeWidth;
            n += (this.MazeWidth - 1) * this.MazeHeight;
            this.NumberOfWallDoors = n;

            this.WallDoorPermutation = null;
            this.WallDoorPermutation = new int[n, 4];

            for (m = 0; m < n; m++)
            {
                WallDoorPermutation[m, 0] = -1;
                WallDoorPermutation[m, 1] = -1;
                WallDoorPermutation[m, 2] = -1;
                WallDoorPermutation[m, 3] = -1;
            }

            MyRandom = new Random();

            for (i = 0; i < this.MazeWidth; i++)
            {
                for (j = 0; j < this.MazeHeight; j++)
                {
                    if (i < this.MazeWidth - 1)
                    {
                        m = MyRandom.Next(0, n);
                        while (WallDoorPermutation[m, 0] > -1)
                        {
                            m = MyRandom.Next(0, n);
                        }
                        WallDoorPermutation[m, 0] = i;
                        WallDoorPermutation[m, 1] = j;
                        WallDoorPermutation[m, 2] = i + 1;
                        WallDoorPermutation[m, 3] = j;
                    }
                    if (j < this.MazeHeight - 1)
                    {
                        m = MyRandom.Next(0, n);
                        while (WallDoorPermutation[m, 0] > -1)
                        {
                            m = MyRandom.Next(0, n);
                        }
                        WallDoorPermutation[m, 0] = i;
                        WallDoorPermutation[m, 1] = j;
                        WallDoorPermutation[m, 2] = i;
                        WallDoorPermutation[m, 3] = j + 1;
                    }
                }
            }
        }

        private void calculatePathDistance()
        {
            int i1;
            int j1;

            this.InitDistance();

            for (i1 = 0; i1 < this.MazeWidth; i1++)
            {
                for (j1 = 0; j1 < this.MazeHeight; j1++)
                {
                    CalculatePathDistanceFrom(i1, j1);
                }
            }
        }

        private void CalculatePathDistanceFrom(int i1, int j1)
        {
            int i2;
            int j2;
            Boolean FoundNewCell;

            FoundNewCell = true;

            while (FoundNewCell == true)
            {
                FoundNewCell = false;
                for (i2 = 0; i2 < this.MazeWidth; i2++)
                {
                    for (j2 = 0; j2 < this.MazeHeight; j2++)
                    {
                        if (this.MyCellPairs[i1, j1, i2, j2].PathDistance > 0 &
                            this.MyCellPairs[i1, j1, i2, j2].PathDistance < this.NoPath)
                        {
                            if (i2 > 0)
                            {
                                if (this.MyCellPairs[i1, j1, i2 - 1, j2].PathDistance == this.NoPath &
                                    this.MyCellPairs[i2, j2, i2 - 1, j2].PathDistance == 1)
                                {
                                    this.MyCellPairs[i1, j1, i2 - 1, j2].PathDistance =
                                       this.MyCellPairs[i1, j1, i2, j2].PathDistance + 1;
                                    //this.MyCellPairs[i2 - 1, j2, i1, j1].PathDistance =
                                    //   this.MyCellPairs[i1, j1, i2 - 1, j2].PathDistance;
                                    FoundNewCell = true;
                                }
                            }
                            if (i2 < this.MazeWidth - 1)
                            {
                                if (this.MyCellPairs[i1, j1, i2 + 1, j2].PathDistance == this.NoPath &
                                    this.MyCellPairs[i2, j2, i2 + 1, j2].PathDistance == 1)
                                {
                                    this.MyCellPairs[i1, j1, i2 + 1, j2].PathDistance =
                                       this.MyCellPairs[i1, j1, i2, j2].PathDistance + 1;
                                    //this.MyCellPairs[i2 + 1, j2, i1, j1].PathDistance =
                                    //   this.MyCellPairs[i1, j1, i2 + 1, j2].PathDistance;
                                    FoundNewCell = true;
                                }
                            }
                            if (j2 > 0)
                            {
                                if (this.MyCellPairs[i1, j1, i2, j2 - 1].PathDistance == this.NoPath &
                                    this.MyCellPairs[i2, j2, i2, j2 - 1].PathDistance == 1)
                                {
                                    this.MyCellPairs[i1, j1, i2, j2 - 1].PathDistance =
                                       this.MyCellPairs[i1, j1, i2, j2].PathDistance + 1;
                                    //this.MyCellPairs[i2, j2 - 1, i1, j1].PathDistance =
                                    //   this.MyCellPairs[i1, j1, i2, j2 - 1].PathDistance;
                                    FoundNewCell = true;
                                }
                            }
                            if (j2 < this.MazeHeight - 1)
                            {
                                if (this.MyCellPairs[i1, j1, i2, j2 + 1].PathDistance == this.NoPath &
                                    this.MyCellPairs[i2, j2, i2, j2 + 1].PathDistance == 1)
                                {
                                    this.MyCellPairs[i1, j1, i2, j2 + 1].PathDistance =
                                       this.MyCellPairs[i1, j1, i2, j2].PathDistance + 1;
                                    //this.MyCellPairs[i2, j2 + 1, i1, j1].PathDistance =
                                    //   this.MyCellPairs[i1, j1, i2, j2 + 1].PathDistance;
                                    FoundNewCell = true;
                                }
                            }
                        }
                    }
                }
            }
        }


        public void GeneratePerfectMaze()
        {
            int m;
            int i1;
            int j1;
            int i2;
            int j2;

            this.OpenCloseWalls(false);
            this.GenerateWallDoorPermutation();
            this.calculatePathDistance();

            for (m = 0; m < this.NumberOfWallDoors; m++)
            {
                i1 = WallDoorPermutation[m, 0];
                j1 = WallDoorPermutation[m, 1];
                i2 = WallDoorPermutation[m, 2];
                j2 = WallDoorPermutation[m, 3];

                if (this.MyCellPairs[i1, j1, i2, j2].PathDistance == this.NoPath)
                {
                    this.SetDirectConnection(i1, j1, i2, j2, true);
                    this.calculatePathDistance();
                }
            }
        }
        private void SetDirectConnection(int i1, int j1, int i2, int j2, bool bConnected)
        {
            if (this.MyCellPairs[i1, j1, i2, j2].CellsAdjacent == false)
            {
                throw new Exception("Trying to define wall between non-adjacent cells");
            }
            else
            {
                this.MyCellPairs[i1, j1, i2, j2].CellsDirectlyConnected = bConnected;
                this.MyCellPairs[i2, j2, i1, j1].CellsDirectlyConnected = bConnected;
            }
        }
        public void SetFromText(string[] plines)
        {
            int h;
            int w;
            int i;
            int j;
            int ln;
            int cn;

            h = (plines.Length + 1) / 2;
            w = (plines[0].Length + 1) / 2;

            this.ResetMaze(w, h);

            for (j = 0; j < this.MazeHeight; j++)
            {
                ln = ((this.MazeHeight - j) * 2) - 2;
                for (i = 0; i < this.MazeWidth; i++)
                {
                    cn = i * 2;
                    if (i < this.MazeWidth - 1)
                    {
                        if (plines[ln][cn + 1] == '|')
                        {
                            this.SetDirectConnection(i, j, i + 1, j, false);
                        }
                        else
                        {
                            this.SetDirectConnection(i, j, i + 1, j, true);
                        }
                    }
                    if (j > 0)
                    {
                        if (plines[ln + 1][cn] == '-')
                        {
                            this.SetDirectConnection(i, j - 1, i, j, false);
                        }
                        else
                        {
                            this.SetDirectConnection(i, j - 1, i, j, true);
                        }
                    }
                }
            }
        }


        public string[] MazeAsText()
        {
            int i;
            int j;
            string s1; //Dots for cells with vertical walls
            string s2; //Horizontal walls

            string[] lines;
            lines = new string[(this.MazeHeight * 2) - 1];

            for (j = this.MazeHeight - 1; j >= 0; j--)
            {
                s1 = "";
                s2 = "";
                for (i = 0; i < this.MazeWidth; i++)
                {
                    s1 = s1 + ".";
                    if (i < this.MazeWidth - 1)
                    {
                        if (this.MyCellPairs[i, j, i + 1, j].CellsDirectlyConnected == false)
                        {
                            s1 = s1 + "|";
                        }
                        else
                        {
                            s1 = s1 + " ";
                        }
                    }
                    if (j > 0)
                    {
                        if (this.MyCellPairs[i, j, i, j - 1].CellsDirectlyConnected == false)
                        {
                            s2 = s2 + "-";
                        }
                        else
                        {
                            s2 = s2 + " ";
                        }
                        if (i < this.MazeWidth - 1)
                        {
                            s2 = s2 + " ";
                        }
                    }
                }
                lines[((this.MazeHeight - j) * 2) - 2] = s1;

                if (j > 0)
                {
                    lines[((this.MazeHeight - j) * 2) - 1] = s2;
                }
            }

            return lines;
        }

    }
}

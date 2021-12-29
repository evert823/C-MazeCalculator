using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeCalculator
{
    public class CellSet
    {
        public bool[,] IsIncluded;
        public int[] csi;
        public int[] csj;
        public int CellCount;

        public CellSet(int pWidth, int pHeight)
        {
            this.ResetCellSet(pWidth, pHeight);
        }

        public void ResetCellSet(int pWidth, int pHeight)
        {
            this.CellCount = 0;
            this.csi = null;
            this.csi = new int[pWidth * pHeight];
            this.csj = null;
            this.csj = new int[pWidth * pHeight];
            this.IsIncluded = null;
            this.IsIncluded = new bool[pWidth, pHeight];
        }
    }

    public struct CellPair
    {
        public ushort PathDistance; //Non-commutatively stored distance FROM i1, j1 TO i2, j2
    }


    public struct WallsOfCell
    {
        public bool OpenToTop;
        public bool OpenToRight;
        public bool OpenToBottom;
        public bool OpenToLeft;
    }
    public class Maze
    {
        public int MazeWidth;
        public int MazeHeight;
        public ushort NoPath;

        public CellPair[,,,] MyCellPairs;
        public WallsOfCell[,] MyWallsOfCell;
        public int[,] NeighbourCount;
        public int[,,] Neighbouri;
        public int[,,] Neighbourj;

        private int[,] WallDoorPermutation;//n, i1, j1, i2, j2
        private int NumberOfWallDoors;

        private int[,] SetNumber;
        private int NumberOfSets;

        public Maze(int pWidth, int pHeight)
        {
            this.ResetMaze(pWidth, pHeight);
        }

        public void ResetMaze(int pWidth, int pHeight)
        {
            int i1;
            int j1;

            this.MazeWidth = pWidth;
            this.MazeHeight = pHeight;

            this.MyWallsOfCell = null;
            this.MyWallsOfCell = new WallsOfCell[this.MazeWidth, this.MazeHeight];


            for (i1 = 0; i1 < this.MazeWidth; i1++)
            {
                for (j1 = 0; j1 < this.MazeHeight; j1++)
                {
                    this.MyWallsOfCell[i1, j1].OpenToTop = false;
                    this.MyWallsOfCell[i1, j1].OpenToRight = false;
                    this.MyWallsOfCell[i1, j1].OpenToBottom = false;
                    this.MyWallsOfCell[i1, j1].OpenToLeft = false;
                }
            }

        }


        private void InitDistance()
        {
            int i1;
            int j1;
            int i2;
            int j2;

            this.MyCellPairs = null;
            this.MyCellPairs = new CellPair[this.MazeWidth, this.MazeHeight, this.MazeWidth, this.MazeHeight];

            this.NoPath = Convert.ToUInt16((this.MazeWidth * this.MazeHeight) + 1);//Exclusive upper limit for a real distance

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
                            } else
                            {
                                this.MyCellPairs[i1, j1, i2, j2].PathDistance = this.NoPath;
                            }
                        }
                    }
                }
            }
        }

        public void OpenCloseWalls(bool pOpen)
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

        private void CopyCellSet(CellSet pCellSetFrom, CellSet pCellSetTo)
        {
            int c;
            
            pCellSetTo.ResetCellSet(this.MazeWidth, this.MazeHeight);

            for (c = 0; c < pCellSetFrom.CellCount; c++)
            {
                pCellSetTo.csi[c] = pCellSetFrom.csi[c];
                pCellSetTo.csj[c] = pCellSetFrom.csj[c];
                pCellSetTo.IsIncluded[pCellSetFrom.csi[c], pCellSetFrom.csj[c]] = true;
            }
            pCellSetTo.CellCount = pCellSetFrom.CellCount;
        }

        public void calculatePathDistance()
        {
            int i1;
            int j1;

            this.InitDistance();
            this.CalculateNeighbours();

            for (i1 = 0; i1 < this.MazeWidth; i1++)
            {
                for (j1 = 0; j1 < this.MazeHeight; j1++)
                {
                    CalculatePathDistanceFrom(i1, j1);
                }
            }
            MessageBox.Show("Distances have been calculated");
        }

        private void CalculateNeighbours()
        {
            int i1;
            int j1;
            int c;

            this.NeighbourCount = null;
            this.Neighbouri = null;
            this.Neighbourj = null;

            this.NeighbourCount = new int[this.MazeWidth, this.MazeHeight];
            this.Neighbouri = new int[this.MazeWidth, this.MazeHeight, 4];
            this.Neighbourj = new int[this.MazeWidth, this.MazeHeight, 4];

            for (i1 = 0; i1 < this.MazeWidth; i1++)
            {
                for (j1 = 0; j1 < this.MazeHeight; j1++)
                {
                    this.NeighbourCount[i1, j1] = 0;

                    if (j1 > 0 & this.MyWallsOfCell[i1, j1].OpenToBottom == true)
                    {
                        this.NeighbourCount[i1, j1] += 1;
                        c = this.NeighbourCount[i1, j1];
                        this.Neighbouri[i1, j1, c - 1] = i1;
                        this.Neighbourj[i1, j1, c - 1] = j1 - 1;
                    }
                    if (i1 < this.MazeWidth - 1 & this.MyWallsOfCell[i1, j1].OpenToRight == true)
                    {
                        this.NeighbourCount[i1, j1] += 1;
                        c = this.NeighbourCount[i1, j1];
                        this.Neighbouri[i1, j1, c - 1] = i1 + 1;
                        this.Neighbourj[i1, j1, c - 1] = j1;
                    }
                    if (j1 < this.MazeHeight - 1 & this.MyWallsOfCell[i1, j1].OpenToTop == true)
                    {
                        this.NeighbourCount[i1, j1] += 1;
                        c = this.NeighbourCount[i1, j1];
                        this.Neighbouri[i1, j1, c - 1] = i1;
                        this.Neighbourj[i1, j1, c - 1] = j1 + 1;
                    }
                    if (i1 > 0 & this.MyWallsOfCell[i1, j1].OpenToLeft == true)
                    {
                        this.NeighbourCount[i1, j1] += 1;
                        c = this.NeighbourCount[i1, j1];
                        this.Neighbouri[i1, j1, c - 1] = i1 - 1;
                        this.Neighbourj[i1, j1, c - 1] = j1;
                    }
                }
            }
        }


        private void CalculatePathDistanceFrom(int i1, int j1)
        {
            CellSet RingA;
            CellSet RingB;
            ushort hRouteDistance;
            int r;
            int n;
            int i2;
            int j2;

            RingA = new CellSet(this.MazeWidth, this.MazeHeight);
            RingB = new CellSet(this.MazeWidth, this.MazeHeight);

            RingA.csi[0] = i1;
            RingA.csj[0] = j1;
            RingA.IsIncluded[i1, j1] = true;
            RingA.CellCount = 1;

            hRouteDistance = 1;

            do
            {
                RingB.ResetCellSet(this.MazeWidth, this.MazeHeight);
                for (r = 0; r < RingA.CellCount; r++)
                {
                    for (n = 0; n < NeighbourCount[RingA.csi[r], RingA.csj[r]]; n++)
                    {
                        i2 = Neighbouri[RingA.csi[r], RingA.csj[r], n];
                        j2 = Neighbourj[RingA.csi[r], RingA.csj[r], n];

                        if (this.MyCellPairs[i1, j1, i2, j2].PathDistance == this.NoPath)
                        {
                            this.MyCellPairs[i1, j1, i2, j2].PathDistance = hRouteDistance;
                            if (RingB.IsIncluded[i2, j2] == false)
                            {
                                RingB.CellCount += 1;
                                RingB.csi[RingB.CellCount - 1] = i2;
                                RingB.csj[RingB.CellCount - 1] = j2;
                                RingB.IsIncluded[i2, j2] = true;
                            }
                        }
                    }
                }
                this.CopyCellSet(RingB, RingA);
                hRouteDistance += 1;
                Application.DoEvents();
            } while (RingB.CellCount > 0);
        }

        private void InitSetNumbers()
        {
            int i;
            int j;
            int n;
            
            this.SetNumber = null;
            this.SetNumber = new int[this.MazeWidth, this.MazeHeight];
            this.NumberOfSets = this.MazeWidth * this.MazeHeight;

            n = 0;

            for (i = 0; i < this.MazeWidth; i++)
            {
                for (j = 0; j < this.MazeHeight; j++)
                {
                    this.SetNumber[i, j] = n; // The setnumber will also be 0-based!!!
                    n++;
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
            int i3;
            int j3;
            int s1;
            int s2;

            this.OpenCloseWalls(false);
            this.GenerateWallDoorPermutation();
            MessageBox.Show("GenerateWallDoorPermutation ended");
            this.InitSetNumbers();

            for (m = 0; m < this.NumberOfWallDoors; m++)
            {
                i1 = WallDoorPermutation[m, 0];
                j1 = WallDoorPermutation[m, 1];
                i2 = WallDoorPermutation[m, 2];
                j2 = WallDoorPermutation[m, 3];

                s1 = this.SetNumber[i1, j1];
                s2 = this.SetNumber[i2, j2];
                if (s1 != s2)
                {
                    this.SetDirectConnection(i1, j1, i2, j2, true);
                    for (i3 = 0; i3 < this.MazeWidth; i3++)
                    {
                        for (j3 = 0; j3 < this.MazeHeight; j3++)
                        {
                            if (this.SetNumber[i3, j3] == s2)
                            {
                                this.SetNumber[i3, j3] = s1;
                            }
                        }
                    }
                    this.NumberOfSets--;
                }
                if (this.NumberOfSets <= 1)
                {
                    break;
                }
            }
            MessageBox.Show("Maze has been generated");
        }

        private void SetDirectConnection(int i1, int j1, int i2, int j2, bool bConnected)
        {
            if (i2 == i1 & j2 == j1 + 1)
            {
                this.MyWallsOfCell[i1, j1].OpenToTop = bConnected;
                this.MyWallsOfCell[i2, j2].OpenToBottom = bConnected;
            }
            else if (i2 == i1 + 1 & j2 == j1)
            {
                this.MyWallsOfCell[i1, j1].OpenToRight = bConnected;
                this.MyWallsOfCell[i2, j2].OpenToLeft = bConnected;
            }
            else if (i2 == i1 & j2 == j1 - 1)
            {
                this.MyWallsOfCell[i1, j1].OpenToBottom = bConnected;
                this.MyWallsOfCell[i2, j2].OpenToTop = bConnected;
            }
            else if (i2 == i1 - 1 & j2 == j1)
            {
                this.MyWallsOfCell[i1, j1].OpenToLeft = bConnected;
                this.MyWallsOfCell[i2, j2].OpenToRight = bConnected;
            }
            else
            {
                throw new Exception("Trying to define wall between non-adjacent cells");
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
                        if (this.MyWallsOfCell[i, j].OpenToRight == false)
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
                        if (this.MyWallsOfCell[i, j].OpenToBottom == false)
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

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

        public void AddCell(int i, int j)
        {
            if (this.IsIncluded[i, j] == false)
            {
                this.CellCount += 1;
                this.csi[this.CellCount - 1] = i;
                this.csj[this.CellCount - 1] = j;
                this.IsIncluded[i, j] = true;
            }
        }
    }

    public enum MarkColor
    {
        White,
        Blue,
        Red,
        Green,
        Yellow
    }

    public struct WallsOfCell
    {
        public bool OpenToTop;
        public bool OpenToRight;
        public bool OpenToBottom;
        public bool OpenToLeft;
    }

    public struct CalculatePathDistanceResult
    {
        public int RequestedDistance;
        public int MostDistanti;
        public int MostDistantj;
        public int MostDistantd;
    }

    public class Maze
    {
        public int MazeWidth;
        public int MazeHeight;
        public int NoPath;

        public MarkColor[,] CellSetColor;
        public WallsOfCell[,] MyWallsOfCell;
        public int[,] NeighbourCount;
        public int[,,] Neighbouri;
        public int[,,] Neighbourj;

        private int[,] WallDoorPermutation;//n, i1, j1, i2, j2
        private int NumberOfWallDoors;

        private int[,] SetNumber;
        private int NumberOfSets;

        //Point A = userdefined starting point
        //Point B = userdefined end point
        //Point C = point most distant from A
        //Point X and Y are two points with maximum distance that occurs in current maze
        public int pAi;
        public int pAj;
        public int pBi;
        public int pBj;
        public int distance_AB;
        public int pCi;
        public int pCj;
        public int distance_AC;
        public int pXi;
        public int pXj;
        public int pYi;
        public int pYj;
        public int distance_XY;
        private CellSet Path_AB;
        private CellSet Path_AC;
        private CellSet Path_XY;

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

            this.CellSetColor = null;
            this.CellSetColor = new MarkColor[this.MazeWidth, this.MazeHeight];

            this.NoPath = (this.MazeWidth * this.MazeHeight) + 1;//Exclusive upper limit for a real distance

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
            this.ClearColors();
            //Mark with colors like this:
            //this.CellSetColor[2, 3] = MarkColor.Blue;
            //this.CellSetColor[8, 7] = MarkColor.Red;
            //this.CellSetColor[4, 11] = MarkColor.Green;
            //this.CellSetColor[9, 5] = MarkColor.Yellow;

        }

        public void ClearColors()
        {
            int i1;
            int j1;
            for (i1 = 0; i1 < this.MazeWidth; i1++)
            {
                for (j1 = 0; j1 < this.MazeHeight; j1++)
                {
                    this.CellSetColor[i1, j1] = MarkColor.White;
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

        private void MarkCellSet(ref CellSet pCellSet, MarkColor pColor)
        {
            int n;
            int i;
            int j;

            for (n = 0; n < pCellSet.CellCount; n++)
            {
                i = pCellSet.csi[n];
                j = pCellSet.csj[n];
                this.CellSetColor[i, j] = pColor;
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

        public void calculatePathDistance(bool MarkAB, bool MarkAC, bool MarkXY)
        {
            int i1;
            int j1;

            this.CalculateNeighbours();
            this.ClearColors();

            CellSet tmpPath_AB;
            CellSet tmpPath_AC;

            this.Path_AB = new CellSet(this.MazeWidth, this.MazeHeight);
            this.Path_AC = new CellSet(this.MazeWidth, this.MazeHeight);
            this.Path_XY = new CellSet(this.MazeWidth, this.MazeHeight);
            tmpPath_AB = new CellSet(this.MazeWidth, this.MazeHeight);
            tmpPath_AC = new CellSet(this.MazeWidth, this.MazeHeight);

            CalculatePathDistanceResult MyResult;
            MyResult = CalculatePathDistanceFrom(this.pAi, this.pAj, this.pBi, this.pBj, ref this.Path_AB, ref this.Path_AC);
            this.distance_AB = MyResult.RequestedDistance;

            this.pCi = MyResult.MostDistanti;
            this.pCj = MyResult.MostDistantj;
            this.distance_AC = MyResult.MostDistantd;

            MessageBox.Show("Requested distance : " + this.distance_AB.ToString());
            MessageBox.Show("Max distance from this point : " + this.distance_AC.ToString()
                        + " --> " + this.pCi.ToString() + "," + this.pCj.ToString());

            this.distance_XY = -1;
            this.pXi = -1;
            this.pXj = -1;
            this.pYi = -1;
            this.pYj = -1;

            for (i1 = 0; i1 < this.MazeWidth; i1++)
            {
                for (j1 = 0; j1 < this.MazeHeight; j1++)
                {
                    MyResult = CalculatePathDistanceFrom(i1, j1, 0, 0, ref tmpPath_AB, ref tmpPath_AC);
                    if (MyResult.MostDistantd > this.distance_XY)
                    {
                        this.distance_XY = MyResult.MostDistantd;
                        this.pXi = i1;
                        this.pXj = j1;
                        this.pYi = MyResult.MostDistanti;
                        this.pYj = MyResult.MostDistantj;
                        this.CopyCellSet(tmpPath_AC, this.Path_XY);
                    }
                }
            }

            if (MarkAB == true)
            {
                this.MarkCellSet(ref this.Path_AB, MarkColor.Red);
            }
            if (MarkAC == true)
            {
                this.MarkCellSet(ref this.Path_AC, MarkColor.Yellow);
            }
            if (MarkXY == true)
            {
                this.MarkCellSet(ref this.Path_XY, MarkColor.Green);
            }

            MessageBox.Show("Max distance overall : " + this.distance_XY.ToString() + " --> " + this.pXi.ToString() + "," + this.pXj.ToString() + "," + this.pYi.ToString() + "," + this.pYj.ToString());
        }


        private CalculatePathDistanceResult CalculatePathDistanceFrom(int fromi, int fromj, int toi, int toj, ref CellSet RequestedPath, ref CellSet PathToMostDistant)
        {
            CalculatePathDistanceResult MyResult;
            MyResult = new CalculatePathDistanceResult();
            MyResult.MostDistantd = this.NoPath;
            MyResult.RequestedDistance = this.NoPath;
            MyResult.MostDistanti = -1;
            MyResult.MostDistantj = -1;
            
            CellSet RingA;
            CellSet RingB;
            int hRouteDistance;
            int r;
            int n;
            int i2;
            int j2;

            RingA = new CellSet(this.MazeWidth, this.MazeHeight);
            RingB = new CellSet(this.MazeWidth, this.MazeHeight);

            int[,] PathDistanceTo;

            void LoadPath(int ti, int tj, ref CellSet Path_ti_tj_fromi_fromj)
            {
                int ci;
                int cj;
                int nb;
                int ni;
                int nj;

                Path_ti_tj_fromi_fromj.ResetCellSet(this.MazeWidth, this.MazeHeight);

                if (ti == -1 || tj == -1)
                {
                    return;
                }

                if (PathDistanceTo[ti, tj] == this.NoPath)
                {
                    return;
                }

                ci = ti;
                cj = tj;

                Path_ti_tj_fromi_fromj.AddCell(ci, cj);

                while (Path_ti_tj_fromi_fromj.IsIncluded[fromi, fromj] == false)
                {
                    nb = 0;
                    ni = Neighbouri[ci, cj, nb];
                    nj = Neighbourj[ci, cj, nb];
                    while (PathDistanceTo[ni, nj] != PathDistanceTo[ci, cj] - 1)
                    {
                        nb++;
                        ni = Neighbouri[ci, cj, nb];
                        nj = Neighbourj[ci, cj, nb];
                    }
                    ci = ni;
                    cj = nj;
                    Path_ti_tj_fromi_fromj.AddCell(ci, cj);
                }
            }


            PathDistanceTo = new int[this.MazeWidth, this.MazeHeight];
            for (i2 = 0; i2 < this.MazeWidth; i2++)
            {
                for (j2 = 0; j2 < this.MazeHeight; j2++)
                {
                    if (fromi == i2 & fromj == j2)
                    {
                        PathDistanceTo[i2, j2] = 0;
                    }
                    else
                    {
                        PathDistanceTo[i2, j2] = this.NoPath;
                    }
                }
            }

            RingA.AddCell(fromi, fromj);

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

                        if (PathDistanceTo[i2, j2] == this.NoPath)
                        {
                            PathDistanceTo[i2, j2] = hRouteDistance;
                            RingB.AddCell(i2, j2);//AddCell will avoid duplicates
                            MyResult.MostDistanti = i2;
                            MyResult.MostDistantj = j2;
                            MyResult.MostDistantd = hRouteDistance;
                        }
                    }
                }
                this.CopyCellSet(RingB, RingA);
                hRouteDistance += 1;
                Application.DoEvents();
            } while (RingB.CellCount > 0);

            MyResult.RequestedDistance = PathDistanceTo[toi, toj];

            LoadPath(toi, toj, ref RequestedPath);
            LoadPath(MyResult.MostDistanti, MyResult.MostDistantj, ref PathToMostDistant);

            return MyResult;
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
            //MessageBox.Show("GenerateWallDoorPermutation ended");
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
                    Application.DoEvents();
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

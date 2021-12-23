using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace MazeCalculator
{
    public class MazeDrawer
    {
        public struct Surrounding
        {
            public int topy;
            public int bottomy;
            public int leftx;
            public int rightx;
        }
        
        public const int PixelsPerCell = 20;
        public const int PenWidth = 3;
        public const int edgemarge = 3;
        
        public readonly Maze MyMaze;

        private Surrounding CellSurrounding(int i, int j)
        {
            Surrounding MyResult;

            MyResult.leftx = (i * PixelsPerCell) + edgemarge;
            MyResult.rightx = MyResult.leftx + PixelsPerCell;
            MyResult.bottomy = ((this.MyMaze.MazeHeight - j) * PixelsPerCell) + edgemarge;
            MyResult.topy = MyResult.bottomy - PixelsPerCell;

            return MyResult;
        }

        public MazeDrawer(Maze pMaze)
        {
            this.MyMaze = pMaze;
        }


        
        public void SaveMazeAsImage(string pFileName)
        {
            int w = (MyMaze.MazeWidth * PixelsPerCell) + (edgemarge * 2);
            int h = (MyMaze.MazeHeight * PixelsPerCell) + (edgemarge * 2);

            Bitmap MyBitmap;
            Graphics g;

            MyBitmap = new Bitmap(w, h);
            g = Graphics.FromImage(MyBitmap);

            Pen blackPen = new Pen(Color.Black, PenWidth);

            g.DrawLine(blackPen, edgemarge, edgemarge, edgemarge, h - edgemarge);
            g.DrawLine(blackPen, edgemarge, h- edgemarge, w - edgemarge, h - edgemarge);
            g.DrawLine(blackPen, w - edgemarge, edgemarge, w - edgemarge, h - edgemarge);
            g.DrawLine(blackPen, w - edgemarge, edgemarge, edgemarge, edgemarge);

            int i;
            int j;
            
            for (i = 0; i < this.MyMaze.MazeWidth; i++)
            {
                for (j = 0; j < this.MyMaze.MazeHeight; j++)
                {
                    Surrounding MySurrounding = this.CellSurrounding(i, j);
                    
                    if (i < this.MyMaze.MazeWidth - 1)
                    {
                        if (this.MyMaze.MyCellPairs[i, j, i + 1, j].CellsDirectlyConnected == false)
                        {
                            g.DrawLine(blackPen, MySurrounding.rightx, MySurrounding.bottomy, MySurrounding.rightx, MySurrounding.topy);
                        }
                    }
                    if (j < this.MyMaze.MazeHeight - 1)
                    {
                        if (this.MyMaze.MyCellPairs[i, j, i, j + 1].CellsDirectlyConnected == false)
                        {
                            g.DrawLine(blackPen, MySurrounding.leftx, MySurrounding.topy, MySurrounding.rightx, MySurrounding.topy);
                        }
                    }
                }
            }

            MyBitmap.Save(pFileName, ImageFormat.Png);
        }
    }
}

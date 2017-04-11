using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    class Plane
    {
        Foundation foundation;

        Bitmap wholeImage, levelImage;
        Region clipRegion;

        Object objTemporas;
        bool drawObjTemporas;

        Size gridCellSize;
        bool drawGrid, snapGrid;

        public Plane(Foundation Foundation)
        {
            foundation = Foundation;

            clipRegion = new Region();
            drawObjTemporas = false;

            gridCellSize = foundation.Form.GridCellSize;
            drawGrid = foundation.Form.ShouldShowGrid;
            snapGrid = foundation.Form.ShouldSnapGrid;

            SetSize(foundation.Form.PlaneSize);
        }

        public Foundation Foundation
        {
            get { return foundation; }
        }

        public Bitmap Image
        {
            get { return wholeImage; }
        }

        public Object ObjTemporas
        {
            get { return objTemporas; }
        }

        public Size GridCellSize
        {
            get { return gridCellSize; }
            set { gridCellSize = value; }
        }

        public bool IsDrawGrid
        {
            get { return drawGrid; }
            set { drawGrid = value; }
        }

        public bool IsSnapGrid
        {
            get { return snapGrid; }
            set { snapGrid = value; }
        }

        public void SetSize(Size Size)
        {
            if (Size == null || Size.Width == 0 || Size.Height == 0) return;

            wholeImage = new Bitmap(Size.Width, Size.Height);
            levelImage = new Bitmap(Size.Width, Size.Height);
        }

        public void SetShowObjTemporas(bool Show)
        {
            if (Show)
            {
                drawObjTemporas = true;
            }
            else
            {
                drawObjTemporas = false;

                if (objTemporas != null)
                {
                    clipRegion = new Region(
                            new Rectangle(
                                objTemporas.Position,
                                objTemporas.GetDefinition().Image.Size
                                ));
                }
            }
        }

        public Point SnapToGrid(int X, int Y)
        {
            if (snapGrid)
            {
                if (gridCellSize.Width > 0)
                    X = (X / gridCellSize.Width) * gridCellSize.Width;

                if (gridCellSize.Height > 0)
                    Y = (Y / gridCellSize.Height) * gridCellSize.Height;
            }

            return new Point(X, Y);
        }

        public void MoveObjTemporas(int X, int Y)
        {
            Point nextLoc = SnapToGrid(X, Y);

            if (objTemporas != null && 
                objTemporas.GetDefinition() != null && 
                objTemporas.GetDefinition().Image != null)
            {
                clipRegion = new Region(
                    new Rectangle(
                        objTemporas.Position,
                        objTemporas.GetDefinition().Image.Size
                        ));

                /*double area =
                    objTemporas.GetDefinition().Image.Size.Width *
                    objTemporas.GetDefinition().Image.Size.Height;

                if (area > 64 * 64)
                {
                    clipRegion.Exclude(
                        new Rectangle(
                            nextLoc,
                            objTemporas.GetDefinition().Image.Size
                            ));
                }*/

                objTemporas.Position = nextLoc;
            }
        }

        public void MakeObjTemporas(Definition Definition)
        {
            if (Definition == null) return;

            objTemporas = new Object(foundation.Level, Definition);

            if (Definition.Image != null)
            {
                clipRegion = new Region(new Rectangle(objTemporas.Position, objTemporas.GetDefinition().Image.Size));
            }
            else
            {
                clipRegion = new Region(new Rectangle(objTemporas.Position, new Size(0, 0)));
            }
        }

        public void RemakeObjTemporas()
        {
            if (objTemporas == null) return;

            Object tmp = new Object(foundation.Level, objTemporas.GetDefinition());
            tmp.SetPosition(objTemporas.Position);
            objTemporas = tmp;
        }

        public void ForgetObjTemporas()
        {
            objTemporas = null;
        }

        private void drawPostLevel(Graphics GraphicsWhole)
        {
            if (objTemporas != null && drawObjTemporas)
                objTemporas.Draw(GraphicsWhole);

            if (drawGrid &&
                gridCellSize.Width >= 8 && gridCellSize.Height >= 8)
            {
                Pen pen = new Pen(Color.DarkGray);

                for (int i = 0; i < wholeImage.Width; i += gridCellSize.Width)
                    GraphicsWhole.DrawLine(pen, i, 0, i, wholeImage.Height);

                for (int i = 0; i < wholeImage.Height; i += gridCellSize.Height)
                    GraphicsWhole.DrawLine(pen, 0, i, wholeImage.Width, i);

                GraphicsWhole.DrawEllipse(pen, -4, -4, 8, 8);
            }
        }

        public void RedrawWhole()
        {
            Graphics graphicsWhole = Graphics.FromImage(wholeImage);

            Graphics graphicsLevel = Graphics.FromImage(levelImage);
            graphicsLevel.Clear(foundation.Form.PlaneBackColor);
            foundation.Level.Draw(graphicsLevel);

            graphicsWhole.DrawImage(levelImage, 0, 0);

            drawPostLevel(graphicsWhole);
        }

        public void RedrawIncrm()
        {
            if (clipRegion != null)
            {
                Graphics graphicsWhole = Graphics.FromImage(wholeImage);
                graphicsWhole.SetClip(clipRegion, System.Drawing.Drawing2D.CombineMode.Replace);
                graphicsWhole.DrawImage(levelImage, 0, 0);
                graphicsWhole.ResetClip();

                drawPostLevel(graphicsWhole);
            }
            else
            {
                RedrawWhole();
            }
        }
    }
}

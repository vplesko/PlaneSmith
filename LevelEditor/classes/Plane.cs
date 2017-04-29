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
        private Foundation foundation;

        private Bitmap wholeImage, levelImage;
        private Region clipRegion;

        private Object objTemporas;
        private bool drawObjTemporas;

        private Size gridCellSize;
        private bool drawGrid, snapGrid;

        private Point translation;

        public Plane(Foundation Foundation)
        {
            foundation = Foundation;

            clipRegion = new Region();
            drawObjTemporas = false;

            gridCellSize = foundation.Form.GridCellSize;
            drawGrid = foundation.Form.ShouldShowGrid;
            snapGrid = foundation.Form.ShouldSnapGrid;

            translation = new Point(0, 0);

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

        public Point Translation
        {
            get { return translation; }
        }

        public void SetTranslation(int X, int Y)
        {
            translation.X = X;
            translation.Y = Y;
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

        public Point SnapToGrid(int X, int Y, bool NoCheckFlag)
        {
            if (NoCheckFlag || snapGrid)
            {
                if (gridCellSize.Width > 0)
                {
                    if (X < 0) X -= gridCellSize.Width;
                    X = (X / gridCellSize.Width) * gridCellSize.Width;
                }

                if (gridCellSize.Height > 0)
                {
                    if (Y < 0) Y -= gridCellSize.Height;
                    Y = (Y / gridCellSize.Height) * gridCellSize.Height;
                }
            }

            return new Point(X, Y);
        }

        public Point SnapToGrid(Point P, bool NoCheckFlag)
        {
            return SnapToGrid(P.X, P.Y, NoCheckFlag);
        }

        public Point Transform(int X, int Y)
        {
            return new Point(X + translation.X, Y + translation.Y);
        }

        public Point GetCoordsOnPlane(int X, int Y)
        {
            return SnapToGrid(InverseTransform(X, Y), false);
        }

        public Point GetCoordsOnPlane(Point P)
        {
            return GetCoordsOnPlane(P.X, P.Y);
        }

        public Point Transform(Point P)
        {
            return Transform(P.X, P.Y);
        }

        public Point InverseTransform(int X, int Y)
        {
            return new Point(X - translation.X, Y - translation.Y);
        }

        public Point InverseTransform(Point P)
        {
            return InverseTransform(P.X, P.Y);
        }

        public void MoveObjTemporas(int X, int Y)
        {
            Point nextLoc = SnapToGrid(X, Y, false);

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

        public void MoveObjTemporas(Point P)
        {
            MoveObjTemporas(P.X, P.Y);
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
            {
                GraphicsWhole.TranslateTransform(translation.X, translation.Y);
                objTemporas.Draw(GraphicsWhole);
                GraphicsWhole.ResetTransform();
            }

            if (drawGrid)
            {
                Pen pen = new Pen(Color.DarkGray);

                if (gridCellSize.Width >= 8 && gridCellSize.Height >= 8)
                {
                    int lft = translation.X % gridCellSize.Width;
                    int top = translation.Y % gridCellSize.Height;
                    int cntX = wholeImage.Width / gridCellSize.Width;
                    int cntY = wholeImage.Height / gridCellSize.Height;

                    for (int i = 0; i <= cntX; ++i)
                    {
                        GraphicsWhole.DrawLine(pen, lft + i * gridCellSize.Width, 0, lft + i * gridCellSize.Width, wholeImage.Height);
                    }

                    for (int j = 0; j <= cntY; ++j)
                    {
                        GraphicsWhole.DrawLine(pen, 0, top + j * gridCellSize.Height, wholeImage.Width, top + j * gridCellSize.Height);
                    }
                }

                GraphicsWhole.TranslateTransform(translation.X, translation.Y);
                GraphicsWhole.DrawEllipse(pen, -4, -4, 8, 8);
                GraphicsWhole.ResetTransform();
            }
        }

        public void RedrawWhole()
        {
            Graphics graphicsWhole = Graphics.FromImage(wholeImage);
            graphicsWhole.Clear(foundation.Form.PlaneBackColor);

            Graphics graphicsLevel = Graphics.FromImage(levelImage);
            graphicsLevel.Clear(foundation.Form.PlaneBackColor);

            graphicsLevel.TranslateTransform(translation.X, translation.Y);
            foundation.Level.Draw(graphicsLevel);
            graphicsLevel.ResetTransform();

            graphicsWhole.DrawImage(levelImage, 0, 0);

            drawPostLevel(graphicsWhole);
        }

        public void RedrawIncrm()
        {
            if (clipRegion != null)
            {
                Graphics graphicsWhole = Graphics.FromImage(wholeImage);

                graphicsWhole.TranslateTransform(translation.X, translation.Y);
                graphicsWhole.SetClip(clipRegion, System.Drawing.Drawing2D.CombineMode.Replace);
                graphicsWhole.Clear(foundation.Form.PlaneBackColor);
                graphicsWhole.ResetTransform();
                
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

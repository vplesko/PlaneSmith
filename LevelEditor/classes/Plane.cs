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
        Rectangle clipRect;

        Instance instAtCursor;
        bool drawInstAtCursor;

        Size gridCellSize;
        bool drawGrid, snapGrid;

        public Plane(Foundation Foundation)
        {
            foundation = Foundation;

            Size size = foundation.Form.PlaneSize;
            wholeImage = new Bitmap(size.Width, size.Height);
            levelImage = new Bitmap(size.Width, size.Height);

            clipRect = new Rectangle();
            drawInstAtCursor = false;

            gridCellSize = foundation.Form.GridCellSize;
            drawGrid = foundation.Form.ShouldShowGrid;
            snapGrid = foundation.Form.ShouldSnapGrid;
        }

        public Foundation Foundation
        {
            get { return foundation; }
        }

        public Bitmap Image
        {
            get { return wholeImage; }
        }

        public Instance InstAtCursor
        {
            get { return instAtCursor; }
        }

        public Size GridCellSize
        {
            get { return gridCellSize; }
            set
            {
                gridCellSize = value;
                foundation.Form.onPlaneChanged(true);
            }
        }

        public bool IsDrawGrid
        {
            get { return drawGrid; }
            set
            {
                drawGrid = value;
                foundation.Form.onPlaneChanged(true);
            }
        }

        public bool IsSnapGrid
        {
            get { return snapGrid; }
            set
            {
                snapGrid = value;
            }
        }

        public void SetSize(Size Size)
        {
            wholeImage = new Bitmap(Size.Width, Size.Height);
            levelImage = new Bitmap(Size.Width, Size.Height);
            foundation.Form.onPlaneChanged(true);
        }

        public void ShowInstAtCursor()
        {
            drawInstAtCursor = true;
        }

        public void MoveInstAtCursor(int X, int Y)
        {
            if (snapGrid)
            {
                X = (X / gridCellSize.Width) * gridCellSize.Width;
                Y = (Y / gridCellSize.Height) * gridCellSize.Height;
            }

            if (instAtCursor != null && instAtCursor.GetDefinition() != null)
            {
                clipRect = new Rectangle(instAtCursor.Location, instAtCursor.GetDefinition().Image.Size);
                instAtCursor.Location = new Point(X, Y);
            }
        }

        public void HideInstAtCursor()
        {
            drawInstAtCursor = false;
            foundation.Form.onPlaneChanged(false);
        }

        public void MakeInstAtCursor(Definition Definition)
        {
            instAtCursor = new Instance(foundation.Level, Definition);
            clipRect = new Rectangle(instAtCursor.Location, instAtCursor.GetDefinition().Image.Size);

            if (drawInstAtCursor) foundation.Form.onPlaneChanged(false);
        }

        public void RemakeInstAtCursor()
        {
            if (instAtCursor == null) return;

            Instance tmp = new Instance(foundation.Level, instAtCursor.GetDefinition());
            tmp.SetLocation(instAtCursor.Location);
            instAtCursor = tmp;
        }

        public void ForgetInstAtCursor()
        {
            instAtCursor = null;
            if (drawInstAtCursor) foundation.Form.onPlaneChanged(false);
        }

        private void drawPostLevel(Graphics GraphicsWhole)
        {
            if (instAtCursor != null && drawInstAtCursor)
                instAtCursor.Draw(GraphicsWhole);

            if (drawGrid &&
                gridCellSize.Width > 0 && gridCellSize.Height > 0)
            {
                Pen pen = new Pen(Color.DarkGray);

                for (int i = 0; i < wholeImage.Width; i += gridCellSize.Width)
                    GraphicsWhole.DrawLine(pen, i, 0, i, wholeImage.Height);

                for (int i = 0; i < wholeImage.Height; i += gridCellSize.Height)
                    GraphicsWhole.DrawLine(pen, 0, i, wholeImage.Width, i);
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
            if (clipRect != null)
            {
                Graphics graphicsWhole = Graphics.FromImage(wholeImage);
                graphicsWhole.SetClip(clipRect);
                graphicsWhole.DrawImage(levelImage, 0, 0);

                drawPostLevel(graphicsWhole);
            }
            else
            {
                RedrawWhole();
            }
        }
    }
}

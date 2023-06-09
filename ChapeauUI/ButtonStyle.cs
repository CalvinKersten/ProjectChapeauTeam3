using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauUI
{
    class ButtonStyle : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath path = new GraphicsPath();
            int arcRadius = 25; // Adjust the radius to control the amount of curvature

            int width = Width;
            int height = Height;

            path.AddArc(0, 0, arcRadius, arcRadius, 180, 90);
            path.AddArc(width - arcRadius, 0, arcRadius, arcRadius, 270, 90);
            path.AddArc(width - arcRadius, height - arcRadius, arcRadius, arcRadius, 0, 90);
            path.AddArc(0, height - arcRadius, arcRadius, arcRadius, 90, 90);
            path.CloseFigure();

            Region = new Region(path);
            base.OnPaint(pevent);
        }
    }
    class LabelStyle : Label
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath path = new GraphicsPath();
            int arcRadius = 25; // Adjust the radius to control the amount of curvature

            int width = Width;
            int height = Height;

            path.AddArc(0, 0, arcRadius, arcRadius, 180, 90);
            path.AddArc(width - arcRadius, 0, arcRadius, arcRadius, 270, 90);
            path.AddArc(width - arcRadius, height - arcRadius, arcRadius, arcRadius, 0, 90);
            path.AddArc(0, height - arcRadius, arcRadius, arcRadius, 90, 90);
            path.CloseFigure();

            Region = new Region(path);
            base.OnPaint(pevent);
        }
    }
}


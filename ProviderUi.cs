using System.Drawing.Drawing2D;

namespace Home_Hero
{
    // =====================================================================
    //  SOFT BOX  - flat rounded panel (no shadow) with optional accent bar.
    //  Used for the "smart plan" banner, the AI briefing box and the glass
    //  profile-strength card on the registration screen.
    // =====================================================================
    internal class SoftBox : Panel
    {
        public Color FillColor { get; set; } = Color.White;
        public Color BorderColor { get; set; } = Theme.Border;
        public Color AccentColor { get; set; } = Color.Empty;
        public int Radius { get; set; } = 12;

        public SoftBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Width < 8 || Height < 8) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float s = DeviceDpi / 96f;
            RectangleF rect = new RectangleF(1, 1, Width - 3, Height - 3);

            using (GraphicsPath path = Theme.RoundRect(rect, Radius * s))
            {
                using (SolidBrush fill = new SolidBrush(FillColor))
                    g.FillPath(fill, path);

                if (AccentColor != Color.Empty)
                {
                    GraphicsState st = g.Save();
                    g.SetClip(path, CombineMode.Intersect);
                    using (SolidBrush ab = new SolidBrush(AccentColor))
                        g.FillRectangle(ab, rect.X, rect.Y, 5 * s, rect.Height);
                    g.Restore(st);
                }

                using (Pen border = new Pen(BorderColor, 1f))
                    g.DrawPath(border, path);
            }
        }
    }
}

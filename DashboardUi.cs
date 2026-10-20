using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Home_Hero
{
    // =====================================================================
    //  HERO PANEL - rounded photo banner with a navy fade on the left so
    //  the welcome text stays readable
    // =====================================================================
    internal class HeroPanel : Panel
    {
        private Bitmap? cache;
        private Size cacheSize = Size.Empty;

        public Image? Photo { get; set; }

        public HeroPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Theme.Bg;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Width < 60 || Height < 60) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float s = DeviceDpi / 96f;
            Rectangle inner = new Rectangle(
                (int)(4 * s), (int)(2 * s),
                Width - (int)(8 * s), Height - (int)(12 * s));
            if (inner.Width < 10 || inner.Height < 10) return;

            // soft shadow
            for (int i = 4; i >= 1; i--)
            {
                RectangleF sr = inner;
                sr.Inflate(i * s, i * s);
                sr.Offset(0, 2 * s);
                using (GraphicsPath sp = Theme.RoundRect(sr, 18 * s + i))
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(9, 15, 40, 90)))
                    g.FillPath(sb, sp);
            }

            if (cache == null || cacheSize != inner.Size)
            {
                if (cache != null) cache.Dispose();
                cache = BuildCache(inner.Size);
                cacheSize = inner.Size;
            }

            GraphicsState state = g.Save();
            g.TranslateTransform(inner.X, inner.Y);
            using (GraphicsPath path = Theme.RoundRect(new RectangleF(0, 0, inner.Width, inner.Height), 18 * s))
            using (TextureBrush brush = new TextureBrush(cache))
            {
                g.FillPath(brush, path);
            }
            g.Restore(state);
        }

        private Bitmap BuildCache(Size size)
        {
            Bitmap bmp = new Bitmap(Math.Max(2, size.Width), Math.Max(2, size.Height));
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Rectangle all = new Rectangle(0, 0, bmp.Width, bmp.Height);

                if (Photo != null)
                {
                    float aspect = (float)bmp.Width / bmp.Height;
                    float srcW = Photo.Width;
                    float srcH = srcW / aspect;
                    if (srcH > Photo.Height)
                    {
                        srcH = Photo.Height;
                        srcW = srcH * aspect;
                    }
                    float srcX = (Photo.Width - srcW) / 2f;
                    float srcY = Math.Min(Photo.Height - srcH, Photo.Height * 0.12f);
                    g.DrawImage(Photo, all, srcX, srcY, srcW, srcH, GraphicsUnit.Pixel);
                }
                else
                {
                    using (LinearGradientBrush back = new LinearGradientBrush(all, Theme.NavyDeep, Theme.NavyLight, 0f))
                        g.FillRectangle(back, all);
                }

                // navy fade from the left
                int fadeWidth = Math.Max(4, (int)(bmp.Width * 0.68f));
                Rectangle fade = new Rectangle(0, 0, fadeWidth, bmp.Height);
                using (LinearGradientBrush lb = new LinearGradientBrush(
                    fade, Color.FromArgb(242, Theme.NavyDeep), Color.FromArgb(0, Theme.NavyDeep), 0f))
                {
                    g.FillRectangle(lb, fade);
                }

                // orange accent line along the bottom
                Rectangle line = new Rectangle(0, bmp.Height - 4, bmp.Width, 4);
                using (LinearGradientBrush ab = new LinearGradientBrush(line, Theme.Orange, Color.FromArgb(255, 176, 96), 0f))
                    g.FillRectangle(ab, line);
            }
            return bmp;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && cache != null)
            {
                cache.Dispose();
                cache = null;
            }
            base.Dispose(disposing);
        }
    }

    // =====================================================================
    //  AVATAR CIRCLE - filled circle with centred text (initials / badges / dots)
    // =====================================================================
    internal class BadgeCircle : Control
    {
        public string Initials { get; set; } = "";
        public Color Fill { get; set; } = Theme.Orange;
        public Color TextColor { get; set; } = Color.White;
        public Color RingColor { get; set; } = Color.Empty;
        public float FontSize { get; set; } = 12F;

        public BadgeCircle()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(44, 44);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF r = new RectangleF(1, 1, Width - 3, Height - 3);
            using (SolidBrush b = new SolidBrush(Fill))
                g.FillEllipse(b, r);

            if (RingColor != Color.Empty)
                using (Pen p = new Pen(RingColor, 2f))
                    g.DrawEllipse(p, r);

            if (!string.IsNullOrEmpty(Initials))
            {
                using (Font f = Theme.MakeFont(FontSize, FontStyle.Bold))
                {
                    TextRenderer.DrawText(g, Initials, f, ClientRectangle, TextColor,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                        TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
                }
            }
        }
    }
}

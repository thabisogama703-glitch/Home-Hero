using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Home_Hero
{
    internal static class UiAssets
    {
        public static Image GetImage(string resourceName)
        {
            return Properties.Resources.ResourceManager.GetObject(resourceName) as Image
                ?? throw new InvalidOperationException("The image resource '" + resourceName + "' could not be loaded.");
        }
    }

    // =====================================================================
    //  THEME  (same navy + orange palette as the Customer Dashboard)
    // =====================================================================
    internal static class Theme
    {
        public static readonly Color Navy = Color.FromArgb(22, 45, 92);
        public static readonly Color NavyLight = Color.FromArgb(44, 80, 140);
        public static readonly Color NavyDeep = Color.FromArgb(12, 28, 62);
        public static readonly Color Orange = Color.FromArgb(255, 107, 53);
        public static readonly Color OrangeHover = Color.FromArgb(255, 132, 84);
        public static readonly Color OrangeSoft = Color.FromArgb(255, 241, 235);
        public static readonly Color Bg = Color.FromArgb(244, 247, 251);
        public static readonly Color Border = Color.FromArgb(226, 232, 240);
        public static readonly Color Text = Color.FromArgb(30, 41, 59);
        public static readonly Color Muted = Color.FromArgb(100, 116, 139);

        public static readonly Color Green = Color.FromArgb(22, 163, 74);
        public static readonly Color GreenSoft = Color.FromArgb(220, 252, 231);
        public static readonly Color Amber = Color.FromArgb(217, 119, 6);
        public static readonly Color AmberSoft = Color.FromArgb(254, 243, 199);
        public static readonly Color Blue = Color.FromArgb(37, 99, 235);
        public static readonly Color BlueSoft = Color.FromArgb(219, 234, 254);
        public static readonly Color Red = Color.FromArgb(220, 38, 38);
        public static readonly Color RedSoft = Color.FromArgb(254, 226, 226);
        public static readonly Color Purple = Color.FromArgb(124, 58, 237);
        public static readonly Color PurpleSoft = Color.FromArgb(237, 233, 254);

        public static Font MakeFont(float size, FontStyle style = FontStyle.Regular)
        {
            return new Font("Segoe UI", size, style, GraphicsUnit.Point);
        }

        public static Font MakeSemibold(float size)
        {
            return new Font("Segoe UI Semibold", size, FontStyle.Regular, GraphicsUnit.Point);
        }

        public static GraphicsPath RoundRect(RectangleF r, float radius)
        {
            float d = Math.Max(1f, radius * 2f);
            GraphicsPath p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        public static Label MakeLabel(string text, float size, FontStyle style, Color color)
        {
            Label l = new Label();
            l.AutoSize = true;
            l.BackColor = Color.Transparent;
            l.ForeColor = color;
            l.Font = MakeFont(size, style);
            l.Text = text;
            return l;
        }
    }

    // =====================================================================
    //  CARD PANEL  - white rounded card with soft shadow
    // =====================================================================
    internal class CardPanel : Panel
    {
        public int Radius { get; set; } = 16;
        public Color FillColor { get; set; } = Color.White;
        public Color BorderColor { get; set; } = Theme.Border;
        public Color AccentColor { get; set; } = Color.Empty;

        public CardPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Theme.Bg;
            Padding = new Padding(20);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Width < 12 || Height < 12) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float s = DeviceDpi / 96f;
            RectangleF rect = new RectangleF(4 * s, 4 * s, Width - 8 * s, Height - 12 * s);

            for (int i = 4; i >= 1; i--)
            {
                RectangleF sr = rect;
                sr.Inflate(i * s, i * s);
                sr.Offset(0, 2 * s);
                using (GraphicsPath sp = Theme.RoundRect(sr, Radius + i))
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(7, 15, 40, 90)))
                {
                    g.FillPath(sb, sp);
                }
            }

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

    // =====================================================================
    //  GRADIENT HEADER
    // =====================================================================
    internal class GradientPanel : Panel
    {
        public Color ColorA { get; set; } = Theme.NavyDeep;
        public Color ColorB { get; set; } = Theme.NavyLight;
        public Image? Photo { get; set; }

        public GradientPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        /// <summary>The solid colour of the horizontal gradient at a given x position.</summary>
        public Color ColorAtX(float x)
        {
            float t = Width <= 0 ? 0f : Math.Max(0f, Math.Min(1f, x / Width));
            return Color.FromArgb(255,
                (int)(ColorA.R + (ColorB.R - ColorA.R) * t),
                (int)(ColorA.G + (ColorB.G - ColorA.G) * t),
                (int)(ColorA.B + (ColorB.B - ColorA.B) * t));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Width <= 0 || Height <= 0) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (LinearGradientBrush br = new LinearGradientBrush(ClientRectangle, ColorA, ColorB, 0f))
                g.FillRectangle(br, ClientRectangle);

            if (Photo != null)
            {
                Rectangle imageBounds = Width > Height * 4
                    ? new Rectangle(Math.Max(0, Width - Math.Max(220, Math.Min(520, Width / 3))), 0,
                        Math.Max(1, Math.Max(220, Math.Min(520, Width / 3))), Height)
                    : ClientRectangle;
                DrawCover(g, Photo, imageBounds);

                using (SolidBrush tint = new SolidBrush(Color.FromArgb(120, Theme.NavyDeep)))
                    g.FillRectangle(tint, imageBounds);

                int fadeLeft = Math.Max(0, imageBounds.Left - Math.Max(70, Height));
                Rectangle fadeBounds = new Rectangle(fadeLeft, 0, Width - fadeLeft, Height);
                using (LinearGradientBrush fade = new LinearGradientBrush(
                    fadeBounds, ColorA, Color.FromArgb(120, ColorA), 0f))
                    g.FillRectangle(fade, fadeBounds);
            }
            else
            {
                using (SolidBrush c1 = new SolidBrush(Color.FromArgb(14, 255, 255, 255)))
                    g.FillEllipse(c1, Width - Height * 3, -Height, Height * 2.4f, Height * 2.4f);
                using (SolidBrush c2 = new SolidBrush(Color.FromArgb(10, 255, 107, 53)))
                    g.FillEllipse(c2, Width / 2f, Height * 0.2f, Height * 1.6f, Height * 1.6f);
            }

            // orange accent line
            int lineH = Math.Max(3, (int)(4 * DeviceDpi / 96f));
            Rectangle line = new Rectangle(0, Height - lineH, Width, lineH);
            using (LinearGradientBrush ab = new LinearGradientBrush(line, Theme.Orange, Color.FromArgb(255, 170, 90), 0f))
                g.FillRectangle(ab, line);
        }

        private static void DrawCover(Graphics graphics, Image image, Rectangle destination)
        {
            if (destination.Width <= 0 || destination.Height <= 0) return;

            float targetRatio = (float)destination.Width / destination.Height;
            float sourceRatio = (float)image.Width / image.Height;
            RectangleF source = new RectangleF(0, 0, image.Width, image.Height);
            if (sourceRatio > targetRatio)
            {
                float sourceWidth = image.Height * targetRatio;
                source.X = (image.Width - sourceWidth) / 2f;
                source.Width = sourceWidth;
            }
            else
            {
                float sourceHeight = image.Width / targetRatio;
                source.Y = (image.Height - sourceHeight) / 2f;
                source.Height = sourceHeight;
            }
            graphics.DrawImage(image, destination, source.X, source.Y, source.Width, source.Height, GraphicsUnit.Pixel);
        }
    }

    // =====================================================================
    //  MODERN BUTTON
    // =====================================================================
    internal class ModernButton : Button
    {
        private bool hover;
        private bool down;
        private Font? fitFont;
        private string fitKey = "";

        public Color BaseColor { get; set; } = Theme.Orange;
        public Color HoverColor { get; set; } = Theme.OrangeHover;
        public Color TextColor { get; set; } = Color.White;
        public int Radius { get; set; } = 10;
        public bool Outline { get; set; }
        public Color BorderColor { get; set; } = Color.Empty;

        /// <summary>Colour behind the button. Leave empty (default) to pick it up from the parent automatically.</summary>
        public Color BackdropColor { get; set; } = Color.Empty;

        public ModernButton()
        {
            // The button paints EVERYTHING itself (solid backdrop first, then the rounded shape).
            // It is never transparent, so nothing can show through or be left behind when a page scrolls.
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            Font = Theme.MakeSemibold(10.5F);
            UseVisualStyleBackColor = false;
            base.BackColor = Theme.Bg;
        }

        // Older code sets BackColor = Transparent; the button no longer needs it, so ignore it safely.
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value.A < 255 ? Theme.Bg : value; }
        }

        /// <summary>Light-on-navy look used by buttons that sit on the gradient page headers (Back, Logout, Exit).</summary>
        public void UseHeaderStyle()
        {
            Outline = false;
            BaseColor = Color.FromArgb(34, 62, 118);
            HoverColor = Theme.Orange;
            TextColor = Color.White;
            BorderColor = Color.FromArgb(88, 116, 168);
            Radius = 12;
        }

        protected override void OnMouseEnter(EventArgs e) { hover = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { hover = false; down = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs mevent) { down = true; Invalidate(); base.OnMouseDown(mevent); }
        protected override void OnMouseUp(MouseEventArgs mevent) { down = false; Invalidate(); base.OnMouseUp(mevent); }
        protected override void OnParentChanged(EventArgs e) { base.OnParentChanged(e); Invalidate(); }
        protected override void OnEnabledChanged(EventArgs e) { base.OnEnabledChanged(e); Invalidate(); }
        protected override void OnPaintBackground(PaintEventArgs pevent) { /* painted in OnPaint */ }

        // ---- what is behind the button? -----------------------------------------------------
        private void PaintBackdrop(Graphics g)
        {
            Rectangle all = ClientRectangle;
            if (all.Width <= 0 || all.Height <= 0) return;

            if (BackdropColor != Color.Empty)
            {
                using (SolidBrush b = new SolidBrush(BackdropColor)) g.FillRectangle(b, all);
                return;
            }

            for (Control? c = Parent; c != null; c = c.Parent)
            {
                GradientPanel? gp = c as GradientPanel;
                if (gp != null)
                {
                    // blend into the header gradient exactly
                    Point origin = gp.PointToClient(PointToScreen(Point.Empty));
                    Color left = gp.ColorAtX(origin.X);
                    Color right = gp.ColorAtX(origin.X + Width);
                    using (LinearGradientBrush lb = new LinearGradientBrush(all, left, right, 0f))
                        g.FillRectangle(lb, all);
                    return;
                }

                Color solid = Color.Empty;
                CardPanel? card = c as CardPanel;
                SoftBox? soft = c as SoftBox;
                if (card != null) solid = card.FillColor;
                else if (soft != null && soft.FillColor.A == 255) solid = soft.FillColor;
                else if (c.BackColor.A == 255 && soft == null) solid = c.BackColor;

                if (solid != Color.Empty)
                {
                    using (SolidBrush b = new SolidBrush(solid)) g.FillRectangle(b, all);
                    return;
                }
            }

            using (SolidBrush fallback = new SolidBrush(Theme.Bg)) g.FillRectangle(fallback, all);
        }

        // ---- make sure the whole label is always readable ------------------------------------
        private Font FontThatFits(int available)
        {
            string key = Text + "|" + available + "|" + Font.SizeInPoints;
            if (fitFont != null && key == fitKey) return fitFont;

            Font current = Font;
            if (string.IsNullOrEmpty(Text) || TextRenderer.MeasureText(Text, current).Width <= available)
            {
                fitFont = null; fitKey = key;
                return current;
            }

            float size = current.SizeInPoints;
            Font? candidate = null;
            while (size > 7.5f)
            {
                size -= 0.5f;
                if (candidate != null) candidate.Dispose();
                candidate = new Font(current.FontFamily, size, current.Style, GraphicsUnit.Point);
                if (TextRenderer.MeasureText(Text, candidate).Width <= available) break;
            }
            if (fitFont != null) fitFont.Dispose();
            fitFont = candidate;
            fitKey = key;
            return candidate ?? current;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && fitFont != null) { fitFont.Dispose(); fitFont = null; }
            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            PaintBackdrop(g);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float scale = DeviceDpi / 96f;
            RectangleF r = new RectangleF(0.5f, 0.5f, Width - 2, Height - 2);
            float rad = Radius * scale;

            Color fill;
            Color textColor;
            Color border = Color.Empty;

            if (Outline)
            {
                fill = hover ? Color.FromArgb(Theme.OrangeSoft.R, Theme.OrangeSoft.G, Theme.OrangeSoft.B) : Color.White;
                if (hover && BaseColor != Theme.Orange)
                    fill = Color.FromArgb(240, 244, 250);
                textColor = Enabled ? BaseColor : Color.FromArgb(170, 180, 195);
                border = (hover && Enabled) ? BaseColor : Theme.Border;
                if (!Enabled) fill = Color.FromArgb(248, 250, 252);
            }
            else
            {
                fill = down ? ControlPaint.Dark(BaseColor, 0.08f) : (hover ? HoverColor : BaseColor);
                textColor = Enabled ? TextColor : Color.FromArgb(200, 205, 215);
            }

            if (!Enabled && !Outline)
                fill = Color.FromArgb(203, 213, 225);

            if (!Outline && BorderColor != Color.Empty && Enabled)
                border = BorderColor;

            using (GraphicsPath path = Theme.RoundRect(r, rad))
            {
                using (SolidBrush b = new SolidBrush(fill))
                    g.FillPath(b, path);
                if (border != Color.Empty)
                    using (Pen p = new Pen(border, 1.5f))
                        g.DrawPath(p, path);
            }

            int sidePad = (int)(10 * scale);
            Font f = FontThatFits(Math.Max(10, Width - 2 * sidePad));
            TextRenderer.DrawText(g, Text, f, ClientRectangle, textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding);
        }
    }

    // =====================================================================
    //  INPUT FRAME  - rounded border with orange focus ring; hosts one control
    // =====================================================================
    internal class InputFrame : Panel
    {
        private bool focused;
        public int Radius { get; set; } = 10;

        public InputFrame()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Color.Transparent;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (e.Control != null)
            {
                e.Control.Enter += (s, a) => { focused = true; Invalidate(); };
                e.Control.Leave += (s, a) => { focused = false; Invalidate(); };
                PositionChild();
            }
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            PositionChild();
        }

        private void PositionChild()
        {
            if (Controls.Count == 0) return;
            Control c = Controls[0];
            int pad = (int)(12 * DeviceDpi / 96f);

            if (c is TextBox tb && tb.Multiline)
            {
                c.SetBounds(pad, pad - 2, Math.Max(10, Width - 2 * pad), Math.Max(10, Height - 2 * pad + 2));
            }
            else
            {
                c.Width = Math.Max(10, Width - 2 * pad);
                c.Left = pad;
                c.Top = Math.Max(0, (Height - c.Height) / 2);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF r = new RectangleF(1, 1, Width - 3, Height - 3);
            using (GraphicsPath path = Theme.RoundRect(r, Radius * DeviceDpi / 96f))
            {
                using (SolidBrush b = new SolidBrush(Color.White))
                    g.FillPath(b, path);

                if (focused)
                {
                    using (Pen glow = new Pen(Color.FromArgb(60, Theme.Orange), 4f))
                        g.DrawPath(glow, path);
                }
                using (Pen p = new Pen(focused ? Theme.Orange : Color.FromArgb(203, 213, 225), focused ? 2f : 1.2f))
                    g.DrawPath(p, path);
            }
        }
    }

    // =====================================================================
    //  OPTION CARD  - radio button drawn as a selectable card
    // =====================================================================
    internal class OptionCard : RadioButton
    {
        private bool hover;
        public string Title { get; set; } = "";
        public string Subtitle { get; set; } = "";
        public Color Accent { get; set; } = Theme.Green;
        public Color AccentSoft { get; set; } = Theme.GreenSoft;

        public OptionCard()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            AutoSize = false;
            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
        }

        protected override void OnMouseEnter(EventArgs eventargs) { hover = true; Invalidate(); base.OnMouseEnter(eventargs); }
        protected override void OnMouseLeave(EventArgs eventargs) { hover = false; Invalidate(); base.OnMouseLeave(eventargs); }
        protected override void OnCheckedChanged(EventArgs e) { base.OnCheckedChanged(e); Invalidate(); }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float s = DeviceDpi / 96f;

            RectangleF r = new RectangleF(1.5f, 1.5f, Width - 4, Height - 4);
            using (GraphicsPath path = Theme.RoundRect(r, 12 * s))
            {
                Color fill = Checked ? AccentSoft : (hover ? Color.FromArgb(248, 250, 252) : Color.White);
                using (SolidBrush b = new SolidBrush(fill))
                    g.FillPath(b, path);
                using (Pen p = new Pen(Checked ? Accent : Theme.Border, Checked ? 2f : 1.2f))
                    g.DrawPath(p, path);
            }

            float d = 20 * s;
            RectangleF circle = new RectangleF(16 * s, (Height - d) / 2f, d, d);
            using (Pen cp = new Pen(Checked ? Accent : Color.FromArgb(148, 163, 184), 2f))
                g.DrawEllipse(cp, circle);
            if (Checked)
            {
                RectangleF inner = circle;
                inner.Inflate(-5 * s, -5 * s);
                using (SolidBrush ib = new SolidBrush(Accent))
                    g.FillEllipse(ib, inner);
            }

            int tx = (int)(48 * s);
            Rectangle titleRect = new Rectangle(tx, (int)(Height / 2f - 24 * s), Width - tx - (int)(8 * s), (int)(24 * s));
            Rectangle subRect = new Rectangle(tx, (int)(Height / 2f), Width - tx - (int)(8 * s), (int)(22 * s));
            TextRenderer.DrawText(g, Title, Theme.MakeSemibold(11F), titleRect, Checked ? Accent : Theme.Text,
                TextFormatFlags.Left | TextFormatFlags.Bottom | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
            TextRenderer.DrawText(g, Subtitle, Theme.MakeFont(9F), subRect, Theme.Muted,
                TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
        }
    }

    // =====================================================================
    //  METER BAR  - slim rounded progress bar
    // =====================================================================
    internal class MeterBar : Control
    {
        private int value;
        private Color barColor = Theme.Orange;

        public int Value { get { return value; } set { this.value = Math.Max(0, Math.Min(100, value)); Invalidate(); } }
        public Color BarColor { get { return barColor; } set { barColor = value; Invalidate(); } }

        public MeterBar()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Height = 10;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF track = new RectangleF(0, 0, Width - 1, Height - 1);
            float rad = track.Height / 2f;
            using (GraphicsPath tp = Theme.RoundRect(track, rad))
            using (SolidBrush tb = new SolidBrush(Color.FromArgb(226, 232, 240)))
                g.FillPath(tb, tp);

            float w = track.Width * value / 100f;
            if (w >= track.Height)
            {
                RectangleF fillRect = new RectangleF(0, 0, w, track.Height);
                using (GraphicsPath fp = Theme.RoundRect(fillRect, rad))
                using (SolidBrush fb = new SolidBrush(barColor))
                    g.FillPath(fb, fp);
            }
        }
    }

    // =====================================================================
    //  PILL LABEL  - coloured rounded tag
    // =====================================================================
    internal class PillLabel : Control
    {
        private string pillText = "";
        private Color back = Theme.BlueSoft;
        private Color fore = Theme.Blue;

        public string PillText { get { return pillText; } set { pillText = value; Invalidate(); } }
        public Color PillBack { get { return back; } set { back = value; Invalidate(); } }
        public Color PillFore { get { return fore; } set { fore = value; Invalidate(); } }

        public PillLabel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Font = Theme.MakeSemibold(9F);
            Height = 28;
            Width = 120;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF r = new RectangleF(0, 0, Width - 1, Height - 1);
            using (GraphicsPath p = Theme.RoundRect(r, r.Height / 2f))
            using (SolidBrush b = new SolidBrush(back))
                g.FillPath(b, p);
            Font draw = Font;
            Font? shrunk = null;
            int avail = Math.Max(10, Width - 12);
            float size = Font.SizeInPoints;
            while (size > 7f && TextRenderer.MeasureText(pillText, draw).Width > avail)
            {
                size -= 0.5f;
                if (shrunk != null) shrunk.Dispose();
                shrunk = new Font(Font.FontFamily, size, Font.Style, GraphicsUnit.Point);
                draw = shrunk;
            }
            TextRenderer.DrawText(g, pillText, draw, ClientRectangle, fore,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding);
            if (shrunk != null) shrunk.Dispose();
        }
    }

    // =====================================================================
    //  STEP TIMELINE  - request journey tracker
    // =====================================================================
    internal class StepTimeline : Control
    {
        private int current = -1;
        private bool cancelled;

        public string[] Steps { get; set; } = new string[]
        {
            "Requested", "Approved", "Provider Assigned", "Scheduled", "In Progress", "Completed"
        };

        public int Current { get { return current; } set { current = value; Invalidate(); } }
        public bool Cancelled { get { return cancelled; } set { cancelled = value; Invalidate(); } }

        public StepTimeline()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Color.Transparent;
            Height = 86;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float s = DeviceDpi / 96f;

            int n = Steps.Length;
            if (n < 2 || Width < 100) return;

            float margin = 70 * s;
            float usable = Width - 2 * margin;
            float cy = 24 * s;
            float rad = 14 * s;

            // connecting lines
            for (int i = 0; i < n - 1; i++)
            {
                float x1 = margin + usable * i / (n - 1);
                float x2 = margin + usable * (i + 1) / (n - 1);
                bool done = !cancelled && i < current;
                using (Pen p = new Pen(done ? Theme.Green : Theme.Border, 4f * s))
                    g.DrawLine(p, x1, cy, x2, cy);
            }

            for (int i = 0; i < n; i++)
            {
                float cx = margin + usable * i / (n - 1);
                RectangleF circle = new RectangleF(cx - rad, cy - rad, rad * 2, rad * 2);

                bool isDone = !cancelled && (i < current || (current == n - 1 && i == n - 1));
                bool isCurrent = !cancelled && i == current && current < n - 1;
                bool isCancelMark = cancelled && i == 0;

                if (isDone)
                {
                    using (SolidBrush b = new SolidBrush(Theme.Green))
                        g.FillEllipse(b, circle);
                    using (Pen cp = new Pen(Color.White, 2.6f * s))
                    {
                        cp.StartCap = LineCap.Round;
                        cp.EndCap = LineCap.Round;
                        cp.LineJoin = LineJoin.Round;
                        g.DrawLines(cp, new PointF[]
                        {
                            new PointF(cx - 5 * s, cy),
                            new PointF(cx - 1.5f * s, cy + 4 * s),
                            new PointF(cx + 5 * s, cy - 4 * s)
                        });
                    }
                }
                else if (isCurrent)
                {
                    RectangleF halo = circle;
                    halo.Inflate(7 * s, 7 * s);
                    using (SolidBrush hb = new SolidBrush(Color.FromArgb(55, Theme.Orange)))
                        g.FillEllipse(hb, halo);
                    using (SolidBrush b = new SolidBrush(Theme.Orange))
                        g.FillEllipse(b, circle);
                    RectangleF dot = circle;
                    dot.Inflate(-8 * s, -8 * s);
                    using (SolidBrush wb = new SolidBrush(Color.White))
                        g.FillEllipse(wb, dot);
                }
                else if (isCancelMark)
                {
                    using (SolidBrush b = new SolidBrush(Theme.Red))
                        g.FillEllipse(b, circle);
                    using (Pen xp = new Pen(Color.White, 2.6f * s))
                    {
                        xp.StartCap = LineCap.Round;
                        xp.EndCap = LineCap.Round;
                        g.DrawLine(xp, cx - 4.5f * s, cy - 4.5f * s, cx + 4.5f * s, cy + 4.5f * s);
                        g.DrawLine(xp, cx + 4.5f * s, cy - 4.5f * s, cx - 4.5f * s, cy + 4.5f * s);
                    }
                }
                else
                {
                    using (SolidBrush b = new SolidBrush(Color.White))
                        g.FillEllipse(b, circle);
                    using (Pen p = new Pen(Color.FromArgb(203, 213, 225), 2.5f * s))
                        g.DrawEllipse(p, circle);
                }

                float labelW = usable / (n - 1);
                Rectangle labelRect = new Rectangle((int)(cx - labelW / 2f), (int)(cy + rad + 10 * s), (int)labelW, (int)(34 * s));
                Color lc = isCurrent ? Theme.Navy : (isDone ? Theme.Text : Theme.Muted);
                Font lf = isCurrent ? Theme.MakeSemibold(9.5F) : Theme.MakeFont(9F);
                TextRenderer.DrawText(g, Steps[i], lf, labelRect, lc,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.Top | TextFormatFlags.WordBreak | TextFormatFlags.NoPadding);
            }
        }
    }

    // =====================================================================
    //  FIELD BLOCK  - small caption + value pair
    // =====================================================================
    internal class FieldBlock : Panel
    {
        private readonly Label caption;
        private readonly Label value;

        public string Caption { get { return caption.Text; } set { caption.Text = value; } }
        private static readonly ToolTip tip = new ToolTip();

        public string Value
        {
            get { return this.value.Text; }
            set
            {
                this.value.Text = value;
                tip.SetToolTip(this.value, value);   // full text on hover if it is ever shortened
            }
        }
        public Color ValueColor { get { return this.value.ForeColor; } set { this.value.ForeColor = value; } }

        public FieldBlock(string captionText)
        {
            BackColor = Color.Transparent;

            caption = Theme.MakeLabel(captionText.ToUpperInvariant(), 8F, FontStyle.Bold, Theme.Muted);
            caption.Location = new Point(0, 0);

            value = Theme.MakeLabel("-", 11F, FontStyle.Bold, Theme.Text);
            value.AutoSize = false;
            value.AutoEllipsis = true;
            value.Location = new Point(0, 22);
            value.Height = 34;
            value.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            Controls.Add(caption);
            Controls.Add(value);

            Height = 62;
            value.AutoEllipsis = false;
            // if a long value has to wrap onto a second line, make the block taller so nothing is clipped
            value.SizeChanged += delegate { if (Height < value.Bottom + 6) Height = value.Bottom + 6; };
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            if (value != null)
                value.Width = Math.Max(10, Width - 6);
        }
    }

    // =====================================================================
    //  SMART ASSISTANT  - on-device "AI" that reads the problem description
    // =====================================================================
    internal class AiSuggestion
    {
        public string? Category { get; set; }
        public bool Urgent { get; set; }
        public int Confidence { get; set; }
        public string Headline { get; set; } = "";
        public string Tip { get; set; } = "";
        public int QualityScore { get; set; }
        public string QualityLabel { get; set; } = "";
        public string QualityHint { get; set; } = "";
    }

    internal static class SmartAssistant
    {
        private static readonly Dictionary<string, string[]> CategoryKeywords = new Dictionary<string, string[]>
        {
            { "Plumbing", new[] { "leak", "pipe", "tap", "geyser", "drain", "toilet", "blocked", "burst", "water", "sink", "shower", "basin", "flush", "drip", "gutter overflow", "damp" } },
            { "Electrical", new[] { "power", "light", "plug", "socket", "wiring", "wire", "switch", "trip", "breaker", "db board", "electric", "spark", "bulb", "outlet", "short circuit", "load shedding", "inverter" } },
            { "Painting", new[] { "paint", "wall", "ceiling", "peeling", "repaint", "colour", "color", "stain", "plaster", "cracked wall", "primer" } },
            { "Appliance Repair", new[] { "fridge", "washing machine", "dishwasher", "oven", "stove", "microwave", "dryer", "freezer", "kettle", "aircon", "air con", "appliance", "tumble", "geezer" } },
            { "General Maintenance", new[] { "door", "window", "lock", "hinge", "fence", "gutter", "roof", "tile", "floor", "cupboard", "handle", "gate", "broken", "shelf", "carpentry" } }
        };

        private static readonly string[] UrgentKeywords = new[]
        {
            "burst", "flood", "flooding", "spark", "sparking", "smoke", "gas", "shock", "fire",
            "emergency", "urgent", "asap", "no power", "everywhere", "overflowing", "not working at all"
        };

        public static AiSuggestion Analyse(string text)
        {
            AiSuggestion result = new AiSuggestion();
            string t = (text ?? "").Trim().ToLowerInvariant();

            // ---- description quality ----
            int len = t.Length;
            int words = t.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            int quality = Math.Min(100, (int)(len * 100.0 / 140.0));
            if (words < 4) quality = Math.Min(quality, 30);
            result.QualityScore = quality;

            if (len == 0) { result.QualityLabel = "Waiting for details"; result.QualityHint = "Tell us what happened, where it is and since when."; }
            else if (quality < 35) { result.QualityLabel = "Too brief"; result.QualityHint = "Add where the problem is and how long it has been happening."; }
            else if (quality < 65) { result.QualityLabel = "Getting there"; result.QualityHint = "Mention anything you have already tried."; }
            else if (quality < 90) { result.QualityLabel = "Good detail"; result.QualityHint = "Your provider will arrive better prepared."; }
            else { result.QualityLabel = "Excellent detail"; result.QualityHint = "Perfect - this gives the provider everything needed."; }

            if (len < 12)
            {
                result.Headline = "Start typing and I will analyse your problem.";
                return result;
            }

            // ---- category detection ----
            string? best = null;
            int bestHits = 0;
            foreach (KeyValuePair<string, string[]> kv in CategoryKeywords)
            {
                int hits = kv.Value.Count(k => t.Contains(k));
                if (hits > bestHits) { bestHits = hits; best = kv.Key; }
            }

            result.Urgent = UrgentKeywords.Any(k => t.Contains(k));

            if (best == null)
            {
                result.Headline = "I could not place this yet - try adding what is broken (e.g. tap, socket, fridge).";
                return result;
            }

            result.Category = best;
            result.Confidence = Math.Min(97, 55 + 14 * bestHits);

            switch (best)
            {
                case "Plumbing":
                    result.Headline = "This looks like a plumbing issue.";
                    result.Tip = "If water is escaping, switch it off at the main valve and clear the area around the leak.";
                    break;
                case "Electrical":
                    result.Headline = "This looks like an electrical issue.";
                    result.Tip = "Do not touch exposed wiring. If it is safe, switch off the affected circuit at the DB board.";
                    break;
                case "Painting":
                    result.Headline = "This looks like a painting job.";
                    result.Tip = "Move furniture away from the walls and note any damp patches - they should be treated before painting.";
                    break;
                case "Appliance Repair":
                    result.Headline = "This looks like an appliance repair.";
                    result.Tip = "Unplug the appliance and photograph its model label - it speeds up the repair.";
                    break;
                default:
                    result.Headline = "This looks like general maintenance.";
                    result.Tip = "Take a clear photo of the damaged area and measure it if you can.";
                    break;
            }

            if (result.Urgent)
                result.Tip = "This sounds time-critical - Urgent priority is recommended. " + result.Tip;

            return result;
        }
    }
}

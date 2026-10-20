using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Home_Hero
{
    // =====================================================================
    //  SOFT NOTE - rounded tinted box with an optional coloured edge
    // =====================================================================
    internal class SoftNote : Panel
    {
        public Color FillColor { get; set; } = Color.FromArgb(250, 247, 255);
        public Color EdgeColor { get; set; } = Theme.Border;
        public Color AccentColor { get; set; } = Color.Empty;
        public int Radius { get; set; } = 10;

        public SoftNote()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Width < 8 || Height < 8) return;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float s = DeviceDpi / 96f;
            RectangleF r = new RectangleF(0.5F, 0.5F, Width - 2, Height - 2);
            using (GraphicsPath path = Theme.RoundRect(r, Radius * s))
            {
                using (SolidBrush fill = new SolidBrush(FillColor)) g.FillPath(fill, path);
                if (AccentColor != Color.Empty)
                {
                    GraphicsState st = g.Save();
                    g.SetClip(path, CombineMode.Intersect);
                    using (SolidBrush ab = new SolidBrush(AccentColor))
                        g.FillRectangle(ab, r.X, r.Y, 5 * s, r.Height);
                    g.Restore(st);
                }
                using (Pen p = new Pen(EdgeColor, 1f)) g.DrawPath(p, path);
            }
        }
    }

    // =====================================================================
    //  SOFT GROUP BOX - group box with a rounded light border and a tidy caption
    // =====================================================================
    internal class SoftGroupBox : GroupBox
    {
        public SoftGroupBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Width < 8 || Height < 8) return;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float s = DeviceDpi / 96f;

            Size text = TextRenderer.MeasureText(g, Text, Font, new Size(int.MaxValue / 4, 100),
                TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
            int top = text.Height / 2;

            RectangleF r = new RectangleF(0.5F, top, Width - 2, Height - top - 2);
            using (GraphicsPath path = Theme.RoundRect(r, 10 * s))
            {
                using (SolidBrush fill = new SolidBrush(Color.FromArgb(250, 251, 253))) g.FillPath(fill, path);
                using (Pen p = new Pen(Theme.Border, 1f)) g.DrawPath(p, path);
            }

            // caption sits on a white tab over the border line
            int cx = (int)(16 * s);
            Rectangle tab = new Rectangle(cx - (int)(6 * s), 0, text.Width + (int)(12 * s), text.Height);
            using (SolidBrush white = new SolidBrush(Color.White)) g.FillRectangle(white, tab);
            TextRenderer.DrawText(g, Text, Font, new Point(cx, 0), Theme.Navy,
                TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
        }
    }

    // =====================================================================
    //  REQUEST A SERVICE - modern look
    // =====================================================================
    public partial class frmRequestAService
    {
        private void ApplyModernStyle()
        {
            SuspendLayout();
            Text = "Request a Service";

            // numbered step badges -> crisp orange circles
            foreach (Label badge in new[] { lblServicenumber1, label6, label9, label15 })
                ReplaceBadge(badge);

            // header labels sit on the painted gradient
            foreach (Control c in pnlServiceRequest.Controls)
                if (c is Label) c.BackColor = Color.Transparent;

            // the four sections become soft rounded cards
            foreach (CardPanel card in new[] { panel1, panel2, panel3, panel4 })
            {
                card.BackColor = BackColor;
                card.Radius = 14;
                MakeTransparent(card);
            }

            // priority choice -> two selectable option cards
            StyleChoice(RdbxNormalPriorityLevel, new Point(32, 222), Theme.Green);
            StyleChoice(RdbtnUrgent, new Point(448, 222), Theme.Red);

            // inputs: clean single-pixel border on a very light fill
            foreach (Control host in new Control[] { panel1, panel2, panel3, gbxPropertyAddress, gxContactDetails })
                StyleInputs(host);

            // note under the date / time pickers
            SoftNote note = (SoftNote)pnlNote;
            note.FillColor = Color.FromArgb(240, 246, 255);
            note.EdgeColor = Color.FromArgb(207, 224, 250);
            note.AccentColor = Theme.Blue;
            lblMessage.Left = 26;

            txtProblemDEscription.TextChanged += delegate { UpdateDescriptionHelper(); };

            ResumeLayout(true);
        }

        private void ReplaceBadge(Label l)
        {
            if (l.Parent == null) return;
            BadgeCircle b = new BadgeCircle();
            b.Initials = l.Text;
            b.Fill = Theme.Orange;
            b.FontSize = 12F;
            b.Bounds = l.Bounds;
            Control parent = l.Parent;
            parent.Controls.Add(b);
            b.BringToFront();
            l.Visible = false;
        }

        private void MakeTransparent(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Label || c is RadioButton || c is GroupBox || c is CheckBox || c is SoftNote)
                    c.BackColor = Color.Transparent;
                if (c.HasChildren) MakeTransparent(c);
            }
        }

        private void StyleChoice(RadioButton rb, Point where, Color accent)
        {
            rb.Appearance = Appearance.Button;
            rb.FlatStyle = FlatStyle.Flat;
            rb.AutoSize = false;
            rb.Size = new Size(395, 64);
            rb.Location = where;
            rb.TextAlign = ContentAlignment.MiddleLeft;
            rb.Padding = new Padding(14, 0, 0, 0);
            rb.UseVisualStyleBackColor = false;
            rb.BackColor = Color.White;
            rb.ForeColor = Theme.Navy;
            rb.FlatAppearance.BorderSize = 2;
            rb.FlatAppearance.BorderColor = Theme.Border;
            rb.FlatAppearance.CheckedBackColor = Color.FromArgb(255, 247, 242);
            rb.FlatAppearance.MouseOverBackColor = Color.FromArgb(248, 250, 252);
            rb.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 241, 235);
            rb.CheckedChanged += delegate
            {
                rb.FlatAppearance.BorderColor = rb.Checked ? accent : Theme.Border;
            };
        }

        private void StyleInputs(Control host)
        {
            foreach (Control c in host.Controls)
            {
                TextBox? tb = c as TextBox;
                if (tb != null)
                {
                    tb.BorderStyle = BorderStyle.FixedSingle;
                    tb.BackColor = Color.FromArgb(252, 253, 254);
                    tb.ForeColor = Theme.Text;
                }
                else if (c is ComboBox || c is DateTimePicker)
                {
                    c.BackColor = Color.FromArgb(252, 253, 254);
                }
                if (c.HasChildren) StyleInputs(c);
            }
        }

        private void UpdateDescriptionHelper()
        {
            int n = txtProblemDEscription.Text.Length;

            if (n < 20)
            {
                lblMinimumCharacters.Text = n + " / 20 characters minimum  -  " + (20 - n) + " more needed";
                lblMinimumCharacters.ForeColor = Theme.Amber;
            }
            else
            {
                lblMinimumCharacters.Text = n + " characters  \u2713";
                lblMinimumCharacters.ForeColor = Theme.Green;
            }
        }
    }
}

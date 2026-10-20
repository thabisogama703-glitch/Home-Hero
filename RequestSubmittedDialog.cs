using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Home_Hero
{
    /// <summary>
    /// Friendly confirmation shown after a request is submitted.
    /// DialogResult.Yes = create another request, DialogResult.No = back to dashboard.
    /// </summary>
    internal class RequestSubmittedDialog : FitForm
    {
        public RequestSubmittedDialog(string requestNumber, string category, DateTime date, string timeSlot, decimal estimatedCost, string status)
        {
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(540, 560);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Request Submitted";
            BackColor = Color.White;
            DoubleBuffered = true;

            Label title = Theme.MakeLabel("Request submitted!", 20F, FontStyle.Bold, Theme.Navy);
            title.AutoSize = false;
            title.TextAlign = ContentAlignment.MiddleCenter;
            title.SetBounds(0, 150, 540, 42);

            Label sub = Theme.MakeLabel("Your maintenance request is in. We will take it from here.", 10F, FontStyle.Regular, Theme.Muted);
            sub.AutoSize = false;
            sub.TextAlign = ContentAlignment.MiddleCenter;
            sub.SetBounds(0, 192, 540, 26);

            PillLabel number = new PillLabel();
            number.PillText = requestNumber;
            number.PillBack = Theme.OrangeSoft;
            number.PillFore = Color.FromArgb(194, 65, 12);
            number.Font = Theme.MakeSemibold(10F);
            number.Size = new Size(300, 34);
            number.Location = new Point(120, 226);

            AddRow("SERVICE", category, 276);
            AddRow("APPOINTMENT", date.ToString("dd MMMM yyyy") + "  |  " + timeSlot, 322);
            AddRow("ESTIMATED COST", "R" + estimatedCost.ToString("F2"), 368);
            AddRow("STATUS", status, 414);

            ModernButton another = new ModernButton();
            another.Text = "Create another";
            another.Outline = true;
            another.BaseColor = Theme.Navy;
            another.HoverColor = Theme.NavyLight;
            another.Size = new Size(220, 48);
            another.Location = new Point(40, 490);
            another.Click += (s, e) => { DialogResult = DialogResult.Yes; Close(); };

            ModernButton dash = new ModernButton();
            dash.Text = "Back to dashboard";
            dash.Size = new Size(220, 48);
            dash.Location = new Point(280, 490);
            dash.Click += (s, e) => { DialogResult = DialogResult.No; Close(); };

            Controls.Add(title);
            Controls.Add(sub);
            Controls.Add(number);
            Controls.Add(another);
            Controls.Add(dash);

            AcceptButton = dash;
            CancelButton = dash;
        }

        private void AddRow(string caption, string value, int top)
        {
            Label c = Theme.MakeLabel(caption, 8.5F, FontStyle.Bold, Theme.Muted);
            c.Location = new Point(60, top + 6);

            Label v = Theme.MakeLabel(value, 10.5F, FontStyle.Bold, Theme.Text);
            v.AutoSize = false;
            v.TextAlign = ContentAlignment.MiddleRight;
            v.SetBounds(210, top, 270, 28);

            Controls.Add(c);
            Controls.Add(v);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float s = DeviceDpi / 96f;

            // navy banner
            Rectangle banner = new Rectangle(0, 0, ClientSize.Width, (int)(100 * s));
            using (LinearGradientBrush br = new LinearGradientBrush(banner, Theme.NavyDeep, Theme.NavyLight, 0f))
                g.FillRectangle(br, banner);
            using (SolidBrush accent = new SolidBrush(Theme.Orange))
                g.FillRectangle(accent, 0, banner.Bottom - (int)(4 * s), ClientSize.Width, (int)(4 * s));

            // green check badge overlapping the banner
            float d = 68 * s;
            RectangleF circle = new RectangleF((ClientSize.Width - d) / 2f, 46 * s, d, d);
            using (SolidBrush ring = new SolidBrush(Color.White))
            {
                RectangleF outer = circle;
                outer.Inflate(6 * s, 6 * s);
                g.FillEllipse(ring, outer);
            }
            using (SolidBrush fill = new SolidBrush(Theme.Green))
                g.FillEllipse(fill, circle);

            float cx = circle.X + d / 2f;
            float cy = circle.Y + d / 2f;
            using (Pen p = new Pen(Color.White, 5f * s))
            {
                p.StartCap = LineCap.Round;
                p.EndCap = LineCap.Round;
                p.LineJoin = LineJoin.Round;
                g.DrawLines(p, new PointF[]
                {
                    new PointF(cx - 13 * s, cy + 1 * s),
                    new PointF(cx - 3 * s, cy + 11 * s),
                    new PointF(cx + 14 * s, cy - 10 * s)
                });
            }

            // divider above buttons
            using (Pen line = new Pen(Theme.Border, 1f))
                g.DrawLine(line, 40 * s, 464 * s, ClientSize.Width - 40 * s, 464 * s);
        }
    }
}

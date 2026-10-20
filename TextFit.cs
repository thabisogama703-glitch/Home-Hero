using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Home_Hero
{
    // =====================================================================
    //  TEXT FIT
    //  Makes sure every sentence on screen is readable in full. Labels that
    //  are too small for their text first shrink the font a little (for
    //  one-line labels) and otherwise wrap onto extra lines / grow, instead
    //  of cutting the sentence off with "..." or at the edge of a card.
    //  Runs once a window is shown and again whenever a label's text or its
    //  container's size changes.
    // =====================================================================
    internal static class TextFit
    {
        private static readonly ConditionalWeakTable<Control, object> hooked = new ConditionalWeakTable<Control, object>();
        private static readonly ConditionalWeakTable<Label, Font> originalFonts = new ConditionalWeakTable<Label, Font>();
        private static readonly Dictionary<string, Font> fontCache = new Dictionary<string, Font>();
        private static readonly HashSet<Label> fitting = new HashSet<Label>();

        private const TextFormatFlags WrapFlags = TextFormatFlags.WordBreak | TextFormatFlags.NoPrefix | TextFormatFlags.NoPadding;
        private const TextFormatFlags LineFlags = TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix | TextFormatFlags.NoPadding;

        /// <summary>Start watching a window (and everything added to it later) and fit what is there now.</summary>
        public static void Attach(Control root)
        {
            Watch(root);
            FitTree(root);
        }

        private static void Watch(Control c)
        {
            if (hooked.TryGetValue(c, out _)) return;
            hooked.Add(c, new object());

            c.ControlAdded += delegate (object? s, ControlEventArgs e)
            {
                if (e.Control == null) return;
                Watch(e.Control);
                FitTree(e.Control);
            };

            Label? label = c as Label;
            if (label != null)
            {
                label.TextChanged += delegate { Fit(label); };
            }
            else
            {
                // when a container changes size its labels may need more / less room
                c.SizeChanged += delegate { FitChildren(c); };
            }

            foreach (Control child in c.Controls) Watch(child);
        }

        public static void FitTree(Control root)
        {
            Label? label = root as Label;
            if (label != null) Fit(label);
            foreach (Control child in root.Controls) FitTree(child);
        }

        private static void FitChildren(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                Label? label = child as Label;
                if (label != null) Fit(label);
            }
        }

        private static Font Sized(Font basis, float size)
        {
            string key = basis.FontFamily.Name + "|" + size.ToString("0.0") + "|" + (int)basis.Style;
            Font? f;
            if (!fontCache.TryGetValue(key, out f))
            {
                f = new Font(basis.FontFamily, size, basis.Style, GraphicsUnit.Point);
                fontCache[key] = f;
            }
            return f;
        }

        private static void Fit(Label lb)
        {
            if (lb.IsDisposed || lb.Parent == null || string.IsNullOrEmpty(lb.Text)) return;
            if (!fitting.Add(lb)) return;
            try
            {
                Font original = originalFonts.GetValue(lb, l => l.Font);
                if (lb.AutoSize) FitAutoSize(lb, original);
                else FitFixed(lb, original);
            }
            finally
            {
                fitting.Remove(lb);
            }
        }

        // ---- labels that size themselves: just keep them inside their parent --------------
        private static void FitAutoSize(Label lb, Font original)
        {
            Control parent = lb.Parent!;
            if (parent is TableLayoutPanel || parent is FlowLayoutPanel) return;   // those lay themselves out

            float scale = lb.DeviceDpi / 96f;
            int available = parent.ClientSize.Width - lb.Left - Math.Max(parent.Padding.Right, (int)(14 * scale));
            if (available < (int)(120 * scale)) return;                              // parent not laid out yet

            Size natural = TextRenderer.MeasureText(lb.Text, lb.Font, new Size(int.MaxValue / 4, int.MaxValue / 4), LineFlags & ~TextFormatFlags.SingleLine);
            Size wanted = natural.Width > available ? new Size(available, 0) : Size.Empty;
            if (lb.MaximumSize != wanted) lb.MaximumSize = wanted;
        }

        // ---- labels with a fixed size: shrink a little, then wrap and grow ----------------
        private static void FitFixed(Label lb, Font original)
        {
            if (lb.AutoEllipsis) lb.AutoEllipsis = false;

            int width = lb.ClientSize.Width - lb.Padding.Horizontal;
            if (width < 20) return;

            float scale = lb.DeviceDpi / 96f;
            int oneLine = TextRenderer.MeasureText("Ag", original, new Size(1000, 1000), LineFlags).Height;
            bool designedOneLine = lb.Height <= oneLine * 1.8 + lb.Padding.Vertical;

            float minSize = Math.Max(8f, original.SizeInPoints * 0.72f);
            Font use = original;
            float size = original.SizeInPoints;

            if (designedOneLine && lb.Dock != DockStyle.Fill)
            {
                while (TextRenderer.MeasureText(lb.Text, use, new Size(int.MaxValue / 4, 1000), LineFlags).Width > width && size - 0.5f >= minSize)
                {
                    size -= 0.5f;
                    use = Sized(original, size);
                }
            }
            else if (lb.Dock == DockStyle.Fill)
            {
                // cannot grow - shrink until the whole text fits the space it has
                int height = lb.ClientSize.Height - lb.Padding.Vertical;
                while (TextRenderer.MeasureText(lb.Text, use, new Size(width, 0), WrapFlags).Height > height && size - 0.5f >= 8f)
                {
                    size -= 0.5f;
                    use = Sized(original, size);
                }
            }

            if (!ReferenceEquals(lb.Font, use)) lb.Font = use;

            // still too much text for the box: let it wrap onto more lines
            if (lb.Dock == DockStyle.None || lb.Dock == DockStyle.Top || lb.Dock == DockStyle.Bottom)
            {
                int need = TextRenderer.MeasureText(lb.Text, lb.Font, new Size(width, 0), WrapFlags).Height + lb.Padding.Vertical + (int)(2 * scale);
                if (need > lb.Height) lb.Height = need;
            }
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Home_Hero
{
    /// <summary>
    /// Base class for every HomeHero window.  It makes sure a window can never be bigger
    /// than the screen it opens on, and that content which does not fit is reachable with
    /// scroll bars instead of being cut off.  This is what lets the same build work on a
    /// 1366x768 laptop, a 1920x1080 desktop and any Windows display-scaling setting.
    /// </summary>
    public class FitForm : Form
    {
        /// <summary>
        /// When true (default) the whole window scrolls if it is smaller than the layout it was
        /// designed for.  Pages that already scroll their own body under a fixed header set this
        /// to false in their constructor so the header stays put.
        /// </summary>
        protected bool ScrollWholeForm { get; set; } = true;

        private static System.Windows.Forms.Timer? exitTimer;

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (DesignMode)
                return;

            // The app ends when the last visible window is gone (hidden leftovers must not keep it running),
            // but not while a screen is merely switching to the next one.
            exitTimer?.Stop();
            exitTimer?.Dispose();
            exitTimer = new System.Windows.Forms.Timer { Interval = 500 };
            exitTimer.Tick += (s, args) =>
            {
                exitTimer?.Stop();
                if (!Application.OpenForms.Cast<Form>().Any(f => f.Visible))
                    Application.ExitThread();
            };
            exitTimer.Start();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (DesignMode) return;

            // every sentence must be readable in full - shrink / wrap any label that is too small for its text
            try { TextFit.Attach(this); }
            catch { /* a safety net only - must never stop a window from opening */ }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode)
                return;

            try
            {
                FitToScreen();
            }
            catch
            {
                // Fitting is a safety net only - it must never stop a window from opening.
            }
        }

        private void FitToScreen()
        {
            Rectangle area = Screen.FromControl(this).WorkingArea;

            // The window is allowed to be smaller than its designed minimum size on small screens
            // (the scroll bars take over), otherwise Windows would push it off the screen.
            Size min = MinimumSize;
            if (min.Width > area.Width || min.Height > area.Height)
                MinimumSize = new Size(Math.Min(min.Width, area.Width), Math.Min(min.Height, area.Height));

            // Size of the layout this window was designed for (already scaled for this PC's display settings).
            Size frame = new Size(Math.Max(0, Width - ClientSize.Width), Math.Max(0, Height - ClientSize.Height));
            Size designClient = ClientSize;
            if (WindowState != FormWindowState.Normal)
            {
                Rectangle restore = RestoreBounds;
                designClient = new Size(Math.Max(0, restore.Width - frame.Width), Math.Max(0, restore.Height - frame.Height));
            }

            // Windows that open at a normal size: never larger than the screen, always fully visible.
            if (WindowState == FormWindowState.Normal)
            {
                int w = Math.Min(Width, area.Width);
                int h = Math.Min(Height, area.Height);
                if (w != Width || h != Height)
                    Size = new Size(w, h);

                int x = Math.Max(area.Left, Math.Min(Left, area.Right - Width));
                int y = Math.Max(area.Top, Math.Min(Top, area.Bottom - Height));
                if (x != Left || y != Top)
                    Location = new Point(x, y);
            }

            // Whole-window scrolling is only switched on when the screen is clearly too small for the
            // layout (e.g. a 1366x768 laptop). On normal screens nothing changes, so layouts are never shifted.
            if (ScrollWholeForm && designClient.Width > 0 && designClient.Height > 0 &&
                (area.Width < designClient.Width * 0.75 || area.Height < designClient.Height * 0.70))
            {
                AutoScroll = true;
                AutoScrollMinSize = new Size((int)(designClient.Width * 0.75), (int)(designClient.Height * 0.70));
            }
        }
    }
}

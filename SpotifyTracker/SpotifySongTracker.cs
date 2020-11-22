using SpotifySongTracker.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SpotifySongTracker
{
    static class SpotifySongTracker
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SpotifyTrackerApplicationContext());
        }
    }


    public class SpotifyTrackerApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon TrayIcon;
        private readonly SpotifyTrackDisplayer TrackDisplayer;
        private readonly Thread TrackThread;
        private bool ContinueLoop = true;

        public SpotifyTrackerApplicationContext()
        {
            // Initialize Tray Icon
            TrayIcon = new NotifyIcon()
            {
                Icon = Resources.ScuffedSpotify,
                Text = "No Song",
                ContextMenu = new ContextMenu(new MenuItem[] {
                    new MenuItem("Reset Defaults", ResetDefaults),
                    new MenuItem("Force Update", ForceUpdate),
                    new MenuItem("Settings", OpenSettingsForm),
                    new MenuItem("Exit", Exit)
                }),
                Visible = true
            };

            //Initialize the track writer
            TrackDisplayer = new SpotifyTrackDisplayer();
            TrackThread = new Thread(new ThreadStart(LoopContinuously));
            TrackThread.Start();
        }

        private void OpenSettingsForm(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            if (sf.ShowDialog() != DialogResult.Cancel)
            {
                TrayIcon.Text = TrackDisplayer.CurrentSong;
                TrackDisplayer.SetWriter(sf.SongWriter);
                TrackDisplayer.UpdateTrack(true);
            }
        }

        private void MakeBackgroundTransparent(object sender, EventArgs e)
        {
            Properties.Settings.Default.TextBackground = Color.Transparent;
            Properties.Settings.Default.Save();
            TrackDisplayer.UpdateTrack(true);
        }

        private void ResetDefaults(object sender, EventArgs e)
        {
            Properties.Settings.Default.Font = new Font("Arial", 12);
            Properties.Settings.Default.TextColor = Color.White;
            Properties.Settings.Default.TextBackground = Color.Transparent;
            Properties.Settings.Default.TextOutline = Color.Black;
            Properties.Settings.Default.MaxSize = 256;
            Properties.Settings.Default.Save();
            TrackDisplayer.UpdateTrack(true);
        }

        private void SetFont(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog
            {
                ShowColor = true,
                ShowEffects = true,
                Font = Properties.Settings.Default.Font,
                Color = Properties.Settings.Default.TextColor
            };

            bool hasChanged = false;
            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                hasChanged = !(Properties.Settings.Default.Font.Equals(fontDialog.Font) && Properties.Settings.Default.TextColor.Equals(fontDialog.Color));
                Properties.Settings.Default.Font = fontDialog.Font;
                Properties.Settings.Default.TextColor = fontDialog.Color;
            }

            if (hasChanged)
            {
                Properties.Settings.Default.Save();
                TrackDisplayer.UpdateTrack(true);
            }
        }

        private void LoopContinuously()
        {
            while (ContinueLoop)
            {
                try
                {
                    TrackDisplayer.UpdateTrack();

                    TrayIcon.Text = TrackDisplayer.CurrentSong.Length > 63
                        ? $"{new String(TrackDisplayer.CurrentSong.Take(60).ToArray())}..."
                        : TrackDisplayer.CurrentSong;

                    Thread.Sleep(5000);
                }
                catch (ThreadAbortException)
                {
                    return;
                }
            }
        }

        private void Stop()
        {
            ContinueLoop = false;
            Thread.Sleep(1);
            if (TrackThread.IsAlive)
            {
                TrackThread.Abort();
            }
        }

        private void Exit(object sender, EventArgs evt)
        {
            Stop();
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            TrayIcon.Visible = false;

            Application.Exit();
        }

        private void ForceUpdate(object sender, EventArgs evt)
        {
            TrackDisplayer.UpdateTrack(true);
            TrayIcon.Text = TrackDisplayer.CurrentSong;
        }

        private void SetOutlineColor(object sender, EventArgs evt)
        {
            ColorDialog cd = new ColorDialog
            {
                Color = Properties.Settings.Default.TextOutline,
                AllowFullOpen = true,
                AnyColor = true,
            };

            bool hasChanged = false;
            if (cd.ShowDialog() != DialogResult.Cancel)
            {
                hasChanged = !Properties.Settings.Default.TextOutline.Equals(cd.Color);
                Properties.Settings.Default.TextOutline = cd.Color;
            }

            if (hasChanged)
            {
                Properties.Settings.Default.Save();
                TrackDisplayer.UpdateTrack(true);
            }
        }

        private void SetBackgroundColor(object sender, EventArgs evt)
        {
            ColorDialog cd = new ColorDialog
            {
                Color = Properties.Settings.Default.TextOutline,
                AllowFullOpen = true,
                AnyColor = true,
            };

            bool hasChanged = false;
            if (cd.ShowDialog() != DialogResult.Cancel)
            {
                hasChanged = !Properties.Settings.Default.TextBackground.Equals(cd.Color);
                Properties.Settings.Default.TextBackground = cd.Color;
            }

            if (hasChanged)
            {
                Properties.Settings.Default.Save();
                TrackDisplayer.UpdateTrack(true);
            }
        }
    }
}

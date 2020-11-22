using SpotifySongTracker.Properties;
using SpotifySongTracker.Writers;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SpotifySongTracker
{
    class SpotifyTrackDisplayer
    {

        private static readonly string[] PausedSong = new string[] { "Spotify", "Spotify Premium" };

        private static readonly Object WriterLock = new Object();
        private static ISongWriter Writer { get; set; }

        private readonly StreamWriter logFile;

        private DateTime NoSongAt { get; set; }

        public string CurrentSong { get; private set; }

        public bool IsPaused { get; private set; } = false;

        public SpotifyTrackDisplayer()
        {
            switch (Properties.Settings.Default.OutputType) 
            {
                case "TXT":
                    Writer = new TextSongWriter();
                    break;
                case "PNG":
                    Writer = new PngSongWriter();
                    break;
                case "GIF":
                    Writer = new GifSongWriter();
                    break;
                default:
                    throw new NotImplementedException();
            }

            logFile = new StreamWriter(@"log.txt", true);
            logFile.WriteLine("Start SpotifyTrackDisplayer at " + DateTime.Now);
            logFile.Flush();
        }

        public SpotifyTrackDisplayer(ISongWriter writer)
        {
            Writer = writer;

            logFile = new StreamWriter(@"log.txt", true);
            logFile.WriteLine("Start SpotifyTrackDisplayer at " + DateTime.Now);
            logFile.Flush();
        }

        public void SetWriter(ISongWriter writer)
        {
            lock (WriterLock)
            {
                Writer.Close();
                Writer = writer;
            }
        }

        public void UpdateTrack(bool forceUpdate = false)
        {
            lock (WriterLock)
            {
                try
                {
                    Directory.CreateDirectory("out");
                    if (GetSpotifyTrackInfo() || forceUpdate)
                    {
                        // re-generate the output
                        Writer.Write(this.CurrentSong);
                        // DrawScrollingText();
                    }
                }
                catch (Exception e)
                {
                    logFile.Write("[" + DateTime.Now + "] - ");
                    logFile.WriteLine(e);
                    logFile.Flush();
                    return;
                }
            }
        }

        public bool GetSpotifyTrackInfo()
        {
            Process proc = Process.GetProcessesByName("Spotify").FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.MainWindowTitle));

            string oldSong = CurrentSong ?? "";
            if (proc == null)
            {
                CurrentSong = "";
            }
            else if (PausedSong.Contains(proc.MainWindowTitle))
            {
                if (!IsPaused)
                {
                    IsPaused = true;
                    CurrentSong = "(PAUSED) " + CurrentSong;
                    NoSongAt = DateTime.Now.AddMinutes(5);
                }
                else
                {
                    if (NoSongAt < DateTime.Now)
                    {
                        CurrentSong = "";
                    }
                }
            }
            else
            {
                IsPaused = false;
                CurrentSong = proc.MainWindowTitle;
            }

            if (oldSong.Equals(CurrentSong))
            {
                return false;
            }
            return true;
        }
    }
}

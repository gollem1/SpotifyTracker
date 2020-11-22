using System.IO;

namespace SpotifySongTracker.Writers
{
    internal class TextSongWriter : ISongWriter
    {
        public void Write(string songName)
        {
            File.WriteAllText(@"out\song.txt", songName);
        }
        public void Close()
        { }
    }
}
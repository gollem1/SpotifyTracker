namespace SpotifySongTracker.Writers
{
    public interface ISongWriter
    {
        void Write(string songName);
        void Close();
    }
}

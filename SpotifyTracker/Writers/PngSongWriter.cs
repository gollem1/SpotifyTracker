using SpotifySongTracker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifySongTracker.Writers
{
    class PngSongWriter : ISongWriter
    {
        public void Close()
        { }

        public void Write(string songName)
        {
            try
            {
                Image source = DrawText(songName);
                source.Save(@"out\song.png", ImageFormat.Png);
            }
            catch
            {

            }
        }

        private Image DrawText(string text)
        {
            //first, create a dummy bitmap just to get a graphics object
            Bitmap img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, Properties.Settings.Default.Font);

            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size
            img = new Bitmap((int)textSize.Width, (int)textSize.Height, PixelFormat.Format32bppArgb);

            drawing = Graphics.FromImage(img);

            //paint the background

            drawing.Clear(Properties.Settings.Default.TextBackground);

            //create a brush for the text
            Brush textBrush = new SolidBrush(Properties.Settings.Default.TextColor);
            Pen outlinePen = new Pen(Properties.Settings.Default.TextOutline, 2);

            GraphicsPath p = new GraphicsPath();
            p.AddString(
                text,                               // text to draw
                Properties.Settings.Default.Font.FontFamily,   // or any other font family
                (int)Properties.Settings.Default.Font.Style,  // font style (bold, italic, etc.)
                Properties.Settings.Default.Font.SizeInPoints, // em size g.DpiY * fontSize / 72
                new Point(0, 0),                    // location where to draw text
                new StringFormat()                  // set options here (e.g. center alignment) new StringFormat()
            );

            drawing.DrawPath(outlinePen, p);
            drawing.FillPath(textBrush, p);

            // drawing.DrawString(text, Settings.Default.Font, textBrush, 0, 0);

            drawing.Save();

            outlinePen.Dispose();
            textBrush.Dispose();
            drawing.Dispose();

            //if (Settings.Default.TextBackground.Equals(Color.Transparent))
            //{
            //    return MakeTransparentGif(img, Color.FromArgb(123, 123, 123, 123));
            //}

            return img;
        }
    }
}

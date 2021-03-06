﻿using ImageMagick;
using SpotifySongTracker.Properties;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace SpotifySongTracker.Writers
{
    class GifSongWriter : ISongWriter
    {
        public void Write(string songName)
        {
            using (var collection = new MagickImageCollection())
            {
                Image source = DrawText(songName);
                source.Save(@"out\song.png", ImageFormat.Png);

                int maxWidth = Properties.Settings.Default.MaxSize;

                int frame = 0;

                int xDelta = 2;
                int xStart = 0;
                int xEnd = xStart + xDelta;
                // grow
                while (xDelta < maxWidth)
                {
                    Bitmap target = new Bitmap(maxWidth, source.Height, PixelFormat.Format32bppArgb);

                    Graphics graphics = Graphics.FromImage(target);
                    graphics.Clear(Properties.Settings.Default.TextBackground);
                    graphics.DrawImage(source, new Rectangle(Math.Max(0, maxWidth - xEnd), 0, xEnd, target.Height), new Rectangle(xStart, 0, xEnd, source.Height), GraphicsUnit.Pixel);
                    graphics.Dispose();

                    AddFrameToCollection(target, collection);

                    //target.Save(@"out\source" + frame.ToString() + ".png", ImageFormat.Png);
                    frame++;

                    xDelta += 2;
                    xEnd = xStart + xDelta;
                }
                // shrink
                while (xStart < source.Width)
                {
                    Bitmap target = new Bitmap(maxWidth, source.Height, PixelFormat.Format32bppArgb);

                    Graphics graphics = Graphics.FromImage(target);
                    graphics.Clear(Properties.Settings.Default.TextBackground);
                    graphics.DrawImage(source, new Rectangle(Math.Max(0, maxWidth - xEnd), 0, xEnd, target.Height), new Rectangle(xStart, 0, xEnd, source.Height), GraphicsUnit.Pixel);
                    graphics.Dispose();

                    AddFrameToCollection(target, collection);

                    //target.Save(@"out\source" + frame.ToString() + ".png", ImageFormat.Png);
                    frame++;

                    xStart += 2;
                    xEnd = xStart + xDelta;
                }

                Bitmap last = new Bitmap(maxWidth, source.Height, PixelFormat.Format32bppArgb);

                Graphics g = Graphics.FromImage(last);
                g.Clear(Properties.Settings.Default.TextBackground);
                g.Save();

                AddFrameToCollection(last, collection);

                g.Dispose();

                collection[0].AnimationIterations = 0;
                collection.Coalesce();
                collection.Quantize(new QuantizeSettings()
                {
                    Colors = 256
                });

                collection.Write(@"out\song.gif", MagickFormat.Gif);
            }
        }

        public void Close()
        { }

        private void AddFrameToCollection(Bitmap frame, MagickImageCollection collection)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                frame.Save(ms, ImageFormat.Png);
                ms.Position = 0;

                MagickImage mi = new MagickImage(ms, MagickFormat.Png)
                {
                    AnimationDelay = 10,
                    BackgroundColor = MagickColor.FromRgba(Properties.Settings.Default.TextBackground.R, Properties.Settings.Default.TextBackground.G, Properties.Settings.Default.TextBackground.B, Properties.Settings.Default.TextBackground.A),
                    GifDisposeMethod = GifDisposeMethod.Background,
                    AnimationTicksPerSecond = 200
                };

                collection.Add(mi);
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

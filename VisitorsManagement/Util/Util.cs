using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Utility
{
    public class Util
    {
        public static System.Drawing.Image ConvertByteToSystemDrawingImage(byte[] byteImg)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(byteImg);
            return System.Drawing. Image.FromStream(ms);
        }

        public static byte[] ConvertImageToByte(string filepath)
        {
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(filepath);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            return ms.ToArray();
        }

        //public static byte[] ConvertBitmapToByte(Bitmap bmp)
        //{
        //    System.IO.MemoryStream ms = new System.IO.MemoryStream();
        //    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

        //    return ms.ToArray();
        //}

        //public static byte[] ConvertImageToByte(Image img)
        //{
        //    ImageConverter converter = new ImageConverter();
        //    return (byte[])converter.ConvertTo(img, typeof(byte[]));
        //}

        public static BitmapImage ConvertByteToImage(byte[] img)
        {
            BitmapImage bi = new BitmapImage();
            try
            {
                System.IO.MemoryStream stream = new System.IO.MemoryStream(img);

                bi.BeginInit();
                bi.StreamSource = stream;
                bi.EndInit();
                return bi;
            }
            catch { }
            return null;
        }

        public static ImageSource ConvertBitmapToImageSource(System.Drawing.Bitmap bitmap)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            ms.Position = 0;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.EndInit();

            return bi;
        }

        public static byte[] ImageToByteArray(BitmapImage im)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(im));
                encoder.Save(ms);
                return ms.GetBuffer();
            }

        }

        public static byte[] ImageToByteArray(System.Drawing.Image bitmapImage)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmapImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] temp = ms.ToArray();
                return temp;
            }

        }

        //public static byte[] ImageToByteArray(System.Drawing.Image bitmapImage)
        //{
        //        MemoryStream ms = new MemoryStream();
        //        string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        //        //bitmapImage.Save(path + "\\temp.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        //        Bitmap _bitmap = (Bitmap)bitmapImage.Clone();//new Bitmap(bitmapImage, bitmapImage.Width, bitmapImage.Height);
        //        //Bitmap _bitmap = new Bitmap(path + "\\temp.jpg");
        //        bitmapImage.Dispose();
        //        //bitmapImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        _bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);   
        //        byte[] temp = ms.ToArray();
        //        _bitmap.Dispose();
        //        //aFile.Delete(path + "\\temp.jpg");
        //        ms.Dispose();
        //        return temp;
        //}

        public static byte[] ConvertIntToBytes(int value, int capacity)
        {
            byte[] buffer = new byte[capacity];
            for (int i = 0; i < capacity; i++) buffer[i] = (byte)((value >> (i * 8)) & 0x000000FF);
            return buffer;
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        
    }
}

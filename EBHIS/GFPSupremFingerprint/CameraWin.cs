using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Emgu.CV.Structure;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace CameraDriver1
{
    //[System.Reflection.ObfuscationAttribute(Feature = "renaming", ApplyToMembers = false)]
    public partial class CameraWin : Form
    {
        [System.Reflection.ObfuscationAttribute(Feature = "renaming", ApplyToMembers = false)]
        public event PhotoAcquiredEventHandler PictureAcquired;
        
        int c = 0;
        //try

        Emgu.CV.Capture cp;// = new Emgu.CV.Capture(0); 
        Emgu.CV.Image<Bgr, byte> img;
        MCvAvgComp[][] facesDetected = null;
        
        Rectangle DefaultRect = new Rectangle(41, 31, 204, 185);

        public CameraWin()
        {
            InitializeComponent();
            tnsize = 100;
            quality = 50;
            try { cp = new Emgu.CV.Capture(0); }
            catch (Exception ex) { }
        }


        void Run()
        {
            while (true)
            {
                try
                {
                    Emgu.CV.Image<Gray, Byte> gray = img.Convert<Gray, Byte>(); //Convert it to Grayscale

                    //normalizes brightness and increases contrast of the image
                    gray._EqualizeHist();

                    //Read the HaarCascade objects
                    Emgu.CV.HaarCascade face = new Emgu.CV.HaarCascade("haarcascade_frontalface_alt_tree.xml");
                    //Emgu.CV.HaarCascade eye = new Emgu.CV.HaarCascade("haarcascade_eye.xml");

                    //Detect the faces  from the gray scale image and store the locations as rectangle
                    //The first dimensional is the channel
                    //The second dimension is the index of the rectangle in the specific channel
                    facesDetected = gray.DetectHaarCascade(
                       face,
                       1.1,
                       10,
                       Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                       new Size(20, 20));
                }
                catch { }
            }
        }

        System.Threading.Thread thread = null;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (img != null)
            //{
            try
            {
                img = cp.QueryFrame();
                if (facesDetected != null && facedetect)
                    foreach (MCvAvgComp f in facesDetected[0])
                    {
                        //draw the face detected in the 0th (gray) channel with blue color
                        img.Draw(f.rect, new Bgr(System.Drawing.Color.Blue), 2);
                    }


                if (!facedetect)
                    CaptureButton.Enabled = true;
                else if (facesDetected != null && facesDetected[0].Count() != 0)
                    CaptureButton.Enabled = true;
                else
                    CaptureButton.Enabled = false;

                if (!facedetect)
                {
                    if (img.Width <= 320)
                        DefaultRect = new Rectangle(41, 31, 204, 185);
                    else
                        DefaultRect = new Rectangle(92, 26, 390, 355);
                    img.Draw(DefaultRect, new Bgr(System.Drawing.Color.Red), 2);
                    //zoom = new Rectangle(new Point((img.Width - img.Width * 10 / (trackBar1.Value * 10)) / 2, (img.Height - img.Height * 10 / (trackBar1.Value * 10)) / 2), new Size(img.Width / (trackBar1.Value), img.Height / (trackBar1.Value)));
                    //img = img.Copy(zoom);
                }

                pictureBox1.Image = img.Resize(pictureBox1.Width, pictureBox1.Height, Emgu.CV.CvEnum.INTER.CV_INTER_NN, true).Bitmap;
                //img.Dispose();

                if (thread == null)
                {
                    thread = new System.Threading.Thread(new System.Threading.ThreadStart(Run));
                    thread.Start();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void captureButton_Click(object sender, EventArgs e)
        {
            try
            {
                CaptureButton.Enabled = false;
                ResetButton.Enabled = true;
                thread.Abort(); thread = null;
                timer1.Enabled = false;
                if (facedetect)
                    img = img.Copy(((MCvAvgComp)facesDetected[0][0]).rect);
                else
                {
                    if (img.Width <= 320)
                        DefaultRect = new Rectangle(41, 31, 204, 185);
                    else
                        DefaultRect = new Rectangle(92, 26, 390, 355);

                    img = img.Copy(DefaultRect);
                }
                //pictureBox1.Image = pictureBox1.Image = img.Resize(pictureBox1.Width, pictureBox1.Height, Emgu.CV.CvEnum.INTER.CV_INTER_AREA, true).Bitmap;
                pictureBox1.Image = img.Resize(pictureBox1.Width, pictureBox1.Height, Emgu.CV.CvEnum.INTER.CV_INTER_AREA, true).Bitmap;
                PhotoAcquiredEventArgs bmp = new PhotoAcquiredEventArgs(Thumbnail, Photo, resizedBMPbyte, normalBMPbyte,normalBMPImageSource);//new PhotoAcquiredEventArgs(Thumbnail, Photo);
                PictureAcquired(this, bmp);
                //Thumbnail.Save("test.jpg");
            }
            catch (Exception ex)
            {

            }
        }

        public Bitmap Photo
        {
            get
            {
                return img.Bitmap;
            }
        }

        public byte[] normalBMPbyte
        {
            get
            {
                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(
                    System.Drawing.Imaging.Encoder.Quality, quality
                    );

                var jpegCodec = (from codec in ImageCodecInfo.GetImageEncoders()
                                 where codec.MimeType == "image/jpeg"
                                 select codec).Single();
                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                img.Bitmap.Save(stream, jpegCodec, encoderParams);
                return stream.ToArray();
            }
        }

        public byte[] resizedBMPbyte
        {
            get
            {
                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(
                    System.Drawing.Imaging.Encoder.Quality, quality
                    );

                var jpegCodec = (from codec in ImageCodecInfo.GetImageEncoders()
                                 where codec.MimeType == "image/jpeg"
                                 select codec).Single();
                System.IO.MemoryStream stream = new System.IO.MemoryStream();

                Emgu.CV.Image<Bgr, byte> img1 = img.Resize(tnsize, tnsize, Emgu.CV.CvEnum.INTER.CV_INTER_AREA, true);
                img1.Bitmap.Save(stream, jpegCodec, encoderParams);

                return stream.ToArray();
            }
        }

        private long quality;
        public long Quality
        {
            get
            {
                return quality;
            }
            set
            {
                quality = value;
            }
        }

        private int tnsize;
        public int ThumpnailSize
        {
            get
            {
                return tnsize;
            }
            set
            {
                tnsize = value;
            }
        }

        //thumbnail picture size is 1936 bytes. use 1920 to be on the safe side
        public Bitmap Thumbnail
        {
            get
            {
                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(
                    System.Drawing.Imaging.Encoder.Quality, quality
                    );

                var jpegCodec = (from codec in ImageCodecInfo.GetImageEncoders()
                                 where codec.MimeType == "image/jpeg"
                                 select codec).Single();
                System.IO.MemoryStream stream = new System.IO.MemoryStream();

                Emgu.CV.Image<Bgr, byte> img1 = img.Resize(tnsize, tnsize, Emgu.CV.CvEnum.INTER.CV_INTER_AREA, true);
                img1.Bitmap.Save(stream, jpegCodec, encoderParams);

                return new Bitmap(stream);
            }
        }

        public ImageSource normalBMPImageSource
        {
            get
            {
                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(
                    System.Drawing.Imaging.Encoder.Quality, quality
                    );

                var jpegCodec = (from codec in ImageCodecInfo.GetImageEncoders()
                                 where codec.MimeType == "image/jpeg"
                                 select codec).Single();
                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                img.Bitmap.Save(stream, jpegCodec, encoderParams);
                stream.Position = 0;
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = stream;
                bi.EndInit();
                return bi;
            }
        }
        
        
        //public static ImageSource ConvertBitmapToImageSource(System.Drawing.Bitmap bitmap)
        //{
        //    System.IO.MemoryStream ms = new System.IO.MemoryStream();
        //    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //    ms.Position = 0;
        //    BitmapImage bi = new BitmapImage();
        //    bi.BeginInit();
        //    bi.StreamSource = ms;
        //    bi.EndInit();

        //    return bi;
        //}
        
        
        private void resetButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            CaptureButton.Enabled = true;
            ResetButton.Enabled = false;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread != null)
                thread.Abort();
            timer1.Enabled = false;
            if (cp != null)
                cp.Dispose();
        }

        private void toggleCamButton_Click(object sender, EventArgs e)
        {
            toggleCamButton.Enabled = false;
            timer1.Enabled = false;
            if (thread != null)
            { thread.Abort(); thread = null; }
            if (cp != null)
                cp.Dispose();
            c = (c == 0) ? 1 : 0;
            try
            {
                cp = new Emgu.CV.Capture(c);
                timer1.Enabled = true;
                toggleCamButton.Enabled = true;
            }
            catch (Exception ex)
            {
                toggleCamButton.Enabled = true;
            }
        }

        bool facedetect = false;

        public bool FaceDetect
        {
            get
            {
                return facedetect;
            }
            set
            {
                facedetect = value;
                checkBox1.Checked = facedetect;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            facedetect = checkBox1.Checked;
            trackBar1.Enabled = !checkBox1.Checked;
        }


        Rectangle zoom;
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //string g = trackBar1.Value.ToString();
        }
    }
    [System.Reflection.ObfuscationAttribute(Feature = "renaming", ApplyToMembers = false)]
    public delegate void PhotoAcquiredEventHandler(object sender, PhotoAcquiredEventArgs e);

    [System.Reflection.ObfuscationAttribute(Feature = "renaming", ApplyToMembers = true)]
    public class PhotoAcquiredEventArgs : EventArgs
    {
        public PhotoAcquiredEventArgs(Bitmap resizedBMP, Bitmap normalBMP, byte[] resizedBMPbyte, byte[] normalBMPbyte, ImageSource BMPImageSource)
        {
            this._resizedBMP = resizedBMP;
            this._resizedBMPbyte = resizedBMPbyte;
            this._normalBMP = normalBMP;
            this._normalBMPbyte = normalBMPbyte;
            this._normalBMPImageSource = BMPImageSource;
        }

        private Bitmap _resizedBMP;
        private Bitmap _normalBMP;
        private byte[] _resizedBMPbyte;
        private byte[] _normalBMPbyte;
        ImageSource _normalBMPImageSource;

        public Bitmap resizedPhoto
        {
            get { return this._resizedBMP; }
        }
        public Bitmap normalPhoto
        {
            get { return this._normalBMP; }
        }
        public byte[] normalPhotobyte
        {
            get { return this._normalBMPbyte; }
        }
        public byte[] resizedBMPbyte
        {
            get { return this._resizedBMPbyte; }
        }

        public ImageSource ImageSource 
        {
            get { return this._normalBMPImageSource; }
        }
    }


}

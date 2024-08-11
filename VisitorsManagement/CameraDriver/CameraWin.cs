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

namespace CameraDriver
{
     
    
    public partial class CameraWin : Form
    {

        public event PhotoAcquiredEventHandler PictureAcquired;
        Emgu.CV.Capture cp = new Emgu.CV.Capture(0); int c = 0;
        Emgu.CV.Image<Bgr, byte> img;

        MCvAvgComp[][] facesDetected = null;

        public CameraWin()
        {
            InitializeComponent();
            tnsize = 100;
            quality = 50;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
           
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
            img = cp.QueryFrame();
            if(facesDetected != null)
            foreach (MCvAvgComp f in facesDetected[0])
            {
                //draw the face detected in the 0th (gray) channel with blue color
                img.Draw(f.rect, new Bgr(Color.Blue), 2);
            }

            if (facesDetected != null && facesDetected[0].Count() != 0)
                CaptureButton.Enabled = true;
            else
                CaptureButton.Enabled = false;

            pictureBox1.Image = img.Resize(pictureBox1.Width, pictureBox1.Height, Emgu.CV.CvEnum.INTER.CV_INTER_NN, true).Bitmap;

            if (thread == null)
            {
                thread = new System.Threading.Thread(new System.Threading.ThreadStart(Run));
                thread.Start();
            }
        }

        private void captureButton_Click(object sender, EventArgs e)
        {
            CaptureButton.Enabled = false;
            ResetButton.Enabled = true;
            thread.Abort(); thread = null;
            timer1.Enabled = false;
            img = img.Copy(((MCvAvgComp)facesDetected[0][0]).rect);
            pictureBox1.Image = pictureBox1.Image = img.Resize(pictureBox1.Width, pictureBox1.Height, Emgu.CV.CvEnum.INTER.CV_INTER_AREA, true).Bitmap;
            PhotoAcquiredEventArgs bmp = new PhotoAcquiredEventArgs(Thumbnail,Photo);
            PictureAcquired(this, bmp);
            //Thumbnail.Save("test.jpg");
         }

        public Bitmap Photo
        {
            get
            {
                return img.Bitmap;
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
            if(thread != null)
                thread.Abort();
            if (timer1 != null) { timer1.Dispose(); }
            cp.Dispose();
        }

        private void toggleCamButton_Click(object sender, EventArgs e)
        {
            toggleCamButton.Enabled = false;
            timer1.Enabled = false;
            if (thread != null)
            { thread.Abort(); thread = null; }
            cp.Dispose(); 
            c= (c == 0)?1:0 ;
            cp = new Emgu.CV.Capture(c);

            timer1.Enabled = true;
            toggleCamButton.Enabled = true;
        }
                
    }

    public delegate void PhotoAcquiredEventHandler(object sender, PhotoAcquiredEventArgs e);
    public class PhotoAcquiredEventArgs : EventArgs
    {
        public PhotoAcquiredEventArgs(Bitmap resizedBMP, Bitmap normalBMP)
        {
            resizedBmp = resizedBMP;
            untouchedBmp = normalBMP;
        }
        private Bitmap resizedBmp;
        private Bitmap untouchedBmp;
        public Bitmap resizedPhoto
        {
            get { return resizedBmp;}
        }
        public Bitmap normalPhoto
        {
            get { return untouchedBmp;}
        }

    }
}

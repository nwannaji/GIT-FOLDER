using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
//using BiometricInterface;
using Suprema;
using System.IO;


namespace GFPSupremaFingerprint
{
    public class GFPSupremaFpApi : System.Windows.Forms.Form//, IFingerprint
    {
        private UFS_STATUS ufs_res;
        UFM_STATUS ufm_res;
        Suprema.UFScannerManager ScannerManager;
        const int MAX_TEMPLATE_SIZE = 1024;
        int TempSize;
        int noOfScanner;
        Suprema.UFScanner scanner;
        UFMatcher Matcher;
        byte[] template;

        private int lengthOfDBTemplate;

        public int LengthOfDBTemplate
        {
            get { return lengthOfDBTemplate; }
            set { lengthOfDBTemplate = value; }

        }

        public GFPSupremaFpApi()
        {

            this.lengthOfDBTemplate = MAX_TEMPLATE_SIZE;
            ScannerManager = new UFScannerManager(this);
            ufs_res = ScannerManager.Init();
            if (ufs_res == UFS_STATUS.ERR_ALREADY_INITIALIZED)
            {
                ufs_res = ScannerManager.Uninit();//Uninitialize it
                ufs_res = ScannerManager.Init();//Initialize it again.
            }
            noOfScanner = ScannerManager.Scanners.Count;
            scanner = new UFScanner();
            scanner = ScannerManager.Scanners[0];
            scanner.Timeout = 5000;
            scanner.TemplateSize = MAX_TEMPLATE_SIZE;
            scanner.DetectCore = false;
            /*  suprema = 2001
            iso19479_2 = 2002
            ansi378 = 2003 */
            scanner.nTemplateType = 2002; //ISO1974_2
            Matcher = new UFMatcher();
            Matcher.nTemplateType = 2002;
            Matcher.SecurityLevel = 7;
        }


        public GFPSupremaFpApi(int SizeOfTemplate, int TimeOut)
        {

            //this.lengthOfDBTemplate = MAX_TEMPLATE_SIZE;
            ScannerManager = new UFScannerManager(this);
            ufs_res = ScannerManager.Init();
            if (ufs_res == UFS_STATUS.ERR_ALREADY_INITIALIZED)
            {
                ufs_res = ScannerManager.Uninit();//Uninitialize it
                ufs_res = ScannerManager.Init();//Initialize it again.
            }
            noOfScanner = ScannerManager.Scanners.Count;
            scanner = new UFScanner();
            scanner = ScannerManager.Scanners[0];
            scanner.Timeout = TimeOut;
            scanner.TemplateSize = SizeOfTemplate;//MAX_TEMPLATE_SIZE;
            scanner.DetectCore = false;
            /*  suprema = 2001
            iso19479_2 = 2002
            ansi378 = 2003 */
            scanner.nTemplateType = 2002; //ISO1974_2
            Matcher = new UFMatcher();
            Matcher.nTemplateType = 2002;
            Matcher.SecurityLevel = 7;
        }

        public GFPSupremaFpApi(int SizeOfTemplate, int TimeOut, int securityLevel)
        {

            this.lengthOfDBTemplate = SizeOfTemplate;
            ScannerManager = new UFScannerManager(this);
            ufs_res = ScannerManager.Init();
            if (ufs_res == UFS_STATUS.ERR_ALREADY_INITIALIZED)
            {
                ufs_res = ScannerManager.Uninit();//Uninitialize it
                ufs_res = ScannerManager.Init();//Initialize it again.
            }
            noOfScanner = ScannerManager.Scanners.Count;
            scanner = new UFScanner();
            scanner = ScannerManager.Scanners[0];
            scanner.Timeout = TimeOut;
            scanner.TemplateSize = SizeOfTemplate;//MAX_TEMPLATE_SIZE;
            scanner.DetectCore = false;
            /*  suprema = 2001
            iso19479_2 = 2002
            ansi378 = 2003 */
            scanner.nTemplateType = 2002;// ISO1974_2
            Matcher = new UFMatcher();
            Matcher.nTemplateType = 2002;
            Matcher.SecurityLevel = securityLevel;
        }

        public GFPSupremaFpApi(int SizeOfTemplate)
        {
            //this.lengthOfDBTemplate = MAX_TEMPLATE_SIZE;
            ScannerManager = new UFScannerManager(this);
            ufs_res = ScannerManager.Init();
            if (ufs_res == UFS_STATUS.ERR_ALREADY_INITIALIZED)
            {
                ufs_res = ScannerManager.Uninit();//Uninitialize it
                ufs_res = ScannerManager.Init();//Initialize it again.
            }
            noOfScanner = ScannerManager.Scanners.Count;
            scanner = new UFScanner();
            scanner = ScannerManager.Scanners[0];
            scanner.Timeout = 5000;
            scanner.TemplateSize = SizeOfTemplate;//MAX_TEMPLATE_SIZE;
            scanner.DetectCore = false;
            /*  suprema = 2001
            iso19479_2 = 2002
            ansi378 = 2003 */
            scanner.nTemplateType = 2003; //ISO1974_2
            Matcher = new UFMatcher();
            Matcher.nTemplateType = 2002;
            Matcher.SecurityLevel = 7;
        }

        public void Dispose()
        {
            if (scanner != null)
            {
                if (scanner.IsCapturing)
                {
                    ufs_res = scanner.AbortCapturing();
                    if (ufs_res == UFS_STATUS.OK)
                    {
                        ufs_res = ScannerManager.Uninit();
                        if (ufs_res == UFS_STATUS.OK)
                        {

                        }
                    }
                }

            }

        }

        public bool Identify(byte[] capturedTemplate, int capturedTemplateSize, byte[][] dbTemplates, int[] Template2SizeArray, int noOfdbTemplates, int timeOut, ref int MatchIndex)
        {
            // ufm_res = Matcher.Identify(capturedTemplate, TempSize, dbTemplates, Template2SizeArray, noOfdbTemplates, timeOut, out MatchIndex);
            ufm_res = Matcher.Identify(capturedTemplate, capturedTemplateSize, dbTemplates, Template2SizeArray, noOfdbTemplates, timeOut, out MatchIndex);

            if (ufm_res != UFM_STATUS.OK)
            {
                throw new Exception("Template Error");
            }
            else { if (MatchIndex != -1) { return true; } else { return false; } }
        }

        public bool Identify(byte[] capturedTemplate, byte[][] dbTemplates, int[] Template2SizeArray, int noOfdbTemplates, int timeOut, ref int MatchIndex)
        {
            // ufm_res = Matcher.Identify(capturedTemplate, TempSize, dbTemplates, Template2SizeArray, noOfdbTemplates, timeOut, out MatchIndex);
            if (capturedTemplate != null)
            {
                ufm_res = Matcher.Identify(capturedTemplate, capturedTemplate.Length, dbTemplates, Template2SizeArray, noOfdbTemplates, timeOut, out MatchIndex);

                if (ufm_res != UFM_STATUS.OK)
                {
                    throw new Exception("Template Error");
                }

                else { if (MatchIndex != -1) { return true; } else { return false; } }
            }
            else return false;
        }
        
        #region IFingerprint Members

        public Bitmap AcquireImage()
        {
            ufs_res = scanner.ClearCaptureImageBuffer();
            ufs_res = scanner.CaptureSingleImage();
            scanner.SaveCaptureImageBufferToBMP("temp1.bmp");
            Bitmap b = new Bitmap("temp1.bmp");
            return b;
            //throw new NotImplementedException();
        }

        //public byte[] ExtractTemplate(ref Bitmap bmp, ref int templateQuality, out string errorMsg)
        //{
        //    template = new byte[MAX_TEMPLATE_SIZE];
        //    ufs_res = scanner.ClearCaptureImageBuffer();
        //    ufs_res = scanner.CaptureSingleImage();
        //    scanner.SaveCaptureImageBufferToBMP("temp.bmp");
        //    if (ufs_res == UFS_STATUS.OK) { scanner.Extract(template, out TempSize, out templateQuality); }
        //    else {
        //        UFScanner.GetErrorString(ufs_res, out errorMsg);
        //        throw new Exception("");
        //    }
        //    Bitmap b = new Bitmap("temp.bmp");
        //    bmp = b;
        //    errorMsg = null;
        //    return template;
        //    //throw new NotImplementedException();
        //}

        public byte[] ExtractTemplate(ref Bitmap bmp, ref int SizeOfCaptureTemplate, ref int templateQuality, out string errorMsg)
        {
            template = new byte[MAX_TEMPLATE_SIZE];
            ufs_res = scanner.ClearCaptureImageBuffer();
            while (true)
            {
                ufs_res = scanner.CaptureSingleImage();
                if (ufs_res != UFS_STATUS.OK)
                {
                    UFScanner.GetErrorString(ufs_res, out errorMsg);
                    throw new Exception("");
                }

               ufs_res = scanner.Extract(template, out SizeOfCaptureTemplate, out templateQuality);
                if (ufs_res == UFS_STATUS.OK)
                {
                    break;
                }
                else
                {
                    UFScanner.GetErrorString(ufs_res, out errorMsg);
                    throw new Exception("");
                }
            }
            //scanner.SaveCaptureImageBufferToBMP("temp.bmp");
            Bitmap b = new Bitmap("temp.bmp");
            bmp = b;
            errorMsg = null;
            return template;
            //throw new NotImplementedException();
        }


        public byte[] ExtractTemplate(ref Bitmap bmp)
        {
            int TempQuality;
            template = new byte[MAX_TEMPLATE_SIZE];
            ufs_res = scanner.ClearCaptureImageBuffer();
            ufs_res = scanner.CaptureSingleImage();
            UFS_STATUS stat = scanner.SaveCaptureImageBufferToBMP("temp.bmp");
            if (ufs_res == UFS_STATUS.OK) {
                using (MemoryStream ms = new MemoryStream())
                {
                    Bitmap b = new Bitmap("temp.bmp");
                    b.Save(ms, System.Drawing.Imaging.ImageFormat.Png);// Use Png because Bmp causes an Exception in GDI+ when the Save method of Image class is used
                    bmp = new Bitmap(ms);
                    b.Dispose();
                }
            scanner.Extract(template, out TempSize, out TempQuality); 
            }
            else { throw new Exception(""); }
            //Bitmap b = new Bitmap("temp.bmp");
            //bmp = b;
            File.Delete("temp.bmp");
            return template;
            //throw new NotImplementedException();
        }

        public bool Verify(byte[] fromdatabase, byte[] acquired)
        {
            //byte[] Template1 = new byte[MAX_TEMPLATE_SIZE];
            int AcquiredTemplateSize = TempSize;
            // byte[] Template2 = new byte[MAX_TEMPLATE_SIZE];
            int DBTemplateSize = lengthOfDBTemplate;
            bool VerifySucceed;
            // try
            //{
            ufm_res = Matcher.Verify(acquired, AcquiredTemplateSize, fromdatabase, DBTemplateSize, out VerifySucceed);
            if (ufm_res == UFM_STATUS.ERR_INVALID_PARAMETERS) { throw new Exception(""); }
            return VerifySucceed;
            //}
            //catch (Exception ex)
            //{
            // return false;
            //throw new NotImplementedException();
            //}
        }


        #endregion
    }
}

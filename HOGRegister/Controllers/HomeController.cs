using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using SecuGen.FDxSDKPro.Windows;


namespace HOGRegister.Controllers
{
    public class HomeController : Controller
    {
        #region fingerprint init
        /*
        private SGFingerPrintManager m_FPM; //member variable
        SGFPMDeviceName device_name = SGFPMDeviceName.DEV_FDU03;
        static int m_ImageWidth, m_ImageHeight;

        public void InitializeSGFingerPrintManager()
        {
            m_FPM = new SGFingerPrintManager();
            int port_addr;
            port_addr = (int)SGFPMPortAddr.USB_AUTO_DETECT;
            int iError = m_FPM.OpenDevice(port_addr);
            if (iError == (int)SGFPMError.ERROR_NONE)
            {
                SGFPMDeviceInfoParam pInfo = new SGFPMDeviceInfoParam();
                pInfo = new SGFPMDeviceInfoParam();
                iError = m_FPM.GetDeviceInfo(pInfo);
                if (iError == (Int32)SGFPMError.ERROR_NONE)
                {
                    // This should be done GetDeviceInfo();
                    m_ImageWidth = pInfo.ImageWidth;
                    m_ImageHeight = pInfo.ImageHeight;
                }
                ViewBag.Message = "OpenDevice() Error : " + iError;
            }
            else
                ViewBag.Message = "OpenDevice() Error : " + iError;

        }

        //getting finger print image
        public void GetFingerPrintImage()
        {
            byte[] fp_image = new Byte[m_ImageWidth * m_ImageHeight];
            int iError;
            iError = m_FPM.GetImage(fp_image);
            if (iError == (int)SGFPMError.ERROR_NONE)
            {
                //ToDO: pass the fingerprint image to the screen
                //DrawImage(fp_image, pictureBox1);
            }
            else
                ViewBag.Message = "GetImage() Error : " + iError;
        }
        */
        #endregion fingerprint init

        public ActionResult Index()
        {
            //InitializeSGFingerPrintManager();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
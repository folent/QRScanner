using QRcodeGenerate.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using ZXing;
using AForge.Video.DirectShow;
using System.Web.Mvc;
using System.Configuration;
using System.Data.Entity;

namespace QRcodeGenerate.Controllers
{
    public class QRCodeGeneratorController : Controller
    {
        // GET: QRCodeGenerator
        TasksContext db = new TasksContext();
        public ActionResult Index()
        {
            int selectedIndex = 1;
            SelectList locations = new SelectList(db.Locations, "Id", "Name", selectedIndex);
            ViewBag.Locations = locations;
            SelectList underLocations = new SelectList(db.UnderLocations.Where(c => c.LocationId == 2), "Id", "Name");
            ViewBag.UnderLocations = underLocations;
            SelectList machine = new SelectList(db.Machine.Where(c => c.LocationId == 2), "Id", "Name");
            ViewBag.Machine = machine;
            SelectList operations = new SelectList(db.Operations.Where(c => c.LocationId == 2), "Id", "Name");
            ViewBag.Operations = operations;
            return View();
            // "Server = localhost; Database = tasks; Trusted_Connection = True;"
        }
        public ActionResult GetUnderLocations(int id)
        {
            return PartialView(db.UnderLocations.Where(c => c.LocationId == id).ToList());
        }
        public ActionResult GetMachine(int id)
        {
            return PartialView(db.Machine.Where(c => c.UnderLocationId == id).ToList());
        }        
        public ActionResult GetOperations(int id)
        {
            return PartialView(db.Operations.Where(c => c.MachineId == id).ToList());
        }
        public ActionResult FindTask(int id)
        {
            var operation = db.Operations.Where(c => c.Id == id).ToList();
            return PartialView(operation);
        }
        public ActionResult ErrorFindTask()
        {
            return PartialView();
        }
        public ActionResult GetTasks()
        {
            var tech = db.Technologys.ToList();
            return View(tech);
        }
        public ActionResult ScannerQRCode()
        { 
            return View();
        }
        public ActionResult GenerateQRCode()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Generate(QRCodeModel qrcode)
        {
            try
            {
                qrcode.QRCodeImagePath = GenerateQRCode(qrcode.QRCodeText);
                ViewBag.Message = "QR Code Created successfully";
            }
            catch (Exception ex)
            {
                //catch exception if there is any
            }
            return View("Index", qrcode);
        }

        private string GenerateQRCode(string qrcodeText)
        {
            string folderPath = "~/Images/";
            string imagePath = "~/Images/QrCode.jpg";
            // If the directory doesn't exist then create it.
            if (!Directory.Exists(Server.MapPath(folderPath)))
            {
                Directory.CreateDirectory(Server.MapPath(folderPath));
            }

            var barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            var result = barcodeWriter.Write(qrcodeText);

            string barcodePath = Server.MapPath(imagePath);
            var barcodeBitmap = new Bitmap(result);
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(barcodePath, FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            return imagePath;
        }
        public ActionResult Read()
        {
            return View(ReadQRCode());
        }

        private QRCodeModel ReadQRCode()
        {
            QRCodeModel barcodeModel = new QRCodeModel();
            string barcodeText = "";
            string imagePath = "~/Images/QrCode.jpg";
            string barcodePath = Server.MapPath(imagePath);
            var barcodeReader = new BarcodeReader();

            var result = barcodeReader.Decode(new Bitmap(barcodePath));
            if (result != null)
            {
                barcodeText = result.Text;
            }
            return new QRCodeModel() { QRCodeText = barcodeText, QRCodeImagePath = imagePath };
        }


    }
}



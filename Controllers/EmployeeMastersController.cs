using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeRegister.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using EmployeeRegister.Views.Shared.Components.SearchBar;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace EmployeeRegister.Controllers
{
   
    public class EmployeeMastersController : Controller
    {
        private readonly EmployeeMasterContext _context;
        private readonly IWebHostEnvironment webhostEnvironment;

        public EmployeeMastersController(EmployeeMasterContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webhostEnvironment = hostEnvironment;
        }

        // GET: EmployeeMasters
        [Authorize(Roles = "Ntpc Employee,Admin,Viewer")]
        public async Task<IActionResult> Index(string SearchText="",int pg=1)
        {
            List<EmployeeMaster> employees;

            if (SearchText != "" && SearchText != null) {
                employees =await _context.EmployeeMasters.Where(e => e.EmployeeName.Contains(SearchText) || e.EmployeeAadharNo.Contains(SearchText)).ToListAsync();
               /* return _context.EmployeeMasters != null ?
             View(await _context.EmployeeMasters.Where(e=>e.EmployeeName.Contains(SearchText)).ToListAsync()) :
             Problem("Entity set 'EmployeeMasterContext.EmployeeMasters'  is null.");*/
            }
            else
            {
                employees = await _context.EmployeeMasters.ToListAsync();

               /*return  _context.EmployeeMasters != null ?
           View(await _context.EmployeeMasters.ToListAsync()) :
           Problem("Entity set 'EmployeeMasterContext.EmployeeMasters'  is null.");*/
            }

            const int pageSize = 10;
            if (pg < 1)
            {
                pg = 1;
            }

            int recsCount = employees.Count();
            int recSkip=(pg-1)*pageSize;
            List<EmployeeMaster> retEmployees=employees.Skip(recSkip).Take(pageSize).ToList();


           SPager SearchPager = new SPager(recsCount,pg,pageSize) { Action = "Index", Controller = "EmployeeMasters", SearchText = SearchText };
            ViewBag.SearchPager = SearchPager;

            return View(retEmployees);

        }

        // GET: EmployeeMasters/Details/5
        [Authorize(Roles = "Ntpc Employee,Admin,Viewer")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployeeMasters == null)
            {
                return NotFound();
            }

            var employeeMaster = await _context.EmployeeMasters.FirstOrDefaultAsync(m => m.EmployeeVtccertificateNo == id);
            if (employeeMaster == null)
            {
                return NotFound();
            }

            return View(employeeMaster);
        }

        // GET: EmployeeMasters/IdCardDetails/5

        public async Task<IActionResult> IdCardDetails(int? id)
        {
            if (id == null || _context.EmployeeMasters == null)
            {
                return NotFound();
            }

            var employeeMaster = await _context.EmployeeMasters
                .FirstOrDefaultAsync(m => m.EmployeeVtccertificateNo == id);
            if (employeeMaster == null)
            {
                return NotFound();
            }

            return View(employeeMaster);
        }


        // GET: EmployeeMasters/Create
        [Authorize(Roles = "Ntpc Employee,Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Ntpc Employee,Admin")]
        // POST: EmployeeMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeVtccertificateNo,EmployeeName,EmployeeFathersName,EmployeeDesignation,EmployeeBatchNo,EmployeeDateOfBirth,EmployeeStartDate,EmployeeEndDate,EmployeeAadharNo,Address,FormANo,IMENo,EmployeeIMEDate, EmergencyMobileNumber,MobileNumber,BloodGroup,IdCardNo,VtcNo, EmployeeNo,ImageFileData ,Image,SignatureData,Signature,AuthoritySignature,VtcCertificate,FormO,FormA,BarcodeImageData,BarcodeImage,Barcode")] EmployeeMaster employeeMaster)
        {

            /*string? uniqueImageFileName = null;
           string? uniqueSignatureFileName = null;

           if (employeeMaster.Image != null && employeeMaster.Signature != null)
            {
                string ImageUploadedFolder = Path.Combine(webhostEnvironment.WebRootPath, "UploadedImages");
                uniqueImageFileName = Guid.NewGuid().ToString() + "_" + employeeMaster.Image.FileName;
                string filePath = Path.Combine(ImageUploadedFolder, uniqueImageFileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    employeeMaster.Image.CopyTo(filestream);
                }

                employeeMaster.ImageFilePath = "~/wwwroot/UploadedImages";
                employeeMaster.ImageFileName= uniqueImageFileName;

                string SignatureUploadedFolder = Path.Combine(webhostEnvironment.WebRootPath, "UploadedSignature");
                uniqueSignatureFileName = Guid.NewGuid().ToString() + "_" + employeeMaster.Signature.FileName;
                string filePath1 = Path.Combine(ImageUploadedFolder, uniqueSignatureFileName);
                using (var filestream = new FileStream(filePath1, FileMode.Create))
                {
                    employeeMaster.Signature.CopyTo(filestream);
                }

                employeeMaster.SignatureFilePath = "~/wwwroot/UploadedSignature";
                employeeMaster.SignatureFileName = uniqueSignatureFileName;

            }*/
            byte[]? bytes5 = null;

            if (employeeMaster.Image != null)
            {

                using (Stream filestream = employeeMaster.Image.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(filestream))
                    {
                        bytes5 = br.ReadBytes((Int32)filestream.Length);
                    }
                }

                employeeMaster.ImageFileData = Convert.ToBase64String(bytes5, 0, bytes5.Length);

            }

            byte[]? bytes6 = null;

            if (employeeMaster.Signature != null)
            {

                using (Stream filestream = employeeMaster.Signature.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(filestream))
                    {
                        bytes6 = br.ReadBytes((Int32)filestream.Length);
                    }
                }

                employeeMaster.SignatureData = Convert.ToBase64String(bytes6, 0, bytes6.Length);

            }


            byte[]? bytes = null;

            if (employeeMaster.AuthoritySignature != null )
            {

                using (Stream filestream = employeeMaster.AuthoritySignature.OpenReadStream())
                {
                    using(BinaryReader br=new BinaryReader(filestream))
                    {
                        bytes=br.ReadBytes((Int32)filestream.Length);
                    }
                }

                employeeMaster.AuthoritySignatureData = Convert.ToBase64String(bytes,0,bytes.Length);

            }

            byte[]? bytes1 = null;

            if (employeeMaster.VtcCertificate != null)
            {

                using (Stream filestream = employeeMaster.VtcCertificate.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(filestream))
                    {
                        bytes1 = br.ReadBytes((Int32)filestream.Length);
                    }
                }

                employeeMaster.VtcCertificateData = Convert.ToBase64String(bytes1, 0, bytes1.Length);

            }

            byte[]? bytes2 = null;

            if (employeeMaster.FormO != null)
            {

                using (Stream filestream = employeeMaster.FormO.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(filestream))
                    {
                        bytes2 = br.ReadBytes((Int32)filestream.Length);
                    }
                }

                employeeMaster.FormOData = Convert.ToBase64String(bytes2, 0, bytes2.Length);

            }

            byte[]? bytes3 = null;

            if (employeeMaster.FormA != null)
            {

                using (Stream filestream = employeeMaster.FormA.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(filestream))
                    {
                        bytes3 = br.ReadBytes((Int32)filestream.Length);
                    }
                }

                employeeMaster.FormAData = Convert.ToBase64String(bytes3, 0, bytes3.Length);

            }

            //barcode
            string id = Convert.ToString(employeeMaster.EmployeeVtccertificateNo);
            string barCodeText = $"https://localhost:7217/EmployeeMasters/Details/{id}";
            employeeMaster.Barcode = generateBarcode();
            byte[]? bytes4 = null;


            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            var image= barcode.Draw(barCodeText, 200);
            var resultImage = new Bitmap(image.Width, image.Height + 20); // 20 is bottom padding, adjust to your text

            using (var graphics = Graphics.FromImage(resultImage))
            using (var font = new Font("Consolas", 12))
            using (var brush = new SolidBrush(Color.Black))
            using (var format = new StringFormat(){
                Alignment = StringAlignment.Center, // Also, horizontally centered text, as in your example of the expected output
                LineAlignment = StringAlignment.Far
            })
            {
                graphics.Clear(Color.White);
                graphics.DrawImage(image, 0, 0);
                graphics.DrawString(employeeMaster.Barcode, font, brush, resultImage.Width / 2, resultImage.Height, format);
            }

            bytes4 = converterDemo(resultImage);

            employeeMaster.BarcodeImageData = Convert.ToBase64String(bytes4, 0, bytes4.Length);
           


            if (ModelState.IsValid)
            {
                _context.Add(employeeMaster);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }


            return View(employeeMaster);
        }

        public static byte[] converterDemo(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

        public string generateBarcode()
        {
            try
            {
                string[] charPool = "1-2-3-4-5-6-7-8-9-0".Split('-');
                StringBuilder rs = new StringBuilder();
                int length = 6;
                Random rnd = new Random();
                while (length-- > 0)
                {
                    int index = (int)(rnd.NextDouble() * charPool.Length);
                    if (charPool[index] != "-")
                    {
                        rs.Append(charPool[index]);
                        charPool[index] = "-";
                    }
                    else
                        length++;
                }
                return rs.ToString();
            }
            catch (Exception ex)
            {
                //ErrorLog.WriteErrorLog("Barcode", ex.ToString(), ex.Message);  
            }
            return "";
        }

        [Authorize(Roles = "Ntpc Employee,Admin")]
        // GET: EmployeeMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployeeMasters == null)
            {
                return NotFound();
            }

            var employeeMaster = await _context.EmployeeMasters.FindAsync(id);
            if (employeeMaster == null)
            {
                return NotFound();
            }
            return View(employeeMaster);
        }


        [Authorize(Roles = "Ntpc Employee,Admin")]
        // POST: EmployeeMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeVtccertificateNo,EmployeeName,EmployeeFathersName,EmployeeDesignation,EmployeeBatchNo,EmployeeDateOfBirth,EmployeeStartDate,EmployeeEndDate,EmployeeAadharNo,Address,FormANo,IMENo,EmployeeIMEDate, EmergencyMobileNumber,MobileNumber,BloodGroup,IdCardNo,VtcNo, EmployeeNo,ImageFileData ,Image,SignatureData,Signature,AuthoritySignature,VtcCertificate,FormO,FormA,BarcodeImageData,BarcodeImage,Barcode")] EmployeeMaster employeeMaster)
        {
            if (id != employeeMaster.EmployeeVtccertificateNo)
            {
                return NotFound();
            }
            /*string? uniqueImageFileName = null;
            string? uniqueSignatureFileName = null;
            if (employeeMaster.Image != null && employeeMaster.Signature != null)
            {
                string ImageUploadedFolder = Path.Combine(webhostEnvironment.WebRootPath, "UploadedImages");
                uniqueImageFileName = Guid.NewGuid().ToString() + "_" + employeeMaster.Image.FileName;
                string filePath = Path.Combine(ImageUploadedFolder, uniqueImageFileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    employeeMaster.Image.CopyTo(filestream);
                }

                employeeMaster.ImageFilePath = "~/wwwroot/UploadedImages";
                employeeMaster.ImageFileName = uniqueImageFileName;

                string SignatureUploadedFolder = Path.Combine(webhostEnvironment.WebRootPath, "UploadedSignature");
                uniqueSignatureFileName = Guid.NewGuid().ToString() + "_" + employeeMaster.Signature.FileName;
                string filePath1 = Path.Combine(ImageUploadedFolder, uniqueSignatureFileName);
                using (var filestream = new FileStream(filePath1, FileMode.Create))
                {
                    employeeMaster.Signature.CopyTo(filestream);
                }

                employeeMaster.SignatureFilePath = "~/wwwroot/UploadedSignature";
                employeeMaster.SignatureFileName = uniqueSignatureFileName;
            }*/
            _context.Attach(employeeMaster);
            byte[]? bytes6 = null;

            if (employeeMaster.Image != null)
            {

                using (Stream filestream = employeeMaster.Image.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(filestream))
                    {
                        bytes6 = br.ReadBytes((Int32)filestream.Length);
                    }
                }

                employeeMaster.ImageFileData = Convert.ToBase64String(bytes6, 0, bytes6.Length);
            }
            else
            {
                _context.Entry(employeeMaster).Property(x => x.ImageFileData).IsModified = false;
            }



            byte[]? bytes7 = null;

             if (employeeMaster.Signature != null)
             {

                 using (Stream filestream = employeeMaster.Signature.OpenReadStream())
                 {
                     using (BinaryReader br = new BinaryReader(filestream))
                     {
                         bytes7 = br.ReadBytes((Int32)filestream.Length);
                     }
                 }

                 employeeMaster.SignatureData = Convert.ToBase64String(bytes7, 0, bytes7.Length);

             }
            else
            {
                _context.Entry(employeeMaster).Property(x => x.SignatureData).IsModified = false;
            }

          
        byte[]? bytes = null;

             if (employeeMaster.AuthoritySignature != null)
             {

                 using (Stream filestream = employeeMaster.AuthoritySignature.OpenReadStream())
                 {
                     using (BinaryReader br = new BinaryReader(filestream))
                     {
                         bytes = br.ReadBytes((Int32)filestream.Length);
                     }
                 }

                 employeeMaster.AuthoritySignatureData = Convert.ToBase64String(bytes, 0, bytes.Length);

             }
             else
             {
                 _context.Entry(employeeMaster).Property(x => x.AuthoritySignatureData).IsModified = false;
             }


             byte[]? bytes1 = null;

             if (employeeMaster.VtcCertificate != null)
             {

                 using (Stream filestream = employeeMaster.VtcCertificate.OpenReadStream())
                 {
                     using (BinaryReader br = new BinaryReader(filestream))
                     {
                         bytes1 = br.ReadBytes((Int32)filestream.Length);
                     }
                 }

                 employeeMaster.VtcCertificateData = Convert.ToBase64String(bytes1, 0, bytes1.Length);


             }
             else
             {

                _context.Entry(employeeMaster).Property(x => x.VtcCertificateData).IsModified = false;
             }



             byte[]? bytes2 = null;

             if (employeeMaster.FormO != null)
             {

                 using (Stream filestream = employeeMaster.FormO.OpenReadStream())
                 {
                     using (BinaryReader br = new BinaryReader(filestream))
                     {
                         bytes2 = br.ReadBytes((Int32)filestream.Length);
                     }
                 }

                 employeeMaster.FormOData = Convert.ToBase64String(bytes2, 0, bytes2.Length);


             }
             else
             {

                 _context.Entry(employeeMaster).Property(x => x.FormOData).IsModified = false;
             }



             byte[]? bytes3 = null;

             if (employeeMaster.FormA != null)
             {

                 using (Stream filestream = employeeMaster.FormA.OpenReadStream())
                 {
                     using (BinaryReader br = new BinaryReader(filestream))
                     {
                         bytes3 = br.ReadBytes((Int32)filestream.Length);
                     }
                 }

                 employeeMaster.FormAData = Convert.ToBase64String(bytes3, 0, bytes3.Length);


             }
             else
             {

                 _context.Entry(employeeMaster).Property(x => x.FormAData).IsModified = false;
             }

             

            if (ModelState.IsValid)
            {
                try
                {


                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeMasterExists(employeeMaster.EmployeeVtccertificateNo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeMaster);
        }


        [Authorize(Roles = "Admin")]
        // GET: EmployeeMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployeeMasters == null)
            {
                return NotFound();
            }

            var employeeMaster = await _context.EmployeeMasters
                .FirstOrDefaultAsync(m => m.EmployeeVtccertificateNo == id);
            if (employeeMaster == null)
            {
                return NotFound();
            }

            return View(employeeMaster);
        }

        [Authorize(Roles = "Admin")]

        // POST: EmployeeMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployeeMasters == null)
            {
                return Problem("Entity set 'EmployeeMasterContext.EmployeeMasters'  is null.");
            }
            var employeeMaster = await _context.EmployeeMasters.FindAsync(id);
            if (employeeMaster != null)
            {
                _context.EmployeeMasters.Remove(employeeMaster);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeMasterExists(int id)
        {
          return (_context.EmployeeMasters?.Any(e => e.EmployeeVtccertificateNo == id)).GetValueOrDefault();
        }
    }
}

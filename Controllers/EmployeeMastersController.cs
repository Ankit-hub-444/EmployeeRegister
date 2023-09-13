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
        [Authorize(Roles = "Ntpc Employee,Admin")]
        public async Task<IActionResult> Index()
        {
              return _context.EmployeeMasters != null ? 
                          View(await _context.EmployeeMasters.ToListAsync()) :
                          Problem("Entity set 'EmployeeMasterContext.EmployeeMasters'  is null.");
        }

        // GET: EmployeeMasters/Details/5
        [Authorize(Roles = "Ntpc Employee,Admin")]
        public async Task<IActionResult> Details(int? id)
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
        public async Task<IActionResult> Create([Bind("EmployeeVtccertificateNo,EmployeeName,EmployeeFathersName,EmployeeDesignation,EmployeeBatchNo,EmployeeStartDate,EmployeeEndDate,EmployeeAadharNo,Address,IMENo,EmployeeIMEDate,MobileNumber,BloodGroup,IdCardNo,VtcNo, EmployeeNo,ImageFilePath,ImageFileName,Image,SignatureFilePath,SignatureFileName,Signature")] EmployeeMaster employeeMaster)
        {

            string? uniqueImageFileName = null;
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
                if (ModelState.IsValid)
                {
                    _context.Add(employeeMaster);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }


            return View(employeeMaster);
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
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeVtccertificateNo,EmployeeName,EmployeeFathersName,EmployeeDesignation,EmployeeBatchNo,EmployeeStartDate,EmployeeEndDate,EmployeeAadharNo,Address,IMENo,EmployeeIMEDate,MobileNumber,BloodGroup,IdCardNo,VtcNo, EmployeeNo,ImageFilePath,ImageFileName,Image,SignatureFilePath,SignatureFileName,Signature")] EmployeeMaster employeeMaster)
        {
            if (id != employeeMaster.EmployeeVtccertificateNo)
            {
                return NotFound();
            }
            string? uniqueImageFileName = null;
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
            }

                    if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeMaster);
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

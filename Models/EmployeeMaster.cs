using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRegister.Models
{
    public class EmployeeMaster
    {
        [Key]
        public int EmployeeVtccertificateNo { get; set; }

        [DisplayName("Name")]
        public string EmployeeName { get; set; } = null!;

        [DisplayName("Father's Name")]

        public string? EmployeeFathersName { get; set; }

        [DisplayName("Designation")]

        public string? EmployeeDesignation { get; set; }

        [DisplayName("Batch No")]

        public int? EmployeeBatchNo { get; set; }

        [DisplayName("Date of Birth")]

        public DateTime? EmployeeDateOfBirth { get; set; }

        [DisplayName("End Date")]

        public DateTime? EmployeeStartDate { get; set; }

        [DisplayName("End Date")]

        public DateTime? EmployeeEndDate { get; set; }

        [DisplayName("Aadhar Number")]

        public string? EmployeeAadharNo { get; set; }

        [DisplayName("Address")]

        public string? Address { get; set; }


        [DisplayName("FormA No")]

        public string? FormANo { get; set; }

        [DisplayName("IME No")]

        public string? IMENo { get; set; }

        [DisplayName("IME Date")]

        public DateTime? EmployeeIMEDate { get; set; }


        [DisplayName("Mobile Number")]

        public string? MobileNumber { get; set; }

        [DisplayName("Emergency Mobile Number")]

        public string? EmergencyMobileNumber { get; set; }

        [DisplayName("Blood Group")]

        public string? BloodGroup { get; set; }
        [DisplayName("ID Card No")]

        public string? IdCardNo { get; set; }
        [DisplayName("Vtc No")]

        public string? VtcNo { get; set; }

        [DisplayName("Employee No")]

        public string? EmployeeNo { get; set; }


        public string? ImageFileData { get; set; }

        [NotMapped]
        [DisplayName("Profile Picture")]

        public IFormFile? Image { get; set; }

        public string? SignatureData { get; set; }

        [NotMapped]
        [DisplayName("Upload Signature File")]

        public IFormFile? Signature { get; set; } 

        public string? AuthoritySignatureData { get; set; }

        [NotMapped]
        [DisplayName("Upload Issuing Authority's Signature File")]
        public IFormFile? AuthoritySignature { get; set; }

        public string? VtcCertificateData { get; set; }
        [NotMapped]
        [DisplayName("Upload  Vtc Certificate File")]
        public IFormFile? VtcCertificate { get; set; }


        public string? FormOData { get; set; }
        [NotMapped]
        [DisplayName("Upload FormO File")]
        public IFormFile? FormO { get; set; }

        public string? FormAData { get; set;}
        [NotMapped]
        [DisplayName("Upload FormA File")]
        public IFormFile? FormA { get; set; }

        public string? BarcodeImageData { get; set; }
        [NotMapped]
        [DisplayName("Barcode Image File")]
        public IFormFile? BarcodeImage { get; set; }
        public string? Barcode { get; set; }


       
    }
}

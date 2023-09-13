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

        [DisplayName("Start Date")]

        public DateTime? EmployeeStartDate { get; set; }

        [DisplayName("End Date")]

        public DateTime? EmployeeEndDate { get; set; }

        [DisplayName("Aadhar Number")]

        public string? EmployeeAadharNo { get; set; }

        [DisplayName("Address")]

        public string? Address { get; set; }

        [DisplayName("IME No")]

        public string? IMENo { get; set; }

        [DisplayName("IME Date")]

        public DateTime? EmployeeIMEDate { get; set; }


        [DisplayName("Mobile Number")]

        public string? MobileNumber { get; set; }
        [DisplayName("Blood Group")]

        public string? BloodGroup { get; set; }
        [DisplayName("ID Card No")]

        public string? IdCardNo { get; set; }
        [DisplayName("Vtc No")]

        public string? VtcNo { get; set; }

        [DisplayName("Employee No")]

        public string? EmployeeNo { get; set; }

        public string? ImageFilePath { get; set; }

        public string? ImageFileName { get; set; }

        [NotMapped]
        [DisplayName("Profile Picture")]

        public IFormFile Image { get; set; } = null!;



        public string? SignatureFilePath { get; set; }

        public string? SignatureFileName { get; set; }

        [NotMapped]
        [DisplayName("Upload Signature File")]

        public IFormFile Signature { get; set; } = null!;
    }
}

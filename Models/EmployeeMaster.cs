using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRegister.Models
{
    public class EmployeeMaster
    {
        [Key]
     public int EmployeeVtccertificateNo { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string? EmployeeFathersName { get; set; }

    public string? EmployeeDesignation { get; set; }

    public int? EmployeeBatchNo { get; set; }

    public DateTime? EmployeeStartDate { get; set; }

    public DateTime? EmployeeEndDate { get; set; }

    public long? EmployeeAadharNo { get; set; }

    public string? ImageFilePath { get; set; }

    public string? ImageFileName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]

    public IFormFile Image { get; set; } = null!;
    }
}

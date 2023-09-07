using System.ComponentModel.DataAnnotations;

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


    }
}

using EmployeeRegister.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
public partial class EmployeeMasterContext : IdentityDbContext
{
    public EmployeeMasterContext()
    {
    }

    public EmployeeMasterContext(DbContextOptions<EmployeeMasterContext> options) : base(options)
    {
    }

    /*public virtual DbSet<Employee> Employees { get; set; }*/

    public virtual DbSet<EmployeeMaster> EmployeeMasters { get; set; }

    public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
    /*internal Task SaveChangesAsync()
    {
        //throw new NotImplementedException();
       
    }

    internal void Update(EmployeeMaster employeeMaster)
    {
        throw new NotImplementedException();
    }*/

    /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
         if (!optionsBuilder.IsConfigured)
         {
             //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
             //  => optionsBuilder.UseSqlServer("Server=DESKTOP-NGAK86L\\SQLEXPRESS;Database=EmployeeMaster;TrustServerCertificate=True;Trusted_Connection=True;");
         }
     }*/

}

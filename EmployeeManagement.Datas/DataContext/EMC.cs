using EmployeeManagement.Datas.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Datas.DataContext
{
    public class EMC : IdentityDbContext  //db bağlantısı için . 

    {
        public EMC(DbContextOptions options )
             : base(options)
        {
            
        }
        public DbSet<Employee> Employee { get; set; } // db ye veri girişi yada veri alma
        public DbSet<EmployeeLeaveAllocation> EmployeeLeaveAllocations { get; set; }
        public DbSet<EmployeeLeaveRequest> EmployeeLeaveRequests   { get; set; }
        public DbSet<EmployeeLeaveType> EmployeeLeaveTypes { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagement.Datas.DbModels
{
    public  class EmployeeLeaveAllocation : BaseEntity
    {
        //employee tablosuyla birleştirdik.Çalışana ne kadar izin tanımlanmış onu tutuyor.

        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public int Period { get; set; }

        
        public string EmployeeId { get; set; } 
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } // employee tablosuyla iletişime geçiyor

        public int EmployeeLeaveTypeId { get; set; }
        [ForeignKey("EmployeeLeaveTypeId")]
        public EmployeeLeaveType EmployeeLeaveType { get; set; }


    }
}

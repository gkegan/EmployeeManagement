

using System;

namespace EmployeeManagement.Datas.DbModels
{
   public class EmployeeLeaveType : BaseEntity
    {
        public string  Name { get; set; }
        public int DefaultDays { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
    }
}

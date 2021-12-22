using AutoMapper;
using EmployeeManagement.Common.VModels;
using EmployeeManagement.Datas.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Common.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<EmployeeLeaveType, EmployeeLeaveTypeVM>().ReverseMap();
            //hangi classı hangi classa dönüştüreceğini istiyor bizden
            CreateMap<EmployeeLeaveAllocation, EmployeeLeaveAllocationsVM>().ReverseMap();
            CreateMap<EmployeeLeaveRequest, EmployeeLeaveRequestVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();


        }
    }
}

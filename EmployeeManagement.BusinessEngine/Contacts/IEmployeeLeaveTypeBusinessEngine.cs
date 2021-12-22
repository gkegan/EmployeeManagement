using EmployeeManagement.Common.ResultModels;
using EmployeeManagement.Common.VModels;
using EmployeeManagement.Datas.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.BusinessEngine.Contacts
{
    public interface IEmployeeLeaveTypeBusinessEngine
    {
        Result<List<EmployeeLeaveTypeVM>> GetAllEmployeeLeaveTypes();
        /// <summary>
        /// New Employee Leave Type Create method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Result<EmployeeLeaveTypeVM> CreateEmployeeLeaveType(EmployeeLeaveTypeVM model);
        Result<EmployeeLeaveTypeVM> GetAllEmployeeLeaveType(int id);
        Result<EmployeeLeaveTypeVM> EditEmployeeLeaveType(EmployeeLeaveTypeVM model);
        Result<EmployeeLeaveTypeVM> RemoveEmployeeLeaveType(int id);

    }
}


using EmployeeManagement.Datas.Contracts;
using EmployeeManagement.Datas.DataContext;
using EmployeeManagement.Datas.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Datas.Implementation
{
    public class EmployeeLeaveTypeRepository : Repository<EmployeeLeaveType>, IEmployeeLeaveTypeRepository
    {
        private readonly EMC _ctx;
        public EmployeeLeaveTypeRepository(EMC ctx)
            :base (ctx)
        {

        }
    }
}

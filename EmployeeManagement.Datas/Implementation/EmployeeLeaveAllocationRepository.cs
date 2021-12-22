using EmployeeManagement.Datas.Contracts;
using EmployeeManagement.Datas.DataContext;
using EmployeeManagement.Datas.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EmployeeManagement.Datas.Implementation
{
    

    public class EmployeeLeaveAllocationRepository : Repository<EmployeeLeaveAllocation>, IEmployeeLeaveAllocationRepository
    {
        private readonly EMC _ctx;
        public EmployeeLeaveAllocationRepository(EMC ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}

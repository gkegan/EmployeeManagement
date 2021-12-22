using EmployeeManagement.Datas.Contracts;
using EmployeeManagement.Datas.DataContext;
using EmployeeManagement.Datas.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Datas.Implementation
{
   public  class EmployeeLeaveRequestRepository : Repository<EmployeeLeaveRequest> , IEmployeeLeaveRequestRepository
    {
        private readonly EMC _ctx;
        public EmployeeLeaveRequestRepository(EMC ctx )
            :base(ctx)
        {

        }
    }
}

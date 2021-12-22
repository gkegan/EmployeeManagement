
using EmployeeManagement.Datas.Contracts;
using EmployeeManagement.Datas.DataContext;
using EmployeeManagement.Datas.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Datas.Implementation
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly EMC _ctx;
        public EmployeeRepository(EMC ctx)
            :base (ctx)
        {

        }
    }
}

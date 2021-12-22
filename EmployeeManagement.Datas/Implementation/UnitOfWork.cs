using EmployeeManagement.Datas.Contracts;
using EmployeeManagement.Datas.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Datas.Implementation
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly EMC _ctx;
        public UnitOfWork(EMC ctx)
        {
            _ctx = ctx;
            EmployeeLeaveAllocation = new EmployeeLeaveAllocationRepository(_ctx);
            EmployeeLeaveRequestRepository = new EmployeeLeaveRequestRepository(_ctx);
            EmployeeLeaveTypeRepository = new EmployeeLeaveTypeRepository(_ctx);
            EmployeeRepository = new EmployeeRepository(_ctx);

        }
        public IEmployeeLeaveAllocationRepository EmployeeLeaveAllocation { get; private set; }
        public IEmployeeLeaveRequestRepository EmployeeLeaveRequestRepository { get; private set; }
        public IEmployeeLeaveTypeRepository EmployeeLeaveTypeRepository { get; private set; }
        public IEmployeeRepository EmployeeRepository { get; private set; }


        public void Dispose()
        {
            _ctx.Dispose();
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}

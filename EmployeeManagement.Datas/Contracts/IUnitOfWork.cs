using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Datas.Contracts
{
   public interface IUnitOfWork : IDisposable
    {
       IEmployeeLeaveAllocationRepository EmployeeLeaveAllocation { get;  }
       IEmployeeLeaveRequestRepository EmployeeLeaveRequestRepository { get; }
       IEmployeeLeaveTypeRepository EmployeeLeaveTypeRepository { get;  }
        void Save();
        IEmployeeRepository EmployeeRepository { get; }

    }
}

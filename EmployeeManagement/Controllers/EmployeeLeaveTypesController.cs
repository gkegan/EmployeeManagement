using EmployeeManagement.BusinessEngine.Contacts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class EmployeeLeaveTypesController : Controller
    {
        private readonly IEmployeeLeaveTypeBusinessEngine _EmployeeLeaveTypeBusinessEngine;
        public EmployeeLeaveTypesController(IEmployeeLeaveTypeBusinessEngine EmployeeLeaveTypeBusinessEngine)
        {
            _EmployeeLeaveTypeBusinessEngine = EmployeeLeaveTypeBusinessEngine;
        }
        public IActionResult Index()
        {
            var data = _EmployeeLeaveTypeBusinessEngine.GetAllEmployeeLeaveTypes();
            if(data.IsSuccess)
            {
                var Result = data.Data;
                return View(Result);
            }
            return View();
        }
    }
}

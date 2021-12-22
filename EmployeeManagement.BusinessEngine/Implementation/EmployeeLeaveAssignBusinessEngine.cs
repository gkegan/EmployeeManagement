
using AutoMapper;

using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.Common.ConstantModels;
using EmployeeManagement.Common.ConstantsModels;
using EmployeeManagement.Common.ResultModels;
using EmployeeManagement.Datas.Contracts;
using EmployeeManagement.Datas.DbModels;

using System;

namespace EmployeeManagement.BusinessEngine.Implementaion
{
    public class EmployeeLeaveAssignBusinessEngine : IEmployeeLeaveAssignBusinessEngine
    {
        #region Variables
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public EmployeeLeaveAssignBusinessEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        #endregion

        #region CustomMethods

        public Result<bool> ApprovedEmployeeRequest(int id)
        {
            if (id > 0)
            {
                try
                {
                    var data = _unitOfWork.EmployeeLeaveRequestRepository.GetFirstorDefault(u => u.Id == id);
                    if (data != null)
                    {
                        EmployeeLeaveAllocation createModel = new EmployeeLeaveAllocation();
                        createModel.DateCreated = DateTime.Now;
                        createModel.EmployeeId = data.RequestingEmployeeId;
                        createModel.EmployeeLeaveTypeId = data.EmployeeLeaveTypeId;
                        var day = (data.EndDate.Day - data.StartDate.Day);
                        createModel.NumberOfDays = day < 0 ? -day : day;
                        createModel.Period = 1;
                        _unitOfWork.EmployeeLeaveAllocation.Add(createModel);
                    }

                    data.Approved = (int)EnumEmployeeLeaveRequestStatus.Approved;
                    _unitOfWork.EmployeeLeaveRequestRepository.Update(data);
                    _unitOfWork.Save();
                    return new Result<bool>(true, ResultConstant.RecordCreatedSuccessfully);
                }
                catch (Exception ex)
                {
                    return new Result<bool>(false, ResultConstant.RecordCreateNotSuccesfully + "=>" + ex.Message.ToString());
                }
            }
            else
                return new Result<bool>(false, "Parametre Olarak Geçilen Data Boş Olamaz!");
        }

        #endregion
    }
}

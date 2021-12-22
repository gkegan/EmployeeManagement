using AutoMapper;
using EmployeeManagement.BusinessEngine.Contacts;
using EmployeeManagement.Common.ConstantModels;
using EmployeeManagement.Common.ResultModels;
using EmployeeManagement.Common.VModels;
using EmployeeManagement.Datas.Contracts;
using EmployeeManagement.Datas.DbModels;
using EmployeeManagement.Datas.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagement.BusinessEngine.Implementation
{
    public class EmployeeLeaveTypeBusinessEngine : IEmployeeLeaveTypeBusinessEngine
    {

        #region Variables
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public EmployeeLeaveTypeBusinessEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }


        #endregion

        #region CustomMethods

        public Result<List<EmployeeLeaveTypeVM>> GetAllEmployeeLeaveTypes()
        {
            var data = _unitOfWork.EmployeeLeaveTypeRepository.GetAll(e => e.IsActive== true).ToList();

            #region 1.yöntem
            //if(data != null)
            //{
            //    List<EmployeeLeaveType> returnData = new List<EmployeeLeaveType>();
            //    foreach (var item in data)
            //    {
            //        returnData.Add(new EmployeeLeaveType());
            //        {

            //        }
            //    }
            //    return new Result<List<EmployeeLeaveType>>(true, ResultConstant.RecordFound, returnData);
            //}
            //else return new Result<List<EmployeeLeaveType>>(false, ResultConstant.RecordNotFound); 
            #endregion

            var leaveTypes = _mapper.Map<List<EmployeeLeaveType>, List<EmployeeLeaveTypeVM>>(data);
            return new Result<List<EmployeeLeaveTypeVM>>(true, ResultConstant.RecordFound, leaveTypes);
        }

        public Result<EmployeeLeaveTypeVM> CreateEmployeeLeaveType(EmployeeLeaveTypeVM model)
        {
            if (model != null)
            {
                try
                {
                    var leaveType = _mapper.Map<EmployeeLeaveTypeVM, EmployeeLeaveType>(model);
                    leaveType.DateCreated = DateTime.Now;
                    leaveType.IsActive = true;
                    _unitOfWork.EmployeeLeaveTypeRepository.Add(leaveType);
                    _unitOfWork.Save();
                    return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordCreatedSuccessfully);
                }
                catch (Exception ex)
                {

                    return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordCreateNotSuccesfully + "" + ex.Message.ToString());
                }
            }
            else
            {
                return new Result<EmployeeLeaveTypeVM>(false, "Parametre olarak geçilen data boş olamaz");
            }
        }


      public  Result<EmployeeLeaveTypeVM> GetAllEmployeeLeaveType(int id) 
        {
            var data = _unitOfWork.EmployeeLeaveTypeRepository.Get(id);
            if (data!=null)
            {
                var leaveType = _mapper.Map<EmployeeLeaveType, EmployeeLeaveTypeVM>(data);
                return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordFound,leaveType);
            }
            else
            {
                return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordNotFound);
            }
        }
        #endregion

        public Result<EmployeeLeaveTypeVM> EditEmployeeLeaveType(EmployeeLeaveTypeVM model)
        {
            if (model != null)
            {
                try
                {
                    var leaveType = _mapper.Map<EmployeeLeaveTypeVM, EmployeeLeaveType>(model);
                    _unitOfWork.EmployeeLeaveTypeRepository.Update(leaveType);
                    _unitOfWork.Save();
                    return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordCreatedSuccessfully);
                }
                catch (Exception ex)
                {

                    return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordCreateNotSuccesfully + "" + ex.Message.ToString());
                }
            }
            else
            {
                return new Result<EmployeeLeaveTypeVM>(false, "Parametre olarak geçilen data boş olamaz");
            }
        }
        public Result<EmployeeLeaveTypeVM> RemoveEmployeeLeaveType(int id)
        {
            var data = _unitOfWork.EmployeeLeaveTypeRepository.Get(id);
            if (data !=null)
            {
                data.IsActive = false;
                _unitOfWork.EmployeeLeaveTypeRepository.Update(data);
                _unitOfWork.Save();
                return new Result<EmployeeLeaveTypeVM>(true, ResultConstant.RecordCreatedSuccessfully);
            }
            else
            {
                return new Result<EmployeeLeaveTypeVM>(false, ResultConstant.RecordCreateNotSuccesfully);
            }
        }



    }

   
}

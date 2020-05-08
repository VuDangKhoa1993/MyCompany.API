using MyCompany.API.Response;
using MyCompany.Core.Models.Entities;
using MyCompany.Core.Repositories;
using MyCompany.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _unitOfWork.Department.GetAllAsync();
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsByEmployeeIdAsync(int employeeId)
        {
            return await _unitOfWork.Department.GetAllWithEmployeeId(employeeId);
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _unitOfWork.Department.FindAsync(id);
        }
        public async Task<DepartmentResponse> CreateAsync(Department department)
        {
            try
            {
                await _unitOfWork.Department.AddAsync(department);
                await _unitOfWork.CompleteAsync();
                return new DepartmentResponse(department);
            }
            catch (Exception ex)
            {
                return new DepartmentResponse($"An error occurred while saving the department: {ex.Message}");
            }
        }

        public async Task<DepartmentResponse> UpdateAsync(int id, Department department)
        {
            var departmentToBeUpdated = await _unitOfWork.Department.FindAsync(id);
            if (departmentToBeUpdated == null)
            {
                return new DepartmentResponse("Department isn't found");
            }

            departmentToBeUpdated.DepartmentName = department.DepartmentName;

            try
            {
                _unitOfWork.Department.Update(departmentToBeUpdated);
                await _unitOfWork.CompleteAsync();
                return new DepartmentResponse(departmentToBeUpdated);
            }
            catch(Exception ex)
            {
                return new DepartmentResponse($"An error occurred when updating the department: {ex.Message}");
            }
        }

        public async Task<DepartmentResponse> DeleteAsync(int id)
        {
            var departmentToBeDeleted = await _unitOfWork.Department.FindAsync(id);
            if (departmentToBeDeleted == null)
            {
                return new DepartmentResponse("Department isn't found");
            }

            try
            {
                _unitOfWork.Department.Remove(departmentToBeDeleted);
                await _unitOfWork.CompleteAsync();
                return new DepartmentResponse(departmentToBeDeleted);
            }
            catch(Exception ex)
            {
                return new DepartmentResponse($"An error occurred when deleting the department: {ex.Message}");
            }
        }
    }
}

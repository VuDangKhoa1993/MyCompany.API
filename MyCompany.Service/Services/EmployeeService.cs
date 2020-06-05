using MyCompany.Core.Models.Entities;
using MyCompany.Core.Repositories;
using MyCompany.Core.Services;
using MyCompany.Core.Services.Communication.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _unitOfWork.Employee.GetAllEmployeeAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesByDepartmentIdAsync(int departmentId)
        {
            return await _unitOfWork.Employee.GetEmployeeByDepartmentId(departmentId);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _unitOfWork.Employee.GetEmployeeByIdAsync(id);
        }

        public async Task<EmployeeResponse> CreateAsync(Employee employee)
        {
            try
            {
                await _unitOfWork.Employee.AddAsync(employee);
                await _unitOfWork.CompleteAsync();
                return new EmployeeResponse(employee);
            }
            catch(Exception ex)
            {
                return new EmployeeResponse($"An error occurred while saving the employee: {ex.Message}");
            }
        }

        public async Task<EmployeeResponse> DeleteAsync(int id)
        {
            var employee = await _unitOfWork.Employee.FindAsync(id);
            if (employee == null) return new EmployeeResponse($"Employee isn't found");
            try
            {
                _unitOfWork.Employee.Remove(employee);
                await _unitOfWork.CompleteAsync();
                return new EmployeeResponse(employee);
            }
            catch(Exception ex)
            {
                return new EmployeeResponse($"An error occurred when deleting the department: {ex.Message}");
            }
        }

        public async Task<EmployeeResponse> UpdateAsync(int id, Employee employee)
        {
            var emp = await _unitOfWork.Employee.FindAsync(id);
            if (emp == null) return new EmployeeResponse("Can't find provided employee id");
            emp.Birthday = employee.Birthday;
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.Salaries = employee.Salaries;
            emp.Gender = employee.Gender;
            emp.HiredDate = employee.HiredDate;
            emp.Titles = employee.Titles;
            try
            {
                await _unitOfWork.CompleteAsync();
                return new EmployeeResponse(emp);
            }
            catch(Exception ex)
            {
                return new EmployeeResponse($"An error occurred when updating the employee : {ex.Message}");
            }
        }
    }
}

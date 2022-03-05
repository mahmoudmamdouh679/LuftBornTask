using LuftBornTask.Domain.Entities;
using LuftBornTask.Domain.Helpers;
using LuftBornTask.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuftBornTask.Services.IServices
{
    public interface IEmployeeService
    {
        PagingList<Employee> GetEmployees(PagingDataDto data);
        Employee GetEmployee(long employeeId);
        Employee GetEmployeeByLoggedInUser(string userId);
        //PagingList<Employee> GetEmployeeForDepartment(long departmentId, PagingDataDto data);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(long employeeId);
    }
}

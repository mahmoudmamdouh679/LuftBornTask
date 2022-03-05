using LuftBornTask.Domain;
using LuftBornTask.Domain.Entities;
using LuftBornTask.Domain.Helpers;
using LuftBornTask.Services.Dto;
using LuftBornTask.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuftBornTask.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDBContext _context;

        public EmployeeService(ApplicationDBContext context)
        {
            _context = context;
        }

        public PagingList<Employee> GetEmployees(PagingDataDto data)
        {
            try
            {
                var employees = _context.Employees.AsNoTracking()
                .Where(a => !a.IsDeleted);
                //.Include(a => a.Department) as IQueryable<Employee>;
                return PagingList<Employee>.Create(employees, data.PageNumber, data.PageSize);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Employee GetEmployee(long employeeId)
        {
            try
            {
                return _context.Employees
                //.Include(a => a.Department)
                .FirstOrDefault(a => a.EmployeeId == employeeId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Employee GetEmployeeByLoggedInUser(string userId)
        {
            try
            {
                return _context.Employees
                //.Include(a => a.Department)
                //.FirstOrDefault(a => a.UserId == userId && !a.IsDeleted);
                .FirstOrDefault(a => !a.IsDeleted);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public PagingList<Employee> GetEmployeeForDepartment(long departmentId, PagingDataDto data) 
        //{
        //    try
        //    {
        //        var employees = _context.Employees
        //        .Where(a => a.DepartmentId == departmentId && !a.IsDeleted)
        //        .Include(a => a.Department) as IQueryable<Employee>;

        //        return PagingList<Employee>.Create(employees, data.PageNumber, data.PageSize);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public void CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
        }

        public void DeleteEmployee(long employeeId)
        {
            var employee = _context.Employees.Find(employeeId);
            if (employee != null)
            {

                employee.DeletedEmpId = employeeId;
                employee.DeletedDate = DateTime.UtcNow;
                employee.IsDeleted = !employee.IsDeleted;
                _context.Employees.Update(employee);
            }
        }
    }
}

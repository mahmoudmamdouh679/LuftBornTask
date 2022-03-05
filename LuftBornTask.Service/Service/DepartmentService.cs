using LuftBornTask.Domain;
using LuftBornTask.Domain.Entities;
using LuftBornTask.Domain.Helpers;
using LuftBornTask.Services.Dto;
using LuftBornTask.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftBornTask.Services.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDBContext _context;

        public DepartmentService(ApplicationDBContext context)
        {
            _context = context;
        }
        public PagingList<Department> GetDepartments(PagingDataDto data)
        {
            var departments = _context.Departments.Where(a => !a.IsDeleted);
            return PagingList<Department>.Create(departments, data.PageNumber, data.PageSize);
        }

        public Department GetDepartment(long departmentId)
        {
            return _context.Departments.FirstOrDefault(a => a.DepartmentId == departmentId && !a.IsDeleted);
        }

        public IEnumerable<Department> GetDepartmentForBranch(long branchId) 
        {
            return _context.Departments.Where(department => department.BranchId == branchId && !department.IsDeleted).ToList();
        }

        public void CreateDepartment(Department department)
        {
            _context.Departments.AddAsync(department);
        }

        public void UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
        }

        public void DeleteDepartment(long departmentId)
        {
            var department = _context.Departments.Find(departmentId);
            if (department != null)
            {
                department.IsDeleted = !department.IsDeleted;
                _context.Departments.Update(department);
            }
        }
    }
}

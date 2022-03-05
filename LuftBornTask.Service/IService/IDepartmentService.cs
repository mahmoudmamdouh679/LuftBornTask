using LuftBornTask.Domain.Entities;
using LuftBornTask.Domain.Helpers;
using LuftBornTask.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LuftBornTask.Services.IServices
{
    public interface IDepartmentService
    {
        PagingList<Department> GetDepartments(PagingDataDto data);
        Department GetDepartment(long departmentId);
        IEnumerable<Department> GetDepartmentForBranch(long branchId);
        void CreateDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(long departmentId);
    }
}

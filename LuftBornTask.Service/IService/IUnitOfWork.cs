using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LuftBornTask.Services.IServices
{
    public interface IUnitOfWork
    {
        ICompanyService CompanyService { get; }
        IBranchService BranchService { get; }
        IDepartmentService DepartmentService { get; }
        IEmployeeService EmployeeService { get; }
        
        bool Commit();
    }
}

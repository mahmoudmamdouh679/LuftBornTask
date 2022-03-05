using LuftBornTask.Domain;
using LuftBornTask.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LuftBornTask.Services.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        
        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }


        private ICompanyService _companyService;
        private IBranchService _branchService;
        private IDepartmentService _departmentService;
        private IEmployeeService _employeeService;
        

        public ICompanyService CompanyService 
        { 
            get { return _companyService ??= new CompanyService(_context); }
        }

        public IBranchService BranchService 
        { 
            get { return _branchService ??= new BranchService(_context); }
        }

        public IDepartmentService DepartmentService 
        { 
            get { return _departmentService ??= new DepartmentService(_context); }
        }

        public IEmployeeService EmployeeService 
        { 
            get { return _employeeService ??= new EmployeeService(_context); } 
        }

        public bool Commit() => _context.SaveChanges() > 0;
    }
}

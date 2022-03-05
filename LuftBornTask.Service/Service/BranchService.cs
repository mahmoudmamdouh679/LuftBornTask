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
    public class BranchService : IBranchService
    {
        private readonly ApplicationDBContext _context;

        public BranchService(ApplicationDBContext context)
        {
            _context = context;
        }

        public PagingList<Branch> GetBranches(PagingDataDto data)
        {
            var branches = _context.Branches.Where(a => !a.IsDeleted);
            return PagingList<Branch>.Create(branches, data.PageNumber, data.PageSize);
        }

        public Branch GetBranch(long branchId)
        {
            return _context.Branches.FirstOrDefault(a => a.BranchId == branchId && !a.IsDeleted);
        }

        public IEnumerable<Branch> GetBranchForCompany(long companyId) 
        {
            return _context.Branches.Where(branch => branch.CompanyId == companyId && !branch.IsDeleted).ToList();
        }

        public void CreateBranch(Branch branch)
        {
            _context.Branches.AddAsync(branch);
        }

        public void UpdateBranch(Branch branch)
        {
            _context.Branches.Update(branch);
        }

        public void DeleteBranch(long branchId)
        {
            var branch = _context.Branches.Find(branchId);
            if (branch != null)
            {
                branch.IsDeleted = !branch.IsDeleted;
                _context.Branches.Update(branch);
            }
        }
    }
}

using LuftBornTask.Domain.Entities;
using LuftBornTask.Domain.Helpers;
using LuftBornTask.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LuftBornTask.Services.IServices
{
    public interface IBranchService
    {
        PagingList<Branch> GetBranches(PagingDataDto data);
        Branch GetBranch(long branchId);
        IEnumerable<Branch> GetBranchForCompany(long companyId);
        void CreateBranch(Branch branch);
        void UpdateBranch(Branch branch);
        void DeleteBranch(long branchId);
    }
}

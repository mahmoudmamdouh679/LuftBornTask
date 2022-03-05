using LuftBornTask.Domain.Entities;
using LuftBornTask.Domain.Helpers;
using LuftBornTask.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuftBornTask.Services.IServices
{
    public interface ICompanyService
    {
        PagingList<Company> GetCompanies(PagingDataDto data);
        Company GetCompany(long companyId);
        void CreateCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(long companyId);
    }
}

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
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDBContext _context;

        public CompanyService(ApplicationDBContext context)
        {
            _context = context;
        }

        public PagingList<Company> GetCompanies(PagingDataDto data)
        {
            try
            {
                var companies = _context.Companies.Where(a => !a.IsDeleted);
                return PagingList<Company>.Create(companies, data.PageNumber, data.PageSize);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Company GetCompany(long companyId)
        {
            try
            {
                return _context.Companies.FirstOrDefault(a => a.CompanyId == companyId && !a.IsDeleted);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CreateCompany(Company company)
        {
            _context.Companies.Add(company);
        }

        public void UpdateCompany(Company company)
        {
           _context.Companies.Update(company);
        }

        public void DeleteCompany(long companyId)
        {
            var company = _context.Companies.Find(companyId);
            if (company != null)
            {
                company.IsDeleted = !company.IsDeleted;
                _context.Companies.Update(company);
            }
        }
    }
}

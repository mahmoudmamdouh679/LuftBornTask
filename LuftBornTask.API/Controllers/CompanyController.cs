using AutoMapper;
using LuftBornTask.Domain.Entities;
using LuftBornTask.Services.Dto;
using LuftBornTask.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LuftBornTask.Api.Controllers
{
    [Route("api/company")]
    public class CompanyController : MainController
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public CompanyController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<CompanyDto>> GetCompanies([FromQuery] PagingDataDto paging)
        {
            var companies = _context.CompanyService.GetCompanies(paging);
            var companiesMap = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return Ok(companiesMap);
        }

        [HttpPost("{CompanyId}")]
        public ActionResult<CompanyDto> GetCompany(long companyId)
        {
            var company = _context.CompanyService.GetCompany(companyId);
            var companyMap = _mapper.Map<CompanyDto>(company);
            return Ok(companyMap);
        }

        [HttpPost()]
        public IActionResult CreateCompany(CompanyDto company)
        {
            var companyMap = _mapper.Map<Company>(company);
            _context.CompanyService.CreateCompany(companyMap);

            var success = _context.Commit();
            if (!success)
                return BadRequest("something went wrong!");

            return Ok();
        }

        [HttpPut()]
        public IActionResult UpdateCompany(CompanyDto company)
        {
            var companyMap = _mapper.Map<Company>(company);
            _context.CompanyService.UpdateCompany(companyMap);

            var success = _context.Commit();
            if (!success)
                return BadRequest("something went wrong!");

            return Ok();
        }

        [HttpDelete("{CompanyId}")]
        public IActionResult DeleteCompany(long companyId)
        {
            _context.CompanyService.DeleteCompany(companyId);

            var success = _context.Commit();
            if (!success)
                return BadRequest("something went wrong!");

            return Ok();
        }
    }
}

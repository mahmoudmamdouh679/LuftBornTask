using AutoMapper;
using LuftBornTask.Domain.Entities;
using LuftBornTask.Services.Dto;
using LuftBornTask.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LuftBornTask.Api.Controllers
{
    [Route("api/company")]
    public class DepartmentController : MainController
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<DepartmentDto>> GetDepartments([FromQuery] PagingDataDto paging)
        {
            var departments = _context.DepartmentService.GetDepartments(paging);
            var departmentsMap = _mapper.Map<IEnumerable<DepartmentDto>>(departments);
            return Ok(departmentsMap);
        }

        [HttpPost("{CompanyId}")]
        public ActionResult<DepartmentDto> GetDepartment(long departmentId)
        {
            var department = _context.DepartmentService.GetDepartment(departmentId);
            var departmentMap = _mapper.Map<DepartmentDto>(department);
            return Ok(departmentMap);
        }

        [HttpPost()]
        public IActionResult CreateDepartment(DepartmentDto department)
        {
            var departmentMap = _mapper.Map<Department>(department);
            _context.DepartmentService.CreateDepartment(departmentMap);

            var success = _context.Commit();
            if (!success)
                return BadRequest("something went wrong!");

            return Ok();
        }

        [HttpPut()]
        public IActionResult UpdateDepartment(DepartmentDto department)
        {
            var departmentMap = _mapper.Map<Department>(department);
            _context.DepartmentService.UpdateDepartment(departmentMap);

            var success = _context.Commit();
            if (!success)
                return BadRequest("something went wrong!");

            return Ok();
        }

        [HttpDelete("{branchId}")]
        public IActionResult DeleteDepartment(long departmentId)
        {
            _context.DepartmentService.DeleteDepartment(departmentId);

            var success = _context.Commit();
            if (!success)
                return BadRequest("something went wrong!");

            return Ok();
        }
    }
}

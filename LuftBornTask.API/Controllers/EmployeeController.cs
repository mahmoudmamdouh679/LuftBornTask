using AutoMapper;
using LuftBornTask.Domain.Entities;
using LuftBornTask.Services.Dto;
using LuftBornTask.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LuftBornTask.Api.Controllers
{
    [Route("/api/employee")]
    public class EmployeeController : MainController
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //[Authorize(Roles = "SuperAdmin,Admin,Hr")]
        [HttpGet()]
        public ActionResult<IEnumerable<EmployeeDto>> GetEmployees([FromQuery] PagingDataDto paging)
        {
            var employees = _context.EmployeeService.GetEmployees(paging);
            var data = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return Ok(data);
        }

        //[Authorize(Roles = "SuperAdmin,Admin,Hr")]
        [HttpPost("{employeeId}")]
        public ActionResult<EmployeeDto> GetEmployee(long employeeId)
        {
            var employee = _context.EmployeeService.GetEmployee(employeeId);
            var data = _mapper.Map<EmployeeDto>(employee);

            return Ok(data);
        }

        ////[Authorize(Roles = "SuperAdmin,Admin,Hr")]
        //[HttpGet("/department/{departmentId}")]
        //public ActionResult<EmployeeDto> GetEmployeesByDepartment(long departmentId, [FromQuery] PagingDataDto paging)
        //{
        //    var empByDep = _context.EmployeeService.GetEmployeeForDepartment(departmentId,paging);
        //    var data = _mapper.Map<EmployeeDto>(empByDep);
        //    return Ok(data);
        //}

        //[Authorize(Roles = "SuperAdmin,Admin,Hr")]
        [HttpPost()]
        public IActionResult CreateEmployee(EmployeeDto employee)
        {
            var emp = _mapper.Map<Employee>(employee);
            emp.CreatedDate = DateTime.UtcNow;
            _context.EmployeeService.CreateEmployee(emp);

            var success = _context.Commit();
            if (!success)
                return BadRequest("something went wrong!");

            return Ok();
        }

        //[Authorize(Roles = "SuperAdmin,Admin,Hr")]
        [HttpPut()]
        public IActionResult UpdateEmployee(EmployeeDto employee)
        {
            var emp = _mapper.Map<Employee>(employee);
            emp.UpdatedDate = DateTime.UtcNow;
            _context.EmployeeService.UpdateEmployee(emp);

            var success = _context.Commit();
            if (!success)
                return BadRequest("something went wrong!");
            
            return Ok();
        }

        //[Authorize(Roles = "SuperAdmin,Admin")]
        [HttpDelete("{Id}")]
        public IActionResult DeleteEmployee(long Id)
        {
            _context.EmployeeService.DeleteEmployee(Id);

            var success = _context.Commit();
            if (!success)
                return BadRequest("something went wrong!");

            return Ok();
        }
    }
}

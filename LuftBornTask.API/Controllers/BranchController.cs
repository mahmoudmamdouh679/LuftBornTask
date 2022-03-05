using AutoMapper;
using LuftBornTask.Domain.Entities;
using LuftBornTask.Services.Dto;
using LuftBornTask.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LuftBornTask.Api.Controllers
{
    [Route("api/company")]
    public class BranchController : MainController
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public BranchController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<BranchDto>> GetBranches([FromQuery] PagingDataDto paging)
        {
            var branches = _context.BranchService.GetBranches(paging);
            var branchesMap = _mapper.Map<IEnumerable<BranchDto>>(branches);
            return Ok(branchesMap);
        }

        [HttpPost("{CompanyId}")]
        public ActionResult<BranchDto> GetBranch(long branchId)
        {
            var branch = _context.BranchService.GetBranch(branchId);
            var branchMap = _mapper.Map<BranchDto>(branch);
            return Ok(branchMap);
        }

        [HttpPost()]
        public IActionResult CreateBranch(BranchDto branch)
        {
            var branchMap = _mapper.Map<Branch>(branch);
            _context.BranchService.CreateBranch(branchMap);

            var success = _context.Commit();
            if (!success)
                return BadRequest("something went wrong!");

            return Ok();
        }

        [HttpPut()]
        public IActionResult UpdateBranch(BranchDto branch)
        {
            var branchMap = _mapper.Map<Branch>(branch);
            _context.BranchService.UpdateBranch(branchMap);

            var success = _context.Commit();
            if (!success)
                return BadRequest("something went wrong!");

            return Ok();
        }

        [HttpDelete("{branchId}")]
        public IActionResult DeleteBranch(long branchId)
        {
            _context.BranchService.DeleteBranch(branchId);

            var success = _context.Commit();
            if (!success)
                return BadRequest("something went wrong!");

            return Ok();
        }
    }
}

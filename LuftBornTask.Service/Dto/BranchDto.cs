using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Services.Dto
{
    public class BranchDto
    {
        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string DefaultPhoneNumber { get; set; }
        public string DefaultEmail { get; set; }
        public List<DepartmentDto> Departments { get; set; }
    }
}

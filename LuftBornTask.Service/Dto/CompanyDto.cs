using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Services.Dto
{
    public class CompanyDto
    {
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string DefaultPhoneNumber { get; set; }
        public string DefaultEmail { get; set; }
        public bool IsDeleted { get; set; }
    }
}

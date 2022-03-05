using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LuftBornTask.Domain.Entities
{
    public class Company : BaseEntity
    {
        [Key]
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string DefaultPhoneNumber { get; set; }
        public string DefaultEmail { get; set; }


        public virtual ICollection<Branch> Branches { get; set; }
    }
}

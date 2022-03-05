using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LuftBornTask.Domain.Entities
{
    public class Branch : BaseEntity
    {
        [Key]
        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string DefaultPhoneNumber { get; set; }
        public string DefaultEmail { get; set; }

        public long CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}

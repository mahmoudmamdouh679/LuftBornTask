using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LuftBornTask.Domain.Entities
{
    public class Department : BaseEntity
    {
        [Key]
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DefaultPhoneNumber { get; set; }
        public string DefaultEmail { get; set; }

        public long BranchId { get; set; }
        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }


        public virtual ICollection<Employee> Employees { get; set; }
    }
}

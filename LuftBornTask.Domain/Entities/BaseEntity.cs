using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Domain.Entities
{
    public class BaseEntity
    {
        public DateTime? CreatedDate { get; set; }
        public long? CreatedEmpId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdatedEmpId { get; set; }
        public DateTime? DeletedDate { get; set; }
        public long? DeletedEmpId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

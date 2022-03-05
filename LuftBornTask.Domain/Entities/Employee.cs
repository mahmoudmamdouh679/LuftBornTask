using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuftBornTask.Domain.Entities
{
    public class Employee : BaseEntity
    {
        [Key]
        public long EmployeeId { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "NationalId should be a 14 digits number"), StringLength(14), MinLength(14)]
        public string NationalId { get; set; }
        //public DateTime BirthDate { get; set; }
        //public bool Gender { get; set; } = true; //true = male , false = female
        //public DateTime HiringDate { get; set; } = DateTime.Now;
        //public string DefaultPhoneNumber { get; set; }
        //[RegularExpression(@"[\w-\.]+@([\w-]+\.)+[\w-]{2,4}")]
        //public string DefaultEmail { get; set; }
        //public string ProfileImage { get; set; }
        //public string DefaultAddress { get; set; }
        
        //public long? DepartmentId { get; set; }
        //[ForeignKey("DepartmentId")]
        //public virtual Department Department { get; set; }
        //public string UserId { get; set; }
        //[ForeignKey("UserId")]
        //public virtual ApplicationUser User { get; set; }
    }
}

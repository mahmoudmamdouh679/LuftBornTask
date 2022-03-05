using AutoMapper;
using LuftBornTask.Domain.Entities;
using LuftBornTask.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPApplication.Api.MapProfile
{
    public class HRProfile : Profile
    {
        public HRProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                //.ForMember(des => des.DepartmentName,
                //opt => opt.MapFrom(src => src.Department.DepartmentName))
                .ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Branch, BranchDto>().ReverseMap();
        }
    }
}

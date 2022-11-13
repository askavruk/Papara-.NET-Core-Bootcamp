using AutoMapper;
using PaparaRepositoryPattern.Domain.Entities;
using PaparaRepositoryPattern.Services.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaRepositoryPattern.Services.Automapper
{
    public class MyMapper : Profile
    {
        public MyMapper()
        {
            CreateMap<Company, CreateCompanyDTO>().ReverseMap();
            CreateMap<Company, UpdateCompanyDTO>().ReverseMap();
            CreateMap<Company, GetCompanyDTO>().ReverseMap();
        }
    }
}

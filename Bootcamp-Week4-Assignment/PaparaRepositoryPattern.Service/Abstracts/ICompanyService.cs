using PaparaRepositoryPattern.Domain.Entities;
using PaparaRepositoryPattern.Services.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaRepositoryPattern.Services.Abstracts
{
    public interface ICompanyService
    {
        Task Create(CreateCompanyDTO createCompany);
        void Update(UpdateCompanyDTO updateCompany, int id);
        Task Delete(int id);
        Task<GetCompanyDTO> GetById(int id);
        Task<List<GetCompanyDTO>> GetAllCompanies();
    }
}

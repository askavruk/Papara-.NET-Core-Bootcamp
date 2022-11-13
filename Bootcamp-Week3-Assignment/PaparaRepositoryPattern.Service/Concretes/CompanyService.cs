using AutoMapper;
using PaparaRepositoryPattern.Data.Abstarcts;
using PaparaRepositoryPattern.Domain.Entities;
using PaparaRepositoryPattern.Services.Abstracts;
using PaparaRepositoryPattern.Services.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaRepositoryPattern.Services.Concretes
{
    public class CompanyService : ICompanyService
    {
        private readonly IBaseRepository<Company> _baseRepository;
        private readonly IMapper _mapper;

        public CompanyService(IBaseRepository<Company> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateCompanyDTO createCompany)
        {
            var company = _mapper.Map<Company>(createCompany);
            await _baseRepository.Create(company);
        }

        public async Task Delete(int id)
        {
            var companyToDelete = await _baseRepository.GetById(x => x.Id == id);
            _baseRepository.Delete(companyToDelete);
        }

        public async Task<GetCompanyDTO> GetById(int id)
        {
            var company = await _baseRepository.GetById(x => x.Id == id);
            return _mapper.Map<GetCompanyDTO>(company);
        }

        public async Task<List<GetCompanyDTO>> GetAllCompanies()
        {
            var companiesList = await _baseRepository.GetAll();
            List<GetCompanyDTO> companiesDtoList = new List<GetCompanyDTO>();
            foreach (Company company in companiesList)
            {
                GetCompanyDTO getCompanyDTO = new();
                _mapper.Map(company, getCompanyDTO);
                companiesDtoList.Add(getCompanyDTO);
            }
            return companiesDtoList;
        }

        public void Update(UpdateCompanyDTO updateCompany, int id)
        {
            var companyToUpdate = _mapper.Map<Company>(updateCompany);
            updateCompany.Id = id;
            _baseRepository.Update(companyToUpdate);
        }
    }
}
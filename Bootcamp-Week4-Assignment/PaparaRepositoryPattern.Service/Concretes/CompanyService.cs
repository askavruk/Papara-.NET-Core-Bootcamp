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
        private readonly ICompanyDapperRepository _companyDapperRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyDapperRepository companyDapperRepository, IMapper mapper)
        {
            _companyDapperRepository = companyDapperRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateCompanyDTO createCompany)
        {
            var company = _mapper.Map<Company>(createCompany);
            await _companyDapperRepository.Add(company);
        }

        public async Task Delete(int id)
        {
            var companyToDelete = await _companyDapperRepository.GetById(id);
            if (companyToDelete is null)
                throw new ArgumentException("Id not found");
            await _companyDapperRepository.Delete(id);
        }

        public async Task<GetCompanyDTO> GetById(int id)
        {
            var company = await _companyDapperRepository.GetById(id);
            return _mapper.Map<GetCompanyDTO>(company);
        }

        public async Task<List<GetCompanyDTO>> GetAllCompanies()
        {
            var companiesList = await _companyDapperRepository.GetAll();
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
            _companyDapperRepository.Update(companyToUpdate);
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaparaRepositoryPattern.Services.Abstracts;
using PaparaRepositoryPattern.Services.Concretes;
using PaparaRepositoryPattern.Services.Models.DTOs;
using System.Threading.Tasks;

namespace PaparaRepositoryPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("CompaniesList")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companiesList = await _companyService.GetAllCompanies();
            return Ok(companiesList);

        }

        [HttpGet("GetCompany")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _companyService.GetById(id);
            return Ok(company);

        }

        [HttpPost("CreateCompany")]
        public async Task<IActionResult> CreateCompany(CreateCompanyDTO createCompany)
        {
            await _companyService.Create(createCompany);
            return Ok();

        }
        [HttpPut("UpdateCompany")]
        public IActionResult UpdateCompany(UpdateCompanyDTO updateCompany, int id)
        {
            _companyService.Update(updateCompany,id);
            return Ok();
        }
        [HttpDelete("DeleteCompany")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _companyService.Delete(id);
            return Ok();
        }
    }
}

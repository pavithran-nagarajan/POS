using pos.application.DTOs.Company;
using pos.application.Interfaces;
using pos.domain.Entities;
using pos.domain.Interfaces;

namespace pos.application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;

        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Company> CreateCompany(CreateCompanyDTO createCompanyDTO)
        {
            var company = new Company
            {
                CompanyName = createCompanyDTO.CompanyName,
                IsActive = createCompanyDTO.IsActive,
                CreatedBy = createCompanyDTO.CreatedBy,
                CreatedDateTime = DateTime.UtcNow
            };

            return await _repository.CreateCompany(company);
        }
    }
}

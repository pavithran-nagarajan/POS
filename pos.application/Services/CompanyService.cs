using AutoMapper;
using pos.application.DTOs.Company;
using pos.application.DTOs.UserAccount;
using pos.application.Interfaces;
using pos.domain.Entities;
using pos.domain.Interfaces;

namespace pos.application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseCompanyDTO> CreateCompany(CreateCompanyDTO createCompanyDTO)
        {
            var company = _mapper.Map<Company>(createCompanyDTO);
            company.CreatedDateTime = DateTime.UtcNow;

            var created = await _repository.CreateCompany(company);
            return _mapper.Map<ResponseCompanyDTO>(created);
        }
    }
}

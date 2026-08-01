using pos.application.DTOs.Company;
using pos.domain.Entities;

namespace pos.application.Interfaces
{
    public interface ICompanyService
    {
        Task<Company> CreateCompany(CreateCompanyDTO createCompanyDTO);
    }
}

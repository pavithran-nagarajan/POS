using pos.domain.Entities;

namespace pos.domain.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> CreateCompany(Company company);
    }
}

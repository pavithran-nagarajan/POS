using pos.application.DTOs.Company;

namespace pos.application.Interfaces
{
    public interface ICompanyService
    {
        Task<ResponseCompanyDTO> CreateCompany(CreateCompanyDTO createCompanyDTO);
    }
}

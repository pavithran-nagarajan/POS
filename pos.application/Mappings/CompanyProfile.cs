using AutoMapper;
using pos.application.DTOs.Company;
using pos.domain.Entities;

namespace pos.application.Mappings
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CreateCompanyDTO, Company>();
            CreateMap<Company, ResponseCompanyDTO>();
        }
    }
}
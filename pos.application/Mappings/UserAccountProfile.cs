using AutoMapper;
using pos.application.DTOs.UserAccount;
using pos.domain.Entities;

namespace pos.application.Mappings
{
    public class UserAccountProfile : Profile
    {
        public UserAccountProfile()
        {
            CreateMap<CreateUserAccountDTO, UserAccount>();
            CreateMap<UserAccount, ResponseUserAccountDTO>();
        }
    }
}

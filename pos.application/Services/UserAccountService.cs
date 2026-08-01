using AutoMapper;
using pos.application.DTOs.Company;
using pos.application.DTOs.UserAccount;
using pos.application.Interfaces;
using pos.domain.Entities;
using pos.domain.Interfaces;

namespace pos.application.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAccountRepository _repository;
        private readonly IMapper _mapper;

        public UserAccountService(IUserAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseUserAccountDTO> CreateUser(CreateUserAccountDTO createUserAccountDTO)
        {
            var user = _mapper.Map<UserAccount>(createUserAccountDTO);
            user.CreatedDateTime = DateTime.UtcNow;

            var created = await _repository.CreateUser(user);
            return _mapper.Map<ResponseUserAccountDTO>(created);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using pos.application.DTOs.UserAccount;
using pos.application.Interfaces;

namespace pos.api.admin.Controllers.Master
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;

        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserAccountDTO createUserAccountDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userAccountService.CreateUser(createUserAccountDTO);
            return CreatedAtAction(nameof(Create), new { id = result.UserGuid }, result);
        }
    }
}

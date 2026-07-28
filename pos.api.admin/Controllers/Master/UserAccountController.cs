using Microsoft.AspNetCore.Mvc;
using pos.application.DTOs;
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
        public async Task<IActionResult> Create([FromBody] UserAccountDTO userAccountDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userAccountService.CreateUser(userAccountDTO);
            return CreatedAtAction(nameof(Create), new { id = result.UserId }, result);
        }
    }
}

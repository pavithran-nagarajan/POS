using Microsoft.AspNetCore.Mvc;
using pos.application.DTOs.Company;
using pos.application.Interfaces;

namespace pos.api.admin.Controllers.Master
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyDTO createCompanyDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _companyService.CreateCompany(createCompanyDTO);
            return CreatedAtAction(nameof(Create), new { id = result.CompanyGuid }, result);
        }
    }
}

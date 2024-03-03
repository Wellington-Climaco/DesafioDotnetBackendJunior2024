using Application.DTOs;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace TesteBackendEnContact.Controllers
{
    [ApiController]
    [Route("v1/company/")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IContactBookService _contactBookService;

        public CompanyController(ICompanyService companyService,IContactBookService contactBook)
        {
            _companyService = companyService;
            _contactBookService = contactBook;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var companies = await _companyService.GetAll();
                if (!companies.Any()) return NotFound("Companies NotFound");
                return Ok(companies);
            }
            catch
            {
                return StatusCode(500, "internal error");
            }
        }

        [HttpGet("getById{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");

            var result = await _companyService.GetById(id);

            if (result == null) return NotFound("Company NotFound");
            return Ok(result);

        }

        [HttpPost("Create")]
        public async Task<IActionResult> AddCompany([FromBody] CompanyDTO companyDTO)
        {
            try
            {                   
                var contactBook = _contactBookService.CreateWithCompany(companyDTO);

                var contactBookName = _contactBookService.FindByName(companyDTO.Name);
                companyDTO.ContactBookId = contactBookName.Result.Id;

                if(companyDTO.Name == null) return BadRequest("Enter a name");
                await _companyService.Create(companyDTO);
                return Ok(companyDTO);
            }
            catch
            {
                return StatusCode(500, "internal error");
            }            
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdateCompany(int id,UpdateCompanyDTO companyDTO)
        {
            try
            {
                var company = await _companyService.GetById(id);
                if (company == null) return NotFound("Company NotFound");

                await _companyService.Update(id,companyDTO);
                return Ok(companyDTO);
            }
            catch(DbUpdateException)
            {
                return StatusCode(500, "cant update this");
            }
            catch
            {
                return StatusCode(500, "internal error");
            }
        }

        [HttpDelete("remove/{id:int}")]
        public async Task<IActionResult> RemoveCompany(int id)
        {
            try
            {
                var company = await _companyService.GetById(id);
                if (company == null) return NotFound("Company NotFound");

                await _companyService.Remove(company);
                return Ok("Company Removed");
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "cant remove this");
            }
            catch
            {
                return StatusCode(500, "internal error");
            }
        }

        [HttpGet("CompanyContacts/{companyName}")]
        public async Task<IActionResult> FindContatsOfCompany(string companyName)
        {
            try
            {
                if (string.IsNullOrEmpty(companyName)) return BadRequest("Invalid Name");

                var result = await _companyService.FindCompanyContacts(companyName);
                return Ok(result);
              
            }
            catch
            {
                return StatusCode(500, "internal error");
            }
        }




    }
}

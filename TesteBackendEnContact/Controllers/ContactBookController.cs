using Application.DTOs;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Domain;

namespace TesteBackendEnContact.Controllers
{
    [ApiController]
    [Route("v1/[controller]/")]
    public class ContactBookController : ControllerBase
    {
        private readonly IContactBookService _contactBookService;

        public ContactBookController(IContactBookService contactBookService)
        {
            _contactBookService = contactBookService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _contactBookService.GetAll();
                if (result == null) return NotFound("ContactBooks NotFound");
                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "internal error");
            }
        }

        [HttpGet("getById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _contactBookService.GetById(id);
                if (result == null) return NotFound("ContactBook NotFound");

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "internal error");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ContactBookDTO contactBookDTO)
        {
            try
            {
                await _contactBookService.Create(contactBookDTO);
                return Ok(contactBookDTO);
            }
            catch(DbUpdateException)
            {
                return StatusCode(500, "cant create this");
            }
            catch
            {
                return StatusCode(500, "internal error");
            }
        }

        [HttpDelete("remove/{id:int}")]
        public async Task<IActionResult> Remove( int id)
        {
            try
            {
                var contactBook = await _contactBookService.GetById(id);
                if (contactBook == null) return NotFound("ContactBook NotFound");

                await _contactBookService.Remove(contactBook);
                return Ok("ContactBook Removed");

            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "cant create this");
            }
            catch
            {
                return StatusCode(500, "internal error");
            }
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateContactBookDTO contactBookDTO)
        {
            try
            {
                var contactBook = await _contactBookService.GetById(id);
                if (contactBook == null) return NotFound("ContactBook NotFound");
                contactBookDTO.Id = contactBook.Id;
                
                await _contactBookService.Update(contactBookDTO);
                return Ok(contactBookDTO);

            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "cant create this");
            }
            catch
            {
                return StatusCode(500, "internal error");
            }
        }

    }
}

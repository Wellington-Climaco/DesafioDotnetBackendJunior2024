
using Application.DTOs;
using Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace TesteBackendEnContact.Controllers
{
    [ApiController]
    [Route("v1/Contact/")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }


        [HttpPost]
        [Route("ImportContact")]
        public async Task<IActionResult> ImportContacts(IFormFile file)
        {
            try
            {
                await _contactService.Add(file);
                return Ok("Sucesfull import");
            }
            catch
            {
                return StatusCode(500, "internal error");
            }
                       
        }

        [HttpGet("ById/{id:int}")]
        public async Task<IActionResult> getById([FromRoute] int id)
        {
            try
            {
                var contact = await _contactService.GetById(id);
                if (contact == null) return NotFound("Contact Notfound");
                return Ok(contact);
            }
            catch 
            { 
                return StatusCode(500, "internal error");
            }           
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var contact = await _contactService.GetAll();
                if (contact == null) return NotFound("Contact NotFound");
                return Ok(contact);
            }
            catch
            {
                return StatusCode(500, "internal error");
            }
        }


        [HttpDelete("Remove")]
        public async Task<IActionResult> RemoveContact(int Id)
        {
            try
            {
                var contact = _contactService.GetById(Id);
                if (contact.Result == null) return NotFound("Contact NotFound");

                await _contactService.Remove(Id);
                return Ok("Contact Removed");
            }
            catch(DbUpdateException)
            {
                return StatusCode(500, "cant remove this");
            }
            catch
            {
                return StatusCode(500, "internal error");
            }
            
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateContact(int Id,[FromBody] UpdateContactDTO updateContactDTO)
        {
            try
            {
                var contact = await _contactService.GetById(Id);
                if (contact == null) return NotFound("Contact NotFound");

                await _contactService.Update(updateContactDTO,Id);
                return Ok(updateContactDTO);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "cant update this");
            }
            catch
            {
                return StatusCode(500, "internal error");
            }

        }

        [HttpGet("Seach/{word}/{page:int}/{take:int}")]
        public async Task<IActionResult> SearchContacts(string word,int page,int take)
        {
            try
            {                
                var result = await _contactService.SearchContact(word);
                var total = result.Count();

                result = result.Skip((page-1)*take).Take(take);
                
                if (!result.Any()) return NotFound("nothing found");

                return Ok(new { total, CurrentPage = page, take,result});
            }
            catch 
            {
                return StatusCode(500, "internal error");
            }
        }


    }
}

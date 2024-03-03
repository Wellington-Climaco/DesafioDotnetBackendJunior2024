using Application.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDTO>> GetAll();

        Task<ContactDTO> GetById(int id);

        Task Add(IFormFile file);

        Task Update(UpdateContactDTO updateContactDTO,int Id);

        Task Remove(int id);

        Task<IEnumerable<ContactDTO>> SearchContact(string word);

        //int TakeTotal(IEnumerable<ContactDTO> contacts);

        Task<bool> FindByEmail(string email);

    }
}

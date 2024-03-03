using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Domain;

namespace Application.Interface
{
    public interface IContactBookService
    {
        Task<IEnumerable<ContactBookDTO>> GetAll();

        Task<ContactBookDTO> GetById(int id);

        Task CreateWithCompany(CompanyDTO companyDTO);

        Task Create(ContactBookDTO contactBookDTO);

        Task Update(UpdateContactBookDTO contactBookDTO);

        Task Remove(ContactBookDTO contactBookDTO);

        Task<ContactBookDTO> FindByName(string name);

    }
}

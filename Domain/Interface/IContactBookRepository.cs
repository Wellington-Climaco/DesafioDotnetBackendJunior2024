using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Domain;

namespace Domain.Interface
{
    public interface IContactBookRepository
    {
        Task<IEnumerable<ContactBook>> GetAll();

        Task<ContactBook> GetById(int id);

        Task<ContactBook> Create(ContactBook contactBook);

        Task<ContactBook> Update(ContactBook contactBook);

        Task<ContactBook> Remove(ContactBook contactBook);

        Task<IEnumerable<ContactBook>> FindContactsCompany(string name);

        Task<ContactBook> FindByName(string name);

        

    }
}

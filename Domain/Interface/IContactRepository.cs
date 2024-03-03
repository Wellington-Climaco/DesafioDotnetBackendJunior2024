using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Domain;

namespace Domain.Interface
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAll();

        Task<Contact> GetById(int id);

        Task<IEnumerable<Contact>> Create(List<Contact> contacs);

        Task<Contact> Update(Contact contact);

        Task<Contact> Remove(int id);

        Task<IEnumerable<Contact>> Search(string word);

        Task<bool> FindByEmail(string email);

        

    }
}

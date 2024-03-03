using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Domain;

namespace Domain.Interface
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAll();

        Task<Company> GetById(int id);

        Task<Company> Create(Company company);

        Task<Company> Update(Company company);

        Task<Company> Remove(Company company);
       
    }
}

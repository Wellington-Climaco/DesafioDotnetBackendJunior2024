using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDTO>> GetAll();

        Task<CompanyDTO> GetById(int id);

        Task Create(CompanyDTO companyDTO);

        Task Update(int id,UpdateCompanyDTO companyDTO);

        Task Remove(CompanyDTO companyDTO);

        Task<IEnumerable<ContactBooksCompany>> FindCompanyContacts(string name);
    }
}

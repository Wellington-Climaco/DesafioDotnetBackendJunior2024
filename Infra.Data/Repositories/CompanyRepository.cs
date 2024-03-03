
using Domain.Interface;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Domain;


namespace Infra.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IContactBookRepository _contactBook;
        private readonly AppDbContext _context;
        public CompanyRepository(AppDbContext appDbContext, IContactBookRepository contactBook)
        {
            _context = appDbContext;
            _contactBook = contactBook;
        }

     
        public async Task<Company> Create(Company company)
        {           
            _context.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _context.Companys.AsNoTracking().ToListAsync();
        }

        public async Task<Company> GetById(int id)
        {
            return await _context.Companys.AsNoTracking().FirstOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<Company> Remove(Company company)
        {
            _context.Remove(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company> Update(Company company)
        {
            _context.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }
    }
}

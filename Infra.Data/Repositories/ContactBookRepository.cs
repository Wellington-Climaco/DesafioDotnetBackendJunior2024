using Domain.Interface;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Infra.Data.Repositories
{
    public class ContactBookRepository : IContactBookRepository
    {
        private readonly AppDbContext _context;
        public ContactBookRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }


        public async Task<ContactBook> Create(ContactBook contactBook)
        {            
            _context.Add(contactBook);
            await _context.SaveChangesAsync();
            return contactBook;
            
        }

        public async Task<ContactBook> FindByName(string name)
        {
            return await _context.ContactBooks.AsNoTracking().FirstOrDefaultAsync(x=>x.Name.ToLower() == name.ToLower());
        }

        public async Task<IEnumerable<ContactBook>> FindContactsCompany(string name)
        {
            //var result = await _context.ContactBooks.AsNoTracking().Where(c=>c.Name.Contains(name)).SelectMany(contact => contact.Contact).Where(x => x.CompanyId == id).ToListAsync();
            //&& x.Contact.Any(c=>c.CompanyId == id)
            name = name.ToLower();
            var result = await _context.ContactBooks.AsNoTracking().Include(x=>x.Contact).Where(x=>x.Name.ToLower().Contains(name)).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<ContactBook>> GetAll()
        {
            return await _context.ContactBooks.AsNoTracking().ToListAsync();
        }

        public async Task<ContactBook> GetById(int id)
        {
            return await _context.ContactBooks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ContactBook> Remove(ContactBook contactBook)
        {
            _context.Remove(contactBook);
            await _context.SaveChangesAsync();
            return contactBook;
        }

        public async Task<ContactBook> Update(ContactBook contactBook)
        {
            _context.Update(contactBook);
            await _context.SaveChangesAsync();
            return contactBook;
        }
    }
}

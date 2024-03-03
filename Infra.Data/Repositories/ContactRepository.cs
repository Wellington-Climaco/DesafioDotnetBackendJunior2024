using Domain.Interface;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Domain;

namespace Infra.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;
        public ContactRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }


        public async Task<IEnumerable<Contact>> Create(List<Contact> contacs)
        {
            var contactList = contacs;
            foreach(var contact in contactList)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
            }            
            return contactList;    
            
        }

        public async Task<bool> FindByEmail(string email)
        {
            var contact = await _context.Contacts.AsNoTracking().FirstOrDefaultAsync(x=>x.Email.ToLower() == email.ToLower());
            if(contact == null)return false;

            return true;
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetById(int id)
        {
            return await _context.Contacts.AsNoTracking().FirstOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<Contact> Remove(int id)
        {
            var result = GetById(id);
            _context.Remove(result.Result);
            await _context.SaveChangesAsync();
            return await result;
        }

        public async Task<IEnumerable<Contact>> Search(string word)
        {
            word = word.ToLower();
            
            return await _context.Contacts.AsNoTracking().Where(x=> x.Name.ToLower().Contains(word) || x.Email.ToLower().Contains(word) || x.PhoneNumber.ToLower().Contains(word)).ToListAsync();
        }

        public async Task<Contact> Update(Contact contact)
        {
            _context.Update(contact);    
            await _context.SaveChangesAsync();
            return contact;
        }
    }
}

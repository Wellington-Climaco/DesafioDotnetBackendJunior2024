using Application.DTOs;
using Application.Helpers;
using Application.Interface;
using AutoMapper;
using Domain.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Domain;

namespace Application.Services
{

    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public ContactService(IContactRepository contactRepository,IMapper mapper, ICompanyRepository companyRepository)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _companyRepository = companyRepository;

        }

        public async Task Add(IFormFile file)
        {
            var excel = new ExcelHelper<ContactDTO>(file, _companyRepository);
            var contactDTO = excel.GetValues();
            
            for (int i = contactDTO.Count - 1; i >= 0; i--)
            {
                var contact = contactDTO[i];
                var validation = Validation(contact);
                if (!validation)
                {
                    contactDTO.RemoveAt(i);
                }
            }
           
            var contactEntity = _mapper.Map<List<Contact>>(contactDTO);

            await _contactRepository.Create(contactEntity);
        }

        public async Task<bool> FindByEmail(string email)
        {
            var contactEntity = await _contactRepository.FindByEmail(email);
            if (contactEntity) return true;

            return false;
        }

        public async Task<IEnumerable<ContactDTO>> GetAll()
        {
            var contactEntity = await _contactRepository.GetAll();
            return _mapper.Map<IEnumerable<ContactDTO>>(contactEntity);
        }

        public async Task<ContactDTO> GetById(int id)
        {
            var ContactEntity = await _contactRepository.GetById(id);
            return _mapper.Map<ContactDTO>(ContactEntity);
        }

        public async Task Remove(int id)
        {
            await _contactRepository.Remove(id);
        }

        public async Task<IEnumerable<ContactDTO>> SearchContact(string word)
        {
            var contactEntity = await _contactRepository.Search(word);
            return _mapper.Map<IEnumerable<ContactDTO>>(contactEntity);
        }

        public async Task Update(UpdateContactDTO updateContactDTO,int Id)
        {
            var contact = await _contactRepository.GetById(Id);
            contact.UpdateContact(updateContactDTO.Name, updateContactDTO.Email, updateContactDTO.PhoneNumber, updateContactDTO.CompanyId, updateContactDTO.ContactBookId);

            await _contactRepository.Update(contact);
        }

        private bool Validation(ContactDTO contactDTO)
        {
            if (string.IsNullOrWhiteSpace(contactDTO.Name) || string.IsNullOrWhiteSpace(contactDTO.Email) || string.IsNullOrWhiteSpace(contactDTO.PhoneNumber)) return false;
            
            var IfContactExist = FindByEmail(contactDTO.Email);
            if(IfContactExist.Result) return false;

            if (contactDTO.ContactBookId == 0) return false;

            return true;
        }

        //public int TakeTotal(IEnumerable<ContactDTO> contacts)
        //{
        //    return contacts.Count();
        //}
    }
}

using Application.DTOs;
using Application.Interface;
using AutoMapper;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Domain;

namespace Application.Services
{
    public class ContactBookService : IContactBookService
    {
        private readonly IContactBookRepository _contactBookRepository;
        private readonly IMapper _mapper;

        public ContactBookService(IContactBookRepository contactBookRepository, IMapper mapper)
        {
            _contactBookRepository = contactBookRepository;
            _mapper = mapper;
        }

        public async Task Create(ContactBookDTO contactBookDTO)
        {
            var contactBookEntity = _mapper.Map<ContactBook>(contactBookDTO);
            await _contactBookRepository.Create(contactBookEntity);
        }

        public async Task CreateWithCompany(CompanyDTO companyDTO)
        {
            var contactBookEntity = _mapper.Map<ContactBook>(companyDTO);
            await _contactBookRepository.Create(contactBookEntity);
        }

        public async Task<ContactBookDTO> FindByName(string name)
        {
            var contactBookEntity = await _contactBookRepository.FindByName(name);
            return _mapper.Map<ContactBookDTO>(contactBookEntity);
        }

        public async Task<IEnumerable<ContactBookDTO>> GetAll()
        {
            var contactBookEntity = await _contactBookRepository.GetAll();
            return _mapper.Map<IEnumerable<ContactBookDTO>>(contactBookEntity);
        }

        public async Task<ContactBookDTO> GetById(int id)
        {
            var contactBookEntity = await _contactBookRepository.GetById(id);
            return _mapper.Map<ContactBookDTO>(contactBookEntity);
        }

        public async Task Remove(ContactBookDTO contactBookDTO)
        {
            var contactBookEntity = _mapper.Map<ContactBook>(contactBookDTO);
            await _contactBookRepository.Remove(contactBookEntity);

        }

        public async Task Update(UpdateContactBookDTO contactBookDTO)
        {
            var contactBookEntity = _mapper.Map<ContactBook>(contactBookDTO);
            await _contactBookRepository.Update(contactBookEntity);
        }
    }
}

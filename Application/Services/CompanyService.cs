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
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IContactBookRepository _contactBookRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository,IMapper mapper, IContactBookRepository contactBookRepository)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _contactBookRepository = contactBookRepository;

        }

        public async Task Create(CompanyDTO companyDTO)
        {
            var CompanyEntity = _mapper.Map<Company>(companyDTO);
            await _companyRepository.Create(CompanyEntity);
        }

        public async Task<IEnumerable<ContactBooksCompany>> FindCompanyContacts(string name)
        {
            var contactsEntity = await _contactBookRepository.FindContactsCompany(name);
            return _mapper.Map<IEnumerable<ContactBooksCompany>>(contactsEntity);
        }

        public async Task<IEnumerable<CompanyDTO>> GetAll()
        {
            var companyEntity = await _companyRepository.GetAll();
            return _mapper.Map<IEnumerable<CompanyDTO>>(companyEntity);
        }

        public async Task<CompanyDTO> GetById(int id)
        {
            var companyEntity = await _companyRepository.GetById(id);
            return _mapper.Map<CompanyDTO>(companyEntity);
        }

        public async Task Remove(CompanyDTO companyDTO)
        {
            var companyEntity = _mapper.Map<Company>(companyDTO);
            await _companyRepository.Remove(companyEntity);
        }

        public async Task Update(int id, UpdateCompanyDTO companyDTO)
        {
            var company = await _companyRepository.GetById(id);
            company.UpdateCompany(companyDTO.Name);

            await _companyRepository.Update(company);
        }
    }
}

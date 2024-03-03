using Application.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Domain;

namespace Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Company,CompanyDTO>().ReverseMap();
            CreateMap<Contact,ContactDTO>().ForMember(dst => dst.PhoneNumber,map => map.MapFrom(src => src.PhoneNumber)).ReverseMap();
            CreateMap<ContactBook,ContactBookDTO>().ReverseMap();
            CreateMap<ContactBook,CompanyDTO>().ForMember(dst => dst.Name,map => map.MapFrom(src => src.Name)).ReverseMap();
            CreateMap<UpdateContactDTO,Contact>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
            CreateMap<UpdateCompanyDTO, Company>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
            //CreateMap<Company, CompanyContactsDTO>().ReverseMap();
            //CreateMap<Contact, CompanyContactDTO>().ReverseMap();
            CreateMap<ContactBook, ContactBooksCompany>().ReverseMap();
            CreateMap<ContactBook,UpdateContactBookDTO>().ReverseMap();
        }

    }
}

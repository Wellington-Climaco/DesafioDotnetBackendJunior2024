
using System.Collections.Generic;
using TesteBackendEnContact.Core.Validation;

namespace TesteBackendEnContact.Core.Domain
{
    public sealed class Company 
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int ContactBookId { get; set; }
        public ContactBook ContactBook { get; set; }

        public Company()
        {

        }

        public void UpdateCompany(string name)
        {
           if(!string.IsNullOrEmpty(name)) Name = name;
        }


        public Company(string name,int contactBookId)
        {
            ValidateCompany(name, contactBookId);
        }                                                                       

        public void ValidateCompany(string name,int contactbookId)
        {
            DomainValidation.When(string.IsNullOrEmpty(name), "Campo nome é obrigatório");
            DomainValidation.When(contactbookId <= 0, "É necessário uma lista de contatos");

            Name = name;
            ContactBookId = contactbookId;
        }

        
    }
}

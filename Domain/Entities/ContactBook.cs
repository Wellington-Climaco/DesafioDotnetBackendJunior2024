using System.Collections.Generic;
using TesteBackendEnContact.Core.Validation;

namespace TesteBackendEnContact.Core.Domain
{
    public sealed class ContactBook
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Contact> Contact { get; set; }
        public List<Company> Company { get; set; }

        public ContactBook()
        {
            
        }

        public ContactBook(int id, string name)
        {

            Id = id;
            Name = name;
        }

        public ContactBook(string name)
        {
            DomainValidation.When(string.IsNullOrEmpty(name), "Campo nome é obrigatório");
        }
    }
}

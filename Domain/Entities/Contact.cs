using TesteBackendEnContact.Core.Validation;

namespace TesteBackendEnContact.Core.Domain
{
    public sealed class Contact
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public int CompanyId { get;  set; }

        public int ContactBookId {  get;  set; }
        public ContactBook ContactBook { get; set; }


        public Contact()
        {
            
        }

        public Contact(string name, string email, string phoneNumber, int companyId, int contactBookId)
        {
            ValidateContact(name, email,phoneNumber, contactBookId);
            CompanyId = companyId;
        }

        public void UpdateContact(string name, string email, string phoneNumber, int? companyId, int? contactBookId)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Name = name;
            }

            if (!string.IsNullOrEmpty(email))
            {
                Email = email;
            }

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                PhoneNumber = phoneNumber;
            }

            if(companyId > 0) 
            {
                CompanyId = (int)companyId;
            }

            if (contactBookId > 0)
            {
                ContactBookId = (int)contactBookId;
            }


        }

        public void ValidateContact(string name, string email,string phoneNumber, int contactBookId)
        {
            DomainValidation.When(string.IsNullOrEmpty(name), "Campo nome é obrigatório");
            DomainValidation.When(string.IsNullOrEmpty(email), "Campo email é obrigatório");
            DomainValidation.When(string.IsNullOrEmpty(phoneNumber), "Campo numero de telefone é obrigatório");
            DomainValidation.When(contactBookId <= 0, "Agenda inválida");


            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            ContactBookId = contactBookId;
        }

    }
}

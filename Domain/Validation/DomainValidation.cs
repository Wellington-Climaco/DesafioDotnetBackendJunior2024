using System;

namespace TesteBackendEnContact.Core.Validation
{
    public class DomainValidation : Exception
    {
        public DomainValidation(string error) : base(error)
        {
            
        }

        public static void When (bool HasError,string erro)
        {
            if (HasError)
            {
                throw new DomainValidation(erro);
            }
        }

    }
}

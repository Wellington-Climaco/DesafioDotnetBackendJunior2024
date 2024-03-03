using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Domain;

namespace Application.DTOs
{
    public class UpdateContactDTO
    {
        public int Id { get; private set; }

        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }


        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }


        [RegularExpression(@"^(1[1-9]|2[12478]|3([1-5]|[7-8])|4[1-9]|5(1|[3-5])|6[1-9]|7[134579]|8[1-9]|9[1-9])9[0-9]{8}$", ErrorMessage = "PhoneNumber invalid, ex:11909821250")]
        public string PhoneNumber { get; set; }

        [Range(1, int.MaxValue)]
        public int? CompanyId { get; set; }

        [Range(1, int.MaxValue)]
        public int? ContactBookId { get; set; }

    }
}

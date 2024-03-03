using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Domain;
using System.Text.Json.Serialization;

namespace Application.DTOs
{
    public class CompanyDTO
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [JsonIgnore]
        public int ContactBookId { get; set; }

        [JsonIgnore]
        public ContactBook ContactBook { get; set; }
    }
}

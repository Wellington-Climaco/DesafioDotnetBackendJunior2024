using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateCompanyDTO
    {
        [JsonIgnore]
        public int Id { get; private set; }

        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}

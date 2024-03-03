//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Text.Json.Serialization;
//using System.Threading.Tasks;
//using TesteBackendEnContact.Core.Domain;

//namespace Application.DTOs
//{
//    public class CompanyContactsDTO
//    {
//        [JsonIgnore]
//        public int Id { get; set; }

//        [Required(ErrorMessage = "The Name is Required")]
//        [MinLength(3)]
//        [MaxLength(100)]
//        public string Name { get; set; }
        
//        public int ContactBookId { get; set; }
        
//        public string ContactBook { get; set; }

//        public List<Contact> contacts { get; set; }
//    }
//}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ContactBooksCompany
    {

        public int Id { get;  set; }

        public string Name { get;  set; }

        public List<ContactDTO> Contact { get; set; }
    }
}

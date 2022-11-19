using PaparaRepositoryPattern.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaRepositoryPattern.Services.Models.DTOs
{
    public class CreateCompanyDTO
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string TaxNumber { get; set; }
        public string Email { get; set; }
        //public DateTime CreationDate => DateTime.Now;
        //public Status Status => Status.Active;
    }
}

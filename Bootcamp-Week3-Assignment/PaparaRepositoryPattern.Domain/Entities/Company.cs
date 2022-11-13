using PaparaRepositoryPattern.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaRepositoryPattern.Domain.Entities
{
    public class Company : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; } = Status.Active;

        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string TaxNumber { get; set; }
        public string Email { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace Quarantine.Core.Models
{
    public class Author: IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pseudonym { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}

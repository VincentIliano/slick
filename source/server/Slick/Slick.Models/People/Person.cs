using Slick.Models.Contact;
using System;
using System.ComponentModel.DataAnnotations;

namespace Slick.Models.People
{
    public abstract class Person : BaseEntity
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        public string Middlename { get; set; }
        public DateTime Birthdate { get; set; }

        public Guid? AddressId { get; set; }
        public virtual Address Address { get; set; }

        public bool IsDeleted { get; set; }

        public override string ToString()
        {
            return $"{Firstname} {Lastname}";
        }
    }
}

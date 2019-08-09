using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Slick.Models.Skills
{
    public class Specialisation : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual IList<ConsultantSpecialisation> Consultants { get; set; }


        public Guid SpecialisationLevelId { get; set; }
        public virtual SpecialisationLevel SpecialisationLevel { get; set; }

        public override string ToString()
        {
            return $"{Title}: {Description}";
        }
    }
}

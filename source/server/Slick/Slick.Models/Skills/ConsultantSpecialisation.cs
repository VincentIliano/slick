using Slick.Models.People;
using System;

namespace Slick.Models.Skills
{
    public class ConsultantSpecialisation : BaseEntity
    {
        public Guid ConsultantID { get; set; }
        public virtual Consultant Consultant { get; set; }

        public Guid SpecialisationID { get; set; }
        public virtual Specialisation Specialisation { get; set; }
    }
}

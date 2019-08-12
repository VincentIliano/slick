using Slick.Models.Contracts;
using Slick.Models.Skills;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Slick.Models.People
{
    public class Consultant : Person
    {
        public string Email { get; set; }
        public string WorkEmail { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }

        public virtual IList<ConsultantSpecialisation> Specialisations { get; set; }

        public virtual IList<Contract> Contracts { get; set; }

        [NotMapped]
        public Contract CurrentContract {
            get
            {
                return Contracts.OrderByDescending(x => x.StartDate)
                                .FirstOrDefault();
            }
        }

        public Consultant()
        {
            Specialisations = new List<ConsultantSpecialisation>();
            Contracts = new List<Contract>();
        }
    }
}

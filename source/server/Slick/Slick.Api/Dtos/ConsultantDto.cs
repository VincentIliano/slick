using Slick.Models.Skills;
using System.Collections.Generic;
using System.Linq;

namespace Slick.Api.Dtos
{
    public class ConsultantDto
    {
        public string Straat { get; set; }
        public string Number { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Middlename { get; set; }

        public string Email { get; set; }
        public string WorkEmail { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }

        public IList<ConsultantSpecialisation> Specialisations { get; set; }

        public IList<ContractDto> Contracts { get; set; }

        public ContractDto CurrentContract
        {
            get
            {
                return Contracts.OrderByDescending(x => x.StartDate)
                                .FirstOrDefault();
            }
        }
    }
}

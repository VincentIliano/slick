using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slick.Api.Dtos
{
    public class AccountDto
    {
        public string CompanyName { get; set; }
        public string VatNumber { get; set; }
        public string Telephone { get; set; }
        public string Straat { get; set; }
        public string Number { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }

        public virtual IList<AccountManagerDto> AccountManagers { get; set; }

        public AccountDto()
        {
            AccountManagers = new List<AccountManagerDto>();
        }
    }
}

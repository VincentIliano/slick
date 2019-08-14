using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slick.Api.Dtos
{
    public class AccountConsultantDto
    {
        public ConsultantDto Consultant { get; set; }

        public AccountDto Account { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }

        // accountmanager die contract heeft opgesteld tussen consultant en account
        public EmployeeDto Employee { get; set; }
    }
}

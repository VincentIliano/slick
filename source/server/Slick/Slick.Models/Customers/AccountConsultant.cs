using Slick.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slick.Models.Customers
{
    public class AccountConsultant : BaseEntity
    {
        public Guid ConsultantId { get; set; }
        public Consultant Consultant{ get; set; }

        public Guid AccountId { get; set; }
        public Account Account { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }

        // accountmanager die contract heeft opgesteld tussen consultant en account
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}

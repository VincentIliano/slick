using Slick.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slick.Models.Customers
{
    public class AccountManager : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public Guid AccountId { get; set; }
        public Account Account { get; set; }

        public bool IsActive { get; set; }
    }
}

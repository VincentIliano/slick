using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slick.Api.Dtos
{
    public class AccountManagerDto
    {
        public EmployeeDto Employee { get; set; }

        public AccountDto Account { get; set; }

        public bool IsActive { get; set; }
    }
}

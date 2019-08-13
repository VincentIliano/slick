using Slick.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slick.Services.Customers
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAll();
        IEnumerable<Account> GetAll(string sort);
        Account GetById(Guid id);
        void Delete(Account account);
        Account Create(Account account);
        IEnumerable<Account> GetOverview(string orderby, bool isDescending, int page, int size);
        IEnumerable<Account> getByCompanyName(string value);
        Account GetByVatNumber(string value);
    }
}

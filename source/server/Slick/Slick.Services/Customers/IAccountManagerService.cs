using Slick.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slick.Services.Customers
{
    public interface IAccountManagerService
    {
        IEnumerable<AccountManager> GetAll();
        IEnumerable<AccountManager> GetAll(string sort);
        AccountManager GetById(Guid id);
        void Delete(AccountManager account);
        AccountManager Create(AccountManager account);
        IEnumerable<AccountManager> GetOverview(string orderby, bool isDescending, int page, int size);
        IEnumerable<AccountManager> GetByAccount(Guid id);
    }
}

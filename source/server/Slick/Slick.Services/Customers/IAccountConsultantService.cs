using Slick.Models.Customers;
using Slick.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slick.Services.Customers
{
    public interface IAccountConsultantService
    {
        IEnumerable<AccountConsultant> GetAll();
        IEnumerable<AccountConsultant> GetAll(string sort);
        AccountConsultant GetById(Guid id);
        IEnumerable<AccountConsultant> GetByConsultant(Consultant consultant);
        IEnumerable<AccountConsultant> GetByAccount(Account account);
        void Update(AccountConsultant accountConsultant);
        void Delete(AccountConsultant accountConsultant);
        AccountConsultant Create(AccountConsultant accountConsultant);
        IEnumerable<AccountConsultant> GetOverview(string orderby, bool isDescending, int page, int size);
    }
}

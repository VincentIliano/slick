using Slick.Models.Customers;
using Slick.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Slick.Services.Customers
{
    public class AccountManagerService : IAccountManagerService
    {
        private readonly IEntityRepository<AccountManager> accountManagerRepository;

        public AccountManagerService(IEntityRepository<AccountManager> accountManagerRepository)
        {
            this.accountManagerRepository = accountManagerRepository;
        }

        public AccountManager Create(AccountManager account)
        {
            return accountManagerRepository.Create(account);
        }

        public void Delete(AccountManager account)
        {
            accountManagerRepository.Delete(account);
        }

        public IEnumerable<AccountManager> GetAll()
        {
            return accountManagerRepository.GetAll().ToList();
        }

        public IEnumerable<AccountManager> GetAll(string sort)
        {
            return accountManagerRepository
                .GetAll()
                .OrderBy(sort)
                .ToList();
        }

        public IEnumerable<AccountManager> GetByAccount(Guid id)
        {
            return accountManagerRepository
                .FindBy(x => x.AccountId == id)
                .ToList();
        }

        public AccountManager GetById(Guid id)
        {
            return accountManagerRepository.GetById(id);
        }

        public IEnumerable<AccountManager> GetOverview(string orderby, bool isDescending, int page, int size)
        {
            return accountManagerRepository.GetAllOverview(orderby, isDescending, page, size);
        }
    }
}

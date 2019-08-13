using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Slick.Models.Customers;
using Slick.Repositories;

namespace Slick.Services.Customers
{
    public class AccountService : IAccountService
    {
        private readonly IEntityRepository<Account> accountRepository;

        public AccountService(IEntityRepository<Account> accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public Account Create(Account account)
        {
            return accountRepository.Create(account);
        }

        public void Delete(Account account)
        {
            accountRepository.Delete(account);
        }

        public IEnumerable<Account> GetAll()
        {
            return accountRepository
                .GetAll()
                .ToList();
        }

        public IEnumerable<Account> GetAll(string sort)
        {
            return accountRepository
                .GetAll()
                .OrderBy(sort)
                .ToList();
        }

        public IEnumerable<Account> getByCompanyName(string value)
        {
            return accountRepository
                .FindBy(x => x.CompanyName == value)
                .ToList();
        }

        public Account GetById(Guid id)
        {
            return accountRepository
                .GetAllIncluding(x => x.Address)
                .Where(x => x.Id == id)
                .SingleOrDefault();
        }

        public Account GetByVatNumber(string value)
        {
            return accountRepository
                .FindBy(x => x.VatNumber == value)
                .SingleOrDefault();
        }

        public IEnumerable<Account> GetOverview(string orderby, bool isDescending, int page, int size)
        {
            return accountRepository.GetAllOverview(orderby, isDescending, page, size);
        }

    }
}

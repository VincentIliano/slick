using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Slick.Models.Customers;
using Slick.Models.People;
using Slick.Repositories;

namespace Slick.Services.Customers
{
    public class AccountConsultantService : IAccountConsultantService
    {
        private readonly IEntityRepository<AccountConsultant> accountConsultantRepository;

        public AccountConsultantService(IEntityRepository<AccountConsultant> accountConsultantRepository)
        {
            this.accountConsultantRepository = accountConsultantRepository;
        }

        public AccountConsultant Create(AccountConsultant accountConsultant)
        {
            return accountConsultantRepository.Create(accountConsultant);
        }

        public void Delete(AccountConsultant accountConsultant)
        {
            accountConsultantRepository.Delete(accountConsultant);
        }

        public IEnumerable<AccountConsultant> GetAll()
        {
            return accountConsultantRepository.GetAll();
        }

        public IEnumerable<AccountConsultant> GetAll(string sort)
        {
            return accountConsultantRepository
                .GetAll()
                .OrderBy(sort)
                .ToList();
        }

        public IEnumerable<AccountConsultant> GetByAccount(Account account)
        {
            return accountConsultantRepository
                .FindBy(x => x.Account == account)
                .ToList();
        }

        public IEnumerable<AccountConsultant> GetByAccount(Guid accountId)
        {
            return accountConsultantRepository
                .FindBy(x => x.AccountId == accountId)
                .ToList();
        }

        public IEnumerable<AccountConsultant> GetByConsultant(Consultant consultant)
        {
            return accountConsultantRepository
                .FindBy(x => x.Consultant == consultant)
                .ToList();
        }

        public IEnumerable<AccountConsultant> GetByConsultant(Guid consultantId)
        {
            return accountConsultantRepository
                .FindBy(x => x.ConsultantId == consultantId)
                .ToList();
        }


        public AccountConsultant GetById(Guid id)
        {
            return accountConsultantRepository
                .GetAllIncluding(x => x.Employee, x => x.Account, x => x.Consultant.Address)
                .Where(x => x.Id == id)
                .SingleOrDefault();
        }

        public IEnumerable<AccountConsultant> GetOverview(string orderby, bool isDescending, int page, int size)
        {
            return accountConsultantRepository.GetAllOverview(orderby, isDescending, page, size);
        }

        public void Update(AccountConsultant accountConsultant)
        {
            accountConsultantRepository.Update(accountConsultant);
        }
    }
}

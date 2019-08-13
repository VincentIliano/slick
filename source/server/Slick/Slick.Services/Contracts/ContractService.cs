using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slick.Models.Contracts;
using Slick.Repositories;

namespace Slick.Services.Contracts
{
    public class ContractService : IContractService
    {
        private readonly IEntityRepository<Contract> contractRepository;

        public ContractService(IEntityRepository<Contract> contractRepository)
        {
            this.contractRepository = contractRepository;
        }

        public Contract Create(Contract contract)
        {
            return contractRepository.Create(contract);
        }

        public void Delete(Contract contract)
        {
            contractRepository.Delete(contract);
        }

        public IEnumerable<Contract> GetActiveContracts()
        {
            return contractRepository
                .GetAllIncluding(x => x.ContractType)
                .Where(x => DateTime.Now < x.EndDate);
        }

        public IEnumerable<Contract> GetAll()
        {
            return contractRepository
                .GetAllIncluding(x => x.ContractType)
                .ToList();
        }

        public Contract GetById(Guid id)
        {
            return contractRepository.GetById(id);
        }

        public IEnumerable<Contract> GetContractsForConsultant(Guid consultantId)
        {
            return contractRepository.FindBy(c => c.ConsultantId == consultantId).ToList();
        }

        public void Update(Contract contract)
        {
            contractRepository.Update(contract);
        }
    }
}

using Slick.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slick.Services.Contracts
{
    public interface IContractService
    {
        IEnumerable<Contract> GetAll();
        IEnumerable<Contract> GetActiveContracts();
        Contract GetById(Guid id);
        void Update(Contract contract);
        void Delete(Contract contract);
        Contract Create(Contract contract);
    }
}

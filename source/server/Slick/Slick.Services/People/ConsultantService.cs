using Slick.Models.People;
using Slick.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

namespace Slick.Services.People
{
    public class ConsultantService : IConsultantService
    {
        private IEntityRepository<Consultant> consultantRepository;

        public ConsultantService(IEntityRepository<Consultant> consultantRepository)
        {
            this.consultantRepository = consultantRepository;
        }

        public Consultant Create(Consultant level)
        {
            return consultantRepository.Create(level);
        }

        public void Delete(Consultant level)
        {
            level.IsDeleted = true;
            consultantRepository.Update(level);
        }

        public IEnumerable<Consultant> GetAll()
        {
            return consultantRepository
                .GetAllIncluding(x => x.Address, x => x.Contracts, x => x.Specialisations)
                .Where(x => x.IsDeleted == false)
                .ToList();
        }

        public IEnumerable<Consultant> GetAll(string sort)                
        {                                                                                                
            if (String.IsNullOrEmpty(sort))
                sort = "firstname";
            return consultantRepository
                .GetAll()
                .OrderBy(x => sort)
                .ToList();
        }

        public IEnumerable<Consultant> GetByfirstName(string firstname)
        {
            return consultantRepository
                .FindBy(x => x.Firstname == firstname)
                .ToList();
        }

        public IEnumerable<Consultant> GetByfirstName(string firstname, string sort)
        {
            return consultantRepository
                .FindBy(x => x.Firstname == firstname)
                .OrderBy(sort)
                .ToList();
        }

        public IEnumerable<Consultant> GetByLastname(string lastname)
        {
            return consultantRepository
                .FindBy(x => x.Lastname == lastname)
                .ToList();
        }

        public IEnumerable<Consultant> GetByLastname(string lastname, string sort)
        {
            return consultantRepository
                .FindBy(x => x.Lastname == lastname)
                .OrderBy(sort)
                .ToList();
        }

        public Consultant GetById(Guid id)
        {
            return consultantRepository.GetById(id);
        }

        public IEnumerable<Consultant> GetOverview(string orderby, bool isDescending, int page, int size)
        {
            return consultantRepository.GetAllOverview(orderby, isDescending, page, size).ToList();
        }

        public void Update(Consultant level)
        {
            consultantRepository.Update(level);
        }
    }
}

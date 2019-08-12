using Slick.Models.People;
using Slick.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
                .GetAll()
                .Where(x => x.IsDeleted == false)
                .ToList();
        }

        public Consultant GetById(Guid id)
        {
            return consultantRepository.GetById(id);
        }

        public void Update(Consultant level)
        {
            consultantRepository.Update(level);
        }
    }
}

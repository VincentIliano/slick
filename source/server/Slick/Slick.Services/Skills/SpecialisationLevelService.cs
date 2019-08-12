using System;
using System.Collections.Generic;
using System.Text;
using Slick.Models.Skills;
using Slick.Repositories;

namespace Slick.Services.Skills
{
    public class SpecialisationLevelService : ISpecialisationLevelService
    {
        private IEntityRepository<SpecialisationLevel> specialisationLevelRepository;

        public SpecialisationLevelService(IEntityRepository<SpecialisationLevel> specialisationLevelRepository)
        {
            this.specialisationLevelRepository = specialisationLevelRepository;
        }


        public SpecialisationLevel Create(SpecialisationLevel level)
        {
            return specialisationLevelRepository.Create(level);
        }

        public void Delete(SpecialisationLevel level)
        {
            level.IsDeleted = true;
            specialisationLevelRepository.Update(level);
        }

        public IEnumerable<SpecialisationLevel> GetAll()
        {
            return specialisationLevelRepository.GetAll();
        }

        public SpecialisationLevel GetById(Guid id)
        {
            return specialisationLevelRepository.GetById(id);
        }

        public void Update(SpecialisationLevel level)
        {
            specialisationLevelRepository.Update(level);
        }
    }
}

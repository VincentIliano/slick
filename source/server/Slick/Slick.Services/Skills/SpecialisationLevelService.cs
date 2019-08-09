using System;
using System.Collections.Generic;
using System.Text;
using Slick.Models.Skills;
using Slick.Repositories.Skills;

namespace Slick.Services.Skills
{
    public class SpecialisationLevelService : ISpecialisationLevelService
    {
        private ISpecialisationLevelRepository SpecialisationLevelRepository;

        public SpecialisationLevelService(ISpecialisationLevelRepository specialisationLevelRepository)
        {
            SpecialisationLevelRepository = specialisationLevelRepository;
        }

        public SpecialisationLevel Create(SpecialisationLevel level)
        {
            return SpecialisationLevelRepository.Create(level);
        }

        public void Delete(SpecialisationLevel level)
        {
            level.IsDeleted = true;
            SpecialisationLevelRepository.Update(level);
        }

        public IEnumerable<SpecialisationLevel> GetAll()
        {
            return SpecialisationLevelRepository.GetAll();
        }

        public SpecialisationLevel GetById(Guid id)
        {
            return SpecialisationLevelRepository.GetById(id);
        }

        public void Update(SpecialisationLevel level)
        {
            SpecialisationLevelRepository.Update(level);
        }
    }
}

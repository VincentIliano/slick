using Slick.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Services.Skills
{
    public interface ISpecialisationLevelService
    {
        IEnumerable<SpecialisationLevel> GetAll();
        SpecialisationLevel GetById(Guid id);
        void Update(SpecialisationLevel level);
        void Delete(SpecialisationLevel level);
        SpecialisationLevel Create(SpecialisationLevel level);

    }
}

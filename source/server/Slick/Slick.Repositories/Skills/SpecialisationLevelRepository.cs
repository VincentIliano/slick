using System;
using System.Collections.Generic;
using System.Text;
using Slick.Database;
using Slick.Models.Skills;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Slick.Repositories.Skills
{
    public class SpecialisationLevelRepository : ISpecialisationLevelRepository
    {
        private readonly ApplicationDbContext entitiesContext;

        public SpecialisationLevelRepository(ApplicationDbContext entitiesContext)
        {
            this.entitiesContext = entitiesContext;
        }

        public SpecialisationLevel Create(SpecialisationLevel specialisationLevel)
        {
            entitiesContext.Set<SpecialisationLevel>().Add(specialisationLevel);
            entitiesContext.SaveChanges();
            return specialisationLevel;
        }

        public void Delete(SpecialisationLevel specialisationLevel)
        {
            EntityEntry dbEntry = entitiesContext.Entry(specialisationLevel);
            dbEntry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            entitiesContext.SaveChanges();
        }

        public IEnumerable<SpecialisationLevel> GetAll()
        {
            return entitiesContext.Set<SpecialisationLevel>().ToList();
        }

        public SpecialisationLevel GetById(Guid id)
        {
            return entitiesContext.Set<SpecialisationLevel>().Find(id);
        }

        public void Update(SpecialisationLevel specialisationLevel)
        {
            EntityEntry dbEntry = entitiesContext.Entry(specialisationLevel);
            dbEntry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            entitiesContext.SaveChanges();
        }
    }
}

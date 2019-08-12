using Microsoft.EntityFrameworkCore.ChangeTracking;
using Slick.Database;
using Slick.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Slick.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : BaseEntity, new()
    {
        private readonly ApplicationDbContext entitiesContext;

        public EntityRepository(ApplicationDbContext entitiesContext)
        {
            this.entitiesContext = entitiesContext;
        }

        public T Create(T model)
        {
            entitiesContext.Set<T>().Add(model);
            entitiesContext.SaveChanges();
            return model;
        }

        public void Delete(T model)
        {
            EntityEntry dbEntry = entitiesContext.Entry(model);
            dbEntry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            entitiesContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return entitiesContext.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return entitiesContext.Set<T>().Find(id);
        }

        public void Update(T model)
        {
            EntityEntry dbEntry = entitiesContext.Entry(model);
            dbEntry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            entitiesContext.SaveChanges();
        }
    }
}

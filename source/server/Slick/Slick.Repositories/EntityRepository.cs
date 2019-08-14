using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Slick.Database;
using Slick.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

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
            //entitiesContext.Set<T>().Add(model);
            EntityEntry dbEntry = entitiesContext.Entry(model);
            dbEntry.State = Microsoft.EntityFrameworkCore.EntityState.Added;
            entitiesContext.SaveChanges();
            return model;
        }

        public void Delete(T model)
        {
            EntityEntry dbEntry = entitiesContext.Entry(model);
            dbEntry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            entitiesContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return entitiesContext.Set<T>();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return entitiesContext.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = entitiesContext.Set<T>();
            foreach (var includedProperty in includeProperties)
            {
                query = query.Include(includedProperty);
            }
            return query;
        }

        public IQueryable<T> GetAllOverview(string orderby, bool isDescending, int page, int size)
        {
            var order = orderby + " " + (isDescending ? "descending" : "ascending");

            var query = entitiesContext.Set<T>()
                .OrderBy(order)
                .Skip((page - 1)  * size)
                .Take(size);

            return query;

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

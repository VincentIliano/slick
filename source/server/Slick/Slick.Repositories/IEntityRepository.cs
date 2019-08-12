using Slick.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Slick.Repositories
{
    public interface IEntityRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T GetById(Guid id);
        T Create(T model);
        void Update(T model);
        void Delete(T model);
    }
}

using Slick.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Repositories
{
    public interface IEntityRepository<T> where T: BaseEntity, new()
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        T Create(T model);
        void Update(T model);
        void Delete(T model);
    }
}

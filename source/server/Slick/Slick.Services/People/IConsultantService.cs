using Slick.Models.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Services.People
{
    public interface IConsultantService
    {
        IEnumerable<Consultant> GetAll();
        Consultant GetById(Guid id);
        void Update(Consultant level);
        void Delete(Consultant level);
        Consultant Create(Consultant level);
        IEnumerable<Consultant> GetOverview(string orderby,bool isDescending, int page, int size);
    }
}

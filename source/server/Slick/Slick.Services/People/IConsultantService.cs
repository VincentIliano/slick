﻿using Slick.Models.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Services.People
{
    public interface IConsultantService
    {
        IEnumerable<Consultant> GetAll();
        IEnumerable<Consultant> GetAll(string sort);
        Consultant GetById(Guid id);
        IEnumerable<Consultant> GetByfirstName(string firstname);
        IEnumerable<Consultant> GetByfirstName(string firstname, string sort);
        IEnumerable<Consultant> GetByLastname(string lastname);
        IEnumerable<Consultant> GetByLastname(string lastname, string sort);
        void Update(Consultant consultant);
        void Delete(Consultant consultant);
        Consultant Create(Consultant consultant);
        IEnumerable<Consultant> GetOverview(string orderby,bool isDescending, int page, int size);
    }
}

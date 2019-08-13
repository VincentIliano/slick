using Slick.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slick.Services.People
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        IEnumerable<Employee> GetAll(string sort);
        Employee GetById(Guid id);
        IEnumerable<Employee> GetByfirstName(string firstname);
        IEnumerable<Employee> GetByfirstName(string firstname, string sort);
        IEnumerable<Employee> GetByLastname(string lastname);
        IEnumerable<Employee> GetByLastname(string lastname, string sort);
        void Update(Employee employee);
        void Delete(Employee employee);
        Employee Create(Employee employee);
        IEnumerable<Employee> GetOverview(string orderby, bool isDescending, int page, int size);
    }
}

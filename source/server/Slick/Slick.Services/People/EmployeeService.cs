using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Slick.Models.Customers;
using Slick.Models.People;
using Slick.Repositories;

namespace Slick.Services.People
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEntityRepository<Employee> employeeRepository;
        private readonly IEntityRepository<AccountManager> accountManagerRepository;

        public EmployeeService(IEntityRepository<Employee> employeeRepository, IEntityRepository<AccountManager> accountManagerRepository)
        {
            this.employeeRepository = employeeRepository;
            this.accountManagerRepository = accountManagerRepository;
        }

        public Employee Create(Employee employee)
        {
            return employeeRepository.Create(employee);
        }

        public void Delete(Employee employee)
        {
            employeeRepository.Delete(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return employeeRepository
                .GetAllIncluding(x => x.Address)
                .ToList();
        }

        public IEnumerable<Employee> GetAll(string sort)
        {
            return employeeRepository
                .GetAllIncluding(x => x.Address)
                .OrderBy(sort)
                .ToList();
        }

        public IEnumerable<Employee> GetByfirstName(string firstname)
        {
            return employeeRepository
                .FindBy(x => x.Firstname == firstname)
                .ToList();
        }

        public IEnumerable<Employee> GetByfirstName(string firstname, string sort)
        {
            return employeeRepository
                .FindBy(x => x.Firstname == firstname)
                .OrderBy(sort)
                .ToList();
        }

        public Employee GetById(Guid id)
        {
            return employeeRepository
                   .GetAllIncluding(x => x.Address)
                   .Where(x => x.Id == id)
                   .SingleOrDefault();
        }

        public IEnumerable<Employee> GetByLastname(string lastname)
        {
            return employeeRepository
               .FindBy(x => x.Lastname== lastname)
               .ToList();
        }

        public IEnumerable<Employee> GetByLastname(string lastname, string sort)
        {
            return employeeRepository
              .FindBy(x => x.Lastname == lastname)
              .OrderBy(sort)
              .ToList();
        }

        public IEnumerable<Employee> GetOverview(string orderby, bool isDescending, int page, int size)
        {
            return employeeRepository.GetAllOverview(orderby, isDescending, page, size).ToList();
        }

        public void Update(Employee employee)
        {
            employeeRepository.Update(employee);
        }
    }
}

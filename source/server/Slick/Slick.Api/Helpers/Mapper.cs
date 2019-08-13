using Slick.Api.Dtos;
using Slick.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slick.Api
{
    public static class Mapper
    {
        public static EmployeeDto mapEmployee(Employee e)
        {
            return new EmployeeDto
            {
                Country = e.Address?.Country,
                Email = e.Email,
                Firstname = e.Firstname,
                Lastname = e.Lastname,
                Number = e.Address?.Number,
                Straat = e.Address?.Straat,
                Telephone = e.Telephone,
                Zipcode = e.Address?.Zipcode
            };
        }

        internal static List<EmployeeDto> mapEmployeeList(IEnumerable<Employee> employees)
        {
            var employeeDtoList = new List<EmployeeDto>();

            foreach (var e in employees)
            {
                employeeDtoList.Add(mapEmployee(e));
            }
            return employeeDtoList;
        }
    }
}

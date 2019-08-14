using Slick.Api.Dtos;
using Slick.Models.Contracts;
using Slick.Models.Customers;
using Slick.Models.People;
using System.Collections.Generic;

namespace Slick.Api
{
    public static class Mapper
    {
        internal static EmployeeDto MapEmployee(Employee e)
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

        internal static List<EmployeeDto> MapEmployees(IEnumerable<Employee> employees)
        {
            var employeeDtoList = new List<EmployeeDto>();

            foreach (var e in employees)
            {
                employeeDtoList.Add(MapEmployee(e));
            }
            return employeeDtoList;
        }

        internal static AccountConsultantDto MapAccountConsultant(AccountConsultant accountConsultant)
        {
            return new AccountConsultantDto
            {
                BuyPrice = accountConsultant.BuyPrice,
                EndDate = accountConsultant.EndDate,
                SellPrice = accountConsultant.SellPrice,
                StartDate = accountConsultant.StartDate,
                Account = MapAccount(accountConsultant.Account),
                Consultant = MapConsultant(accountConsultant.Consultant),
                Employee = MapEmployee(accountConsultant.Employee)
            };
        }

        internal static ConsultantDto MapConsultant(Consultant consultant)
        {
            return new ConsultantDto
            {
                Country = consultant.Address?.Country,
                Straat = consultant.Address?.Straat,
                Zipcode = consultant.Address?.Zipcode,
                FirstName = consultant.Firstname,
                LastName = consultant.Lastname,
                Email = consultant.Email,
                Mobile = consultant.Mobile,
                Middlename = consultant.Middlename,
                Telephone = consultant.Telephone,
                Number = consultant.Address?.Number,
                WorkEmail = consultant.WorkEmail,
                Specialisations = consultant.Specialisations,
                Contracts = MapContracts(consultant.Contracts)
            };
        }

        internal static IList<ContractDto> MapContracts(IList<Contract> contracts)
        {
            var dtos = new List<ContractDto>();
            foreach (var c in contracts)
            {
                dtos.Add(MapContract(c));
            }
            return dtos;
        }

        internal static ContractDto MapContract(Contract c)
        {
            return new ContractDto
            {
                ContractType = c.ContractType.ToString(),
                DocumentUrl = c.DocumentUrl,
                EndDate = c.EndDate,
                Salary = c.Salary,
                SignedDate = c.SignedDate,
                StartDate = c.StartDate
            };
        }

        internal static AccountDto MapAccount(Account account)
        {
            return new AccountDto
            {
                CompanyName = account.CompanyName,
                Country = account.Address?.Country,
                Number = account.Address?.Number,
                Straat = account.Address?.Straat,
                Zipcode = account.Address?.Zipcode,
                Telephone = account.Telephone,
                VatNumber = account.VatNumber,
                AccountManagers = account.AccountManagers == null  ? null : MapAccountManagers(account.AccountManagers)
            };
        }

        internal static IList<AccountManagerDto> MapAccountManagers(IList<AccountManager> accountManagers)
        {
            var dtos = new List<AccountManagerDto>();
            foreach (var a in accountManagers)
            {
                dtos.Add(MapAccountManager(a));
            }
            return dtos;
        }

        internal static AccountManagerDto MapAccountManager(AccountManager a)
        {
            return new AccountManagerDto
            {
                Account = MapAccount(a.Account),
                Employee = MapEmployee(a.Employee),
                IsActive = a.IsActive
            };
        }
    }
}

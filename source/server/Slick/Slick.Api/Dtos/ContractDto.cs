using System;

namespace Slick.Api.Dtos
{
    public class ContractDto
    {

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? SignedDate { get; set; }
        public decimal? Salary { get; set; }
        public string DocumentUrl { get; set; }
        public string ContractType { get; set; }
    }
}

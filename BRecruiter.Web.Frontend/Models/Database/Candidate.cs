using System;

namespace BRecruiter.Web.Frontend.Models.Database
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal SalaryExpectations { get; set; }
        public string Observations { get; set; }
    }
}

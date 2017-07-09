using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BRecruiter.Web.Frontend.Models.Database
{
    public class Candidate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public decimal SalaryExpectations { get; set; }

        public decimal Experience { get; set; }

        public int Status { get; set; }

        public string Observations { get; set; }

        public string Curriculum_FileUrl { get; set; }

        public IEnumerable<Skill> Skills { get; set; }
    }
}

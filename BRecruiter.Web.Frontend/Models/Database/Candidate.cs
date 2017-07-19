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

        public int SalaryExpectations { get; set; }

        public int Experience { get; set; }

        public int Status { get; set; }

        public string Observations { get; set; }

        //public string Curriculum_FileUrl { get; set; }
        public byte[] Curriculum_File { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<CandidateSkill> RelationSkills { get; set; }
    }
}

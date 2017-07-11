using System.Collections;
using System.Collections.Generic;

namespace BRecruiter.Web.Frontend.Models.Database
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CandidateSkill> CandidateSkills { get; set; }
    }
}

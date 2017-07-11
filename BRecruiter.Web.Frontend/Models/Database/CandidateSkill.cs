﻿using BRecruiter.Web.Frontend.Models.ViewModels;

namespace BRecruiter.Web.Frontend.Models.Database
{
    public class CandidateSkill
    {
        public CandidateSkill()
        {

        }
        
        public int CandidateId { get; set; }
        public int SkillId { get; set; }

        public Skill Skill { get; set; }
        public Candidate Candidate { get; set; }
    }
}

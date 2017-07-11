using BRecruiter.Web.Frontend.Models.ViewModels;

namespace BRecruiter.Web.Frontend.Models.Database
{
    public class CandidateSkill
    {
        public CandidateSkill()
        {

        }

        public CandidateSkill(CandidateSkillViewModel model)
        {
            CandidateId = model.CandidateId;
            SkillId = model.CandidateId;
        }
        public int CandidateId { get; set; }
        public int SkillId { get; set; }

        public Skill Skill { get; set; }
        public Candidate Candidate { get; set; }
    }
}

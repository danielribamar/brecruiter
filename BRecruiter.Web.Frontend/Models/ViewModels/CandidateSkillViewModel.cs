using System.ComponentModel.DataAnnotations;

namespace BRecruiter.Web.Frontend.Models.ViewModels
{
    public class CandidateSkillViewModel
    {
        [Required]
        public int CandidateId { get; set; }

        [Required]
        public int SkillId { get; set; }
    }
}

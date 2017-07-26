using BRecruiter.Web.Frontend.Data;
using BRecruiter.Web.Frontend.Models.Graph;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BRecruiter.Web.Frontend.Business
{
    public class GraphManager
    {
        private readonly BRecruiterContext _context;

        public GraphManager(BRecruiterContext context)
        {
            _context = context;
        }
        public List<DonutModel> GetSkillsModel()
        {
            var skillsModel = new List<DonutModel>();

            var skills = _context.Skills.Include(p => p.CandidateSkills).ToList();
            foreach (var skill in skills.Where(p => p.CandidateSkills.Any()))
            {
                skillsModel.Add(new DonutModel
                {
                    label = skill.Name,
                    value = skill.CandidateSkills.Count(p => p.SkillId == skill.Id)
                });
            }
            return skillsModel;
        }
        public List<DonutModel> GetExperienceModel()
        {
            var model = new List<DonutModel>();

            var group = _context.Candidates.GroupBy(p => p.Experience);

            foreach (var exp in group)
            {
                var lbl = DateTime.Now.Year - exp.Key > 1 ? "years" : "year";
                model.Add(new DonutModel
                {
                    label = $"{DateTime.Now.Year - exp.Key} {lbl}",
                    value = exp.Count()
                });
            }

            return model;
        }
    }
}

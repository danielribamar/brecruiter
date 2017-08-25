using BRecruiter.Web.Frontend.Data;
using BRecruiter.Web.Frontend.Interfaces;
using BRecruiter.Web.Frontend.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BRecruiter.Web.Frontend.Business
{
    public class SkillManager : IManager<Skill>, IDisposable
    {
        private readonly BRecruiterContext _context;

        public SkillManager(BRecruiterContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            var skillToDelete = await _context.Skills.FindAsync(id);
            if (skillToDelete != null)
            {
                _context.Skills.Remove(skillToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Skill>> Get()
        {
            var skills = await _context.Skills.ToListAsync();
            return skills;
        }

        public async Task<Skill> GetById(int id)
        {
            var skill = await _context.Skills
                .Include(p => p.CandidateSkills)
                .ThenInclude(q => q.Candidate)
                .SingleOrDefaultAsync(p => p.Id == id); ;
            return skill;
        }

        public async Task<Skill> Insert(Skill model)
        {
            if (!_context.Skills.Any(p => p.Name.ToLowerInvariant().Equals(model.Name.ToLowerInvariant())))
            {
                var entity = await _context.Skills.AddAsync(model);
                await _context.SaveChangesAsync();
                return entity.Entity;
            }
            return null;
        }

        public async Task Update(Skill model)
        {
            _context.Skills.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}

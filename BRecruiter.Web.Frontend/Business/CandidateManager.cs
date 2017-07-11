using BRecruiter.Web.Frontend.Data;
using BRecruiter.Web.Frontend.Interfaces;
using BRecruiter.Web.Frontend.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BRecruiter.Web.Frontend.Business
{
    public class CandidateManager : IManager<Candidate>, IDisposable
    {
        private readonly BRecruiterContext _context;

        public CandidateManager(BRecruiterContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            var candidateToDelete = await _context.FindAsync<Candidate>(id);
            if (candidateToDelete != null)
            {
                _context.Candidates.Remove(candidateToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Candidate>> Get()
        {
            var candidates = await _context.Candidates
                .Include(c => c.RelationSkills)
                    .ThenInclude(q => q.Skill)
                .ToListAsync();

            return candidates;
        }

        public async Task<Candidate> GetById(int id)
        {
            var candidate = await _context.Candidates.Include(c => c.RelationSkills)
                    .ThenInclude(q => q.Skill)
                    .SingleOrDefaultAsync(p => p.Id == id);
            return candidate;
        }

        public async Task<Candidate> Insert(Candidate model)
        {
            var entity = await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task Update(Candidate model)
        {
            _context.Candidates.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task AddSkill(CandidateSkill model)
        {
            _context.CandidateSkills.Add(model);
            await _context.SaveChangesAsync();
        }
    }
}

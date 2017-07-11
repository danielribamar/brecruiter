using BRecruiter.Web.Frontend.Business;
using BRecruiter.Web.Frontend.Data;
using BRecruiter.Web.Frontend.Interfaces;
using BRecruiter.Web.Frontend.Models.Database;
using BRecruiter.Web.Frontend.Models.ViewModels;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BRecruiter.Web.Frontend.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CandidatesController : Controller
    {
        private CandidateManager _candidateManager;
        private BRecruiterContext _context;

        public CandidatesController(BRecruiterContext context)
        {
            _context = context;
            _candidateManager = new CandidateManager(context);
        }

        [HttpGet]
        [Route("ping")]
        public IActionResult Ping()
        {
            return Ok();
        }
        [HttpPost]
        [Route("addskill")]
        public async Task<IActionResult> AddSkill([FromBody]CandidateSkillViewModel model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _candidateManager.AddSkill(
                    new CandidateSkill
                    {
                        CandidateId = model.CandidateId,
                        SkillId = model.SkillId
                    });

                return Ok();

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
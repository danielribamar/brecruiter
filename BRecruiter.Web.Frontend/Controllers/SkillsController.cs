using BRecruiter.Web.Frontend.Business;
using BRecruiter.Web.Frontend.Data;
using BRecruiter.Web.Frontend.Interfaces;
using BRecruiter.Web.Frontend.Models.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BRecruiter.Web.Frontend.Controllers
{
    [Authorize]
    public class SkillsController : Controller
    {
        private IManager<Skill> _skillManager;
        private IManager<Candidate> _candidateManager;

        public SkillsController(BRecruiterContext context)
        {
            _skillManager = new SkillManager(context);
            _candidateManager = new CandidateManager(context);
        }

        public async Task<ActionResult> Index()
        {
            var skills = await _skillManager.Get();
            return View(skills);
        }

        public async Task<ActionResult> Details(int id)
        {
            var skill = await _skillManager.GetById(id);

            if (skill == null)
            {
                return NotFound();
            }

            var candidates = await _candidateManager.Get();
            ViewData.Add("candidates", candidates);
            return View(skill);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Skill skill)
        {
            try
            {
                var newSkill = await _skillManager.Insert(skill);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var skill = await _skillManager.GetById(id);
            return View(skill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Skill skill)
        {

            try
            {
                await _skillManager.Update(skill);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var skill = await _skillManager.GetById(id);
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _skillManager.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
using BRecruiter.Web.Frontend.Business;
using BRecruiter.Web.Frontend.Data;
using BRecruiter.Web.Frontend.Interfaces;
using BRecruiter.Web.Frontend.Models.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BRecruiter.Web.Frontend.Controllers
{
    public class CandidatesController : Controller
    {
        private IManager<Candidate> _candidateManager;
        private IManager<Skill> _skillManager;

        public CandidatesController(BRecruiterContext context)
        {
            _candidateManager = new CandidateManager(context);
            _skillManager = new SkillManager(context);
        }
        public async Task<ActionResult> Index()
        {
            var candidates = await _candidateManager.Get();
            return View(candidates);
        }

        public async Task<ActionResult> Details(int id)
        {
            var candidate = await _candidateManager.GetById(id);
            ViewData.Add("skills", await _skillManager.Get());
            return View(candidate);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Candidate model)
        {
            try
            {
                var candidate = await _candidateManager.Insert(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var candidate = await _candidateManager.GetById(id);
            return View(candidate);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Candidate model)
        {
            try
            {
                await _candidateManager.Update(model);

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var candidate = await _candidateManager.GetById(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return View(candidate);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _candidateManager.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
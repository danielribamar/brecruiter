using BRecruiter.Web.Frontend.Business;
using BRecruiter.Web.Frontend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BRecruiter.Web.Frontend.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private GraphManager _graphManager;
        public DashboardController(BRecruiterContext context)
        {
            _graphManager = new GraphManager(context);
        }

        public IActionResult Index()
        {
            //ViewData["skillsGraphModel"] = new JsonConvert. (_graphManager.GetSkillsModel());

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

using BRecruiter.Web.Frontend.Business;
using BRecruiter.Web.Frontend.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BRecruiter.Web.Frontend.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class GraphController : Controller
    {
        private GraphManager _graphManager;
        public GraphController(BRecruiterContext context)
        {
            _graphManager = new GraphManager(context);
        }

        [HttpGet]
        [Route("getskills")]
        public IActionResult GetSkillsGraph()
        {
            var graphData = _graphManager.GetSkillsModel();
            return Ok(graphData);
        }
        [HttpGet]
        [Route("getexperience")]
        public IActionResult GetExperienceGraph()
        {
            var graphData = _graphManager.GetExperienceModel();
            return Ok(graphData);
        }
    }
}
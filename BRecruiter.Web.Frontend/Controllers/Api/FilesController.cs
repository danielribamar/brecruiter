using BRecruiter.Web.Frontend.Business;
using BRecruiter.Web.Frontend.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace BRecruiter.Web.Frontend.Controllers.Api
{
    public class FilesController : Controller
    {
        private CandidateManager candidateManager;

        public FilesController(BRecruiterContext context)
        {
            candidateManager = new CandidateManager(context);
        }

        public async Task<IActionResult> DownloadFile(int id)
        {
            var candidate = await candidateManager.GetById(id);

            if (candidate == null)
            {
                return NotFound();
            }
            Stream stream = new MemoryStream(candidate.Curriculum_File);
            return Ok(stream);
        }
    }
}
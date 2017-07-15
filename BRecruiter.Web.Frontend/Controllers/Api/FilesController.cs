using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BRecruiter.Web.Frontend.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/files")]
    public class FilesController : Controller
    {
        [HttpPost]
        [Route("upload")]
        public IActionResult Upload()
        {
            if (Request.Form.Files != null)
            {
                return Ok(Guid.NewGuid().ToString("N"));
            }
            else
            {
                return NoContent();
            }
        }
    }
}
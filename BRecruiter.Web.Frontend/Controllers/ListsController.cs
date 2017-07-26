using BRecruiter.Web.Frontend.Business;
using BRecruiter.Web.Frontend.Data;
using BRecruiter.Web.Frontend.Models.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BRecruiter.Web.Frontend.Controllers
{
    public class ListsController : Controller
    {
        private readonly ListManager _listManager;

        public ListsController(BRecruiterContext context)
        {
            _listManager = new ListManager(context);
        }

        public IActionResult Index()
        {
            var lists = new List<List>();
            return View(lists);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(List list)
        {
            return RedirectToAction("Index");
        }
    }
}
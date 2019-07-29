using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoFish.Data;
using GoFish.Web.Models.Forum;
using Microsoft.AspNetCore.Mvc;

namespace GoFish.Web.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;

        public ForumController(IForum forumService)
        {
            _forumService = forumService;
        }

        public IActionResult Index()
        {
            var model = _forumService.GetAll()
                .Select(f => new ForumListingModel
                {
                    Id = f.Id,
                    Title = f.Title,
                    Description = f.Description
                }
            ).OrderBy(f => f.Title);
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _forumService.GetById(id);
            return View(model);
        }
    }
}
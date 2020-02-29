using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoFish.Data;
using GoFish.Data.Models;
using GoFish.Web.Models.Forum;
using GoFish.Web.Models.Post;
using Microsoft.AspNetCore.Mvc;

namespace GoFish.Web.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        private readonly IPost _postService;

        public ForumController(IForum forumService, IPost postService)
        {
            _forumService = forumService;
            _postService = postService;
        }

        public IActionResult Index()
        {
            var forums = _forumService.GetAll()
                .Select(f => new ForumListingModel
                {
                    Id = f.Id,
                    Title = f.Title,
                    Description = f.Description
                }
            ).OrderBy(f => f.Title);

            var model = new ForumIndexModel
            {
                ForumList = forums
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var forum = _forumService.GetById(id);
            var posts = forum.Posts;

            var postListing = posts.Select(p => new PostListingModel
            { 
                Id = p.Id,
                AuthorId = p.User.Id,
                AuthorRating = p.User.Rating,
                Title = p.Title,
                DateCreated = p.Created.ToString(),
                RepliesCount = p.Replies.Count(),
                Forum = BuildForumListing(p)
            });

            var model = new ForumDetailModel
            {
                Posts = postListing,
                Forum = BuildForumListing(forum)
            };
                
            return View(model);
        }

        private ForumListingModel BuildForumListing(Post p)
        {
            var forum = p.Forum;
            return BuildForumListing(forum);
        }

        private ForumListingModel BuildForumListing(Forum forum)
        {
            return new ForumListingModel
            {
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description,
                ImageUrl = forum.ImageUrl
            };
        }
    }
}
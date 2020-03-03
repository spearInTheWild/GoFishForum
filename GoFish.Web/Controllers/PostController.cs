using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoFish.Data;
using GoFish.Data.Models;
using GoFish.Web.Models.Post;
using GoFish.Web.Models.Reply;
using Microsoft.AspNetCore.Mvc;

namespace GoFish.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost postService;

        public PostController(IPost postService)
        {
            this.postService = postService;
        }
        public IActionResult Index(int id)
        {
            var post = postService.GetById(id);

            var model = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorImageUrl = post.User.ProfileImage,
                AuthorRating= post.User.Rating,
                PostContent = post.Content,
                Created = post.Created,
                Replies = BuildPostReplies(post.Replies)
        };
            return View(model);
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyModel
            {
                Id = reply.Id,
                AuthorId = reply.User.Id,
                AuthorName = reply.User.UserName,
                AuthorImageUrl = reply.User.ProfileImage,
                AuthorRating = reply.User.Rating,
                Created = reply.Created,
                ReplyContent = reply.Content
            });
        }
    }
}
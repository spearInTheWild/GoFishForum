using GoFish.Data;
using GoFish.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoFish.Service
{
    public class ForumService : IForum
    {
        private readonly ApplicationDbContext _context;
        public ForumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Create(Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums.Include(f => f.Posts);
        }

        public IEnumerable<IdentityUser> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Forum GetById(int id)
        {
            return _context.Forums.Where(forum => forum.Id == id)
                .Include(forum => forum.Posts).ThenInclude(post => post.User)
                .Include(forum => forum.Posts).ThenInclude(post => post.Replies).ThenInclude(forum => forum.User)
                .FirstOrDefault();
        }

        public Task UpdateForum(Forum forum)
        {
            throw new NotImplementedException();
        }
    }
}

using GoFish.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Data
{
    public interface IForum
    {
        Forum GetById(int id);
        IEnumerable<Forum> GetAll();
        IEnumerable<IdentityUser> GetAllActiveUsers();

        Task Create(Forum forum);
        Task Delete(int id);
        Task UpdateForum(Forum forum);




    }
}

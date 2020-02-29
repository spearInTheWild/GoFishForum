using GoFish.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoFish.Data
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetPostsByForum(int id);
        IEnumerable<Post> GetFilteredPosts(string searchQuery);

        Task Add(Post post);
        Task Delete(int id);
        Task EditPost(int id, string newContent);
        
    }
}

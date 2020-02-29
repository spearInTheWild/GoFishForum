using Microsoft.AspNetCore.Identity;
using System;

namespace GoFish.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Rating { get; set; }
        public string ProfileImage { get; set; }
        public DateTime MemeberSince { get; set; }
        public bool IsActive { get; set; }
    }
}

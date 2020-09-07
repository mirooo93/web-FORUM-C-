using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using WebForum.Model;

namespace WebForum.Pages.PostList
{
    public class HomeModel : PageModel
    {
        private ApplicationDbContext _db;

        public HomeModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Post Post { get; set; }
        public Comment Comment { get; set; }
        //public User User { get; set; }

        public async Task OnGet(string id)
        {
            Post = await _db.Posts.FindAsync(id);
        }
    }
}

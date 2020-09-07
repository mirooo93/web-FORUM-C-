using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebForum.Model;

namespace WebForum.Pages.PostList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

        //public IEnumerable<User> User { get; set; }

        public async Task OnGet()  //u razeru sve ovako nesto naziva HENDLER umisto metoda
        {
            Posts = await _db.Posts.Include(x => x.User).ToListAsync(); //async onmoguca vise radnji odjednom dok await-a
            //Comments = await _db.Comments.ToListAsync();
        }

        public IActionResult OnGetLogout()  
        {
            HttpContext.Session.Remove("username"); //provjeri jel username ili UserName?    -> username je tocno!
            HttpContext.Session.Remove("Id");
            return RedirectToPage("login");
        }

        public async Task<IActionResult> OnPostDelete (string id)
        {
            var post = await _db.Posts.FindAsync(id);
            var com = _db.Comments.Where(x => x.Post.Id == id).ToList();
            if (post == null)
            {
                return NotFound();  
            }
            _db.Posts.Remove(post);
            foreach (var i in com)
            {
                _db.Comments.Remove(i);
            }
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}

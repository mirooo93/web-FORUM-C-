using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebForum.Model;

namespace WebForum.Pages.PostList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Post Post { get; set; }

        public async Task OnGet(string id)
        {
            //id = Guid.NewGuid().ToString();
            Post = await _db.Posts.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //Post.Id = Guid.NewGuid().ToString();
                var PostFromDb = await _db.Posts.FindAsync(Post.Id);
                if (PostFromDb == null)
                {
                    return NotFound();
                }
                //var PostFromDb = await _db.Posts.fi
                //PostFromDb.t
                PostFromDb.Title = Post.Title;
                PostFromDb.Text= Post.Text;
                
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}

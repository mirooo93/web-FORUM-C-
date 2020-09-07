using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebForum.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
namespace WebForum.Pages.PostList
{
    public class ShowModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ShowModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Post Post { get; set; }

        [BindProperty]    //Bez bindanja mi ne radi Guid
        public Comment Comment { get; set; }

        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

       
        public async Task OnGet(string id)
        {
            // Comments = await _db.Comments.ToListAsync();
            Comments =  _db.Comments.Include(x => x.User).Where(x => x.Post.Id == id).ToList();

            Comment = await _db.Comments.FindAsync(id);
            Post = await _db.Posts.FindAsync(id);
        }

        //public async Task OnGet(string id)
        //{
        //    Post = await _db.Posts.FindAsync(id);
           
        //}

        public async Task<IActionResult> OnPost()
        {
            var userId = HttpContext.Session.GetString("Id");
            if (!ModelState.IsValid)
            {
                var postId = _db.Posts.Where(x => x.Id == Post.Id).SingleOrDefault();
                Comment.User = await _db.Users.FindAsync(userId);
                //Comment.Post = await _db.Posts.FindAsync("3c1e7ea6-fe70-4a62-91c9-089a9b38411d"); //valja!
                Comment.Post = await _db.Posts.FindAsync(postId.Id);
                Comment.Id = Guid.NewGuid().ToString();
                await _db.Comments.AddAsync(Comment);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}

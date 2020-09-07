using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebForum.Model;

using System.Security.Claims;
using Microsoft.AspNetCore.Http.Connections;
using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;

namespace WebForum.Pages.PostList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public string Msg;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Post Post { get; set; }

       


        public async Task<IActionResult> OnPost()
        {
            var userId = HttpContext.Session.GetString("Id");  //vrati mi loggirani Id testirano
            var userName = HttpContext.Session.GetString("Userame");
        
            if (ModelState.IsValid) 
            {
                Post.User = await _db.Users.FindAsync(userId);
                if (Post.User == null)
                {
                    Msg = "Neprijavljeni korisnik moze samo komentirati";
                    return Page();
                }
                else
                {
                    Post.Id = Guid.NewGuid().ToString();
                    await _db.Posts.AddAsync(Post);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("Index");
                }
            }
                //Post.User = await _db.Users.FindAsync("2cf34c84-c92b-4ca1-a80b-d1df606c6a0f");  //ovo hardcode-iranje mi uspije spojit kljuc
                
            else
            {
                return Page();
            }
         }
    }
}

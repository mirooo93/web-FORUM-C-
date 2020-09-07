using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebForum.Model;
using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebForum.Pages.PostList
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }

        private ApplicationDbContext db;

        public SignUpModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            user = new User();
        }

        public IActionResult OnPost() //mora sam dodat ekstenziju za ovaj BCrypt / IactionResul PROVJERI
        {
            user.Id = Guid.NewGuid().ToString();
            user.Role = "User";
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToPage("login");
        }
    }
}

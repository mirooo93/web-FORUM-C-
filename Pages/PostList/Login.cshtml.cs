using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebForum.Model;
using WebForum.Pages;

namespace WebForum.Pages.PostList
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }

        public string Msg;

        private ApplicationDbContext db;

        public LoginModel (ApplicationDbContext _db)
        {
            db = _db;
        }
    

        public void OnGet()
        {
            user = new User();
        }

        public IActionResult OnPost() //
        {
            // var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userId = db.Users.Where(x => x.UserName == user.UserName).SingleOrDefault();
            var usr = very(user.UserName, user.Password);
            if(usr == null)
            {
                HttpContext.Session.SetString("Anonymouse", usr.UserName);
                Msg = "User does not exist!";
                return Page();
            }
            else
            {
                HttpContext.Session.SetString("username", usr.UserName);
                HttpContext.Session.SetString("Id", usr.Id);
                HttpContext.Session.SetString("Role", usr.Role);
                return RedirectToPage("index");  //ovo bi ttriba bit moj INDEX
            }
        }

        private User very(string username, string password)
        {
            var user = db.Users.SingleOrDefault(a => a.UserName.Equals(username));
            if (user != null)
            {
                if(BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return user;
                }
            }
            return null;
        }
    }
}

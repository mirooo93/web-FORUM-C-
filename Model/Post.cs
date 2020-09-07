
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Model
{
    public class Post
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }
        public User User { get; set; }
        public string Image { get; set; }   //
        public string Text { get; set; }
        public DateTime PostDataTime { get; set; }
        public Post()
        {
            PostDataTime = DateTime.Now;
        }

        //public IFormFile Image { get; set; }
        public ICollection<Comment> Comments { get; set; }
        

    }
}
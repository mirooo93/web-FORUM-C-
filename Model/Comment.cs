using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Model
{
    public class Comment
    {
        public string Id { get; set; }
        
        public string Text { get; set; }
        public DateTime CommentDate { get; set; }
        public Comment()
        {
            CommentDate = DateTime.Now;
        }
        public User User { get; set; }
        public Post Post { get; set; }

      
    }
}
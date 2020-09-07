using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Model
{
    //[Table("User")]  //moze i nemora ka i key
    public class User
    { 
        public string Id { get; set; }  //string

        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }   
        public string Role { get; set; }   
        

        public ICollection<Post> Post { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}

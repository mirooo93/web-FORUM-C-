using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebForum.Model;

namespace WebForum.Repositories.Contracts
{
    public interface IWebForumRepository
    {
        Task<User> GetUser(string userId);
        Task<User> GetUserByUsername(string username);
        Task AddUser(User user);
        
        Task<Post> GetPost(string postId);
        Task AddPost(Post post);
        Task<List<Post>> GetAllPostsWithComments();
        Task DeletePost(string postId);
        
        Task<Comment> GetComment(string commentId);
        Task<List<Comment>> GetComments(string postId);
        Task<List<Comment>> GetCommentsWithUser(string postId);
        Task DeleteComments(List<string> commentIds);
        Task AddComment(Comment comment);
    }
}
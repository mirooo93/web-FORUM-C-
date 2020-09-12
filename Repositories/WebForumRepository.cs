using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebForum.Model;
using WebForum.Repositories.Contracts;

namespace WebForum.Repositories
{
    public class WebForumRepository : IWebForumRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public WebForumRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUser(string userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public async Task AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> GetPost(string postId)
        {
            throw new NotImplementedException();
        }

        public async Task AddPost(Post post)
        {
            await _dbContext.AddAsync(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Post>> GetAllPostsWithComments()
        {
            return await _dbContext.Posts.Include(p => p.Comments).ToListAsync();
        }

        public async Task DeletePost(string postId)
        {
            throw new NotImplementedException();
        }

        public async Task<Comment> GetComment(string commentId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>> GetComments(string postId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>> GetCommentsWithUser(string postId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteComments(List<string> commentIds)
        {
            throw new NotImplementedException();
        }

        public async Task AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using MVC_Thehegeo.Data;
using MVC_Thehegeo.Models.BlogModels;

namespace MVC_Thehegeo.Models.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BlogRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Post> GetList()
        {
            return _dbContext.Posts.AsEnumerable();
        }
    }
}
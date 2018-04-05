using System.Collections.Generic;
using System.Linq;
using MVC_Thehegeo.Data;
using MVC_Thehegeo.Models.BlogModels;

namespace MVC_Thehegeo.Models.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Category category)
        {
            _dbContext.Add(category);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetList()
        {
            return _dbContext.Categories.AsEnumerable();
        }
    }
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetList();
        void Add(Category category);
    }
}
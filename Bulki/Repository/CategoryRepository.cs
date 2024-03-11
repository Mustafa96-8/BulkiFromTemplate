using Bulki.Data;
using Bulki.Models;
using Bulki.Repository.IRepository;

namespace Bulki.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository

    {
        private ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context):base(context)
        {
            _context = context;    
        }
        

        public void Update(Category obj)
        {
            _context.Categories.Update(obj); 
        }
    }
}

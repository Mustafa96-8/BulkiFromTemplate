using Bulki.Data;
using Bulki.Models;
using Bulki.Repository.IRepository;

namespace Bulki.Repository
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public void Update(Product obj)
        {
            //_context.Products.Update(obj);
            var objFromDb = _context.Products.FirstOrDefault(u=>u.Id==obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Price = obj.Price;
                objFromDb.Author = obj.Author;
                objFromDb.Description = obj.Description;
                if (objFromDb.imageURL!= null)
                {
                    objFromDb.imageURL = obj.imageURL;
                }
                
            }
        }
    }
}

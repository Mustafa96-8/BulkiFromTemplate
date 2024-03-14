﻿using Bulki.Data;
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
            _context.Products.Update(obj);
        }
    }
}
using Microsoft.EntityFrameworkCore;

using ProductMicroservice.DBContext;
using ProductMicroservice.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _db;

        public ProductRepository(ProductContext db)
        {
            _db = db;
        }
        public void DeleteProduct(int productId)
        {
            var product = _db.Products.Find(productId);
            _db.Products.Remove(product);
            Save();
        }

        public Product GetProductByID(int productId)
        {
            return _db.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _db.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            _db.Add(product);
            Save();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _db.Entry(product).State = EntityState.Modified;
            Save();
        }
    }
}

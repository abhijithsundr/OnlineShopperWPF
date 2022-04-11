using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopper.Data.Services.Facade;
using OnlineShopper.Domain.Models;

namespace OnlineShopper.Data.Services.Manager
{
    public class ProductsService : IProductsService
    {
        public Task<Product> Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(int id, Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateInventory(int productId, int stockCount)
        {
            throw new NotImplementedException();
        }
    }
}

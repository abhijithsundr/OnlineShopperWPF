using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShopper.Domain.Models;
using OnlineShopper.Domain.Services.Facade;

namespace OnlineShopper.Data.Services.Manager
{
    public class ProductsService : IProductsService
    {
        private readonly OnlineShopperDbContext _context;
        private readonly DbSet<Product> _products;

        public ProductsService(OnlineShopperDbContext context)
        {
            _context = context;
            _products = context.Set<Product>();
        }

        #region Mutations
        public async Task<Product> Create(Product entity)
        {
            await _products.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _products.FindAsync(id);
            if (product is null)
            {
                throw new Exception("Product does not exist");
            }

            _products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Product> Update(Product entity)
        {
            var res = _products.Update(entity).Entity;
            await _context.SaveChangesAsync();

            return res;
        }

        public async Task<int> UpdateInventory(int productId, int stockCount)
        {
            var product = await _products.FindAsync(productId);
            if (product is null)
            {
                throw new Exception("Product does not exist");
            }

            product.Inventory = stockCount;
            await Update(product);

            return stockCount;
        }
        #endregion

        #region Queries
        public async Task<Product?> Get(int id)
        {
            return await _products.FindAsync(id);
        }

        public async Task<IAsyncEnumerable<Product>> GetAll(Expression<Func<Product,bool>> expr)
        {
            if (expr is not null)
            {
                return _products.Where(expr).AsAsyncEnumerable<Product>();
            }

            return _products.AsAsyncEnumerable<Product>();
        }
        #endregion
    }
}
